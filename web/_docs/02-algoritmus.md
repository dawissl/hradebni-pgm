---
layout: post
title: "Co je algoritmus"
order: 2
---

Algoritmus je přesný postup složený z konečného počtu kroků, který vede k řešení daného problému. Slovo pochází od jména perského matematika Al-Chorezmího, který žil v 9. století.

---

## Vlastnosti algoritmu

Ne každý postup je algoritmus. Aby jím byl, musí splňovat pět vlastností:

### Hromadnost

Algoritmus řeší **celou třídu problémů**, ne jen jeden konkrétní případ. Algoritmus pro výpočet obsahu obdélníku musí fungovat pro jakékoli rozměry — ne pouze pro obdélník 3 × 5.

### Determinovanost

Každý krok algoritmu je **jednoznačně definovaný** — není prostor pro interpretaci. Při stejných vstupech a stejném stavu musí algoritmus vždy provést stejný krok.

> ⚠️ Instrukce „přidej trochu soli" není deterministická. „Přidej 5 g soli" je.

### Konečnost

Algoritmus musí **skončit** — a to po konečném počtu kroků. Postup, který by mohl běžet donekonečna, algoritmem není.

### Rezultativnost

Algoritmus musí **vždy dospět k výsledku** (nebo jednoznačně oznámit, že řešení neexistuje). Nestačí, aby skončil — musí skončit smysluplně.

### Správnost

Algoritmus musí pro každý platný vstup produkovat **správný výsledek**. Tato vlastnost se ověřuje testováním.

---

## Příklad: Je to algoritmus?

**Postup A:** „Vyjdi z domu. Jdi na autobus. Nastup. Vystup na zastávce Náměstí."

❌ Není algoritmus — chybí hromadnost (funguje jen pro jednu konkrétní cestu) a determinovanost (co když autobus nejede?).

**Postup B:**
```
1. Zjisti jízdní řád linky X
2. Pokud linka jede, jdi na zastávku
3. Nastup do autobusu směr Centrum
4. Sleduj zastávky
5. Pokud aktuální zastávka = Náměstí, vystup
6. Jinak pokračuj krokem 4
```

✅ Algoritmus — hromadný (funguje pro různé dny a linky), determinovaný, konečný, rezultativní.

---

## Algoritmus v programování

V programování jsou algoritmy základní stavební kameny. Každý program je v jádru sbírka algoritmů — pro řazení dat, vyhledávání, výpočty, komunikaci se uživatelem.

Jednoduchý příklad — algoritmus pro zjištění, zda je číslo sudé:

```
1. Načti číslo n
2. Vypočítej zbytek po dělení: zbytek = n mod 2
3. Pokud zbytek = 0, vypiš "sudé"
4. Jinak vypiš "liché"
5. Konec
```

Tento algoritmus splňuje všechny vlastnosti: je hromadný (funguje pro jakékoli celé číslo), deterministický, konečný, rezultativní a správný.

---

## Shrnutí

| Vlastnost | Co znamená |
|---|---|
| Hromadnost | Řeší celou třídu problémů, ne jen jeden případ |
| Determinovanost | Každý krok je jednoznačný |
| Konečnost | Algoritmus vždy skončí |
| Rezultativnost | Vždy dospěje k výsledku |
| Správnost | Výsledek je pro daný vstup správný |