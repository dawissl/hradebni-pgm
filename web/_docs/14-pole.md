---
layout: post
title: "Pole"
order: 14
---

Pole (`array`) je datová struktura, která uchovává **pevný počet prvků stejného datového typu** pod jedním názvem. Prvky jsou uloženy v paměti za sebou a přístup k nim probíhá přes **index** – celé číslo udávající pozici.

---

## Jednorozměrné pole

### Deklarace a inicializace

**Inicializace při deklaraci** – hodnoty jsou známé dopředu:

```csharp
int[] scores = { 85, 92, 78, 90, 88 };
string[] names = { "Kamil", "Jana", "Tomáš" };
```

**Deklarace s velikostí** – prvky dostávají výchozí hodnotu (`0` pro čísla, `null` pro objekty):

```csharp
int[] scores = new int[5];    // { 0, 0, 0, 0, 0 }
string[] names = new string[3]; // { null, null, null }
```

**Deklarace odděleně od inicializace:**

```csharp
int[] scores;             // deklarace
scores = new int[5];      // vytvoření pole
scores = new[] { 85, 92, 78, 90, 88 }; // inicializace hodnotami
```

> 💡 Velikost pole se po vytvoření **nedá změnit**. Pokud potřebuješ dynamicky přidávat prvky, použij `List<T>` (kapitola 15).

---

### Přístup přes index

Index začíná **vždy od nuly**. Pole o pěti prvcích má indexy 0–4.

```csharp
int[] scores = { 85, 92, 78, 90, 88 };

Console.WriteLine(scores[0]); // 85 – první prvek
Console.WriteLine(scores[4]); // 88 – poslední prvek

scores[2] = 100;              // změna třetího prvku
Console.WriteLine(scores[2]); // 100
```

> ⚠️ Přístup na neexistující index (např. `scores[5]` u pole délky 5) způsobí výjimku `IndexOutOfRangeException` za běhu programu.

Poslední index bezpečně získáš přes `Length - 1`:

```csharp
Console.WriteLine(scores[scores.Length - 1]); // vždy poslední prvek
```

---

### Procházení pole cyklem

**Pomocí `for`** – máš přístup k indexu:

```csharp
int[] scores = { 85, 92, 78, 90, 88 };

for (int i = 0; i < scores.Length; i++)
{
    Console.WriteLine($"Student {i + 1}: {scores[i]} bodů");
}
```

**Pomocí `foreach`** – čistší zápis, pokud index nepotřebuješ:

```csharp
foreach (int score in scores)
{
    Console.WriteLine(score);
}
```

> 💡 `foreach` neumožňuje prvky pole měnit. Potřebuješ-li modifikovat hodnoty při průchodu, použij `for` s indexem.

---

### Vlastnosti a metody pole

Pole v C# nejsou jen „krabice s daty" – mají vlastnosti a metody ze třídy `Array`.

**`Length`** – počet prvků:

```csharp
int[] scores = { 85, 92, 78 };
Console.WriteLine(scores.Length); // 3
```

**`Array.Sort()`** – seřadí pole vzestupně (in-place, původní pole se změní):

```csharp
int[] numbers = { 12, 1, 5, -2, 16, 14 };
Array.Sort(numbers);
// numbers = { -2, 1, 5, 12, 14, 16 }
```

**`Array.Reverse()`** – obrátí pořadí prvků:

```csharp
Array.Reverse(numbers);
// numbers = { 16, 14, 12, 5, 1, -2 }
```

**`Array.IndexOf()`** – vrátí index první výskytu hodnoty, nebo `-1` pokud neexistuje:

```csharp
int[] numbers = { 10, 30, 44, 21, 51 };
int idx = Array.IndexOf(numbers, 21); // 3
int missing = Array.IndexOf(numbers, 99); // -1
```

**`Array.Copy()`** – zkopíruje část pole do jiného:

```csharp
int[] source = { 12, 1, 5, -2, 16 };
int[] dest   = { 0, 0, 0, 0 };

Array.Copy(source, dest, 3); // zkopíruje první 3 prvky
// dest = { 12, 1, 5, 0 }
```

---

## Vícerozměrná pole

C# podporuje dva odlišné typy vícerozměrných polí: **pravoúhlé** a **zubaté**.

---

### Pravoúhlé pole (rectangular array)

Všechny řádky mají **stejný počet sloupců** – tvoří pravidelnou mřížku. Deklaruje se pomocí čárky uvnitř hranatých závorek.

```csharp
// 3 řádky, 4 sloupce
int[,] matrix = new int[3, 4];

// inicializace s hodnotami
int[,] grid = {
    { 1, 2, 3, 4 },
    { 5, 6, 7, 8 },
    { 9, 10, 11, 12 }
};
```

**Přístup přes dvojici indexů** `[řádek, sloupec]`:

```csharp
Console.WriteLine(grid[0, 0]); // 1  – první řádek, první sloupec
Console.WriteLine(grid[1, 2]); // 7  – druhý řádek, třetí sloupec
Console.WriteLine(grid[2, 3]); // 12 – třetí řádek, čtvrtý sloupec

grid[0, 1] = 99; // změna hodnoty
```

**Počet řádků a sloupců:**

```csharp
int rows = grid.GetLength(0); // 3
int cols = grid.GetLength(1); // 4
```

**Procházení pravoúhlého pole vnořeným cyklem:**

```csharp
for (int row = 0; row < grid.GetLength(0); row++)
{
    for (int col = 0; col < grid.GetLength(1); col++)
    {
        Console.Write($"{grid[row, col],4}"); // zarovnání na 4 znaky
    }
    Console.WriteLine();
}
```

Výstup:
```
   1   2   3   4
   5   6   7   8
   9  10  11  12
```

---

### Zubaté pole (jagged array)

Pole polí – každý řádek může mít **jiný počet prvků**. Deklaruje se jako pole, jehož prvky jsou samy pole.

```csharp
// deklarace: pole tří polí (počty sloupců zatím neznáme)
int[][] jagged = new int[3][];

// každý řádek inicializujeme zvlášť – různé délky
jagged[0] = new int[] { 1, 2, 3 };
jagged[1] = new int[] { 4, 5 };
jagged[2] = new int[] { 6, 7, 8, 9 };
```

Nebo zkráceně při inicializaci:

```csharp
int[][] jagged = {
    new int[] { 1, 2, 3 },
    new int[] { 4, 5 },
    new int[] { 6, 7, 8, 9 }
};
```

**Přístup** – první index vybere řádek, druhý prvek v tom řádku:

```csharp
Console.WriteLine(jagged[0][2]); // 3
Console.WriteLine(jagged[2][3]); // 9
```

**Procházení zubatého pole:**

```csharp
for (int row = 0; row < jagged.Length; row++)
{
    for (int col = 0; col < jagged[row].Length; col++)
    {
        Console.Write($"{jagged[row][col]} ");
    }
    Console.WriteLine();
}
```

Výstup:
```
1 2 3
4 5
6 7 8 9
```

---

### Pravoúhlé vs. zubaté – kdy co použít?

| | Pravoúhlé `[,]` | Zubaté `[][]` |
|---|---|---|
| Počet sloupců | Stejný v každém řádku | Může se lišit |
| Syntaxe přístupu | `arr[i, j]` | `arr[i][j]` |
| Typické použití | Matice, herní mřížka, tabulka | Trojúhelníkové tabulky, rozvrhy s různým počtem hodin |
| Paměť | Jeden souvislý blok | Více bloků (jeden na řádek) |

---

## Kompletní příklad

Program načte známky tří studentů, uloží je do pole a vypočítá průměr:

```csharp
int[] scores = new int[3];

for (int i = 0; i < scores.Length; i++)
{
    Console.Write($"Zadej skóre studenta {i + 1}: ");
    scores[i] = Convert.ToInt32(Console.ReadLine());
}

int sum = 0;
foreach (int score in scores)
    sum += score;

double average = (double)sum / scores.Length;
Console.WriteLine($"Průměr: {average:F1}");
```

---

## Shrnutí

| Pojem | Příklad |
|---|---|
| Deklarace s hodnotami | `int[] arr = { 1, 2, 3 };` |
| Deklarace s velikostí | `int[] arr = new int[5];` |
| Přístup přes index | `arr[0]`, `arr[arr.Length - 1]` |
| Délka pole | `arr.Length` |
| Řazení | `Array.Sort(arr)` |
| Hledání | `Array.IndexOf(arr, hodnota)` |
| Pravoúhlé 2D pole | `int[,] m = new int[3, 4];` → `m[i, j]` |
| Zubaté pole | `int[][] j = new int[3][];` → `j[i][k]` |
