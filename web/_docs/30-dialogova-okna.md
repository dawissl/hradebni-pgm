---
layout: post
title: "Dialogová okna"
order: 300
---

Dialogová okna jsou specializovaná okna, která vyžadují od uživatele reakci nebo výběr — potvrzení akce, výběr souboru, volbu barvy. WinForms nabízí sadu hotových dialogů, takže je nemusíte navrhovat od nuly.

---

## Modální vs. nemodální okno

| | Modální (`ShowDialog`) | Nemodální (`Show`) |
|---|---|---|
| Blokuje? | Ano — uživatel nemůže pracovat s hlavním oknem, dokud dialog nezavře | Ne — obě okna jsou aktivní naráz |
| Kdy použít | Potvrzení, výběr souboru, nastavení | Průvodce nástrojem, panel vlastností |
| Vrací | `DialogResult` | — |

```csharp
// Modální — čeká na zavření
DialogResult result = form2.ShowDialog();

// Nemodální — pokračuje okamžitě
form2.Show();
```

---

## MessageBox

Nejjednodušší dialog — zobrazí zprávu s jedním nebo více tlačítky.

```csharp
// Prostá informace
MessageBox.Show("Data byla uložena.");

// S nadpisem
MessageBox.Show("Data byla uložena.", "Úspěch");

// S volbou Ano/Ne
DialogResult result = MessageBox.Show(
    "Opravdu chcete smazat záznam?",
    "Potvrzení",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Warning
);

if (result == DialogResult.Yes)
{
    SmazatZaznam();
}
```

<!-- TODO: screenshot - MessageBox s tlačítky Ano/Ne a ikonou Warning -->

---

## OpenFileDialog — výběr souboru

```csharp
OpenFileDialog dialog = new OpenFileDialog();
dialog.Title = "Otevřít soubor";
dialog.Filter = "Textové soubory (*.txt)|*.txt|Všechny soubory (*.*)|*.*";
dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

if (dialog.ShowDialog() == DialogResult.OK)
{
    string cesta = dialog.FileName;
    textBoxObsah.Text = File.ReadAllText(cesta);
}
```

Vlastnost `Filter` určuje typy souborů v rozevíracím seznamu dialogu. Formát: `"Popis (*.ext)|*.ext"`. Více typů oddělujete `|`.

<!-- TODO: screenshot - dialog pro otevření souboru s nastaveným Filter (Textové soubory) -->

---

## SaveFileDialog — uložení souboru

```csharp
SaveFileDialog dialog = new SaveFileDialog();
dialog.Title = "Uložit jako";
dialog.Filter = "Textové soubory (*.txt)|*.txt";
dialog.DefaultExt = "txt";
dialog.FileName = "novy_soubor";

if (dialog.ShowDialog() == DialogResult.OK)
{
    File.WriteAllText(dialog.FileName, textBoxObsah.Text);
}
```

<!-- TODO: screenshot - dialog pro uložení souboru s předvyplněným názvem -->

---

## ColorDialog — výběr barvy

```csharp
ColorDialog dialog = new ColorDialog();
dialog.Color = panelNahled.BackColor;  // předvyplnit aktuální barvou

if (dialog.ShowDialog() == DialogResult.OK)
{
    panelNahled.BackColor = dialog.Color;
}
```

<!-- TODO: screenshot - dialog pro výběr barvy -->

---

## FontDialog — výběr písma

```csharp
FontDialog dialog = new FontDialog();
dialog.Font = textBoxText.Font;  // předvyplnit aktuálním písmem

if (dialog.ShowDialog() == DialogResult.OK)
{
    textBoxText.Font = dialog.Font;
}
```

<!-- TODO: screenshot - dialog pro výběr písma -->

---

## Vlastní formulářové okno

Někdy standardní dialogy nestačí — potřebujete vlastní okno s konkrétními poli.

**1. Přidejte nový formulář:** pravý klik na projekt → Přidat → Formulář Windows Forms → pojmenujte ho (např. `FormNastaveni`).

<!-- TODO: screenshot - kontextové menu projektu: Přidat → Formulář Windows Forms -->

**2. Navrhněte UI** v Designeru — přidejte komponenty, tlačítka OK a Storno.

**3. Nastavte `DialogResult` tlačítkům:**

```csharp
// V konstruktoru nebo Properties:
buttonOK.DialogResult = DialogResult.OK;
buttonStorno.DialogResult = DialogResult.Cancel;

// Tím se formulář zavře automaticky po kliknutí
this.AcceptButton = buttonOK;      // Enter = OK
this.CancelButton = buttonStorno;  // Escape = Storno
```

**4. Předejte data zpět přes veřejné properties:**

```csharp
// FormNastaveni.cs
public string JmenoUzivatele => textBoxJmeno.Text;
public int MaxPocet => (int)numericUpDown1.Value;
```

**5. Otevřete dialog z hlavního formuláře:**

```csharp
FormNastaveni dialog = new FormNastaveni();

if (dialog.ShowDialog() == DialogResult.OK)
{
    labelJmeno.Text = dialog.JmenoUzivatele;
    maxPocet = dialog.MaxPocet;
}
```

---

## Shrnutí

| Dialog | Třída | Typické použití |
|---|---|---|
| Zpráva s tlačítky | `MessageBox` | Potvrzení, informace, varování |
| Výběr souboru | `OpenFileDialog` | Načtení souboru |
| Uložení souboru | `SaveFileDialog` | Uložení pod zvoleným názvem |
| Výběr barvy | `ColorDialog` | Nastavení barvy prvku |
| Výběr písma | `FontDialog` | Nastavení písma textu |
| Vlastní dialog | Nový formulář + `ShowDialog` | Složitější vstup od uživatele |
---

## Otázky k zamyšlení

1. Jaký je rozdíl mezi modálním (`ShowDialog`) a nemodálním (`Show`) oknem? Kdy je modalita nutná?
2. `MessageBox.Show` vrací hodnotu `DialogResult`. K čemu je a proč ji nestačí ignorovat u dotazu "Opravdu smazat?"
3. Proč používat `OpenFileDialog`/`SaveFileDialog` místo textového pole, kam uživatel napíše cestu ručně?

---

## Procvičení

### Řešený příklad

**Zadání:** Do aplikace přidejte tlačítko "Konec", které se před zavřením zeptá "Opravdu chcete aplikaci ukončit?" s tlačítky Ano/Ne. Zajistěte stejné chování i při zavření okna křížkem.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

```csharp
private void btnKonec_Click(object sender, EventArgs e)
{
    this.Close();   // jen vyvolá zavírání – dotaz řeší FormClosing
}

private void Form1_FormClosing(object sender, FormClosingEventArgs e)
{
    DialogResult odpoved = MessageBox.Show(
        "Opravdu chcete aplikaci ukončit?",
        "Potvrzení",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

    if (odpoved == DialogResult.No)
    {
        e.Cancel = true;   // zavírání se zruší
    }
}
```

Trik je v tom, že dotaz **nepatří do tlačítka**, ale do události `FormClosing` — ta zachytí všechny cesty zavření (tlačítko, křížek, Alt+F4). `e.Cancel = true` řekne formuláři "nezavírej se". Tlačítko Konec pak jen zavolá `Close()` a o nic dalšího se nestará.

</details>

### Samostatná cvičení

1. **Základní** — Přidejte do libovolné své aplikace tlačítko "O aplikaci", které zobrazí MessageBox s názvem, verzí a vaším jménem, s ikonou Information.
2. **Pokročilejší** — Vytvořte aplikaci s `TextBox`em (Multiline) a tlačítky "Otevřít" a "Uložit", která pomocí `OpenFileDialog`/`SaveFileDialog` načte a uloží textový soubor. Nastavte `Filter` na textové soubory.
3. **Bonus (*)** — Vytvořte vlastní dialogové okno (druhý formulář) pro zadání jména, otevírané přes `ShowDialog()`, které vrátí zadané jméno hlavnímu oknu. (Nápověda: vlastnost `DialogResult` tlačítek a veřejná property formuláře.)