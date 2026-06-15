---
layout: post
title: "Kompozice vs. dědičnost"
order: 47
---

Dědičnost není jediný způsob, jak znovu použít kód. **Kompozice** je alternativa, která je v mnoha situacích vhodnější — a zkušení programátoři ji preferují.

---

## „Je typem" vs. „má část"

Rozdíl mezi dědičností a kompozicí lze shrnout dvěma otázkami:

- **Je B typem A?** → dědičnost (`class B : A`)
- **Má B část/součást A?** → kompozice (třída B obsahuje objekt A)

| Vztah | Příklad | Přístup |
|---|---|---|
| Auto *je typem* Vozidla | `class Auto : Vozidlo` | Dědičnost |
| Auto *má* Motor | `class Auto { Motor motor; }` | Kompozice |
| Pes *je typem* Zvířete | `class Pes : Zvire` | Dědičnost |
| Pes *má* Jméno | `class Pes { string jmeno; }` | Kompozice (atribut) |

---

## Příklad — kdy dědičnost selže

Představ si třídu `Pracovnik`, od které chceš odvodit `PracovnikSPravem` (má navíc přístupová práva) a `PracovnikSAuremDobre`:

```csharp
class Pracovnik { ... }
class PracovnikSPravem : Pracovnik { ... }
class PracovnikSAutemDobre : Pracovnik { ... }

// Co ale s pracovníkem, který má oboje?
// class PracovnikSPravemAAutem : ??? C# neumí dědit od dvou tříd
```

Dědičnost to neumí vyřešit. Kompozice ano:

```csharp
class Prava
{
    public bool MaAdminPristup { get; set; }
    public List<string> OpravenesekceE { get; set; } = new();
}

class SluzbeniAuto
{
    public string Znacka { get; set; }
    public int RokVyroby { get; set; }
}

class Pracovnik
{
    public string Jmeno { get; set; }
    public Prava Prava { get; set; }       // má práva (nebo null = nemá)
    public SluzbeniAuto Auto { get; set; } // má auto (nebo null = nemá)
}
```

```csharp
Pracovnik p = new Pracovnik
{
    Jmeno = "Jana",
    Prava = new Prava { MaAdminPristup = true },
    Auto = new SluzbeniAuto { Znacka = "Škoda", RokVyroby = 2022 }
};
```

---

## Refaktoring z dědičnosti na kompozici

**Před refaktoringem:**

```csharp
class Logger
{
    public void Log(string zprava)
    {
        Console.WriteLine($"[LOG] {zprava}");
    }
}

class DatabazeService : Logger   // ❌ DatabazeService "není typem" Loggeru
{
    public void UlozData(string data)
    {
        Log($"Ukládám: {data}");
        // ... uložení
    }
}
```

`DatabazeService` dědí od `Logger`, ale to nedává smysl — databázová služba *není typem* loggeru. Dědičnost se tu použila jen pro pohodlné volání `Log()`.

**Po refaktoringu:**

```csharp
class DatabazeService
{
    private readonly Logger logger;  // kompozice — má logger

    public DatabazeService(Logger logger)
    {
        this.logger = logger;
    }

    public void UlozData(string data)
    {
        logger.Log($"Ukládám: {data}");
        // ... uložení
    }
}
```

```csharp
Logger log = new Logger();
DatabazeService db = new DatabazeService(log);
db.UlozData("testovací data");
```

Výhoda: `Logger` lze snadno vyměnit za jiný (soubor, databáze, síť) bez změny `DatabazeService`.

---

## Kdy použít co

**Dědičnost** — když:
- platí přirozený vztah „je typem"
- chceš sdílet implementaci a polymorfismus dává smysl
- hierarchie je mělká (max. 2–3 úrovně)

**Kompozice** — když:
- vztah je „má část" nebo „používá"
- potřebuješ kombinovat chování z více zdrojů
- chceš větší flexibilitu při výměně součástí

> 💡 Zkušení programátoři se řídí pravidlem: **preferuj kompozici před dědičností**. Dědičnost je silný nástroj, ale snadno vede k křehkým hierarchiím, které je těžko změnit.

---

## Shrnutí

| | Dědičnost | Kompozice |
|---|---|---|
| Vztah | „je typem" | „má část" |
| Syntaxe | `class B : A` | `class B { A a; }` |
| Více zdrojů chování | ❌ jedna třída | ✅ více objektů |
| Flexibilita | Nižší | Vyšší |
| Kdy | Přirozená hierarchie | Skládání chování |