---
layout: post
title: "Algoritmizace"
order: 1
---

Než začneš psát první řádek kódu, musíš umět **myslet jako počítač** — rozkládat problémy na jasné, přesné kroky, které lze vykonat mechanicky. Tenhle způsob myšlení se nazývá algoritmizace a je základem celého programování.

---

## Co je algoritmizace?

Algoritmizace je proces návrhu řešení problému tak, aby bylo možné ho:

- **přesně zapsat** — jednoznačně, bez dohadování
- **automaticky vykonat** — strojem nebo počítačem
- **opakovaně použít** — pro různé vstupy stejného typu

Příklad z každodenního života: recept na palačinky je algoritmus. Popisuje přesný postup — co smíchat, v jakém pořadí, jak dlouho péct — a kdokoli ho bude následovat se stejnými surovinami, dostane (přibližně) stejný výsledek.

---

## Proč se algoritmizace učí před programováním?

Programovací jazyk je jen nástroj. Pokud nevíš, jak problém vyřešit, syntaxe jazyka ti nepomůže.

Postup řešení každého programovacího problému vypadá takto:

1. **Porozumět problému** — co přesně chci vyřešit?
2. **Navrhnout algoritmus** — jak to vyřeším krok za krokem?
3. **Zapsat algoritmus** — slovně, diagramem nebo pseudokódem
4. **Implementovat** — přeložit algoritmus do kódu
5. **Otestovat** — funguje pro různé vstupy?

Většina začátečníků skáče rovnou na krok 4. Výsledkem je kód, který nefunguje, a programátor neví proč — protože nikdy neměl jasný plán.

---

## Zápis algoritmu

Algoritmus lze zapsat třemi způsoby:

| Způsob | Kdy se hodí | Příklad |
|---|---|---|
| **Přirozeným jazykem** | Rychlý náčrt, komunikace s ne-programátory | „Načti číslo. Pokud je kladné, vypiš ‚kladné', jinak ‚záporné'." |
| **Vývojový diagram** | Vizualizace větvení a cyklů | Grafické schéma se symboly (→ kapitola 3) |
| **Pseudokód** | Přechod k implementaci | Strukturovaný zápis připomínající kód, ale bez přesné syntaxe |

Příklad pseudokódu pro výpočet průměru dvou čísel:

```
ZAČÁTEK
  NAČTI a
  NAČTI b
  součet ← a + b
  průměr ← součet / 2
  VYPIŠ průměr
KONEC
```

Pseudokód není žádný standard — každý ho píše trochu jinak. Důležité je, aby byl **čitelný** a **jednoznačný**.

---

## Shrnutí

Algoritmizace = přesný popis postupu řešení problému. Tvoří základ každého programu — bez dobrého algoritmu nevznikne dobrý kód. V následujících kapitolách se podíváme na vlastnosti algoritmů (kapitola 2), jejich grafický zápis (kapitola 3) a způsob, jak složité problémy rozkládat na menší části (kapitola 4).