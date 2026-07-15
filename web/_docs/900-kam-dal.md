---
layout: post
title: "Kam dál?"
order: 900
---
🚧 **Tato kapitola se teprve připravuje.**

Pokud jste se dostali až sem, prošli jste cestu od „co je to vlastně algoritmus" až po generika, delegáty a vlastní knihovny. To není málo. Tahle poslední kapitola nemá učit novou syntaxi — je to mapa. C# a .NET jsou jen výchozí bod; ukážeme si, kam z něj vedou cesty, a co se z toho, co už umíte, na každé z nich přímo hodí.

---

## Co si odnášíte, ať půjdete kamkoli

Než se podíváme na konkrétní směry, stojí za to si uvědomit, že většina toho, co jste se naučili, **není specifická pro konzolové aplikace ani pro WinForms**:

- **Algoritmické myšlení** (dekompozice, složitost, ladění) — potřebné úplně všude, bez ohledu na jazyk či platformu.
- **OOP** (třídy, zapouzdření, dědičnost, polymorfismus, rozhraní) — stejné principy platí v Javě, Kotlinu, TypeScriptu i Swiftu.
- **Práce s daty** (kolekce, LINQ, generika) — tvoří jádro naprosté většiny reálných aplikací, ať běží v prohlížeči, na mobilu nebo v cloudu.
- **Návyky** (verzování, testování, čitelný kód, dokumentace) — přenositelné do jakéhokoli jazyka a týmu.

Konkrétní směry níže se liší v tom, *na čem* tyhle dovednosti použijete — ne v tom, *jestli* je použijete.

---

## Web — ASP.NET Core

Pokud vás zajímá, jak vznikají webové stránky a API na serveru, ASP.NET Core je přirozený další krok — je to stále C#, stále .NET, jen místo okna s tlačítky odpovídá na požadavky z prohlížeče.

```csharp
// Minimal API — jeden z nejjednodušších vstupních bodů do ASP.NET Core
var app = WebApplication.Create();

app.MapGet("/pozdrav/{jmeno}", (string jmeno) => $"Ahoj, {jmeno}!");

app.Run();
```

Co se přímo přenáší: třídy a objekty z **OOP bloku** (modely dat), kolekce a LINQ (zpracování dat z databáze), `try-catch` (ošetření chybných požadavků). Nové k naučení: routování (jak URL adresa najde odpovídající kód), HTTP (GET/POST a spol.), a obvykle rovnou databáze — proto další bod.

---

## Databáze — Entity Framework Core

Aplikace ze cvičení v téhle knize ukládaly data do `.txt` souborů (kapitola **Práce se soubory**) — funkční pro školní projekt, nepoužitelné pro cokoli s víc než pár desítkami záznamů. **Entity Framework Core** (EF Core) je ORM (Object-Relational Mapping) — mapuje vaše C# třídy přímo na tabulky v databázi, bez nutnosti psát SQL ručně.

```csharp
class Student
{
    public int Id { get; set; }
    public string Jmeno { get; set; }
    public double Prumer { get; set; }
}

// EF Core dovolí dotazovat databázi stejnou syntaxí jako LINQ nad List<T>
var vybornici = dbContext.Studenti.Where(s => s.Prumer <= 1.5).ToList();
```

Všimněte si, že dotaz vypadá **přesně** jako LINQ z kapitoly **Lambda funkce a LINQ** — a to je záměr. Naučit se EF Core je z devadesáti procent naučit se pár nových pojmů (`DbContext`, migrace, cizí klíče); samotné dotazování už umíte.

---

## Mobilní a desktopové aplikace — .NET MAUI

Pokud se vám líbila práce s WinForms (okna, komponenty, události — kapitoly **Grafické aplikace — WinForms** až **Dialogová okna**), ale chtěli byste, aby stejná aplikace běžela i na telefonu, **.NET MAUI** (Multi-platform App UI) je přímý nástupce — jeden C# kód, výstup pro Windows, macOS, Android i iOS.

Rozdíl oproti WinForms: rozhraní se nekreslí jen v designeru, ale primárně se zapisuje v **XAML** (deklarativní značkovací jazyk, podobný HTML):

```xml
<Button Text="Klikni na mě" Clicked="OnKliknuti" />
```

```csharp
private void OnKliknuti(object sender, EventArgs e)
{
    // stejný vzorec (object sender, EventArgs e), jaký znáte
    // z kapitoly Události a event handlery
}
```

Události, `event`/delegáti z kapitoly **Delegáti a vlastní události**, a princip „komponenta má vlastnosti a události" z kapitoly **Základní komponenty** se přenášejí téměř beze změny — mění se hlavně to, čím se rozhraní popisuje.

---

## Hry — Unity

Unity je nejpoužívanější herní engine, který jako svůj primární jazyk používá **C#**. Skript v Unity je typicky třída dědící od `MonoBehaviour`:

```csharp
using UnityEngine;

public class Hrac : MonoBehaviour
{
    public float rychlost = 5f;

    void Update()   // zavolá se automaticky každý snímek — podobně jako Tick u Timeru
    {
        float pohyb = Input.GetAxis("Horizontal") * rychlost * Time.deltaTime;
        transform.Translate(pohyb, 0, 0);
    }
}
```

Co se přenáší přímo: **celý OOP blok** (Unity je skrz naskrz objektově orientované — každý herní objekt je kompozicí komponent, přesně jako v kapitole **Kompozice vs. dědičnost**), a princip **malířova algoritmu** a smyčky "aktualizuj stav → překresli" z kapitol **Grafika a animace** a **Animace a časovač** — to je principiálně totéž, co dělá `Update()` v Unity, jen ve 3D a s hotovým enginem okolo.

---

## Další směry ve zkratce

| Oblast | Co to je | Co se přenáší nejvíc |
|---|---|---|
| **Cloud (Azure, AWS)** | Provoz aplikací na cizích serverech, ne na vlastním počítači | Práce se soubory/sítí, koncept knihoven a balíčků z kapitoly **Sdílení kódu** |
| **Testování jako profese (QA)** | Systematické ověřování kvality software | Celá kapitola **Testování** a **Ladění a debugging** — tohle už umíte |
| **DevOps** | Automatizace sestavení, testování a nasazení | **Git**, testování, představa o **životním cyklu vývoje** |
| **Datová analýza / strojové učení** | Zpracování a modelování velkých dat | LINQ, kolekce, matematické myšlení ze **Složitosti algoritmů** |

---

## Jak si vybrat

Nemusíte se rozhodnout napořád — ale pár praktických vodítek:

- **Líbilo se vám kreslit a stavět UI?** → MAUI (mobil/desktop) nebo Unity (hry).
- **Bavilo vás LINQ a práce s daty?** → ASP.NET Core + Entity Framework (web a databáze).
- **Bavilo vás ladit a hledat, proč něco nefunguje?** → testování/QA, případně DevOps.
- **Nejste si jistí?** Zkuste postavit jeden malý projekt v ASP.NET Core (nejmenší vstupní bariéra, výsledek vidíte v prohlížeči za pár minut) — i kdyby vás to nakonec nechytlo, princip "kontroler přijme požadavek, zpracuje ho, vrátí odpověď" je blízký všemu ostatnímu.

---

## Na závěr

Žádná z těchto technologií vás nenaučí přemýšlet jako programátor — to jste se naučili už v prvních kapitolách této knihy, dávno před tím, než jste napsali první řádek C#. Technologie se za pár let změní; rozklad problému na menší části, systematické testování a čitelný kód zůstávají. To jste si odnesli. Zbytek je detail, který se doučí za pochodu.
