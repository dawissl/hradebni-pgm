---
layout: post
title: ".NET C# a vývojové prostředí"
order: 6
---

## Co je .NET?

**.NET** (dříve .NET Framework, dnes .NET 6/7/8+) je platforma od Microsoftu, která poskytuje:

- **Runtime** (CLR – Common Language Runtime) – spouští zkompilovaný kód
- **Knihovny** (BCL – Base Class Library) – hotový kód pro práci se soubory, sítí, textem, kolekcemi atd.
- **Nástroje** – kompilátor, správce balíčků (NuGet), CLI

C# je jen jeden z jazyků, které na .NET běží. Dalšími jsou F# nebo Visual Basic.

### Jak funguje kompilace?

```
C# kód (.cs)
    ↓  kompilátor (Roslyn)
CIL / bytekód (.dll / .exe)
    ↓  CLR za běhu (JIT)
Strojový kód (spustí CPU)
```

> 💡 Díky tomuto přístupu může .NET běžet na Windows, macOS i Linuxu (cross-platform od .NET Core).

---

## Vývojové prostředí (IDE)

Pro vývoj v C# se nejčastěji používá **Visual Studio** od Microsoftu.

### Visual Studio Community

- **Zdarma** pro studenty, open-source projekty a jednotlivce
- Integrovaný editor, kompilátor, debugger
- IntelliSense – automatické doplňování kódu

> Aktuální verze: **Visual Studio 2022**. Stažení na [visualstudio.microsoft.com](https://visualstudio.microsoft.com/cs/vs/community/)

### Alternativy

| Nástroj | Popis |
|---|---|
| **Visual Studio Code** | Lehký editor, vhodný s rozšířením C# Dev Kit |
| **Rider** (JetBrains) | Placené IDE, oblíbené u profesionálů |
| **dotnet CLI** | Příkazová řádka – tvorba a spouštění projektů bez IDE |

---

## Vytvoření prvního projektu ve Visual Studiu

1. Otevři Visual Studio → **Vytvořit nový projekt**
2. Vyber šablonu **Console App** (konzolová aplikace)
3. Pojmenuj projekt (např. `HelloWorld`) a zvol umístění
4. Klikni **Vytvořit**

Visual Studio vygeneruje základní strukturu:

```
HelloWorld/
├── HelloWorld.sln        ← solution soubor (otevírá projekt)
└── HelloWorld/
    ├── HelloWorld.csproj ← konfigurace projektu
    └── Program.cs        ← tvůj kód
```

> ⚠️ Pro znovuotevření projektu vždy otevírej soubor `.sln`, ne `.cs`.

---

## Spuštění programu

- Tlačítko ▶ **Start** (nebo `F5`) – spustí program s debuggerem
- `Ctrl + F5` – spustí bez debuggeru (konzolové okno zůstane otevřené)

Pokud program obsahuje chybu, Visual Studio ukáže chybu v **Error List** a označí problematický řádek.

---

## IntelliSense

Při psaní kódu Visual Studio nabízí automatické doplňování:

```csharp
Console.  // ← po napsání tečky se zobrazí seznam dostupných metod
```

Klávesa `Tab` nebo `Enter` doplní vybranou možnost.

---

## Struktura solution vs. projekt

| Pojem | Popis |
|---|---|
| **Solution** (`.sln`) | Kontejner – může obsahovat více projektů |
| **Project** (`.csproj`) | Jeden program nebo knihovna |
| **Program.cs** | Hlavní soubor s kódem |

U jednoduchých cvičení bude solution i projekt jedno a to samé.

---

## Shrnutí

| Pojem | Co to je |
|---|---|
| .NET | Platforma pro běh C# programů |
| CLR | Runtime – spouští zkompilovaný kód |
| Visual Studio | Hlavní IDE pro C# vývoj |
| `.sln` | Solution soubor – otevírá celý projekt |
| IntelliSense | Automatické doplňování kódu v IDE |
