---
layout: post
title: "Verzovací systémy a Git"
order: 560
---

Verzovací systém sleduje změny v kódu — kdo co změnil, kdy a proč. Umožňuje vrátit se k libovolné dřívější verzi, pracovat na víc věcech naráz a spolupracovat v týmu bez přepisování cizí práce.

---

## Proč verzovat

Bez verzování:

- přepíšete funkční kód a nemůžete se vrátit
- pracujete ve dvou lidech na stejném souboru a jeden přepíše druhého
- zálohy jsou složky `projekt_final`, `projekt_final2`, `projekt_final_FINAL`

S Gitem:

- každá změna je zaznamenána s popisem
- můžeš se vrátit k libovolnému stavu
- větve umožňují pracovat na nové funkci bez ovlivnění hlavního kódu

---

## Typy verzovacích systémů

| Typ | Popis | Příklad |
|---|---|---|
| Lokální | Historie jen na jednom počítači | RCS |
| Centralizovaný | Jeden sdílený server | SVN, TFS |
| Distribuovaný | Každý má plnou kopii repozitáře | **Git**, Mercurial |

Git je dnes průmyslový standard — distribuovaný, rychlý, offline schopný.

---

## Základní pojmy

| Pojem | Vysvětlení |
|---|---|
| **Repozitář (repo)** | Složka projektu sledovaná Gitem (obsahuje skrytou složku `.git`) |
| **Commit** | Snímek stavu projektu v daném čase s popisem změny |
| **Branch (větev)** | Nezávislá linie vývoje |
| **Remote** | Vzdálená kopie repozitáře (GitHub, GitLab) |
| **Clone** | Stažení celého repozitáře ze vzdáleného serveru |

---

## Základní příkazy

### Inicializace a konfigurace

```bash
# Nastavení identity (jednou pro celý počítač)
git config --global user.name "Jana Nováková"
git config --global user.email "jana@example.com"

# Vytvoření nového repozitáře ve stávající složce
git init
```

### Workflow: přidání a commitování změn

```bash
# Zjistit stav — které soubory jsou změněny
git status

# Přidat soubory do staging area (připravit k commitu)
git add soubor.cs          # konkrétní soubor
git add .                  # všechny změněné soubory

# Vytvořit commit se zprávou
git commit -m "Přidána funkce výpočtu průměru"
```

![Schéma tří zón Gitu: Working Directory → git add → Staging Area → git commit → Repozitář](../assets/git-zones.png)

### Prohlížení historie

```bash
git log                    # výpis commitů
git log --oneline          # zkrácený výpis
```

### Práce se vzdáleným repozitářem (GitHub)

```bash
# Stažení existujícího repozitáře
git clone https://github.com/uzivatel/projekt.git

# Propojení lokálního repo se vzdáleným
git remote add origin https://github.com/uzivatel/projekt.git

# Nahrání změn na GitHub
git push origin main

# Stažení změn ze vzdáleného repozitáře
git pull
```

---

## Větve (branches)

Větve umožňují pracovat na nové funkci izolovaně — hlavní větev (`main`) zůstává funkční.

```bash
# Vytvoření a přepnutí na novou větev
git checkout -b nova-funkce

# Přepnutí zpět na main
git checkout main

# Sloučení větve do main
git merge nova-funkce

# Výpis větví
git branch
```

---

## Konflikty při slučování (merge conflicts)

Sloučení (`git merge`) proběhne automaticky, pokud Git dokáže změny spojit sám. Pokud ale dva lidé (nebo dvě větve) upraví **stejný řádek stejného souboru** jinak, Git neví, která verze je správná — vznikne **konflikt**.

Git zastaví merge a do souboru vloží obě verze, oddělené značkami:

```
<<<<<<< HEAD
    int slevaProcent = 10;
=======
    int slevaProcent = 15;
>>>>>>> nova-funkce
```

- Vše mezi `<<<<<<< HEAD` a `=======` je **vaše aktuální verze**.
- Vše mezi `=======` a `>>>>>>> nova-funkce` je verze **z větve, kterou slučujete**.

### Jak konflikt vyřešit

1. Otevřete konfliktní soubor — Visual Studio konflikty zvýrazní a nabídne tlačítka pro výběr verze.
2. Rozhodněte, která verze (nebo jejich kombinace) je správná, a **smažte značky** (`<<<<<<<`, `=======`, `>>>>>>>`) i nechtěnou variantu.
3. Soubor uložte, `git add` na opravený soubor, a `git commit` — tím merge dokončíte.

```bash
git add SoubourSKonfliktem.cs
git commit -m "Vyřešen konflikt v SoubourSKonfliktem.cs"
```

> 💡 Konflikt nevzniká proto, že by Git "nefungoval" — je to Git, který si **odmítá vymýšlet**, kterou verzi jste chtěli. Rozhodnutí musí udělat člověk. Malé, časté commity a průběžné `git pull` snižují šanci, že se dvě verze stejného řádku vůbec potkají.

---

## Git v Visual Studiu

Visual Studio má integrovanou podporu Gitu — nepotřebujete příkazový řádek. Panel **Git Changes** (View → Git Changes) umožňuje commitovat, pushovat a procházet historii přímo z IDE.

![Panel Git Changes ve Visual Studiu — seznam změněných souborů, pole pro zprávu commitu, tlačítka Commit a Push](../assets/git-vs.png)

---

## Doporučené postupy

- **Commituj často** s krátkými, popisnými zprávami: `"Opravena chyba v přihlašování"` > `"fix"`
- **Jeden commit = jedna logická změna** — nesmíchávej opravu chyby s přidáním funkce
- **Nikdy necommituj hesla a API klíče** — jednou v historii, navždy dostupné
- **Používej `.gitignore`** pro ignorování build výstupů (`bin/`, `obj/`, `*.user`)

---

## Shrnutí

| Příkaz | Co dělá |
|---|---|
| `git init` | Vytvoří nový repozitář |
| `git clone <url>` | Stáhne repozitář ze vzdáleného serveru |
| `git status` | Zobrazí stav pracovního adresáře |
| `git add .` | Přidá vše do staging area |
| `git commit -m "zpráva"` | Vytvoří commit |
| `git push` | Nahraje commity na remote |
| `git pull` | Stáhne a sloučí změny z remote |
| `git checkout -b větev` | Vytvoří a přepne na novou větev |
| `git merge větev` | Sloučí větev do aktuální |
| `<<<<<<<` / `=======` / `>>>>>>>` | Značky konfliktu — Git neví, kterou verzi má vzít |

---

## Otázky k zamyšlení

1. Jaké problémy řeší verzovací systém i pro programátora, který pracuje sám? (Nápověda: "final_v2_opravdu_final.zip".)
2. Jaký je rozdíl mezi `git add`, `git commit` a `git push`? Kde se změny nacházejí po každém z těchto kroků?
3. Co je dobrá commit message? Porovnejte "update" a "Oprava dělení nulou při prázdném seznamu známek".

---

## Procvičení

### Řešený příklad

**Zadání:** Popište přesnou posloupnost git příkazů pro tento scénář: založíte nový projekt, uložíte první verzi, uděláte změnu v jednom souboru, prohlédnete si, co se změnilo, uložíte druhou verzi a nahrajete vše na GitHub (repozitář už máte na webu založený, prázdný).

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

```bash
# 1. inicializace repozitáře ve složce projektu
git init

# 2. první verze: přidat vše do stage a commitnout
git add .
git commit -m "Initial commit: kostra projektu"

# 3. ...úprava souboru Program.cs v editoru...

# 4. co se změnilo?
git status                  # které soubory jsou změněné
git diff                    # konkrétní změněné řádky

# 5. druhá verze
git add Program.cs
git commit -m "Přidán výpočet průměru známek"

# 6. propojení s GitHubem a nahrání
git remote add origin https://github.com/uzivatel/muj-projekt.git
git push -u origin main
```

Mentální model tří míst: **pracovní adresář** (vaše soubory) → `add` → **stage** (co půjde do příštího commitu) → `commit` → **lokální historie** → `push` → **GitHub**. Každý příkaz posouvá změny o jedno místo dál; `status` a `diff` vám kdykoli řeknou, kde co je.

</details>

### Samostatná cvičení

1. **Základní** — Zaverzujte svůj poslední školní projekt: `git init`, `.gitignore` pro složky `bin` a `obj`, první commit a nahrání na GitHub.
2. **Pokročilejší** — Udělejte v projektu tři commity s kvalitními zprávami, pak si `git log --oneline` vypište historii a příkazem `git diff HEAD~1` porovnejte poslední dvě verze.
3. **Bonus (*)** — Vyzkoušejte scénář "pokazil jsem soubor": změňte soubor, nedělejte commit a vraťte ho do poslední commitnuté podoby (`git restore`). Pak zjistěte, čím se liší `git restore`, `git revert` a `git reset`.