# Zásady používání AI nástrojů

## Základní princip

AI nástroje (ChatGPT, Claude, Copilot a podobné) jsou při práci na úlohách povoleny — s cílem, aby Vám pomáhaly **zdokonalovat vlastní schopnosti**, ne aby je nahrazovaly.

Správné použití vypadá takto:
- pomůže Vám pochopit koncept, na kterém jste se zasekli,
- ukáže Vám alternativní přístup k řešení, který sami okomentujete a zdůvodníte, proč je lepší,
- naučí Vás něco nového, co pak dokážete použít i bez AI.

Špatné použití vypadá takto:
- necháte si úlohu kompletně vygenerovat a odevzdáte řešení, kterému nerozumíte.

Tohle druhé nikdy nehodnotím dobře — ani když aplikace funkčně splňuje zadání. Umět aplikaci obhájit a vysvětlit je součástí hodnocení stejně jako to, že běží.

---

## Úrovně povolení podle typu úlohy

Pokud zadání neuvádí jinak, platí **výchozí pravidlo**:

| Typ úlohy | Úroveň |
|---|---|
| Testy, ústní zkoušení | **Bez AI** |
| Implementace v hodině, domácí úlohy, projekty | **AI jako konzultant** (výchozí) |
| Vybrané úlohy explicitně označené v zadání | **AI volně** |

U jednotlivých zadání může být uvedena výjimka z výchozí úrovně — v takovém případě platí, co je psáno v zadání.

### Co jednotlivé úrovně znamenají

**Bez AI** — AI se nepoužívá vůbec, ani na přípravu předem. Ověřuje se výhradně vaše vlastní, aktuální znalost.

**AI jako konzultant** (výchozí úroveň pro většinu úloh) — smíte ji použít na:
- vysvětlení konceptu, pojmu nebo chybové hlášky,
- code review vlastního, již napsaného řešení,
- porovnání různých přístupů a jejich kompromisů,
- vygenerování podobných cvičných úloh k procvičení.

Neměli byste ji použít na:
- vygenerování funkčního řešení celé úlohy nebo jeho podstatné části, kterou pak jen zkopírujete,
- kód, kterému sami nerozumíte a neumíte ho vysvětlit.

Orientační pravidlo: pokud vám AI vrátí kód, který rovnou vložíte do řešení, aniž byste museli přemýšlet, jak funguje — už to není konzultace, ale generování za vás.

**AI volně** — u úloh takto výslovně označených v zadání smí AI vytvořit i podstatnou část řešení. I zde ale platí povinnost použití zdokumentovat (viz níže) a schopnost řešení obhájit — svoboda použití neruší nic z toho.

---

## Jak s AI efektivně pracovat

Následující principy a příklady se týkají především úrovně **AI jako konzultant**, která platí pro většinu úloh.

### Principy

- **Nejdřív zkuste sami.** AI konzultujte ve chvíli, kdy jste se opravdu zasekli, ne jako první krok. Vlastní pokus — byť neúspěšný — je to, na čem se učíte.
- **Ptejte se na "proč", ne na "napiš mi to".** Cílem je pochopit princip, ne získat funkční kód. Pokud vám AI vrátí kód, kterému nerozumíte, je to signál, že jste se ptali špatně.
- **Nechte si vysvětlit, než použijete.** Pokud narazíte na neznámý pojem, funkci nebo konstrukci, nechte si ji vysvětlit a ověřte si pochopení na vlastním, jednodušším příkladu — až pak ji nasaďte do svého řešení.
- **Používejte AI jako code review, ne jako autora.** Napište si vlastní řešení a nechte si ho zkritizovat — kde je slabé, co by šlo zjednodušit, jaké okrajové případy chybí.
- **Vždy ověřujte.** AI se může mýlit nebo navrhnout řešení, které nesedí na váš konkrétní kontext. Kód si spusťte, otestujte, nepřebírejte automaticky.
- **Porovnávejte přístupy.** Nechte si ukázat víc způsobů řešení a jejich kompromisy — to rozvíjí rozhodování mnohem víc než jedno hotové řešení.

### Konkrétní příklady (C# / programování)

**Ladění chyby — správně:**
> „Mám tuhle chybovou hlášku a tenhle kód. Nevkládej mi opravu, jen mi vysvětli, proč k chybě dochází."

**Ladění chyby — špatně:**
> „Oprav mi tenhle kód, ať to funguje."

**Vysvětlení konceptu:**
> „Vysvětli mi, k čemu slouží `yield return` a ukaž jednoduchý ilustrační příklad — ne řešení mého zadání."

**Code review vlastního řešení:**
> „Tohle je moje implementace fronty přes `LinkedList<T>`. Zkontroluj ji a navrhni vylepšení, u každého napiš proč je lepší."

**Porovnání přístupů:**
> „Ukaž mi dva způsoby, jak implementovat Singleton v C#, a vysvětli výhody a nevýhody obou."

**Procvičování:**
> „Vygeneruj mi tři podobně obtížné úlohy na LINQ dotazy, jako je tahle, abych si to procvičil/a."

---

## Jak AI použití zdokumentovat

Podobně jako u citací zdrojů v Odborném článku (ČSN ISO 690) platí: pokud Vám AI s něčím pomohla, přiznejte to. Nejde o log promptů, ale o stručnou, čestnou poznámku. Platí pro všechny úrovně povolení — i u úloh s "AI volně" se použití dokumentuje stejně. Rozsah dokumentace se odvíjí od váhy úlohy:

- **Drobné domácí úlohy, cvičení** → jedna věta na konci řešení, např.:
  > *„ChatGPT — konzultace syntaxe LINQ."*

- **Projekty v hodině, testy s implementací** → krátký odstavec: co AI navrhla, co jste upravili/odmítli a proč.

- **Seminární/týmový projekt** → samostatná sekce v dokumentaci (v rámci Projektové zprávy / Technického přehledu): kde AI pomohla, kde selhala, jak jste výstup ověřili.

---

## Důsledky

- Pokud chybí dokumentace AI použití tam, kde je vyžadována, nelze tuto složku hodnotit známkou — je tedy klasifikována **N (neklasifikováno)**, stejně jako u neodevzdané práce. Nejde o trest, ale o to, že není co hodnotit.
- Aktivita a přístup k úloze jsou hodnoceny samostatně, se stejnou vahou, jakou měla tato složka — a to i známkou 5, pokud vzniknou důvodné pochybnosti o samostatnosti práce.
- Klasifikace N není konečná — jakmile chybějící dokumentaci dodatečně doplníte, je nahrazena odpovídající známkou.
- Obhajoba a ústní zkoušení slouží především k ověření výstupů učení — tedy k tomu, zda znalosti a dovednosti prokázané odevzdanou prací skutečně máte. Pokud při nich vyjde najevo, že řešení nedokážete vysvětlit nebo obhájit, mám právo na základě toho **přehodnotit výslednou známku za celou úlohu**, bez ohledu na to, že aplikace funkčně splňuje zadání.
