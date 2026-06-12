---
layout: post
title: "Podmínky"
order: 11
---
# Podmínky

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

> ⚠️ Vynechávání závorek je zdroj chyb. Doporučení: **vždy používej `{ }`**, i pro jednořádkové bloky.

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

> 💡 Hlubokému vnořování (`if` uvnitř `if` uvnitř `if`…) se vyhýbej – kód je pak těžko čitelný. Jako orientační pravidlo: více než 2–3 úrovně jsou signál k refaktoringu.

---

## Ternární operátor

Zkrácený zápis podmínky na jeden řádek. Hodí se, když chceš přiřadit hodnotu nebo vrátit výsledek podle podmínky.

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

> ⚠️ Ternární operátor je vhodný pro **jednoduché přiřazení**. Pokud logika složitější, použij `if/else` – čitelnost má přednost.

---

## switch

`switch` porovnává proměnnou s pevnými hodnotami (**cases**). Je přehlednější než dlouhý řetězec `else if`, pokud testuješ jednu proměnnou na konkrétní hodnoty.

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
- Více `case` na stejný blok (jako `"A"` a `"A+"` výše) – zapíšeš je za sebou bez `break` mezi nimi

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

> 💡 Pro jednoduché přiřazení hodnoty preferuj `switch` expression – je kratší a čitelnější. Pro složitější logiku (více příkazů v každé větvi) zůstaň u klasického.

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
