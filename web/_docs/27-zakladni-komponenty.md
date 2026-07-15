---
layout: post
title: "Základní komponenty"
order: 270
---

V aplikacích Windows Forms se uživatelské rozhraní skládá z jednotlivých komponent. Komponenty představují prvky, se kterými uživatel pracuje – například tlačítka, textová pole nebo seznamy.

Komponenty přidáváme na formulář pomocí okna **Toolbox**. Každá komponenta má:

- **vlastnosti (Properties)** – určují vzhled a chování,
- **metody (Methods)** – provádějí určité akce,
- **události (Events)** – reagují na činnost uživatele.

> 💡 Jak přesně události a jejich obsluha (event handlery) funguje, si podrobně vysvětlíme v příští kapitole. Tady si jen u každé komponenty ukážeme, jak typický zápis vypadá.

---

## Label

Komponenta sloužící k zobrazení textu.

Používá se například pro:

- popisky formulářů,
- nápovědu,
- zobrazení výsledků výpočtů.

```csharp
lblResult.Text = "Hotovo";
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
private void btnSave_Click(object sender, EventArgs e)
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
string name = txtName.Text;
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
if (chkTerms.Checked)
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
if (radMale.Checked)
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
string city = cmbCity.Text;
```

### Přidání položek

```csharp
cmbCity.Items.Add("Praha");
cmbCity.Items.Add("Brno");
cmbCity.Items.Add("Ostrava");
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
lstStudents.Items.Add("Kamil");
lstStudents.Items.Add("Jana");
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
picLogo.Image = Image.FromFile("logo.png");
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

Při vytváření aplikací používejte smysluplné názvy komponent.

| Komponenta | Doporučený název |
|---|---|
| Button | `btnSave` |
| Label | `lblResult` |
| TextBox | `txtName` |
| CheckBox | `chkTerms` |
| RadioButton | `radMale` |
| ComboBox | `cmbCity` |
| ListBox | `lstStudents` |
| PictureBox | `picLogo` |

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

---

## Otázky k zamyšlení

1. Kdy použijete `Label` a kdy `TextBox` s `ReadOnly = true`? V čem se liší pro uživatele?
2. Jaký je rozdíl mezi `RadioButton` a `CheckBox`? Jak zajistíte dvě nezávislé skupiny radiobuttonů na jednom formuláři?
3. Hodnota z `TextBox` je vždy `string`. Jaké kroky musí program udělat, než s ní může počítat?

---

## Procvičení

### Řešený příklad

**Zadání:** Vytvořte formulář "objednávka pizzy": `ComboBox` s výběrem pizzy, `RadioButton` pro velikost (malá/velká), `CheckBox` "krabice navíc" a tlačítko, které sestaví a zobrazí souhrn objednávky.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

Položky ComboBoxu vyplňte v designeru (vlastnost `Items`) nebo v konstruktoru formuláře. Obsluha tlačítka:

```csharp
private void btnObjednat_Click(object sender, EventArgs e)
{
    if (cmbPizza.SelectedIndex == -1)
    {
        MessageBox.Show("Vyber si pizzu.", "Chybí výběr");
        return;
    }

    string pizza = cmbPizza.SelectedItem.ToString();
    string velikost = rbVelka.Checked ? "velká" : "malá";
    string krabice = chbKrabice.Checked ? " + krabice navíc" : "";

    lblSouhrn.Text = $"Objednávka: {velikost} {pizza}{krabice}";
}
```

Tři typické vzory: kontrola `SelectedIndex == -1` (nic nevybráno), čtení `Checked` u radio/checkboxů, a **předčasný návrat** (`return`) při nevalidním stavu, aby zbytek metody nemusel být ve vnořeném `if`.

</details>

### Samostatná cvičení

1. **Základní** — Vytvořte formulář se dvěma `TextBox` pro čísla a čtyřmi tlačítky (+, −, ×, ÷). Výsledek zobrazte v `Label`. Ošetřete nečíselný vstup a dělení nulou.
2. **Pokročilejší** — Vytvořte formulář "anketa": jméno (`TextBox`), třída (`ComboBox`), oblíbené předměty (více `CheckBox`ů) a tlačítko, které přidá souhrn do `ListBox`u.
3. **Bonus (*)** — Přidejte k anketě tlačítko "Smazat vybrané", které odstraní označenou položku z `ListBox`u, a zajistěte, že je aktivní jen když je něco vybráno (událost `SelectedIndexChanged`).