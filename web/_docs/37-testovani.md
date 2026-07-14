---
layout: post
title: "Testování"
order: 37
---

Testování ověřuje, že program dělá to, co dělat má. Bez testování zjistíte chyby až od uživatelů — a to je pozdě. Tato kapitola pokrývá základy testovací terminologie a praktický úvod do unit testů v C#.

---

## Whitebox vs. blackbox testování

| | Whitebox | Blackbox |
|---|---|---|
| Tester zná kód? | Ano | Ne |
| Co testuje | Vnitřní logiku, větve, cykly | Chování z pohledu uživatele |
| Kdo testuje | Programátor | Tester, zákazník |
| Příklad | „Projde kód větví `else` pro záporné číslo?" | „Když zadám -5, aplikace zobrazí chybovou zprávu?" |

V praxi se oba přístupy kombinují.

---

## Unit testy

Unit test ověřuje **jednu konkrétní metodu nebo funkci** — izolovaně, bez závislostí na databázi, síti nebo UI. Je rychlý, automatický a opakovatelný.

Základní pravidlo: jeden test ověřuje jednu věc.

---

## MSTest v C# — první kroky

**Přidání testovacího projektu:**
1. V Solution Explorer pravý klik na Solution → Přidat → Nový projekt
2. Vyberte **MSTest Test Project** (C#)
3. Pojmenujte ho např. `MojeAplikace.Tests`

**Struktura test projektu:**

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class KalkulackaTests
{
    [TestMethod]
    public void Secti_DveKladnaCisla_VratiSpravnyVysledek()
    {
        // Arrange — připrav vstup
        Kalkulacka k = new Kalkulacka();

        // Act — proveď akci
        int vysledek = k.Secti(3, 5);

        // Assert — ověř výsledek
        Assert.AreEqual(8, vysledek);
    }
}
```

Konvence pojmenování testů: `Co_ZaJakéPodmínky_ČehoOčekávám`.

---

## Základní asserty

| Metoda | Co ověřuje |
|---|---|
| `Assert.AreEqual(expected, actual)` | Hodnoty jsou stejné |
| `Assert.AreNotEqual(a, b)` | Hodnoty jsou různé |
| `Assert.IsTrue(podmínka)` | Výraz je `true` |
| `Assert.IsFalse(podmínka)` | Výraz je `false` |
| `Assert.IsNull(objekt)` | Objekt je `null` |
| `Assert.IsNotNull(objekt)` | Objekt není `null` |
| `Assert.ThrowsException<T>(akce)` | Akce vyhodí výjimku typu T |

---

## Příklad — testování metody s výjimkou

```csharp
public class Kalkulacka
{
    public double Vydel(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("Dělitel nesmí být nula.");
        return a / b;
    }
}
```

```csharp
[TestMethod]
public void Vydel_DelenimNulou_VyhodiVyjimku()
{
    Kalkulacka k = new Kalkulacka();

    Assert.ThrowsException<DivideByZeroException>(() => k.Vydel(10, 0));
}

[TestMethod]
public void Vydel_PlatneVstupy_VratiSpravnyVysledek()
{
    Kalkulacka k = new Kalkulacka();
    double vysledek = k.Vydel(10, 4);
    Assert.AreEqual(2.5, vysledek);
}
```

---

## Spuštění testů

`Test → Spustit všechny testy` nebo `Ctrl+R, A`. Výsledky se zobrazí v okně **Test Explorer** — zelená ✅ = úspěch, červená ❌ = selhání s popisem, co se lišilo.

---

## Proč testovat

- Odhalíte regresi — změna kódu nerozbije existující funkce
- Testy slouží jako dokumentace — jasně popisují, co metoda dělá
- Refaktoring je bezpečnější — testy hlídají, že chování zůstalo stejné
- Nutí vás psát kód, který je testovatelný — a tím i lépe navržený

---

## Pozor na „smoke test" — jedno spuštění nic nedokazuje

Nejzrádnější chyba v testování není chybějící nástroj, ale falešný pocit jistoty z jediného úspěšného běhu: *"vyzkoušel jsem to, zadal jsem hodnotu, vypsalo se to správně, takže to funguje."* Tomuto přístupu se říká **smoke test** (kouřový test) — ověří, že program „nehoří", ale nic víc. A hlavně: ověří jen **jeden vstup na jedné cestě kódu**. Řada chyb se přitom projeví až při **opakování akce** nebo **kombinaci kroků**, ne při jediném běhu.

### Příklad: funguje to — dokud to nezkusíte podruhé

V kapitole **Soubory** se ukládá nákupní seznam takto:

```csharp
File.WriteAllLines("nakup.txt", polozky);
```

Smoke test: spustíte program, zadáte "mléko", program uloží soubor, otevřete `nakup.txt` — vidíte "mléko". ✅ Vypadá to funkčně.

Jenže funkční požadavek zní: *"uživatel může do seznamu přidávat položky."* Ne *"uživatel může jednou zapsat jednu položku."* Když program spustíte znovu a přidáte "chleba", `WriteAllLines` soubor **přepíše** — "mléko" zmizí. Test s jedním vstupem tuhle chybu neodhalí, protože testoval jen jednu akci, ne posloupnost akcí, kterou má aplikace ve skutečnosti podporovat.

### Proč se to stává

Smoke test funguje jako důkaz správnosti jen tehdy, když je přesně definováno, **co má aplikace umět** — tedy až po pořádném návrhu (viz kapitola **Dekompozice a návrh**). Bez jasně zapsaného funkčního požadavku ("přidávání položek", "opakované ukládání") nemá test s čím porovnávat, a "vypadá to, že to jde" se snadno zamění za "funguje to".

### Jak testovat lépe

- Testujte **sekvence akcí**, ne jen jednorázový běh: přidat → přidat znovu → ověřit, že jsou v seznamu obě položky.
- Ptejte se: *"Co se stane, když tuto akci zopakuji?"* — přidání podruhé, uložení podruhé, kliknutí podruhé.
- Vycházejte z konkrétní specifikace: pokud zní požadavek "přidávat položky" (množné číslo!), test musí ověřit přidání **alespoň dvou**, ne jedné.
- Analýza hraničních hodnot (viz řešený příklad níže) řeší jednotlivé vstupy jedné metody; sekvenční testování řeší, jak se program chová **v čase a při opakování** — obě techniky se doplňují, žádná nenahrazuje druhou.

> ⚠️ "Spustil jsem to jednou a vypsalo to správný výsledek" je nutná, ale ne dostačující podmínka správnosti. U čehokoli, co ukládá stav (soubor, seznam, databáze), je druhé spuštění minimem, ne bonusem.

---

## Shrnutí

| Pojem | Vysvětlení |
|---|---|
| Unit test | Test jedné metody, izolovaně, automaticky |
| `[TestClass]` | Označuje třídu obsahující testy |
| `[TestMethod]` | Označuje jednu testovací metodu |
| Arrange / Act / Assert | Standardní struktura testu |
| Test Explorer | Okno Visual Studia pro spouštění a výsledky testů |
| Smoke test | Jediné spuštění s jedním vstupem — nutné, ale nikdy ne dostačující |

---

## Otázky k zamyšlení

1. Jaký je rozdíl mezi ručním a automatizovaným testem? Proč se automatizace vyplatí, i když napsání testu trvá déle než ruční ověření?
2. Co jsou krajní (hraniční) případy a proč se chyby schovávají právě v nich?
3. Co znamená, že test "prošel"? Znamená to, že je program bez chyb?
4. Proč jediné úspěšné spuštění programu s jedním vstupem nedokazuje, že funguje i požadavek "lze přidávat víc položek"? Jaký konkrétní test by chybu z tohoto typu odhalil?

---

## Procvičení

### Řešený příklad

**Zadání (návrhové):** Máte metodu `string Znamka(int body)`, která pro 0–100 bodů vrací známku podle stupnice: 90+ → "1", 75+ → "2", 60+ → "3", 45+ → "4", jinak "5"; pro vstup mimo rozsah vyhazuje výjimku. Navrhněte úplnou sadu testovacích případů (vstup → očekávaný výstup).

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

Klíčová technika: testovat **hranice a jejich okolí**, ne náhodná čísla uprostřed intervalů.

| kategorie | vstupy | očekávání |
|-----------|--------|-----------|
| hranice 1/2 | 90 → "1", 89 → "2" | přesná hranice patří lepší známce |
| hranice 2/3 | 75 → "2", 74 → "3" | |
| hranice 3/4 | 60 → "3", 59 → "4" | |
| hranice 4/5 | 45 → "4", 44 → "5" | |
| krajní platné | 0 → "5", 100 → "1" | minimum a maximum rozsahu |
| neplatné | -1, 101 | výjimka |

Dvanáct případů pokryje všechny větve i obě "brány" každé hranice. Chyby typu `>` místo `>=` odhalí právě dvojice 90/89 — test s hodnotou 95 by ji nikdy nenašel. Tomuto přístupu se říká **analýza hraničních hodnot**.

</details>

### Samostatná cvičení

1. **Základní** — Navrhněte stejným způsobem testovací případy pro metodu `bool JePrestupny(int rok)`. Nezapomeňte na roky 1900 a 2000.
2. **Pokročilejší** — Napište metodu `Znamka` ze zadání a k ní testovací program, který projde všechny případy z tabulky a vypíše PASS/FAIL pro každý.
3. **Bonus (*)** — Schválně zaveďte do metody chybu (`>` místo `>=`) a ověřte, že ji vaše testy odhalí. Kolik z nich selhalo? Co by to znamenalo, kdyby žádný?
4. **Bonus (*)** — Vezměte nákupní seznam z kapitoly **Soubory** a napište pro něj tři testovací scénáře, které smoke test (jedno spuštění, jedna položka) nikdy neodhalí — např. přidání druhé položky, opakované spuštění programu, prázdný vstup hned na začátku.