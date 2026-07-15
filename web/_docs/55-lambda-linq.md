---
layout: post
title: "Lambda funkce a LINQ"
order: 55
---

Lambda výrazy a LINQ jsou dvě úzce propojené funkce C#, které zásadně zpřehledňují práci s kolekcemi. Místo explicitních cyklů s podmínkami napíšete záměr přímo — „vyber studenty s průměrem pod 2, seřaď je podle příjmení."

---

## Lambda výrazy

Lambda výraz je anonymní funkce — funkce bez jména, zapsaná přímo na místě, kde ji potřebujete.

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

### GroupBy — seskupení

Rozdělí kolekci do skupin podle klíče. Výsledkem je kolekce skupin — každá má vlastnost `Key` (hodnota klíče) a chová se jako `IEnumerable` prvků, které do ní patří.

```csharp
var poRocnicich = studenti.GroupBy(s => s.Rocnik);

foreach (var skupina in poRocnicich)
{
    Console.WriteLine($"{skupina.Key}. ročník: {skupina.Count()} studentů");
    foreach (var s in skupina)
        Console.WriteLine($"  - {s.Jmeno}");
}
```

`skupina.Key` je hodnota, podle které se seskupilo (tady ročník); uvnitř `skupina` lze iterovat, počítat (`Count()`) i dál filtrovat, stejně jako u jakékoli jiné kolekce.

### FirstOrDefault / SingleOrDefault

```csharp
// Vrátí první shodu nebo null
Student nejlepsi = studenti.FirstOrDefault(s => s.Prumer == 1.0);

// Vrátí null pro prázdný seznam (ne výjimku)
Student prvni = studenti.FirstOrDefault();

// SingleOrDefault: vrátí null, pokud nic nenajde — ale VYHODÍ VÝJIMKU,
// pokud najde víc než jednu shodu.
Student podleId = studenti.SingleOrDefault(s => s.Id == 42);
```

`FirstOrDefault` vezme první shodu a na ostatní se nedívá — hodí se, když víc shod nevadí. `SingleOrDefault` naopak trvá na tom, že shoda smí být nejvýš jedna — vhodné třeba u hledání podle unikátního ID, kde víc shod znamená chybu v datech, ne platný výsledek.

### Any / All — existuje aspoň jeden / platí pro všechny

```csharp
bool nekdoNeprospel = studenti.Any(s => s.Prumer > 4.0);   // aspoň jeden?
bool vsichniProspeli = studenti.All(s => s.Prumer <= 4.0); // úplně všichni?

if (studenti.Any())   // bez podmínky = "je kolekce neprázdná?"
    Console.WriteLine("Ve třídě je aspoň jeden student.");
```

`Any(podmínka)` prohledávání zastaví hned u první shody — pro otázku "existuje...?" je tak efektivnější než `Where(...).Count() > 0`, které by procházelo úplně celou kolekci.

### Count, Sum, Min, Max, Average

```csharp
int pocet = studenti.Count(s => s.Prumer < 2.0);
double prumer = studenti.Average(s => s.Prumer);
double nejlepsi = studenti.Min(s => s.Prumer);
```

### ToList / ToArray

LINQ dotazy jsou **líné** (lazy) — nevyhodnocují se, dokud nepotřebujete výsledek. `ToList()` nebo `ToArray()` vynutí okamžité vyhodnocení a materializují výsledek.

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
| `GroupBy(klíč)` | Rozdělí kolekci do skupin podle klíče |
| `FirstOrDefault` | První prvek nebo null |
| `SingleOrDefault` | Jediný prvek nebo null; vyhodí výjimku při víc shodách |
| `Any` / `All` | Existuje aspoň jeden / platí pro všechny |
| `Count` / `Sum` / `Average` | Agregace |
| `Take(n)` / `Skip(n)` | Vezme prvních n / přeskočí n prvků |
| `ToList()` / `ToArray()` | Materializuje výsledek |

---

## Otázky k zamyšlení

1. Co je lambda výraz `x => x * 2` zač? Čím se liší od běžné metody a kde všude ho lze předat?
2. Přečtěte "lidsky" dotaz: `studenti.Where(s => s.Prumer <= 1.5).OrderBy(s => s.Prijmeni).Select(s => s.Jmeno)`. Jak by vypadal stejný kód bez LINQ?
3. LINQ dotazy jsou "líné" (deferred execution). Co to znamená a kdy se dotaz doopravdy vykoná?

---

## Procvičení

### Řešený příklad

**Zadání:** Máš `List<Student>` (Jmeno, Rocnik, Prumer). Pomocí LINQ: (a) vyber studenty 3. ročníku s průměrem do 2.0, seřazené podle průměru, (b) spočítej průměrný průměr celé školy, (c) zjisti počet studentů v každém ročníku.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

```csharp
var studenti = new List<Student>
{
    new Student("Adam", 3, 1.4),  new Student("Bára", 3, 2.3),
    new Student("Cyril", 1, 1.9), new Student("Dana", 3, 1.8),
    new Student("Emil", 2, 2.5),  new Student("Filip", 1, 1.2)
};

// (a) filtr + řazení
var vybrani = studenti
    .Where(s => s.Rocnik == 3 && s.Prumer <= 2.0)
    .OrderBy(s => s.Prumer);

foreach (var s in vybrani)
    Console.WriteLine($"{s.Jmeno}: {s.Prumer}");   // Adam 1.4, Dana 1.8

// (b) agregace
double prumerSkoly = studenti.Average(s => s.Prumer);
Console.WriteLine($"Průměr školy: {prumerSkoly:F2}");

// (c) seskupení
var poRocnicich = studenti.GroupBy(s => s.Rocnik);
foreach (var skupina in poRocnicich)
    Console.WriteLine($"{skupina.Key}. ročník: {skupina.Count()} studentů");
```

Všimněte si čitelnosti: `Where` = filtr, `OrderBy` = řazení, `Average`/`Count` = agregace, `GroupBy` = seskupení. Každý z těchto řádků by "ručně" znamenal cyklus s podmínkou a pomocnými proměnnými — LINQ říká *co* chcete, ne *jak* to spočítat.

</details>

### Samostatná cvičení

1. **Základní** — Nad polem čísel 1–100 pomocí LINQ: vyberte sudá, umocněte je na druhou (`Select`) a sečtěte (`Sum`). Vše v jednom řetězeném výrazu.
2. **Pokročilejší** — Načtěte textový soubor (`File.ReadAllLines`) a pomocí LINQ najděte 5 nejdelších řádků a vypište je s délkou.
3. **Bonus (*)** — Vyřešte úlohu "četnost slov" z kapitoly **List a Dictionary** znovu — tentokrát celou přes LINQ (`GroupBy` + `OrderByDescending`). Porovnejte délku a čitelnost obou řešení.