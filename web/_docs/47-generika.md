---
layout: post
title: "Generika"
order: 471
---

V kapitole **List a Dictionary** jsme narazili na zápis `List<T>` a slíbili si, že se k typovému parametru `T` vrátíme podrobněji u OOP. Teď je ten správný čas — ukážeme si, jak si vlastní generickou třídu nebo metodu napsat sami, ne jen používat hotové (`List<T>`, `Dictionary<TKey, TValue>`), se kterými pracujete od kapitoly o kolekcích.

---

## Problém, který generika řeší

Představte si zásobník (LIFO — poslední dovnitř, první ven), který umí pracovat jen s `int`:

```csharp
class IntZasobnik
{
    private List<int> data = new List<int>();

    public void Push(int item) => data.Add(item);

    public int Pop()
    {
        int posledni = data[data.Count - 1];
        data.RemoveAt(data.Count - 1);
        return posledni;
    }
}
```

Teď potřebujete stejný zásobník pro `string`. Zkopírujete třídu, přepíšete `int` na `string`, vznikne `StringZasobnik`. Pro `Student` totéž znovu. Kód je identický až na jeden datový typ — přesně tomu se chceme vyhnout (stejný princip jako u dekompozice: opakovaný kód je signál, že něco navrhujeme špatně).

### Alternativa: `object`

Dá se to řešit i jinak — nahradit `int` typem `object`, který umí uchovat cokoli:

```csharp
class ObjectovyZasobnik
{
    private List<object> data = new List<object>();
    public void Push(object item) => data.Add(item);
    public object Pop() { /* ... */ return data[0]; }
}
```

```csharp
ObjectovyZasobnik z = new ObjectovyZasobnik();
z.Push(42);
z.Push("text");           // ❌ nic nezastaví smíchání typů
int cislo = (int)z.Pop();  // musíte pamatovat, co jste tam vlastně dali, a přetypovat
```

Funguje to, ale za cenu ztráty **typové bezpečnosti** — kompilátor nic nezkontroluje, `Push("text")` do zásobníku čísel projde bez varování, a při čtení musíte ručně přetypovávat. U hodnotových typů (`int`, `struct`...) navíc `object` znamená **boxing** — zabalení hodnoty do objektu na haldě, což stojí čas i paměť navíc (k tomu se vrátíme níže).

Generika řeší oba problémy najednou.

---

## Generická třída

Zápis `<T>` za názvem třídy zavádí **typový parametr** — zástupný symbol za konkrétní typ, který se doplní až při použití.

```csharp
class Zasobnik<T>
{
    private List<T> data = new List<T>();

    public void Push(T item) => data.Add(item);

    public T Pop()
    {
        T posledni = data[data.Count - 1];
        data.RemoveAt(data.Count - 1);
        return posledni;
    }

    public int Count => data.Count;
}
```

Použití:

```csharp
Zasobnik<int> cisla = new Zasobnik<int>();
cisla.Push(5);
cisla.Push(10);
int vrchol = cisla.Pop();   // 10 — žádný cast, kompilátor ví, že Pop() vrací int

Zasobnik<string> jmena = new Zasobnik<string>();
jmena.Push("Kamil");
jmena.Push(42);             // ❌ CHYBA PŘI KOMPILACI — Zasobnik<string> přijímá jen string
```

> 💡 S přesně tímto zápisem jste se setkali už dřív — `List<T>` a `Dictionary<TKey, TValue>` jsou obě generické třídy z .NET, jen jste je dosud pouze *používali*. Teď víte, jak takovou třídu napsat sami: `Zasobnik<int>` a `List<int>` jsou stejný princip, jen jednu z nich jste právě napsali vy.

Jedna třída, `Count` typů použití — beze zkopírování jediného řádku kódu.

---

## Generická metoda

Někdy nechcete generickou celou třídu, jen jednu metodu:

```csharp
T Max<T>(T a, T b) where T : IComparable<T>
{
    return a.CompareTo(b) > 0 ? a : b;
}
```

```csharp
Console.WriteLine(Max(5, 10));           // 10
Console.WriteLine(Max("Ahoj", "Zdar"));  // Zdar — abecedně dál než "Ahoj"
```

`<T>` se tu píše mezi název metody a kulaté závorky s parametry. Kompilátor odvodí `T` z toho, co skutečně předáte (`Max(5, 10)` → `T` je `int`), stejně jako to znáte od `List<T>`.

Všimněte si `where T : IComparable<T>` za signaturou — to je **omezení typového parametru**, bez kterého by se metoda vůbec nepřeložila.

---

## Omezení typového parametru (`where`)

Bez omezení kompilátor o `T` neví vůbec nic — nemůže si být jistý, že `T` umí `CompareTo()`, má konstruktor, nebo je to referenční typ. `where` mu to řekne dopředu.

| Omezení | Co zajišťuje |
|---|---|
| `where T : IComparable<T>` | `T` umí porovnání přes `CompareTo()` |
| `where T : class` | `T` musí být referenční typ |
| `where T : struct` | `T` musí být hodnotový typ |
| `where T : new()` | `T` musí mít bezparametrický konstruktor |
| `where T : NazevRozhrani` | `T` musí implementovat dané rozhraní |

> 💡 Rozhraní `IComparable<T>` jsme naimplementovali u třídy `Student` v kapitole **Abstraktní třídy a rozhraní** — přesně tahle schopnost (umět se s někým porovnat) je to, co omezení `where T : IComparable<T>` po `T` vyžaduje. Bez `IComparable<T>` by `a.CompareTo(b)` uvnitř `Max<T>` nešlo zkompilovat, protože ne každý typ tuto metodu má.

---

## Víc typových parametrů

`Dictionary<TKey, TValue>` znáte — dva typové parametry oddělené čárkou. Stejně si můžete napsat vlastní generickou třídu se dvěma parametry:

```csharp
class Dvojice<T1, T2>
{
    public T1 Prvni { get; set; }
    public T2 Druhy { get; set; }
}
```

```csharp
Dvojice<string, int> zaznam = new Dvojice<string, int>
{
    Prvni = "Kamil",
    Druhy = 17
};
```

`T1` a `T2` mohou (ale nemusí) být stejný typ — stejně jako u `Dictionary` klíč a hodnota nemusí být stejného druhu.

---

## Proč generika, a ne jen `object`?

| | `object` | Generika (`T`) |
|---|---|---|
| Typová bezpečnost | ❌ kontrola až za běhu (nebo žádná) | ✅ kontrola při kompilaci |
| Přetypování při čtení | Nutné (`(int)hodnota`) | Není potřeba |
| Boxing hodnotových typů | ✅ ano — navíc paměť i čas | ❌ ne |
| Čitelnost signatury | Nejasné, co metoda skutečně čeká | `Zasobnik<Student>` je jasné na první pohled |

> ⚠️ **Boxing** je přesně ten důvod, proč jsou `List<int>` nebo `Zasobnik<int>` rychlejší než jejich `object`-varianty. Hodnotový typ (`int`, `struct`) normálně žije na zásobníku. Jakmile ho vložíte do `object`, C# ho musí "zabalit" do objektu na haldě — to stojí čas i paměť navíc. Generická třída ví už při kompilaci, jaký typ obsahuje, takže box vůbec nevzniká.

---

## Shrnutí

| Pojem | Zápis |
|---|---|
| Generická třída | `class Zasobnik<T> { ... }` |
| Generická metoda | `T Max<T>(T a, T b) { ... }` |
| Použití | `Zasobnik<int> z = new Zasobnik<int>();` |
| Omezení typu | `where T : IComparable<T>` |
| Víc parametrů | `class Dvojice<T1, T2> { ... }` |
| Výhoda oproti `object` | Typová bezpečnost + žádný boxing |

---

## Otázky k zamyšlení

1. Co znamená `<T>` v názvu třídy nebo metody? Se kterými generickými třídami jste se setkali už dřív, aniž byste tehdy řešili, jak `<T>` uvnitř funguje?
2. Proč `T Max<T>(T a, T b)` s tělem `a.CompareTo(b)` nejde zkompilovat bez omezení `where T : IComparable<T>`?
3. Jaký je rozdíl mezi generickou třídou obsahující `object` a generickou třídou obsahující `T` — z pohledu typové bezpečnosti i výkonu?

---

## Procvičení

### Řešený příklad

**Zadání:** Navrhněte generickou třídu `Uloziste<T>` s metodou `Ulozit(T item)` a metodou `VratVse()` vracející `List<T>` se všemi uloženými prvky. Ukažte použití pro `int` i `string`.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

```csharp
class Uloziste<T>
{
    private List<T> polozky = new List<T>();

    public void Ulozit(T item) => polozky.Add(item);

    public List<T> VratVse() => new List<T>(polozky);
}
```

```csharp
Uloziste<int> cisla = new Uloziste<int>();
cisla.Ulozit(1);
cisla.Ulozit(2);
Console.WriteLine(string.Join(", ", cisla.VratVse()));  // 1, 2

Uloziste<string> jmena = new Uloziste<string>();
jmena.Ulozit("Kamil");
jmena.Ulozit("Jana");
Console.WriteLine(string.Join(", ", jmena.VratVse()));  // Kamil, Jana
```

Jedna třída, napsaná jednou, funguje pro libovolný typ — přesně to je smysl generik. `VratVse()` vrací **kopii** vnitřního listu (`new List<T>(polozky)`), aby volající nemohl zvenčí měnit vnitřní stav třídy přímo — stejná opatrnost, jakou jsme řešili u zapouzdření.

</details>

### Samostatná cvičení

1. **Základní** — Napište generickou metodu `bool JsouStejne<T>(T a, T b)`, která porovná dva prvky přes `Equals`. Vyzkoušejte na `int`, `string` i na vlastní třídě.
2. **Pokročilejší** — Napište generickou třídu `Pár<T>` se dvěma vlastnostmi stejného typu `T` (`Prvni`, `Druhy`) a metodou `Prohodit()`, která jejich hodnoty vymění. Vyzkoušejte na `int` i na vlastní třídě.
3. **Bonus (*)** — Rozšiřte třídu `Zasobnik<T>` z této kapitoly o metodu `Peek()` (vrátí vrchní prvek bez odebrání) a o vlastnost `IsEmpty`. Zamyslete se: proč je rozumné, aby `Pop()` na prázdném zásobníku vyhodil výjimku, místo aby tiše vrátil `default(T)`?