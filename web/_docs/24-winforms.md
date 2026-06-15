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

> 💡 Tomuto modelu se říká **event-driven programming** (programování řízené událostmi). K samotným událostem se dostaneme detailně v kapitole 28 – tahle kapitola je o tom, jak okno a komponenty vůbec vzniknou.

---

## Vytvoření WinForms projektu

1. Ve Visual Studiu klikni na **Vytvořit nový projekt**
2. Vyhledej šablonu **Windows Forms App** a vyber tu s jazykem **C#**
3. Pojmenuj projekt (např. `MojeAplikace`)
4. Klikni **Vytvořit**

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

`Form` reprezentuje jedno **okno** aplikace. Při vytvoření projektu dostaneš automaticky `Form1` – výchozí (a často hlavní) okno.

### `Program.cs`

```csharp
namespace MojeAplikace
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }
    }
}
```

`Application.Run(new Form1())` vytvoří instanci okna `Form1` a spustí **smyčku zpráv** (message loop) – nekonečný cyklus, který čeká na události (kliknutí, stisk klávesy...) a předává je odpovídajícím metodám. Tuto smyčku nikdy nepíšeš ručně – stará se o ni `Application.Run()`.

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

- `: Form` – `Form1` **dědí** od třídy `Form` (k dědičnosti se vrátíme v kapitole 44, zatím stačí: `Form1` *je* okno se vším, co k oknu patří)
- `partial class` – třída je rozdělena do **dvou souborů** (`Form1.cs` a `Form1.Designer.cs`) – víc o tom dále
- `InitializeComponent()` – metoda, která nastaví všechny komponenty okna podle toho, co jsi navrhl v designeru

---

## `partial class` a Designer

Co znamená `public partial class Form1`?

`partial` (částečná) třída umožňuje, aby jedna třída byla **rozdělena do více souborů**. C# při kompilaci oba soubory spojí, jako by šlo o jednu třídu.

| Soubor | Co obsahuje | Kdo ho upravuje |
|---|---|---|
| `Form1.cs` | Tvůj kód – obsluha událostí, logika | **Ty** |
| `Form1.Designer.cs` | Definice komponent (tlačítka, textová pole...), jejich vlastnosti a pozice | **Visual Studio** (designer) |

Tohle rozdělení existuje z jednoho důvodu: když v designeru (vizuálním editoru) přidáš tlačítko nebo upravíš pozici komponenty, Visual Studio přegeneruje `Form1.Designer.cs`. Tvůj kód v `Form1.cs` zůstane nedotčen.

> ⚠️ **`Form1.Designer.cs` neupravuj ručně.** Při další úpravě v designeru by se tvé změny mohly přepsat nebo rozbít. Vlastní kód patří do `Form1.cs`.

### Náhled designeru

Ve Visual Studiu otevřeš okno v **návrhovém zobrazení** (Design view) poklepáním na `Form1.cs` v Solution Exploreru, nebo pravým tlačítkem → "View Designer". Zobrazí se okno, na které lze z **Toolboxu** (postranní panel s komponentami) přetahovat tlačítka, textová pole a další prvky.

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

K Toolboxu, vlastnostem komponent (panel **Properties**) a konkrétním komponentám se podrobně dostaneme v kapitole 27.

---

## Spuštění WinForms aplikace

Stejně jako u konzolové aplikace – `F5` (s debuggerem) nebo `Ctrl+F5` (bez debuggeru). Místo černého okna konzole se otevře **prázdné okno** (`Form1`) – bez komponent zatím nic neumí, ale je to plnohodnotná aplikace.

> 💡 I prázdné okno už umí to, co každé okno Windows – přesouvat se, minimalizovat, maximalizovat, zavřít. To všechno dostáváš "zdarma" díky dědičnosti od `Form`.

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

> 💡 `this` odkazuje na aktuální instanci okna – `Form1`. K `this` a instancím se vrátíme v kapitole o třídách a objektech.

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

V následující kapitole se podíváme na samotný proces návrhu okna a princip UX/UI při tvorbě formulářových aplikací.