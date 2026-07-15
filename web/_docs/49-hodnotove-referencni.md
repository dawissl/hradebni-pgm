---
layout: post
title: "Hodnotové a referenční typy"
order: 490
---

Každý typ v C# je buď **hodnotový** nebo **referenční**. Tento rozdíl určuje, co se stane při kopírování proměnné nebo předání do metody.

---

## Hodnotové typy

Hodnotový typ uchovává **přímo hodnotu**. Při přiřazení vznikne nezávislá kopie.

```csharp
int a = 10;
int b = a;   // b je kopie hodnoty 10
b = 99;

Console.WriteLine(a);  // 10 — nezměněno
Console.WriteLine(b);  // 99
```

**Hodnotové typy:** `int`, `long`, `double`, `float`, `decimal`, `bool`, `char`, `byte`, `struct`, `enum`

---

## Referenční typy

Referenční typ uchovává **odkaz** (adresu) na objekt v paměti. Při přiřazení se zkopíruje odkaz — ne data.

```csharp
int[] a = { 1, 2, 3 };
int[] b = a;   // b odkazuje na stejné pole jako a

b[0] = 99;

Console.WriteLine(a[0]);  // 99 — změnil se objekt, na který odkazují oba
Console.WriteLine(b[0]);  // 99
```

![Diagram: proměnná a a b obě šipkou ukazují na jedno pole {99, 2, 3} v paměti](../assets/reference-diagram.png)

**Referenční typy:** třídy (všechny vlastní třídy), `string`, pole (`int[]`, `string[]`…), rozhraní

---

## Kopírování objektu (deep copy)

Pokud chcete skutečnou nezávislou kopii objektu, musíte ji vytvořit ručně:

```csharp
int[] original = { 1, 2, 3 };

// Clone() nebo Array.Copy() vytvoří nové pole s vlastními hodnotami
int[] kopie = (int[])original.Clone();

// Nebo:
int[] kopie2 = new int[original.Length];
Array.Copy(original, kopie2, original.Length);

kopie[0] = 99;
Console.WriteLine(original[0]);  // 1 — nezměněno
```

> ⚠️ **Pozor u polí objektů:** `Clone()`/`Array.Copy()` je vždy jen **mělká kopie** — zkopíruje samo pole, ale pokud pole obsahuje referenční typy, zkopírují se jen odkazy na ně, ne objekty samotné. `int[]` tenhle problém nemá, protože `int` je hodnotový typ — proto v ukázce výše `kopie[0] = 99` na `original` nesáhne. U `Student[]` by ale `kopie[0].Jmeno = "Nové"` změnilo i `original[0].Jmeno`, protože oba prvky by stále odkazovaly na týž objekt `Student`.

---

## Předávání do metod

### Hodnotový typ — předání hodnotou

```csharp
void Zdvoj(int x)
{
    x = x * 2;
    Console.WriteLine($"Uvnitř metody: {x}");  // 20
}

int cislo = 10;
Zdvoj(cislo);
Console.WriteLine($"Vně metody: {cislo}");  // 10 — nezměněno
```

Metoda dostane **kopii** hodnoty. Změna uvnitř metody nemá vliv na původní proměnnou.

### Referenční typ — předání odkazu

```csharp
void Nastav(int[] pole)
{
    pole[0] = 99;
}

int[] data = { 1, 2, 3 };
Nastav(data);
Console.WriteLine(data[0]);  // 99 — změna se projevila
```

Metoda dostane **kopii odkazu** — ale oba odkazy míří na stejný objekt. Změna obsahu objektu je viditelná i vně.

### Klíčové slovo `ref` a `out`

Pokud chcete předat hodnotový typ odkazem (aby metoda mohla změnit původní proměnnou):

```csharp
void Zdvoj(ref int x)
{
    x = x * 2;
}

int cislo = 10;
Zdvoj(ref cislo);
Console.WriteLine(cislo);  // 20 — změněno
```

`out` funguje podobně, ale proměnná nemusí být inicializována před předáním — metoda ji musí nastavit.

---

## Výjimka: `string`

`string` je referenční typ, ale chová se jako hodnotový — je **immutable** (neměnný). Každá operace na stringu vytvoří nový objekt.

```csharp
string a = "ahoj";
string b = a;
b = b.ToUpper();

Console.WriteLine(a);  // ahoj — nezměněno
Console.WriteLine(b);  // AHOJ
```

`b.ToUpper()` nevytvořil nový string v `b` — ale `b` nyní odkazuje na nový objekt `"AHOJ"`, zatímco `a` stále odkazuje na původní `"ahoj"`.

---

## Shrnutí

| | Hodnotový typ | Referenční typ |
|---|---|---|
| Ukládá | Přímo hodnotu | Odkaz na objekt |
| Kopírování | Nová nezávislá hodnota | Nový odkaz na stejný objekt |
| Předání do metody | Metoda dostane kopii | Metoda může měnit původní objekt |
| Příklady | `int`, `bool`, `struct` | třídy, pole, `string` |

---

## Otázky k zamyšlení

1. Které typy jsou hodnotové a které referenční? Kam patří `int`, `string`, pole, `struct`, třída?
2. Co přesně se kopíruje při `b = a`, když `a` je `int`, a co, když `a` je objekt třídy?
3. Proč metoda může změnit obsah pole předaného parametrem, ale nemůže (bez `ref`) změnit předaný `int`?

---

## Procvičení

### Řešený příklad

**Zadání:** Bez spouštění určete výstup programu a vysvětlete každý řádek výstupu:

```csharp
struct BodS { public int X; }
class BodC { public int X; }

class Program
{
    static void Main()
    {
        BodS s1 = new BodS { X = 1 };
        BodS s2 = s1;
        s2.X = 99;

        BodC c1 = new BodC { X = 1 };
        BodC c2 = c1;
        c2.X = 99;

        Console.WriteLine($"s1.X = {s1.X}, s2.X = {s2.X}");
        Console.WriteLine($"c1.X = {c1.X}, c2.X = {c2.X}");
    }
}
```

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

Výstup:

```
s1.X = 1, s2.X = 99
c1.X = 99, c2.X = 99
```

- **Struktura (hodnotový typ):** `s2 = s1` vytvoří **úplnou kopii** dat. `s1` a `s2` jsou dva nezávislé body — změna `s2.X` se `s1` nedotkne.
- **Třída (referenční typ):** `c2 = c1` zkopíruje jen **referenci** — obě proměnné ukazují na *tentýž* objekt na haldě. Změna přes `c2` je vidět i přes `c1`, protože žádný druhý objekt neexistuje.

Mentální model: hodnotový typ = kopie listu papíru; referenční typ = druhý klíč od téhož bytu.

</details>

### Samostatná cvičení

1. **Základní** — Napište metodu `Vynuluj(int[] pole)`, která nastaví všechny prvky na 0, a ověřte, že se změna projeví u volajícího. Pak vysvětlete proč — vždyť pole bylo předáno "hodnotou"?
2. **Pokročilejší** — Napište metodu `Prohod(ref int a, ref int b)` a druhou verzi bez `ref`. Ukažte na výstupu, že bez `ref` prohození "nefunguje", a vysvětlete, co se prohodilo doopravdy.
3. **Bonus (*)** — Zjistěte, co je "boxing" (`object o = 42;`). Proč je to výkonnostně drahé a jak se mu vyhýbají generické kolekce?