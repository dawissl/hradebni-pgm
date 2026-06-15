---
layout: post
title: "Objektově orientované programování"
order: 41
---

Doteď jsme psali kód procedurálně — příkazy za sebou, data v proměnných, logika ve funkcích. Tento přístup funguje pro menší programy. Jakmile aplikace roste, procedurální kód se stává nepřehledným a obtížně udržovatelným. Řešením je **objektově orientované programování** (OOP).

---

## Proč OOP vzniklo?

V 60. a 70. letech narůstala složitost softwaru rychleji, než dokázaly zvládnout tehdejší techniky. Programy byly tisíce řádků nečitelného kódu — data a funkce byly promíchané, cokoliv mohlo měnit cokoliv.

OOP přineslo nový způsob organizace kódu: místo volných dat a funkcí sdružujeme **data a logiku, která s nimi pracuje, do jednoho celku** — **objektu**.

---

## Procedurální vs. objektový přístup

Představ si program pro správu zaměstnanců.

**Procedurálně:**

```csharp
string jmeno = "Jana Nováková";
int vek = 32;
decimal plat = 45000;

void ZobrazZamestnance(string j, int v, decimal p)
{
    Console.WriteLine($"{j}, {v} let, plat: {p} Kč");
}

void ZvysPlat(ref decimal p, decimal castka)
{
    p += castka;
}
```

Data jsou volně plovoucí proměnné. Funkce pracují s daty přes parametry. Přidáš-li druhého zaměstnance, musíš duplikovat proměnné. Pro sto zaměstnanců je kód chaotický.

**Objektově:**

```csharp
class Zamestnanec
{
    public string Jmeno;
    public int Vek;
    public decimal Plat;

    public void Zobraz()
    {
        Console.WriteLine($"{Jmeno}, {Vek} let, plat: {Plat} Kč");
    }

    public void ZvysPlat(decimal castka)
    {
        Plat += castka;
    }
}
```

Data a metody, které s nimi pracují, jsou pohromadě v jedné třídě. Pro sto zaměstnanců stačí sto objektů — struktura zůstane stejná.

---

## Čtyři pilíře OOP

OOP stojí na čtyřech základních principech:

| Princip | Co znamená | Kde v knize |
|---|---|---|
| **Zapouzdření** | Data objektu jsou skryta, přístup přes metody | Kapitola 43 |
| **Dědičnost** | Třída může přebírat vlastnosti jiné třídy | Kapitola 44 |
| **Polymorfismus** | Různé třídy mohou reagovat na stejnou zprávu různě | Kapitola 45 |
| **Abstrakce** | Skrytí implementace, práce s rozhraním | Kapitola 46 |

---

## Základní pojmy

**Třída** je šablona — popis toho, jaká data a metody bude mít každý objekt tohoto typu.

**Objekt** je konkrétní instance třídy — „vyrobená" podle šablony s vlastními hodnotami.

```csharp
// Třída = šablona
class Auto
{
    public string Znacka;
    public int RokVyroby;
}

// Objekty = instance
Auto prvni = new Auto();
prvni.Znacka = "Škoda";
prvni.RokVyroby = 2020;

Auto druhe = new Auto();
druhe.Znacka = "BMW";
druhe.RokVyroby = 2022;
```

Obě auta jsou instance třídy `Auto` — sdílejí strukturu, ale mají vlastní data.

---

## OOP v kontextu C#

C# je od základu objektově orientovaný jazyk. Všechno, s čím jsme pracovali — `Console`, `string`, `List<T>` — jsou třídy. Vždy, když napíšeš `Console.WriteLine()`, voláš metodu objektu.

V kapitolách 42–47 si postupně projdeme všechny klíčové koncepty: jak třídy definovat, jak funguje zapouzdření přes properties, jak dědit, jak polymorfismus pracuje s přetěžováním a virtuálními metodami.

---

## Shrnutí

| Pojem | Vysvětlení |
|---|---|
| OOP | Přístup k programování, kde jsou data a logika sdruženy do objektů |
| Procedurální přístup | Data a funkce odděleně — vhodné pro malé programy |
| Třída | Šablona definující strukturu objektu |
| Objekt | Konkrétní instance třídy |
| Čtyři pilíře | Zapouzdření, dědičnost, polymorfismus, abstrakce |