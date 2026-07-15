---
layout: post
title: "Operátory a výrazy"
order: 90
---

Operátor je symbol, který provádí operaci s jednou nebo více hodnotami (**operandy**). Výsledkem operace je nová hodnota.

---

## Aritmetické operátory

Slouží k matematickým výpočtům.

| Operátor | Název | Příklad (`x = 7, y = 2`) | Výsledek |
|---|---|---|---|
| `+` | Součet | `x + y` | `9` |
| `-` | Rozdíl | `x - y` | `5` |
| `*` | Součin | `x * y` | `14` |
| `/` | Podíl | `x / y` | `3` |
| `%` | Zbytek po dělení (modulo) | `x % y` | `1` |

### Dělení celých čísel

Pozor – pokud dělíte dvě celá čísla (`int`), výsledek je také celé číslo. Desetinná část se **ořízne**:

```csharp
int a = 7, b = 2;
Console.WriteLine(a / b);    // 3, ne 3.5
Console.WriteLine(7.0 / 2);  // 3.5
Console.WriteLine(7 / 2.0);  // 3.5
```

> 💡 Stačí, aby byl jeden operand desetinný, a výsledek bude také desetinný.

### Modulo

Operátor `%` vrátí **zbytek po celočíselném dělení**. Hodí se například k zjištění, zda je číslo sudé nebo liché:

```csharp
Console.WriteLine(10 % 2); // 0 → sudé
Console.WriteLine(7 % 2);  // 1 → liché
```

---

## Přiřazovací operátory

### Základní přiřazení

`=` není matematická rovnost – je to **přiřazení**: hodnota z pravé strany se uloží do proměnné na levé straně.

```csharp
int x = 5;
int y = 10;
x = y;  // x je nyní 10, y zůstává 10
```

### Zkrácené přiřazovací operátory

Kombinují aritmetickou operaci s přiřazením. Ušetří psaní.

| Operátor | Zápis | Ekvivalent |
|---|---|---|
| `+=` | `x += 2` | `x = x + 2` |
| `-=` | `x -= 2` | `x = x - 2` |
| `*=` | `x *= 2` | `x = x * 2` |
| `/=` | `x /= 2` | `x = x / 2` |
| `%=` | `x %= 2` | `x = x % 2` |

```csharp
int score = 100;
score += 10;  // score = 110
score -= 5;   // score = 105
score *= 2;   // score = 210
```

### Inkrementace a dekrementace

Pro zvýšení nebo snížení hodnoty o 1 existují zkratkové operátory:

```csharp
int counter = 5;
counter++;  // counter = 6
counter--;  // counter = 5
```

#### Prefix vs. postfix

Záleží na tom, jestli je `++` před nebo za proměnnou:

```csharp
int counter = 5;

Console.WriteLine(counter++); // vypíše 5, pak zvýší na 6
Console.WriteLine(++counter); // nejprve zvýší na 7, pak vypíše 7
```

> 💡 V izolovaném příkazu (`counter++;`) není rozdíl. Záleží jen tehdy, když je výraz součástí většího výrazu (např. uvnitř `WriteLine`).

---

## Relační (porovnávací) operátory

Porovnávají dvě hodnoty a vrátí `bool` – `true` nebo `false`. Využívají se hlavně v podmínkách.

| Operátor | Název | Příklad | Výsledek |
|---|---|---|---|
| `==` | Rovnost | `5 == 5` | `true` |
| `!=` | Nerovnost | `5 != 3` | `true` |
| `>` | Větší než | `7 > 2` | `true` |
| `<` | Menší než | `2 < 7` | `true` |
| `>=` | Větší nebo rovno | `5 >= 5` | `true` |
| `<=` | Menší nebo rovno | `3 <= 2` | `false` |

```csharp
int age = 18;
Console.WriteLine(age >= 18); // true
Console.WriteLine(age == 21); // false
```

> ⚠️ Časté záměny: `=` je přiřazení, `==` je porovnání. `x = 5` uloží hodnotu, `x == 5` se ptá, zda je x rovno 5.

---

## Logické operátory

Kombinují více podmínek dohromady.

| Operátor | Název | Popis |
|---|---|---|
| `&&` | AND (a zároveň) | `true` pouze pokud jsou **obě** podmínky pravdivé |
| `\|\|` | OR (nebo) | `true` pokud je **alespoň jedna** podmínka pravdivá |
| `!` | NOT (negace) | Otočí hodnotu: `true` → `false`, `false` → `true` |

```csharp
int age = 20;
bool hasTicket = true;

Console.WriteLine(age >= 18 && hasTicket); // true – obě podmínky platí
Console.WriteLine(age < 18 || hasTicket);  // true – alespoň jedna platí
Console.WriteLine(!hasTicket);             // false – negace true
```

### Líné vyhodnocování (short-circuit evaluation)

`&&` a `||` nevyhodnocují druhý operand vždy – pouze pokud je to potřeba:

- `&&` – pokud je **první** podmínka `false`, celý výraz už nemůže být `true`. Druhá podmínka se vůbec nevyhodnotí.
- `||` – pokud je **první** podmínka `true`, celý výraz už je `true`. Druhá podmínka se vůbec nevyhodnotí.

```csharp
string text = null;

// Bezpečné – pokud je text == null, druhá část se nevyhodnotí, žádná výjimka
if (text != null && text.Length > 0)
{
    Console.WriteLine("Text má obsah.");
}
```

> ⚠️ Pořadí podmínek hraje roli! `text.Length > 0 && text != null` by v tomto příkladu spadlo na `NullReferenceException`, protože `text.Length` se vyhodnotí dřív, než se ověří, že `text` není `null`.

> 💡 Líné vyhodnocování se dá využít i k „ochraně" před voláním nákladné nebo rizikové metody: `IsCacheValid() || RecomputeExpensiveValue()`.

### `&` a `|` – logické operátory bez líného vyhodnocování

C# má i jednoznakové varianty `&` a `|`. Použité na `bool` fungují logicky stejně jako `&&` a `||` (AND / OR), ale **vždy vyhodnotí oba operandy** – žádné zkracování:

```csharp
string text = null;

// NEBEZPEČNÉ – i když text == null, druhá strana se přesto vyhodnotí
if (text != null & text.Length > 0)
{
    Console.WriteLine("Text má obsah.");
}
// → spadne na NullReferenceException
```

Důvod je ten, že `&` a `|` jsou primárně **bitové operátory** (viz dále) – na `bool` se dají použít, ale sémanticky nejde o „logickou zkratku", nýbrž o vyhodnocení obou stran a jejich spojení na úrovni bitů. V praxi se `&`/`|` na `bool` používají jen výjimečně (např. když chcete záměrně vynutit vyhodnocení obou stran kvůli vedlejším efektům). Pro běžné podmínky používejte `&&` a `||`.

---

## Bitové operátory

Bitové operátory pracují s čísly na úrovni jednotlivých **bitů** (binárních číslic 0/1), ne s celou hodnotou najednou. Používají se hlavně u příznaků (flags), nízkoúrovňových výpočtů, kryptografie nebo optimalizací.

| Operátor | Název | Popis | Příklad (`x = 6`, tj. `0110`) |
|---|---|---|---|
| `&` | Bitové AND | `1`, jen když jsou oba bity `1` | `x & 3` → `0010` = `2` |
| `\|` | Bitové OR | `1`, když je alespoň jeden bit `1` | `x \| 1` → `0111` = `7` |
| `^` | Bitové XOR | `1`, když se bity liší | `x ^ 3` → `0101` = `5` |
| `~` | Bitová negace (unární) | Otočí všechny bity | `~x` → `-7` |
| `<<` | Posun vlevo | Posune bity vlevo, doplní nulami | `x << 1` → `1100` = `12` |
| `>>` | Posun vpravo | Posune bity vpravo | `x >> 1` → `0011` = `3` |

```csharp
int a = 6;  // 0110
int b = 3;  // 0011

Console.WriteLine(a & b); // 0010 = 2
Console.WriteLine(a | b); // 0111 = 7
Console.WriteLine(a ^ b); // 0101 = 5
Console.WriteLine(a << 1); // 1100 = 12  (posun vlevo = *2)
Console.WriteLine(a >> 1); // 0011 = 3   (posun vpravo = /2)
```

> 💡 Posun o 1 vlevo (`<< 1`) odpovídá násobení dvěma, posun vpravo (`>> 1`) celočíselnému dělení dvěma. Rychlejší zápis, ale méně čitelný – v běžném kódu dávejte přednost `* 2` / `/ 2`, pokud nejde o výkonově kritické místo.

> ⚠️ Nezaměňujte `&`/`|` (bitové, pracují s čísly) a `&&`/`||` (logické, pracují s `bool` a mají líné vyhodnocování). Na `bool` se `&`/`|` dají použít taky, ale ztratíte tím zkracování – viz výše.

Typické využití jsou **flags** (příznaky) – kombinace více `bool` hodnot do jednoho čísla pomocí výčtového typu s atributem `[Flags]`:

> 💡 `enum` (výčtový typ) si podrobně vysvětlíme až v kapitole **Struktura a enumerace**. Pro tuto chvíli stačí vědět, že jde jen o sadu pojmenovaných celočíselných konstant – `Permissions.Read` je „hezčí jméno" pro číslo `1`.

```csharp
[Flags]
enum Permissions
{
    None  = 0,      // 0000
    Read  = 1,      // 0001
    Write = 2,      // 0010
    Exec  = 4        // 0100
}

Permissions p = Permissions.Read | Permissions.Write; // 0011 – čtení i zápis

bool canWrite = (p & Permissions.Write) == Permissions.Write; // true
```

---

## Počet operandů: unární, binární a ternární operátory

Operátory se dají třídit i podle toho, s **kolika operandy** pracují.

| Typ | Počet operandů | Příklady |
|---|---|---|
| Unární | 1 | `!hasTicket`, `-x`, `x++`, `x--`, `~x` |
| Binární | 2 | `a + b`, `a == b`, `a && b` (naprostá většina operátorů) |
| Ternární | 3 | `podmínka ? hodnota1 : hodnota2` |

Většina operátorů, se kterými jste se zatím setkali, je **binárních** – pracují se dvěma operandy (`a + b`). Výjimkou jsou **unární** operátory jako negace `!` nebo znaménko `-x`, které pracují jen s jednou hodnotou.

### Ternární (podmiňovací) operátor `?:`

C# má jediný operátor, který pracuje se **třemi** operandy – podmiňovací operátor `?:`. Je to zkrácený zápis `if-else`, který rovnou vrací hodnotu:

```csharp
podmínka ? hodnota_pokud_true : hodnota_pokud_false
```

```csharp
int age = 20;
string result = (age >= 18) ? "dospělý" : "nezletilý";
Console.WriteLine(result); // dospělý
```

Je to ekvivalent k:

```csharp
string result;
if (age >= 18)
{
    result = "dospělý";
}
else
{
    result = "nezletilý";
}
```

> 💡 Ternární operátor se hodí pro krátká, jednoduchá rozhodnutí přímo ve výrazu. Pro složitější logiku (víc podmínek, víc řádků kódu) je čitelnější klasické `if-else`.

---

## Priorita operátorů

Operátory se vyhodnocují v určitém pořadí – podobně jako v matematice (nejprve násobení, pak sčítání). Pro přehlednost a jistotu používejte **závorky**:

```csharp
int result = 2 + 3 * 4;    // 14 (nejprve *, pak +)
int result2 = (2 + 3) * 4; // 20 (závorka má přednost)
```

Obecné pořadí (od nejvyšší priority):

1. `++`, `--` (prefix), `!`
2. `*`, `/`, `%`
3. `+`, `-`
4. `<`, `>`, `<=`, `>=`
5. `==`, `!=`
6. `&&`
7. `||`
8. `=`, `+=`, `-=` … (přiřazení)

---

## Typová konverze pomocí `Convert`

Implicitní a explicitní konverzi (`(int)hodnota`) jsme si představili v kapitole **Proměnné a datové typy**. Tady tu myšlenku rozšíříme o další nástroj a ukážeme, čím se liší od přetypování.

Bezpečný směr implicitní konverze bez ztráty dat: `byte → int → long → float → double`.

Třída `Convert` z namespace `System` nabízí bezpečnější převody, zejména ze `string` na číslo:

```csharp
string input = "42";
int number   = Convert.ToInt32(input);
double dbl   = Convert.ToDouble(input);
decimal dec  = Convert.ToDecimal(input);
```

| Metoda | Převádí na |
|---|---|
| `Convert.ToInt32()` | `int` |
| `Convert.ToDouble()` | `double` |
| `Convert.ToDecimal()` | `decimal` |
| `Convert.ToSingle()` | `float` |
| `Convert.ToString()` | `string` |
| `Convert.ToBoolean()` | `bool` |

> 💡 `Convert.ToInt32("42")` **zaokrouhluje** (`"42.9"` → `43`), zatímco `(int)42.9` ořezává (`→ 42`). Pozor na rozdíl.

### `int.Parse` vs. `Convert.ToInt32`

Obě metody převedou řetězec na číslo, ale chovají se odlišně při vstupu `null`:

```csharp
int.Parse(null);           // vyhodí výjimku ArgumentNullException
Convert.ToInt32(null);     // vrátí 0
```

Pro vstup od uživatele je `Convert.ToInt32()` obvykle bezpečnější volba.

---

## Shrnutí

| Skupina | Operátory / zápis | K čemu slouží |
|---|---|---|
| Aritmetické | `+` `-` `*` `/` `%` | Matematické výpočty |
| Přiřazovací | `=` `+=` `-=` `*=` `/=` `%=` | Ukládání hodnot |
| Inkrementace | `++` `--` | Změna o 1 |
| Relační | `==` `!=` `>` `<` `>=` `<=` | Porovnání hodnot |
| Logické | `&&` `\|\|` `!` | Kombinování podmínek (líné vyhodnocování) |
| Bitové | `&` `\|` `^` `~` `<<` `>>` | Operace nad jednotlivými bity čísla |
| Podle počtu operandů | unární / binární / ternární | Klasifikace operátorů |
| Přetypování | `(typ)hodnota` | Explicitní převod datového typu |
| Konverze | `Convert.ToInt32()` atd. | Převod (zejména ze stringu) |

---

## Otázky k zamyšlení

1. Proč `5 / 2` v C# vrátí `2`, a ne `2.5`? Jak z toho dostanete `2.5`?
2. Jaký je rozdíl mezi `=` a `==`? Co udělá překladač, když je zaměníte v podmínce?
3. K čemu je dobrý operátor modulo (`%`)? Uveďte tři praktická použití.
4. Proč je u výrazu `text != null && text.Length > 0` důležité pořadí podmínek?

---

## Procvičení

### Řešený příklad

**Zadání:** Bez spouštění určete, co vypíše následující program, a pak si výsledek ověřte:

```csharp
int a = 17;
int b = 5;
Console.WriteLine(a / b);
Console.WriteLine(a % b);
Console.WriteLine((double)a / b);
Console.WriteLine(a / b * b + a % b);
```

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

```
3
2
3.4
17
```

- `a / b` je **celočíselné dělení** (oba operandy jsou `int`) → 17 / 5 = 3, zbytek se zahodí.
- `a % b` je zbytek po dělení → 17 = 3·5 + **2**.
- `(double)a / b` — přetypováním jednoho operandu se dělení stane desetinným → 3.4.
- Poslední řádek je hezká kontrola: `(a / b) * b + (a % b)` vždy vrátí původní číslo — podíl krát dělitel plus zbytek = 17.

</details>

### Samostatná cvičení

1. **Základní** — Napište program, který načte počet minut (např. 135) a vypíše je jako hodiny a minuty (2 h 15 min). Použijte `/` a `%`.
2. **Pokročilejší** — Načtěte trojciferné číslo a vypište součet jeho číslic (např. 472 → 13). Vyřešte pouze pomocí `/` a `%`, bez převodu na řetězec.
3. **Bonus (*)** — Napište výraz, který bez podmínky zjistí, zda je rok přestupný (dělitelný 4, ale ne 100, ledaže je dělitelný 400). Použijte logické operátory `&&`, `||`, `!`.