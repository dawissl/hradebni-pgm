---
layout: post
title: "Delegáti a vlastní události"
order: 541
---

V kapitole **Události a event handlery** jste psali `button.Click += tlacitko_Click;` a `textBox.TextChanged += ...` — *přihlašovali* jste se k událostem, které už existovaly. Nikdy jsme si ale neřekli, jak takovou událost **vytvořit sami**, ani co přesně `+=` v tomto kontextu dělá. Odpověď na obojí jsou **delegáti**.

---

## Delegát — "typ pro metody"

Až doteď měly proměnné typ jako `int`, `string`, `Student`. Delegát je typ, jehož hodnotou je **odkaz na metodu** — proměnná, do které nedáte číslo ani objekt, ale samotnou metodu, kterou pak můžete zavolat později, přes tuto proměnnou.

```csharp
delegate int Operace(int a, int b);   // deklarace typu delegáta

int Secti(int a, int b) => a + b;
int Vynasob(int a, int b) => a * b;

Operace op = Secti;          // proměnná typu Operace ukazuje na metodu Secti
Console.WriteLine(op(3, 4)); // 7 — zavolá Secti(3, 4)

op = Vynasob;
Console.WriteLine(op(3, 4)); // 12 — teď stejná proměnná ukazuje na Vynasob
```

Deklarace `delegate int Operace(int a, int b);` říká: *"Operace je typ pro jakoukoli metodu, která přijme dva `int` a vrátí `int`."* Jakákoli metoda s touto signaturou (bez ohledu na název) se do proměnné typu `Operace` vejde.

---

## K čemu je to dobré — metoda jako parametr

Delegát umožňuje předat metodu jako **argument jiné metodě** — přesně jako jste zvyklí předávat `int` nebo `string`:

```csharp
void ZpracujDvojici(int a, int b, Operace operace)
{
    int vysledek = operace(a, b);
    Console.WriteLine($"Výsledek: {vysledek}");
}

ZpracujDvojici(5, 3, Secti);     // Výsledek: 8
ZpracujDvojici(5, 3, Vynasob);   // Výsledek: 15
```

`ZpracujDvojici` neví (a nemusí vědět) předem, jaký konkrétní výpočet se provede — o to se stará ten, kdo metodu volá. Tomu se říká **předání chování jako dat**.

---

## `Func<>` a `Action<>` — vestavění delegáti

Deklarovat si vlastní typ delegáta pro každou kombinaci parametrů by bylo zdlouhavé. .NET proto nabízí dva obecné (generické — kapitola **Generika**) delegáty, které pokryjí naprostou většinu případů:

| Delegát | Kdy použít | Příklad typu |
|---|---|---|
| `Action<...>` | Metoda **nic nevrací** (`void`) | `Action<int, int>` — dva `int` parametry, žádný návrat |
| `Func<..., TResult>` | Metoda **něco vrací** — poslední typový parametr je návratový typ | `Func<int, int, int>` — dva `int` parametry, vrací `int` |

```csharp
Func<int, int, int> operace = Secti;
Console.WriteLine(operace(3, 4));   // 7

Action<string> vypis = Console.WriteLine;
vypis("Ahoj!");                     // Ahoj!
```

Vlastní `delegate Operace` z úvodu kapitoly bychom tedy v praxi vůbec nemuseli psát — `Func<int, int, int>` dělá přesně totéž. Až se dostanete k lambda výrazům v příští kapitole, uvidíte `Func<>`/`Action<>` téměř na každém řádku — jsou to typy, kterými se lambda výrazy nejčastěji zapisují do proměnné.

---

## Multicast — proč `+=`, a ne `=`

Delegát nemusí ukazovat jen na jednu metodu. Operátorem `+=` můžete **přidat** další metodu, aniž byste tu předchozí ztratili:

```csharp
Action<string> logovani = null;
logovani += zprava => Console.WriteLine($"[LOG] {zprava}");
logovani += zprava => File.AppendAllText("log.txt", zprava + "\n");

logovani("Aplikace spuštěna.");
// zavolá OBĚ metody — vypíše na konzoli i zapíše do souboru
```

Tohle je přesně mechanismus za `button.Click += tlacitko_Click;` z kapitoly **Události a event handlery**. `Click` je delegát (konkrétně typu `EventHandler`) a `+=` k němu **přidává** další metodu k zavolání, místo aby tu předchozí obsluhu nahradilo. Proto může jedno tlačítko mít teoreticky víc obslužných metod na tutéž událost.

---

## Vlastní událost — klíčové slovo `event`

Teď složíme delegáta a `+=` do vlastní události. Klíčové slovo `event` omezuje, co s delegátem může dělat kód *zvenčí* třídy — cizí kód se může jen **přihlásit** (`+=`) nebo **odhlásit** (`-=`), ale nemůže událost zvenčí přímo zavolat ani přepsat (`=`). Volat ji může jen třída, která ji vlastní.

```csharp
class Teplomer
{
    public event Action<double> PrekrocenaHranice;

    private double hranice;

    public Teplomer(double hranice)
    {
        this.hranice = hranice;
    }

    public void NastavTeplotu(double teplota)
    {
        if (teplota > hranice)
        {
            PrekrocenaHranice?.Invoke(teplota);   // vyvolá událost, pokud má někdo přihlášeno
        }
    }
}
```

```csharp
Teplomer teplomer = new Teplomer(30);

teplomer.PrekrocenaHranice += t =>
    Console.WriteLine($"⚠️ Teplota {t} °C překročila hranici!");

teplomer.NastavTeplotu(25);   // nic se nevypíše
teplomer.NastavTeplotu(35);   // ⚠️ Teplota 35 °C překročila hranici!
```

Několik důležitých detailů:

- `PrekrocenaHranice?.Invoke(teplota)` — `?.` (kapitola **Nullable typy a operátory ?., ??, ??=**) ochrání proti volání, když se ještě nikdo nepřihlásil (`PrekrocenaHranice` by bylo `null`).
- `Invoke(...)` je způsob, jak delegát/událost skutečně **zavolat** — ekvivalent zápisu `PrekrocenaHranice(teplota)`, ale bezpečnější v kombinaci s `?.`.
- Zvenčí třídy `Teplomer` nejde napsat `teplomer.PrekrocenaHranice(35)` ani `teplomer.PrekrocenaHranice = novaMetoda` — `event` tohle záměrně zakazuje. Cizí kód se může jen přihlásit nebo odhlásit.

---

## `EventArgs` — konvenční tvar události

Vestavěné WinForms události, které jste používali (`Click`, `TextChanged`), mají všechny stejný tvar: `(object sender, EventArgs e)`. Je to konvence, ne nutnost — ale je dobré ji znát a případně následovat, hlavně pokud vaši událost bude používat víc lidí:

```csharp
class PrekrocenaHranicEventArgs : EventArgs
{
    public double NamerenaTeplota { get; }
    public PrekrocenaHranicEventArgs(double teplota) => NamerenaTeplota = teplota;
}

class Teplomer
{
    public event EventHandler<PrekrocenaHranicEventArgs> PrekrocenaHranice;

    public void NastavTeplotu(double teplota, double hranice)
    {
        if (teplota > hranice)
            PrekrocenaHranice?.Invoke(this, new PrekrocenaHranicEventArgs(teplota));
    }
}
```

```csharp
teplomer.PrekrocenaHranice += (sender, e) =>
    Console.WriteLine($"Hranice překročena, naměřeno {e.NamerenaTeplota} °C");
```

`EventHandler<T>` je vestavěný generický delegát přesně pro tento účel — `sender` řekne, **který** objekt událost vyvolal (užitečné, když jeden handler obsluhuje víc objektů, stejně jako v kapitole o událostech), `e` nese doplňující data specifická pro danou událost.

---

## Shrnutí

| Pojem | Co znamená |
|---|---|
| Delegát | Typ, jehož hodnotou je odkaz na metodu |
| `Func<..., TResult>` | Vestavěný delegát pro metody, které něco vrací |
| `Action<...>` | Vestavěný delegát pro metody bez návratové hodnoty (`void`) |
| `+=` / `-=` na delegátu | Přidá / odebere metodu k zavolání (multicast) |
| `event` | Omezí delegát tak, že zvenčí lze jen `+=`/`-=`, ne přímé volání |
| `?.Invoke(...)` | Bezpečné vyvolání události, i když nemá přihlášeného posluchače |
| `EventHandler<T>` | Konvenční tvar události `(object sender, T e)` |

---

## Otázky k zamyšlení

1. Co je delegát a čím se liší od běžné proměnné jako `int` nebo `string`?
2. Proč `button.Click += tlacitko_Click;` nepřepíše předchozí obsluhu tlačítka, na rozdíl od `button.Click = tlacitko_Click;`?
3. Co dělá klíčové slovo `event`, které samotný delegát nedělá? Proč je to užitečné bezpečnostní omezení?

---

## Procvičení

### Řešený příklad

**Zadání:** Navrhněte třídu `Budik`, která má metodu `Tikni(int aktualniCas)` a vyvolá vlastní událost `Zvoneni`, pokud `aktualniCas` odpovídá nastavenému času zvonění. Ukažte přihlášení k události zvenčí.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

```csharp
class Budik
{
    public event Action Zvoneni;

    private int casZvoneni;

    public Budik(int casZvoneni)
    {
        this.casZvoneni = casZvoneni;
    }

    public void Tikni(int aktualniCas)
    {
        if (aktualniCas == casZvoneni)
        {
            Zvoneni?.Invoke();
        }
    }
}
```

```csharp
Budik budik = new Budik(700);   // zvoní v 7:00

budik.Zvoneni += () => Console.WriteLine("🔔 Vstávej!");
budik.Zvoneni += () => Console.WriteLine("Rozsvěť se, kávovar startuje.");

budik.Tikni(650);   // nic
budik.Tikni(700);   // 🔔 Vstávej!
                     // Rozsvěť se, kávovar startuje.
```

Zde `Action` (bez typových parametrů) znamená "metoda bez parametrů a bez návratové hodnoty" — přesně to, co `Zvoneni` potřebuje. Dvě přihlášené metody se zavolají obě, v pořadí, ve kterém byly přidány.

</details>

### Samostatná cvičení

1. **Základní** — Rozšiřte `Teplomer` z kapitoly o druhou událost `PoklesPodHranici`, která se vyvolá symetricky při podkročení dolní hranice.
2. **Pokročilejší** — Navrhněte třídu `NakupniKosik` s metodou `PridatPolozku(string nazev, decimal cena)` a událostí `CelkovaCenaPrekrocila`, která se vyvolá, jakmile celková cena všech položek překročí zadaný limit. Použijte `EventArgs` s informací o aktuální ceně.
3. **Bonus (*)** — Zjistěte, jak se v novějším C# zapisuje multicast delegát bez lambda výrazu pomocí jmenných metod, a proč je u událostí důležité se z nich také **odhlásit** (`-=`), pokud objekt, který odhlašuje, přestane existovat dřív než ten, ke kterému je přihlášen. (Nápověda: souvislost s kapitolou **Garbage collector**.)
