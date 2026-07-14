---
layout: post
title: "Ladění a debugging"
order: 36
---

Ladění (debugging) je proces hledání a opravování chyb v programu. Visual Studio nabízí výkonné nástroje, které vám umožní program zastavit, zkontrolovat hodnoty proměnných a projít kód krok za krokem.

---

## Breakpoint — bod přerušení

Breakpoint je značka na řádku kódu, která říká debuggeru: „tady zastav." Program běží normálně, dokud na breakpoint nenarazí — pak se pozastaví a předá kontrolu vám.

**Přidání breakpointu:** klikněte do šedého pruhu vlevo od čísla řádku, nebo stiskněte `F9` na daném řádku. Řádek se zvýrazní červeně.

![Visual Studio s nastaveným breakpointem — červená tečka v levém okraji, zvýrazněný řádek kódu](../assets/debug-breakpoint.png)

Spusťte program v debug módu tlačítkem ▶ nebo klávesou `F5`. Jakmile program dosáhne breakpointu, pozastaví se a šipka ukáže, který řádek bude proveden jako další.

---

## Krokování

Když je program pozastaven, máte tři možnosti jak pokračovat:

| Akce | Klávesa | Co udělá |
|---|---|---|
| **Step Over** | `F10` | Provede aktuální řádek, zastaví na dalším — do volané metody nevstoupí |
| **Step Into** | `F11` | Vstoupí dovnitř volané metody |
| **Step Out** | `Shift+F11` | Doběhne do konce aktuální metody a zastaví za jejím voláním |
| **Continue** | `F5` | Pokračuje v běhu až k dalšímu breakpointu |

> 💡 `Step Over` používejte pro přeskočení metod, jejichž vnitřek vás nezajímá. `Step Into` pro vstup do konkrétní metody, kterou chcete zkontrolovat.

---

## Watch okno — sledování proměnných

Při pozastaveném programu vidíte aktuální hodnoty proměnných několika způsoby:

**Hover** — najeď myší na název proměnné v kódu. Zobrazí se tooltip s její aktuální hodnotou.

**Locals** (`Debug → Windows → Locals`) — automaticky zobrazuje všechny lokální proměnné aktuálního scope.

**Watch** (`Debug → Windows → Watch`) — přidáte konkrétní výrazy, které chcete sledovat průběžně.

![Watch okno ve Visual Studiu — seznam sledovaných proměnných s jejich aktuálními hodnotami](../assets/debug-watch.png)

---

## Immediate Window

`Debug → Windows → Immediate` (nebo `Ctrl+Alt+I`) — spustitelný příkazový řádek za běhu programu. Můžete vyhodnocovat výrazy a volat metody:

```
? seznam.Count
> 5
? Math.Sqrt(16)
> 4.0
? jmeno.ToUpper()
> "TOMÁŠ"
```

Hodí se pro rychlé otestování výrazu bez nutnosti upravovat kód.

---

## Podmíněný breakpoint

Normální breakpoint zastaví program pokaždé. Podmíněný breakpoint zastaví jen tehdy, kdy platí podmínka — neocenitelné při ladění cyklů:

Pravý klik na breakpoint → **Conditions** → zadejte podmínku, např. `i == 47`.

Program projde 46 iterací bez zastavení a zastaví se přesně tam, kde potřebujete.

---

## Časté logické chyby

| Symptom | Pravděpodobná příčina |
|---|---|
| Cyklus se neprovede ani jednou | Podmínka je `false` hned od začátku |
| Cyklus je nekonečný | Proměnná cyklu se nemění |
| Off-by-one (`< n` vs `<= n`) | Špatná hranice podmínky |
| Nesprávný výsledek výpočtu | Špatné pořadí operací, celočíselné dělení místo desetinného |
| `NullReferenceException` | Proměnná nikdy nebyla inicializována |

---

## Shrnutí

| Nástroj | Účel |
|---|---|
| Breakpoint (`F9`) | Zastaví program na daném řádku |
| Step Over (`F10`) | Provede řádek, nevstoupí do metody |
| Step Into (`F11`) | Vstoupí dovnitř volané metody |
| Locals / Watch | Zobrazí hodnoty proměnných |
| Immediate Window | Spustí výraz za běhu |
| Podmíněný breakpoint | Zastaví jen při splnění podmínky |

---

## Otázky k zamyšlení

1. Proč je krokování debuggeru spolehlivější než "čtení kódu očima", i když jste si jistí, co kód dělá?
2. Co je podmíněný breakpoint a kdy vám ušetří desítky minut? (Např. chyba nastává až ve 500. průchodu cyklem.)
3. Jak ladit chybu, která se projevuje "jen někdy"? Jaká je vaše strategie prvních pěti minut?

---

## Procvičení

### Řešený příklad

**Zadání:** Následující metoda má počítat průměr kladných čísel v poli, ale vrací špatné výsledky. Popište postup ladění (kam breakpoint, co sledovat) a chybu najděte:

```csharp
static double PrumerKladnych(int[] cisla)
{
    int soucet = 0;
    int pocet = 0;
    for (int i = 0; i < cisla.Length; i++)
    {
        if (cisla[i] > 0)
        {
            soucet += cisla[i];
        }
        pocet++;
    }
    return (double)soucet / pocet;
}
```

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

**Postup ladění:**
1. Připravte testovací vstup se známým výsledkem, např. `{ 4, -2, 6 }` → očekávám průměr kladných (4+6)/2 = **5**, metoda vrací 3.33.
2. Breakpoint na řádek `pocet++;`, spusťte ladění (F5) a krokujte (F10).
3. Sledujte v panelu Locals proměnné `i`, `soucet`, `pocet`.
4. Ve druhém průchodu (i=1, hodnota -2) uvidíte: `soucet` se správně nezvýšil, ale **`pocet` ano** — a to je moment odhalení.

**Chyba:** `pocet++` je *mimo* blok `if`, takže se počítají všechna čísla, ne jen kladná. Oprava — přesunout `pocet++` dovnitř `if`:

```csharp
if (cisla[i] > 0)
{
    soucet += cisla[i];
    pocet++;
}
```

A ještě jeden bonus, který ladění odhalí: pro pole bez kladných čísel dělíme nulou — u `double` to nevyhodí výjimku, ale vrátí `NaN`. Stojí za ošetření.

</details>

### Samostatná cvičení

1. **Základní** — Vložte do libovolného svého cyklu breakpoint a projděte si tři průchody krokováním. Zapište, jak se měnily hodnoty proměnných.
2. **Pokročilejší** — Nastavte podmíněný breakpoint (pravý klik na breakpoint → Condition), který zastaví běh cyklu `for (int i = 0; i < 1000; i++)` jen při `i == 500`.
3. **Bonus (*)** — Nechte spolužáka schovat do vašeho funkčního programu jednu logickou chybu. Najděte ji pouze debuggerem — bez čtení diffu.