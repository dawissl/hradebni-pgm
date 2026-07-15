---
layout: post
title: "Objektově orientované programování"
order: 410
---

Doteď jsme psali kód procedurálně — příkazy za sebou, data v proměnných, logika ve funkcích. Tento přístup funguje pro menší programy. Jakmile aplikace roste, procedurální kód se stává nepřehledným a obtížně udržovatelným. Řešením je **objektově orientované programování** (OOP).

---

## Proč OOP vzniklo?

V 60. a 70. letech narůstala složitost softwaru rychleji, než dokázaly zvládnout tehdejší techniky. Programy byly tisíce řádků nečitelného kódu — data a funkce byly promíchané, cokoliv mohlo měnit cokoliv.

OOP přineslo nový způsob organizace kódu: místo volných dat a funkcí sdružujeme **data a logiku, která s nimi pracuje, do jednoho celku** — **objektu**.

---

## Procedurální vs. objektový přístup

Představte si program pro správu zaměstnanců.

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

Data jsou volně plovoucí proměnné. Funkce pracují s daty přes parametry. Přidáte-li druhého zaměstnance, musíte duplikovat proměnné. Pro sto zaměstnanců je kód chaotický.

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

| Princip | Co znamená | Kapitola |
|---|---|---|
| **Zapouzdření** | Data objektu jsou skryta, přístup přes metody | **Zapouzdření** |
| **Dědičnost** | Třída může přebírat vlastnosti jiné třídy | **Dědičnost** |
| **Polymorfismus** | Různé třídy mohou reagovat na stejnou zprávu různě | **Polymorfismus** |
| **Abstrakce** | Skrytí implementace, práce s rozhraním a abstraktními třídami | **Abstraktní třídy a rozhraní** |

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

C# je od základu objektově orientovaný jazyk. Všechno, s čím jsme pracovali — `Console`, `string`, `List<T>` — jsou třídy. Když napíšete `seznam.Add(...)` u `List<T>`, voláte metodu konkrétního objektu (instance); `Console.WriteLine()` je podobný případ, jen jde o statickou metodu, která patří přímo třídě `Console` — ke statickým a instančním členům se dostaneme v kapitole **Třída a objekt**.

V následujících kapitolách si postupně projdeme všechny klíčové koncepty: jak třídy definovat, jak funguje zapouzdření přes properties, jak dědit, jak polymorfismus pracuje s přetěžováním a virtuálními metodami.

---

## Shrnutí

| Pojem | Vysvětlení |
|---|---|
| OOP | Přístup k programování, kde jsou data a logika sdruženy do objektů |
| Procedurální přístup | Data a funkce odděleně — vhodné pro malé programy |
| Třída | Šablona definující strukturu objektu |
| Objekt | Konkrétní instance třídy |
| Čtyři pilíře | Zapouzdření, dědičnost, polymorfismus, abstrakce |
---

## Otázky k zamyšlení

1. Jaký problém OOP řeší? Co se stane s programem "evidence školy" psaným jen pomocí polí a metod, když poroste?
2. Objekt spojuje **data** a **chování** do jednoho celku. Proč je to lepší než data zvlášť (pole) a funkce zvlášť?
3. Vyjmenujte čtyři pilíře OOP a ke každému napište jednu větu, co znamená. Kterému zatím rozumíte nejméně?

---

## Procvičení

### Řešený příklad

**Zadání (teoretické):** Program eviduje studenty pomocí tří polí: `string[] jmena`, `int[] rocniky`, `double[] prumery`, kde index drží záznamy pohromadě. Popište alespoň tři konkrétní problémy tohoto přístupu a vysvětlete, jak je řeší třída `Student`.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

Problémy "paralelních polí":

1. **Křehkost:** nic nevynucuje, že `jmena[3]`, `rocniky[3]` a `prumery[3]` patří k sobě. Jedno zapomenuté přidání nebo smazání v jediném poli a všechna data od toho indexu dál patří jiným lidem.
2. **Neškálovatelnost:** každá nová vlastnost studenta = nové pole + úprava všech metod, které se studenty pracují (přidání, mazání, řazení...).
3. **Rozptýlené chování:** logika "spočítej, zda student prospěl" nemá kde bydlet — je to volná metoda kdesi v programu, která musí dostat tři hodnoty a doufat, že jsou ze stejného indexu.

Třída `Student` řeší všechny tři: data jednoho studenta drží **pohromadě v jednom objektu** (nelze je rozpojit), nová vlastnost je jeden řádek ve třídě, a chování (`Prospel()`) bydlí přímo u dat, se kterými pracuje. Evidence je pak jediný `List<Student>` — přidání a mazání je vždy atomické.

</details>

### Samostatná cvičení

1. **Základní** — Vyberte si tři objekty z reálného světa (např. kniha, bankovní účet, semafor) a u každého vypište jeho data (vlastnosti) a chování (metody).
2. **Pokročilejší** — Najděte ve svém starším programu místo, kde "paralelně" držíte související data, a navrhněte pro ně třídu (jen návrh: název, vlastnosti, metody).
3. **Bonus (*)** — Zamyslete se: `string`, `List` i `Random` jsou třídy, které celou dobu používáte. U každé určete, jaká data asi drží uvnitř a jaké chování nabízí navenek.