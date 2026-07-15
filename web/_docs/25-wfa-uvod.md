---
layout: post
title: "Co je WinForms"
order: 250
---

V minulé kapitole jsme si WinForms vyzkoušeli prakticky – vytvořili projekt, spustili prázdné okno a podívali se, jak spolu souvisí `Form1.cs` a `Form1.Designer.cs`. Tato kapitola se vrací o krok zpět a dívá se na WinForms **v širším kontextu**: jako na jednu z technologií pro tvorbu desktopových aplikací, proč ji ve výuce používáme, a jak `partial` třída funguje v C# obecně – ne jen u oken.

> 💡 Pokud potřebujete připomenout praktickou stránku (vytvoření projektu, struktura souborů, designer, Toolbox), vraťte se do kapitoly **Grafické aplikace — WinForms**.

---

## WinForms jako technologie

**Windows Forms** vznikl s první verzí .NET Framework v roce 2002 – je to jedna z **nejstarších** technologií pro GUI v .NET ekosystému. Navzdory svému stáří se nadále vyvíjí (běhá i na moderním .NET 6/8+) a zůstává populární pro:

- interní firemní nástroje a administrační aplikace
- rychlý vývoj jednoduchých desktopových programů
- výuku – princip komponent, vlastností a událostí je jednoduše uchopitelný

### Princip WinForms

WinForms je založen na **vizuálním návrhu**: okno je plátno, na které umisťujete hotové komponenty (tlačítka, textová pole, popisky...) z **Toolboxu**. Každá komponenta má **vlastnosti** (barva, text, velikost) a **události** (klik, změna textu), na které lze reagovat kódem.

Tento princip – komponenty + vlastnosti + události – je společný i pro jiné GUI technologie, byť se liší v detailech a způsobu zápisu.

---

## WinForms vs. WPF

**WPF** (Windows Presentation Foundation) je novější technologie (od .NET Framework 3.0, 2006) pro tvorbu desktopových aplikací ve Windows.

| | WinForms | WPF |
|---|---|---|
| Rok vzniku | 2002 | 2006 |
| Návrh UI | Vizuální designer (drag & drop) | **XAML** – deklarativní značkovací jazyk (podobný HTML) |
| Vykreslování | GDI+ (staré rozhraní Windows) | DirectX – hardwarově akcelerované |
| Vzhled a styly | Omezené – komponenty vypadají "windowsovsky" | Plně přizpůsobitelné (styly, šablony, animace) |
| Škálování na vysokém rozlišení (DPI) | Problematické | Nativně podporováno |
| Datový binding | Základní | Pokročilý (MVVM architektura) |
| Křivka učení | Nižší – vizuální editor, okamžitý výsledek | Vyšší – nutnost naučit se XAML |

### Proč ve škole používáme WinForms?

- **Okamžitá vizuální zpětná vazba** – přetáhnete tlačítko, vidíte ho, kliknete a něco se stane. Žádná abstraktní vrstva mezi návrhem a výsledkem.
- **Soustředění na logiku, ne na syntaxi UI** – cílem výuky je naučit se programovat (proměnné, podmínky, metody, OOP), ne učit se nový jazyk XAML současně s C#.
- **Nižší vstupní bariéra** – první funkční okno s tlačítkem zvládneš za pár minut.

WPF (případně modernější **MAUI** pro multiplatformní aplikace) je vhodný další krok, pokud vás desktopový/mobilní vývoj zaujme – principy komponent a událostí, které se naučíte ve WinForms, se přenesou.

> 💡 Toto srovnání slouží pro orientaci „v širším světě" – v této učebnici pracujeme výhradně s WinForms.

---

## Anatomie WinForms projektu

V kapitole **Grafické aplikace — WinForms** jsme viděli, jak projekt vznikne. Teď se podíváme **hlouběji na to, jak jeho části spolu souvisí** a co se stane, když s nimi manipulujete.

### Tři propojené soubory jednoho okna

| Soubor | Účel |
|---|---|
| `Form1.cs` | Váš kód – konstruktor, obsluha událostí, vlastní metody |
| `Form1.Designer.cs` | Automaticky generovaný kód – deklarace komponent a jejich vlastnosti |
| `Form1.resx` | Zdroje (resources) – obrázky, ikony, lokalizované texty |

### Co se stane, když v designeru přidáte tlačítko?

1. Přetáhnete `Button` z Toolboxu na plochu okna
2. Visual Studio do `Form1.Designer.cs` automaticky zapíše:
   - deklaraci proměnné `private Button button1;`
   - v metodě `InitializeComponent()` nastavení vlastností (`this.button1.Text = "button1"; this.button1.Location = new Point(50, 50); ...`)
   - přidání komponenty do okna (`this.Controls.Add(this.button1);`)
3. Váš `Form1.cs` se **nezmění** – proto v něm můžete mít vlastní kód, aniž by ho designer přepsal

### Co se stane, když `Form1.Designer.cs` smažete nebo poškodíte?

Aplikace se nezkompiluje – `Form1.cs` odkazuje na proměnné (`button1`, `textBox1`...), které jsou deklarované právě v `Form1.Designer.cs`. Bez něj `partial class Form1` „chybí polovina".

> ⚠️ Pokud omylem smažete nebo nevratně poškodíte `.Designer.cs`, nejjednodušší oprava je obvykle **znovu vytvořit komponenty v designeru** – psát ekvivalentní kód ručně je možné, ale zdlouhavé a náchylné na chyby (musíte trefit přesné pořadí inicializace a vlastností).

---

## `partial class` – obecně v C#

V kapitole **Grafické aplikace — WinForms** jsme `partial` představili v kontextu Forms: „třída rozdělená do dvou souborů, aby designer nepřepisoval váš kód". To je **konkrétní použití** obecnějšího jazykového prvku.

### Co `partial` znamená obecně

Klíčové slovo `partial` říká kompilátoru: *"Tato třída je definovaná napříč více soubory – spoj je všechny do jedné."*

```csharp
// Person.cs
partial class Person
{
    public string Name { get; set; }

    public void Greet()
    {
        Console.WriteLine($"Ahoj, jsem {Name}.");
    }
}
```

```csharp
// Person.Generated.cs
partial class Person
{
    public int Id { get; set; }

    public override string ToString() => $"#{Id}: {Name}";
}
```

Z pohledu kódu, který třídu `Person` používá, je to **jedna třída** se všemi členy z obou souborů:

```csharp
Person p = new Person { Name = "Kamil", Id = 1 };
p.Greet();              // Ahoj, jsem Kamil.
Console.WriteLine(p);   // #1: Kamil
```

### Kde se `partial` používá kromě WinForms

- **Generovaný kód obecně** – nejen designer formulářů, ale i nástroje generující kód z databázových modelů, API klientů apod. Generovaná část je v jednom souboru, tvá rozšíření v druhém.
- **Velmi velké třídy** – rozdělení do tematických souborů (např. `Customer.Validation.cs`, `Customer.Persistence.cs`) pro lepší orientaci ve velkém projektu. V malých školních projektech se s tímto důvodem nesetkáš, ale je dobré vědět, že existuje.

### Pravidla

- Všechny části `partial class` musí mít **stejný název třídy** a být ve **stejném namespace**
- Všechny části musí mít **stejný modifikátor přístupu** (`public partial class`, ne jednou `public` a jednou bez modifikátoru)
- `partial` se píše **u každé části** – nejde napsat jen u jedné

```csharp
// ❌ CHYBA – druhá část nemá "partial"
public partial class Foo { ... }
public class Foo { ... }
```

---

## Shrnutí

| Pojem | Vysvětlení |
|---|---|
| WinForms | Nejstarší GUI technologie v .NET, vizuální návrh, princip komponent + vlastnosti + události |
| WPF | Novější alternativa – XAML, lepší vzhled a škálování, vyšší vstupní bariéra |
| Proč WinForms ve výuce | Okamžitá vizuální zpětná vazba, soustředění na logiku, ne na nový jazyk UI |
| `Form1.Designer.cs` | Generovaný kód – deklarace a inicializace komponent |
| `partial class` | Jazykový prvek C# umožňující rozdělit třídu do více souborů; ve Formách oddělí váš kód od generovaného |

Pro praktickou práci s projektem (vytvoření, spuštění, designer) se vraťte do kapitoly **Grafické aplikace — WinForms**. V následující kapitole se podíváme na principy UX/UI při navrhování formulářových aplikací.
---

## Otázky k zamyšlení

1. Jakou roli hraje soubor `Form1.Designer.cs` a proč se do něj nemá ručně zasahovat?
2. Co je to vlastnost (property) komponenty a čím se liší nastavení v designeru od nastavení v kódu?
3. Proč má smysl komponenty pojmenovávat (`btnVypocitej`, `txtJmeno`) místo ponechání `button1`, `textBox1`?

---

## Procvičení

### Řešený příklad

**Zadání:** Vytvořte WinForms aplikaci "vizitka": okno s nadpisem, popiskem se svým jménem a tlačítkem "Pozdrav", které po kliknutí zobrazí MessageBox s pozdravem. Popište i nastavení vlastností v designeru.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

**V designeru:**
1. Formuláři nastavte `Text = "Vizitka"` (titulek okna) a rozumnou velikost.
2. Přetáhněte `Label`, pojmenujte `lblJmeno`, nastavte `Text = "Jan Novák"` a zvětšete písmo přes vlastnost `Font`.
3. Přetáhněte `Button`, pojmenujte `btnPozdrav`, nastavte `Text = "Pozdrav"`.
4. Poklepáním na tlačítko vytvoříte obslužnou metodu události `Click`.

**Kód obsluhy:**

```csharp
private void btnPozdrav_Click(object sender, EventArgs e)
{
    MessageBox.Show("Ahoj, rád tě poznávám!", "Pozdrav");
}
```

Poklepání v designeru udělalo dvě věci: vytvořilo metodu ve `Form1.cs` **a** zaregistrovalo ji k události v `Designer.cs` (`btnPozdrav.Click += ...`). Proto smazání metody bez odregistrování způsobí chybu překladu.

</details>

### Samostatná cvičení

1. **Základní** — Rozšiřte vizitku o druhé tlačítko "Změň barvu", které přepne barvu pozadí formuláře (`this.BackColor`).
2. **Pokročilejší** — Přidejte `TextBox` pro jméno návštěvníka; tlačítko Pozdrav pak zdraví jménem z textového pole. Ošetřete prázdný vstup.
3. **Bonus (*)** — Prozkoumejte vlastnosti `Anchor` a `Dock`: nastavte je tak, aby se komponenty rozumně chovaly při změně velikosti okna.