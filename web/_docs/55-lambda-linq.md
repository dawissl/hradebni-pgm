---
layout: post
title: "Lambda funkce a LINQ"
order: 55
---

Lambda výrazy a LINQ jsou dvě úzce propojené funkce C#, které zásadně zpřehledňují práci s kolekcemi. Místo explicitních cyklů s podmínkami napíšeš záměr přímo — „vyber studenty s průměrem pod 2, seřaď je podle příjmení."

---

## Lambda výrazy

Lambda výraz je anonymní funkce — funkce bez jména, zapsaná přímo na místě, kde ji potřebuješ.

```csharp
// Normální metoda
int Zdvoj(int x) { return x * 2; }

// Ekvivalentní lambda
(int x) => x * 2

// Zkrácená forma (typ se odvodí z kontextu)
x => x * 2
```

Syntaxe: `parametry => výraz` nebo `parametry => { příkazy; return hodnota; }`

### Příklady

```csharp
// Lambda uložená do proměnné
Func<int, int> zdvoj = x => x * 2;
Console.WriteLine(zdvoj(5));  // 10

// Lambda s více parametry
Func<int, int, int> secti = (a, b) => a + b;
Console.WriteLine(secti(3, 4));  // 7

// Lambda s blokem příkazů
Func<int, string> popis = x =>
{
    if (x > 0) return "kladné";
    if (x < 0) return "záporné";
    return "nula";
};
```

---

## LINQ — Language Integrated Query

LINQ umožňuje dotazovat se nad kolekcemi C# pomocí metod nebo dotazovací syntaxe — podobné SQL.

```csharp
List<int> cisla = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// Metody s lambda výrazy (method syntax)
var suda = cisla.Where(x => x % 2 == 0).ToList();
// → { 2, 4, 6, 8, 10 }

// Dotazovací syntaxe (query syntax)
var sudaQuery =
    (from x in cisla
     where x % 2 == 0
     select x).ToList();
```

Oba zápisy jsou ekvivalentní. V praxi se častěji používá metoda syntax — je kratší a dobře se skládá.

---

## Nejčastější LINQ metody

### Where — filtrování

```csharp
List<Student> studenti = GetStudenti();

var vybornii = studenti.Where(s => s.Prumer <= 1.5);
var plnoleti = studenti.Where(s => s.Vek >= 18);
```

### Select — transformace

```csharp
// Z listu objektů vytvoří list hodnot
List<string> jmena = studenti.Select(s => s.Jmeno).ToList();

// Transformace na anonymní typ
var prehled = studenti.Select(s => new { s.Jmeno, s.Prumer });
```

### OrderBy / OrderByDescending — řazení

```csharp
var serazeni = studenti.OrderBy(s => s.Prumer);
var sestupne = studenti.OrderByDescending(s => s.Prumer);

// Řazení podle více klíčů
var viceKlicu = studenti
    .OrderBy(s => s.Prijmeni)
    .ThenBy(s => s.Jmeno);
```

### FirstOrDefault / SingleOrDefault

```csharp
// Vrátí první shodu nebo null
Student nejlepsi = studenti.FirstOrDefault(s => s.Prumer == 1.0);

// Vrátí null pro prázdný seznam (ne výjimku)
Student prvni = studenti.FirstOrDefault();
```

### Count, Sum, Min, Max, Average

```csharp
int pocet = studenti.Count(s => s.Prumer < 2.0);
double prumer = studenti.Average(s => s.Prumer);
double nejlepsi = studenti.Min(s => s.Prumer);
```

### ToList / ToArray

LINQ dotazy jsou **líné** (lazy) — nevyhodnocují se, dokud nepotřebuješ výsledek. `ToList()` nebo `ToArray()` vynutí okamžité vyhodnocení a materializují výsledek.

```csharp
// Dotaz není vyhodnocen — jen popis
IEnumerable<Student> dotaz = studenti.Where(s => s.Prumer < 2.0);

// Teď se vyhodnotí a výsledek se uloží do listu
List<Student> vysledek = dotaz.ToList();
```

---

## Složené dotazy

LINQ metody lze skládat za sebou:

```csharp
var top5 = studenti
    .Where(s => s.Trida == "4A")          // jen ze třídy 4A
    .OrderBy(s => s.Prumer)               // seřaď podle průměru
    .Take(5)                              // vezmi prvních 5
    .Select(s => $"{s.Jmeno}: {s.Prumer}") // formátuj jako string
    .ToList();

foreach (string radek in top5)
    Console.WriteLine(radek);
```

---

## Shrnutí

| Metoda | Co dělá |
|---|---|
| `Where(podmínka)` | Filtruje prvky splňující podmínku |
| `Select(transformace)` | Transformuje každý prvek |
| `OrderBy` / `OrderByDescending` | Řadí vzestupně / sestupně |
| `ThenBy` | Sekundární klíč řazení |
| `FirstOrDefault` | První prvek nebo null |
| `Count` / `Sum` / `Average` | Agregace |
| `Take(n)` / `Skip(n)` | Vezme prvních n / přeskočí n prvků |
| `ToList()` / `ToArray()` | Materializuje výsledek |
