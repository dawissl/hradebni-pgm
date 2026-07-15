---
layout: post
title: "Rekurze"
order: 220
---

Rekurze je technika, kdy **metoda volá sama sebe**. Zní to paradoxně, ale je to mocný nástroj pro řešení problémů, které lze rozložit na menší instance toho samého problému.

---

## Co je rekurzivní funkce?

```csharp
void CountDown(int n)
{
    Console.WriteLine(n);

    if (n > 0)
        CountDown(n - 1); // metoda volá sama sebe
}
```

```csharp
CountDown(3);
// výstup:
// 3
// 2
// 1
// 0
```

Každé volání `CountDown(n - 1)` vytvoří **nové, samostatné spuštění** metody – se svou vlastní kopií proměnné `n`. Tato volání se "vrší na sebe", dokud nenastane podmínka, která rekurzi zastaví.

---

## Podmínka ukončení (base case)

Bez podmínky ukončení by se metoda volala **donekonečna** – až do vyčerpání paměti (`StackOverflowException`).

```csharp
// ❌ NEKONEČNÁ REKURZE – chybí podmínka ukončení
void CountDown(int n)
{
    Console.WriteLine(n);
    CountDown(n - 1); // bude se volat pořád, n půjde do minus nekonečna
}
```

Každá rekurzivní metoda musí mít:

1. **Base case** (podmínka ukončení) – jednoduchý případ, který se vyřeší bez dalšího rekurzivního volání
2. **Rekurzivní případ** – volání sebe sama s **hodnotou, která se blíží k base case**

```csharp
void CountDown(int n)
{
    if (n <= 0)            // 1. base case – zde rekurze končí
    {
        Console.WriteLine("Konec!");
        return;
    }

    Console.WriteLine(n);
    CountDown(n - 1);      // 2. rekurzivní případ – n se blíží k 0
}
```

> ⚠️ Nejčastější chyba: zapomenutý base case, nebo rekurzivní volání s hodnotou, která se **nepřibližuje** k base case (např. `CountDown(n)` místo `CountDown(n - 1)`).

---

## Faktoriál – klasický příklad

Faktoriál čísla `n` (zapisuje se `n!`) je součin všech čísel od `1` do `n`:

```
5! = 5 × 4 × 3 × 2 × 1 = 120
```

Matematická definice je sama o sobě rekurzivní:

```
n! = n × (n-1)!     pro n > 0
0! = 1              (base case)
```

Přepis do C#:

```csharp
int Factorial(int n)
{
    if (n == 0)             // base case
        return 1;

    return n * Factorial(n - 1); // rekurzivní případ
}
```

```csharp
Console.WriteLine(Factorial(5)); // 120
```

### Jak se to vyhodnocuje?

```
Factorial(5)
= 5 * Factorial(4)
= 5 * (4 * Factorial(3))
= 5 * (4 * (3 * Factorial(2)))
= 5 * (4 * (3 * (2 * Factorial(1))))
= 5 * (4 * (3 * (2 * (1 * Factorial(0)))))
= 5 * (4 * (3 * (2 * (1 * 1))))
= 120
```

Volání se "rozbalují" směrem dolů (až k `Factorial(0)`), a pak se výsledky postupně násobí cestou zpět nahoru.

---

## Fibonacciova posloupnost

Fibonacciova posloupnost: každé číslo je součtem dvou předchozích. Začíná `0, 1, 1, 2, 3, 5, 8, 13, 21...`

```
fib(n) = fib(n-1) + fib(n-2)   pro n > 1
fib(0) = 0                      (base case)
fib(1) = 1                      (base case)
```

```csharp
int Fibonacci(int n)
{
    if (n == 0) return 0;  // base case
    if (n == 1) return 1;  // base case

    return Fibonacci(n - 1) + Fibonacci(n - 2); // rekurzivní případ
}
```

```csharp
for (int i = 0; i < 8; i++)
{
    Console.Write(Fibonacci(i) + " ");
}
// výstup: 0 1 1 2 3 5 8 13
```

> ⚠️ Tady jsou **dvě** rekurzivní volání ve stejné metodě – `fib(n-1)` i `fib(n-2)`. Strom volání roste exponenciálně a `Fibonacci(30)` už trvá zaznamenatelně dlouho. To je dobrá ukázka rizika rekurze (viz dále).

---

## Přímá vs. nepřímá rekurze

### Přímá rekurze

Metoda volá **sama sebe** – jako ve všech předchozích příkladech.

```csharp
int Factorial(int n)
{
    if (n == 0) return 1;
    return n * Factorial(n - 1); // volá sama sebe
}
```

### Nepřímá rekurze

Metoda A volá metodu B, která volá zpět metodu A. Cyklus mezi metodami funguje jako rekurze, i když žádná metoda nevolá přímo sebe.

```csharp
void MethodA(int n)
{
    if (n <= 0) return;
    Console.WriteLine($"A: {n}");
    MethodB(n - 1);
}

void MethodB(int n)
{
    if (n <= 0) return;
    Console.WriteLine($"B: {n}");
    MethodA(n - 1);
}
```

```csharp
MethodA(4);
// A: 4
// B: 3
// A: 2
// B: 1
```

> 💡 Nepřímá rekurze se v praxi vyskytuje méně často, ale je dobré ji rozpoznat – jinak může v kódu vypadat jako "obyčejné" volání metod a skrytou rekurzi si nevšimnete.

---

## Výhody a rizika rekurze

### Výhody

- **Přirozený zápis** pro problémy, které jsou samy o sobě definovány rekurzivně (matematické posloupnosti, procházení stromových struktur, procházení složek v souborovém systému)
- **Kratší a čitelnější kód** než ekvivalentní iterativní řešení – zejména u stromových/vnořených struktur

### Rizika

**1. Chybějící nebo nesprávný base case → StackOverflowException**

```csharp
int BadFactorial(int n)
{
    return n * BadFactorial(n - 1); // nikdy neskončí
}
```

Každé volání metody zabírá místo na **zásobníku (stack)**. Bez base case se zásobník naplní a program spadne s `StackOverflowException`.

**2. Výkon – opakované přepočítávání**

`Fibonacci(n-1)` a `Fibonacci(n-2)` se uvnitř volají znovu a znovu se stejnými hodnotami – `Fibonacci(5)` spočítá `Fibonacci(2)` celkem 3×. U větších `n` to vede k exponenciálnímu nárůstu počtu volání.

**3. Paměťová náročnost**

Hluboká rekurze (tisíce vnořených volání) zabírá výrazně víc paměti než ekvivalentní cyklus, který běží v konstantní paměti.

---

## Rekurze vs. cyklus

Většinu rekurzivních řešení lze přepsat jako cyklus – a naopak.

```csharp
// rekurzivně
int FactorialRecursive(int n)
{
    if (n == 0) return 1;
    return n * FactorialRecursive(n - 1);
}

// iterativně (cyklus)
int FactorialIterative(int n)
{
    int result = 1;
    for (int i = 1; i <= n; i++)
        result *= i;
    return result;
}
```

| | Rekurze | Cyklus |
|---|---|---|
| Čitelnost u stromových struktur | ✅ velmi přirozená | ❌ složitější |
| Čitelnost u jednoduchých posloupností | stejná nebo horší | ✅ obvykle jasnější |
| Paměť | spotřebovává zásobník | konstantní |
| Riziko | `StackOverflowException` | nekonečná smyčka |

> 💡 Pro `Factorial` a podobné jednoduché posloupnosti je v praxi cyklus efektivnější. Rekurze ukáže svou sílu hlavně u **stromových a vnořených struktur** (např. procházení složek a podsložek, nebo struktur typu strom v pokročilejších tématech).

---

## Kompletní příklad

Program, který pomocí rekurze vypíše obsah čísla obráceně (rozloží číslo na číslice):

```csharp
using System;

namespace RecursionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Zadej kladné celé číslo: ");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Faktoriál: {Factorial(number)}");

            Console.Write("Číslice pozpátku: ");
            PrintDigitsReversed(number);
            Console.WriteLine();
        }

        static int Factorial(int n)
        {
            if (n == 0) return 1;
            return n * Factorial(n - 1);
        }

        static void PrintDigitsReversed(int n)
        {
            if (n == 0) return; // base case

            Console.Write(n % 10); // vypíše poslední číslici
            PrintDigitsReversed(n / 10); // pokračuje se zbytkem čísla
        }
    }
}
```

Ukázkový běh:
```
Zadej kladné celé číslo: 12
Faktoriál: 479001600
Číslice pozpátku: 21
```

> ⚠️ Zkuste do programu zadat větší číslo, například 15. Výsledek faktoriálu bude vypadat podivně – typ `int` má omezený rozsah a od jistého `n` už *přeteče* (viz cvičení 1 níže).

---

## Shrnutí

```csharp
// kostra rekurzivní metody
TYP Metoda(parametry)
{
    if (base_case)
        return jednoduchá_hodnota;   // 1. podmínka ukončení

    return Metoda(menší_parametry);  // 2. rekurzivní volání blížící se k base case
}
```

| Pojem | Vysvětlení |
|---|---|
| Rekurze | Metoda volá sama sebe |
| Base case | Podmínka, kdy se rekurze zastaví bez dalšího volání |
| Rekurzivní případ | Volání sebe sama s hodnotou bližší k base case |
| Přímá rekurze | Metoda volá sama sebe |
| Nepřímá rekurze | Metoda A volá B, B volá A |
| `StackOverflowException` | Důsledek chybějícího/nesprávného base case |
---

## Otázky k zamyšlení

1. Každá správná rekurze má dvě části: základní případ a rekurzivní krok. Co se stane, když jedna z nich chybí?
2. Co je `StackOverflowException` a proč ji způsobí právě rekurze bez ukončení?
3. Každou rekurzi lze přepsat na cyklus a naopak. Kdy je rekurzivní zápis přirozenější? Uveďte příklad.

---

## Procvičení

### Řešený příklad

**Zadání:** Napište rekurzivní metodu `Secti(int n)`, která vrátí součet čísel 1 až n. Pak vysvětlete, co přesně se děje na zásobníku při volání `Secti(4)`.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

```csharp
static int Secti(int n)
{
    if (n <= 1)        // základní případ
        return 1;
    return n + Secti(n - 1);   // rekurzivní krok
}
```

Průběh volání `Secti(4)`:

```
Secti(4) = 4 + Secti(3)
                Secti(3) = 3 + Secti(2)
                                Secti(2) = 2 + Secti(1)
                                                Secti(1) = 1   ← základní případ
                                Secti(2) = 2 + 1 = 3
                Secti(3) = 3 + 3 = 6
Secti(4) = 4 + 6 = 10
```

Každé volání "čeká" na zásobníku, dokud se nevrátí to vnořené — nejdřív se zanořujeme až k základnímu případu, pak se výsledky skládají cestou zpět.

</details>

### Samostatná cvičení

1. **Základní** — Napište rekurzivní metodu `Faktorial(int n)`. Vyzkoušejte, pro jak velké n ještě funguje s typem `int` a kdy začne „vracet nesmysly" (přetečení).
2. **Pokročilejší** — Napište rekurzivní metodu, která vypíše číslo v binární soustavě. (Nápověda: binární zápis n = binární zápis n/2 + zbytek n%2.)
3. **Bonus (*)** — Naprogramujte Fibonacciho posloupnost rekurzivně a změřte (`Stopwatch`), jak dlouho trvá `Fib(40)`. Proč je to tak pomalé? Jak by to řešil cyklus?