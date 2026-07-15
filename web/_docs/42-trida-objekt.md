---
layout: post
title: "Třída a objekt"
order: 420
---

Třída je šablona — popis struktury. Objekt je konkrétní věc vytvořená podle té šablony. Tato kapitola ukazuje, jak třídy definovat, jak z nich vytvářet objekty a jak pracovat s jejich daty a chováním.

---

## Definice třídy

```csharp
class Osoba
{
    // atributy (pole)
    public string Jmeno;
    public int Vek;

    // metoda
    public void Pozdrav()
    {
        Console.WriteLine($"Ahoj, jsem {Jmeno} a je mi {Vek} let.");
    }
}
```

Třídu definujeme klíčovým slovem `class`, následuje název (konvence: PascalCase) a tělo ve složených závorkách.

---

## Atributy a metody

**Atributy** (pole, fields) jsou proměnné patřící třídě — uchovávají stav objektu.

**Metody** jsou funkce patřící třídě — definují chování objektu.

```csharp
class Obdelnik
{
    public double Sirka;   // atribut
    public double Vyska;   // atribut

    public double Obsah()  // metoda
    {
        return Sirka * Vyska;
    }

    public double Obvod()  // metoda
    {
        return 2 * (Sirka + Vyska);
    }
}
```

---

## Vytvoření objektu — klíčové slovo `new`

Objekt (instanci třídy) vytvoříme operátorem `new`:

```csharp
Osoba prvni = new Osoba();
prvni.Jmeno = "Tomáš";
prvni.Vek = 25;
prvni.Pozdrav();  // Ahoj, jsem Tomáš a je mi 25 let.

Osoba druha = new Osoba();
druha.Jmeno = "Jana";
druha.Vek = 30;
druha.Pozdrav();  // Ahoj, jsem Jana a je mi 30 let.
```

Každý objekt má vlastní kopii atributů. Změna `prvni.Jmeno` nijak neovlivní `druha.Jmeno`.

---

## Konstruktor

Konstruktor je speciální metoda, která se spustí při vytvoření objektu (`new`). Slouží k inicializaci atributů.

### Implicitní konstruktor

Pokud žádný konstruktor nedefinujete, C# automaticky vytvoří prázdný (implicitní) konstruktor — ten inicializuje atributy na výchozí hodnoty (`0`, `null`, `false`).

### Vlastní konstruktor

```csharp
class Osoba
{
    public string Jmeno;
    public int Vek;

    // vlastní konstruktor
    public Osoba(string jmeno, int vek)
    {
        Jmeno = jmeno;
        Vek = vek;
    }

    public void Pozdrav()
    {
        Console.WriteLine($"Ahoj, jsem {Jmeno} a je mi {Vek} let.");
    }
}
```

Vytvoření objektu s konstruktorem:

```csharp
Osoba o = new Osoba("Tomáš", 25);
o.Pozdrav();
```

Výhoda: objekt je ihned po vytvoření v platném stavu — není možné zapomenout inicializovat atribut.

> 💡 Pokud definujete vlastní konstruktor s parametry, implicitní konstruktor **přestane existovat**. Pokud ho stále potřebujete (bez parametrů), musíte ho dopsat ručně.

### Přetěžování konstruktorů

Třída může mít více konstruktorů s různými parametry:

```csharp
class Osoba
{
    public string Jmeno;
    public int Vek;

    public Osoba(string jmeno) : this(jmeno, 0)   // delegace na druhý konstruktor
    {
    }

    public Osoba(string jmeno, int vek)
    {
        Jmeno = jmeno;
        Vek = vek;
    }
}
```

> 💡 `: this(jmeno, 0)` přesměruje volání na **jiný konstruktor téže třídy** — inicializační logika existuje jen jednou, v konstruktoru se všemi parametry. Bez `this(...)` by se `Jmeno = jmeno;` musel opakovat v obou konstruktorech. Stejný princip, jen v rámci jedné třídy, jako `base(...)` pro volání konstruktoru předka (viz kapitola **Dědičnost**).

---

## Properties (vlastnosti)

> 💡 Se zápisem `{ get; set; }` jsme se krátce a neformálně setkali už v kapitole **Dekompozice a návrh aplikace** u třídy `ShoppingItem`. Teď se podíváme, co přesně dělá a jak do něj přidat vlastní logiku.

Properties jsou doporučený způsob přístupu k datům objektu — nabízejí kontrolu nad čtením a zápisem atributů.

```csharp
class Clovek
{
    private int vek;  // soukromé pole (backing field)

    public int Vek    // property
    {
        get { return vek; }
        set
        {
            if (value >= 0 && value <= 150)
                vek = value;
        }
    }
}
```

```csharp
Clovek c = new Clovek();
c.Vek = 25;   // projde přes setter
c.Vek = -5;   // setter to ignoruje
Console.WriteLine(c.Vek);  // 25
```

### Zkrácený zápis (auto-implemented property)

Pokud žádnou logiku v getru/setru nepotřebujete:

```csharp
public string Jmeno { get; set; }
public int Vek { get; private set; }  // jen pro čtení zvenčí
```

---

## Statické vs. instanční členy

Doteď měl každý objekt **svoji vlastní kopii** atributů — `prvni.Jmeno` a `druha.Jmeno` byly dvě různé hodnoty. Tomu se říká **instanční** člen — patří konkrétnímu objektu (instanci).

Klíčové slovo `static` říká: tento člen **nepatří žádnému konkrétnímu objektu, ale celé třídě** — existuje jen jednou, sdílený všemi instancemi.

```csharp
class Pocitac
{
    public static int PocetVytvorenych = 0;   // static – jedna hodnota pro všechny objekty
    public int Cislo;                          // instanční – každý objekt má svoje

    public Pocitac()
    {
        PocetVytvorenych++;       // zvýší se společné počítadlo
        Cislo = PocetVytvorenych; // uloží se do vlastního pole objektu
    }
}
```

```csharp
Pocitac a = new Pocitac();
Pocitac b = new Pocitac();
Pocitac c = new Pocitac();

Console.WriteLine(Pocitac.PocetVytvorenych);  // 3 – static člen se volá přes NÁZEV TŘÍDY
Console.WriteLine(a.Cislo);  // 1
Console.WriteLine(b.Cislo);  // 2
Console.WriteLine(c.Cislo);  // 3
```

> 💡 Static člen se čte a zapisuje přes **název třídy** (`Pocitac.PocetVytvorenych`), ne přes konkrétní objekt. Proto `static void Main()` — vstupní bod programu se spouští ještě dřív, než existuje jakýkoli objekt, takže musí patřit celé třídě, ne instanci.

| | Instanční člen | Statický člen (`static`) |
|---|---|---|
| Patří | Konkrétnímu objektu | Celé třídě |
| Kolik kopií existuje | Jedna pro každý objekt | Jedna jediná, sdílená |
| Přístup | `objekt.Cislo` | `NazevTridy.PocetVytvorenych` |
| Typický příklad | `Jmeno`, `Vek` konkrétní osoby | Počítadlo vytvořených objektů, konstanty |

---

## Shrnutí

```csharp
class NazevTridy
{
    // atributy
    public datovyTyp NazevAtributu;

    // konstruktor
    public NazevTridy(parametry)
    {
        // inicializace
    }

    // property
    public datovyTyp NazevProperty { get; set; }

    // metoda
    public navratovyTyp NazevMetody()
    {
        // logika
    }
}

// vytvoření objektu
NazevTridy obj = new NazevTridy(argumenty);
```

| Pojem | Vysvětlení |
|---|---|
| Atribut (pole) | Proměnná patřící třídě, uchovává stav |
| Metoda | Funkce patřící třídě, definuje chování |
| Konstruktor | Spustí se při `new`, inicializuje objekt |
| `: this(...)` | Delegace na jiný konstruktor téže třídy |
| Property | Řízený přístup k atributu přes get/set |
| `new` | Operátor pro vytvoření instance |
---

## Otázky k zamyšlení

1. Vysvětlete vztah třídy a objektu na vlastní analogii (ne formička/cukroví — vymyslete jinou).
2. Co je konstruktor a co se stane, když ho nedefinujete? Proč mít konstruktor s parametry?
3. Dvě proměnné odkazují na tentýž objekt. Co se stane, když jednu z nich změníte? Jak vzniknou dva nezávislé objekty?

---

## Procvičení

### Řešený příklad

**Zadání:** Vytvořte třídu `BankovniUcet` s vlastníkem a zůstatkem, konstruktorem, metodami `Vloz(castka)` a `Vyber(castka)` (výběr nesmí jít do minusu — vrací `bool`) a metodou `Vypis()`. V `Main` předveďte použití.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

```csharp
class BankovniUcet
{
    public string Vlastnik;
    private decimal zustatek;   // private – nikdo zvenku ho nesmí nastavit napřímo

    public BankovniUcet(string vlastnik, decimal pocatecniVklad)
    {
        Vlastnik = vlastnik;
        zustatek = pocatecniVklad;
    }

    public void Vloz(decimal castka)
    {
        if (castka > 0) zustatek += castka;
    }

    public bool Vyber(decimal castka)
    {
        if (castka <= 0 || castka > zustatek)
            return false;       // nepovolený výběr
        zustatek -= castka;
        return true;
    }

    public void Vypis()
    {
        Console.WriteLine($"Účet {Vlastnik}: {zustatek} Kč");
    }
}

class Program
{
    static void Main()
    {
        BankovniUcet ucet = new BankovniUcet("Jan Novák", 1000);
        ucet.Vloz(500);

        if (!ucet.Vyber(2000))
            Console.WriteLine("Výběr zamítnut – nedostatečný zůstatek.");

        ucet.Vypis();   // Účet Jan Novák: 1500 Kč
    }
}
```

Klíčová myšlenka: `zustatek` je `private`, takže **jediná cesta**, jak ho změnit, vede přes metody — a ty hlídají pravidla (žádný minus). To je první ochutnávka principu, kterému se bude věnovat celá kapitola **Zapouzdření**.

</details>

### Samostatná cvičení

1. **Základní** — Vytvořte třídu `Kniha` (název, autor, počet stran) s konstruktorem a metodou `Predstav()`. Vytvořte `List<Kniha>` se třemi knihami a všechny představte.
2. **Pokročilejší** — Vytvořte třídu `Hrac` (jméno, životy, skóre) s metodami `PridejSkore`, `UberZivot` a vlastností/metodou `JeVeHre` (životy > 0). Simulujte krátkou hru dvou hráčů.
3. **Bonus (*)** — Přidejte třídě `BankovniUcet` statické počítadlo vytvořených účtů a automatické číslo účtu přidělované v konstruktoru. Vysvětlete rozdíl mezi statickým a instančním polem.