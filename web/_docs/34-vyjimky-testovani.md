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

**Logické chyby** — program běží, ale dává špatné výsledky. Průměr počítáš dělením dvěma místo počtem prvků. Kompilátor nic nehlásí — musíš to odhalit sám testováním nebo laděním.

**Runtime chyby** — nastávají za běhu v konkrétní situaci. Uživatel zadá písmeno místo čísla, soubor neexistuje, pole přeteče. Zachytáváš je výjimkami.

Robustní program zvládá všechny tři kategorie — přesnou syntaxi, správnou logiku i ošetřené runtime chyby.
