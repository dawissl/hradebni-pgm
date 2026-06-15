---
layout: post
title: "Testování"
order: 37
---

Testování ověřuje, že program dělá to, co dělat má. Bez testování zjistíš chyby až od uživatelů — a to je pozdě. Tato kapitola pokrývá základy testovací terminologie a praktický úvod do unit testů v C#.

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
2. Vyber **MSTest Test Project** (C#)
3. Pojmenuj ho např. `MojeAplikace.Tests`

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

- Odhalíš regresi — změna kódu nerozbije existující funkce
- Testy slouží jako dokumentace — jasně popisují, co metoda dělá
- Refaktoring je bezpečnější — testy hlídají, že chování zůstalo stejné
- Nutí tě psát kód, který je testovatelný — a tím i lépe navržený

---

## Shrnutí

| Pojem | Vysvětlení |
|---|---|
| Unit test | Test jedné metody, izolovaně, automaticky |
| `[TestClass]` | Označuje třídu obsahující testy |
| `[TestMethod]` | Označuje jednu testovací metodu |
| Arrange / Act / Assert | Standardní struktura testu |
| Test Explorer | Okno Visual Studia pro spouštění a výsledky testů |
