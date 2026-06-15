---
layout: post
title: "Práce se soubory"
order: 38
---

Data v proměnných existují jen po dobu běhu programu — při ukončení se ztratí. Soubory umožňují data **trvale uložit** na disk a znovu načíst při příštím spuštění. Tato kapitola je přehledem; konkrétní techniky čtení a zápisu jsou v kapitolách 39 a 40.

---

## Přehled kapitol o souborech

| Kapitola | Obsah |
|---|---|
| **38 — tato** | Přehled, jmenný prostor `System.IO`, třída `File` |
| **39 — Proudy** | `StreamReader`, `StreamWriter`, kódování |
| **40 — Cesty a adresáře** | `Path`, `Directory`, relativní vs. absolutní cesty |

---

## Jmenný prostor System.IO

Všechny třídy pro práci se soubory jsou v jmenném prostoru `System.IO`. Na začátek souboru přidej:

```csharp
using System.IO;
```

---

## Třída File — rychlé operace

`File` nabízí statické metody pro nejčastější operace — čtení a zápis celého souboru najednou.

### Zápis

```csharp
// Zapíše text do souboru (přepíše, pokud existuje)
File.WriteAllText("poznamky.txt", "Obsah mých poznámek.");

// Zapíše pole řádků
string[] radky = { "První řádek", "Druhý řádek", "Třetí řádek" };
File.WriteAllLines("seznam.txt", radky);

// Přidá text na konec (bez přepsání)
File.AppendAllText("log.txt", $"[{DateTime.Now}] Aplikace spuštěna.\n");
```

### Čtení

```csharp
// Načte celý soubor jako jeden string
string obsah = File.ReadAllText("poznamky.txt");
Console.WriteLine(obsah);

// Načte jako pole řádků
string[] radky = File.ReadAllLines("seznam.txt");
foreach (string radek in radky)
    Console.WriteLine(radek);
```

### Kontrola existence a další operace

```csharp
if (File.Exists("data.txt"))
{
    string obsah = File.ReadAllText("data.txt");
}
else
{
    Console.WriteLine("Soubor neexistuje.");
}

File.Copy("original.txt", "kopie.txt");       // kopírování
File.Move("stary.txt", "novy.txt");           // přejmenování / přesun
File.Delete("docasny.txt");                   // smazání
```

> ⚠️ Vždy ověř `File.Exists()` před čtením — pokus o čtení neexistujícího souboru vyhodí `FileNotFoundException`. Nebo zachyť výjimku pomocí `try-catch`.

---

## Kódování

Textové soubory ukládají znaky jako bajty. Kódování určuje, jak se znaky převádějí.

```csharp
// Výchozí kódování (UTF-8 s BOM)
File.WriteAllText("soubor.txt", "Žluťoučký kůň");

// Explicitní kódování UTF-8 bez BOM (vhodné pro sdílení)
File.WriteAllText("soubor.txt", "Žluťoučký kůň", System.Text.Encoding.UTF8);
```

Pokud soubor obsahuje háčky a čárky, ale zobrazuje se „moji kůň", je problém v kódování — soubor byl uložen nebo načten s jiným kódováním, než bylo vytvořeno.

---

## Shrnutí

| Metoda | Co dělá |
|---|---|
| `File.WriteAllText` | Zapíše string do souboru |
| `File.WriteAllLines` | Zapíše pole řádků |
| `File.AppendAllText` | Přidá text na konec |
| `File.ReadAllText` | Načte celý soubor jako string |
| `File.ReadAllLines` | Načte soubor jako pole řádků |
| `File.Exists` | Zkontroluje, zda soubor existuje |
| `File.Copy / Move / Delete` | Kopírování, přesun, mazání |
