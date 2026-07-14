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

> Aktuální verze je ke stažení na [visualstudio.microsoft.com](https://visualstudio.microsoft.com/cs/vs/community/)

### Alternativy

| Nástroj | Popis |
|---|---|
| **Visual Studio Code** | Lehký editor, vhodný s rozšířením C# Dev Kit |
| **Rider** (JetBrains) | Placené IDE, oblíbené u profesionálů |
| **dotnet CLI** | Příkazová řádka – tvorba a spouštění projektů bez IDE |

> 💡 Konkrétní instalaci Visual Studia, vytvoření prvního projektu a jeho spuštění si krok za krokem projdeme v následující kapitole **Vývojové prostředí**. Tady jde jen o to, zorientovat se v tom, co .NET a IDE vlastně jsou.

---

## Shrnutí

| Pojem | Co to je |
|---|---|
| .NET | Platforma pro běh C# programů |
| CLR | Runtime – spouští zkompilovaný kód |
| Visual Studio | Hlavní IDE pro C# vývoj |
| IntelliSense | Automatické doplňování kódu v IDE |

---

## Otázky k zamyšlení

1. Jaký je vztah mezi jazykem C# a platformou .NET? Může existovat jedno bez druhého?
2. Co je to CIL/IL (mezikód) a proč se C# nepřekládá rovnou do strojového kódu procesoru?
3. Jakou výhodu přináší, že na .NET běží více jazyků (C#, F#, VB.NET)?

---

## Procvičení

### Řešený příklad

**Zadání (teoretické):** Vysvětlěte vlastními slovy cestu programu od zdrojového kódu v C# až po běžící aplikaci na počítači. Použijte pojmy: zdrojový kód, kompilátor, IL, runtime (CLR), JIT.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

1. **Zdrojový kód** (`.cs` soubor) napíše programátor v C#.
2. **Kompilátor** (Roslyn) ho přeloží — ale ne do strojového kódu, nýbrž do **IL** (Intermediate Language), mezikódu nezávislého na konkrétním procesoru. Výsledkem je `.dll`/`.exe`.
3. Při spuštění převezme řízení **CLR** (Common Language Runtime) — běhové prostředí .NET, které se stará o paměť (garbage collector), bezpečnost a další služby.
4. **JIT** (Just-In-Time) kompilátor uvnitř CLR překládá IL do strojového kódu **až za běhu**, přesně pro procesor, na kterém program právě běží.

Díky mezikroku s IL může stejný přeložený program běžet na Windows, Linuxu i macOS — o rozdíly se postará až runtime.

</details>

### Samostatná cvičení

1. **Základní** — Vytvořte nový konzolový projekt přes `dotnet new console`, spusť ho přes `dotnet run` a najděte na disku složku s přeloženými soubory. Jakou má výsledný soubor příponu?
2. **Pokročilejší** — Zjistěte, jaká verze .NET je nainstalovaná na vašem počítači (`dotnet --info`), a vypište si tři informace, kterým z výpisu rozumíte, a jednu, které ne — tu si dohledejte.
3. **Bonus (*)** — Dohledejte, co dělá nástroj ILSpy nebo ildasm, a zkuste se podívat na IL kód svého programu "Ahoj světe".