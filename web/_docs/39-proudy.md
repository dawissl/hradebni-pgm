---
layout: post
title: "Vstupní a výstupní proudy"
order: 39
---

Třída `File` z kapitoly Práce se soubory načítá celý soubor najednou do paměti. Pro velké soubory nebo pro čtení řádek po řádku jsou vhodnější **proudy** (streams) — data čtete nebo zapisujete postupně, bez nutnosti mít vše v paměti najednou.

---

## Princip streamů

Stream je abstrakce nad zdrojem nebo cílem dat — může to být soubor, síťové připojení, paměť. Čtete nebo zapisujete po kouscích.

```
Soubor na disku  ──►  StreamReader  ──►  váš kód
váš kód  ──►  StreamWriter  ──►  Soubor na disku
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

`StreamReader` a `StreamWriter` drží otevřený handle na soubor. Pokud ho nezavřete, soubor zůstane zamčený — jiný program (nebo vy sami) ho nemůže otevřít.

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

Výchozí kódování je UTF-8. Pokud soubor pochází z jiného systému, specifikujte kódování explicitně:

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

---

## Otázky k zamyšlení

1. Co je to proud (stream) a proč je stejná abstrakce použitelná pro soubor, síť i paměť?
2. Proč se `StreamReader`/`StreamWriter` uzavírají do `using`? Co přesně se stane, když zápisový proud nezavřete?
3. Kdy je čtení po řádcích (`ReadLine` v cyklu) lepší než `File.ReadAllLines`? (Nápověda: soubor o velikosti 2 GB.)

---

## Procvičení

### Řešený příklad

**Zadání:** Napište program, který pomocí `StreamReader` projde textový soubor po řádcích a spočítá počet řádků, počet neprázdných řádků a celkový počet znaků — aniž by celý soubor načetl do paměti najednou.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

```csharp
int radky = 0;
int neprazdne = 0;
long znaky = 0;

using (StreamReader ctecka = new StreamReader("vstup.txt"))
{
    string radek;
    while ((radek = ctecka.ReadLine()) != null)
    {
        radky++;
        if (!string.IsNullOrWhiteSpace(radek)) neprazdne++;
        znaky += radek.Length;
    }
}   // zde se proud automaticky zavře – i kdyby uvnitř nastala výjimka

Console.WriteLine($"Řádků celkem:   {radky}");
Console.WriteLine($"Neprázdných:    {neprazdne}");
Console.WriteLine($"Znaků (bez \\n): {znaky}");
```

Dva vzory k zapamatování: idiom `while ((radek = ctecka.ReadLine()) != null)` — čti, dokud proud nevrátí `null` (konec souboru) — a `using`, které zaručí zavření proudu za všech okolností. V paměti je vždy jen jeden řádek, takže program zvládne i gigabajtový soubor.

</details>

### Samostatná cvičení

1. **Základní** — Pomocí `StreamWriter` vytvořte soubor s malou násobilkou (řádky `2 x 3 = 6`), pak ho `StreamReaderem` načtěte a vypište.
2. **Pokročilejší** — Napište "filtr": program čte vstupní soubor po řádcích a do výstupního souboru zapíše jen řádky obsahující zadané slovo (oba proudy současně v jednom `using`).
3. **Bonus (*)** — Změřte (`Stopwatch`) rozdíl mezi zápisem 100 000 řádků po jednom přes `File.AppendAllText` a jedním `StreamWriterem`. Vysvětlete, proč je rozdíl tak velký.