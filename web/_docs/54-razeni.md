---
layout: post
title: "Řadící algoritmy"
order: 54
---

Řazení dat je jednou z nejčastějších operací v programování — seznam kontaktů, výsledky vyhledávání, tabulka výsledků. Tato kapitola ukáže tři základní algoritmy pro pochopení principu, jejich srovnání a pak — proč v praxi používáš vestavěné řazení.

---

## Bubble Sort

Prochází pole opakovaně a porovnává sousední prvky. Pokud jsou ve špatném pořadí, prohodí je. Po každém průchodu „probublá" největší prvek na konec.

```csharp
void BubbleSort(int[] pole)
{
    int n = pole.Length;
    for (int i = 0; i < n - 1; i++)
    {
        for (int j = 0; j < n - 1 - i; j++)
        {
            if (pole[j] > pole[j + 1])
            {
                // prohození
                int tmp = pole[j];
                pole[j] = pole[j + 1];
                pole[j + 1] = tmp;
            }
        }
    }
}
```

```csharp
int[] data = { 64, 34, 25, 12, 22, 11, 90 };
BubbleSort(data);
Console.WriteLine(string.Join(", ", data));
// 11, 12, 22, 25, 34, 64, 90
```

**Složitost:** O(n²) — cyklus v cyklu.

---

## Selection Sort

Najde nejmenší prvek a přesune ho na začátek. Pak najde druhý nejmenší a přesune na druhou pozici. Opakuje, dokud není seřazeno.

```csharp
void SelectionSort(int[] pole)
{
    int n = pole.Length;
    for (int i = 0; i < n - 1; i++)
    {
        int minIndex = i;
        for (int j = i + 1; j < n; j++)
        {
            if (pole[j] < pole[minIndex])
                minIndex = j;
        }
        // prohození nalezené minimum na pozici i
        int tmp = pole[minIndex];
        pole[minIndex] = pole[i];
        pole[i] = tmp;
    }
}
```

**Složitost:** O(n²) — vždy prochází celý zbytek, i když je pole seřazené.

---

## Insertion Sort

Prochází pole zleva doprava. Každý prvek „vloží" na správnou pozici v již seřazené části vlevo — jako třídění karet v ruce.

```csharp
void InsertionSort(int[] pole)
{
    int n = pole.Length;
    for (int i = 1; i < n; i++)
    {
        int klic = pole[i];
        int j = i - 1;

        while (j >= 0 && pole[j] > klic)
        {
            pole[j + 1] = pole[j];
            j--;
        }
        pole[j + 1] = klic;
    }
}
```

**Složitost:** O(n²) nejhorší případ, ale O(n) pro téměř seřazené pole — v praxi rychlejší než Bubble a Selection sort.

---

## Srovnání algoritmů

| Algoritmus | Nejhorší případ | Průměr | Téměř seřazené | Stabilní? |
|---|---|---|---|---|
| Bubble Sort | O(n²) | O(n²) | O(n²) | ✅ |
| Selection Sort | O(n²) | O(n²) | O(n²) | ❌ |
| Insertion Sort | O(n²) | O(n²) | **O(n)** | ✅ |
| QuickSort (vestavěný) | O(n²)* | **O(n log n)** | O(n log n) | ❌ |

*QuickSort má O(n²) nejhorší případ, ale v praxi téměř nikdy nenastane.

**Stabilní řazení** zachovává pořadí prvků se stejnou hodnotou. Důležité například při řazení tabulky nejprve podle příjmení, pak podle jména.

---

## Vestavěné řazení v C#

V praxi neimplementuješ řadící algoritmus ručně — použiješ vestavěné metody, které jsou optimalizované a otestované.

```csharp
int[] cisla = { 64, 34, 25, 12, 22, 11, 90 };
Array.Sort(cisla);
Console.WriteLine(string.Join(", ", cisla));
// 11, 12, 22, 25, 34, 64, 90

// Sestupně
Array.Sort(cisla);
Array.Reverse(cisla);

// List
List<int> seznam = new List<int> { 64, 34, 25 };
seznam.Sort();
```

### Řazení vlastních objektů

```csharp
List<string> jmena = new List<string> { "Tomáš", "Jana", "Adam" };
jmena.Sort();  // abecedně

// Vlastní pravidlo řazení (lambda — viz kapitola 55)
List<Student> studenti = GetStudenti();
studenti.Sort((a, b) => a.Prumer.CompareTo(b.Prumer));  // podle průměru
```

---

## Shrnutí

Základní algoritmy (Bubble, Selection, Insertion) jsou O(n²) a slouží hlavně k pochopení principu. Pro reálná data s tisíci a více prvky vždy použij `Array.Sort()` nebo `List.Sort()` — jsou implementovány jako Introsort (kombinace QuickSort, HeapSort, Insertion Sort) s průměrnou složitostí O(n log n).
