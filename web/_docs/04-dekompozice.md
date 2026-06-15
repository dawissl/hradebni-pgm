---
layout: post
title: "Dekompozice problému"
order: 4
---

Složité problémy se neřeší najednou — rozkládají se na menší, zvládnutelné části. Tomuto přístupu se říká **dekompozice** a je jednou z nejdůležitějších dovedností programátora.

---

## Proč dekompozice?

Představ si, že máš napsat program, který spravuje knihovnu — přidávání knih, vyhledávání, výpůjčky, upomínky. Pokud se na to podíváš jako na jeden velký problém, nevíš kde začít.

Pokud to rozložíš:

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

Nejdříve problém přesně popiš. Co je vstup? Co je výstup? Jaká jsou omezení?

> **Příklad:** Chci program, který spočítá průměrnou známku žáka ze zadaných hodnot.
> - Vstup: seznam čísel (1–5)
> - Výstup: jedno číslo (průměr)
> - Omezení: prázdný seznam musí být ošetřen

### 2. Analýza

Rozlož problém na části. Ptej se: „Co všechno musím udělat, aby to fungovalo?"

```
Výpočet průměru
├── Načíst seznam známek od uživatele
├── Zkontrolovat, že seznam není prázdný
├── Sečíst všechny hodnoty
├── Vydělit počtem hodnot
└── Zobrazit výsledek
```

### 3. Návrh algoritmu

Pro každou část navrhni algoritmus — slovně, pseudokódem nebo vývojovým diagramem.

### 4. Implementace

Přelož algoritmy do kódu. Díky dekompozici víš přesně, co každá část dělá — programuješ ji odděleně a pak skládáš dohromady.

### 5. Testování

Otestuj každou část zvlášť i celý systém dohromady. Chybu je snazší najít v malé části než v celém programu.

---

## Příklad: Kalkulačka

**Problém:** Napiš program, který od uživatele načte dvě čísla a operaci (+, -, *, /) a zobrazí výsledek.

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

V programování se dekompozice přirozeně mapuje na **funkce** (metody) — každá část algoritmu se stane samostatnou funkcí. Ke struktuře funkcí se vrátíme podrobně v kapitolách 18–23.

---

## Shrnutí

| Krok | Co dělám |
|---|---|
| Formulace | Přesně popíšu, co chci vyřešit |
| Analýza | Rozložím problém na menší části |
| Návrh algoritmu | Pro každou část navrhnu postup |
| Implementace | Napíšu kód |
| Testování | Ověřím, že vše funguje správně |