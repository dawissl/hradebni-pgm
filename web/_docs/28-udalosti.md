---
layout: post
title: "Události a event handlery"
order: 28
---

WinForms aplikace nefunguje jako konzolový program — nespouští příkazy shora dolů, ale **čeká na akce uživatele**. Kliknutí na tlačítko, změna textu, stisk klávesy — to vše jsou **události** (events), na které program reaguje.

---

## Jak události fungují

Každá komponenta (Button, TextBox, Form…) má sadu událostí, které může vyvolat. Když uživatel provede akci, komponenta „vyvolá" příslušnou událost — a pokud je k ní připojená obslužná metoda, ta se spustí.

![Schéma: Uživatel klikne na tlačítko → Button vyvolá událost Click → spustí se event handler buttonOK_Click](../assets/udalosti-schema.png)

Obslužná metoda se nazývá **event handler**.

---

## Nejčastější události

| Událost | Komponenta | Kdy se spustí |
|---|---|---|
| `Click` | Button, Label, PictureBox | Kliknutí levým tlačítkem myši |
| `TextChanged` | TextBox, ComboBox | Při každé změně textu |
| `Load` | Form | Při načtení formuláře (před zobrazením) |
| `FormClosing` | Form | Těsně před zavřením okna |
| `KeyDown` | Form, TextBox | Stisk klávesy |
| `KeyPress` | TextBox | Stisk klávesy produkující znak |
| `SelectedIndexChanged` | ComboBox, ListBox | Změna vybrané položky |
| `CheckedChanged` | CheckBox, RadioButton | Změna zaškrtnutí |
| `ValueChanged` | NumericUpDown, TrackBar | Změna hodnoty |

---

## Vytvoření event handleru

### Způsob 1 — dvojklik v Designeru (nejrychlejší)

Dvojklikem na komponentu v Designeru Visual Studio automaticky:
1. Vytvoří metodu event handleru
2. Připojí ji k výchozí události komponenty (pro Button je výchozí `Click`)
3. Přesune kurzor do těla metody

```csharp
private void buttonOK_Click(object sender, EventArgs e)
{
    // sem píšeme kód
}
```

### Způsob 2 — přes panel Properties

1. Vyberte komponentu v Designeru
2. V panelu Properties klikněte na ikonu blesku ⚡ (Events)
3. Najděte požadovanou událost a dvojklikněte na prázdné pole vedle ní

Tento způsob použijte, když potřebujete jiný event než výchozí (např. `MouseEnter`, `KeyDown`).

---

## Signatura event handleru

Všechny event handlery ve WinForms mají stejnou strukturu:

```csharp
private void názevKomponenty_NázevUdálosti(object sender, EventArgs e)
{
    // kód
}
```

- `object sender` — komponenta, která událost vyvolala (lze přetypovat na konkrétní typ)
- `EventArgs e` — informace o události (u některých událostí obsahuje užitečná data)

Pojmenování `buttonOK_Click` je konvence Visual Studia — název lze změnit, ale nepomíchejte ho s napojením v Designeru.

---

## Příklad: Tlačítko s reakcí

```csharp
private void buttonGreet_Click(object sender, EventArgs e)
{
    string name = textBoxName.Text;

    if (string.IsNullOrWhiteSpace(name))
    {
        labelResult.Text = "Zadej prosím jméno.";
        return;
    }

    labelResult.Text = $"Ahoj, {name}!";
}
```

---

## Parametr `sender`

`sender` je odkaz na komponentu, která událost spustila. Hodí se, když **jeden handler obsluhuje více komponent**:

```csharp
private void buttonColor_Click(object sender, EventArgs e)
{
    Button btn = (Button)sender;        // přetypování na Button
    this.BackColor = btn.BackColor;     // nastav barvu okna podle barvy tlačítka
}
```

Tento handler lze připojit k více tlačítkům — každé nastaví jinou barvu, protože přes `sender` víme, které bylo stisknuto.

---

## Událost Load

`Form.Load` se spustí jednou při načtení formuláře — ještě před tím, než ho uživatel uvidí. Používá se pro inicializaci:

```csharp
private void Form1_Load(object sender, EventArgs e)
{
    comboBoxMonth.Items.AddRange(new string[]
    {
        "Leden", "Únor", "Březen", "Duben", "Květen", "Červen",
        "Červenec", "Srpen", "Září", "Říjen", "Listopad", "Prosinec"
    });
    comboBoxMonth.SelectedIndex = 0;
}
```

---

## Shrnutí

| Pojem | Vysvětlení |
|---|---|
| Událost (event) | Akce uživatele nebo systému (kliknutí, změna textu…) |
| Event handler | Metoda, která se spustí jako reakce na událost |
| `sender` | Komponenta, která událost vyvolala |
| `EventArgs e` | Doplňující informace o události |
| Designer / Properties | Vizuální způsob napojení handleru na událost |
---

## Otázky k zamyšlení

1. Co přesně znamená řádek `button1.Click += button1_Click;`? Co je na levé a co na pravé straně?
2. K čemu slouží parametr `object sender`? Jak ho využijete, když deset tlačítek sdílí jednu obslužnou metodu?
3. Jaký je rozdíl mezi událostmi `TextChanged`, `KeyPress` a `Leave` u textového pole? Pro jakou validaci se hodí která?

---

## Procvičení

### Řešený příklad

**Zadání:** Vytvořte formulář s deseti tlačítky s čísly 0–9 (jako numerická klávesnice), všechna obsluhovaná **jedinou** metodou, která zmáčknutou číslici připojí k textu v `Label` (jako displej kalkulačky).

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

Klíčem je parametr `sender` — říká nám, *které* tlačítko událost vyvolalo:

```csharp
public Form1()
{
    InitializeComponent();

    // všem tlačítkům přiřadíme stejnou obsluhu
    foreach (Control c in this.Controls)
    {
        if (c is Button btn && btn.Text.Length == 1 && char.IsDigit(btn.Text[0]))
        {
            btn.Click += Cislice_Click;
        }
    }
}

private void Cislice_Click(object sender, EventArgs e)
{
    Button stisknute = (Button)sender;      // přetypování sender na Button
    lblDisplej.Text += stisknute.Text;      // připojení číslice
}
```

Bez `sender` bychom potřebovali deset skoro totožných metod. Takhle logika existuje jednou — a přidání jedenáctého tlačítka nevyžaduje žádný nový kód obsluhy.

</details>

### Samostatná cvičení

1. **Základní** — Přidejte k "displeji" tlačítko C (smazat vše) a ⌫ (smazat poslední znak). U mazání posledního znaku ošetřete prázdný displej.
2. **Pokročilejší** — Vytvořte `TextBox`, který přes událost `KeyPress` povolí psát jen číslice (nápověda: `e.Handled = true` pro zakázané znaky, nezapomeňte povolit Backspace).
3. **Bonus (*)** — Vytvořte formulář, kde `Label` v reálném čase (`TextChanged`) ukazuje počet zbývajících znaků do limitu 140, a při překročení zčervená.