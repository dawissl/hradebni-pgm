---
layout: post
title: "Grafické aplikace — WinForms"
order: 24
---

Doteď naše programy běžely v černém okně konzole – textový vstup, textový výstup. Od této kapitoly se přesouváme k aplikacím s **grafickým uživatelským rozhraním** (GUI) – okny, tlačítky, textovými poli a dalšími prvky, na které uživatel klikne myší.

K tomu použijeme **Windows Forms** (zkráceně **WinForms** nebo **WFA** – Windows Forms Application) – technologii pro tvorbu desktopových aplikací, součást .NET.

---

## Konzole vs. okno

| | Konzolová aplikace | WinForms aplikace |
|---|---|---|
| Vstup | `Console.ReadLine()` – text | Kliknutí, psaní do textových polí |
| Výstup | `Console.WriteLine()` – text | Vykreslené okno s komponentami |
| Tok programu | Sekvenční – řádek po řádku | Řízený **událostmi** (kliknutí, změna textu...) |
| Vzhled | Jednotný (černé okno) | Plně přizpůsobitelný |

### Sekvenční vs. řízený událostmi

Konzolová aplikace běží **shora dolů** – `Main()` se vykoná, program skončí.

```csharp
Console.Write("Zadej jméno: ");
string name = Console.ReadLine();
Console.WriteLine($"Ahoj, {name}!");
// konec programu
```

WinForms aplikace po spuštění **zobrazí okno a čeká**. Nic se neděje, dokud uživatel neudělá nějakou akci – klikne na tlačítko, napíše text, zavře okno. Každá taková akce je **událost** (event), na kterou program reaguje.

```csharp
// zjednodušeně - kód, který se provede AŽ PO kliknutí na tlačítko
private void buttonGreet_Click(object sender, EventArgs e)
{
    string name = textBoxName.Text;
    labelGreeting.Text = $"Ahoj, {name}!";
}
```

> 💡 Tomuto modelu se říká **event-driven programming** (programování řízené událostmi). K samotným událostem se dostaneme detailně v kapitole **Události** – tahle kapitola je o tom, jak okno a komponenty vůbec vzniknou.

---

## Vytvoření WinForms projektu

1. Ve Visual Studiu klikněte na **Vytvořit nový projekt**
2. Vyhledejte šablonu **Windows Forms App** a vyberte tu s jazykem **C#**
3. Pojmenujte projekt (např. `MojeAplikace`)
4. Klikněte **Vytvořit**

Visual Studio vygeneruje novou strukturu souborů – víc než u konzolové aplikace.

```
MojeAplikace/
├── MojeAplikace.sln
└── MojeAplikace/
    ├── Form1.cs           ← kód okna (logika, obsluha událostí)
    ├── Form1.Designer.cs  ← kód generovaný designerem (UI komponenty)
    ├── Form1.resx         ← zdroje (texty, ikony, obrázky)
    └── Program.cs         ← vstupní bod aplikace
```

---

## Co je `Form`?

`Form` reprezentuje jedno **okno** aplikace. Při vytvoření projektu dostanete automaticky `Form1` – výchozí (a často hlavní) okno.

### `Program.cs`

```csharp
namespace MojeAplikace
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
```

`ApplicationConfiguration.Initialize()` nastaví výchozí konfiguraci aplikace (např. podporu vysokého rozlišení DPI a výchozí písmo) – Visual Studio tento řádek vygeneruje automaticky, není potřeba mu rozumět do detailu.

`Application.Run(new Form1())` vytvoří instanci okna `Form1` a spustí **smyčku zpráv** (message loop) – nekonečný cyklus, který čeká na události (kliknutí, stisk klávesy...) a předává je odpovídajícím metodám. Tuto smyčku nikdy nepíšete ručně – stará se o ni `Application.Run()`.

### `Form1.cs`

```csharp
namespace MojeAplikace
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
}
```

Důležité prvky:

- `: Form` – `Form1` **dědí** od třídy `Form` (k dědičnosti se vrátíme v kapitole **Dědičnost**, zatím stačí: `Form1` *je* okno se vším, co k oknu patří)
- `partial class` – třída je rozdělena do **dvou souborů** (`Form1.cs` a `Form1.Designer.cs`) – víc o tom dále
- `InitializeComponent()` – metoda, která nastaví všechny komponenty okna podle toho, co jste navrhli v designeru

---

## `partial class` a Designer

Co znamená `public partial class Form1`?

`partial` (částečná) třída umožňuje, aby jedna třída byla **rozdělena do více souborů**. C# při kompilaci oba soubory spojí, jako by šlo o jednu třídu.

| Soubor | Co obsahuje | Kdo ho upravuje |
|---|---|---|
| `Form1.cs` | Váš kód – obsluha událostí, logika | **Vy** |
| `Form1.Designer.cs` | Definice komponent (tlačítka, textová pole...), jejich vlastnosti a pozice | **Visual Studio** (designer) |

Tohle rozdělení existuje z jednoho důvodu: když v designeru (vizuálním editoru) přidáte tlačítko nebo upravíte pozici komponenty, Visual Studio přegeneruje `Form1.Designer.cs`. Váš kód v `Form1.cs` zůstane nedotčen.

> ⚠️ **`Form1.Designer.cs` neupravujte ručně.** Při další úpravě v designeru by se vaše změny mohly přepsat nebo rozbít. Vlastní kód patří do `Form1.cs`.

### Náhled designeru

Ve Visual Studiu otevřete okno v **návrhovém zobrazení** (Design view) poklepáním na `Form1.cs` v Solution Exploreru, nebo pravým tlačítkem → "View Designer". Zobrazí se okno, na které lze z **Toolboxu** (postranní panel s komponentami) přetahovat tlačítka, textová pole a další prvky.

```
┌─────────────────────────────┐
│  Form1                  _ □ ✕│
├─────────────────────────────┤
│                               │
│   [Toolbox]    [plocha okna] │
│   - Button                   │
│   - TextBox                  │
│   - Label                    │
│   ...                        │
│                               │
└─────────────────────────────┘
```

K Toolboxu, vlastnostem komponent (panel **Properties**) a konkrétním komponentám se podrobně dostaneme v kapitole **Základní komponenty**.

---

## Spuštění WinForms aplikace

Stejně jako u konzolové aplikace – `F5` (s debuggerem) nebo `Ctrl+F5` (bez debuggeru). Místo černého okna konzole se otevře **prázdné okno** (`Form1`) – bez komponent zatím nic neumí, ale je to plnohodnotná aplikace.

> 💡 I prázdné okno už umí to, co každé okno Windows – přesouvat se, minimalizovat, maximalizovat, zavřít. To všechno dostáváte "zdarma" díky dědičnosti od `Form`.

---

## Vlastnosti okna

Okno samo má vlastnosti, které lze nastavit v panelu **Properties** (při označení okna v designeru) nebo v kódu:

```csharp
public Form1()
{
    InitializeComponent();

    this.Text = "Moje první aplikace";  // titulek okna
    this.Width = 600;                    // šířka v pixelech
    this.Height = 400;                   // výška v pixelech
    this.StartPosition = FormStartPosition.CenterScreen; // okno se otevře na střed obrazovky
}
```

> 💡 `this` odkazuje na aktuální instanci okna – `Form1`. K `this` a instancím se vrátíme v kapitole **Třída a objekt**.

---

## Shrnutí

| Pojem | Vysvětlení |
|---|---|
| WinForms / WFA | Technologie pro desktopové aplikace s grafickým rozhraním |
| Event-driven | Program reaguje na události (klik, psaní) místo běhu shora dolů |
| `Form` | Třída reprezentující okno aplikace |
| `Application.Run()` | Spustí smyčku zpráv – čeká na události |
| `partial class` | Třída rozdělená do více souborů (`.cs` + `.Designer.cs`) |
| `Form1.Designer.cs` | Generuje Visual Studio – neupravovat ručně |
| `InitializeComponent()` | Nastaví komponenty podle návrhu v designeru |
| Designer / Toolbox | Vizuální editor okna a panel s komponentami |

V následující kapitole se podíváme na WinForms v širším kontextu – jako na jednu z technologií pro tvorbu desktopových aplikací – a na to, jak `partial` třída funguje obecně v C#. Principy UX/UI, tedy jak formulář navrhnout, aby byl pro uživatele příjemný, přijde v následné kapitole.
---

## Otázky k zamyšlení

1. Čím se zásadně liší běh konzolové aplikace od aplikace s grafickým rozhraním? (Nápověda: kdo řídí pořadí akcí?)
2. Co znamená, že GUI aplikace je "řízená událostmi" (event-driven)?
3. Proč logika programu (výpočty) nemá být napsaná přímo v obslužných metodách tlačítek?

---

## Procvičení

### Řešený příklad

**Zadání (teoretické):** Porovnejte průběh stejné úlohy ("sečti dvě čísla") v konzolové aplikaci a ve WinForms. Popište, kdo v kterém případě určuje pořadí kroků a co dělá program, když uživatel zrovna nic nedělá.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

**Konzole:** program diktuje scénář. Kód běží shora dolů: vyzve k zadání prvního čísla → čeká (`ReadLine` blokuje) → vyzve k druhému → spočítá → vypíše → skončí. Uživatel jen odpovídá na otázky v pořadí, které určil programátor.

**WinForms:** scénář diktuje uživatel. Po spuštění se zobrazí okno se dvěma textovými poli a tlačítkem a program vstoupí do **smyčky zpráv** — nečinně čeká, dokud nenastane událost. Uživatel může vyplnit pole v libovolném pořadí, okno přesunout, zavřít... Teprve kliknutí na tlačítko vyvolá událost `Click` a spustí náš kód, který přečte hodnoty, sečte je a zobrazí výsledek. Pak program zase čeká.

Shrnutí: v konzoli se **program ptá uživatele**, ve WinForms **uživatel říká programu**, co a kdy se má stát.

</details>

### Samostatná cvičení

1. **Základní** — Vyjmenujte pět událostí, které mohou v okně aplikace nastat (kromě kliknutí na tlačítko), a kdy by se hodilo na ně reagovat.
2. **Pokročilejší** — Vezměte svůj návrh úkolníčku z předchozí kapitoly a rozmyslete, jak by vypadal jako okno: jaké komponenty, jaké události. Nakreslete si okno na papír.
3. **Bonus (*)** — Zjistěte, co dělá `Application.Run(new Form1());` v souboru Program.cs a co by se stalo, kdyby tam nebylo.