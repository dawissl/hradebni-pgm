---
layout: post
title: "Nullable typy a operátory ?., ??, ??="
order: 491
---

V kapitole **Hodnotové a referenční typy** jsme viděli, že referenční typy (třídy, `string`, pole) mohou být `null` — proměnná bez odkazu na žádný objekt. Hodnotové typy (`int`, `bool`, `struct`) `null` být nemohou, protože přímo *jsou* svojí hodnotou, ne odkazem. Co ale dělat, když potřebujete vyjádřit "číslo, které možná neexistuje" — třeba věk, který uživatel nemusel vyplnit? K tomu slouží **nullable typy**.

---

## Hodnotový typ, který může být `null`

Přidáním otazníku za typ vytvoříte jeho nullable variantu:

```csharp
int? vek = null;      // int? = "int, nebo null"
vek = 25;              // teď má hodnotu

bool? souhlas = null;
double? teplota = null;
```

`int?` je ve skutečnosti zkratka za `Nullable<int>` — obecnou (generickou, viz kapitola **Generika**) strukturu, která k hodnotovému typu přidává informaci "má vůbec hodnotu, nebo ne".

### `HasValue` a `Value`

```csharp
int? vek = null;

Console.WriteLine(vek.HasValue);  // False

vek = 25;
Console.WriteLine(vek.HasValue);  // True
Console.WriteLine(vek.Value);     // 25
```

> ⚠️ Přečtení `.Value`, když `HasValue` je `false`, vyhodí `InvalidOperationException`. Vždy nejdřív ověřte `HasValue` (nebo použijte techniky níže, které tuto starost odstraní úplně).

### Porovnání s `null` přímo

Nemusíte vždy sahat po `HasValue` — `int?` se dá porovnat s `null` stejně přirozeně jako referenční typ:

```csharp
int? vek = null;

if (vek == null)
    Console.WriteLine("Věk nebyl zadán.");

if (vek != null)
    Console.WriteLine($"Věk: {vek}");
```

---

## Null-podmíněný operátor `?.`

Vrátíme se k referenčním typům. Bez `?.` musíte před přístupem k členu objektu vždy nejdřív ověřit, že objekt není `null`:

```csharp
string jmeno = null;

if (jmeno != null)
{
    Console.WriteLine(jmeno.Length);
}
```

Operátor `?.` totéž zapíše na jeden řádek — pokud je hodnota vlevo `null`, celý výraz se **vyhodnotí jako `null`** a zbytek se vůbec nezkusí:

```csharp
string jmeno = null;
Console.WriteLine(jmeno?.Length);   // vypíše prázdno (null), ne výjimku
```

Řetězit `?.` lze i přes víc úrovní — typicky u vlastností, které samy mohou být `null`:

```csharp
Student student = NajdiStudenta("Kamil");   // může vrátit null, pokud nenajde
Console.WriteLine(student?.Trida?.Nazev);   // bezpečné, i kdyby student nebo Trida byly null
```

Bez `?.` byste museli psát vnořené `if`, přesně jaké jsme se snažili omezit v kapitole **Podmínky** ("hlubokému vnořování se vyhýbejte").

---

## Null-koalescující operátor `??`

`??` řekne: "použij levou hodnotu, ale pokud je `null`, použij tuto náhradní":

```csharp
string jmeno = null;
string zobrazovaneJmeno = jmeno ?? "Neznámý uživatel";
Console.WriteLine(zobrazovaneJmeno);   // Neznámý uživatel

int? vek = null;
int skutecnyVek = vek ?? 0;
Console.WriteLine(skutecnyVek);        // 0
```

Časté a užitečné spojení `?.` a `??` dohromady — bezpečný přístup s náhradní hodnotou pro případ, že by výsledek byl `null`:

```csharp
Student student = NajdiStudenta("Kamil");
string trida = student?.Trida?.Nazev ?? "bez třídy";
```

### Null-koalescující přiřazení `??=`

Zkratka pro "nastav hodnotu, jen pokud tam ještě žádná není":

```csharp
string prezdivka = null;
prezdivka ??= "Anonym";
Console.WriteLine(prezdivka);   // Anonym

prezdivka ??= "Tohle se nepoužije";
Console.WriteLine(prezdivka);   // stále Anonym — hodnota už tam byla
```

Ekvivalent delšího zápisu:

```csharp
if (prezdivka == null)
{
    prezdivka = "Anonym";
}
```

---

## Nullable referenční typy (C# 8+)

Až doteď mohl být `string` (a jakýkoli jiný referenční typ) `null` odjakživa, bez upozornění. Od C# 8 lze v projektu zapnout **nullable reference types** — pak kompilátor rozlišuje:

```csharp
string jmeno = "Kamil";     // "tohle by null nemělo být" — kompilátor hlídá
string? prezdivka = null;   // "tohle null být může" — explicitně povoleno
```

Se zapnutou touto funkcí vás kompilátor varuje (žlutá vlnovka, ne chyba), pokud se pokusíte použít `string` bez otazníku způsobem, který by mohl vést k `NullReferenceException` — třeba zapomenete ošetřit vstup z `Console.ReadLine()`, který teoreticky `null` vrátit může.

> 💡 Nové projekty ve Visual Studiu mají tuto funkci často zapnutou už od začátku (`<Nullable>enable</Nullable>` v `.csproj`) — pokud jste v kódu občas viděli podivné žluté podtržení u `string`, tohle je ten důvod.

---

## Shrnutí

| Zápis | Význam |
|---|---|
| `int?`, `bool?`, `double?`... | Hodnotový typ, který může být `null` |
| `.HasValue` | Má proměnná hodnotu? |
| `.Value` | Přečtení hodnoty (jen když `HasValue` je `true`) |
| `?.` | Přístup k členu, který se vyhodnotí jako `null`, pokud je objekt `null` |
| `??` | Náhradní hodnota, pokud je výraz vlevo `null` |
| `??=` | Přiřadí, jen pokud proměnná ještě `null` je |
| `string?` (nullable reference types) | Explicitně řekne "tahle proměnná může být null" |

---

## Otázky k zamyšlení

1. Proč `int` nemůže být `null`, ale `int?` může? Co se změnilo?
2. Co udělá `student?.Trida?.Nazev`, pokud je `student` `null`? A pokud `student` existuje, ale jeho `Trida` je `null`?
3. Jaký je rozdíl mezi `x ?? y` a `x ??= y`?

---

## Procvičení

### Řešený příklad

**Zadání:** Napište metodu `int? NajdiIndex(int[] pole, int hledany)`, která vrátí index hledané hodnoty, nebo `null`, pokud v poli není. Pak napište kód, který výsledek vypíše jako "nalezeno na indexu X" nebo "nenalezeno" — bez jediného `if` na `HasValue`.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

```csharp
int? NajdiIndex(int[] pole, int hledany)
{
    for (int i = 0; i < pole.Length; i++)
    {
        if (pole[i] == hledany)
            return i;
    }
    return null;   // nenalezeno
}
```

```csharp
int[] cisla = { 5, 12, 7, 23 };
int? index = NajdiIndex(cisla, 7);

Console.WriteLine(index is not null
    ? $"nalezeno na indexu {index}"
    : "nenalezeno");
```

Tuple, `out` parametr nebo speciální "magická" hodnota jako `-1` (kterou pak musíte pamatovat a ošetřovat) — to všechno jsou způsoby, jak z metody "vrátit i informaci o neúspěchu". `int?` je čtvrtá, často nejčitelnější varianta: `null` prostě znamená "nic".

</details>

### Samostatná cvičení

1. **Základní** — Napište metodu `double? BezpecnyPodil(double a, double b)`, která vrátí `null` při dělení nulou, jinak výsledek. Vyzkoušejte s `??` na výpis náhradního textu při neúspěchu.
2. **Pokročilejší** — Vytvořte třídu `Osoba` s vlastností `Osoba Partner { get; set; }` (může být `null`). Napište výraz, který bezpečně vypíše jméno partnera partnera (`osoba?.Partner?.Partner?.Jmeno`), a vysvětlete, proč nespadne, i když v řetězci někde chybí.
3. **Bonus (*)** — Zjistěte, co dělá operátor `!` (null-forgiving operator, např. `jmeno!.Length`) v projektu se zapnutými nullable reference types, a proč se má používat jen výjimečně.
