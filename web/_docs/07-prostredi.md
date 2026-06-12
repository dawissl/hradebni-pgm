---
layout: post
title: "Vývojové prostředí"
order: 7
---

## Instalace Visual Studia

Pro vývoj v C# budeme používat **Visual Studio Community** – profesionální IDE od Microsoftu, které je zdarma pro studenty a jednotlivce.

Stáhni instalátor na [visualstudio.microsoft.com](https://visualstudio.microsoft.com/cs/vs/community/) a spusť ho.

Během instalace vyber **workload** (sadu nástrojů):

- ✅ **.NET desktop development** – pro konzolové a Windows Forms aplikace

Instalace stáhne potřebné komponenty a zabere cca 5–10 GB místa na disku. Po dokončení restartuj počítač.

> 💡 Aktuální verze je **Visual Studio 2022**. Pokud máš starší, základní principy jsou stejné.

---

## Vytvoření prvního projektu

Po spuštění Visual Studia:

1. Klikni na **Vytvořit nový projekt**
2. Do vyhledávacího pole napiš `Console` a vyber **Konzolová aplikace (Console App)**
3. Zkontroluj, že je zvolen jazyk **C#**
4. Klikni **Další**
5. Pojmenuj projekt – např. `HelloWorld`
6. Zvol umístění na disku (vytvoř složku `C# Projekty`)
7. Klikni **Vytvořit**

---

## Struktura solution a projektu

Visual Studio vytvoří tuto strukturu souborů:

```
HelloWorld/
├── HelloWorld.sln            ← solution soubor
└── HelloWorld/
    ├── HelloWorld.csproj     ← konfigurace projektu
    └── Program.cs            ← tvůj kód
```

| Soubor | Co to je |
|---|---|
| `.sln` | **Solution** – kontejner, který sdružuje projekty. Tento soubor otevírej pro znovuotevření práce. |
| `.csproj` | **Projekt** – definuje nastavení jednoho programu nebo knihovny |
| `Program.cs` | Zdrojový kód – sem píšeš C# |

> ⚠️ Pro znovuotevření projektu vždy klikni na `.sln`, ne na `.cs`.

Jedna solution může obsahovat více projektů – to využiješ např. u větších aplikací rozdělených na části.

---

## Hello World

Visual Studio vygeneruje výchozí šablonu. Nahraď obsah `Program.cs` tímto kódem:

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

Program spustíš tlačítkem ▶ **Start** (nebo klávesou `F5`).

Pokud vše proběhlo správně, otevře se černé okno konzole s textem:

```
Hello World
```

Stiskni Enter – okno se zavře.

> 💡 Zkus kód vždy **napsat ručně**, ne kopírovat. Procvičíš si práci s IDE a všimneš si IntelliSense – automatického doplňování, které se zobrazí po napsání tečky (`.`).

---

## Kdy se program spouští s debuggerem a kdy bez?

| Klávesa | Chování |
|---|---|
| `F5` | Spustí s debuggerem – konzolové okno se zavře hned po skončení programu |
| `Ctrl + F5` | Spustí bez debuggeru – okno zůstane otevřené, dokud nestiskneš klávesu |

Proto je v příkladu výše `Console.Read()` – drží okno otevřené i při `F5`.

---

## Chyba při spuštění

Pokud program nejde spustit, Visual Studio ukáže chybu v okně **Error List** (dole). Poklepáním na chybu přejdeš přesně na problematický řádek.

Nejčastější chyby začátečníků:

- chybějící středník (`;`)
- záměna velkých a malých písmen (`console` místo `Console`)
- chybějící nebo přebývající složená závorka (`{` nebo `}`)

---

## Kde najít spustitelný soubor?

Zkompilovaný `.exe` soubor tvého programu najdeš v:

```
HelloWorld > HelloWorld > bin > Debug > net8.0 > HelloWorld.exe
```
