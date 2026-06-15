---
layout: post
title: "Základní komponenty"
order: 27
---

V aplikacích Windows Forms se uživatelské rozhraní skládá z jednotlivých komponent. Komponenty představují prvky, se kterými uživatel pracuje – například tlačítka, textová pole nebo seznamy.

Komponenty přidáváme na formulář pomocí okna **Toolbox**. Každá komponenta má:

- **vlastnosti (Properties)** – určují vzhled a chování,
- **metody (Methods)** – provádějí určité akce,
- **události (Events)** – reagují na činnost uživatele.

---

## Label

Komponenta sloužící k zobrazení textu.

Používá se například pro:

- popisky formulářů,
- nápovědu,
- zobrazení výsledků výpočtů.

```csharp
LblResult.Text = "Hotovo";
```

### Důležité vlastnosti

| Vlastnost | Význam |
|---|---|
| Text | Zobrazený text |
| ForeColor | Barva textu |
| BackColor | Barva pozadí |
| Visible | Viditelnost komponenty |
| AutoSize | Automatické přizpůsobení velikosti |

### Nejčastější použití

- popis vstupních polí,
- zobrazení stavových informací,
- výpis výsledků.

---

## Button

Tlačítko sloužící ke spuštění akce.

Nejčastěji reaguje na událost `Click`.

```csharp
private void BtnSave_Click(object sender, EventArgs e)
{
    MessageBox.Show("Data byla uložena.");
}
```

### Důležité vlastnosti

| Vlastnost | Význam |
|---|---|
| Text | Text tlačítka |
| Enabled | Povolení nebo zákaz použití |
| Visible | Viditelnost |
| BackColor | Barva pozadí |

### Důležitá událost

| Událost | Význam |
|---|---|
| Click | Kliknutí na tlačítko |

### Nejčastější použití

- potvrzení formuláře,
- spuštění výpočtu,
- otevření souboru,
- ukončení programu.

---

## TextBox

Komponenta pro zadávání textu.

```csharp
string name = TxtName.Text;
```

### Důležité vlastnosti

| Vlastnost | Význam |
|---|---|
| Text | Zadaný text |
| Multiline | Umožňuje více řádků |
| ReadOnly | Pouze pro čtení |
| MaxLength | Maximální délka textu |
| PasswordChar | Skrytí znaků hesla |

### Důležitá událost

| Událost | Význam |
|---|---|
| TextChanged | Změna textu |

### Nejčastější použití

- zadání jména,
- zadání hesla,
- zadání číselné hodnoty,
- víceřádkový text.

---

## CheckBox

Komponenta představující přepínač typu Ano/Ne.

```csharp
if (ChkTerms.Checked)
{
    MessageBox.Show("Souhlas potvrzen.");
}
```

### Důležité vlastnosti

| Vlastnost | Význam |
|---|---|
| Checked | Stav zaškrtnutí |
| Text | Popisek |
| Enabled | Povolení použití |

### Důležitá událost

| Událost | Význam |
|---|---|
| CheckedChanged | Změna stavu |

### Nejčastější použití

- souhlas s podmínkami,
- zapnutí nebo vypnutí funkce,
- výběr více možností současně.

---

## RadioButton

Komponenta umožňující výběr jedné možnosti z více.

```csharp
if (RadMale.Checked)
{
    MessageBox.Show("Vybrán muž.");
}
```

### Důležité vlastnosti

| Vlastnost | Význam |
|---|---|
| Checked | Stav výběru |
| Text | Popisek |

### Důležitá událost

| Událost | Význam |
|---|---|
| CheckedChanged | Změna výběru |

> 💡 RadioButtony umístěné ve stejné skupině umožňují vybrat pouze jednu možnost.

### Nejčastější použití

- výběr pohlaví,
- výběr typu platby,
- výběr režimu aplikace.

---

## ComboBox

Rozbalovací seznam položek.

```csharp
string city = CmbCity.Text;
```

### Přidání položek

```csharp
CmbCity.Items.Add("Praha");
CmbCity.Items.Add("Brno");
CmbCity.Items.Add("Ostrava");
```

### Důležité vlastnosti

| Vlastnost | Význam |
|---|---|
| Text | Vybraná položka |
| SelectedIndex | Index vybrané položky |
| SelectedItem | Vybraný objekt |
| Items | Kolekce položek |

### Důležitá událost

| Událost | Význam |
|---|---|
| SelectedIndexChanged | Změna výběru |

### Nejčastější použití

- výběr města,
- výběr státu,
- výběr kategorie.

---

## ListBox

Komponenta zobrazující seznam položek.

```csharp
LstStudents.Items.Add("Kamil");
LstStudents.Items.Add("Jana");
```

### Důležité vlastnosti

| Vlastnost | Význam |
|---|---|
| Items | Seznam položek |
| SelectedItem | Vybraná položka |
| SelectedIndex | Index vybrané položky |

### Důležitá událost

| Událost | Význam |
|---|---|
| SelectedIndexChanged | Změna výběru |

### Nejčastější použití

- seznam studentů,
- seznam souborů,
- výpis výsledků.

---

## PictureBox

Komponenta pro zobrazení obrázků.

```csharp
PicLogo.Image = Image.FromFile("logo.png");
```

### Důležité vlastnosti

| Vlastnost | Význam |
|---|---|
| Image | Zobrazený obrázek |
| SizeMode | Způsob zobrazení |
| Visible | Viditelnost |

### Nejčastější použití

- loga aplikace,
- fotografie,
- ikony,
- náhledy obrázků.

---

## Společné vlastnosti komponent

Mnoho komponent sdílí stejné vlastnosti.

| Vlastnost | Význam |
|---|---|
| Name | Název komponenty v programu |
| Text | Zobrazený text |
| Enabled | Povolení použití |
| Visible | Viditelnost |
| BackColor | Barva pozadí |
| ForeColor | Barva textu |
| Font | Písmo |
| Width | Šířka |
| Height | Výška |

---

## Společné metody

| Metoda | Význam |
|---|---|
| Show() | Zobrazí komponentu |
| Hide() | Skryje komponentu |
| Focus() | Nastaví fokus |
| Refresh() | Překreslí komponentu |

---

## Nejčastější události

| Událost | Význam |
|---|---|
| Click | Kliknutí |
| TextChanged | Změna textu |
| CheckedChanged | Změna zaškrtnutí |
| SelectedIndexChanged | Změna výběru |
| MouseEnter | Najetí myší |
| MouseLeave | Opuštění myší |

---

## Doporučení pro pojmenování

Při vytváření aplikací používej smysluplné názvy komponent.

| Komponenta | Doporučený název |
|---|---|
| Button | `BtnSave` |
| Label | `LblResult` |
| TextBox | `TxtName` |
| CheckBox | `ChkTerms` |
| RadioButton | `RadMale` |
| ComboBox | `CmbCity` |
| ListBox | `LstStudents` |
| PictureBox | `PicLogo` |

Díky správnému pojmenování je kód přehlednější a snadněji se udržuje.

---

## Shrnutí

| Komponenta | Použití |
|---|---|
| Label | Zobrazení textu |
| Button | Spuštění akce |
| TextBox | Zadávání textu |
| CheckBox | Ano/Ne |
| RadioButton | Výběr jedné možnosti |
| ComboBox | Rozbalovací seznam |
| ListBox | Seznam položek |
| PictureBox | Zobrazení obrázků |

---

## Závěr

Základní komponenty tvoří stavební kameny každé aplikace Windows Forms. Jejich správné použití umožňuje vytvářet přehledná a snadno ovladatelná uživatelská rozhraní.

Před tvorbou složitějších aplikací je důležité dobře porozumět vlastnostem, metodám a událostem jednotlivých komponent.
```