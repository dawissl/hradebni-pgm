---
layout: post
title: "Dědičnost"
order: 440
---

Dědičnost umožňuje vytvořit novou třídu, která přebírá (dědí) vlastnosti a chování třídy existující — a přidává nebo upravuje to, co potřebuje. Zabraňuje opakování kódu a modeluje vztahy „je typem" mezi třídami.

---

## Vztah „je typem" (is-a)

Dědičnost má smysl, když platí: **odvozená třída je typem nadřazené třídy**.

- `Pes` je typem `Zvire` ✅
- `Auto` je typem `Vozidlo` ✅
- `Manazer` je typem `Zamestnanec` ✅
- `Motor` je typem `Auto` ❌ — motor není auto, je jeho součástí (to je kompozice, viz kapitola **Kompozice vs. dědičnost**)

---

## Definice dědičnosti

```csharp
class Zamestnanec          // nadřazená třída (parent, base)
{
    public string Jmeno { get; set; }
    public decimal HodinovaOdmena { get; set; }

    public void Vypis()
    {
        Console.WriteLine($"{Jmeno}, odmena: {HodinovaOdmena} Kč/h");
    }
}

class Manazer : Zamestnanec    // odvozená třída (child, derived)
{
    public decimal Bonus { get; set; }

    public void VypisSBonus()
    {
        Console.WriteLine($"{Jmeno}, odmena: {HodinovaOdmena} Kč/h + bonus {Bonus} Kč");
    }
}
```

`Manazer` dědí `Jmeno`, `HodinovaOdmena` a metodu `Vypis()` — nemusí je psát znovu.

```csharp
Manazer m = new Manazer();
m.Jmeno = "Pavel Kovář";
m.HodinovaOdmena = 350;
m.Bonus = 5000;
m.Vypis();        // zděděná metoda
m.VypisSBonus();  // vlastní metoda
```

---

## Klíčové slovo `base`

`base` odkazuje na nadřazenou třídu. Nejčastěji se používá v konstruktoru, aby se inicializovala i nadřazená část objektu.

```csharp
class Zamestnanec
{
    public string Jmeno { get; set; }
    public decimal HodinovaOdmena { get; set; }

    public Zamestnanec(string jmeno, decimal odmena)
    {
        Jmeno = jmeno;
        HodinovaOdmena = odmena;
    }
}

class Manazer : Zamestnanec
{
    public decimal Bonus { get; set; }

    public Manazer(string jmeno, decimal odmena, decimal bonus)
        : base(jmeno, odmena)   // zavolá konstruktor Zamestnanec
    {
        Bonus = bonus;
    }
}
```

```csharp
Manazer m = new Manazer("Pavel Kovář", 350, 5000);
```

---

## Přepsání metody — `virtual` a `override`

Odvozená třída může **přepsat** metodu nadřazené třídy. Nadřazená třída musí metodu označit jako `virtual`, odvozená použije `override`.

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
        // base.VypoctiMzdu() zavolá původní výpočet
    }
}
```

---

## Co se dědí a co ne

| Co | Dědí se? |
|---|---|
| `public` atributy a metody | ✅ ano |
| `protected` atributy a metody | ✅ ano |
| `private` atributy a metody | ❌ ne (existují, ale nejsou přístupné) |
| Konstruktory | ❌ ne — konstruktor je nutné volat přes `base()` |

---

## Kdy použít `protected`

`protected` je viditelné v dané třídě i ve všech odvozených třídách — ale ne zvenčí. Hodí se pro atributy, ke kterým mají potomci přistupovat přímo:

```csharp
class Tvar
{
    protected Color barva;  // potomci mohou číst a měnit

    public Tvar(Color b) { barva = b; }
}

class Kruh : Tvar
{
    public Kruh(Color b) : base(b) { }

    public void Vypis() => Console.WriteLine($"Barva: {barva}");  // OK
}
```

---

## Shrnutí

```csharp
class Potomek : Predek
{
    public Potomek(parametry) : base(parametryPredku) { }

    public override void Metoda() { ... }  // přepsání virtual metody
}
```

| Pojem | Vysvětlení |
|---|---|
| `class B : A` | B dědí od A |
| `base` | Odkaz na nadřazenou třídu |
| `virtual` | Metoda může být přepsána v potomku |
| `override` | Přepsání virtual metody v potomku |
| `protected` | Přístupné v třídě i potomcích, ne zvenčí |
---

## Otázky k zamyšlení

1. Dědičnost vyjadřuje vztah "je" (Učitel *je* Zaměstnanec). Vymyslete dvojici tříd, kde by dědičnost byla chybou, protože vztah je ve skutečnosti "má".
2. Co dělá klíčové slovo `base` v konstruktoru potomka a proč je často nutné?
3. Co všechno potomek dědí a co ne? Zdědí i privátní pole? Může k němu přistupovat?

---

## Procvičení

### Řešený příklad

**Zadání:** Podle UML diagramu na obrázku implementujte hierarchii zaměstnanců školy. `VypocitejMzdu()` počítá: učitel = hodiny × sazba, ředitel = základní plat + příplatek, uklízeč = základní plat + 500 Kč za každou budovu. Rozhodněte, zda má být `Zamestnanec` abstraktní.

![UML diagram hierarchie zaměstnanců](../assets/44-uml-zamestnanci.png)

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

`Zamestnanec` má být **abstraktní**: "obecný zaměstnanec" v realitě neexistuje (každý má konkrétní roli) a hlavně neumíme rozumně napsat jeho `VypocitejMzdu`.

> 💡 Klíčové slovo `abstract` si detailně vysvětlíme v kapitole **Abstraktní třídy a rozhraní**. Pro tuto chvíli stačí vědět: `abstract class` znamená "tuto třídu nikdy nevytvoříme přímo, jen přes potomky" a `abstract` metoda znamená "každý potomek ji musí implementovat sám — předek jí nedává žádné tělo".

```csharp
abstract class Zamestnanec
{
    public string Jmeno { get; set; }
    protected decimal zakladniPlat;

    public Zamestnanec(string jmeno, decimal zakladniPlat)
    {
        Jmeno = jmeno;
        this.zakladniPlat = zakladniPlat;
    }

    public abstract decimal VypocitejMzdu();

    public string Predstav() => $"{Jmeno} ({GetType().Name}): {VypocitejMzdu()} Kč";
}

class Ucitel : Zamestnanec
{
    private int pocetHodin;
    private decimal sazbaZaHodinu;

    public Ucitel(string jmeno, int hodin, decimal sazba)
        : base(jmeno, 0)          // učitel základní plat nevyužívá
    {
        pocetHodin = hodin;
        sazbaZaHodinu = sazba;
    }

    public override decimal VypocitejMzdu() => pocetHodin * sazbaZaHodinu;
}

class Reditel : Zamestnanec
{
    private decimal priplatekVedeni;

    public Reditel(string jmeno, decimal plat, decimal priplatek)
        : base(jmeno, plat)
    {
        priplatekVedeni = priplatek;
    }

    public override decimal VypocitejMzdu() => zakladniPlat + priplatekVedeni;
}

class Uklizec : Zamestnanec
{
    private int pocetBudov;

    public Uklizec(string jmeno, decimal plat, int budov)
        : base(jmeno, plat)
    {
        pocetBudov = budov;
    }

    public override decimal VypocitejMzdu() => zakladniPlat + pocetBudov * 500;
}
```

Všimněte si `protected` u `zakladniPlat` — potomci k němu přistupovat mohou, okolní svět ne. A `Predstav()` je napsané jednou v předkovi, přesto vypíše správnou mzdu každé role — to už je polymorfismus, kterému se bude věnovat kapitola **Polymorfismus**.

</details>

### Samostatná cvičení

1. **Základní** — Vytvořte hierarchii `Zvire` (jméno, metoda `Zvuk()`) → `Pes`, `Kocka`, `Kachna`, každé s vlastním zvukem. Vytvořte pole zvířat a nechte je "promluvit".
2. **Pokročilejší** — Rozšiřte hierarchii zaměstnanců o `Kucharka` (plat + prémie za počet uvařených obědů) — bez zásahu do existujících tříd. Kolik kódu bylo potřeba? To je hlavní síla dědičnosti.
3. **Bonus (*)** — Vytvořte `List<Zamestnanec>` se všemi rolemi a spočítejte celkové měsíční mzdové náklady školy jediným cyklem.