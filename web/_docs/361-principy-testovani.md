---
layout: post
title: "Principy testování"
order: 361
---

V kapitole **Ladění a debugging** jste se naučili najít chybu, o které už víte, že existuje. Tahle kapitola si klade otázku o krok dřív: jak vůbec systematicky přemýšlet o tom, *co* a *jak* testovat, než se v kapitole **Testování** pustíte do konkrétních technik (whitebox/blackbox, unit testy). Následujících sedm principů pochází z obecné teorie testování softwaru a platí bez ohledu na to, v jakém jazyce nebo pro jakou platformu píšete.

---

## 1. Testování odhaluje přítomnost chyb, ne jejich absenci

Test, který projde, dokazuje jen to, že program **pro tenhle konkrétní vstup** funguje. Nedokazuje, že program je bez chyb obecně — jen že jste zatím žádnou nenašli.

```
Test prošel = "nenašel jsem chybu (zatím)"
Test prošel ≠ "program je bezchybný"
```

> 💡 V kapitole **Co je algoritmus** jsme zmínili, že algoritmus musí produkovat správný výsledek pro *každý* platný vstup. Testování je způsob, jak se k tomuto ověření přiblížit — ale nikdy ho úplně nedosáhne, pokud netestujete doslova všechny možné vstupy (viz princip 2).

---

## 2. Vyčerpávající testování je nemožné

Otestovat **úplně všechny** kombinace vstupů je až na triviální případy nemožné. Metoda se dvěma parametry typu `int` má přes 18 kvintilionů možných kombinací vstupů — nikdo je všechny neprojde.

Řešením není testovat víc, ale testovat **chytřeji** — hraniční hodnoty, krajní případy, typické scénáře. Přesně to dělala analýza hraničních hodnot v kapitole **Testování**.

---

## 3. Včasné testování šetří čas i peníze

Čím později se chyba najde, tím dráž vyjde její oprava — chyba nalezená při psaní kódu stojí minuty, tatáž chyba nalezená po nasazení u zákazníka stojí hodiny ladění, komunikace a znovu-nasazení.

Z toho plyne praktický důsledek: testovací případy má smysl navrhovat **současně se specifikací**, ne až jako poslední krok před odevzdáním.

---

## 4. Shlukování chyb

V praxi se chyby nerozkládají v kódu rovnoměrně — malá část modulů/tříd/metod obsahuje neúměrně velkou část chyb (podobně jako Paretovo pravidlo 80/20: zhruba 80 % chyb pochází z 20 % kódu). Typicky jde o nejsložitější, nejčastěji měněné nebo nejnověji napsané části.

> 💡 Praktický důsledek: pokud v nějaké třídě nebo metodě už jednou byla chyba, věnujte jí při dalším testování zvýšenou pozornost — statisticky je pravděpodobnější zdroj další chyby než nedotčená část kódu.

---

## 5. Pesticidní paradox

Pokud pořád dokola spouštíte **tytéž** testy, časem přestanou nacházet nové chyby — ne proto, že by program zkrásněl, ale protože testy odhalily jen ty chyby, na které byly navržené, a program se mezitím jinam posunul. Jméno je metafora ze zemědělství: hmyz si na opakovaně používaný pesticid časem vytvoří rezistenci.

Řešením je testy **průběžně revidovat a rozšiřovat** — nové testovací případy, nové kombinace vstupů — ne jen opakovaně spouštět tu samou sadu.

---

## 6. Testování je kontextově závislé

Míra a způsob testování se liší podle toho, co program dělá. Školní konzolová aplikace na výpočet průměru snese jinou úroveň testování než řídicí software pro dopravní signalizaci nebo zdravotnický přístroj — tam chyba neznamená "nepříjemnost", ale reálné ohrožení. Neexistuje jedna univerzální "správná míra" testování — závisí na tom, co je v sázce.

---

## 7. Klam "žádné chyby"

I program bez jediné nalezené chyby, který přesně dělá to, co bylo zadáno, může být **k ničemu** — pokud zadání nebylo to, co uživatel skutečně potřeboval. Testování ověří, že program dělá to, co jste mu řekli. Neověří, že jste mu řekli tu správnou věc.

> 💡 V kapitole **Co je algoritmus** jsme se ptali, jestli může být algoritmus správný, ale nepoužitelný v praxi. Tohle je testovací obdoba té samé otázky — a odpověď je stejná: ano, může. Proto testování nikdy nenahrazuje pořádnou analýzu zadání z kapitoly **Dekompozice problému**.

---

## Shrnutí

| Princip | Jedna věta |
|---|---|
| Přítomnost, ne absence | Test dokazuje, že chyba je, nikdy že není |
| Vyčerpávající testování nemožné | Testujte chytře (hranice), ne všechno |
| Včasné testování | Čím dřív se chyba najde, tím levnější je oprava |
| Shlukování chyb | Chyby se soustředí v malé části kódu |
| Pesticidní paradox | Stejné testy dokola časem přestanou nacházet nové chyby |
| Kontextová závislost | Míra testování závisí na tom, co je v sázce |
| Klam "žádné chyby" | Bezchybný program může být přesto k ničemu |

---

## Otázky k zamyšlení

1. Proč věta "všechny testy prošly" neznamená totéž co "program je bez chyb"?
2. Co znamená pesticidní paradox a jak souvisí s tím, že se testovací sada musí čas od času obměňovat?
3. Kontextová závislost říká, že míra testování se liší podle rizika. Uveďte dva reálné příklady softwaru s velmi odlišnou potřebnou mírou testování.

---

## Procvičení

### Řešený příklad

**Zadání (teoretické):** Tým otestoval webovou aplikaci 200 automatizovanými testy, všechny prochází už měsíc bez jediného selhání. Vedení usoudilo, že aplikace je "hotová a bezchybná" a přestalo psát nové testy. O měsíc později uživatelé nahlásili vážnou chybu. Rozeberte pomocí principů z této kapitoly, co se pravděpodobně stalo.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

Dvě principy vysvětlují situaci najednou:

**Pesticidní paradox:** 200 testů, které se měsíc nemění, testují pořád dokola tytéž scénáře. Jakmile aplikaci nikdo nerozšiřuje testy o nové případy, přestávají být užitečné pro odhalování nových chyb — testují jen to, co už jednou fungovalo.

**Klam "žádné chyby":** "Všechny testy prochází" bylo mylně vyloženo jako "aplikace je bezchybná". Testy ale ověřují jen to, na co byly napsané — pokud žádný z 200 testů nepokrýval scénář, který uživatelé nakonec spustili (nová kombinace kroků, okrajový vstup), testy o té chybě nemohly nic vědět.

Správný závěr není "aplikace je hotová", ale "aplikace prochází tou sadou testů, kterou zatím máme" — a tu je potřeba průběžně rozšiřovat, ne se spokojit s tím, že stará sada dál "svítí zeleně".

</details>

### Samostatná cvičení

1. **Základní** — Vezměte program z vlastního staršího projektu. Napište tři nové testovací scénáře, které pravděpodobně dosavadní testování nepokrylo (pokud jste testovali vůbec).
2. **Pokročilejší** — Najděte v týmovém/školním projektu místo, kde platí shlukování chyb — třídu nebo metodu, která byla opravovaná nejvícekrát. Zamyslete se, proč zrovna ona.
3. **Bonus (*)** — Vymyslete konkrétní příklad softwaru, kde by "klam žádné chyby" mohl mít vážné důsledky (program dělá přesně to, co bylo zadáno, ale zadání bylo špatně). Popište, jaká by byla správná otázka na začátku, aby k tomu nedošlo.
