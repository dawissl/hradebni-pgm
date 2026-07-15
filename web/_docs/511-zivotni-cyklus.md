---
layout: post
title: "Životní cyklus vývoje programu"
order: 511
---

Až doteď jsme se soustředili na to, **jak** napsat kód — syntaxi, OOP, práci s pamětí. Tahle kapitola je jiná: nedozvíte se v ní žádnou novou syntaxi. Podíváme se na to, **v jakém pořadí a proč** se jednotlivé činnosti při vzniku skutečného programu dělají — a co se pokazí, když se pořadí přeskočí. Je to zpětné spojení věcí, které jste už viděli rozeseté v kapitolách **Dekompozice problému**, **Výjimky, ladění a testování** a **Testování** — teď dohromady, jako jeden příběh.

---

## Šest fází

| Fáze | Otázka, na kterou odpovídá | Kde jsme se s tím setkali |
|---|---|---|
| **Analýza a specifikace** | Co přesně mám vyřešit? | **Dekompozice problému** |
| **Návrh** | Jak to rozdělím na části a jaké mezi nimi budou vztahy? | **Dekompozice problému**, celý blok OOP |
| **Implementace** | Jak to zapíšu v kódu? | Většina knihy |
| **Testování a ladění** | Funguje to opravdu, i na okrajové případy? | **Testování**, **Ladění a debugging** |
| **Nasazení** | Jak se to dostane k uživateli? | — |
| **Údržba** | Co se s tím děje dalších pět let? | — |

Poslední dvě fáze jsme v knize dosud neřešili vůbec — a přitom u reálného softwaru zaberou většinu jeho života.

---

## Není to přímka

Nejdůležitější věc na těchto šesti fázích: nejdou striktně za sebou jednou a hotovo. Při implementaci zjistíte, že návrh nepočítal s nějakým případem → vrátíte se k návrhu. Při testování najdete chybu, kterou způsobila nejasná specifikace → vrátíte se k analýze. Reálný vývoj vypadá spíš jako smyčka s občasnými návraty než jako jednosměrná cesta.

```
Analýza → Návrh → Implementace → Testování
   ↑___________________________________|
              (a znovu, s dalším požadavkem)
```

Existují formální metodiky, které tohle popisují (třeba "agilní" iterace v malých kolech vs. "vodopádový" model s dlouhými fázemi po sobě) — pro naše účely stačí vědět, že *vracet se* zpátky o fázi nebo dvě je normální a zdravé, ne known selhání.

---

## Co se pokazí, když fázi vynecháte

### Přeskočená analýza → řešíte špatný problém

Vzpomeňte na příklad z kapitoly **Dekompozice problému**: *"Chci program, který spočítá průměrnou známku."* Bez jasného vstupu/výstupu/omezení (může být seznam prázdný? mohou být známky desetinné?) naprogramujete něco, co "nějak" počítá průměr — a pak se ukáže, že uživatel čekal něco jiného. Oprava po dokončení je vždy dražší než položení správné otázky na začátku.

### Přeskočený návrh → křehký kód

Kapitola **Kompozice vs. dědičnost** ukazovala třídu `DatabazeService`, která dědila od `Logger` jen proto, aby pohodlně zavolala `Log()` — rychlé řešení bez promyšleného návrhu vztahů mezi třídami. Funguje to, dokud nepřijde požadavek, který do té "rychlé" struktury nezapadá, a celá věc se musí přestavět (refaktorovat).

### Přeskočené testování → smoke test fallacy

Kapitola **Testování** popisovala přesně tohle: program vypadá hotový, protože jednou spustíte jeden vstup a vidíte správný výsledek. Funkční požadavek "lze přidávat víc položek" ale jeden test s jednou položkou nikdy neprověří.

### Přeskočená údržba (ta, na kterou se nemyslelo dopředu) → technický dluh

Tomuto se říká **technický dluh**: rychlé, "provizorní" řešení, které dnes ušetří čas, ale zítra (nebo za rok) bude nutné zaplatit navíc — buď přepsáním, nebo tím, že se na něm bude hůř stavět další funkce.

```csharp
// "Dočasné" řešení, které se stalo permanentním
void UlozUzivatele(string jmeno)
{
    // TODO: později přidat validaci, zatím to stačí takhle
    File.AppendAllText("uzivatele.txt", jmeno + "\n");
}
```

Takový kód není špatný proto, že by *teď* nefungoval — je špatný proto, že o něm nikdo neví, dokud nezpůsobí problém (duplicitní jméno, chybějící validace, soubor jako "databáze" pro tisíce záznamů), a oprava v tu chvíli bude bolet mnohem víc, než by bolelo udělat to pořádně hned.

> 💡 Technický dluh není vždy chyba — je to *vědomý* kompromis ("uděláme to rychle teď, opravíme to později"), pokud se ale "později" nikdy nedostaví, dluh se hromadí jako úrok.

---

## Údržba: fáze, o které se nejméně mluví

Naprogramovat funkci poprvé je jen zlomek celkové práce, kterou si vyžádá za celou dobu, co bude v provozu. Většina reálného softwarového inženýrství se odehrává **po** prvním nasazení: opravují se chyby nahlášené uživateli, přidávají se nové požadavky, aktualizují se závislosti (knihovny, .NET verze), refaktoruje se, když starý návrh začne škrtit.

Z toho plyne praktický důsledek pro to, jak psát kód **už teď**:

- Kód, který je testovaný (**Testování**), se dá bezpečně upravovat — testy okamžitě řeknou, jestli jste něco rozbili.
- Kód rozdělený na malé, jasně pojmenované metody (**Metody**, **Vlastní metody**) se dá upravovat po částech, ne "všechno nebo nic".
- Zdokumentované veřejné rozhraní (**XML dokumentační komentáře**) ušetří budoucímu vám (nebo kolegovi) čtení celé implementace, jen aby zjistil, co metoda dělá.
- Verzovaný kód (**Verzovací systémy a Git**) umožňuje se kdykoli vrátit k funkční verzi, když se něco pokazí.

Jinak řečeno: většina věcí, které jsme se v téhle knize učili, není samoúčelná — je to výbava pro fázi, která přijde *po* tom, co program poprvé "funguje".

---

## Shrnutí

| Fáze | Klíčová otázka | Co se pokazí při vynechání |
|---|---|---|
| Analýza | Co řeším? | Řešíte špatný problém |
| Návrh | Jak to rozdělím? | Křehký, těžko rozšiřitelný kód |
| Implementace | Jak to zapíšu? | — |
| Testování | Funguje to opravdu? | Chyby objeví až uživatel |
| Nasazení | Jak se to dostane k lidem? | — |
| Údržba | Co s tím bude za rok? | Technický dluh se hromadí |

---

## Otázky k zamyšlení

1. Proč je oprava chyby objevené v analýze levnější než oprava té samé chyby objevené po nasazení?
2. Co je "technický dluh"? Je vždy špatný nápad ho udělat?
3. Kterou ze šesti fází podle vás studenti při školních projektech nejčastěji přeskočí — a proč se jim to (krátkodobě) vyplácí?

---

## Procvičení

### Řešený příklad

**Zadání (teoretické):** Skupina studentů dostala za úkol naprogramovat rezervační systém pro školní knihovnu. Hned první den začali psát kód. Po týdnu měli fungující ukládání knih do souboru, ale zjistili, že učitel čekal evidenci *výpůjček*, ne jen seznam knih — a že jejich řešení neumí zpracovat dvě rezervace téhož výtisku najednou. Rozeberte, které fáze skupina přeskočila a jaký to mělo důsledek.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

**Přeskočená analýza:** skupina nezjistila přesně, co má program dělat ("evidence knih" vs. "evidence výpůjček" jsou různé problémy) — začali implementovat dřív, než porozuměli zadání. Důsledek: týden práce na částečně špatné věci.

**Přeskočený návrh:** neřešili, co se stane, když dva lidé chtějí půjčit tutéž knihu současně — to je přesně otázka, kterou by si vynutila fáze návrhu (kapitola **Dekompozice problému**: "jaká jsou omezení?"). Důsledek: funkční požadavek, na který přišli pozdě a bude vyžadovat přepis datové struktury.

**Poučení:** čas "ušetřený" skočením rovnou k implementaci se ztratil s úrokem — týden práce na nesprávném základu je dražší, než by bylo strávit den navíc ujasněním zadání a návrhem předem.

</details>

### Samostatná cvičení

1. **Základní** — Vezměte svůj poslední školní projekt a zpětně určete, kterou z šesti fází jste udělali důkladně a kterou přeskočili úplně. Co by se stalo, kdybyste tu přeskočenou fázi udělali?
2. **Pokročilejší** — Najděte ve vlastním starším kódu jedno místo, které byste dnes označili jako "technický dluh" (rychlé řešení, které jste nikdy nedotáhli). Popište, co by "správné" řešení obsahovalo navíc.
3. **Bonus (*)** — Zjistěte rozdíl mezi "vodopádovým" (waterfall) a "agilním" (agile) přístupem k vývoji softwaru. Který z nich lépe odpovídá tomu, jak jste doteď dělali školní projekty?
