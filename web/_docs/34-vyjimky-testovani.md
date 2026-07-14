---
layout: post
title: "Výjimky, ladění a testování"
order: 34
---

Každý program narazí na neočekávané situace — chybný vstup, chybějící soubor, přetečení hodnoty. Tato sekce pokrývá tři témata, která tvoří základ robustního kódu: výjimky, ladění a testování.

---

## Přehled kapitol

| Kapitola | Obsah |
|---|---|
| **35 — Výjimky** | `try-catch-finally`, typy výjimek, `throw`, vlastní výjimky |
| **36 — Ladění** | Breakpointy, krokování, Watch okno v Visual Studiu |
| **37 — Testování** | Unit testy, MSTest, základní asserty |

---

## Proč na tom záleží

Chyby v programu přicházejí ve třech formách:

**Syntaktické chyby** — kompilátor je odhalí okamžitě. Zapomenutý středník, překlep v názvu metody. Program se ani nespustí.

**Logické chyby** — program běží, ale dává špatné výsledky. Průměr počítáte dělením dvěma místo počtem prvků. Kompilátor nic nehlásí — musíte to odhalit sami testováním nebo laděním.

**Runtime chyby** — nastávají za běhu v konkrétní situaci. Uživatel zadá písmeno místo čísla, soubor neexistuje, pole přeteče. Zachytáváte je výjimkami.

Robustní program zvládá všechny tři kategorie — přesnou syntaxi, správnou logiku i ošetřené runtime chyby.

---

## Otázky k zamyšlení

1. Čím se liší chyba syntaktická, běhová (výjimka) a logická? Kterou z nich je nejtěžší najít a proč?
2. Proč nestačí program jednou spustit a "vypadá to, že funguje"? Co všechno takový test neodhalí?
3. Jak spolu souvisí výjimky, ladění a testování? Kdy v životě programu nastupuje které?

---

## Procvičení

### Řešený příklad

**Zadání (teoretické):** Program pro výpočet průměru známek spadne, když uživatel nezadá žádnou známku (dělení nulou), a vrací špatný průměr, protože programátor dělí počtem 5 místo skutečným počtem známek. Určete u obou problémů typ chyby a popište, jakým nástrojem/technikou byste každou odhalili.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

**Pád při nule známek** — *běhová chyba (výjimka)*. Program je syntakticky správně a většinou funguje, ale pro určitý vstup selže. Odhalí ji **testování krajních případů** (prázdný vstup, nula, maximum...) a v produkci ji zachytí ošetření výjimek (`try-catch`) nebo ještě lépe kontrola vstupu předem (`if (pocet == 0)`).

**Dělení pěti místo skutečného počtu** — *logická chyba*. Program nespadne, jen tiše vrací špatný výsledek — proto je nejzáludnější. Odhalí ji:
- **test se známým výsledkem**: zadám známky 1, 1, 1 → čekám průměr 1.0, program vrátí 0.6 → něco je špatně;
- **ladění**: breakpoint, krokování a sledování proměnných ukáže, že se dělí konstantou.

Poučení: výjimky hlásí problém samy a hlasitě; logické chyby musíte aktivně hledat testy s předem známými výsledky.

</details>

### Samostatná cvičení

1. **Základní** — Ke svému staršímu programu vymyslete pět testovacích vstupů: dva běžné, dva krajní a jeden nesmyslný. Zapište očekávané výsledky a ověřte je.
2. **Pokročilejší** — Vymyslete program (stačí popis), který obsahuje logickou chybu neodhalitelnou žádným jedním spuštěním s "hezkým" vstupem. Jaké testovací vstupy by ji odhalily?
3. **Bonus (*)** — Vzpomeňte si na poslední chybu, kterou jste ve svém kódu hledali dlouho. Zpětně určete její typ a napište, jaký postup by ji našel rychleji.