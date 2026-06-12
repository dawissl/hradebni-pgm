---
layout: post
title: "Vstup a výstup"
order: 10
---

Program komunikuje s uživatelem přes **konzoli** – textové okno, do kterého vypisuje zprávy a čte uživatelský vstup. K tomu slouží třída `Console` z namespace `System`.

---

## Výstup – zobrazení textu

### `Console.WriteLine()` a `Console.Write()`

| Metoda | Chování |
|---|---|
| `Console.WriteLine("text")` | Vypíše text a přejde na **nový řádek** |
| `Console.Write("text")` | Vypíše text **bez** přechodu na nový řádek |

```csharp
Console.WriteLine("Hello");
Console.WriteLine("World");
// výstup:
// Hello
// World

Console.Write("Hello ");
Console.Write("World");
// výstup:
// Hello World
```

### Výpis hodnoty proměnné

Proměnnou předáš přímo jako argument – **bez uvozovek**:

```csharp
int userAge = 20;
Console.WriteLine(userAge);        // vypíše: 20
Console.WriteLine("userAge");      // vypíše: userAge  ← pozor, toto je string!
```

### Spojování textu a proměnných (konkatenace)

```csharp
string name = "Kamil";
int age = 17;
Console.WriteLine("Jmenuji se " + name + " a je mi " + age + " let.");
```

### Interpolace řetězců (moderní zápis)

Před uvozovky přidáš `$` a proměnné zapíšeš přímo do `{ }`:

```csharp
string name = "Kamil";
int age = 17;
Console.WriteLine($"Jmenuji se {name} a je mi {age} let.");
```

> 💡 Interpolace `$"..."` je přehlednější než spojování pomocí `+`. Používej ji jako výchozí volbu.

### Zástupné symboly (starší styl)

Alternativní způsob – čísla v závorkách odpovídají argumentům:

```csharp
int score = 79;
Console.WriteLine("Získal jsi {0} bodů z {1}.", score, 100);
// výstup: Získal jsi 79 bodů z 100.
```

### Formátování čísel

V zástupných symbolech i v interpolaci lze upřesnit formát výstupu:

```csharp
double price = 1234.5678;
Console.WriteLine($"{price:F2}");   // 1234.57  (2 desetinná místa)
Console.WriteLine($"{price:C}");    // $1,234.57 (měna, závisí na nastavení systému)
Console.WriteLine("{0:F3}", price); // 1234.568  (starší styl)
```

---

## Escape sekvence

Speciální znaky, které v řetězci nelze napsat přímo, zapíšeš pomocí zpětného lomítka `\`:

| Sekvence | Význam | Příklad výstupu |
|---|---|---|
| `\n` | Nový řádek | `"A\nB"` → A na prvním, B na druhém řádku |
| `\t` | Tabulátor | `"A\tB"` → A&nbsp;&nbsp;&nbsp;&nbsp;B |
| `\\` | Zpětné lomítko | `"\\"` → `\` |
| `\"` | Uvozovka uvnitř stringu | `"říkal \"ahoj\""` → říkal "ahoj" |

```csharp
Console.WriteLine("Jméno:\tKamil");
Console.WriteLine("Cesta:\tC:\\Users\\Kamil");
Console.WriteLine("Řekl: \"Ahoj!\"");
```

Výstup:
```
Jméno:  Kamil
Cesta:  C:\Users\Kamil
Řekl: "Ahoj!"
```

---

## Vstup – čtení od uživatele

### `Console.ReadLine()`

Přečte celý řádek zadaný uživatelem a vrátí ho jako `string`:

```csharp
Console.Write("Zadej své jméno: ");
string name = Console.ReadLine();
Console.WriteLine($"Ahoj, {name}!");
```

> ⚠️ `ReadLine()` vždy vrací `string`. Pokud potřebuješ číslo, musíš ho převést.

### `Console.Read()`

Přečte jediný znak a vrátí jeho ASCII kód jako `int`. Používá se méně – nejčastěji k pozastavení programu:

```csharp
Console.Read(); // čeká na stisk klávesy
```

---

## Převod vstupu na číslo

Uživatel vždy zadává text – aby ses dostal k číslu, potřebuješ konverzi:

```csharp
Console.Write("Zadej věk: ");
int age = Convert.ToInt32(Console.ReadLine());
```

Zkrácený zápis (obě operace na jednom řádku):

```csharp
int age = Convert.ToInt32(Console.ReadLine());
```

Přehled konverzních metod:

| Metoda | Převádí na |
|---|---|
| `Convert.ToInt32(s)` | `int` |
| `Convert.ToDouble(s)` | `double` |
| `Convert.ToDecimal(s)` | `decimal` |

---

## Kompletní příklad

Program, který přečte jméno a rok narození a vypočítá věk:

```csharp
Console.Write("Zadej jméno: ");
string name = Console.ReadLine();

Console.Write("Zadej rok narození: ");
int birthYear = Convert.ToInt32(Console.ReadLine());

int age = 2025 - birthYear;

Console.WriteLine($"Ahoj, {name}! Je ti přibližně {age} let.");
```

Ukázkový běh:
```
Zadej jméno: Kamil
Zadej rok narození: 2007
Ahoj, Kamil! Je ti přibližně 18 let.
```

---

## Shrnutí

| Metoda | Co dělá |
|---|---|
| `Console.WriteLine()` | Vypíše text + nový řádek |
| `Console.Write()` | Vypíše text bez nového řádku |
| `Console.ReadLine()` | Přečte řádek jako `string` |
| `Console.Read()` | Přečte jeden znak (jako `int`) |
| `Convert.ToInt32()` | Převede `string` na `int` |
| `$"text {proměnná}"` | Interpolace – vkládání proměnných do textu |
| `\n`, `\t`, `\\`, `\"` | Escape sekvence – speciální znaky v textu |
