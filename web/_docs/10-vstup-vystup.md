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

Proměnnou předáte přímo jako argument – **bez uvozovek**:

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

Před uvozovky přidáte `$` a proměnné zapíšete přímo do `{ }`:

```csharp
string name = "Kamil";
int age = 17;
Console.WriteLine($"Jmenuji se {name} a je mi {age} let.");
```

> 💡 Interpolace `$"..."` je přehlednější než spojování pomocí `+`. Používejte ji jako výchozí volbu.

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

Speciální znaky, které v řetězci nelze napsat přímo, zapíšete pomocí zpětného lomítka `\`:

| Sekvence | Význam | Příklad výstupu |
|---|---|---|
| `\n` | Nový řádek | `"A\nB"` → A na prvním, B na druhém řádku |
| `\t` | Tabulátor | `"A\tB"` → A&nbsp;&nbsp;&nbsp;&nbsp;B |
| `\\` | Zpětné lomítko | `"\\"` → `\` |
| `\"` | Uvozovka uvnitř stringu | `"říkal \"ahoj\""` → říkal "ahoj" |

> 💡 `\n` je pevně daný Unix styl konce řádku. Windows historicky používá `\r\n`. Pro `Console.WriteLine` je to jedno – ta si nový řádek přidává sama. Ale pokud řádek ukládáte do proměnné, souboru nebo posíláte jinam (např. do textového pole), použijte konstantu `Environment.NewLine`, která se přizpůsobí operačnímu systému, na kterém program běží:

```csharp
string zprava = "Jméno: Kamil" + Environment.NewLine + "Věk: 25";
File.WriteAllText("info.txt", zprava);
```

> Na Windows se do souboru zapíše `\r\n`, na Linuxu/macOS `\n` – bez toho, abyste to museli řešit ručně.

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

> ⚠️ `ReadLine()` vždy vrací `string`. Pokud potřebujete číslo, musíte ho převést než s ním můžete dál pracovat. V opačeném případě očekávejte chybu při kompilaci nebo běhovou vyjímku.

### `Console.Read()`

Přečte jediný znak a vrátí jeho ASCII kód jako `int`. Používá se méně – nejčastěji k pozastavení programu:

```csharp
Console.Read(); // čeká na stisk klávesy
```

---

## Převod vstupu na číslo

Uživatel vždy zadává text – aby ses dostal k číslu, potřebujete konverzi:

```csharp
Console.Write("Zadej věk: ");
int age = Convert.ToInt32(Console.ReadLine());
```

Zkrácený zápis (obě operace na jednom řádku):

```csharp
int age = Convert.ToInt32(Console.ReadLine());
```

Alternativně lze i použít metodu `Parse()` pro jednotlivé datové typy:

```csharp
int age = int.Parse(Console.ReadLine());
```

Přehled konverzních metod:

| Metoda | Převádí na |
|---|---|
| `Convert.ToInt32(s)` | `int` |
| `Convert.ToDouble(s)` | `double` |
| `Convert.ToDecimal(s)` | `decimal` |
| `int.Parse(s)` | `int` |
| `bool.Parse(s)` | `bool` |
| `double.Parse(s)` | `double` |

---

## Kompletní příklad

Program, který přečte jméno a rok narození a vypočítá věk:

```csharp
Console.Write("Zadej jméno: ");
string name = Console.ReadLine();

Console.Write("Zadej rok narození: ");
int birthYear = Convert.ToInt32(Console.ReadLine());

int age = 2026 - birthYear;

Console.WriteLine($"Ahoj, {name}! Je ti přibližně {age} let.");
```

Ukázkový běh:
```
Zadej jméno: Kamil
Zadej rok narození: 2007
Ahoj, Kamil! Je ti přibližně 19 let.
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

---

## Otázky k zamyšlení

1. Proč `Console.ReadLine()` vrací vždy `string`, i když uživatel napíše číslo?
2. Co se stane, když uživatel místo čísla zadá "abc" a program zavolá `Convert.ToInt32()`? Jak se tomu dá předejít?
3. Jaký je rozdíl mezi `Console.Write` a `Console.WriteLine`? Kdy se hodí ten první?

---

## Procvičení

### Řešený příklad

**Zadání:** Napište program, který se zeptá na jméno a rok narození, a vypíše pozdrav s vypočteným (přibližným) věkem. Ošetřete situaci, kdy uživatel nezadá platné číslo — použijte `int.TryParse`.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

`int.TryParse` je bezpečnější než `Convert.ToInt32` — místo pádu programu vrátí `false`, když převod selže.

```csharp
Console.Write("Jak se jmenuješ? ");
string jmeno = Console.ReadLine();

Console.Write("V jakém roce ses narodil(a)? ");
string vstup = Console.ReadLine();

if (int.TryParse(vstup, out int rok))
{
    int vek = 2026 - rok;
    Console.WriteLine($"Ahoj {jmeno}, letos ti bude {vek} let.");
}
else
{
    Console.WriteLine("To nevypadá jako rok. Zkus to znovu.");
}
```

Všimněte si vzoru: `TryParse` vrací `bool` (povedlo se?) a výsledek předává přes `out` parametr — o obojím se dozvíte víc v kapitole o metodách.

</details>

### Samostatná cvičení

1. **Základní** — Napište program, který načte dvě čísla a vypíše jejich součet, rozdíl, součin a podíl, každý na samostatném řádku ve formátu `a + b = c`.
2. **Pokročilejší** — Upravte program z řešeného příkladu tak, aby se na rok ptal opakovaně, dokud uživatel nezadá platné číslo.
3. **Bonus (*)** — Prozkoumejte formátování výstupu: vypište číslo `1234.5678` zaokrouhlené na 2 desetinná místa, jako měnu a s oddělovači tisíců (`{cislo:N2}`, `{cislo:C}`, ...).