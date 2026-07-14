---
layout: post
title: "Práce s řetězcem"
order: 16
---

Řetězec (`string`) je posloupnost znaků uzavřená v dvojitých uvozovkách. V C# je `string` referenční typ, ale chová se jako hodnotový – při porovnávání se porovnává obsah, ne adresa v paměti.

```csharp
string message = "Hello World";
string empty   = "";
string name    = "Kamil";
```

---

## Neměnnost řetězce (immutability)

`string` je v C# **neměnný** – každá metoda, která „mění" řetězec, ve skutečnosti vytvoří **nový** řetězec a vrátí ho. Původní zůstane nezměněný.

```csharp
string name = "kamil";
string upper = name.ToUpper(); // vrátí nový řetězec "KAMIL"

Console.WriteLine(name);  // kamil – nezměněno
Console.WriteLine(upper); // KAMIL
```

> 💡 Toto má dopad na výkon při intenzivním skládání řetězců v cyklu – viz sekce [StringBuilder](#stringbuilder) níže.

---

## Vlastnosti a metody třídy string

### `Length` – délka řetězce

```csharp
string message = "Hello World";
Console.WriteLine(message.Length); // 11 (včetně mezery)
```

---

### `ToUpper()` a `ToLower()` – změna velikosti písmen

```csharp
string name = "Kamil";
Console.WriteLine(name.ToUpper()); // KAMIL
Console.WriteLine(name.ToLower()); // kamil
```

Hodí se pro **porovnávání bez ohledu na velikost písmen**:

```csharp
string input = Console.ReadLine();
if (input.ToLower() == "ano")
    Console.WriteLine("Souhlasíš.");
```

---

### `Trim()`, `TrimStart()`, `TrimEnd()` – odebrání bílých znaků

```csharp
string raw = "   Ahoj světe!   ";
Console.WriteLine(raw.Trim());      // "Ahoj světe!"
Console.WriteLine(raw.TrimStart()); // "Ahoj světe!   "
Console.WriteLine(raw.TrimEnd());   // "   Ahoj světe!"
```

Nezbytné při zpracování uživatelského vstupu – mezery na začátku/konci jsou častý zdroj chyb. Tyto metody odstraňují všechny bílé znaky (whitespace).

---

### `Contains()` – zda řetězec obsahuje podřetězec

Vrátí `bool`.

```csharp
string sentence = "C# je skvělý jazyk.";
Console.WriteLine(sentence.Contains("skvělý")); // true
Console.WriteLine(sentence.Contains("Python"));  // false
```

---

### `IndexOf()` – pozice prvního výskytu

Vrátí index prvního výskytu hledaného podřetězce, nebo `-1` pokud neexistuje.

```csharp
string message = "Hello World";
Console.WriteLine(message.IndexOf("World")); // 6
Console.WriteLine(message.IndexOf("Java"));  // -1
```

---

### `Substring()` – výřez podřetězce

Dva parametry: **startovní index** a **délka**. Pokud délku vynecháte, vrátí vše od startu do konce.

```csharp
string message = "Hello World";

Console.WriteLine(message.Substring(6));     // "World"    (od indexu 6 do konce)
Console.WriteLine(message.Substring(0, 5));  // "Hello"    (5 znaků od indexu 0)
Console.WriteLine(message.Substring(2, 5));  // "llo W"    (5 znaků od indexu 2)
```

> ⚠️ Index musí být v rozsahu délky řetězce, jinak vyhodí `ArgumentOutOfRangeException`.

---

### `Replace()` – nahrazení podřetězce

```csharp
string message = "Hello World";
string newMessage = message.Replace("World", "C#");
Console.WriteLine(newMessage); // "Hello C#"

// odstraní všechny mezery
string noSpaces = message.Replace(" ", "");
Console.WriteLine(noSpaces); // "HelloWorld"
```

---

### `Split()` – rozdělení řetězce na pole

Rozdělí řetězec podle oddělovače a vrátí pole stringů.

```csharp
string csv = "Kamil,Jana,Tomáš,Petr";
string[] names = csv.Split(',');

foreach (string name in names)
    Console.WriteLine(name);
// Kamil
// Jana
// Tomáš
// Petr
```

Více oddělovačů najednou:

```csharp
string data = "Kamil; Jana, Tomáš";
string[] separators = { ", ", "; " };
string[] names = data.Split(separators, StringSplitOptions.RemoveEmptyEntries);
```

`StringSplitOptions.RemoveEmptyEntries` automaticky odstraní prázdné řetězce ze výsledného pole.

---

### `Equals()` – porovnání řetězců

Bezpečnější alternativa k `==` s možností ignorovat velikost písmen:

```csharp
string a = "Kamil";
string b = "kamil";

Console.WriteLine(a == b);                                           // false
Console.WriteLine(a.Equals(b));                                      // false
Console.WriteLine(a.Equals(b, StringComparison.OrdinalIgnoreCase)); // true
```

---

### Přehled metod

| Metoda | Co dělá | Vrací |
|---|---|---|
| `Length` | Počet znaků | `int` |
| `ToUpper()` | Velká písmena | `string` |
| `ToLower()` | Malá písmena | `string` |
| `Trim()` | Odstraní bílé znaky z obou stran | `string` |
| `Contains(s)` | Obsahuje podřetězec? | `bool` |
| `IndexOf(s)` | Index prvního výskytu (nebo -1) | `int` |
| `Substring(i, n)` | Výřez od indexu i, délky n | `string` |
| `Replace(old, new)` | Nahradí všechny výskyty | `string` |
| `Split(sep)` | Rozdělí na pole | `string[]` |
| `Equals(s, comp)` | Porovnání (volitelně case-insensitive) | `bool` |

---

## Interpolace řetězců

Moderní způsob vkládání proměnných do textu. Před uvozovky přidáte `$`:

```csharp
string name = "Kamil";
int age = 17;
double average = 88.5;

Console.WriteLine($"Jmenuji se {name}, je mi {age} let a průměr mám {average}.");
```

Uvnitř `{ }` může být libovolný výraz:

```csharp
int a = 5, b = 3;
Console.WriteLine($"Součet {a} + {b} = {a + b}");
Console.WriteLine($"Délka jména: {name.Length}");
Console.WriteLine($"Velká písmena: {name.ToUpper()}");
```

### Formátování hodnot v interpolaci

```csharp
double price = 1234.5678;
Console.WriteLine($"{price:F2}");   // 1234.57  (2 des. místa)
Console.WriteLine($"{price:N0}");   // 1,235    (celé číslo s oddělovačem tisíců)
Console.WriteLine($"{price:C}");    // $1,234.57 (měna dle nastavení systému)

int score = 42;
Console.WriteLine($"{score:D5}");  // 00042    (doplní nuly zleva)
```

---

## StringBuilder

Protože `string` je neměnný, **skládání řetězců v cyklu** pomocí `+` vytváří vždy nový objekt – to je pomalé a plýtvá pamětí.

```csharp
// ❌ neefektivní – každá iterace vytvoří nový string
string result = "";
for (int i = 0; i < 10000; i++)
    result += i.ToString();
```

Pro takové případy existuje `StringBuilder` z namespace `System.Text` – interně pracuje s bufferem a řetězec sestaví až na konci.

```csharp
using System.Text;

StringBuilder sb = new StringBuilder();

for (int i = 0; i < 10000; i++)
    sb.Append(i);

string result = sb.ToString(); // sestaví výsledný řetězec
```

### Metody StringBuilder

```csharp
StringBuilder sb = new StringBuilder();

sb.Append("Hello");           // přidá na konec
sb.AppendLine(" World");      // přidá + nový řádek
sb.Insert(5, ",");            // vloží na daný index
sb.Replace("Hello", "Ahoj"); // nahradí podřetězec
sb.Remove(0, 5);              // odebere znaky od indexu 0, délky 5

Console.WriteLine(sb.Length); // aktuální délka
Console.WriteLine(sb.ToString()); // převede na string
```

### Kdy použít `string`, kdy `StringBuilder`?

| Situace | Použití |
|---|---|
| Jednoduchá práce s textem, metody, porovnávání | `string` |
| Skládání mnoha řetězců v cyklu (100+) | `StringBuilder` |
| Postupné budování výstupu (generování HTML, CSV…) | `StringBuilder` |

> 💡 Pro běžné programy rozdíl nepoznáte. `StringBuilder` oceníte při práci s velkými daty nebo generování textu v cyklech.

---

## Kompletní příklad

Program načte větu, spočítá slova a zobrazí ji pozpátku:

```csharp
Console.Write("Zadej větu: ");
string sentence = Console.ReadLine().Trim();

// počet slov
string[] words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
Console.WriteLine($"Počet slov: {words.Length}");

// věta velkými písmeny
Console.WriteLine($"Velká písmena: {sentence.ToUpper()}");

// výřez prvního slova
string firstWord = sentence.Substring(0, sentence.IndexOf(' ') > 0
    ? sentence.IndexOf(' ')
    : sentence.Length);
Console.WriteLine($"První slovo: {firstWord}");
```

---

## Shrnutí

```csharp
string s = "  Hello World  ";

s.Length            // 15
s.Trim()            // "Hello World"
s.ToUpper()         // "  HELLO WORLD  "
s.Contains("World") // true
s.IndexOf("World")  // 8
s.Substring(8, 5)   // "World"
s.Replace("World", "C#") // "  Hello C#  "
s.Split(' ')        // pole slov

// interpolace
$"Délka: {s.Length}"

// StringBuilder pro cykly
StringBuilder sb = new StringBuilder();
sb.Append("text");
string result = sb.ToString();
```

---

## Otázky k zamyšlení

1. Řetězce v C# jsou *neměnné* (immutable). Co to znamená a co ve skutečnosti dělá `text.ToUpper()`?
2. Proč se dva řetězce porovnávají přes `==` nebo `Equals`, ale u jiných referenčních typů `==` porovnává reference?
3. Proč je skládání dlouhého textu v cyklu přes `+=` pomalé a co je `StringBuilder`?

---

## Procvičení

### Řešený příklad

**Zadání:** Napište program, který zjistí, zda je zadané slovo palindrom (čte se stejně zepředu i zezadu, např. "krk", "oko"). Ignorujte velikost písmen.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

Porovnáváme znaky od krajů ke středu — stačí projít polovinu slova:

```csharp
Console.Write("Zadej slovo: ");
string slovo = Console.ReadLine().ToLower();

bool jePalindrom = true;

for (int i = 0; i < slovo.Length / 2; i++)
{
    if (slovo[i] != slovo[slovo.Length - 1 - i])
    {
        jePalindrom = false;
        break;
    }
}

Console.WriteLine(jePalindrom
    ? $"\"{slovo}\" je palindrom."
    : $"\"{slovo}\" není palindrom.");
```

K řetězci lze přistupovat přes index jako k poli znaků (`slovo[i]`). Jakmile najdeme první neshodu, `break` ukončí cyklus — dál nemá smysl hledat.

</details>

### Samostatná cvičení

1. **Základní** — Načtěte jméno a příjmení v jednom řádku a vypište iniciály (např. "Jan Novák" → "J. N."). Použijte `Split` a indexaci.
2. **Pokročilejší** — Napište program, který spočítá samohlásky v zadaném textu. (Nápověda: `"aeiouyáéíóúůý".Contains(znak)`.)
3. **Bonus (*)** — Vytvořte jednoduchou šifru Caesar: posuňte každé písmeno abecedy o 3 pozice (a→d, b→e, ..., x→a). Napište i dešifrování.
