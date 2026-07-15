---
layout: post
title: "Cesty a adresáře"
order: 40
---

Soubor musíte nejdřív najít — a to vyžaduje správně sestavit cestu. Třída `Path` pomáhá se sestavováním cest přenositelným způsobem, třída `Directory` s procházením adresářové struktury.

---

## Absolutní vs. relativní cesta

**Absolutní cesta** začíná od kořene systému souborů:

```
C:\Users\Jana\Documents\data.txt       // Windows
/home/jana/dokumenty/data.txt          // Linux / macOS
```

**Relativní cesta** je relativní k aktuálnímu adresáři (obvykle adresář, kde běží `.exe`):

```
data.txt                    // soubor ve stejném adresáři
data\soubory\data.txt       // podadresář
..\sdilene\config.txt       // nadřazený adresář
```

> 💡 Pro přenositelnost kódu preferujte relativní cesty — absolutní cesta platí jen na konkrétním počítači.

---

## Třída Path

`Path` poskytuje statické metody pro práci s cestami — bez nutnosti přemýšlet nad lomítky a platformami.

```csharp
string slozka = @"C:\Users\Jana\Documents";
string soubor = "data.txt";

// Sestavení cesty (správné lomítko automaticky)
string plnaCesta = Path.Combine(slozka, soubor);
// → C:\Users\Jana\Documents\data.txt

// Rozložení cesty
Console.WriteLine(Path.GetFileName(plnaCesta));       // data.txt
Console.WriteLine(Path.GetFileNameWithoutExtension(plnaCesta)); // data
Console.WriteLine(Path.GetExtension(plnaCesta));      // .txt
Console.WriteLine(Path.GetDirectoryName(plnaCesta));  // C:\Users\Jana\Documents
```

### Speciální složky

```csharp
// Složka Dokumenty aktuálního uživatele
string dokumenty = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

// Dočasná složka systému
string temp = Path.GetTempPath();

// Dočasný soubor s unikátním názvem
string docasny = Path.GetTempFileName();
```

---

## Třída Directory

```csharp
// Existence složky
if (!Directory.Exists(@"C:\Data\Vystupy"))
    Directory.CreateDirectory(@"C:\Data\Vystupy");

// Výpis souborů ve složce
string[] soubory = Directory.GetFiles(@"C:\Data", "*.txt");
foreach (string s in soubory)
    Console.WriteLine(Path.GetFileName(s));

// Výpis podsložek
string[] slozky = Directory.GetDirectories(@"C:\Data");

// Rekurzivní výpis všech souborů (včetně podsložek)
string[] vsechny = Directory.GetFiles(@"C:\Data", "*.*",
    SearchOption.AllDirectories);

// Přesun a smazání složky
Directory.Move(@"C:\Data\Stare", @"C:\Archiv\Stare");
Directory.Delete(@"C:\Data\Docasne", recursive: true);
```

---

## FileInfo a DirectoryInfo — objektová alternativa

`File` a `Directory` nabízí statické metody — pohodlné pro jednorázové operace. Pokud potřebujete o jednom souboru zjistit víc informací najednou (velikost, datum vytvoření, poslední úprava...), hodí se `FileInfo` — vytvoříte jednu instanci a pak z ní čtete vlastnosti opakovaně.

```csharp
FileInfo info = new FileInfo(@"C:\Data\soubor.txt");

Console.WriteLine(info.Name);           // soubor.txt
Console.WriteLine(info.Length);         // velikost v bajtech
Console.WriteLine(info.CreationTime);   // datum vytvoření
Console.WriteLine(info.LastWriteTime);  // datum poslední úpravy
```

Obdobně existuje `DirectoryInfo` pro složky (`info.Parent`, `info.GetFiles()`...).

> 💡 Pravidlo pro výběr: **jedna rychlá operace** → statická metoda `File`/`Directory`. **Víc informací o tomtéž souboru** → `FileInfo`/`DirectoryInfo`, ať se pro každou vlastnost znovu nesahá na disk.

---

## Praktický příklad — načtení všech CSV ze složky

```csharp
string slozka = Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
    "Export"
);

if (!Directory.Exists(slozka))
{
    Console.WriteLine("Složka Export neexistuje.");
    return;
}

string[] csvSoubory = Directory.GetFiles(slozka, "*.csv");
Console.WriteLine($"Nalezeno {csvSoubory.Length} CSV souborů:");

foreach (string cesta in csvSoubory)
{
    Console.WriteLine($"  {Path.GetFileName(cesta)}");
}
```

---

## Shrnutí

| Metoda | Co dělá |
|---|---|
| `Path.Combine(a, b)` | Sestaví cestu ze součástí (správná lomítka) |
| `Path.GetFileName` | Název souboru s příponou |
| `Path.GetExtension` | Přípona (`.txt`, `.csv`…) |
| `Path.GetDirectoryName` | Nadřazená složka |
| `Directory.Exists` | Zkontroluje existenci složky |
| `Directory.CreateDirectory` | Vytvoří složku (i celou cestu) |
| `Directory.GetFiles` | Vrátí seznam souborů v složce |
| `Directory.GetDirectories` | Vrátí seznam podsložek |
| `FileInfo` / `DirectoryInfo` | Objekt s vlastnostmi o jednom souboru/složce (velikost, data...) |

---

## Otázky k zamyšlení

1. Jaký je rozdíl mezi absolutní a relativní cestou? Vůči čemu se relativní cesta vyhodnocuje?
2. Proč se cesty skládají přes `Path.Combine` místo lepení řetězců s `+ "\\" +`?
3. Proč je zápis `"C:\temp\novy.txt"` v C# problém a jaké jsou dvě možnosti řešení? (Nápověda: escape sekvence, verbatim string.)

---

## Procvičení

### Řešený příklad

**Zadání:** Napište program, který pro zadanou cestu k souboru vypíše: název souboru, příponu, název bez přípony, složku, a zda soubor skutečně existuje. Použijte třídu `Path`.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

```csharp
Console.Write("Zadej cestu k souboru: ");
string cesta = Console.ReadLine();

Console.WriteLine($"Název souboru:  {Path.GetFileName(cesta)}");
Console.WriteLine($"Přípona:        {Path.GetExtension(cesta)}");
Console.WriteLine($"Bez přípony:    {Path.GetFileNameWithoutExtension(cesta)}");
Console.WriteLine($"Složka:         {Path.GetDirectoryName(cesta)}");
Console.WriteLine($"Absolutní:      {Path.GetFullPath(cesta)}");
Console.WriteLine($"Existuje:       {(File.Exists(cesta) ? "ano" : "ne")}");
```

Třída `Path` pracuje jen s **textem cesty** — nic nekontroluje na disku (proto existenci ověřuje až `File.Exists`). Výhoda: metody správně řeší oddělovače na různých systémech (`\` vs `/`), okrajové případy i soubory bez přípony, což ruční parsování řetězce skoro jistě pokazí.

</details>

### Samostatná cvičení

1. **Základní** — Vypište pomocí `Directory.GetFiles` všechny soubory ve zvolené složce, u každého název a velikost v kB (`FileInfo.Length`).
2. **Pokročilejší** — Napište program "úklid stažených souborů": ve zvolené složce roztřiďte soubory do podsložek podle přípony (obrazky, dokumenty, ostatni). Použijte `Path.Combine`, `Directory.CreateDirectory` a `File.Move`.
3. **Bonus (*)** — Napište rekurzivní metodu, která projde složku včetně všech podsložek a najde největší soubor. Porovnejte s `Directory.GetFiles(cesta, "*", SearchOption.AllDirectories)`.