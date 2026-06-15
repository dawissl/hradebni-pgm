---
layout: post
title: "Dialogová okna"
order: 30
---

Dialogová okna jsou specializovaná okna, která vyžadují od uživatele reakci nebo výběr — potvrzení akce, výběr souboru, volbu barvy. WinForms nabízí sadu hotových dialogů, takže je nemusíš navrhovat od nuly.

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
    "Opravdu chceš smazat záznam?",
    "Potvrzení",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Warning
);

if (result == DialogResult.Yes)
{
    SmazatZaznam();
}
```

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

Vlastnost `Filter` určuje typy souborů v rozevíracím seznamu dialogu. Formát: `"Popis (*.ext)|*.ext"`. Více typů odděluješ `|`.

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

---

## Vlastní formulářové okno

Někdy standardní dialogy nestačí — potřebuješ vlastní okno s konkrétními poli.

**1. Přidej nový formulář:** pravý klik na projekt → Přidat → Formulář Windows Forms → pojmenuj ho (např. `FormNastaveni`).

**2. Navrhni UI** v Designeru — přidej komponenty, tlačítka OK a Storno.

**3. Nastav `DialogResult` tlačítkům:**

```csharp
// V konstruktoru nebo Properties:
buttonOK.DialogResult = DialogResult.OK;
buttonStorno.DialogResult = DialogResult.Cancel;

// Tím se formulář zavře automaticky po kliknutí
this.AcceptButton = buttonOK;      // Enter = OK
this.CancelButton = buttonStorno;  // Escape = Storno
```

**4. Předej data zpět přes veřejné properties:**

```csharp
// FormNastaveni.cs
public string JmenoUzivatele => textBoxJmeno.Text;
public int MaxPocet => (int)numericUpDown1.Value;
```

**5. Otevři dialog z hlavního formuláře:**

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