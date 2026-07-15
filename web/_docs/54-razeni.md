---
layout: post
title: "Řadící algoritmy"
order: 540
---

Řazení dat je jednou z nejčastějších operací v programování — seznam kontaktů, výsledky vyhledávání, tabulka výsledků. Tato kapitola ukáže tři základní algoritmy pro pochopení principu, jejich srovnání a pak — proč v praxi používáte vestavěné řazení.

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

V praxi neimplementujete řadící algoritmus ručně — použijete vestavěné metody, které jsou optimalizované a otestované.

```csharp
int[] cisla = { 64, 34, 25, 12, 22, 11, 90 };
Array.Sort(cisla);
Console.WriteLine(string.Join(", ", cisla));
// 11, 12, 22, 25, 34, 64, 90

// Sestupně — pole je už seřazené vzestupně, jen ho otočíme
Array.Reverse(cisla);

// List
List<int> seznam = new List<int> { 64, 34, 25 };
seznam.Sort();
```

### Řazení vlastních objektů

```csharp
List<string> jmena = new List<string> { "Tomáš", "Jana", "Adam" };
jmena.Sort();  // abecedně

// Vlastní pravidlo řazení (lambda — viz kapitola **Lambda funkce a LINQ**)
List<Student> studenti = GetStudenti();
studenti.Sort((a, b) => a.Prumer.CompareTo(b.Prumer));  // podle průměru
```

---

## Shrnutí

Základní algoritmy (Bubble, Selection, Insertion) jsou O(n²) a slouží hlavně k pochopení principu. Pro reálná data s tisíci a více prvky vždy použijte `Array.Sort()` nebo `List.Sort()` — jsou implementovány jako Introsort (kombinace QuickSort, HeapSort, Insertion Sort) s průměrnou složitostí O(n log n).

---

## Otázky k zamyšlení

1. Proč existuje tolik řadících algoritmů, když `Array.Sort` "prostě funguje"? Co se na nich učíme?
2. Bubble sort je O(n²), merge sort O(n log n). Proč se přesto bubble sort učí jako první?
3. Co znamená "stabilní řazení" a kdy na stabilitě záleží? (Nápověda: řazení už seřazených dat podle druhého kritéria.)

---

## Procvičení

### Řešený příklad

**Zadání:** Obrázek zachycuje první průchod bubble sortu polem `{5, 3, 8, 1, 4}`. (a) Rozepište zbývající průchody až do seřazení. (b) Implementujte bubble sort s vylepšením: pokud v průchodu nedošlo k žádné výměně, skončete.

![Bubble sort — první průchod](../assets/54-bubblesort-kroky.png)

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

**(a)** Po 1. průchodu (z obrázku): `{3, 5, 1, 4, 8}` — osmička "probublala" na konec.
- 2. průchod: `{3, 1, 4, 5, 8}` (5 doputovala na místo)
- 3. průchod: `{1, 3, 4, 5, 8}` — pole je seřazené
- 4. průchod: žádná výměna → díky vylepšení končíme.

**(b)** Implementace:

```csharp
static void BubbleSort(int[] pole)
{
    for (int i = 0; i < pole.Length - 1; i++)
    {
        bool dosloKVymene = false;

        // po i-tém průchodu je posledních i prvků na místě
        for (int j = 0; j < pole.Length - 1 - i; j++)
        {
            if (pole[j] > pole[j + 1])
            {
                (pole[j], pole[j + 1]) = (pole[j + 1], pole[j]);  // prohození
                dosloKVymene = true;
            }
        }

        if (!dosloKVymene) break;   // seřazeno – žádný další průchod není třeba
    }
}
```

Vylepšení nemění nejhorší případ (stále O(n²)), ale už seřazené pole zvládne v jediném průchodu — O(n). Všimněte si i zkracujícího se vnitřního cyklu (`- i`): konec pole je po každém průchodu hotový.

</details>

### Samostatná cvičení

1. **Základní** — Ručně (na papír) rozepište průchody bubble sortu pro pole `{9, 2, 7, 2, 6}` a spočítejte celkový počet výměn.
2. **Pokročilejší** — Implementujte selection sort (najděte minimum zbytku, prohoďte na začátek) a porovnejte s bubble sortem počet výměn na stejném náhodném poli (přidejte počítadla).
3. **Bonus (*)** — Změřte `Stopwatch`em čas bubble sortu a `Array.Sort` na poli 50 000 náhodných čísel. Kolikanásobný je rozdíl a proč?