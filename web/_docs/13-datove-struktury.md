---
layout: post
title: "Datové struktury a kolekce"
order: 13
---

Když program pracuje s jediným číslem nebo řetězcem, stačí jedna proměnná. Jenže reálné programy potřebují uchovávat **mnoho hodnot najednou** – seznam studentů, výsledky měření, položky košíku, historii tahů ve hře.

K tomu slouží **datové struktury** – způsoby, jak data organizovat, ukládat a efektivně zpracovávat.

---

## Proč nestačí samostatné proměnné?

Představ si, že chceš uložit skóre 30 studentů:

```csharp
int score1 = 85;
int score2 = 92;
int score3 = 78;
// ... až score30
```

To je nespravovatelné. Nemůžeš to procházet cyklem, nemůžeš snadno přidat dalšího studenta, nemůžeš třídit.

Řešení: **jedna proměnná, která drží víc hodnot najednou**.

---

## Přehled datových struktur v C#

### Pole (`array`)

Pevně daný počet prvků stejného typu. Rychlé, jednoduché – velikost se po vytvoření nemění.

```csharp
int[] scores = { 85, 92, 78, 90, 88 };
```

→ Detailně v kapitole **14 – Pole**

---

### Seznam (`List<T>`)

Dynamická kolekce – prvky lze přidávat a odebírat za běhu programu. Nejpoužívanější kolekce v praxi.

```csharp
List<string> names = new List<string> { "Kamil", "Jana" };
names.Add("Tomáš");
```

→ Detailně v kapitole **15 – Kolekce**

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

→ Detailně v kapitole **15 – Kolekce**

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

→ Detailně v kapitole **16 – Řetězce**

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

> ⚠️ Toto chování překvapí mnoho začátečníků. Pokud chceš skutečnou kopii pole, nestačí `b = a` – musíš pole zkopírovat explicitně, např. pomocí `Array.Copy()` nebo `a.ToArray()`.

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
