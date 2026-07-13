---
layout: post
title: "Podmínky"
order: 11
---

Podmínky umožňují programu **rozhodovat** – provést různý kód podle toho, zda platí nebo neplatí nějaká podmínka. Jsou základem jakékoli logiky v programu.

---

## if / else if / else

Nejzákladnější nástroj pro větvení programu.

### Základní `if`

```csharp
int age = 20;

if (age >= 18)
{
    Console.WriteLine("Jsi plnoletý.");
}
```

Pokud podmínka platí (`true`), blok kódu v `{ }` se provede. Jinak se přeskočí.

### `if` + `else`

```csharp
if (age >= 18)
{
    Console.WriteLine("Jsi plnoletý.");
}
else
{
    Console.WriteLine("Jsi nezletilý.");
}
```

### `if` + `else if` + `else`

Testuje více podmínek postupně – vykoná se **první větev, jejíž podmínka platí**. Ostatní se přeskočí.

```csharp
int age = Convert.ToInt32(Console.ReadLine());

if (age < 0 || age > 120)
{
    Console.WriteLine("Neplatný věk.");
}
else if (age < 18)
{
    Console.WriteLine("Nezletilý.");
}
else if (age < 65)
{
    Console.WriteLine("Dospělý.");
}
else
{
    Console.WriteLine("Senior.");
}
```

> 💡 `else` na konci je volitelné. Pokud žádná podmínka neplatí a `else` chybí, program pokračuje dál bez výpisu.

### Složené závorky u jednořádkových bloků

Pokud větev obsahuje **jediný příkaz**, závorky jsou technicky nepovinné:

```csharp
if (age < 18)
    Console.WriteLine("Nezletilý."); // funguje, ale...
```

> ⚠️ Vynechávání závorek je zdroj chyb. Doporučení: **používejte `{ }`**, i pro jednořádkové bloky.

---

## Vnořené podmínky

Podmínku lze umístit dovnitř jiné podmínky. Říkáme tomu **vnořená podmínka** (nested if).

```csharp
bool hasTicket = true;
int age = 20;

if (age >= 18)
{
    if (hasTicket)
    {
        Console.WriteLine("Vstup povolen.");
    }
    else
    {
        Console.WriteLine("Nemáš lístek.");
    }
}
else
{
    Console.WriteLine("Vstup nepovolen – nezletilý.");
}
```

Stejný výsledek lze zapsat přehledněji pomocí logického operátoru `&&`:

```csharp
if (age >= 18 && hasTicket)
{
    Console.WriteLine("Vstup povolen.");
}
```

> 💡 Hlubokému vnořování (`if` uvnitř `if` uvnitř `if`…) se vyhýbejte – kód je pak těžko čitelný. Jako orientační pravidlo: více než 2–3 úrovně jsou signál k refaktoringu.

---

## Ternární operátor

Zkrácený zápis podmínky na jeden řádek. Hodí se, když chcete přiřadit hodnotu nebo vrátit výsledek podle podmínky.

```
podmínka ? hodnota_když_true : hodnota_když_false
```

```csharp
int age = 20;
string status = age >= 18 ? "plnoletý" : "nezletilý";
Console.WriteLine(status); // plnoletý
```

Nebo přímo uvnitř `WriteLine`:

```csharp
Console.WriteLine(score >= 50 ? "Prospěl" : "Neprospěl");
```

> ⚠️ Ternární operátor je vhodný pro **jednoduché přiřazení**. Pokud logika složitější, použijte `if/else` – čitelnost má přednost.

---

## switch

`switch` porovnává proměnnou s pevnými hodnotami (**cases**). Je přehlednější než dlouhý řetězec `else if`, pokud testujete jednu proměnnou na konkrétní hodnoty.

### Klasický `switch`

```csharp
Console.Write("Zadej známku: ");
string grade = Console.ReadLine();

switch (grade)
{
    case "A":
    case "A+":
        Console.WriteLine("Výborně");
        break;
    case "B":
        Console.WriteLine("Chvalitebně");
        break;
    case "C":
        Console.WriteLine("Dobře");
        break;
    default:
        Console.WriteLine("Neplatná známka");
        break;
}
```

Klíčová pravidla:

- Každý `case` musí končit `break` (nebo `return`, `throw`)
- `default` je volitelný – provede se, pokud žádný `case` nevyhovuje
- Více `case` na stejný blok (jako `"A"` a `"A+"` výše) – zapíšete je za sebou bez `break` mezi nimi

### switch expression (moderní zápis, C# 8+)

Přehlednější alternativa – místo příkazů vrací **hodnotu**:

```csharp
string grade = "B";

string result = grade switch
{
    "A" or "A+" => "Výborně",
    "B"         => "Chvalitebně",
    "C"         => "Dobře",
    _           => "Neplatná známka"  // _ je výchozí případ (jako default)
};

Console.WriteLine(result);
```

Rozdíly oproti klasickému `switch`:

| Klasický `switch` | `switch` expression |
|---|---|
| Příkaz (statement) | Výraz – vrací hodnotu |
| `case X:` + `break;` | `X =>` |
| `default:` | `_` (discard pattern) |
| Více řádků logiky v bloku | Jednořádkové větve |

> 💡 Pro jednoduché přiřazení hodnoty preferujte `switch` expression – je kratší a čitelnější. Pro složitější logiku (více příkazů v každé větvi) zůstaňte u klasického.

---

## Kdy použít co?

| Situace | Doporučení |
|---|---|
| Jedna nebo dvě podmínky | `if / else` |
| Více podmínek s rozsahy (`< 18`, `>= 65`) | `if / else if / else` |
| Porovnání s pevnými hodnotami | `switch` |
| Přiřazení hodnoty podle podmínky | ternární operátor nebo `switch` expression |

---

## Shrnutí

```csharp
// if / else if / else
if (x > 0)      { ... }
else if (x < 0) { ... }
else            { ... }

// ternární operátor
string s = x > 0 ? "kladné" : "záporné";

// klasický switch
switch (x) { case 1: ...; break; default: ...; break; }

// switch expression
string s = x switch { 1 => "jedna", 2 => "dva", _ => "jiné" };
```

---

## Otázky k zamyšlení

1. Jaký je rozdíl mezi řetězcem `if – else if – else` a několika samostatnými `if` za sebou? Kdy dají různý výsledek?
2. Kdy je vhodnější `switch` než `if`? A kdy `switch` použít nejde?
3. Co znamená "líné vyhodnocování" (short-circuit) u `&&` a `||`? Proč je užitečné v podmínce `if (pole != null && pole.Length > 0)`?

---

## Procvičení

### Řešený příklad

**Zadání:** Napište program, který načte bodový zisk z testu (0–100) a vypíše známku podle stupnice: 90+ → 1, 75+ → 2, 60+ → 3, 45+ → 4, jinak 5. Vstup mimo rozsah 0–100 odmítni.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

Klíčové je pořadí podmínek — od nejvyšší hranice dolů, díky `else if` se vyhodnotí jen první splněná:

```csharp
Console.Write("Zadej počet bodů (0-100): ");
int body = Convert.ToInt32(Console.ReadLine());

if (body < 0 || body > 100)
{
    Console.WriteLine("Body musí být v rozsahu 0-100.");
}
else if (body >= 90) Console.WriteLine("Známka: 1");
else if (body >= 75) Console.WriteLine("Známka: 2");
else if (body >= 60) Console.WriteLine("Známka: 3");
else if (body >= 45) Console.WriteLine("Známka: 4");
else Console.WriteLine("Známka: 5");
```

Kdybychom použili samostatné `if` bez `else`, vstup 95 by vypsal známky 1, 2, 3 i 4 — všechny podmínky by byly pravdivé.

</details>

### Samostatná cvičení

1. **Základní** — Načtěte tři čísla a vypište největší z nich. Vyřešte jen pomocí `if`/`else`, bez `Math.Max()`.
2. **Pokročilejší** — Napište program "kalkulačka": načtěte dvě čísla a operátor (+, -, *, /) a proveďte odpovídající operaci. Použijte `switch`. Ošetřete dělení nulou a neznámý operátor.
3. **Bonus (*)** — Načtěte rok a rozhodněte, zda je přestupný (dělitelný 4, ale ne 100, ledaže 400). Napište dvě verze: s vnořenými `if` a s jedinou složenou podmínkou. Která je čitelnější?
