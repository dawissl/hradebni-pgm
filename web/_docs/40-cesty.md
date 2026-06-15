---
layout: post
title: "Cesty a adresáře"
order: 40
---

Soubor musíš nejdřív najít — a to vyžaduje správně sestavit cestu. Třída `Path` pomáhá se sestavováním cest přenositelným způsobem, třída `Directory` s procházením adresářové struktury.

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

> 💡 Pro přenositelnost kódu preferuj relativní cesty — absolutní cesta platí jen na konkrétním počítači.

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
