---
layout: post
title: "Cykly"
order: 12
---

Cyklus umožňuje **opakovat blok kódu** – buď pevně daný počet opakování, nebo dokud platí nějaká podmínka. Bez cyklů by opakování muselo být psáno ručně řádek po řádku.

---

## for

Ideální, když **předem víš, kolikrát** se má kód opakovat.

```
for (inicializace; podmínka; krok)
{
    // tělo cyklu
}
```

```csharp
for (int i = 0; i < 5; i++)
{
    Console.WriteLine(i);
}
// výstup: 0 1 2 3 4
```

Tři části hlavičky cyklu:

| Část | Co dělá | V příkladu |
|---|---|---|
| Inicializace | Deklaruje a nastaví čítač | `int i = 0` |
| Podmínka | Cyklus běží, dokud je `true` | `i < 5` |
| Krok | Provede se po každém průchodu | `i++` |

Krok nemusí být vždy `i++` – lze použít libovolný výraz:

```csharp
for (int i = 10; i >= 0; i -= 2)   // sestupně po 2: 10, 8, 6, 4, 2, 0
    Console.Write(i + " ");
```

### Procházení pole pomocí `for`

```csharp
int[] scores = { 85, 92, 78, 90, 88 };

for (int i = 0; i < scores.Length; i++)
{
    Console.WriteLine($"Student {i + 1}: {scores[i]} bodů");
}
```

---

## foreach

Určen pro **procházení kolekcí** (pole, listy…). Jednodušší zápis než `for` – nepotřebuješ index.

```
foreach (typ proměnná in kolekce)
{
    // tělo cyklu
}
```

```csharp
string[] names = { "Kamil", "Jana", "Tomáš" };

foreach (string name in names)
{
    Console.WriteLine($"Ahoj, {name}!");
}
```

> ⚠️ `foreach` je **pouze pro čtení** – hodnotu prvku uvnitř cyklu nelze změnit. Pokud potřebuješ prvky pole modifikovat, použij `for` s indexem.

---

## while

Opakuje, dokud platí podmínka. Podmínka se vyhodnocuje **před každým průchodem** – pokud není splněna hned na začátku, tělo se neprovede ani jednou.

```
while (podmínka)
{
    // tělo cyklu
}
```

```csharp
int counter = 5;

while (counter > 0)
{
    Console.WriteLine($"Counter = {counter}");
    counter--;
}
// výstup: 5 4 3 2 1
```

> ⚠️ Nezapomeň na krok uvnitř těla (`counter--`). Bez něj podmínka nikdy nepřestane platit a vznikne **nekonečná smyčka**.

Typické použití – čekání na správný vstup:

```csharp
Console.Write("Zadej kladné číslo: ");
int number = Convert.ToInt32(Console.ReadLine());

while (number <= 0)
{
    Console.Write("Číslo musí být kladné, zkus znovu: ");
    number = Convert.ToInt32(Console.ReadLine());
}

Console.WriteLine($"Zadal jsi: {number}");
```

---

## do-while

Stejné jako `while`, ale podmínka se vyhodnocuje **až po prvním průchodu** – tělo se provede **vždy alespoň jednou**.

```
do
{
    // tělo cyklu
} while (podmínka);
```

```csharp
int counter = 100;

do
{
    Console.WriteLine($"Counter = {counter}");
    counter++;
} while (counter < 0);

// výstup: Counter = 100
// (podmínka nesplněna, ale tělo proběhlo jednou)
```

Praktické použití – menu, které se zobrazí vždy aspoň jednou:

```csharp
string choice;

do
{
    Console.WriteLine("1 - Nová hra");
    Console.WriteLine("2 - Nastavení");
    Console.WriteLine("0 - Konec");
    Console.Write("Volba: ");
    choice = Console.ReadLine();
} while (choice != "0");
```

> 💡 Nezapomeň na středník `;` za `while (podmínka);` – jinak kód nepůjde zkompilovat.

---

## break a continue

Oba příkazy mění průběh cyklu, ale každý jinak.

### `break` – okamžité ukončení cyklu

Jakmile program narazí na `break`, **cyklus se celý ukončí** a pokračuje kód za ním.

```csharp
for (int i = 0; i < 10; i++)
{
    if (i == 3)
        break;

    Console.WriteLine(i);
}
// výstup: 0 1 2
```

Typické použití – hledání prvku v poli:

```csharp
int[] numbers = { 5, 12, 7, 23, 4 };
int target = 7;

for (int i = 0; i < numbers.Length; i++)
{
    if (numbers[i] == target)
    {
        Console.WriteLine($"Nalezeno na indexu {i}");
        break; // nemá smysl hledat dál
    }
}
```

### `continue` – přeskočení zbytku aktuálního průchodu

Kód za `continue` se v daném průchodu **přeskočí**, cyklus ale pokračuje dalším průchodem.

```csharp
for (int i = 0; i < 5; i++)
{
    if (i == 2)
        continue;

    Console.WriteLine(i);
}
// výstup: 0 1 3 4
```

Typické použití – přeskakování nežádoucích hodnot:

```csharp
int[] scores = { 85, -1, 92, -1, 78 };

foreach (int score in scores)
{
    if (score < 0)
        continue; // přeskočíme neplatné záznamy

    Console.WriteLine($"Skóre: {score}");
}
```

---

## Vnořené cykly

Cyklus uvnitř jiného cyklu. Vnitřní cyklus **proběhne celý** pro každý průchod vnějšího.

```csharp
for (int row = 1; row <= 3; row++)
{
    for (int col = 1; col <= 4; col++)
    {
        Console.Write($"[{row},{col}] ");
    }
    Console.WriteLine(); // nový řádek po každém řádku tabulky
}
```

Výstup:
```
[1,1] [1,2] [1,3] [1,4]
[2,1] [2,2] [2,3] [2,4]
[3,1] [3,2] [3,3] [3,4]
```

> ⚠️ `break` uvnitř vnořeného cyklu ukončí **jen vnitřní** cyklus, ne vnější. Pokud potřebuješ ukončit oba, je potřeba další logika (příznaková proměnná nebo refaktoring do metody).

```csharp
bool found = false;

for (int i = 0; i < 3 && !found; i++)
{
    for (int j = 0; j < 3; j++)
    {
        if (i == 1 && j == 1)
        {
            Console.WriteLine($"Nalezeno na [{i},{j}]");
            found = true;
            break;
        }
    }
}
```

> 💡 Hluboké vnořování (3+ úrovně) výrazně snižuje čitelnost. Pokud se k němu dostaneš, zamysli se nad přesunem vnitřní logiky do samostatné metody.

---

## Kdy použít který cyklus?

| Situace | Vhodný cyklus |
|---|---|
| Znám přesný počet opakování | `for` |
| Procházím pole nebo seznam (jen čtu) | `foreach` |
| Opakuji, dokud platí podmínka – nevím kolikrát | `while` |
| Tělo musí proběhnout alespoň jednou (menu, validace vstupu) | `do-while` |

---

## Shrnutí

```csharp
// for – pevný počet
for (int i = 0; i < n; i++) { ... }

// foreach – procházení kolekce
foreach (var item in collection) { ... }

// while – podmínka na začátku
while (podmínka) { ... }

// do-while – podmínka na konci (aspoň 1 průchod)
do { ... } while (podmínka);

// break  – ukončí cyklus
// continue – přeskočí zbytek průchodu
```
