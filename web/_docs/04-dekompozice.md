---
layout: post
title: "Dekompozice problému"
order: 4
---

Složité problémy se neřeší najednou — rozkládají se na menší, zvládnutelné části. Tomuto přístupu se říká **dekompozice** a je jednou z nejdůležitějších dovedností programátora.

---

## Proč dekompozice?

Představte si, že máte napsat program, který spravuje knihovnu — přidávání knih, vyhledávání, výpůjčky, upomínky. Pokud se na to podíváte jako na jeden velký problém, nevíte kde začít.

Pokud to rozložíte:

```
Systém knihovny
├── Správa knih
│   ├── Přidat knihu
│   ├── Odebrat knihu
│   └── Zobrazit katalog
├── Výpůjčky
│   ├── Půjčit knihu
│   └── Vrátit knihu
└── Uživatelé
    ├── Registrace
    └── Přehled výpůjček
```

Každá část je teď samostatný, srozumitelný úkol.

---

## Postup dekompozice

### 1. Formulace problému

Nejdříve problém přesně popište. Co je vstup? Co je výstup? Jaká jsou omezení?

> **Příklad:** Chci program, který spočítá průměrnou známku žáka ze zadaných hodnot.
> - Vstup: seznam čísel (1–5)
> - Výstup: jedno číslo (průměr)
> - Omezení: prázdný seznam musí být ošetřen

### 2. Analýza

Rozložte problém na části. Ptejte se: „Co všechno musím udělat, aby to fungovalo?"

```
Výpočet průměru
├── Načíst seznam známek od uživatele
├── Zkontrolovat, že seznam není prázdný
├── Sečíst všechny hodnoty
├── Vydělit počtem hodnot
└── Zobrazit výsledek
```

### 3. Návrh algoritmu

Pro každou část navrhněte algoritmus — slovně, pseudokódem nebo vývojovým diagramem.

### 4. Implementace

Přeložte algoritmy do kódu. Díky dekompozici víte přesně, co každá část dělá — programujete ji odděleně a pak skládáte dohromady.

### 5. Testování

Otestujte každou část zvlášť i celý systém dohromady. Chybu je snazší najít v malé části než v celém programu.

---

## Příklad: Kalkulačka

**Problém:** Napište program, který od uživatele načte dvě čísla a operaci (+, -, *, /) a zobrazí výsledek.

**Dekompozice:**

```
1. Načíst vstup
   1a. Načíst první číslo
   1b. Načíst operaci
   1c. Načíst druhé číslo

2. Ověřit vstup
   2a. Jsou čísla platná?
   2b. Je operace platná?
   2c. Není dělení nulou?

3. Provést výpočet
   3a. Podle operace vyber správný výpočet

4. Zobrazit výsledek
```

Každý bod je teď jasný, ohraničený úkol. Bod 2c (dělení nulou) bychom bez dekompozice snadno zapomněli.

---

## Dekompozice a funkce

V programování se dekompozice přirozeně mapuje na **funkce** (metody) — každá část algoritmu se stane samostatnou funkcí. Ke struktuře funkcí se vrátíme podrobně v pozdějších kapitolách.

---

## Shrnutí

| Krok | Co dělám |
|---|---|
| Formulace | Přesně popíšu, co chci vyřešit |
| Analýza | Rozložím problém na menší části |
| Návrh algoritmu | Pro každou část navrhnu postup |
| Implementace | Napíšu kód |
| Testování | Ověřím, že vše funguje správně |

---

## Otázky k zamyšlení

1. Proč je snazší vyřešit deset malých problémů než jeden velký, i když je to "stejné množství práce"?
2. Jak poznáte, že je podproblém už "dost malý" a nemá smysl ho dál dělit?
3. Jak souvisí dekompozice s možností rozdělit práci v týmu?

---

## Procvičení

### Řešený příklad

**Zadání (návrhové):** Proveďte dekompozici problému "uspořádat školní turnaj v piškvorkách". Rozdělte ho na podproblémy alespoň do dvou úrovní.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

Jedna z možných dekompozic:

1. **Registrace hráčů**
   - sběr přihlášek (jméno, třída)
   - kontrola duplicit
2. **Rozlosování**
   - určení systému (pavouk / skupiny)
   - přiřazení dvojic do prvního kola
3. **Průběh zápasů**
   - pravidla jedné hry (kdo začíná, velikost hrací plochy)
   - zaznamenání výsledku
   - postup vítěze do dalšího kola
4. **Vyhodnocení**
   - určení pořadí
   - vyhlášení výsledků

Všimněte si, že každý podproblém jde řešit (a testovat!) samostatně — přesně to je cíl dekompozice. V programu by každý z bodů mohl být samostatnou metodou nebo třídou.

</details>

### Samostatná cvičení

1. **Základní** — Proveďte dekompozici problému "napéct cukroví na Vánoce" do dvou úrovní.
2. **Pokročilejší** — Proveďte dekompozici programu "jednoduchá kalkulačka pro dvě čísla". Ke každému podproblému napište, jaký má vstup a výstup.
3. **Bonus (*)** — Vezměte svou dekompozici kalkulačky a najděte podproblém, který by šel znovu použít i v úplně jiném programu. Proč je znovupoužitelnost důležitá?