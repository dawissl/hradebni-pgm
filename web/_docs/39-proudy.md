---
layout: post
title: "Vstupní a výstupní proudy"
order: 39
---

Třída `File` z předchozí kapitoly načítá celý soubor najednou do paměti. Pro velké soubory nebo pro čtení řádek po řádku jsou vhodnější **proudy** (streams) — data čteš nebo zapisuješ postupně, bez nutnosti mít vše v paměti najednou.

---

## Princip streamů

Stream je abstrakce nad zdrojem nebo cílem dat — může to být soubor, síťové připojení, paměť. Čteš nebo zapisuješ po kouscích.

```
Soubor na disku  ──►  StreamReader  ──►  tvůj kód
tvůj kód  ──►  StreamWriter  ──►  Soubor na disku
```

---

## StreamReader — čtení řádek po řádku

```csharp
using System.IO;

string cesta = "data.txt";

using (StreamReader sr = new StreamReader(cesta))
{
    while (!sr.EndOfStream)
    {
        string radek = sr.ReadLine();
        Console.WriteLine(radek);
    }
}
// using blok automaticky zavře soubor
```

### Čtení celého obsahu

```csharp
using (StreamReader sr = new StreamReader("soubor.txt"))
{
    string vsechen = sr.ReadToEnd();
    Console.WriteLine(vsechen);
}
```

### Zpracování CSV souboru

```csharp
using (StreamReader sr = new StreamReader("zamestnanci.csv"))
{
    sr.ReadLine(); // přeskočí hlavičku

    while (!sr.EndOfStream)
    {
        string[] pole = sr.ReadLine().Split(',');
        string jmeno = pole[0].Trim();
        int vek = int.Parse(pole[1].Trim());
        Console.WriteLine($"{jmeno}, {vek} let");
    }
}
```

---

## StreamWriter — zápis řádek po řádku

```csharp
using (StreamWriter sw = new StreamWriter("vystup.txt"))
{
    sw.WriteLine("První řádek");
    sw.WriteLine("Druhý řádek");
    sw.Write("Bez zalomení");
}
```

### Přidání na konec (append)

```csharp
// druhý parametr true = append, false (výchozí) = přepsat
using (StreamWriter sw = new StreamWriter("log.txt", append: true))
{
    sw.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Aplikace spuštěna");
}
```

---

## using blok — proč je důležitý

`StreamReader` a `StreamWriter` drží otevřený handle na soubor. Pokud ho nezavřeš, soubor zůstane zamčený — jiný program (nebo ty sám) ho nemůže otevřít.

Blok `using` zajistí zavolání `Dispose()` (a tím zavření souboru) automaticky — i v případě výjimky.

```csharp
// Ekvivalentní zápisy:

// 1. using blok
using (StreamReader sr = new StreamReader("soubor.txt"))
{
    // ...
}

// 2. using deklarace (C# 8+, zavře se na konci scope)
using StreamReader sr = new StreamReader("soubor.txt");
// ...
// automaticky zavřeno zde
```

---

## Kódování

Výchozí kódování je UTF-8. Pokud soubor pochází z jiného systému, specifikuj kódování explicitně:

```csharp
using (StreamReader sr = new StreamReader("windows.txt",
    System.Text.Encoding.GetEncoding("windows-1250")))
{
    // ...
}
```

---

## Shrnutí

| Třída | Použití |
|---|---|
| `StreamReader` | Čtení textu ze souboru — řádek po řádku nebo celý najednou |
| `StreamWriter` | Zápis textu do souboru |
| `using` blok | Zajistí automatické zavření souboru |
| `sr.ReadLine()` | Přečte jeden řádek |
| `sr.EndOfStream` | `true` = jsme na konci souboru |
| `sw.WriteLine()` | Zapíše řádek se zalomením |
| `append: true` | Přidá na konec místo přepsání |
