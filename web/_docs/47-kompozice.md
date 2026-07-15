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

Představte si třídu `Pracovnik`, od které chcete odvodit `PracovnikSPravem` (má navíc přístupová práva) a `PracovnikSAutemDobre`:

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
    private readonly Logger logger;  // kompozice — má logger (readonly: nastaví se jen v konstruktoru a dál se nemění)

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
---

## Otázky k zamyšlení

1. Vysvětlete rozdíl vztahů "je" (dědičnost) a "má" (kompozice) na dvojici Auto–Motor a Auto–DopravniProstredek.
2. Proč se říká "preferuj kompozici před dědičností"? Jaké problémy hluboké dědičné hierarchie způsobují?
3. Třída `StackOverflowList : List<int>` zdědí i metody, které se pro zásobník nehodí (`Insert`, `RemoveAt`...). Jak tento problém řeší kompozice?

---

## Procvičení

### Řešený příklad

**Zadání (návrhové):** Modelujete hru: postava může být Válečník nebo Mág a zároveň může umět plavat, létat, ani jedno, nebo obojí. Kolega navrhl dědičnost: `Valecnik`, `Mag`, `PlavajiciValecnik`, `LetajiciValecnik`, `PlavajiciLetajiciValecnik`, `PlavajiciMag`... Vysvětlete, proč tento návrh neškáluje, a navrhněte řešení kompozicí.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

**Problém:** kombinatorická exploze. 2 povolání × 4 kombinace schopností = 8 tříd; přidáním třetí schopnosti (neviditelnost) naroste počet na 16, dalším povoláním na 24... Navíc kód plavání je nakopírovaný v každé "plavající" třídě — oprava chyby znamená opravit ji N-krát.

**Řešení kompozicí:** schopnosti nejsou to, co postava *je*, ale co postava *má*:

```csharp
interface ISchopnost
{
    string Pouzij();
}

class Plavani : ISchopnost
{
    public string Pouzij() => "plave";
}

class Letani : ISchopnost
{
    public string Pouzij() => "letí";
}

class Postava
{
    public string Jmeno { get; }
    public string Povolani { get; }                 // Válečník / Mág
    private List<ISchopnost> schopnosti = new();

    public Postava(string jmeno, string povolani) { Jmeno = jmeno; Povolani = povolani; }

    public void NaucSe(ISchopnost s) => schopnosti.Add(s);
}
```

Libovolná kombinace vzniká skládáním za běhu (`hrdina.NaucSe(new Plavani())`), nová schopnost = jedna nová třída, kód každé schopnosti existuje právě jednou. Dědičnost si šetřete pro skutečné vztahy "je" se sdíleným jádrem — pro kombinovatelné vlastnosti je kompozice téměř vždy lepší.

</details>

### Samostatná cvičení

1. **Základní** — Rozhodněte u dvojic, zda jde o dědičnost, nebo kompozici: Škola–Třída, Ctverec–Tvar, Objednávka–Polozka, Ucitel–Osoba, Auto–Kola.
2. **Pokročilejší** — Navrhněte třídu `Objednavka`, která *má* seznam položek (`Polozka`: název, cena, počet) a metodu `CelkovaCena()`. Implementujte a otestujte.
3. **Bonus (*)** — Implementujte zásobník `MujZasobnik` kompozicí (uvnitř `private List<int>`), navenek jen `Push`, `Pop`, `Peek`, `Count`. Porovnejte s děděním z `List<int>` — co všechno teď uživatel třídy *nemůže* pokazit?