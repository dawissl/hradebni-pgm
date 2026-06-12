---
layout: post
title: "List a Dictionary"
order: 15
---

Kromě polí (`array`) nabízí C# i generické kolekce, které umožňují flexibilnější práci s daty. Nejčastěji se používají `List<T>` a `Dictionary<TKey, TValue>`.

Písmeno `T` v názvu `List<T>` je **typový parametr** – při deklaraci ho nahradíš
konkrétním datovým typem (`int`, `string`, vlastní třída…). Kompilátor pak
zajistí, že do listu nepůjde vložit nic jiného. `List<int>` přijme jen celá čísla,
`List<string>` jen řetězce. Tomuto principu se říká **generické programování**
a vrátíme se k němu podrobněji u OOP.

Totéž platí pro `Dictionary<TKey, TValue>`, kde `TKey` a `TValue` jsou dva samostatné typové parametry (klíč a hodnota mohou být různého typu).

---

## List<T>

`List<T>` je dynamická kolekce, která se může automaticky zvětšovat a zmenšovat. Na rozdíl od klasického pole není nutné dopředu znát jeho velikost.

### Vytvoření Listu

```csharp
List<int> scores = new List<int>();
List<string> names = new List<string>();
```

Zkrácená inicializace:

```csharp
List<int> scores = new List<int> { 85, 92, 78 };
List<string> names = new List<string> { "Kamil", "Jana", "Tomáš" };
```

---

### Přidávání a odebírání prvků

```csharp
List<int> scores = new List<int>();

scores.Add(85);
scores.Add(92);
scores.Add(78);

scores.Remove(92);
scores.RemoveAt(0);
```

> 💡 List se automaticky zvětšuje, není nutné řešit jeho kapacitu.

---

### Přístup přes index

```csharp
List<int> scores = new List<int> { 85, 92, 78 };

Console.WriteLine(scores[0]);
scores[1] = 100;
```

---

### Počet prvků

```csharp
Console.WriteLine(scores.Count);
```

> ⚠️ U Listu se používá `Count`, ne `Length`.

---

### Procházení Listu

```csharp
foreach (int score in scores)
{
    Console.WriteLine(score);
}
```

```csharp
for (int i = 0; i < scores.Count; i++)
{
    Console.WriteLine(scores[i]);
}
```

---

### Užitečné metody Listu

```csharp
scores.Contains(92);
scores.IndexOf(78);

scores.Sort();
scores.Reverse();
```

---

### Pole vs List

| Vlastnost | Array | List<T> |
|---|---|---|
| Velikost | pevná | dynamická |
| Přidávání prvků | ne | ano |
| Přístup přes index | ano | ano |
| Flexibilita | nízká | vysoká |

---

## Dictionary<TKey, TValue>

`Dictionary` ukládá data ve formě dvojic:

> klíč → hodnota

Každý klíč je unikátní a umožňuje rychlé vyhledávání hodnoty.

### Vytvoření Dictionary

```csharp
Dictionary<int, string> students = new Dictionary<int, string>();
```

Zkrácená inicializace:

```csharp
Dictionary<int, string> students = new Dictionary<int, string>
{
    { 1, "Kamil" },
    { 2, "Jana" },
    { 3, "Tomáš" }
};
```

---

### Přístup k hodnotám

```csharp
Console.WriteLine(students[1]);
```

> ⚠️ Pokud klíč neexistuje, vznikne výjimka `KeyNotFoundException`.

Bezpečný přístup:

```csharp
if (students.TryGetValue(2, out string name))
{
    Console.WriteLine(name);
}
```

---

### Přidávání a mazání

```csharp
students.Add(4, "Lucie");
students.Remove(2);
```

---

### Kontrola existence

```csharp
students.ContainsKey(1);
students.ContainsValue("Kamil");
```

---

### Procházení Dictionary

```csharp
foreach (var pair in students)
{
    Console.WriteLine($"ID: {pair.Key}, jméno: {pair.Value}");
}
```

---

## Kdy použít List a kdy Dictionary?

### List<T>

- když záleží na pořadí
- když pracuješ se sekvencí hodnot
- když nepotřebuješ klíče

Příklad: seznam známek, úkolů, jmen

### Dictionary<TKey, TValue>

- když potřebuješ rychlé vyhledávání
- když pracuješ s mapováním (např. ID → objekt)
- když klíč musí být unikátní

Příklad: studenti podle ID, slovník, konfigurace

---

## Kompletní příklad

```csharp
Dictionary<string, List<int>> grades = new Dictionary<string, List<int>>
{
    { "Kamil", new List<int> { 85, 90, 88 } },
    { "Jana", new List<int> { 92, 91, 89 } }
};

foreach (var student in grades)
{
    double avg = student.Value.Average();
    Console.WriteLine($"{student.Key}: {avg:F1}");
}
```

---

## Shrnutí

| Konstrukce | Použití |
|---|---|
| `List<T>` | dynamický seznam |
| `Add()` | přidání prvku |
| `Remove()` | odstranění prvku |
| `Count` | počet prvků |
| `Dictionary<TKey,TValue>` | klíč → hodnota |
| `Add(k, v)` | přidání páru |
| `TryGetValue()` | bezpečné čtení |

---

## Závěr

`List<T>` je přirozeným rozšířením pole pro situace, kdy neznáš předem velikost dat.

`Dictionary<TKey, TValue>` umožňuje modelovat vztahy mezi daty a poskytuje velmi rychlé vyhledávání.

Obě struktury jsou základním stavebním kamenem práce s daty v C#.