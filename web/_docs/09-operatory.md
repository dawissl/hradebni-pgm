---
layout: post
title: "Operátory a výrazy"
order: 9
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

Pozor – pokud dělíš dvě celá čísla (`int`), výsledek je také celé číslo. Desetinná část se **ořízne**:

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

---

## Priorita operátorů

Operátory se vyhodnocují v určitém pořadí – podobně jako v matematice (nejprve násobení, pak sčítání). Pro přehlednost a jistotu používej **závorky**:

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

## Typová konverze a přetypování

Při operacích se různé datové typy někdy musí převést na společný typ. C# to řeší dvěma způsoby.

### Implicitní konverze (automatická)

Proběhne sama, pokud nedochází ke ztrátě dat – kompilátor převede „menší" typ na „větší":

```csharp
int myInt = 10;
double myDouble = myInt; // int → double, žádná ztráta
```

Bezpečný směr: `byte → int → long → float → double`

### Explicitní přetypování (cast)

Nutné, když hrozí ztráta dat. Cílový typ zapíšeš do závorek před hodnotu:

```csharp
double price = 20.9;
int rounded = (int)price; // výsledek: 20 (desetinná část se ořízne, NEzaokrouhlí)
```

```csharp
double d = 20.9;
float f  = (float)d;    // 20.9
float f2 = (float)20.9; // alternativa k suffixu 'f'
```

> ⚠️ `(int)20.9` je `20`, ne `21`. Přetypování vždy **ořízne**, nezaokrouhluje.

### Konverze pomocí `Convert`

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
| `Convert.ToBool()` | `bool` |

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
| Logické | `&&` `\|\|` `!` | Kombinování podmínek |
| Přetypování | `(typ)hodnota` | Explicitní převod datového typu |
| Konverze | `Convert.ToInt32()` atd. | Převod (zejména ze stringu) |
