---
layout: post
title: "Proměnné a datové typy"
order: 8
---

## Co je proměnná?

Proměnná je **pojmenované místo v paměti**, kde program ukládá data, se kterými pracuje.

Představte si ji jako krabičku s popiskem – popisek je název proměnné, obsah krabičky je její hodnota.

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

Někdy potřebujete hodnotu jednoho typu uložit do proměnné jiného typu.

### Implicitní konverze (automatická)

Proběhne sama, pokud nehrozí ztráta dat (z menšího do většího typu):

```csharp
int myInt = 10;
double myDouble = myInt; // int → double, bez ztráty
```

### Explicitní konverze (přetypování)

Nutná, pokud hrozí ztráta dat. Píšete cílový typ do závorek před hodnotu:

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

Pokud se hodnota proměnné **nesmí změnit**, používejte klíčové slovo `const`:

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

---

## Otázky k zamyšlení

1. Proč má C# více celočíselných typů (`byte`, `short`, `int`, `long`), když by "stačil" ten největší?
2. Co se stane, když do proměnné `byte` (max 255) uložíte výsledek `200 + 100`? A proč překladač nevaruje vždy?
3. Kdy použijete `double` a kdy `decimal`? Proč se pro částku nehodí `double`?

---

## Procvičení

### Řešený příklad

**Zadání:** Určete, jaký datový typ je nejvhodnější pro tyto údaje, a zdůvodněte: 
(a) počet žáků ve třídě
(b) výška člověka v metrech
(c) cena zboží v e-shopu
(d) zda je uživatel přihlášen
(e) jedno písmeno klávesnice
(f) rodné číslo.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

- **(a) počet žáků** → `int` — celé číslo, malý rozsah, `byte` by stačil, ale `int` je konvence a bezpečnější při výpočtech.
- **(b) výška v metrech** → `double` — desetinné číslo, nepotřebujeme absolutní přesnost.
- **(c) cena zboží** → `decimal` — u peněz vadí zaokrouhlovací chyby binárního `double` (0.1 + 0.2 ≠ 0.3), `decimal` počítá desítkově přesně.
- **(d) přihlášen** → `bool` — dvě hodnoty, `true`/`false`.
- **(e) jedno písmeno** → `char`.
- **(f) rodné číslo** → `string`! Přestože vypadá jako číslo, nepočítáme s ním, může začínat nulou a obsahuje lomítko. Pravidlo: *co není určeno k počítání, není číslo.*

</details>

### Samostatná cvičení

1. **Základní** — Deklarujte proměnné pro: své jméno, věk, výšku, znaménko tvého jména a informaci, zda splňujete podmínku plnoletosti. Všechny vypište v jedné větě pomocí interpolace (`$"..."`).
2. **Pokročilejší** — Vyzkoušejte, co vypíše `Console.WriteLine(0.1 + 0.2 == 0.3);` a vysvětlete výsledek. Pak totéž s typem `decimal` (`0.1m + 0.2m == 0.3m`).
3. **Bonus (*)** — Napište program, který demonstruje přetečení (overflow) typu `int`. Zjistěte, co dělá klíčové slovo `checked`.
