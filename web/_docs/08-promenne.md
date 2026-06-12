---
layout: post
title: "Proměnné a datové typy"
order: 8
---

## Co je proměnná?

Proměnná je **pojmenované místo v paměti**, kde program ukládá data, se kterými pracuje.

Představ si ji jako krabičku s popiskem – popisek je název proměnné, obsah krabičky je její hodnota.

```csharp
int userAge = 20;
```

Tento řádek říká: „Vytvoř krabičku pro celé číslo, pojmenuj ji `userAge` a vlož do ní hodnotu `20`."

---

## Datové typy

Každá proměnná musí mít **datový typ** – říká kompilátoru, jaký druh dat bude proměnná uchovávat a kolik paměti pro ni rezervovat.

### Celá čísla

| Typ | Rozsah | Typické použití |
|---|---|---|
| `int` | −2 147 483 648 až 2 147 483 647 | věk, počet, index |
| `byte` | 0 až 255 | omezená celá čísla, úspora paměti |
| `long` | přibližně ±9,2 × 10¹⁸ | velká čísla (např. ID v databázi) |

```csharp
int numberOfStudents = 30;
byte userAge = 20;
```

### Desetinná čísla

| Typ | Přesnost | Přípona | Typické použití |
|---|---|---|---|
| `double` | ~15–16 číslic | _(výchozí)_ | obecná desetinná čísla |
| `float` | ~7 číslic | `f` | grafika, výpočty kde stačí menší přesnost |
| `decimal` | ~28–29 číslic | `m` | finance, kde záleží na každé desetině |

```csharp
double height = 1.75;
float temperature = 36.6f;
decimal price = 299.99m;
```

> ⚠️ Výchozí typ pro desetinná čísla v C# je `double`. Číslo `3.14` je tedy double, nikoli float.

### Ostatní typy

| Typ | Co uchovává | Příklad |
|---|---|---|
| `char` | jeden znak (Unicode) | `'A'`, `'%'`, `'č'` |
| `bool` | pravda nebo nepravda | `true`, `false` |
| `string` | text (posloupnost znaků) | `"Hello"`, `"Kamil"` |

```csharp
char grade = 'A';
bool isLoggedIn = true;
string userName = "Kamil";
```

> 💡 `char` používá **jednoduché** uvozovky, `string` **dvojité**.

---

## Deklarace a inicializace

**Deklarace** – oznámení proměnné (rezervace místa v paměti):

```csharp
int score;
```

**Inicializace** – přiřazení první hodnoty:

```csharp
score = 100;
```

Obojí lze zapsat najednou:

```csharp
int score = 100;
```

Více proměnných stejného typu na jednom řádku:

```csharp
int x = 5, y = 10, z = 15;
```

---

## Pravidla pojmenování

- Název může obsahovat písmena, číslice a podtržítko `_`
- Nesmí začínat číslicí
- Rozlišují se velká a malá písmena (`userName` ≠ `username`)
- Nesmí být **rezervované klíčové slovo** (`if`, `while`, `class`, `int`…)

| ✅ Správně | ❌ Špatně |
|---|---|
| `userAge` | `2userAge` |
| `user_name` | `user name` |
| `totalScore` | `class` |

### Konvence pojmenování

V C# se pro proměnné používá **camelCase** – první slovo malým, každé další velkým písmenem:

```csharp
int userAge = 20;
string firstName = "Kamil";
double accountBalance = 1500.50;
```

---

## Typová konverze (přetypování)

Někdy potřebuješ hodnotu jednoho typu uložit do proměnné jiného typu.

### Implicitní konverze (automatická)

Proběhne sama, pokud nehrozí ztráta dat (z menšího do většího typu):

```csharp
int myInt = 10;
double myDouble = myInt; // int → double, bez ztráty
```

### Explicitní konverze (přetypování)

Nutná, pokud hrozí ztráta dat. Píšeš cílový typ do závorek před hodnotu:

```csharp
double price = 20.9;
int rounded = (int)price; // výsledek: 20 (desetinná část se ořízne, NE zaokrouhlí)
```

> ⚠️ Přetypování `double → int` desetinnou část **ořízne**, nezaokrouhlí. `(int)20.9` je `20`, ne `21`.

```csharp
double d = 20.9;
float f = (float)d;
decimal m = (decimal)d;
```

---

## Konstanta

Pokud se hodnota proměnné **nesmí změnit**, použij klíčové slovo `const`:

```csharp
const double Pi = 3.14159;
const int MaxStudents = 30;
```

Pokus o změnu konstanty skončí chybou při kompilaci.

---

## Shrnutí

| Pojem | Vysvětlení |
|---|---|
| Proměnná | Pojmenované místo v paměti pro uložení dat |
| Datový typ | Určuje, jaká data proměnná uchovává |
| Deklarace | Vytvoření proměnné (`int score;`) |
| Inicializace | Přiřazení první hodnoty (`score = 100;`) |
| camelCase | Konvence pojmenování v C# |
| Přetypování | Převod hodnoty na jiný datový typ |
| `const` | Proměnná, jejíž hodnota se nemůže měnit |
