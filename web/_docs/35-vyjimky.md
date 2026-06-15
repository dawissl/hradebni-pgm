---
layout: post
title: "Výjimky"
order: 35
---

Každý program narazí na situace, které neočekával — uživatel zadá písmeno místo čísla, soubor neexistuje, dojde místo na disku. Tyto situace se v C# řeší mechanismem **výjimek** (exceptions).

---

## Typy chyb

| Typ | Kdy nastane | Příklad |
|---|---|---|
| **Syntaktická chyba** | Při kompilaci — program se vůbec nespustí | Zapomenutý středník, překlep v názvu |
| **Logická chyba** | Program běží, ale dává špatné výsledky | Průměr počítaný dělením 2 místo počtem prvků |
| **Runtime chyba** | Nastane za běhu programu | Dělení nulou, přístup k neexistujícímu indexu |

Výjimky řeší **runtime chyby** — situace, které nelze odhalit při kompilaci.

---

## Blok `try-catch`

```csharp
try
{
    // kód, který může selhat
}
catch (Exception e)
{
    // co dělat, když selže
}
```

Příklad — bezpečné načtení čísla od uživatele:

```csharp
try
{
    Console.Write("Zadej číslo: ");
    int n = int.Parse(Console.ReadLine());
    Console.WriteLine($"Zadal jsi: {n}");
}
catch (Exception e)
{
    Console.WriteLine($"Chyba: {e.Message}");
}
```

Pokud uživatel zadá „abc", `int.Parse` vyhodí výjimku. Bez `try-catch` by program spadl. S ním program chybu zachytí a zobrazí srozumitelnou zprávu.

---

## Blok `finally`

`finally` se provede **vždy** — ať výjimka nastala, nebo ne. Používá se pro úklid (zavření souborů, uvolnění zdrojů).

```csharp
try
{
    // kód
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
finally
{
    Console.WriteLine("Toto se provede vždy.");
}
```

---

## Zachytávání konkrétních výjimek

Místo obecného `Exception` lze zachytávat specifické typy — program pak reaguje různě na různé chyby.

```csharp
try
{
    int[] arr = { 1, 2, 3 };
    Console.Write("Index: ");
    int i = int.Parse(Console.ReadLine());
    Console.WriteLine(arr[i]);
}
catch (FormatException)
{
    Console.WriteLine("Zadej celé číslo.");
}
catch (IndexOutOfRangeException)
{
    Console.WriteLine("Index je mimo rozsah pole (0–2).");
}
catch (Exception e)
{
    Console.WriteLine($"Neočekávaná chyba: {e.Message}");
}
```

> 💡 Zachytávej od **nejspecifičtější** k **nejobecnější**. `Exception` na konci slouží jako záchranná síť pro vše, co jsi nečekal.

### Časté typy výjimek v C#

| Třída výjimky | Kdy nastane |
|---|---|
| `FormatException` | Neplatný formát při převodu (`int.Parse("abc")`) |
| `OverflowException` | Číslo mimo rozsah datového typu |
| `DivideByZeroException` | Dělení nulou u celých čísel |
| `IndexOutOfRangeException` | Přístup mimo rozsah pole |
| `NullReferenceException` | Volání metody na `null` objektu |
| `FileNotFoundException` | Soubor neexistuje |
| `ArgumentException` | Neplatný argument metody |

---

## Klíčové slovo `throw`

Výjimku lze vyhodit i ručně — například při ověřování vstupů:

```csharp
static double Sqrt(double x)
{
    if (x < 0)
        throw new ArgumentException("Odmocnina záporného čísla není definována.");

    return Math.Sqrt(x);
}
```

```csharp
try
{
    Console.WriteLine(Sqrt(-4));
}
catch (ArgumentException e)
{
    Console.WriteLine(e.Message);
}
```

---

## Vlastní výjimky

Pro specializované situace lze vytvořit vlastní typ výjimky — stačí dědit od `Exception`:

```csharp
class NegativeNumberException : Exception
{
    public NegativeNumberException(string message) : base(message) { }
}
```

```csharp
if (value < 0)
    throw new NegativeNumberException($"Hodnota {value} nesmí být záporná.");
```

Vlastní výjimky se hodí u větších projektů, kde chceš odlišit chyby aplikační logiky od systémových chyb.

---

## Shrnutí

```csharp
try
{
    // kód, který může selhat
}
catch (FormatException)       // specifická výjimka
{
    // reakce na konkrétní chybu
}
catch (Exception e)           // záchranná síť
{
    Console.WriteLine(e.Message);
}
finally
{
    // provede se vždy (úklid)
}
```

| Klíčové slovo | Funkce |
|---|---|
| `try` | Obalí rizikový kód |
| `catch` | Zachytí výjimku a zpracuje ji |
| `finally` | Vždy se provede — pro úklid |
| `throw` | Ručně vyhodí výjimku |