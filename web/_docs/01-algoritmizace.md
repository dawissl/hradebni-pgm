---
layout: post
title: "Algoritmizace"
order: 10
---

Než začnete psát první řádek kódu, musíte umět **myslet jako počítač** — rozkládat problémy na jasné, přesné kroky, které lze vykonat mechanicky. Tenhle způsob myšlení se nazývá algoritmizace a je základem celého programování.

---

## Co je algoritmizace?

Algoritmizace je proces návrhu řešení problému tak, aby bylo možné ho:

- **přesně zapsat** — jednoznačně, bez dohadování
- **automaticky vykonat** — strojem nebo počítačem
- **opakovaně použít** — pro různé vstupy stejného typu

Příklad z každodenního života: recept na palačinky je algoritmus. Popisuje přesný postup — co smíchat, v jakém pořadí, jak dlouho smažit — a kdokoli ho bude následovat se stejnými surovinami, dostane (přibližně) stejný výsledek.

---

## Proč se algoritmizace učí před programováním?

Programovací jazyk je jen nástroj. Pokud nevíte, jak problém vyřešit, syntaxe jazyka rozhodně nepomůže.

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
| **Vývojový diagram** | Vizualizace větvení a cyklů | Grafické schéma se symboly (→ kapitola **Vývojové diagramy**) |
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

Algoritmizace = přesný popis postupu řešení problému. Tvoří základ každého programu — bez dobrého algoritmu nevznikne dobrý kód. V následujících kapitolách se podíváme na vlastnosti algoritmů, jejich grafický zápis a způsob, jak složité problémy rozkládat na menší části.

---

## Otázky k zamyšlení

1. Uveďte tři činnosti z běžného života, které mají povahu algoritmu, a tři, které ji nemají. Čím se liší?
2. Proč je důležité umět problém popsat algoritmicky ještě předtím, než začneme psát kód?
3. Může být algoritmus správný, ale přesto nepoužitelný v praxi? Uveďte příklad.

---

## Procvičení

### Řešený příklad

**Zadání (teoretické):** Popište slovně algoritmus pro přípravu čaje tak, aby jej zvládl vykonat i "robot", který nic nedomýšlí. Zaměřte se na to, aby žádný krok nebyl nejednoznačný.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

Ukázkové řešení (jedna z možných variant):

1. Vezmi hrnek a polož ho na stůl dnem dolů.
2. Vlož do hrnku jeden čajový sáček.
3. Naplň konvici vodou po rysku 1 litr.
4. Zapni konvici a čekej, dokud se sama nevypne.
5. Nalij vodu z konvice do hrnku, dokud hladina nebude 2 cm pod okrajem.
6. Čekej 3 minuty.
7. Vyjmi sáček z hrnku a vyhoď ho do koše.

Klíčové je, že každý krok je **konkrétní a měřitelný** ("dnem dolů", "po rysku 1 litr", "3 minuty", "2 cm pod okrajem") — robot nemá "zdravý rozum", kterým by si doplnil detaily. Přesně stejně přemýšlíme při psaní programu.

</details>

### Samostatná cvičení

1. **Základní** — Popište algoritmus pro zabalení školní tašky na zítřejší den podle rozvrhu. Nezapomeňte na rozhodovací kroky ("pokud je zítra tělocvik, pak...").
2. **Pokročilejší** — Najděte ve svém řešení z úlohy 1 všechna místa, kde se rozhodujete (podmínky), a všechna místa, kde se něco opakuje (cykly). Označte je.
3. **Bonus (*)** — Vymyslete problém, který algoritmem řešit *nelze* nebo jen velmi obtížně, a zdůvodněte proč.