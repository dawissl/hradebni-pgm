---
layout: post
title: "Stromové struktury: BST a halda"
order: 531
---

> ⚠️ Pozor na název: v kapitole **Zásobník a halda** jsme „haldou" (heap) nazývali **paměťovou oblast**, kam se ukládají objekty. Tahle kapitola mluví o haldě jako o **datové struktuře** — něčem, co si sami naprogramujete, podobně jako `Stack<T>` nebo `Queue<T>` z kapitoly **Datové struktury a kolekce**. Je to bohužel stejné české slovo pro dva různé pojmy — v angličtině se datová struktura obvykle píše taky „heap", takže záměna existuje i v originále. Kontext vám vždy řekne, o kterou haldu jde.

---

## Strom jako datová struktura

Strom je datová struktura, kde má každý prvek (**uzel**) nejvýše jednoho rodiče a libovolný počet potomků. Nejvyšší uzel bez rodiče je **kořen**, uzly bez potomků jsou **listy**.

```
        8
      /   \
     3     10
    / \      \
   1   6      14
```

V této kapitole se podíváme na dva stromové útvary, se kterými se v praxi setkáte nejčastěji: **binární vyhledávací strom** a **haldu**.

---

## Binární vyhledávací strom (BST)

BST je strom, kde má každý uzel nejvýše dva potomky (levý a pravý), a platí pravidlo: **v levém podstromu jsou jen menší hodnoty, v pravém jen větší nebo rovné**.

```csharp
class UzelBST
{
    public int Hodnota;
    public UzelBST Vlevo;
    public UzelBST Vpravo;

    public UzelBST(int hodnota)
    {
        Hodnota = hodnota;
    }
}
```

### Vkládání

Nová hodnota se porovná s kořenem a podle výsledku pokračuje doleva nebo doprava, dokud nenajde volné místo. Zápis je přirozeně rekurzivní (kapitola **Rekurze**):

```csharp
UzelBST Vloz(UzelBST koren, int hodnota)
{
    if (koren == null)
        return new UzelBST(hodnota);   // base case — tady vznikne nový uzel

    if (hodnota < koren.Hodnota)
        koren.Vlevo = Vloz(koren.Vlevo, hodnota);
    else
        koren.Vpravo = Vloz(koren.Vpravo, hodnota);

    return koren;
}
```

```csharp
UzelBST koren = null;
foreach (int cislo in new[] { 8, 3, 10, 1, 6, 14 })
    koren = Vloz(koren, cislo);
```

Výsledek přesně odpovídá stromu nakreslenému výše — každé číslo skončí tam, kam ho zavede pravidlo „menší doleva, větší doprava".

### Vyhledávání

Stejná logika, jen místo vkládání nového uzlu vracíme, jestli jsme hodnotu našli:

```csharp
bool Obsahuje(UzelBST koren, int hodnota)
{
    if (koren == null) return false;
    if (koren.Hodnota == hodnota) return true;

    return hodnota < koren.Hodnota
        ? Obsahuje(koren.Vlevo, hodnota)
        : Obsahuje(koren.Vpravo, hodnota);
}
```

### Proč se to vyplatí — složitost

Každým krokem (doleva nebo doprava) se prohledávaný prostor **přibližně půlí** — přesně princip **O(log n)** z kapitoly **Složitost algoritmů**, stejný jako u binárního vyhledávání. Pro milion prvků tak stačí zhruba 20 kroků, ne milion.

> ⚠️ Tohle platí jen pro **vyvážený** strom. Pokud vkládáte už seřazená data (1, 2, 3, 4, 5...), strom degraduje na obyčejný seznam — každý uzel má jen pravého potomka, a hledání se zpomalí na O(n). Řešením jsou tzv. samovyvažující se stromy (AVL, red-black), které jsou nad rámec této kapitoly.

---

## Halda (heap) — datová struktura

Halda je strom se slabším, ale rychleji udržovatelným pravidlem: **rodič je vždy menší (min-halda) nebo větší (max-halda) než jeho potomci** — bez ohledu na to, který potomek je vlevo a který vpravo. Díky tomu je na kořeni vždy nejmenší (nebo největší) prvek celé haldy — okamžitě dostupný.

Halda se v praxi ukládá do obyčejného pole/listu, ne přes uzly s odkazy — pozice v poli sama určuje, kdo je čí rodič a potomek.

```csharp
List<int> halda = new List<int>();

void VlozDoHaldy(int hodnota)
{
    halda.Add(hodnota);           // nejdřív na konec
    int i = halda.Count - 1;

    while (i > 0)
    {
        int rodic = (i - 1) / 2;
        if (halda[rodic] <= halda[i])
            break;                 // rodič je menší → hotovo

        int docasna = halda[rodic];
        halda[rodic] = halda[i];
        halda[i] = docasna;        // prohození s rodičem

        i = rodic;
    }
}
```

Tomuto postupu se říká **heapify up**: nový prvek vložíme na konec a „probubláváme" ho směrem ke kořeni, dokud neplatí pravidlo haldy. Odebrání kořene funguje zrcadlově (**heapify down**): kořen nahradí poslední prvek haldy a ten se postupně prohazuje s menším z potomků, dokud pravidlo haldy zase neplatí.

> 💡 Vkládání i odebírání z haldy je **O(log n)** — stejný princip jako u BST, jen strom je vždy vyvážený "automaticky" díky pravidlu vkládání na první volné místo.

---

## BST vs. halda — kdy co použít

| | BST | Halda |
|---|---|---|
| Pravidlo | Levý podstrom < uzel ≤ pravý podstrom | Rodič ≤ (nebo ≥) oba potomci |
| Nejrychlejší přístup k | Libovolné hodnotě (vyhledávání) | Jen k minimu/maximu |
| Vhodné pro | Vyhledávání, řazené procházení | Prioritní frontu, nejmenší/největší prvek |
| Riziko | Degradace na O(n) při nevyváženém vkládání | Nehrozí — struktura pole to brání |

> 💡 Halda je základem **prioritní fronty** (vždy zpracuj nejnaléhavější položku první) a algoritmu **HeapSort**, se kterým se setkáte v kapitole **Řadící algoritmy**.

---

## Shrnutí

| Pojem | Co znamená |
|---|---|
| Strom, uzel, kořen, list | Základní pojmy stromové struktury |
| Binární vyhledávací strom (BST) | Levý podstrom menší, pravý větší/roven — rychlé vyhledávání |
| Halda (datová struktura) | Rodič vždy menší/větší než potomci — rychlý přístup k min/max |
| Heapify up / heapify down | Postup obnovení pravidla haldy po vložení / odebrání |
| Degradace BST | Nevyvážené vkládání (už seřazená data) zpomalí BST na O(n) |

---

## Otázky k zamyšlení

1. Proč se hodnoty {8, 3, 10, 1, 6, 14} vloží do BST jinak, než kdybyste je vkládali v pořadí {1, 3, 6, 8, 10, 14}? Co se stane ve druhém případě?
2. Halda garantuje rychlý přístup jen k minimu/maximu, ne k libovolné hodnotě. Kdy vám to stačí a kdy ne?
3. Proč je vkládání do BST i haldy popsáno jako O(log n), ale jen za určitého předpokladu? Jaký to je předpoklad?

---

## Procvičení

### Řešený příklad

**Zadání:** Máte pole `{15, 3, 9, 1, 20, 7}`. Postupně ho vložte do BST (v tomto pořadí) a nakreslete výsledný strom. Pak totéž vložte do min-haldy a popište, jak vypadá pole haldy po každém vložení.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

**BST** (vkládáme v pořadí 15, 3, 9, 1, 20, 7):

```
            15
          /    \
         3      20
        / \
       1   9
          /
         7
```

15 je kořen. 3 < 15 → doleva. 9 < 15, ale > 3 → doleva od 15, doprava od 3. 1 < 15, < 3 → úplně vlevo. 20 > 15 → doprava od kořene. 7 < 15, > 3, < 9 → doleva od uzlu 9.

**Min-halda** (pole, heapify up po každém vložení):

- Vlož 15 → `[15]`
- Vlož 3 → `[15, 3]` → 3 < rodič(15) → prohodit → `[3, 15]`
- Vlož 9 → `[3, 15, 9]` → rodič indexu 2 je index 0 (hodnota 3) → 9 > 3 → beze změny
- Vlož 1 → `[3, 15, 9, 1]` → rodič indexu 3 je index 1 (hodnota 15) → 1 < 15 → prohodit → `[3, 1, 9, 15]` → rodič indexu 1 je index 0 (hodnota 3) → 1 < 3 → prohodit → `[1, 3, 9, 15]`
- Vlož 20 → `[1, 3, 9, 15, 20]` → rodič indexu 4 je index 1 (hodnota 3) → 20 > 3 → beze změny
- Vlož 7 → `[1, 3, 9, 15, 20, 7]` → rodič indexu 5 je index 2 (hodnota 9) → 7 < 9 → prohodit → `[1, 3, 7, 15, 20, 9]` → rodič indexu 2 je index 0 (hodnota 1) → 7 > 1 → hotovo

Výsledná min-halda: `[1, 3, 7, 15, 20, 9]` — na indexu 0 je vždy nejmenší prvek celé haldy.

</details>

### Samostatná cvičení

1. **Základní** — Implementujte metodu `Maximum(UzelBST koren)`, která najde největší hodnotu v BST bez použití rekurze (nápověda: největší hodnota je vždy úplně vpravo).
2. **Pokročilejší** — Implementujte `VypisSetridene(UzelBST koren)`, která vypíše hodnoty BST vzestupně (nápověda: navštivte nejdřív levý podstrom, pak uzel, pak pravý podstrom — tzv. inorder průchod).
3. **Bonus (*)** — Rozšiřte kód min-haldy o metodu `OdeberMinimum()` implementující heapify down. Otestujte na haldě z řešeného příkladu a ověřte, že postupné odebírání vrátí čísla setříděná vzestupně — to je přesně princip HeapSort.
