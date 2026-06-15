---
layout: post
title: "Předdefinované metody"
order: 21
---

C# a .NET nabízí ohromné množství hotových metod pro běžné úkoly – matematické výpočty, generování náhodných čísel, práci s datem a časem, konverze. Než cokoliv naprogramuješ sám, **stojí za to zkontrolovat, jestli to už neexistuje**.

> 💡 Tato kapitola je přehled – nejde zapamatovat si vše najednou. Spíš si zapamatuj, **že tyto třídy existují**, a konkrétní metody si dohledávej v dokumentaci ([learn.microsoft.com](https://learn.microsoft.com/dotnet/api/)) nebo přes IntelliSense.

---

## Math

Statická třída pro matematické operace. Všechny metody se volají bez vytváření instance – přímo `Math.NázevMetody()`.

```csharp
Math.Pow(2, 3);        // 8    – mocnina (2³)
Math.Sqrt(16);         // 4    – odmocnina
Math.Abs(-5);          // 5    – absolutní hodnota
Math.Round(3.456, 2);  // 3.46 – zaokrouhlení na 2 desetinná místa
Math.Floor(3.9);       // 3.0  – zaokrouhlení dolů
Math.Ceiling(3.1);     // 4.0  – zaokrouhlení nahoru
Math.Max(5, 9);        // 9    – větší z dvou hodnot
Math.Min(5, 9);        // 5    – menší z dvou hodnot
```

Konstanty:

```csharp
Math.PI;  // 3.14159265358979
Math.E;   // 2.71828182845905
```

> ⚠️ `Math.Round(2.5)` vrací `2`, ne `3` – výchozí pravidlo je zaokrouhlování na sudé číslo ("banker's rounding"). Pro klasické zaokrouhlování použij `Math.Round(2.5, MidpointRounding.AwayFromZero)`.

---

## Random

Generuje pseudonáhodná čísla. Nejprve vytvoříš instanci, pak z ní voláš metody.

```csharp
Random random = new Random();

int dice = random.Next(1, 7);        // celé číslo 1–6 (horní hranice je vyloučena)
int percent = random.Next(101);      // 0–100
double chance = random.NextDouble(); // desetinné číslo 0.0–1.0
```

```csharp
// simulace hodu kostkou
Random dice = new Random();
for (int i = 0; i < 5; i++)
{
    Console.WriteLine(dice.Next(1, 7));
}
```

> ⚠️ Vytvoř `Random` **jednou** a používej opakovaně. Pokud vytvoříš novou instanci v každé iteraci cyklu (`new Random()` uvnitř `for`), různé instance mohou dostat stejné "seed" a generovat stejná čísla.

```csharp
// ❌ riziko stejných čísel
for (int i = 0; i < 5; i++)
{
    Random r = new Random();
    Console.WriteLine(r.Next(1, 100));
}

// ✅ správně
Random r = new Random();
for (int i = 0; i < 5; i++)
{
    Console.WriteLine(r.Next(1, 100));
}
```

---

## Console

Třídu `Console` jsme používali od první kapitoly – zde rychlé shrnutí dalších užitečných metod nad `Write`/`WriteLine`/`ReadLine`.

```csharp
Console.Clear();              // vyčistí obrazovku konzole
Console.ForegroundColor = ConsoleColor.Green; // barva textu
Console.WriteLine("Úspěch!");
Console.ResetColor();         // vrátí výchozí barvu

Console.Title = "Moje aplikace"; // titulek okna konzole
```

---

## Convert

Konverze mezi datovými typy – navazuje na kapitolu o operátorech a vstupu/výstupu.

```csharp
Convert.ToInt32("42");      // 42       (string → int)
Convert.ToDouble("3.14");   // 3.14     (string → double)
Convert.ToString(42);       // "42"     (int → string)
Convert.ToBoolean("true");  // true     (string → bool)
Convert.ToInt32(3.9);       // 4        – zaokrouhluje (na rozdíl od (int) castu)
```

> 💡 Pro bezpečnou konverzi uživatelského vstupu, kde čekáš možnou chybu, použij raději `int.TryParse()` (kapitola 20) – `Convert` při neplatném vstupu vyhodí výjimku.

---

## DateTime

Práce s datem a časem. Namespace `System` (žádný extra `using` potřeba).

### Aktuální datum a čas

```csharp
DateTime now = DateTime.Now;        // aktuální datum a čas
DateTime today = DateTime.Today;    // aktuální datum, čas 00:00:00

Console.WriteLine(now);   // 15.06.2026 14:32:07
Console.WriteLine(today); // 15.06.2026 00:00:00
```

### Vytvoření konkrétního data

```csharp
DateTime birthday = new DateTime(2007, 3, 15); // rok, měsíc, den
```

### Vlastnosti

```csharp
DateTime date = new DateTime(2026, 6, 15);

Console.WriteLine(date.Year);       // 2026
Console.WriteLine(date.Month);      // 6
Console.WriteLine(date.Day);        // 15
Console.WriteLine(date.DayOfWeek);  // Monday
```

### Formátování

```csharp
DateTime now = DateTime.Now;

Console.WriteLine(now.ToString("dd.MM.yyyy"));       // 15.06.2026
Console.WriteLine(now.ToString("dd.MM.yyyy HH:mm")); // 15.06.2026 14:32
Console.WriteLine(now.ToString("dddd"));             // Monday
```

### Výpočty s daty

```csharp
DateTime birthday = new DateTime(2007, 3, 15);
TimeSpan age = DateTime.Now - birthday;

Console.WriteLine($"Žiješ už {age.Days} dní.");

DateTime nextWeek = DateTime.Now.AddDays(7);
DateTime nextMonth = DateTime.Now.AddMonths(1);
```

---

## Předdefinované metody datových typů

Každý datový typ má vlastní sadu metod. Tyto si často nevšimneš, dokud nenapíšeš `proměnná.` a IntelliSense ti nabídne seznam.

### Číselné typy

```csharp
int number = 42;
Console.WriteLine(number.ToString());     // "42"
Console.WriteLine(number.CompareTo(50));  // -1 (number je menší)

double d = 3.14159;
Console.WriteLine(d.ToString("F2"));      // "3.14"
```

### `string`

Probráno detailně v kapitole [Řetězce](./16-retezce.md) – `Length`, `Substring`, `Split`, `Trim`, `ToUpper`/`ToLower`, `Contains`, `IndexOf`, `Replace`...

### `bool`

```csharp
bool flag = true;
Console.WriteLine(flag.ToString()); // "True"
```

---

## Předdefinované metody kolekcí

Také `array`, `List<T>` a `Dictionary<K,V>` mají vlastní metody – probráno detailně v kapitolách 14 a 15. Stručná připomínka:

```csharp
// array
int[] numbers = { 5, 1, 8, 3 };
Array.Sort(numbers);              // seřadí
Array.Reverse(numbers);           // obrátí pořadí
int idx = Array.IndexOf(numbers, 8);

// List<T>
List<string> names = new List<string> { "Kamil", "Jana" };
names.Add("Tomáš");
names.Remove("Jana");
bool has = names.Contains("Kamil");

// Dictionary<K,V>
Dictionary<string, int> ages = new Dictionary<string, int>();
ages["Kamil"] = 17;
bool exists = ages.ContainsKey("Kamil");
```

> 💡 Obecné pravidlo: než si napíšeš vlastní metodu pro řazení, hledání nebo transformaci dat, zkus napsat `proměnná.` a podívat se, co nabízí IntelliSense – pravděpodobnost, že už to existuje, je vysoká.

---

## Shrnutí

| Třída | K čemu slouží | Příklad |
|---|---|---|
| `Math` | Matematické výpočty | `Math.Sqrt(16)`, `Math.Round(x, 2)` |
| `Random` | Náhodná čísla | `random.Next(1, 7)` |
| `Console` | Vstup/výstup, vzhled konzole | `Console.Clear()`, `ForegroundColor` |
| `Convert` | Konverze typů | `Convert.ToInt32("42")` |
| `DateTime` | Datum a čas | `DateTime.Now`, `.ToString("dd.MM.yyyy")` |
| Datové typy | Vlastní metody (`ToString`, `CompareTo`...) | `number.ToString("F2")` |
| Kolekce | `array`, `List`, `Dictionary` metody | `Array.Sort()`, `list.Add()` |