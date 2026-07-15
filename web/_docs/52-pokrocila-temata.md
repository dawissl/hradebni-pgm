---
layout: post
title: "Pokročilá témata"
order: 520
---

Předchozí kapitoly pokryly základy jazyka, OOP a práci se soubory. Tato sekce se věnuje tématům, která vás posunou o úroveň výš — nezbytným pro pochopení profesionálního C# kódu a přípravě na praxi.

---

## Přehled kapitol

| Kapitola | Obsah |
|---|---|
| **Složitost algoritmů** | O-notace, časová a paměťová složitost |
| **Řadící algoritmy** | Bubble sort, Selection sort, Insertion sort, vestavěné řazení |
| **Lambda funkce a LINQ** | Lambda výrazy, dotazování nad kolekcemi |
| **Verzovací systémy a Git** | Verzování kódu, základní příkazy, GitHub |

---

## Proč tato témata

**Složitost algoritmů** vám dá nástroj, jak hodnotit efektivitu kódu — bez nutnosti spouštět benchmarky. Až napíšete cyklus v cyklu a data porostou, budete vědět proč je to pomalé.

**Řadící algoritmy** jsou klasická cvičení pro pochopení algoritmického myšlení. Navíc ukáží, proč se v praxi používá vestavěné řazení a ne vlastní implementace.

**Lambda a LINQ** jsou součástí každodenního C# kódu — zpřehledňují práci s kolekcemi a odstraňují potřebu explicitních cyklů pro filtrování a transformaci dat.

**Git** je nástroj, který každý programátor používá. Bez verzování kódu přijdete o práci, přepíšete funkční kód a nebudete moct spolupracovat v týmu.

---

## Otázky k zamyšlení

1. Proč se učit teorii (složitost, algoritmy), když "všechno už je v knihovnách"? Kdy knihovní řešení nestačí?
2. Které z pokročilých témat (složitost, řazení, LINQ, Git) použijete nejdřív v praxi a proč?
3. Jak souvisí volba algoritmu s volbou datové struktury? Uveďte příklad, kdy špatná struktura zpomalí i dobrý algoritmus.

---

## Procvičení

### Řešený příklad

**Zadání (teoretické):** Aplikace pro školní jídelnu se s 50 uživateli chová svižně, ale s 5 000 uživateli je nepoužitelně pomalá. Hardware se nezměnil a kód "vypadá správně". Vysvětlete, co je pravděpodobnou příčinou, a navrhněte postup, jak problém systematicky najít.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

**Pravděpodobná příčina:** algoritmická složitost. Kód, který je *správně* (vrací správné výsledky), může být *pomalý* — např. pro každého uživatele prochází celý seznam uživatelů (O(n²)): při 50 uživatelích ~2 500 operací (neznatelné), při 5 000 už ~25 000 000. Stokrát víc uživatelů = desetitisíckrát víc práce. To je typické "funguje v testu, umírá v provozu".

**Systematický postup:**
1. **Změřit, ne hádat** — profiler nebo aspoň `Stopwatch` kolem podezřelých úseků; najít, kde se čas tráví doopravdy.
2. **Podívat se na vnořené cykly** nad rostoucími daty a na lineární hledání v `List` tam, kde by mělo být vyhledání podle klíče.
3. **Zvolit lepší strukturu/algoritmus** — např. `Dictionary` místo opakovaného `List.Find` sníží hledání z O(n) na ~O(1).
4. **Ověřit měřením znovu** na velkém vzorku dat.

Pointa kapitol, které následují: tahle diagnóza a oprava je řemeslo, které se dá naučit — složitost algoritmů je jeho jazyk.

</details>

### Samostatná cvičení

1. **Základní** — Vzpomeňte si na svůj program, který "chvíli přemýšlel". Odhadněte, kde trávil čas, a navrhněte měření, které by to potvrdilo.
2. **Pokročilejší** — Vygenerujte List se 100 000 náhodných čísel a změřte `Stopwatch`em rozdíl mezi `list.Contains(x)` v cyklu tisíckrát a stejným hledáním v `HashSet`.
3. **Bonus (*)** — Sepište si tři otázky, na které chcete znát odpověď po dokončení kapitol o složitosti, řazení a LINQ. Po jejich prostudování se k otázkám vraťte.