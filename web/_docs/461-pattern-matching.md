---
layout: post
title: "Pattern matching"
order: 461
---

V kapitole **Podmínky** jsme se seznámili se `switch` expression a v kapitole **Polymorfismus** jsme použili `zam is Manazer m` k ověření typu proměnné. Obojí je ve skutečnosti jen malý kousek většího nástroje jménem **pattern matching** — porovnávání hodnoty nejen podle typu, ale i podle jejího tvaru a obsahu. C# ho umí kombinovat do překvapivě čitelných výrazů.

> ⚠️ Pattern matching není náhrada za `virtual`/`override` z kapitoly **Polymorfismus**. Pokud máte třídní hierarchii a chcete, aby se každý typ zachoval "po svém", stále patří přepsaná metoda, ne řetězec `is Typ`. Pattern matching se hodí tam, kde přirozená hierarchie chybí, nebo když rozhodujete podle *dat*, ne podle *typu*.

---

## Připomenutí: `is` s deklarací proměnné

```csharp
object zam = new Manazer { Jmeno = "Pavel", Bonus = 5000 };

if (zam is Manazer m)
{
    Console.WriteLine($"Manažer s bonusem {m.Bonus}");
}
```

`is Manazer m` je nejjednodušší pattern — ověří typ a při shodě rovnou deklaruje proměnnou `m` daného typu. Tohle jste už viděli; teď to rozšíříme.

---

## Vlastnostní pattern (property pattern)

Můžete testovat i **hodnoty vlastností** objektu, ne jen jeho typ:

```csharp
if (zam is Manazer { Bonus: > 10000 })
{
    Console.WriteLine("Manažer s vysokým bonusem.");
}
```

Tohle ověří: je `zam` typu `Manazer`, **a zároveň** jeho `Bonus` je větší než 10000. Bez pattern matchingu byste psali `zam is Manazer m && m.Bonus > 10000` — funkčně stejné, ale o řádek delší a s pomocnou proměnnou, kterou možná ani nepotřebujete.

---

## Relační patterny ve `switch`

Switch expression umí porovnávat i pomocí `<`, `>`, `<=`, `>=` — hodí se přesně na situace jako klasifikace podle rozsahu, které jsme dřív řešili řetězcem `if/else if`:

```csharp
string Klasifikuj(int body) => body switch
{
    >= 90 => "Výborně",
    >= 75 => "Chvalitebně",
    >= 60 => "Dobře",
    >= 45 => "Dostatečně",
    _     => "Nedostatečně"
};
```

Pořadí větví platí stejné pravidlo jako u `else if` v kapitole **Podmínky**: `switch` zkouší větve shora dolů a použije první, která sedí — proto musí být řazené od nejvyšší hranice.

---

## Kombinátory `and`, `or`, `not`

Patterny lze skládat logickými spojkami přímo v zápisu:

```csharp
string PopisTeploty(int stupne) => stupne switch
{
    < 0                => "mrzne",
    >= 0 and < 15       => "chladno",
    >= 15 and < 25      => "příjemně",
    >= 25               => "horko"
};
```

```csharp
bool JeVikend(DayOfWeek den) => den is DayOfWeek.Saturday or DayOfWeek.Sunday;

bool NeniNula(int x) => x is not 0;
```

`and`/`or`/`not` fungují podobně jako `&&`/`||`/`!` z kapitoly **Operátory a výrazy**, ale zapisují se přímo uvnitř patternu, ne jako samostatný logický výraz.

---

## Tuple pattern — rozhodování podle víc hodnot najednou

Switch expression umí testovat i kombinaci víc proměnných zabalených do tuple (kapitola **Parametry a návratové hodnoty**):

```csharp
string VyhodnotSouradnice(int x, int y) => (x, y) switch
{
    (0, 0)          => "počátek",
    (0, _)          => "na ose Y",
    (_, 0)          => "na ose X",
    _ when x == y   => "na diagonále",
    _               => "obecný bod"
};
```

`_` (discard) v patternu znamená "na téhle pozici mi nezáleží, na jaké hodnotě" — najde shodu bez ohledu na skutečnou hodnotu. `when` doplňuje pattern o libovolnou podmínku, kterou by samotný pattern nevyjádřil.

---

## `switch` na hierarchii typů — kdy je to v pořádku

Pattern matching na typ *uvnitř* jedné metody se hodí, když sami nevlastníte třídu (nemůžete do ní přidat `virtual` metodu), nebo když se rozhoduje jen jednou, na jednom místě, ne opakovaně napříč programem:

```csharp
string Popis(object tvar) => tvar switch
{
    Kruh k when k.Polomer > 100  => "velký kruh",
    Kruh                          => "kruh",
    Obdelnik { Sirka: var s, Vyska: var v } when s == v => "čtverec",
    Obdelnik                      => "obdélník",
    _                              => "neznámý tvar"
};
```

Všimněte si `Obdelnik { Sirka: var s, Vyska: var v }` — vytáhne obě vlastnosti do nových proměnných `s` a `v` k dalšímu použití v podmínce `when`. Tohle je jednorázové rozhodnutí na jednom místě v kódu — přesně to, co kapitola **Polymorfismus** varovala, bylo opakované `if (zam is Manazer) ... else if (zam is Brigardnik) ...` roztroušené po celém programu, kde se při každém novém typu musí zasahovat na víc místech. Jednorázový `switch` na tvar dat je jiný případ než náhrada polymorfismu.

---

## Shrnutí

| Pattern | Zápis | Co ověří |
|---|---|---|
| Typový (s deklarací) | `x is Manazer m` | typ, a zpřístupní jako `m` |
| Vlastnostní | `x is Manazer { Bonus: > 1000 }` | typ **a** hodnotu vlastnosti |
| Relační | `>= 90 => ...` | porovnání `<`, `>`, `<=`, `>=` ve `switch` |
| Kombinátory | `and`, `or`, `not` | logické skládání patternů |
| Tuple | `(x, y) switch { (0, 0) => ... }` | kombinaci víc hodnot najednou |
| Discard | `_` | "na hodnotě nezáleží" |
| `when` | `Kruh k when k.Polomer > 100` | doplňující podmínka k patternu |

---

## Otázky k zamyšlení

1. Čím se liší `zam is Manazer { Bonus: > 10000 }` od `zam is Manazer m && m.Bonus > 10000`? Dělají obě varianty totéž?
2. Proč musí být relační patterny ve `switch` (`>= 90`, `>= 75`...) seřazené od nejvyšší hranice, stejně jako `else if` v kapitole Podmínky?
3. Kdy je `switch` na typ objektu v pořádku, a kdy je to signál, že chybí `virtual`/`override`?

---

## Procvičení

### Řešený příklad

**Zadání:** Napište metodu `string OhodnotStudenta(Student s)`, která pomocí pattern matchingu vrátí slovní hodnocení podle vlastnosti `Prumer`: do 1.5 "vynikající", do 2.5 "dobrý", do 3.5 "průměrný", jinak "slabý" — a navíc speciálně "vynikající s pochvalou", pokud je `Prumer` roven přesně 1.0.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

```csharp
string OhodnotStudenta(Student s) => s switch
{
    { Prumer: 1.0 }         => "vynikající s pochvalou",
    { Prumer: <= 1.5 }      => "vynikající",
    { Prumer: <= 2.5 }      => "dobrý",
    { Prumer: <= 3.5 }      => "průměrný",
    _                        => "slabý"
};
```

Klíčový detail: `{ Prumer: 1.0 }` (přesná shoda) musí být **před** `{ Prumer: <= 1.5 }`, jinak by přesná hodnota 1.0 spadla do obecnější větve dřív, než by se dostala k té specifičtější — stejné pravidlo pořadí jako u relačních patternů výše.

</details>

### Samostatná cvičení

1. **Základní** — Napište metodu `string PopisPocasi(int teplota, bool prsi)`, která pomocí tuple patternu a kombinátorů vrátí popis jako "slunečno a teplo", "zima a déšť" apod.
2. **Pokročilejší** — Vezměte hierarchii `Tvar` → `Kruh`, `Obdelnik`, `Trojuhelnik` z kapitoly **Polymorfismus** a napište `switch` expression, který vrátí barevný popis podle typu *a* podle obsahu (`when obsah > 100 => "velký " + ...`).
3. **Bonus (*)** — Zjistěte, co dělá pattern `is null` a `is not null` a proč se doporučuje před `== null`/`!= null` u typů, které mohou přetěžovat operátor `==`.
