---
layout: post
title: "Datové struktury a kolekce"
order: 13
---

Když program pracuje s jediným číslem nebo řetězcem, stačí jedna proměnná. Jenže reálné programy potřebují uchovávat **mnoho hodnot najednou** – seznam studentů, výsledky měření, položky košíku, historii tahů ve hře.

K tomu slouží **datové struktury** – způsoby, jak data organizovat, ukládat a efektivně zpracovávat.

---

## Proč nestačí samostatné proměnné?

Představte si, že chcete uložit skóre 30 studentů:

```csharp
int score1 = 85;
int score2 = 92;
int score3 = 78;
// ... až score30
```

To je nespravovatelné. Nemůžete to procházet cyklem, nemůžešte snadno přidat dalšího studenta, nemůžete třídit.

Řešení: **jedna proměnná, která drží víc hodnot najednou**.

---

## Přehled datových struktur v C#

### Pole (`array`)

Pevně daný počet prvků stejného typu. Rychlé, jednoduché – velikost se po vytvoření nemění.

```csharp
int[] scores = { 85, 92, 78, 90, 88 };
```

→ Detailně v kapitole **[Pole](14-pole.md)**

---

### Seznam (`List<T>`)

Dynamická kolekce – prvky lze přidávat a odebírat za běhu programu. Nejpoužívanější kolekce v praxi.

```csharp
List<string> names = new List<string> { "Kamil", "Jana" };
names.Add("Tomáš");
```

→ Detailně v kapitole **[Kolekce](/docs/15-kolekce.md)**

---

### Slovník (`Dictionary<TKey, TValue>`)

Ukládá páry **klíč → hodnota**. Vyhledávání podle klíče je velmi rychlé.

```csharp
Dictionary<string, int> grades = new Dictionary<string, int>();
grades["Kamil"] = 90;
grades["Jana"]  = 85;

Console.WriteLine(grades["Kamil"]); // 90
```

Typické použití: překlad slov, konfigurace, výsledky podle jména.

→ Detailně v kapitole **[Kolekce](./15-kolekce.md)**

---

### Fronta (`Queue<T>`)

Prvky se přidávají na konec a odebírají ze začátku – princip **FIFO** (first in, first out). Jako fronta u pokladny.

```csharp
Queue<string> queue = new Queue<string>();
queue.Enqueue("první");
queue.Enqueue("druhý");
Console.WriteLine(queue.Dequeue()); // "první"
```

---

### Zásobník (`Stack<T>`)

Prvky se přidávají i odebírají ze stejného konce – princip **LIFO** (last in, first out). Jako hromádka talířů.

```csharp
Stack<int> stack = new Stack<int>();
stack.Push(1);
stack.Push(2);
stack.Push(3);
Console.WriteLine(stack.Pop()); // 3
```

---

### Množina (`HashSet<T>`)

Kolekce **unikátních** hodnot – každý prvek může být přítomen nejvýše jednou. Duplikáty se automaticky ignorují.

```csharp
HashSet<string> tags = new HashSet<string>();
tags.Add("C#");
tags.Add("programování");
tags.Add("C#"); // ignorováno – už tam je

Console.WriteLine(tags.Count); // 2
```

---

### Řetězec (`string`)

Technicky posloupnost znaků – datová struktura pro text. Má vlastní bohatou sadu metod.

```csharp
string name = "Kamil";
Console.WriteLine(name.Length);    // 5
Console.WriteLine(name.ToUpper()); // KAMIL
```

→ Detailně v kapitole **[Řetězce](../16-retezce.md)**

---

## Hodnotové vs. referenční typy

Všechny datové struktury v C# jsou buď **hodnotový** nebo **referenční** typ – a toto rozlišení ovlivňuje, jak se chovají při přiřazení nebo předávání do metod.

### Hodnotové typy

Proměnná **drží přímo hodnotu**. Při přiřazení se vytvoří nezávislá kopie.

```csharp
int a = 5;
int b = a; // b je kopie, nezávislá na a
b = 10;

Console.WriteLine(a); // 5 – a se nezměnilo
Console.WriteLine(b); // 10
```

Hodnotové typy: `int`, `double`, `bool`, `char`, `float`, `decimal`, `struct`, `enum`

### Referenční typy

Proměnná **drží adresu** (odkaz) na místo v paměti, kde jsou data uložena. Při přiřazení se kopíruje pouze odkaz – obě proměnné pak ukazují na **stejná data**.

```csharp
int[] a = { 1, 2, 3 };
int[] b = a; // b odkazuje na stejné pole jako a

b[0] = 99;

Console.WriteLine(a[0]); // 99 – změna přes b se projevila i v a!
```

Referenční typy: `string`, pole (`array`), `List<T>`, `Dictionary`, všechny třídy

> ⚠️ Toto chování překvapí mnoho začátečníků. Pokud chcete skutečnou kopii pole, nestačí `b = a` – musíte pole zkopírovat explicitně, např. pomocí `Array.Copy()` nebo `a.ToArray()`.

---

## Jak vybrat správnou strukturu?

| Potřebuji... | Použij |
|---|---|
| Pevný počet prvků stejného typu | `array` |
| Dynamický seznam s přidáváním/odebíráním | `List<T>` |
| Vyhledávání podle klíče | `Dictionary<TKey, TValue>` |
| Zpracování v pořadí příchodu (FIFO) | `Queue<T>` |
| Zásobník – poslední dovnitř, první ven (LIFO) | `Stack<T>` |
| Unikátní hodnoty bez duplicit | `HashSet<T>` |
| Text | `string` |

---

## Shrnutí

Datové struktury jsou nástroje pro organizaci dat. Volba správné struktury ovlivňuje přehlednost kódu i výkon programu. Nejčastěji budeš pracovat s polem (`array`), listem (`List<T>`) a slovníkem (`Dictionary`). Ostatní se hodí pro specifické situace.

Detailní práce s polem, kolekcemi a řetězci přijde v následujících kapitolách.

---

## Otázky k zamyšlení

1. Proč nestačí ukládat všechna data do samostatných proměnných? Kde je hranice, za kterou už potřebujete kolekci?
2. Jaký je zásadní rozdíl mezi polem a `List<T>` z pohledu velikosti?
3. Podle čeho se rozhodujete mezi polem, Listem a Dictionary? Zformulujte pravidlo jednou větou pro každou strukturu.

---

## Procvičení

### Řešený příklad

**Zadání (návrhové):** Pro každou situaci vyberte nejvhodnější datovou strukturu (pole / `List<T>` / `Dictionary<K,V>`) a zdůvodněte: 
(a) známky žáka z jednoho předmětu přibývající během roku
(b) šachovnice 8×8
(c) telefonní seznam — hledání čísla podle jména
(d) 12 průměrných teplot po měsících.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

- **(a) známky během roku** → `List<int>` — počet předem neznáme a průběžně přidáváme; přesně na to je List stavěný.
- **(b) šachovnice** → dvourozměrné pole `char[8,8]` — velikost je pevně daná pravidly a nikdy se nezmění.
- **(c) telefonní seznam** → `Dictionary<string, string>` — potřebujeme rychle najít hodnotu (číslo) podle klíče (jména), ne procházet vše popořadě.
- **(d) teploty po měsících** → pole `double[12]` — pevný počet (12 měsíců), index 0–11 přirozeně odpovídá měsíci.

Obecné pravidlo: **pevný počet → pole, proměnlivý počet → List, vyhledávání podle klíče → Dictionary.**

</details>

### Samostatná cvičení

1. **Základní** — Vymyslete ke každé ze tří struktur (pole, List, Dictionary) jeden vlastní příklad ze života školy a zdůvodněte volbu.
2. **Pokročilejší** — Navrhněte datové struktury pro program "evidence knihovny": knihy, čtenáři, výpůjčky. U každé napište typ a co bude klíčem/prvkem.
3. **Bonus (*)** — Zjistěte, co je `HashSet<T>` a `Queue<T>`, a vymyslete situaci, kde by se hodily lépe než List.
