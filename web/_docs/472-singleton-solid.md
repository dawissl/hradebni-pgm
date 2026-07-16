---
layout: post
title: "Singleton a principy SOLID"
order: 472
---

Celý OOP blok — zapouzdření, dědičnost, polymorfismus, rozhraní, kompozice, generika — vám dal stavební kameny. Tahle kapitola je jiná: nepřidává nový jazykový prvek, ale pojmenovává **osvědčené vzory**, jak z těch kamenů stavět tak, aby výsledek přežil další rok vývoje. Možná zjistíte, že některé z nich už jste nevědomky použili.

---

## Singleton — návrhový vzor

**Singleton** zaručuje, že v celém programu existuje **nejvýše jedna instance** dané třídy, a nabízí k ní globální přístupový bod.

```csharp
class Konfigurace
{
    private static Konfigurace instance;

    public string NazevAplikace { get; set; }

    private Konfigurace() { }   // soukromý konstruktor — nikdo zvenčí nevytvoří vlastní instanci

    public static Konfigurace Instance
    {
        get
        {
            if (instance == null)
                instance = new Konfigurace();
            return instance;
        }
    }
}
```

```csharp
Konfigurace.Instance.NazevAplikace = "Moje aplikace";
Console.WriteLine(Konfigurace.Instance.NazevAplikace);
```

Klíčové detaily:

- Konstruktor je **`private`** (kapitola **Zapouzdření**) — zvenčí nejde napsat `new Konfigurace()`, jediná cesta k instanci vede přes `Instance`.
- `instance` je **`static`** (kapitola **Třída a objekt**) — patří celé třídě, ne konkrétnímu objektu, takže existuje jen jednou bez ohledu na to, kolikrát se na `Konfigurace.Instance` sáhne.
- Při prvním volání `Instance` se objekt vytvoří; při každém dalším volání se vrací **ta samá** instance.

### Kdy se hodí, a kdy je to problém

Typické použití: konfigurace aplikace, logování, připojení k databázi — věci, kterých má smysl mít v programu jen jednu sdílenou kopii.

> ⚠️ Singleton má i temnou stránku: je to v podstatě **globální proměnná v přestrojení**. Kód, který na něj spoléhá, je hůř testovatelný (nejde ho snadno nahradit něčím jiným pro test) a vytváří skryté závislosti mezi vzdálenými částmi programu. Než sáhnete po Singletonu, zvažte, jestli by nestačilo předat závislost přes konstruktor — přesně jako `SpravceUkolu` přijímal `IUloziste` v kapitole **Abstraktní třídy a rozhraní**.

---

## SOLID — pět principů návrhu

SOLID je zkratka pěti principů, které pomáhají navrhovat třídy tak, aby se daly bezpečně rozšiřovat, aniž by se rozsypal zbytek programu.

### S — Single Responsibility Principle (jedna odpovědnost)

**Třída by měla mít jediný důvod ke změně.** Tohle jste už dělali — je to stejný princip jako „jedna metoda, jeden úkol" z kapitoly **Vlastní metody**, jen aplikovaný na celou třídu místo jedné metody.

```csharp
// ❌ Třída dělá tři nesouvisející věci najednou
class Zamestnanec
{
    public string Jmeno { get; set; }
    public decimal VypocitejMzdu() { /* ... */ return 0; }
    public void UlozDoSouboru() { /* ... */ }         // úložná logika nepatří sem
    public void VytiskniVysledovku() { /* ... */ }     // ani tisková logika
}
```

Rozdělení na `Zamestnanec` (data), `MzdovaKalkulacka` (výpočet) a `TiskovaSluzba` (výstup) dá každé třídě jediný důvod ke změně.

### O — Open/Closed Principle (otevřeno pro rozšíření, zavřeno pro úpravu)

**Přidání nového chování by nemělo vyžadovat zásah do existujícího, otestovaného kódu.** Tohle jste udělali doslova v kapitole **Dědičnost**, cvičení o rozšíření hierarchie zaměstnanců o `Kucharka` — nová třída, žádný zásah do `Ucitel`, `Reditel` ani `Uklizec`. Polymorfismus z kapitoly **Polymorfismus** je hlavní nástroj, jak toho docílit.

### L — Liskov Substitution Principle (zaměnitelnost potomka za předka)

**Kdekoli program čeká předka, musí fungovat i libovolný jeho potomek — beze změny správnosti.** Klasický příklad, kdy se to porazí: `Ctverec` dědící od `Obdelnik`.

```csharp
class Obdelnik
{
    public virtual double Sirka { get; set; }
    public virtual double Vyska { get; set; }
    public double Obsah() => Sirka * Vyska;
}

class Ctverec : Obdelnik
{
    public override double Sirka
    {
        set { base.Sirka = value; base.Vyska = value; }   // čtverec musí mít stejné strany
    }
}
```

```csharp
void NastavRozmery(Obdelnik o)
{
    o.Sirka = 5;
    o.Vyska = 10;
    Console.WriteLine(o.Obsah());   // u Obdelnik: 50, u Ctverec: 100 — překvapení!
}
```

Kód, který funguje správně pro `Obdelnik`, dá u `Ctverec` jiný výsledek, než by čekal — `Ctverec` **není bezpečně zaměnitelný** za `Obdelnik`, přestože „čtverec je typem obdélníku" zní matematicky rozumně. Liskov princip říká: pokud dědičnost takhle překvapí volajícího, vztah „je typem" byl špatná volba — řešením je často kompozice (kapitola **Kompozice vs. dědičnost**) místo dědičnosti.

### I — Interface Segregation Principle (menší rozhraní před jedním obřím)

**Radši víc malých, zaměřených rozhraní než jedno velké, které nutí implementovat i to, co třída nepotřebuje.** V kapitole **Abstraktní třídy a rozhraní** jste už pracovali s `IComparable<T>` a `IUloziste` — obě jsou malá, soustředěná na jedinou schopnost (porovnat se, uložit/načíst). Kdyby existovalo jedno obrovské rozhraní `IVseUmim` s desítkami metod, každá implementující třída by musela (naprázdno) implementovat i metody, které vůbec nepotřebuje.

### D — Dependency Inversion Principle (závislost na abstrakci, ne na konkrétní třídě)

**Třída by měla záviset na rozhraní, ne na konkrétní implementaci.** Tohle jste přesně udělali v řešeném příkladu kapitoly **Abstraktní třídy a rozhraní**:

```csharp
class SpravceUkolu
{
    private IUloziste uloziste;   // závisí na rozhraní, ne na SouboroveUloziste

    public SpravceUkolu(IUloziste uloziste)
    {
        this.uloziste = uloziste;
    }
}
```

`SpravceUkolu` nezávisí na tom, jestli se ukládá do souboru nebo do paměti — závisí jen na **smlouvě** `IUloziste`. Tomu se říká **dependency injection** (vstřikování závislosti) a je to přímý důsledek principu D.

---

## Shrnutí

| Princip | Jedna věta |
|---|---|
| Singleton | Nejvýše jedna instance třídy, globálně dostupná — používejte s rozvahou |
| **S**ingle Responsibility | Třída má jediný důvod ke změně |
| **O**pen/Closed | Rozšiřitelné bez zásahu do existujícího kódu |
| **L**iskov Substitution | Potomek musí bezpečně nahradit předka |
| **I**nterface Segregation | Malá, zaměřená rozhraní místo jednoho obřího |
| **D**ependency Inversion | Závislost na rozhraní, ne na konkrétní třídě |

---

## Otázky k zamyšlení

1. Proč se Singletonu říká „globální proměnná v přestrojení"? Co přesně ho činí těžko testovatelným?
2. Proč `Ctverec : Obdelnik` porušuje Liskov princip, přestože matematicky "čtverec je typem obdélníku" zní rozumně?
3. Kapitola Abstraktní třídy a rozhraní obsahovala příklad `SpravceUkolu`/`IUloziste` ještě předtím, než jste znali název "dependency inversion". Proč funguje i bez toho, abyste princip znali jménem?

---

## Procvičení

### Řešený příklad

**Zadání:** Třída `Objednavka` (z kapitoly **Kompozice vs. dědičnost**) teď navíc počítá DPH, ukládá se do souboru a posílá e-mailem — vše v jedné třídě. Rozhodněte, který princip SOLID je porušen, a navrhněte opravu.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

Porušen je **Single Responsibility Principle** — `Objednavka` má teď tři důvody ke změně: změna výpočtu DPH, změna formátu ukládání, změna e-mailového klienta. Kdyby se zítra změnil jen způsob odesílání e-mailu, museli byste zasahovat do třídy, která s e-mailem konceptuálně nemá nic společného.

```csharp
class Objednavka
{
    public List<Polozka> Polozky { get; set; }
    public decimal CelkovaCena() { /* ... */ return 0; }
}

class DphKalkulacka
{
    public decimal SDph(decimal castka, decimal sazba) => castka * (1 + sazba);
}

class UlozisteObjednavek
{
    public void Uloz(Objednavka o) { /* ... */ }
}

class EmailoveOznameni
{
    public void Odesli(Objednavka o) { /* ... */ }
}
```

Každá třída teď má jediný důvod ke změně. Bonus: `UlozisteObjednavek` by šlo dál rozdělit za rozhraní (princip D), přesně jako `IUloziste` v kapitole Abstraktní třídy a rozhraní — a `Objednavka` by se pak vůbec nemusela starat, kam přesně data putují.

</details>

### Samostatná cvičení

1. **Základní** — Implementujte Singleton `PocitadloPristupu`, který napříč celým programem počítá, kolikrát byla jeho `Instance` vyžádána.
2. **Pokročilejší** — Vezměte hierarchii `Tvar` → `Kruh`, `Obdelnik` z kapitoly **Abstraktní třídy a rozhraní** a ověřte, že **neporušuje** Liskov princip — napište metodu, která přijme `Tvar` a spočítá jeho obsah, a ukažte, že funguje stejně korektně pro libovolného potomka.
3. **Bonus (*)** — Najděte ve vlastním starším projektu třídu, která dělá „moc věcí najednou" (porušuje S). Navrhněte (stačí návrh, nemusíte implementovat), jak byste ji rozdělili.
