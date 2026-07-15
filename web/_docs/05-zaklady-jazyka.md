---
layout: post
title: "Základy jazyka C#"
order: 5
---

## Co je C#?

C# (čti „C sharp") je objektově orientovaný programovací jazyk vyvinutý společností **Microsoft** a je součástí ekosystému **.NET**. Používá se pro vývoj konzolových aplikací, desktopových aplikací (Windows Forms, WPF), webových aplikací (ASP.NET) i mobilních aplikací (Xamarin / MAUI).

C# kód připomíná angličtinu – počítač mu ale přímo nerozumí. Proto se C# kód **kompiluje** do mezikódu (CIL – Common Intermediate Language), který pak spouští runtime prostředí CLR (Common Language Runtime).

> 💡 Zjednodušeně: píšete C# → kompilátor přeloží → CLR spustí.

---

## Proč se učit C#?

- **Syntaxe podobná jiným jazykům** – kdo zná Javu nebo C++, adaptuje se rychle
- **Součást .NET** – přístup k obrovské knihovně hotového kódu (není nutné psát vše od nuly)
- **OOP jazyk** – naučíte se koncepty platné i v jiných jazycích (Java, Kotlin, Swift…)
- **Široké uplatnění** – hry (Unity), web, desktop, mobilní aplikace, testování

---

## Struktura programu v C#

Základní program v C# vypadá takto:

```csharp
using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            Console.Read();
        }
    }
}
```

### Direktivy (`using`)

Řádky začínající `using` říkají kompilátoru, které **jmenné prostory** (namespaces) program využívá.

```csharp
using System;
```

Tato direktiva zpřístupňuje třídu `Console` a další základní prvky jazyka.

### Jmenný prostor (`namespace`)

Namespace je logické seskupení příbuzných tříd a dalších prvků. Zabraňuje **konfliktům názvů** – dvě třídy se stejným jménem mohou existovat, pokud jsou v různých namespace.

```csharp
namespace HelloWorld
{
    // obsah namespace
}
```

### Třída (`class`)

C# je objektově orientovaný jazyk – veškerý kód musí být uvnitř třídy. V konzolové aplikaci je výchozí třída obvykle pojmenována `Program`.

```csharp
class Program
{
    // obsah třídy
}
```

### Metoda `Main()`

`Main()` je **vstupní bod** každé konzolové, i kterékoliv jiné aplikace – první metoda, která se spustí. To platí pro většinu programovacích jazyků.

```csharp
static void Main(string[] args)
{
    // sem píšeme kód
}
```

> ⚠️ Bez metody `Main()` program neví, kde začít. Konzolová aplikace musí mít právě jednu.

### Složené závorky `{ }`

Závorky označují začátek a konec každého bloku kódu (namespace, třídy, metody). Každá otevírací závorka musí mít odpovídající zavírací.

---

## Komentáře

Komentáře jsou části kódu ignorované kompilátorem – slouží k vysvětlení logiky pro ostatní (nebo pro autora za půl roku, když se k práci vrátí).

```csharp
// Jednořádkový komentář

/* Víceřádkový
   komentář */

Console.Read(); // komentář za příkazem
```

> 💡 Dobrý kód je čitelný sám o sobě – komentáře vysvětlují **proč**, ne **co**.

---

## První program krok za krokem

```csharp
using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World"); // vypíše text a přejde na nový řádek
            Console.Read();                   // čeká na stisk klávesy (aby okno nezaniklo)
        }
    }
}
```

| Příkaz | Co dělá |
|---|---|
| `Console.WriteLine("text")` | Vypíše text na konzoli a přejde na nový řádek |
| `Console.Write("text")` | Vypíše text bez přechodu na nový řádek |
| `Console.Read()` | Čeká na stisk klávesy (vrací int) |
| `Console.ReadLine()` | Čeká na Enter a vrátí celý řádek jako string |

---

## Středník

Každý příkaz v C# končí **středníkem** (`;`). Zapomenutý středník je jedna z nejčastějších chyb začátečníků.

```csharp
Console.WriteLine("Toto funguje");   // ✅
Console.WriteLine("Toto nefunguje")  // ❌ chybí středník
```

---

## Shrnutí

| Pojem | Vysvětlení |
|---|---|
| `using` | Direktiva – importuje jmenný prostor |
| `namespace` | Logická skupina tříd a kódu |
| `class` | Základní stavební blok OOP |
| `Main()` | Vstupní bod programu |
| `{ }` | Ohraničení bloku kódu |
| `//` nebo `/* */` | Komentáře |
| `;` | Ukončení příkazu |

---

## Otázky k zamyšlení

1. Proč se program musí nejdřív přeložit (zkompilovat), než ho počítač spustí? Co překladač kontroluje?
2. Jaký je rozdíl mezi chybou při překladu (compile-time) a chybou za běhu (runtime)? Uveďte příklad každé z nich.
3. Proč mají programovací jazyky tak přísná pravidla syntaxe, když lidé si drobné překlepy domyslí?

---

## Procvičení

### Řešený příklad

**Zadání:** V následujícím programu je pět chyb. Najděte je a pokuste se je opravit.

```csharp
using system;

class Program
{
    static void main()
    {
        Console.WriteLine("Ahoj světe")
        int cislo = "5";
        Console.WriteLine(Cislo);
    }
}
```

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

1. `using system;` → `using System;` — C# rozlišuje velká a malá písmena.
2. `static void main()` → `static void Main()` — vstupní bod programu musí být `Main` s velkým M.
3. Za `Console.WriteLine("Ahoj světe")` chybí středník.
4. `int cislo = "5";` — do `int` nelze přiřadit řetězec. Správně `int cislo = 5;`.
5. `Console.WriteLine(Cislo);` — proměnná se jmenuje `cislo` (malé c); C# je case-sensitive.

Opravený program:

```csharp
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Ahoj světe");
        int cislo = 5;
        Console.WriteLine(cislo);
    }
}
```

</details>

### Samostatná cvičení

1. **Základní** — Napište program, který vypíše tři řádky textu: své jméno, svou třídu a svůj oblíbený předmět.
2. **Pokročilejší** — Schválně vytvořte program se třemi různými chybami a vyzkoušejte, co na každou z nich řekne překladač. Naučte se chybové hlášky číst.
3. **Bonus (*)** — Zjistěte, co znamená hláška `error CS0103: The name '...' does not exist in the current context` a vytvořte program, který ji vyvolá.