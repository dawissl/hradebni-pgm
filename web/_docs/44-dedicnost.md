---
layout: post
title: "Dědičnost"
order: 44
---

Dědičnost umožňuje vytvořit novou třídu, která přebírá (dědí) vlastnosti a chování třídy existující — a přidává nebo upravuje to, co potřebuje. Zabraňuje opakování kódu a modeluje vztahy „je typem" mezi třídami.

---

## Vztah „je typem" (is-a)

Dědičnost má smysl, když platí: **odvozená třída je typem nadřazené třídy**.

- `Pes` je typem `Zvire` ✅
- `Auto` je typem `Vozidlo` ✅
- `Manazer` je typem `Zamestnanec` ✅
- `Motor` je typem `Auto` ❌ — motor není auto, je jeho součástí (to je kompozice, kapitola 47)

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