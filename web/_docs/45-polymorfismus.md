---
layout: post
title: "Polymorfismus"
order: 450
---

Polymorfismus (z řeckého „mnoho tvarů") umožňuje pracovat s různými typy objektů jednotným způsobem — volat stejnou metodu na různých objektech a nechat každý objekt, ať se zachová po svém. Staví na dědičnosti a přepsání metod z kapitoly **Dědičnost**.

---

## Motivace — bez polymorfismu

Máte seznam zaměstnanců různých typů a chcete spočítat každému mzdu:

```csharp
// ❌ Špatně — kontrola typu ručně
foreach (object zam in seznam)
{
    // pozor: pořadí musí být od nejspecifičtějšího typu k nejobecnějšímu –
    // Manazer i Brigardnik JSOU Zamestnanec, takže obecná větev musí být poslední
    if (zam is Manazer m)
        Console.WriteLine(m.VypoctiMzdu(160));
    else if (zam is Brigardnik b)
        Console.WriteLine(b.VypoctiMzdu(160));
    else if (zam is Zamestnanec z)
        Console.WriteLine(z.VypoctiMzdu(160));
    // přidáte nový typ → musíte upravit tento kód
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

Každý objekt se chová podle svého typu — `Manazer.VypoctiMzdu` přidá bonus, `Brigardnik.VypoctiMzdu` počítá přesčas. Kód v `foreach` se nemění, i kdybyste přidali desítky nových typů.

---

## `virtual` a `override` — shrnutí pravidel

- Metoda v nadřazené třídě musí být označena `virtual` (nebo `abstract` — viz kapitola **Abstraktní třídy a rozhraní**)
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
---

## Otázky k zamyšlení

1. Vysvětlete větu: "proměnná typu předka může držet objekt potomka". Proč je to užitečné?
2. Jaký je rozdíl mezi `virtual`/`override` a "zastíněním" metody přes `new`? Která varianta se chová polymorfně?
3. O tom, která `override` metoda se zavolá, se rozhoduje až za běhu. Proč to nemůže rozhodnout překladač?

---

## Procvičení

### Řešený příklad

**Zadání:** Bez spouštění určete, co vypíše následující program, a vysvětlete proč:

```csharp
class Tvar
{
    public virtual string Popis() => "obecný tvar";
}

class Kruh : Tvar
{
    public override string Popis() => "kruh";
}

class Ctverec : Tvar
{
    public string Popis() => "čtverec";   // pozor: chybí override!
}

class Program
{
    static void Main()
    {
        Tvar[] tvary = { new Kruh(), new Ctverec(), new Tvar() };
        foreach (Tvar t in tvary)
            Console.WriteLine(t.Popis());
    }
}
```

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

Výstup:

```
kruh
obecný tvar
obecný tvar
```

- `Kruh` metodu **přepisuje** (`override`) → volání přes proměnnou typu `Tvar` se za běhu "prováže" na verzi kruhu. Polymorfismus funguje.
- `Ctverec` metodu jen **zastínil** — bez `override` vznikla nová, nesouvisející metoda (kompilátor na to vypíše warning a doporučí `new`). Protože proměnná v cyklu je typu `Tvar`, zavolá se verze předka → "obecný tvar".
- Třetí prvek je přímo `Tvar`, takže "obecný tvar" je správně.

Poučení: polymorfismus vyžaduje **pár `virtual` + `override`**. Warningy překladače nejsou dekorace — tenhle konkrétní vám právě zachránil hodinu ladění.

</details>

### Samostatná cvičení

1. **Základní** — Doplňte do hierarchie `Zvire` z kapitoly **Dědičnost** `virtual`/`override` u metody `Zvuk()` a ověřte polymorfní chování přes pole `Zvire[]`.
2. **Pokročilejší** — Vytvořte třídy `Tvar` → `Kruh`, `Obdelnik`, `Trojuhelnik` s metodou `Obsah()`. Napište metodu `NejvetsiTvar(List<Tvar>)`, která najde tvar s největším obsahem — jediná implementace pro všechny typy.
3. **Bonus (*)** — Přepište u svých tříd metodu `ToString()` (dědí se z `object` a je `virtual`!) a sledujte, jak se změní chování `Console.WriteLine(objekt)`.