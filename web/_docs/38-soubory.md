---
layout: post
title: "Práce se soubory"
order: 38
---

Data v proměnných existují jen po dobu běhu programu — při ukončení se ztratí. Soubory umožňují data **trvale uložit** na disk a znovu načíst při příštím spuštění. Tato kapitola je přehledem; konkrétní techniky čtení a zápisu jsou v kapitolách **Vstupní a výstupní proudy** a **Cesty a adresáře**.

---

## Přehled kapitol o souborech

| Kapitola | Obsah |
|---|---|
| **Práce se soubory** (tato) | Přehled, jmenný prostor `System.IO`, třída `File` |
| **Vstupní a výstupní proudy** | `StreamReader`, `StreamWriter`, kódování |
| **Cesty a adresáře** | `Path`, `Directory`, relativní vs. absolutní cesty |

---

## Jmenný prostor System.IO

Všechny třídy pro práci se soubory jsou v jmenném prostoru `System.IO`. Na začátek souboru přidejte:

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

> ⚠️ Vždy ověřte `File.Exists()` před čtením — pokus o čtení neexistujícího souboru vyhodí `FileNotFoundException`. Nebo zachyťte výjimku pomocí `try-catch`.

---

## Kódování

Textové soubory ukládají znaky jako bajty. Kódování určuje, jak se znaky převádějí.

```csharp
// Výchozí kódování (UTF-8 bez BOM) — nejběžnější a nejpřenositelnější volba
File.WriteAllText("soubor.txt", "Žluťoučký kůň");

// Explicitní UTF-8 s BOM (některé starší nástroje BOM vyžadují nebo očekávají)
File.WriteAllText("soubor.txt", "Žluťoučký kůň", System.Text.Encoding.UTF8);
```

> ⚠️ Snadná záměna: `Encoding.UTF8` (statická vlastnost) BOM **přidává** — není to totéž jako "bez BOM". Pro explicitní zápis bez BOM je potřeba `new UTF8Encoding(encoderShouldEmitUTF8Identifier: false)`.

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

---

## Otázky k zamyšlení

1. Proč data v proměnných "přežijí" jen do konce běhu programu? Kde jsou uložena a kde jsou uložené soubory?
2. Jaký je rozdíl mezi textovým a binárním souborem? Otevřete oba v poznámkovém bloku — co uvidíte?
3. Co všechno se může pokazit při práci se souborem, i když je váš kód správně? (Nápověda: soubor neexistuje, oprávnění, disk...)

---

## Procvičení

### Řešený příklad

**Zadání:** Napište program, který uloží nákupní seznam (zadaný uživatelem po řádcích, konec prázdným řádkem) do souboru `nakup.txt` a poté ho ze souboru načte a vypíše číslovaný.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

Pro jednoduché scénáře stačí statické metody třídy `File` — o otevírání a zavírání se postarají samy:

```csharp
List<string> polozky = new List<string>();

Console.WriteLine("Zadávej položky (prázdný řádek = konec):");
while (true)
{
    string radek = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(radek)) break;
    polozky.Add(radek.Trim());
}

// zápis – každá položka na samostatný řádek
File.WriteAllLines("nakup.txt", polozky);
Console.WriteLine("Uloženo do nakup.txt");

// čtení a výpis
string[] nactene = File.ReadAllLines("nakup.txt");
Console.WriteLine($"\nNákupní seznam ({nactene.Length} položek):");
for (int i = 0; i < nactene.Length; i++)
{
    Console.WriteLine($"{i + 1}. {nactene[i]}");
}
```

Dvojice `WriteAllLines`/`ReadAllLines` je ideální pro data "řádek = záznam". Pozor: `WriteAllLines` soubor bez ptaní **přepíše** — pro přidávání existuje `AppendAllLines`.

</details>

### Samostatná cvičení

1. **Základní** — Upravte program tak, aby před zápisem zkontroloval `File.Exists` a při existujícím souboru se zeptal, zda přepsat, nebo přidat na konec.
2. **Pokročilejší** — Napište jednoduchý deník: program při každém spuštění přidá do `denik.txt` řádek s aktuálním datem, časem a zadanou poznámkou. Volba "V" vypíše celý deník.
3. **Bonus (*)** — Ulož do souboru známky ve formátu `předmět;známka` (CSV) a při načtení spočítejte průměr každého předmětu. Ošetřete poškozený řádek.