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
5. Pokud je aktuální zastávka Náměstí, vystup
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

---

## Otázky k zamyšlení

1. Vyjmenujte vlastnosti algoritmu (konečnost, určitost, ...) a ke každé uveďte, co by se stalo, kdyby ji algoritmus neměl.
2. Je kuchařský recept algoritmus? Které vlastnosti splňuje a které ne?
3. Dva algoritmy řeší stejnou úlohu, ale jeden potřebuje 10× více kroků. Je horší? Kdy na tom záleží a kdy ne?

---

## Procvičení

### Řešený příklad

**Zadání (teoretické):** Máte tento postup: "Vezmi číslo. Pokud je hezké, vyděl ho. Opakuj." Vysvětlete, které vlastnosti algoritmu tento postup porušuje a jak by ho šlo opravit?

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

Postup porušuje hned tři vlastnosti:

- **Určitost (determinovanost):** "pokud je hezké" není jednoznačné kritérium — každý vykonavatel by se rozhodl jinak. Oprava: např. "pokud je sudé".
- **Určitost podruhé:** "vyděl ho" neříká čím. Oprava: "vyděl ho dvěma".
- **Konečnost:** "Opakuj" bez ukončovací podmínky znamená nekonečné opakování. Oprava: "opakuj, dokud číslo není 1".

Opravená verze: *"Vezmi celé kladné číslo. Pokud je sudé, vyděl ho dvěma. Opakuj, dokud číslo není rovno 1."* — teď je postup jednoznačný a (pro mocniny dvojky) konečný.

</details>

### Samostatná cvičení

1. **Základní** — Napište vlastní příklad "špatného algoritmu", který porušuje alespoň dvě vlastnosti, a nechte spolužáka, ať chyby najde.
2. **Pokročilejší** — Slovně popište algoritmus, který najde největší číslo ze tří zadaných čísel. Ověřte, že splňuje všechny vlastnosti algoritmu.
3. **Bonus (*)** — Zamyslete se nad opravenou verzí z řešeného příkladu: je konečná pro *každé* kladné celé číslo, nebo jen pro některá? Zdůvodněte.