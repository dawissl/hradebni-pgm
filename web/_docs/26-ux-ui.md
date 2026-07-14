---
layout: post
title: "Principy UX a UI"
order: 26
---

Při tvorbě aplikací nestačí, aby program pouze fungoval. Důležité je také to, jak se uživateli používá. Přehledné ovládání, srozumitelné informace a logické uspořádání prvků mohou výrazně ovlivnit spokojenost uživatele.

Oblast návrhu uživatelského rozhraní a uživatelského zážitku označujeme zkratkami **UI** a **UX**.

---

## UX vs. UI

Ačkoli se oba pojmy často zaměňují, označují odlišné oblasti.

### UI (User Interface)

UI neboli **uživatelské rozhraní** představuje vše, co uživatel vidí a s čím přímo pracuje.

Patří sem například:

- tlačítka
- textová pole
- nabídky
- ikony
- barvy
- rozvržení obrazovky

UI odpovídá na otázku:

> Jak aplikace vypadá?

---

### UX (User Experience)

UX neboli **uživatelský zážitek** popisuje, jak se uživateli s aplikací pracuje.

Zaměřuje se například na:

- snadnost používání
- rychlost splnění úkolu
- srozumitelnost ovládání
- počet chyb, kterých se uživatel dopustí
- celkový dojem z používání

UX odpovídá na otázku:

> Jak se aplikace používá?

---

### Příklad

Aplikace může mít krásné UI, ale špatné UX.

Například tlačítko může být graficky povedené, ale pokud ho uživatel nedokáže najít, nebude aplikaci používat pohodlně.

Naopak jednoduché rozhraní může působit obyčejně, ale pokud uživatel rychle najde vše potřebné, bude mít dobré UX.

---

## Uživatel na prvním místě

Základním pravidlem UX je zaměření na uživatele.

Uživatel nepoužívá aplikaci proto, aby obdivoval její vzhled. Používá ji proto, aby splnil konkrétní úkol.

Při návrhu rozhraní je vhodné si klást otázky:

- Co chce uživatel udělat?
- Jak mu mohu úkol usnadnit?
- Jaké chyby může udělat?
- Jak mohu těmto chybám předejít?

---

## Základní pravidla návrhu formulářů

Formuláře patří mezi nejčastější součásti aplikací. Správné rozvržení výrazně ovlivňuje jejich použitelnost.

### Logické seskupování prvků

Související informace by měly být umístěny blízko sebe.

Například jméno a příjmení tvoří jednu skupinu údajů, zatímco kontaktní údaje mohou tvořit skupinu druhou.

Špatně:

```text
Jméno

Telefon

Příjmení
```

Lépe:

```text
Jméno
Příjmení

Telefon
```

---

### Konzistentní zarovnání

Prvky by měly být zarovnány jednotným způsobem.

Nepravidelné rozmístění polí a tlačítek působí nepřehledně a zhoršuje orientaci.

![formulář se správně zarovnanými poli vlevo a formulář s nepravidelně rozmístěnými poli vpravo](../assets/26-zarovnani-formulare.png)

---

### Dostatek prostoru

Jednotlivé prvky by neměly být příliš natěsnané.

Volné místo pomáhá uživateli rychleji rozpoznat strukturu formuláře.

---

### Srozumitelné popisky

Každé pole by mělo mít jasný popisek.

Lepší:

```text
Email
[____________]
```

Než:

```text
[Zadejte email]
```

Po začátku psaní totiž nápověda uvnitř pole zmizí.

---

## Čitelnost

Informace by měly být snadno čitelné na různých zařízeních.

### Vhodná velikost textu

Příliš malé písmo zhoršuje čitelnost.

Důležité informace by měly být dostatečně výrazné.

---

### Dostatečný kontrast

Text musí být dobře odlišitelný od pozadí.

Dobře:

```text
Černý text na bílém pozadí
```

Špatně:

```text
Světle šedý text na bílém pozadí
```

![ukázka dobrého kontrastu (černý text na bílém pozadí) a špatného kontrastu (světle šedý text na bílém pozadí)](../assets/26-kontrast-textu.png)

---

### Omezený počet fontů

Používání mnoha různých písem působí chaoticky.

Ve většině aplikací postačí jeden nebo dva fonty.

---

## Konzistence

Stejné prvky by měly vypadat a chovat se stejně.

Pokud jedno tlačítko ukládá data a je zelené, měla by podobně vypadat i ostatní tlačítka pro ukládání.

Uživatel si během používání vytváří očekávání a konzistence mu pomáhá rychleji se orientovat.

![sada tlačítek se stejným stylem a velikostí vedle sady tlačítek s náhodně odlišnými barvami, velikostmi a tvary](../assets/26-konzistence-ovladacich-prvku.png)

---

## Zpětná vazba uživateli

Po každé důležité akci by měl uživatel dostat informaci o výsledku.

### Úspěšná operace

```text
✓ Data byla úspěšně uložena.
```

### Chyba

```text
✗ Heslo musí obsahovat alespoň 8 znaků.
```

### Probíhající operace

```text
Načítání...
```

Bez zpětné vazby si uživatel může myslet, že aplikace nefunguje.

---

## Prevence chyb

Dobře navržené rozhraní se snaží chybám předcházet.

Mezi běžné techniky patří:

- kontrola správnosti vstupu
- omezení délky textu
- výběr z předdefinovaných možností
- potvrzení nebezpečných operací

Příklad:

```text
Opravdu chcete odstranit účet?

[ Ano ] [ Ne ]
```

---

## Nejčastější chyby začátečníků

Při návrhu rozhraní se často opakují podobné chyby.

### Příliš mnoho barev

Používání velkého množství barev odvádí pozornost a snižuje přehlednost.

### Příliš mnoho fontů

Velké množství různých písem působí neprofesionálně.

### Nekonzistentní ovládací prvky

Tlačítka různých velikostí a stylů mohou uživatele mást.

### Chybějící validace

Aplikace by měla kontrolovat správnost zadaných dat.

### Nejasné názvy tlačítek

Horší:

```text
[ OK ]
```

Lepší:

```text
[ Uložit změny ]
```

Uživatel by měl vždy vědět, co se po stisknutí tlačítka stane.

---

## Shrnutí

| Princip | Význam |
|----------|----------|
| UX | Celkový zážitek uživatele |
| UI | Vzhled uživatelského rozhraní |
| Konzistence | Stejné prvky se chovají stejně |
| Čitelnost | Informace jsou snadno čitelné |
| Zpětná vazba | Uživatel ví, co se děje |
| Prevence chyb | Chybám se snažíme předcházet |

---

## Závěr

Kvalitní uživatelské rozhraní nevzniká náhodou. Je výsledkem promyšleného návrhu, který bere ohled na potřeby uživatelů.

Při tvorbě aplikací je důležité myslet nejen na funkčnost, ale také na to, jak snadno a příjemně se bude aplikace používat. Dobré UX a UI pomáhají uživatelům rychleji dosáhnout jejich cílů a zvyšují celkovou kvalitu aplikace.

---

## Otázky k zamyšlení

1. Jaký je rozdíl mezi UI a UX? Může mít aplikace hezké UI a špatné UX? A naopak?
2. Proč je důležité, aby se ovládací prvky chovaly konzistentně s tím, na co jsou uživatelé zvyklí z jiných aplikací?
3. Co znamená, že dobré rozhraní "odpouští chyby"? Uveďte tři konkrétní mechanismy (např. potvrzení, zpět, validace).

---

## Procvičení

### Řešený příklad

**Zadání (návrhové):** Formulář pro registraci do kroužku má tyto problémy: všechna pole jsou povinná, ale nejsou označena; tlačítko "Odeslat" je aktivní i s prázdným formulářem a po chybě se celý formulář vymaže; chybová hláška zní "Error 422". Navrhněte pět konkrétních vylepšení UX.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

1. **Označit povinná pole** hvězdičkou nebo popiskem — uživatel se nemá dozvídat požadavky až z chyby.
2. **Validovat průběžně**, ne až po odeslání: např. po opuštění pole zvýraznit chybějící údaj a vysvětlit, co se čeká.
3. **Zachovat vyplněná data po chybě** — mazání správně vyplněných polí je frustrující a zvyšuje riziko, že to uživatel vzdá.
4. **Srozumitelné chybové hlášky:** místo "Error 422" napsat "E-mail nemá správný formát — zkontrolujte zavináč" — říct *co* je špatně a *jak* to opravit.
5. **Deaktivovat tlačítko Odeslat**, dokud nejsou vyplněna povinná pole (nebo ho nechat aktivní, ale po kliknutí ukázat souhrn chyb u konkrétních polí).

Společný princip: uživatel nemá hádat. Rozhraní mu má říkat, co se od něj čeká, a jeho práci chránit.

</details>

### Samostatná cvičení

1. **Základní** — Najděte ve třech aplikacích, které denně používáte, po jednom příkladu dobrého a špatného UX. Zdůvodněte.
2. **Pokročilejší** — Navrhněte na papír rozhraní jednoduché kalkulačky splátek (částka, počet měsíců, úrok → měsíční splátka). Rozmyslete rozložení, popisky, formát výsledku a chování při chybném vstupu.
3. **Bonus (*)** — Vezměte svůj návrh a "otestujte" ho na spolužákovi: dejte mu úkol a jen pozorujte, kde zaváhá. Zapište si tři zjištění.