---
layout: post
title: "Třída a objekt"
order: 42
---

Třída je šablona — popis struktury. Objekt je konkrétní věc vytvořená podle té šablony. Tato kapitola ukazuje, jak třídy definovat, jak z nich vytvářet objekty a jak pracovat s jejich daty a chováním.

---

## Definice třídy

```csharp
class Osoba
{
    // atributy (pole)
    public string Jmeno;
    public int Vek;

    // metoda
    public void Pozdrav()
    {
        Console.WriteLine($"Ahoj, jsem {Jmeno} a je mi {Vek} let.");
    }
}
```

Třídu definujeme klíčovým slovem `class`, následuje název (konvence: PascalCase) a tělo ve složených závorkách.

---

## Atributy a metody

**Atributy** (pole, fields) jsou proměnné patřící třídě — uchovávají stav objektu.

**Metody** jsou funkce patřící třídě — definují chování objektu.

```csharp
class Obdelnik
{
    public double Sirka;   // atribut
    public double Vyska;   // atribut

    public double Obsah()  // metoda
    {
        return Sirka * Vyska;
    }

    public double Obvod()  // metoda
    {
        return 2 * (Sirka + Vyska);
    }
}
```

---

## Vytvoření objektu — klíčové slovo `new`

Objekt (instanci třídy) vytvoříme operátorem `new`:

```csharp
Osoba prvni = new Osoba();
prvni.Jmeno = "Tomáš";
prvni.Vek = 25;
prvni.Pozdrav();  // Ahoj, jsem Tomáš a je mi 25 let.

Osoba druha = new Osoba();
druha.Jmeno = "Jana";
druha.Vek = 30;
druha.Pozdrav();  // Ahoj, jsem Jana a je mi 30 let.
```

Každý objekt má vlastní kopii atributů. Změna `prvni.Jmeno` nijak neovlivní `druha.Jmeno`.

---

## Konstruktor

Konstruktor je speciální metoda, která se spustí při vytvoření objektu (`new`). Slouží k inicializaci atributů.

### Implicitní konstruktor

Pokud žádný konstruktor nedefinuješ, C# automaticky vytvoří prázdný (implicitní) konstruktor — ten inicializuje atributy na výchozí hodnoty (`0`, `null`, `false`).

### Vlastní konstruktor

```csharp
class Osoba
{
    public string Jmeno;
    public int Vek;

    // vlastní konstruktor
    public Osoba(string jmeno, int vek)
    {
        Jmeno = jmeno;
        Vek = vek;
    }

    public void Pozdrav()
    {
        Console.WriteLine($"Ahoj, jsem {Jmeno} a je mi {Vek} let.");
    }
}
```

Vytvoření objektu s konstruktorem:

```csharp
Osoba o = new Osoba("Tomáš", 25);
o.Pozdrav();
```

Výhoda: objekt je ihned po vytvoření v platném stavu — není možné zapomenout inicializovat atribut.

> 💡 Pokud definuješ vlastní konstruktor s parametry, implicitní konstruktor **přestane existovat**. Pokud ho stále potřebuješ (bez parametrů), musíš ho dopsat ručně.

### Přetěžování konstruktorů

Třída může mít více konstruktorů s různými parametry:

```csharp
class Osoba
{
    public string Jmeno;
    public int Vek;

    public Osoba(string jmeno)
    {
        Jmeno = jmeno;
        Vek = 0;
    }

    public Osoba(string jmeno, int vek)
    {
        Jmeno = jmeno;
        Vek = vek;
    }
}
```

---

## Properties (vlastnosti)

Properties jsou doporučený způsob přístupu k datům objektu — nabízejí kontrolu nad čtením a zápisem atributů.

```csharp
class Clovek
{
    private int vek;  // soukromé pole (backing field)

    public int Vek    // property
    {
        get { return vek; }
        set
        {
            if (value >= 0 && value <= 150)
                vek = value;
        }
    }
}
```

```csharp
Clovek c = new Clovek();
c.Vek = 25;   // projde přes setter
c.Vek = -5;   // setter to ignoruje
Console.WriteLine(c.Vek);  // 25
```

### Zkrácený zápis (auto-implemented property)

Pokud žádnou logiku v getru/setru nepotřebuješ:

```csharp
public string Jmeno { get; set; }
public int Vek { get; private set; }  // jen pro čtení zvenčí
```

---

## Shrnutí

```csharp
class NazevTridy
{
    // atributy
    public datovyTyp NazevAtributu;

    // konstruktor
    public NazevTridy(parametry)
    {
        // inicializace
    }

    // property
    public datovyTyp NazevProperty { get; set; }

    // metoda
    public navratovyTyp NazevMetody()
    {
        // logika
    }
}

// vytvoření objektu
NazevTridy obj = new NazevTridy(argumenty);
```

| Pojem | Vysvětlení |
|---|---|
| Atribut (pole) | Proměnná patřící třídě, uchovává stav |
| Metoda | Funkce patřící třídě, definuje chování |
| Konstruktor | Spustí se při `new`, inicializuje objekt |
| Property | Řízený přístup k atributu přes get/set |
| `new` | Operátor pro vytvoření instance |