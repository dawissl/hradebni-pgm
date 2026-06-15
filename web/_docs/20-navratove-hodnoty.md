---
layout: post
title: "Parametry a návratové hodnoty"
order: 20
---

# Parametry a návratové hodnoty

V kapitole [Metody](./18-metody.md) jsme používali `return` k vrácení jedné hodnoty a krátce jsme se dotkli `ref`/`out`. Teď se na všechny tři možnosti, jak metoda komunikuje výsledek ven, podíváme detailně – a ukážeme, kdy se která hodí.

---

## `void` vs. metody vracející hodnotu

Každá metoda má návratový typ – buď `void`, nebo konkrétní datový typ.

```csharp
void PrintHeader()              // void – pouze provede akci, nic nevrací
{
    Console.WriteLine("=== Report ===");
}

int CountVowels(string text)    // vrací int – výsledek je k dalšímu použití
{
    int count = 0;
    foreach (char c in text.ToLower())
    {
        if ("aeiouy".Contains(c))
            count++;
    }
    return count;
}
```

```csharp
PrintHeader();                       // volání jako samostatný příkaz
int vowels = CountVowels("Hradec");  // výsledek uložíme do proměnné
Console.WriteLine(vowels);           // a dál s ním pracujeme
```

### Jak se rozhodnout?

| Otázka | Odpověď | Návratový typ |
|---|---|---|
| Potřebuje volající kód výsledek k dalšímu zpracování? | Ano | konkrétní typ (`int`, `string`, `bool`...) |
| Metoda jen provádí akci (výpis, uložení, změna stavu)? | Ano | `void` |
| Metoda *zjišťuje*, *počítá*, *vytváří* něco? | — | konkrétní typ |
| Metoda *vypisuje*, *ukládá*, *nastavuje* něco? | — | obvykle `void` |

> 💡 Jazykový test: pokud název metody začíná na *Get*, *Calculate*, *Is*, *Find*, *Create* – čekáš návratovou hodnotu. *Print*, *Show*, *Save*, *Set* – obvykle `void`.

---

## `return` – návrat z metody

### Jedna hodnota

```csharp
double CalculateArea(double width, double height)
{
    return width * height;
}
```

### `return` okamžitě ukončuje metodu

Jakmile program narazí na `return`, **metoda končí** – další kód v metodě se neprovede.

```csharp
string ClassifyAge(int age)
{
    if (age < 0)
        return "Neplatný věk";

    if (age < 18)
        return "Nezletilý";

    if (age < 65)
        return "Dospělý";

    return "Senior";
}
```

Každá větev má vlastní `return` – kód po prvním splněném `return` se nevykoná.

### `return` ve `void` metodě

I `void` metoda může obsahovat `return` – ale **bez hodnoty**, pouze pro předčasné ukončení:

```csharp
void PrintIfPositive(int number)
{
    if (number <= 0)
    {
        Console.WriteLine("Číslo musí být kladné.");
        return; // konec metody, dál se nepokračuje
    }

    Console.WriteLine($"Číslo je {number}.");
}
```

### Metoda musí vrátit hodnotu na každé cestě

Pokud má metoda návratový typ jiný než `void`, kompilátor vyžaduje, aby **každá možná cesta kódu** skončila `return`em s hodnotou:

```csharp
// ❌ CHYBA – pokud age == 18, metoda nic nevrátí
string Check(int age)
{
    if (age < 18)
        return "Nezletilý";
    else if (age > 18)
        return "Dospělý";
    // chybí else nebo return pro případ age == 18
}
```

```csharp
// ✅ OK – else pokrývá zbylý případ
string Check(int age)
{
    if (age < 18)
        return "Nezletilý";
    else
        return "Dospělý nebo přesně 18";
}
```

---

## Modifikátor `ref`

Ve výchozím nastavení se parametry předávají **hodnotou** – metoda dostane kopii, originál zůstává nezměněný:

```csharp
void Increase(int number)
{
    number++;
}

int value = 10;
Increase(value);
Console.WriteLine(value); // 10 – beze změny
```

Pokud chceš, aby metoda **změnila proměnnou, kterou jí předáš**, použij `ref` – metoda pak pracuje přímo s originálem, ne s kopií.

```csharp
void Increase(ref int number)
{
    number++;
}

int value = 10;
Increase(ref value);
Console.WriteLine(value); // 11 – změna se projevila
```

### Pravidla pro `ref`

- `ref` musí být uveden **jak v definici, tak při volání**
- proměnná musí být **inicializovaná před voláním** (musí mít už nějakou hodnotu)

```csharp
int x;
Increase(ref x); // ❌ CHYBA – x není inicializované

int y = 0;
Increase(ref y); // ✅ OK
```

---

## Modifikátor `out`

`out` slouží k tomu, aby metoda **vrátila víc hodnot najednou** – něco, co `return` neumožňuje (return může vrátit jen jednu hodnotu).

```csharp
void Divide(int a, int b, out int quotient, out int remainder)
{
    quotient = a / b;
    remainder = a % b;
}
```

```csharp
Divide(17, 5, out int quotient, out int remainder);

Console.WriteLine($"Podíl: {quotient}");   // 3
Console.WriteLine($"Zbytek: {remainder}"); // 2
```

### Pravidla pro `out`

- proměnná **nemusí** být před voláním inicializovaná
- metoda **musí** každému `out` parametru přiřadit hodnotu před koncem – jinak nezkompiluje

```csharp
// ❌ CHYBA – remainder nikdy nedostane hodnotu
void Divide(int a, int b, out int quotient, out int remainder)
{
    quotient = a / b;
    // remainder = ...  ← chybí
}
```

### Časté praktické použití – `TryParse`

`out` se hojně používá ve standardní knihovně, typicky u metod `TryXxx`, které vrací `bool` (úspěch/neúspěch) a výsledek předávají přes `out`:

```csharp
Console.Write("Zadej číslo: ");
string input = Console.ReadLine();

if (int.TryParse(input, out int number))
{
    Console.WriteLine($"Zadal jsi číslo: {number}");
}
else
{
    Console.WriteLine("To nebylo platné číslo.");
}
```

> 💡 `TryParse` je bezpečnější než `Convert.ToInt32()` – při neplatném vstupu nevyhodí výjimku, jen vrátí `false`.

---

## `return` vs. `ref` vs. `out`

| Technika | Co řeší | Příklad použití |
|---|---|---|
| `return` | Metoda vrací **jeden** výsledek | `int Add(int a, int b)` |
| `ref` | Metoda **upravuje** existující proměnnou | `Swap(ref a, ref b)` |
| `out` | Metoda vrací **víc hodnot** najednou | `Divide(a, b, out q, out r)` |

### Doporučení

Ve **většině případů použij `return`** – je nejčitelnější a nejméně náchylný na chyby. `ref` a `out` mají svá specifická místa, ale zneužívání vede k nepřehlednému kódu (není na první pohled vidět, že volání metody změní tvé proměnné).

```csharp
// ❌ Zneužití ref tam, kde stačí return
void CalculateSquare(int number, ref int result)
{
    result = number * number;
}

// ✅ Mnohem čitelnější
int CalculateSquare(int number)
{
    return number * number;
}
```

`out` má smysl hlavně u `TryParse`-vzoru a u metod, které **opravdu** přirozeně produkují víc nezávislých výsledků (např. min a max z pole najednou).

---

## Kompletní příklad

Program kombinující všechny tři techniky – validace vstupu (`TryParse`), výpočet s návratovou hodnotou, a výpočet statistik pomocí `out`:

```csharp
using System;

namespace StatsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 12, 45, 7, 23, 56, 3, 89 };

            GetMinMax(numbers, out int min, out int max);
            double average = CalculateAverage(numbers);

            Console.WriteLine($"Minimum: {min}");
            Console.WriteLine($"Maximum: {max}");
            Console.WriteLine($"Průměr: {average:F2}");

            // bezpečné načtení vstupu
            Console.Write("Zadej hledané číslo: ");
            if (int.TryParse(Console.ReadLine(), out int target))
            {
                bool found = Array.IndexOf(numbers, target) >= 0;
                Console.WriteLine(found ? "Nalezeno!" : "Nenalezeno.");
            }
            else
            {
                Console.WriteLine("Neplatný vstup.");
            }
        }

        static double CalculateAverage(int[] numbers)
        {
            int sum = 0;
            foreach (int n in numbers)
                sum += n;

            return (double)sum / numbers.Length;
        }

        static void GetMinMax(int[] numbers, out int min, out int max)
        {
            min = numbers[0];
            max = numbers[0];

            foreach (int n in numbers)
            {
                if (n < min) min = n;
                if (n > max) max = n;
            }
        }
    }
}
```

---

## Shrnutí

```csharp
// void – žádná návratová hodnota
void Print(string text) { Console.WriteLine(text); }

// return – jedna návratová hodnota
int Add(int a, int b) { return a + b; }

// ref – metoda upraví existující proměnnou (musí být inicializovaná)
void Increase(ref int x) { x++; }

// out – metoda "vrátí" víc hodnot (nemusí být inicializované)
void Divide(int a, int b, out int q, out int r)
{
    q = a / b;
    r = a % b;
}
```

| Pojem | Vysvětlení |
|---|---|
| `void` | Metoda nic nevrací |
| `return` | Vrátí jednu hodnotu a ukončí metodu |
| `ref` | Předání odkazem – metoda mění originál (musí být inicializovaný) |
| `out` | Metoda vrací další hodnoty navíc (nemusí být inicializované, ale musí být přiřazeny) |
| `TryParse` | Typický `out` vzor – bezpečná konverze bez výjimky |