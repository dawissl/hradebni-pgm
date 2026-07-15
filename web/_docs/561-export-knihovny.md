---
layout: post
title: "Sdílení kódu — knihovny a NuGet"
order: 561
---

Představte si, že jste v kapitole **Zapouzdření** napsali třídu `BankovniUcet` a teď byste ji chtěli použít ve třech různých školních projektech. Kopírovat soubor `BankovniUcet.cs` z projektu do projektu funguje — dokud v jednom z nich neopravíte chybu a zapomenete tu samou opravu udělat i ve zbylých dvou. Řešením je zabalit třídu do **knihovny**, kterou pak projekty jen *odkazují*, ne kopírují.

---

## Co je knihovna (Class Library)

Doteď jsme vytvářeli projekty typu **Console App** — mají vlastní `Main()` a dají se spustit jako `.exe`. **Class Library** je jiný typ projektu: nemá `Main()`, nedá se spustit sama o sobě, jen se přeloží do `.dll` (Dynamic Link Library) — souboru s hotovými třídami, který si jiný projekt *přidá jako odkaz* a používá jeho třídy, jako by byly napsané přímo v něm.

### Vytvoření Class Library

1. **Přidat nový projekt** do existující solution (nebo vytvořit novou) → vyhledat šablonu **Class Library** → vybrat jazyk **C#**
2. Pojmenovat projekt, např. `Skoleni.Utils`
3. Do vygenerovaného projektu vložit své třídy — např. `BankovniUcet.cs`

Výsledná struktura solution se dvěma projekty:

```
MujProjekt.sln
├── MujProjekt/              ← Console App, obsahuje Main()
│   └── Program.cs
└── Skoleni.Utils/           ← Class Library, žádné Main()
    └── BankovniUcet.cs
```

Po sestavení (`Build`) vznikne `Skoleni.Utils.dll` — to je ten výsledný "balíček" s hotovým kódem.

---

## Project Reference — použití knihovny v jiném projektu

Aby `MujProjekt` (Console App) uměl použít třídy z `Skoleni.Utils`, musí na knihovnu **odkazovat**:

1. Pravý klik na `MujProjekt` v Solution Exploreru → **Add → Project Reference...**
2. Zaškrtnout `Skoleni.Utils`

V kódu `Program.cs` teď půjde použít `BankovniUcet`, jako by byl součástí stejného projektu:

```csharp
using Skoleni.Utils;   // jmenný prostor knihovny — kapitola Základy jazyka C#

BankovniUcet ucet = new BankovniUcet("Jana Nováková", 1000);
ucet.Vlozit(500);
```

> 💡 Pokud oprava chyby stačí udělat jen v `Skoleni.Utils`, sestavíte celou solution a **všechny** projekty, které na knihovnu odkazují, opravu dostanou automaticky. Přesně tomu se kopírováním souborů mezi projekty vyhnete.

---

## Co dát do veřejného rozhraní knihovny

Kapitola **Zapouzdření** řešila, co má být `public` a co `private` *uvnitř jedné třídy*. U knihovny se stejná otázka řeší na úrovni celého balíčku: knihovna by měla mít **jasné, úsporné veřejné rozhraní** — pár tříd a metod, které jsou určené k použití zvenčí — a všechno ostatní (pomocné třídy, detaily výpočtu) nechat jako `internal`.

```csharp
// Veřejné — je to určené k použití mimo knihovnu
public class BankovniUcet
{
    // ...
}

// Interní — pomocná třída, kterou uživatel knihovny nikdy nepotřebuje vidět
internal class UrokovaKalkulacka
{
    // ...
}
```

`internal` (modifikátor přístupu z kapitoly **Zapouzdření**) znamená "viditelné jen v rámci tohoto projektu (assembly)" — přesně to, co potřebujete pro interní pomocné třídy knihovny. Projekt, který knihovnu jen odkazuje, `UrokovaKalkulacku` ani neuvidí v IntelliSense.

> 💡 Menší, promyšlenější veřejné rozhraní znamená menší riziko, že při budoucí úpravě knihovny něco rozbijete lidem, kteří ji používají — přesně princip "černé skříňky" z kapitoly Zapouzdření, jen v měřítku celého balíčku, ne jedné třídy.

---

## NuGet — knihovny od někoho jiného

`Skoleni.Utils` je knihovna, kterou jste napsali sami a odkazujete lokálně. **NuGet** je balíčkovací systém .NET pro knihovny **od jiných lidí** — tisíce hotových, otestovaných balíčků pro cokoli od práce s JSON po generování PDF, ke stažení jedním kliknutím.

### Instalace balíčku

1. Pravý klik na projekt → **Manage NuGet Packages...**
2. Záložka **Browse**, vyhledat jméno balíčku (např. `Newtonsoft.Json`)
3. **Install**

Visual Studio stáhne balíček, přidá odkaz do `.csproj` a od teď můžete jeho třídy používat přes `using`, stejně jako vlastní knihovnu:

```xml
<!-- v .csproj, doplní se automaticky -->
<ItemGroup>
  <PackageReference Include="Newtonsoft.Json" Version="13.0.3" />
</ItemGroup>
```

> 💡 Vlastně jste s "cizím" kódem pracovali už od kapitoly **Základy jazyka C#** — celá **BCL** (Base Class Library, zmíněná v kapitole **.NET C# a vývojové prostředí**) je v podstatě obrovská sbírka hotových knihoven, které jsou součástí .NET automaticky. NuGet řeší to samé pro knihovny, které součástí .NET *nejsou*.

### Publikování vlastního balíčku (koncept)

Vlastní `Skoleni.Utils` byste teoreticky mohli zabalit (`dotnet pack`) a nahrát na [nuget.org](https://www.nuget.org), aby ji mohl přes NuGet nainstalovat kdokoli na světě, ne jen projekty ve vaší solution. Pro školní projekty se s tím běžně nesetkáte, ale je dobré vědět, že přesně tudy vznikají balíčky, které jste možná sami nainstalovali.

---

## Shrnutí

| Pojem | Co to je |
|---|---|
| Class Library | Typ projektu bez `Main()`, sestaví se do `.dll` |
| `.dll` | Sestavená knihovna s hotovými třídami k použití jinde |
| Project Reference | Odkaz jednoho projektu na jiný v téže solution |
| `public` / `internal` u knihovny | Co je určené k použití zvenčí, co je vnitřní detail |
| NuGet | Balíčkovací systém pro knihovny od jiných autorů |
| `dotnet pack` | Zabalení vlastní knihovny do NuGet balíčku |

---

## Otázky k zamyšlení

1. Proč je knihovna (Class Library) lepší způsob sdílení kódu mezi projekty než kopírování `.cs` souborů?
2. Co znamená `internal` u třídy uvnitř knihovny a proč to není totéž jako `public`?
3. Jaký je rozdíl mezi Project Reference (na `Skoleni.Utils` ve vlastní solution) a NuGet balíčkem (na `Newtonsoft.Json`)?

---

## Procvičení

### Řešený příklad

**Zadání:** Máte třídu `Teplomer` z kapitoly **Delegáti a vlastní události**. Popište kroky, jak ji přesunout do vlastní Class Library `Skoleni.Senzory` a použít ve dvou různých Console App projektech.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

1. V solution vytvořit nový projekt typu **Class Library**, pojmenovat `Skoleni.Senzory`.
2. Přesunout (nebo vytvořit) soubor `Teplomer.cs` do tohoto projektu, ujistit se, že třída `Teplomer` i její veřejné členy jsou `public`.
3. V obou Console App projektech: pravý klik → **Add → Project Reference...** → zaškrtnout `Skoleni.Senzory`.
4. V každém z nich přidat `using Skoleni.Senzory;` a použít `Teplomer` normálně:

```csharp
using Skoleni.Senzory;

Teplomer t = new Teplomer(30);
t.PrekrocenaHranice += teplota => Console.WriteLine($"Pozor, {teplota} °C!");
t.NastavTeplotu(35);
```

Klíčová výhoda: pokud v `Teplomer` opravíte chybu nebo doplníte novou událost, obě aplikace ji po přesestavení dostanou automaticky — nikdy nemusíte pamatovat, že máte tutéž třídu zkopírovanou na dvou místech.

</details>

### Samostatná cvičení

1. **Základní** — Vytvořte Class Library se třídou `MatematickePomucky` obsahující statické metody `JePrvocislo(int n)` a `Faktorial(int n)`. Odkažte ji ze dvou různých Console App projektů ve stejné solution.
2. **Pokročilejší** — Nainstalujte přes NuGet libovolný jednoduchý balíček (např. `Humanizer`) a vyzkoušejte jednu jeho metodu. Prohlédněte si `.csproj` před a po instalaci — co se změnilo?
3. **Bonus (*)** — Zjistěte, co dělá příkaz `dotnet pack` a `dotnet nuget push`, a co všechno (kromě samotného kódu) musí balíček obsahovat, aby ho šlo publikovat na nuget.org (Nápověda: verze, popis, licence).
