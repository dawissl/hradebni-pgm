---
layout: post
title: "Vývojové prostředí"
order: 7
---

## Instalace Visual Studia

Pro vývoj v C# budeme používat **Visual Studio Community** – profesionální IDE od Microsoftu, které je zdarma pro studenty a jednotlivce.

Stáhněte instalátor na [visualstudio.microsoft.com](https://visualstudio.microsoft.com/cs/vs/community/) a spusťte ho.

Během instalace vyberte **workload** (sadu nástrojů):

- ✅ **.NET desktop development** – pro konzolové a Windows Forms aplikace

Instalace stáhne potřebné komponenty a zabere cca 5–10 GB místa na disku. Po dokončení restartujte počítač.

> 💡 Aktuální verze je **Visual Studio 2026**. Pokud máte starší, základní principy jsou stejné.

---

## Vytvoření prvního projektu

Po spuštění Visual Studia:

1. Klikněte na **Vytvořit nový projekt**
2. Do vyhledávacího pole napište `Console` a vyberte **Konzolová aplikace (Console App)**
3. Zkontrolujte, že je zvolen jazyk **C#**
4. Klikněte **Další**
5. Pojmenujte projekt – např. `HelloWorld`
6. Zvolte umístění na disku (vytvořte složku `C# Projekty`)
7. Klikněte **Vytvořit**

---

## Struktura solution a projektu

Visual Studio vytvoří tuto strukturu souborů:

```
HelloWorld/
├── HelloWorld.sln            ← solution soubor
└── HelloWorld/
    ├── HelloWorld.csproj     ← konfigurace projektu
    └── Program.cs            ← váš kód
```

| Soubor | Co to je |
|---|---|
| `.sln` | **Solution** – kontejner, který sdružuje projekty. Tento soubor otevírejte pro znovuotevření práce. |
| `.csproj` | **Projekt** – definuje nastavení jednoho programu nebo knihovny |
| `Program.cs` | Zdrojový kód – sem píšete C# |

> ⚠️ Pro znovuotevření projektu vždy klikněte na `.sln`, ne na `.cs`.

Jedna solution může obsahovat více projektů – to využijete např. u větších aplikací rozdělených na části.

---

## Hello World

Visual Studio vygeneruje výchozí šablonu. Nahraďte obsah `Program.cs` tímto kódem:

```csharp
using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            Console.Read();
        }
    }
}
```

Program spustíte tlačítkem ▶ **Start** (nebo klávesou `F5`).

Pokud vše proběhlo správně, otevře se černé okno konzole s textem:

```
Hello World
```

Stiskněte Enter – okno se zavře.

> 💡 Zkuste kód vždy **napsat ručně**, ne kopírovat. Procvičíte si práci s IDE a všimnete si IntelliSense – automatického doplňování, které se zobrazí po napsání tečky (`.`).

---

## Kdy se program spouští s debuggerem a kdy bez?

| Klávesa | Chování |
|---|---|
| `F5` | Spustí s debuggerem – konzolové okno se zavře hned po skončení programu |
| `Ctrl + F5` | Spustí bez debuggeru – okno zůstane otevřené, dokud nestisknete klávesu |

Proto je v příkladu výše `Console.Read()` – drží okno otevřené i při `F5`.

Režim s debuggerem slouží k postupnému procházení kódu řádek po řádku. Pokud nechceme procházet celý kód od začátku, lze umístit na příslušný řádek tzv. **breakpoint**. Ten způsobí, že aplikace běží samostatně až do momentu než narazí na řádek s breakpointem. Od tohoto momentu lze kód krokovat. 

---

## Chyba při spuštění

Pokud program nejde spustit, Visual Studio ukáže chybu v okně **Error List** (dole). Poklepáním na chybu přejdete přesně na problematický řádek i soubor, pokud již pracujete s více soubory.

Nejčastější chyby začátečníků:

- chybějící středník (`;`)
- záměna velkých a malých písmen (`console` místo `Console`)
- chybějící nebo přebývající složená závorka (`{` nebo `}`)

> 💡 Pokud kód v nějaký moment vypadá jako rozsypaný čaj, lze využít kombinace klávesových zkratek ve Visual Studiu `Ctrl + K` a následně `Ctrl + D`. Tato kombinace zajistí, že se kód zarovná podle složených závorek, přidají se mezery na příslušná místa a hned je kód o něco čitelnější.


---

## Kde najít spustitelný soubor?

Zkompilovaný `.exe` soubor programu najdete v:

```
HelloWorld > HelloWorld > bin > Debug > net8.0 > HelloWorld.exe
```

---

## Otázky k zamyšlení

1. K čemu slouží breakpoint a proč je lepší než vypisování hodnot přes `Console.WriteLine`?
2. Jaký je rozdíl mezi *build* (sestavení) a *run* (spuštění) projektu?
3. IDE vám podtrhne chybu ještě před spuštěním. Jak je to možné, když program ještě neběžel?

---

## Procvičení

### Řešený příklad

**Zadání (praktické):** Popište postup, jak ve svém vývojovém prostředí (Visual Studio / VS Code / Rider) zjistíte hodnotu proměnné v polovině běhu programu, aniž byste do kódu přidával jediný řádek.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

Postup (na příkladu Visual Studia, jinde je princip stejný):

1. Klikněte do šedého sloupce vlevo od řádku, kde chcete běh zastavit — objeví se červená tečka (**breakpoint**).
2. Spusťte program v režimu ladění (**F5** / Start Debugging), ne obyčejným spuštěním.
3. Běh se na breakpointu zastaví. Hodnoty proměnných uvidíte:
   - najetím myší přímo na proměnnou v kódu,
   - v panelu **Locals** (lokální proměnné),
   - nebo zadáním výrazu do panelu **Watch**.
4. Dál můžete krokovat: **F10** (další řádek), **F11** (vstoupit do metody), **F5** (pokračovat do dalšího breakpointu).

Výhoda proti `Console.WriteLine`: nemusíte měnit kód, vidíte *všechny* proměnné najednou a můžete běh krokovat řádek po řádku.

</details>

### Samostatná cvičení

1. **Základní** — Vytvořte program se třemi proměnnými, vložte breakpoint a pomocí krokování (F10) sledujte, jak se hodnoty postupně mění.
2. **Pokročilejší** — Vyzkoušejte rozdíl mezi F10 (Step Over) a F11 (Step Into) na programu, který volá vlastní metodu. Popište vlastními slovy, co se stalo jinak.
3. **Bonus (*)** — Najděte ve svém IDE tři klávesové zkratky, které jste dosud neznali, a týden je používejte (např. přejmenování proměnné, formátování kódu, rychlá oprava).