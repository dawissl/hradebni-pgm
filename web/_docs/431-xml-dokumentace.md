---
layout: post
title: "XML dokumentační komentáře"
order: 431
---

V kapitole **Základy jazyka C#** jsme si řekli, že dobrý kód je čitelný sám o sobě a komentáře vysvětlují *proč*, ne *co*. To platí dovnitř třídy. Jakmile ale třídu nebo metodu **používá někdo jiný** — spolužák, kolega, nebo vy sami za půl roku — potřebujete jiný druh komentáře: takový, který se propíše do IntelliSense a dá se z něj vygenerovat dokumentace. K tomu slouží **XML dokumentační komentáře**.

---

## Obyčejný komentář vs. dokumentační komentář

```csharp
// Sečte dvě čísla
int Add(int a, int b) => a + b;
```

Tohle je běžný komentář — Visual Studio ho nikde nezobrazí, když metodu `Add` použijete jinde v kódu. Zkuste ale tři lomítka místo dvou:

```csharp
/// <summary>
/// Sečte dvě čísla a vrátí jejich součet.
/// </summary>
int Add(int a, int b) => a + b;
```

Teď, když napíšete `Add(` kdekoli v projektu, Visual Studio zobrazí tooltip s tímto textem — přesně jako u vestavěných metod, jejichž nápovědu jste už stokrát viděli u `Console.WriteLine` nebo `Math.Sqrt`.

> 💡 Napovídací zkratka: napište `///` na řádek nad metodu nebo třídu a Visual Studio vám automaticky vygeneruje kostru se všemi správnými tagy podle parametrů metody.

---

## Nejdůležitější tagy

### `<summary>` — co metoda dělá

Povinný základ každého dokumentačního komentáře — jedna až dvě věty shrnující účel.

```csharp
/// <summary>
/// Ověří, zda je zadaný rok přestupný.
/// </summary>
bool JePrestupny(int rok) { /* ... */ return false; }
```

### `<param>` — popis parametru

Jeden tag pro každý parametr metody, se jménem parametru v atributu `name`.

```csharp
/// <summary>
/// Vypočítá obsah obdélníku.
/// </summary>
/// <param name="sirka">Šířka obdélníku v metrech.</param>
/// <param name="vyska">Výška obdélníku v metrech.</param>
double Obsah(double sirka, double vyska) => sirka * vyska;
```

### `<returns>` — co metoda vrací

```csharp
/// <summary>
/// Vypočítá obsah obdélníku.
/// </summary>
/// <param name="sirka">Šířka obdélníku v metrech.</param>
/// <param name="vyska">Výška obdélníku v metrech.</param>
/// <returns>Obsah obdélníku ve čtverečních metrech.</returns>
double Obsah(double sirka, double vyska) => sirka * vyska;
```

Jakmile teď na tuto metodu najedete myší kdekoli v kódu, IntelliSense zobrazí celý popis včetně obou parametrů a návratové hodnoty — bez nutnosti otevírat definici metody.

### `<exception>` — jaké výjimky metoda může vyhodit

Hodí se u metod, které za určitých okolností vyhazují výjimku — student čtoucí dokumentaci se dozví, na co si dát pozor, aniž by musel číst tělo metody.

```csharp
/// <summary>
/// Vydělí dvě čísla.
/// </summary>
/// <param name="a">Dělenec.</param>
/// <param name="b">Dělitel.</param>
/// <returns>Podíl <paramref name="a"/> a <paramref name="b"/>.</returns>
/// <exception cref="DivideByZeroException">Pokud je <paramref name="b"/> nula.</exception>
double Vydel(double a, double b)
{
    if (b == 0)
        throw new DivideByZeroException("Dělitel nesmí být nula.");
    return a / b;
}
```

`<paramref name="..."/>` odkazuje na parametr metody přímo v textu — IntelliSense a generovaná dokumentace ho zvýrazní jako kód.

---

## Dokumentace třídy

Stejné tagy fungují i nad třídou nebo rozhraním:

```csharp
/// <summary>
/// Reprezentuje bankovní účet s možností vkladu a výběru.
/// </summary>
class BankovniUcet
{
    /// <summary>Jméno vlastníka účtu.</summary>
    public string Vlastnik { get; set; }

    /// <summary>
    /// Vloží částku na účet.
    /// </summary>
    /// <param name="castka">Vkládaná částka, musí být kladná.</param>
    public void Vlozit(decimal castka) { /* ... */ }
}
```

> 💡 Dokumentujte hlavně **public** rozhraní třídy — to je přesně ta část, o které jsme mluvili v kapitole **Zapouzdření** jako o "smlouvě" s okolním světem. Privátní pomocné metody dokumentaci většinou nepotřebují; jejich smysl by měl být čitelný z kódu a případně z běžného `//` komentáře.

---

## `<remarks>` a `<see>` — rozšíření a odkazy

`<remarks>` doplňuje `<summary>` o delší vysvětlení, které by v krátkém shrnutí zabíralo příliš místo:

```csharp
/// <summary>Vypočítá faktoriál čísla.</summary>
/// <remarks>
/// Používá rekurzi — pro velká čísla (n > 12) hrozí přetečení typu <see cref="int"/>.
/// Pro bezpečnější variantu zvažte typ <see cref="long"/>.
/// </remarks>
int Factorial(int n) { /* ... */ return 1; }
```

`<see cref="..."/>` vytvoří odkaz na jiný typ nebo člen — v generované dokumentaci je klikatelný, v IntelliSense zvýrazněný jako kód.

---

## Generování dokumentace ze souborů

Komentáře `///` nejsou samoúčelné — dají se z celého projektu automaticky vyexportovat do XML souboru, který popisuje veškeré veřejné API. Ve Visual Studiu: **Vlastnosti projektu → Build → Output → zaškrtnout "Generate a file containing API documentation"** (nebo v `.csproj` ručně `<GenerateDocumentationFile>true</GenerateDocumentationFile>`).

Výsledný `.xml` soubor sám o sobě nevypadá hezky — je to strojově čitelný podklad, ze kterého nástroje jako DocFX nebo Sandcastle sestaví skutečné webové stránky s dokumentací. Pro školní projekty se s tím obvykle nesetkáte, ale je dobré vědět, že přesně odtud pochází dokumentace ke `List<T>` nebo `Console`, kterou vidíte na [learn.microsoft.com](https://learn.microsoft.com/dotnet/api/).

---

## Shrnutí

| Tag | K čemu slouží |
|---|---|
| `///` | Zahájí dokumentační komentář (na rozdíl od `//`) |
| `<summary>` | Krátký popis třídy/metody |
| `<param name="...">` | Popis jednoho parametru |
| `<returns>` | Popis návratové hodnoty |
| `<exception cref="...">` | Jaké výjimky metoda může vyhodit a za jakých podmínek |
| `<remarks>` | Delší doplňující vysvětlení |
| `<see cref="...">` / `<paramref name="...">` | Odkaz na typ / na parametr metody |

---

## Otázky k zamyšlení

1. Čím se liší běžný komentář (`//`) od dokumentačního komentáře (`///`)? Kde se projeví ten druhý, a kde první ne?
2. Proč dává smysl dokumentovat hlavně `public` metody a properties, a ne každou privátní pomocnou metodu?
3. Když nad metodou napíšete `///` ve Visual Studiu, editor vygeneruje kostru se `<param>` tagy automaticky. Odkud ví, kolik jich má být a jak se parametry jmenují?

---

## Procvičení

### Řešený příklad

**Zadání:** Doplňte XML dokumentační komentáře (`<summary>`, `<param>`, `<returns>`, `<exception>` kde je to vhodné) k metodě `Teplomer.TeplotaC` ze třídy z kapitoly **Zapouzdření**.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

```csharp
/// <summary>
/// Reprezentuje teplotu a umožňuje bezpečně nastavit hodnotu ve stupních Celsia.
/// </summary>
class Teplomer
{
    private double teplotaC;

    /// <summary>
    /// Teplota ve stupních Celsia. Nastavení hodnoty pod -273.15
    /// (absolutní nula) vyhodí výjimku.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Pokud je nastavovaná hodnota nižší než -273.15.
    /// </exception>
    public double TeplotaC
    {
        get { return teplotaC; }
        set
        {
            if (value < -273.15)
                throw new ArgumentOutOfRangeException(
                    nameof(value), "Teplota nemůže být pod absolutní nulou.");
            teplotaC = value;
        }
    }
}
```

Všimněte si, že se dokumentuje i **property**, ne jen metody — `<exception>` je tu obzvlášť užitečný, protože z pohledu volajícího kódu není z názvu `TeplotaC` vůbec vidět, že nastavení hodnoty může spadnout.

</details>

### Samostatná cvičení

1. **Základní** — Doplňte XML dokumentaci ke třídě `Kniha` (název, autor, počet stran) z kapitoly **Třída a objekt** — zdokumentujte konstruktor i metodu `Predstav()`.
2. **Pokročilejší** — Vezměte třídu `BankovniUcet` z kapitoly **Zapouzdření** a zdokumentujte celé její veřejné rozhraní, včetně `<exception>` u metod `Vlozit`/`Vybrat`. Najeďte pak myší na volání těchto metod v kódu — objeví se váš text?
3. **Bonus (*)** — Zapněte ve vlastnostech projektu generování XML dokumentačního souboru a najděte ho v `bin` složce po sestavení projektu. Otevřete ho v textovém editoru — poznáváte v něm své `<summary>` a `<param>` tagy?
