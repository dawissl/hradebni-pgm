---
layout: post
title: "Práce s pamětí"
order: 48
---

C# spravuje paměť automaticky — nemusíte ji ručně alokovat ani uvolňovat jako v C nebo C++. Přesto je dobré rozumět tomu, jak paměť funguje. Pomůže vám to pochopit chování proměnných, vyhnout se skrytým chybám a psát efektivnější kód.

---

## Přehled kapitol o paměti

| Kapitola | Obsah |
|---|---|
| **Práce s pamětí** (tato) | Přehled, co jsou hodnotové a referenční typy |
| **Hodnotové a referenční typy** | Rozdíl v chování při kopírování a předávání |
| **Zásobník a halda** | Kde se data fyzicky ukládají |
| **Garbage collector** | Automatická správa paměti, `IDisposable` |

---

## Proč to vědět?

Podívejte se na tento zdánlivě nevinný kód:

```csharp
int[] a = { 1, 2, 3 };
int[] b = a;
b[0] = 99;

Console.WriteLine(a[0]);  // Co se vypíše?
```

Vypíše se `99` — i když jste měnili `b`. Proč? Protože `b` není kopie pole, ale **odkaz na stejné pole** v paměti. Tomuto chování se věnuje kapitola **Hodnotové a referenční typy**.

Nebo:

```csharp
int x = 5;
int y = x;
y = 99;

Console.WriteLine(x);  // Co se vypíše?
```

Vypíše se `5` — `y` je nezávislá kopie. Proč se pole a `int` chovají jinak? Odpověď je v rozdílu mezi **hodnotovými a referenčními typy**.

---

## Dvě kategorie typů v C#

| Hodnotové typy | Referenční typy |
|---|---|
| `int`, `double`, `bool`, `char` | Třídy (`string`, pole, vlastní třídy) |
| `struct`, `enum` | Rozhraní |
| Ukládají přímo hodnotu | Ukládají odkaz (adresu) na data |
| Kopírování = nová hodnota | Kopírování = nový odkaz na stejná data |

Podrobnosti jsou v kapitole **Hodnotové a referenční typy**. Kde v paměti se data fyzicky ukládají, vysvětluje kapitola **Zásobník a halda**.

---

## Otázky k zamyšlení

1. Proč by měl programátor v C# rozumět práci s pamětí, když se o ni "stará runtime sám"?
2. Jaké dvě hlavní oblasti paměti program používá a čím se liší jejich životní cyklus?
3. Co je únik paměti (memory leak) a může nastat i v jazyce s garbage collectorem?

---

## Procvičení

### Řešený příklad

**Zadání (teoretické):** Seřaďte následující pojmy do logického příběhu o tom, co se děje v paměti při běhu programu, a příběh napište (5–8 vět): *zásobník, halda, lokální proměnná, objekt, reference, garbage collector, konec metody.*

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

Ukázkový příběh:

Když program zavolá metodu, na **zásobníku** vznikne její rámec s **lokálními proměnnými**. Jakmile metoda příkazem `new` vytvoří **objekt**, jeho data se umístí na **haldu** — na zásobník se uloží jen **reference**, tedy odkaz, kde na haldě objekt leží. S **koncem metody** se její rámec ze zásobníku okamžitě odstraní, a s ním zmizí i lokální proměnné včetně referencí. Objekt na haldě ale zůstává — dokud na něj odněkud vede reference, žije. Když poslední reference zanikne, objekt se stane nedosažitelným a dříve či později ho uklidí **garbage collector**, který haldu průběžně prohledává a uvolňuje místo po nedosažitelných objektech.

Klíčové rozlišení: zásobník se uklízí *okamžitě a deterministicky* (koncem metody), halda *později a automaticky* (rozhodnutím GC).

</details>

### Samostatná cvičení

1. **Základní** — Nakreslete stav paměti (zásobník + halda) pro kód: `Main` vytvoří `Student s = new Student("Petr");` a zavolá metodu `Vypis(s)`. Zakreslete oba rámce a šipky referencí.
2. **Pokročilejší** — Vysvětlete, proč po skončení metody `Vypis` z úlohy 1 objekt Petr stále žije, a popište okamžik, od kterého se stane kandidátem na úklid GC.
3. **Bonus (*)** — Zjistěte, co dělá `GC.GetTotalMemory(false)`, a napište program, který ukáže růst obsazené paměti při vytváření velkého množství objektů v cyklu.