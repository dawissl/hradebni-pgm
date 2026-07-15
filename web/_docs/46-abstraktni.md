---
layout: post
title: "Abstraktní třídy a rozhraní"
order: 46
---

Abstraktní třídy a rozhraní jsou nástroje pro **definici kontraktu** — říkají, co musí potomek nebo implementátor umět, aniž by určovaly, jak to dělat. Jsou základem pro navrhování flexibilní a rozšiřitelné architektury.

---

## Abstraktní třída

> 💡 S `abstract` jsme se krátce setkali už v kapitole **Dědičnost**, v řešeném příkladu s hierarchií zaměstnanců. Teď se na klíčové slovo podíváme systematicky.

Abstraktní třída nemůže mít přímé instance — slouží výhradně jako základ pro odvozené třídy.

```csharp
abstract class Tvar
{
    public Color Barva { get; set; }

    // Abstraktní metoda — bez těla, potomek MUSÍ implementovat
    public abstract double Obsah();
    public abstract double Obvod();

    // Normální metoda — potomek dědí, může přepsat
    public void VypisInfo()
    {
        Console.WriteLine($"Obsah: {Obsah():F2}, Obvod: {Obvod():F2}");
    }
}
```

```csharp
class Kruh : Tvar
{
    public double Polomer { get; set; }

    public override double Obsah() => Math.PI * Polomer * Polomer;
    public override double Obvod() => 2 * Math.PI * Polomer;
}

class Obdelnik : Tvar
{
    public double Sirka { get; set; }
    public double Vyska { get; set; }

    public override double Obsah() => Sirka * Vyska;
    public override double Obvod() => 2 * (Sirka + Vyska);
}
```

```csharp
List<Tvar> tvary = new List<Tvar>
{
    new Kruh { Polomer = 5, Barva = Color.Red },
    new Obdelnik { Sirka = 4, Vyska = 6, Barva = Color.Blue }
};

foreach (Tvar t in tvary)
    t.VypisInfo();

// Tvar t = new Tvar();  ❌ abstraktní třídu nelze instancovat
```

---

## Rozhraní (interface)

Rozhraní je čistý kontrakt — definuje **pouze signatury** metod a properties, žádnou implementaci. Třída, která rozhraní implementuje, musí dodat všechny metody.

```csharp
interface IVykreslitelny
{
    void Vykresli(Graphics g);
}

interface IUlozitelny
{
    void Uloz(string cesta);
    void Nacti(string cesta);
}
```

Implementace rozhraní:

```csharp
class MujDiagram : IVykreslitelny, IUlozitelny
{
    public void Vykresli(Graphics g)
    {
        // konkrétní implementace kreslení
    }

    public void Uloz(string cesta)
    {
        // uložení do souboru
    }

    public void Nacti(string cesta)
    {
        // načtení ze souboru
    }
}
```

> 💡 Třída může implementovat **více rozhraní** — ale dědit jen od jedné třídy. Rozhraní jsou proto způsob, jak získat „vícenásobnou dědičnost" v C#.

---

## Předdefinovaná rozhraní v C#

C# obsahuje řadu standardních rozhraní, která třídy implementují, aby získaly určité chování.

### `IComparable<T>` — porovnávání pro řazení

```csharp
class Student : IComparable<Student>
{
    public string Jmeno { get; set; }
    public double Prumer { get; set; }

    public int CompareTo(Student other)
    {
        return this.Prumer.CompareTo(other.Prumer);
    }
}
```

```csharp
List<Student> studenti = new List<Student> { ... };
studenti.Sort();  // funguje, protože Student implementuje IComparable
```

### `IEnumerable<T>` — možnost procházet `foreach`

Pokud třída implementuje `IEnumerable<T>`, lze ji procházet pomocí `foreach`. Kolekce jako `List<T>` a pole toto rozhraní implementují automaticky.

---

## Abstraktní třída vs. rozhraní

| | Abstraktní třída | Rozhraní |
|---|---|---|
| Může mít implementaci? | ✅ ano (normální metody) | ❌ ne (jen signatury) |
| Může mít pole/atributy? | ✅ ano | ❌ ne |
| Více dědičnosti? | ❌ jen od jedné třídy | ✅ třída může implementovat více |
| Kdy použít? | Sdílená implementace pro příbuzné třídy | Kontrakt pro nesouvisející třídy |

**Pravidlo palce:** pokud třídy sdílejí kód a jsou si příbuzné (Kruh, Obdélník) → abstraktní třída. Pokud potřebujete zajistit, že různé třídy nabídnou určité chování (Uložitelný, Vykreslitelný) → rozhraní.

---

## Shrnutí

```csharp
// Abstraktní třída
abstract class Predek
{
    public abstract void MustImplement();  // potomek musí implementovat
    public void Hotova() { ... }           // potomek zdědí
}

// Rozhraní
interface IKontrakt
{
    void Metoda1();
    int Metoda2(string s);
}

// Implementace
class Trida : Predek, IKontrakt
{
    public override void MustImplement() { ... }
    public void Metoda1() { ... }
    public int Metoda2(string s) { ... }
}
```
---

## Otázky k zamyšlení

1. Jaký je rozdíl mezi abstraktní třídou a rozhraním (interface)? Co může obsahovat jedna a co druhé?
2. Proč třída může implementovat více rozhraní, ale dědit jen z jedné třídy?
3. Rozhraní je "smlouva". Co to znamená pro kód, který s rozhraním pracuje? Proč mu nevadí, jaká konkrétní třída za ním stojí?

---

## Procvičení

### Řešený příklad

**Zadání (návrhové + kód):** V aplikaci potřebujete ukládat data do souboru, do databáze a při testování do paměti. Navrhněte rozhraní `IUloziste` a ukažte, jak díky němu třída `SpravceUkolu` nemusí vědět, kam se ukládá.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

```csharp
interface IUloziste
{
    void Uloz(List<string> polozky);
    List<string> Nacti();
}

class SouboroveUloziste : IUloziste
{
    public void Uloz(List<string> polozky) => File.WriteAllLines("ukoly.txt", polozky);
    public List<string> Nacti() =>
        File.Exists("ukoly.txt") ? File.ReadAllLines("ukoly.txt").ToList() : new List<string>();
}

class PametoveUloziste : IUloziste    // pro testy – nic nezapisuje na disk
{
    private List<string> data = new List<string>();
    public void Uloz(List<string> polozky) => data = new List<string>(polozky);
    public List<string> Nacti() => new List<string>(data);
}

class SpravceUkolu
{
    private IUloziste uloziste;       // zná jen smlouvu, ne konkrétní třídu

    public SpravceUkolu(IUloziste uloziste)
    {
        this.uloziste = uloziste;
    }

    public void PridejUkol(string ukol)
    {
        List<string> ukoly = uloziste.Nacti();
        ukoly.Add(ukol);
        uloziste.Uloz(ukoly);
    }
}

// použití:
var spravce = new SpravceUkolu(new SouboroveUloziste());
// v testu jen:  new SpravceUkolu(new PametoveUloziste());
```

`SpravceUkolu` se o způsobu uložení nedozví vůbec nic — a přesně proto lze úložiště vyměnit jediným řádkem. Předání závislosti konstruktorem se říká *dependency injection* a je to jeden z nejužitečnějších návyků, který si z OOP odnesete.

</details>

### Samostatná cvičení

1. **Základní** — Vytvořte rozhraní `IHratelne` s metodami `Start()`, `Konec()` a implementujte ho ve dvou třídách her. Napište metodu, která přijme `IHratelne` a hru "odehraje".
2. **Pokročilejší** — Rozhodněte a zdůvodněte pro každý případ, zda použít abstraktní třídu, nebo rozhraní: (a) společný základ všech zaměstnanců se sdíleným kódem, (b) schopnost "dá se vytisknout" napříč nesouvisejícími třídami, (c) tvar s povinnou metodou Obsah a hotovou metodou Vypis.
3. **Bonus (*)** — Implementujte u třídy `Student` rozhraní `IComparable<Student>` (porovnání podle průměru) a ověřte, že `List<Student>.Sort()` začne fungovat bez dalších parametrů.