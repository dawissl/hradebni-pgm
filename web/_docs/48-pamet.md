---
layout: post
title: "Práce s pamětí"
order: 48
---

C# spravuje paměť automaticky — nemusíš ji ručně alokovat ani uvolňovat jako v C nebo C++. Přesto je dobré rozumět tomu, jak paměť funguje. Pomůže ti to pochopit chování proměnných, vyhnout se skrytým chybám a psát efektivnější kód.

---

## Přehled kapitol o paměti

| Kapitola | Obsah |
|---|---|
| **48 — tato** | Přehled, co jsou hodnotové a referenční typy |
| **49 — Hodnotové a referenční typy** | Rozdíl v chování při kopírování a předávání |
| **50 — Zásobník a halda** | Kde se data fyzicky ukládají |
| **51 — Garbage collector** | Automatická správa paměti, `IDisposable` |

---

## Proč to vědět?

Podívej se na tento zdánlivě nevinný kód:

```csharp
int[] a = { 1, 2, 3 };
int[] b = a;
b[0] = 99;

Console.WriteLine(a[0]);  // Co se vypíše?
```

Vypíše se `99` — i když jsi měnil `b`. Proč? Protože `b` není kopie pole, ale **odkaz na stejné pole** v paměti. Tomuto chování se věnuje kapitola 49.

Nebo:

```csharp
int x = 5;
int y = x;
y = 99;

Console.WriteLine(x);  // Co se vypíše?
```

Vypíše se `5` — `y` je nezávislá kopie. Proč se pole a `int` chovají jinak? Odpověď je v rozdílu mezi **hodnotovými a referenčními typy**.

---

## Dvě kategorie typů v C#

| Hodnotové typy | Referenční typy |
|---|---|
| `int`, `double`, `bool`, `char` | Třídy (`string`, pole, vlastní třídy) |
| `struct`, `enum` | Rozhraní |
| Ukládají přímo hodnotu | Ukládají odkaz (adresu) na data |
| Kopírování = nová hodnota | Kopírování = nový odkaz na stejná data |

Podrobnosti jsou v kapitole 49. Kde v paměti se data fyzicky ukládají, vysvětluje kapitola 50.
