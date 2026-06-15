---
layout: post
title: "Polymorfismus"
order: 45
---

Polymorfismus (z řeckého „mnoho tvarů") umožňuje pracovat s různými typy objektů jednotným způsobem — volat stejnou metodu na různých objektech a nechat každý objekt, ať se zachová po svém. Staví na dědičnosti a přepsání metod z kapitoly 44.

---

## Motivace — bez polymorfismu

Máš seznam zaměstnanců různých typů a chceš spočítat každému mzdu:

```csharp
// ❌ Špatně — kontrola typu ručně
foreach (object zam in seznam)
{
    if (zam is Zamestnanec z)
        Console.WriteLine(z.VypoctiMzdu(160));
    else if (zam is Manazer m)
        Console.WriteLine(m.VypoctiMzdu(160));
    else if (zam is Brigardnik b)
        Console.WriteLine(b.VypoctiMzdu(160));
    // přidáš nový typ → musíš upravit tento kód
}
```

Přidáš nový typ → procházíš celý kód a přidáváš větve. Toto je typický příznak chybějícího polymorfismu.

---

## Polymorfismus v praxi

```csharp
class Zamestnanec
{
    public string Jmeno { get; set; }
    public decimal HodinovaOdmena { get; set; }

    public virtual decimal VypoctiMzdu(int hodiny)
    {
        return HodinovaOdmena * hodiny;
    }
}

class Manazer : Zamestnanec
{
    public decimal Bonus { get; set; }

    public override decimal VypoctiMzdu(int hodiny)
    {
        return base.VypoctiMzdu(hodiny) + Bonus;
    }
}

class Brigardnik : Zamestnanec
{
    public override decimal VypoctiMzdu(int hodiny)
    {
        decimal zaklad = HodinovaOdmena * hodiny;
        return hodiny > 150 ? zaklad * 1.2m : zaklad;  // přesčas +20 %
    }
}
```

```csharp
// ✅ Správně — polymorfismus
List<Zamestnanec> seznam = new List<Zamestnanec>
{
    new Zamestnanec { Jmeno = "Eva", HodinovaOdmena = 200 },
    new Manazer    { Jmeno = "Pavel", HodinovaOdmena = 350, Bonus = 5000 },
    new Brigardnik { Jmeno = "Tomáš", HodinovaOdmena = 150 }
};

foreach (Zamestnanec z in seznam)
{
    Console.WriteLine($"{z.Jmeno}: {z.VypoctiMzdu(160)} Kč");
}
```

Každý objekt se chová podle svého typu — `Manazer.VypoctiMzdu` přidá bonus, `Brigardnik.VypoctiMzdu` počítá přesčas. Kód v `foreach` se nemění, i kdybys přidal desítky nových typů.

---

## `virtual` a `override` — shrnutí pravidel

- Metoda v nadřazené třídě musí být označena `virtual` (nebo `abstract` — viz kapitola 46)
- Přepsání v potomku vyžaduje `override`
- `override` metoda může zavolat původní implementaci přes `base.NázevMetody()`
- Bez `virtual` kompilátor přepsání odmítne — nebo skryje metodu, což není totéž

---

## Proměnná nadřazeného typu

Klíčová vlastnost polymorfismu: proměnná typu `Zamestnanec` může držet objekt libovolného potomka.

```csharp
Zamestnanec z = new Manazer { Jmeno = "Pavel", HodinovaOdmena = 350, Bonus = 5000 };
Console.WriteLine(z.VypoctiMzdu(160));
// Zavolá Manazer.VypoctiMzdu — i když proměnná je typu Zamestnanec
```

C# za běhu zjistí skutečný typ objektu a zavolá správnou metodu. Tomu se říká **pozdní vazba** (late binding).

---

## Shrnutí

| Pojem | Vysvětlení |
|---|---|
| Polymorfismus | Různé třídy reagují na stejnou metodu různě |
| `virtual` | Metoda může být přepsána potomkem |
| `override` | Přepsání `virtual` metody v potomku |
| Pozdní vazba | C# volá správnou metodu za běhu podle skutečného typu objektu |
| Proč ne `if (zam is Manazer)` | Kód je křehký — každý nový typ vyžaduje úpravu |