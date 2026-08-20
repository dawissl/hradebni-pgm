---
layout: post
title: "Pokročilé komponenty"
order: 290
---

Předchozí kapitola pokryla základní komponenty pro vstup a výstup dat. Tato kapitola rozšiřuje paletu o komponenty pro strukturování aplikace, navigaci a zobrazení komplexnějších dat.

---

## MenuStrip — hlavní nabídka

`MenuStrip` přidá do okna standardní lištu s nabídkami (Soubor, Úpravy, Nápověda…).

**Přidání v Designeru:** přetáhněte `MenuStrip` z Toolboxu na formulář — ukotví se automaticky nahoře. Klikáním přímo do lišty přidáváte položky nabídky.

![MenuStrip v Designeru — lišta s nabídkami Soubor, Úpravy, Nápověda a rozevřenými podmenu](../assets/menustrip-designer.png)

Obsluha kliknutí na položku menu:

```csharp
private void novyToolStripMenuItem_Click(object sender, EventArgs e)
{
    // akce pro Soubor → Nový
    textBoxObsah.Clear();
}

private void ukoncitToolStripMenuItem_Click(object sender, EventArgs e)
{
    Application.Exit();
}
```

### StatusStrip a ToolStrip

`StatusStrip` je lišta ve spodní části okna pro stavové informace (počet záznamů, aktuální stav…).

`ToolStrip` je lišta s ikonami pod MenuStripem — rychlý přístup k nejčastějším akcím.

```csharp
// Aktualizace stavové lišty
toolStripStatusLabel1.Text = $"Načteno {pocet} záznamů";
```

---

## Panel a GroupBox — organizace obsahu

`Panel` je kontejner bez viditelného rámečku (na rozdíl od `GroupBoxu`) — seskupuje komponenty a umožňuje je zobrazovat/skrývat najednou.

`GroupBox` je viditelný rámeček s nadpisem, vizuálně odděluje skupinu příbuzných prvků.

```csharp
// Zobrazit/skrýt celou sekci najednou
panelPrihlaseni.Visible = false;
panelHlavni.Visible = true;
```

![Formulář se dvěma GroupBoxy — "Osobní údaje" a "Kontakt" — každý obsahuje popisky a textová pole](../assets/groupbox-ukazka.png)

---

## TabControl — záložkové rozhraní

`TabControl` rozděluje obsah do záložek — vhodné pro formuláře s mnoha sekci.

**Přidání záložek:** v Properties klikněte na `TabPages` → `...` → přidávejte stránky.

Každá záložka (`TabPage`) je samostatný kontejner — vkládáte do ní komponenty jako do formuláře.

```csharp
// Přepnout na konkrétní záložku
tabControl1.SelectedIndex = 1;

// Zjistit aktuální záložku
if (tabControl1.SelectedTab.Text == "Kontakt")
{
    // ...
}
```

<!-- TODO: screenshot - TabControl s otevřeným editorem TabPages (přidávání záložek) -->

---

## Timer — opakované akce

`Timer` je neviditelná komponenta, která v pravidelných intervalech vyvolává událost `Tick`. Neblokuje uživatelské rozhraní.

| Vlastnost | Popis |
|---|---|
| `Interval` | Čas mezi tiky v milisekundách (1000 = 1 sekunda) |
| `Enabled` | `true` = timer běží, `false` = zastaven |

```csharp
// Nastavení v kódu (nebo v Designeru přes Properties)
timer1.Interval = 1000;
timer1.Start();

private void timer1_Tick(object sender, EventArgs e)
{
    labelCas.Text = DateTime.Now.ToString("HH:mm:ss");
}
```

> 💡 `timer1.Start()` je totéž jako `timer1.Enabled = true`. Pro zastavení: `timer1.Stop()`.

<!-- TODO: screenshot - Timer jako neviditelná komponenta v tray pod formulářem + nastavení Interval v Properties -->

---

## NumericUpDown — číselný vstup

`NumericUpDown` je textové pole speciálně pro čísla — má šipky nahoru/dolů a **nedovolí zadat nic jiného než číslo** v zadaném rozsahu.

```csharp
numericUpDownRok.Minimum = 1450;
numericUpDownRok.Maximum = DateTime.Now.Year;
numericUpDownRok.Value = 2000;

int rok = (int)numericUpDownRok.Value;
```

| Vlastnost | Popis |
|---|---|
| `Minimum` / `Maximum` | Povolený rozsah hodnot |
| `Value` | Aktuální hodnota (typ `decimal`, proto časté přetypování na `int`) |
| `Increment` | O kolik se hodnota změní po jednom kliknutí na šipku |

> 💡 `Value` má typ `decimal` — pro celočíselné použití je potřeba přetypovat: `(int)numericUpDownRok.Value`.

Výhoda oproti `TextBox` s validací: `NumericUpDown` neumožní zadat nesmyslnou hodnotu už na vstupu — uživatel nemůže napsat písmeno ani zadat číslo mimo povolený rozsah.

<!-- TODO: screenshot - NumericUpDown na formuláři s šipkami nahoru/dolů -->

---

## ListView — seznam s více pohledy

`ListView` je mocnější varianta `ListBoxu` — umí zobrazit ikony, více sloupců (detailní pohled) a umožňuje výběr více položek najednou.

```csharp
listView1.View = View.Details;
listView1.Columns.Add("Jméno", 120);
listView1.Columns.Add("Věk", 60);

var item = new ListViewItem("Kamil");
item.SubItems.Add("17");
listView1.Items.Add(item);
```

| Vlastnost | Popis |
|---|---|
| `View` | Způsob zobrazení (`Details`, `LargeIcon`, `List`...) |
| `Columns` | Sloupce v pohledu `Details` |
| `Items` | Kolekce položek (`ListViewItem`) |
| `MultiSelect` | Povolí výběr více položek |

### ListBox vs. ListView vs. DataGridView

| | `ListBox` | `ListView` | `DataGridView` |
|---|---|---|---|
| Sloupce | Ne | Ano (v pohledu Details) | Ano |
| Ikony | Ne | Ano | Ne (bez úprav) |
| Editace buněk | Ne | Ne | Ano |
| Vhodné pro | Jednoduchý seznam | Seznam s ikonami/sloupci bez editace | Tabulková data k editaci |

<!-- TODO: screenshot - ListView v pohledu Details se sloupci Jméno/Věk -->

---

## DataGridView — tabulková data

`DataGridView` zobrazuje data v tabulce s řádky a sloupci — podobně jako Excel.

### Ruční plnění dat

```csharp
// Definice sloupců
dataGridView1.Columns.Add("Jmeno", "Jméno");
dataGridView1.Columns.Add("Vek", "Věk");
dataGridView1.Columns.Add("Mesto", "Město");

// Přidání řádků
dataGridView1.Rows.Add("Jana Nováková", 28, "Praha");
dataGridView1.Rows.Add("Tomáš Dvořák", 34, "Brno");
dataGridView1.Rows.Add("Eva Horáková", 22, "Ostrava");
```

### Napojení na seznam objektů

Nejpohodlnější způsob — přiřaďte `List<T>` jako zdroj dat:

```csharp
List<Zamestnanec> seznam = NactiZamestnance();
dataGridView1.DataSource = seznam;
```

DataGridView automaticky vytvoří sloupec pro každou veřejnou property třídy `Zamestnanec`.

<!-- TODO: screenshot - DataGridView s daty napojenými přes DataSource, automaticky vytvořené sloupce -->

### Čtení vybraného řádku

```csharp
private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
{
    if (e.RowIndex < 0) return;  // klik na záhlaví

    string jmeno = dataGridView1.Rows[e.RowIndex].Cells["Jmeno"].Value.ToString();
    labelVybrano.Text = $"Vybráno: {jmeno}";
}
```

---

## Shrnutí

| Komponenta | Použití |
|---|---|
| `MenuStrip` | Hlavní nabídka (Soubor, Úpravy…) |
| `StatusStrip` | Stavová lišta ve spodní části okna |
| `ToolStrip` | Lišta s ikonami pro rychlé akce |
| `Panel` | Kontejner bez viditelného rámečku pro seskupení komponent |
| `GroupBox` | Viditelný rámeček s nadpisem |
| `TabControl` | Záložkové rozhraní |
| `Timer` | Opakované akce v pravidelných intervalech |
| `NumericUpDown` | Bezpečný číselný vstup v rozsahu |
| `ListView` | Seznam s ikonami nebo více sloupci |
| `DataGridView` | Zobrazení tabulkových dat |
---

## Otázky k zamyšlení

1. Kdy sáhnete po `ListBox`, kdy po `ListView` a kdy po `DataGridView`? Seřaďte je podle "síly" a složitosti.
2. K čemu je `NumericUpDown` a proč je pro číselný vstup bezpečnější než `TextBox`?
3. `TabControl` umožňuje rozdělit formulář na záložky. Kdy je to dobrý nápad a kdy je lepší udělat víc formulářů?

---

## Procvičení

### Řešený příklad

**Zadání:** Vytvořte jednoduchou evidenci knih: `TextBox` pro název, `NumericUpDown` pro rok vydání a `DataGridView`, do kterého tlačítko "Přidat" vloží nový řádek. Přidejte tlačítko "Odebrat vybranou".

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

Sloupce gridu nadefinujeme jednou při startu, řádky pak přidáváme za běhu:

```csharp
public Form1()
{
    InitializeComponent();
    dgvKnihy.Columns.Add("colNazev", "Název knihy");
    dgvKnihy.Columns.Add("colRok", "Rok vydání");
    dgvKnihy.AllowUserToAddRows = false;   // vypne prázdný editační řádek
    nudRok.Minimum = 1450;
    nudRok.Maximum = DateTime.Now.Year;
    nudRok.Value = DateTime.Now.Year;
}

private void btnPridat_Click(object sender, EventArgs e)
{
    if (string.IsNullOrWhiteSpace(txtNazev.Text))
    {
        MessageBox.Show("Zadej název knihy.");
        return;
    }
    dgvKnihy.Rows.Add(txtNazev.Text.Trim(), (int)nudRok.Value);
    txtNazev.Clear();
    txtNazev.Focus();
}

private void btnOdebrat_Click(object sender, EventArgs e)
{
    if (dgvKnihy.CurrentRow != null)
        dgvKnihy.Rows.Remove(dgvKnihy.CurrentRow);
}
```

`NumericUpDown` s nastaveným `Minimum`/`Maximum` zaručuje validní rok bez jediného řádku validace — dobrá komponenta ušetří kód.

</details>

### Samostatná cvičení

1. **Základní** — Přidejte do evidence knih `Label`, který po každé změně ukazuje celkový počet knih v gridu.
2. **Pokročilejší** — Přidejte `ComboBox` s žánry a sloupec Žánr; poté tlačítko "Filtrovat", které skryje řádky jiných žánrů (vlastnost `Visible` řádku).
3. **Bonus (*)** — Vytvořte formulář s `TabControl`em o dvou záložkách: "Zadání" (formulář) a "Přehled" (grid). Data zadaná v první záložce se zobrazují ve druhé.