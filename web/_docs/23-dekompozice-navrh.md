---
layout: post
title: "Dekompozice a návrh aplikace"
order: 230
---

Dosud jsme se věnovali jednotlivým **stavebním kamenům** jazyka – proměnným, podmínkám, cyklům, metodám, kolekcím. Od příští kapitoly se přesouváme k **Windows Forms aplikacím** (WFA) – programům s okny, tlačítky a grafickým rozhraním.

Než ale začneme klikat na komponenty, je potřeba umět jednu klíčovou dovednost: **rozložit zadání na zvládnutelné části**. Tato kapitola je most mezi "umím syntaxi" a "umím navrhnout aplikaci".

---

## Co je dekompozice?

**Dekompozice** je rozklad velkého, komplexního problému na menší, samostatně řešitelné části. Stejný princip, který jsme používali u metod ("jedna metoda, jeden úkol"), platí i na úrovni celé aplikace.

> 💡 Dekompozice nejde nadeklarovat jedním pravidlem – je to dovednost, kterou si osvojíte praxí. Cílem této kapitoly je dát vám **postup**, kterým se můžete řídit, než vám dekompozice "vleze do krve".

---

## Od zadání ke kódu – čtyři kroky

### 1. Specifikace – co aplikace dělá?

Nejprve si zadání **přepište vlastními slovy** jako seznam funkcí, které aplikace musí umět. Konkrétně, ne obecně.

Příklad zadání: *"Vytvořte aplikaci pro správu nákupního seznamu."*

❌ Příliš obecné: *"Aplikace bude správa seznamu."*

✅ Konkrétní specifikace:

- Uživatel může zadat název položky a počet kusů
- Po kliknutí na tlačítko se položka přidá do seznamu
- Seznam položek se zobrazuje v okně
- Uživatel může vybranou položku ze seznamu odebrat
- Aplikace zobrazuje celkový počet položek v seznamu

> 💡 Pokud nějaký bod specifikace nejde popsat jednou věcí, co se stane (vstup → akce → výstup), je pravděpodobně ještě moc obecný a potřebuje další rozklad.

---

### 2. Návrh – z čeho se aplikace skládá?

Z konkrétní specifikace odvodíte dvě věci: **co uživatel vidí** (UI) a **co se děje "pod kapotou"** (data a logika).

#### UI prvky

Pro každou funkci ze specifikace určete, jaká komponenta ji obstará:

| Funkce ze specifikace | UI prvek |
|---|---|
| Zadat název položky | `TextBox` |
| Zadat počet kusů | `NumericUpDown` |
| Přidat položku | `Button` |
| Zobrazit seznam | `ListBox` |
| Odebrat položku | `Button` (+ výběr v `ListBox`) |
| Celkový počet | `Label` |

> 💡 Konkrétní komponenty (`TextBox`, `NumericUpDown`, `ListBox`...) si detailně představíme v **Základní komponenty** – tady jde jen o to, přiřadit ke každé funkci vhodný typ ovládacího prvku.

#### Data

Jaká data si aplikace potřebuje pamatovat, aby UI prvky mohly fungovat?

```csharp
// Jedna položka nákupního seznamu
class ShoppingItem
{
    public string Name { get; set; }
    public int Quantity { get; set; }
}

// Seznam všech položek
List<ShoppingItem> items = new List<ShoppingItem>();
```

> 💡 Syntax `{ get; set; }` uvnitř `class` jsou **vlastnosti** (properties) – stejný princip, jaký jsme viděli u `struct` v kapitole **Struktura a enumerace**, jen na `class`. Detailně se třídám a objektům budeme věnovat později; teď stačí vědět, že `ShoppingItem` je "krabička", která drží pohromadě `Name` a `Quantity` jedné položky.

> 💡 Tady se vrací téma z kapitoly **Datové struktury** a **Struktura a enumerace** – výběr vhodné datové struktury je součástí návrhu, ne implementační detail, který "vyřešíš za běhu".

#### Logika

Jaké **akce** se mají stát a co každá z nich udělá s daty?

| Akce (událost) | Co se stane |
|---|---|
| Klik na "Přidat" | Přečte text z `TextBox` a číslo z `NumericUpDown`, vytvoří `ShoppingItem`, přidá do `items`, aktualizuje `ListBox` |
| Klik na "Odebrat" | Zjistí vybranou položku v `ListBox`, odebere z `items`, aktualizuje `ListBox` |
| (po každé změně) | Přepočítá a zobrazí celkový počet kusů v `Label` |

---

### 3. Rozpad na metody

Z tabulky logiky teď vznikají konkrétní metody – každá řádka tabulky je kandidát na samostatnou metodu:

```csharp
void AddItem(string name, int quantity)
{
    items.Add(new ShoppingItem { Name = name, Quantity = quantity });
    RefreshListBox();
    UpdateTotalLabel();
}

void RemoveSelectedItem(int selectedIndex)
{
    if (selectedIndex < 0) return; // nic není vybráno

    items.RemoveAt(selectedIndex);
    RefreshListBox();
    UpdateTotalLabel();
}

void RefreshListBox()
{
    // vyprázdní a znovu naplní ListBox podle items
}

void UpdateTotalLabel()
{
    int total = 0;
    foreach (var item in items)
        total += item.Quantity;

    // nastaví text Label na total
}
```

Všimněte si: `RefreshListBox()` a `UpdateTotalLabel()` se volají z obou akcí – díky dekompozici se nepíšou dvakrát.

---

### 4. Implementace

Teprve teď – po specifikaci, návrhu a rozpadu na metody – přichází psaní kódu v konkrétním prostředí (WFA). V této fázi už jen "vyplňujete" jednotlivé metody a propojujete je s konkrétními komponentami okna (`textBoxName`, `listBoxItems`, `labelTotal`...).

> 💡 Pokud se vám implementace zdá těžká nebo nevíte, kde začít, je to často signál, že krok 2 nebo 3 byl proveden povrchně. Vraťte se k návrhu – psaní kódu by mělo být tou *nejméně* náročnou částí, pokud je návrh dostatečně konkrétní.

---

## Jak velký kus rozkládat?

Návod, kdy je kus "zvládnutelný":

- Umíte ho popsat **jednou větou** bez slova "a" (viz kapitola **Vlastní metody** – jedna metoda, jeden úkol)
- Umíte odhadnout, **jaké datové typy** budou na vstupu a výstupu
- Dokážete si představit **konkrétní příklad** vstupu a očekávaného výstupu

```
❌ "Aplikace zpracuje data od uživatele a zobrazí výsledky."
   (co je "data"? jaké "výsledky"? jak vypadá vstup?)

✅ "Metoda AddItem přijme název (string) a počet kusů (int),
   vytvoří novou ShoppingItem a přidá ji do seznamu items."
   (konkrétní typy, konkrétní akce, dá se otestovat)
```

---

## Dekompozice odshora dolů (top-down)

Praktický postup je **postupné zjemňování** – začnete na úrovni celé aplikace a krok za krokem se dostáváte k detailům:

```
Nákupní seznam
├── Přidávání položek
│   ├── Načtení vstupu z formuláře
│   ├── Validace (název nesmí být prázdný, počet > 0)
│   └── Uložení do seznamu + aktualizace UI
├── Odebírání položek
│   ├── Zjištění vybrané položky
│   └── Odebrání ze seznamu + aktualizace UI
└── Souhrnné informace
    └── Přepočet celkového počtu kusů
```

Každá úroveň stromu je menší a konkrétnější než ta nad ní. Listy stromu (nejnižší úroveň) odpovídají jednotlivým metodám nebo i jednotlivým řádkům kódu.

> ⚠️ Časté úskalí: snaha napsat *celou* aplikaci najednou ("nejdřív naprogramuju všechno a pak to spustím"). Lepší přístup je **vertikální plátky** – udělejte *jednu* funkci od UI po data kompletně funkční (např. jen "přidání položky"), vyzkoušejte, že funguje, a pak pokračujte další funkcí.

---

## Shrnutí

```
1. Specifikace  → seznam konkrétních funkcí (vstup → akce → výstup)
2. Návrh        → UI prvky + datové struktury + tabulka akcí
3. Rozpad       → konkrétní metody se signaturami
4. Implementace → psaní kódu, propojení s komponentami WFA
```

| Pojem | Vysvětlení |
|---|---|
| Dekompozice | Rozklad velkého problému na menší, řešitelné části |
| Specifikace | Konkrétní popis "co aplikace dělá" – ne obecné fráze |
| Návrh | UI prvky, datové struktury a akce odvozené ze specifikace |
| Top-down | Postup od celku k detailům formou stromu |
| Vertikální plátek | Jedna funkce kompletně funkční od UI po data, než se přejde k další |

V následující kapitole se podíváme na samotné Windows Forms aplikace – okna, komponenty a jejich vlastnosti.
---

## Otázky k zamyšlení

1. Čím se liší dekompozice na úrovni návrhu aplikace od dekompozice algoritmu z úvodu učebnice?
2. Proč se vyplatí navrhnout strukturu programu (metody, data) dřív, než napíšete první řádek kódu?
3. Co je "špagetový kód" a jak dekompozice pomáhá se mu vyhnout?

---

## Procvičení

### Řešený příklad

**Zadání (návrhové):** Navrhněte strukturu konzolové aplikace "slovníček pro učení slovíček": přidávání dvojic CZ–EN, zkoušení v náhodném pořadí, výpis úspěšnosti. Rozepište hlavní datové struktury a metody se signaturami. Kód psát nemusíte.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

**Data:**
- `Dictionary<string, string> slovicka` — klíč = české slovo, hodnota = anglický překlad
- `int spravne`, `int celkem` — statistika zkoušení

**Metody:**

| Metoda | Signatura | Odpovědnost |
|--------|-----------|-------------|
| `ZobrazMenu` | `int ZobrazMenu()` | vypíše volby, vrátí volbu uživatele |
| `PridejSlovicko` | `void PridejSlovicko(Dictionary<string,string> s)` | načte dvojici, ošetří duplicitu |
| `Zkousej` | `(int spravne, int celkem) Zkousej(Dictionary<string,string> s, int pocet)` | náhodně vybírá, porovnává odpovědi |
| `VypisStatistiku` | `void VypisStatistiku(int spravne, int celkem)` | procento úspěšnosti |

**Hlavní smyčka v `Main`:** `while` cyklus → `ZobrazMenu` → `switch` podle volby → volání příslušné metody.

Klíčové rozhodnutí: `Zkousej` **vrací** výsledky, nevypisuje je — o výpis se stará `VypisStatistiku`. Oddělení logiky od prezentace usnadní pozdější převod třeba do WinForms.

</details>

### Samostatná cvičení

1. **Základní** — Navrhněte stejným způsobem strukturu aplikace "jednoduchý úkolníček" (přidat úkol, označit hotový, vypsat nehotové).
2. **Pokročilejší** — Navrhněte strukturu hry "kámen, nůžky, papír proti počítači" na 3 vítězné hry. Rozlište metody pro logiku (kdo vyhrál kolo) a pro vstup/výstup.
3. **Bonus (*)** — Vezměte svůj návrh úkolníčku a rozšiřte ho o ukládání do souboru. Které metody se změní a které zůstanou beze změny? Co vám to říká o kvalitě původního návrhu?