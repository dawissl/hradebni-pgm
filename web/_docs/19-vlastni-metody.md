---
layout: post
title: "Vlastní metody"
order: 19
---

V kapitole **Metody** jsme si ukázali, jak metodu definovat, zavolat a vrátit z ní hodnotu. Teď se podíváme na to, jak metody **navrhovat** – jak vypadá dobře rozdělený program – a na dvě věci, které ušetří práci při volání: **výchozí hodnoty parametrů** a **pojmenované argumenty**.

---

## Jedna metoda, jeden úkol

Nejčastější chyba začátečníků není syntaktická, ale designová: jedna metoda dělá *moc věcí najednou*.

```csharp
// ❌ Metoda dělá tři různé věci – načítá, počítá i vypisuje
void ProcessOrder()
{
    Console.Write("Zadej cenu: ");
    double price = Convert.ToDouble(Console.ReadLine());

    double total = price * 1.21; // DPH

    Console.WriteLine($"Celkem s DPH: {total:F2} Kč");
}
```

Pokud byste chtěli později cenu jen *spočítat* (bez vstupu a výstupu), např. v jiné části programu, tak to nepůjde – všechno je slité do jedné metody.

```csharp
// ✅ Tři metody, každá s jasnou odpovědností
double ReadPrice()
{
    Console.Write("Zadej cenu: ");
    return Convert.ToDouble(Console.ReadLine());
}

double AddVat(double price, double vatRate = 0.21)
{
    return price * (1 + vatRate);
}

void PrintTotal(double total)
{
    Console.WriteLine($"Celkem s DPH: {total:F2} Kč");
}
```

```csharp
double price = ReadPrice();
double total = AddVat(price);
PrintTotal(total);
```

Výhoda: `AddVat()` lze nyní použít i v testu, v jiném výpočtu, na seznamu cen v cyklu – bez konzole, bez vstupu uživatele.

> 💡 Otestujte si metodu jednou větou: *"Tato metoda dělá ___."* Pokud do té věty potřebujte slovo „a", je nejspíš čas ji rozdělit.

---

## Signatura jako smlouva

**Signatura** metody (název + parametry + návratový typ) je „smlouva" mezi metodou a tím, kdo ji volá – říká, co metoda potřebuje na vstupu a co dostaneš na výstupu, bez nutnosti znát její vnitřní implementaci. V některých textech můžete narazit na pojmenování **hlavička**.

```csharp
double CalculateAverage(int[] scores)
```

Z této jediné řádky víme:

- potřebujeme pole celých čísel
- dostaneme zpět desetinné číslo

Díky tomu můžete metodu používat kdokoliv, aniž by musel číst její tělo.

---

## Parametry s výchozí hodnotou

Parametru lze přiřadit hodnotu, která se použije, pokud argument při volání není předán.

```csharp
string FormatPrice(double price, string currency = "Kč")
{
    return $"{price:F2} {currency}";
}
```

```csharp
Console.WriteLine(FormatPrice(99.5));        // 99.50 Kč
Console.WriteLine(FormatPrice(99.5, "€"));   // 99.50 €
```

### Pravidla

Parametry s výchozí hodnotou musí být **na konci** seznamu parametrů – za nimi nesmí následovat povinný parametr bez výchozí hodnoty:

```csharp
// ❌ CHYBA – povinný parametr "name" je až za parametrem s výchozí hodnotou
void Invalid(int age = 18, string name) { ... }

// ✅ OK
void Valid(string name, int age = 18) { ... }
```

---

## Pojmenované argumenty

Argumenty lze při volání předat podle **jména parametru** – pak nezáleží na pořadí:

```csharp
void CreateUser(string name, int age = 18, string role = "student")
{
    Console.WriteLine($"{name}, {age} let, role: {role}");
}
```

```csharp
CreateUser("Kamil");                          // Kamil, 18 let, role: student
CreateUser("Kamil", role: "teacher");         // přeskočili jsme "age", použije se výchozí 18
CreateUser(age: 30, name: "Jana");            // pořadí argumentů obráceně – funguje
```

Pojmenované argumenty se hodí zejména tehdy, když metoda má víc parametrů s výchozími hodnotami a chcete změnit jen jeden z nich – bez nich je třeba vypsat i ty, které se nemění.

---

## Kompletní příklad

Program rozdělený do menších metod – každá řeší jednu věc, kombinace výchozích hodnot a pojmenovaných argumentů:

```csharp
using System;

namespace ShoppingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            double price = ReadPrice();

            double totalDefault = AddVat(price);               // s výchozí sazbou 21 %
            double totalReduced = AddVat(price, vatRate: 0.10); // snížená sazba 10 %

            PrintTotal("Základní sazba", totalDefault);
            PrintTotal("Snížená sazba", totalReduced);
        }

        static double ReadPrice()
        {
            Console.Write("Zadej cenu bez DPH: ");
            return Convert.ToDouble(Console.ReadLine());
        }

        static double AddVat(double price, double vatRate = 0.21)
        {
            return price * (1 + vatRate);
        }

        static void PrintTotal(string label, double total)
        {
            Console.WriteLine($"{label}: {total:F2} Kč");
        }
    }
}
```

---

## Shrnutí

```csharp
// výchozí hodnota – musí být na konci seznamu parametrů
void Metoda(string povinny, int volitelny = 10) { ... }

// pojmenovaný argument – přeskočí parametry s výchozí hodnotou
Metoda("text", volitelny: 20);
Metoda("text"); // použije se výchozí hodnota 10
```

| Pojem | Vysvětlení |
|---|---|
| Jedna odpovědnost | Metoda by měla dělat jednu věc – jde popsat jednou větou |
| Signatura | Název + parametry + návratový typ = „smlouva" metody |
| Výchozí hodnota | `typ param = hodnota` – argument lze při volání vynechat |
| Pojmenovaný argument | `Metoda(param: hodnota)` – umožní vynechat parametry uprostřed |

> Modifikátory `ref` a `out` a detailní práci s `return` probereme v následující kapitole.
---

## Otázky k zamyšlení

1. Proč musí být metody volané ze statické metody `Main` také statické? Co znamená `static`?
2. Jak se liší lokální proměnná uvnitř metody od proměnné v `Main`? Kde která "žije" a kdy zaniká?
3. Co se stane, když metoda s návratovým typem `int` neobsahuje `return` na všech cestách kódu?

---

## Procvičení

### Řešený příklad

**Zadání:** Napište metodu `VykresliObdelnik(int sirka, int vyska)`, která vykreslí na konzoli obdélník z hvězdiček — plný okraj, prázdný vnitřek. Zavolejte ji z `Main` s několika různými rozměry.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

Uvnitř metody rozhodujeme pro každou pozici: okraj (první/poslední řádek či sloupec) → hvězdička, jinak mezera:

```csharp
class Program
{
    static void Main()
    {
        VykresliObdelnik(8, 4);
        Console.WriteLine();
        VykresliObdelnik(5, 5);
    }

    static void VykresliObdelnik(int sirka, int vyska)
    {
        for (int r = 0; r < vyska; r++)
        {
            for (int s = 0; s < sirka; s++)
            {
                bool okraj = r == 0 || r == vyska - 1 || s == 0 || s == sirka - 1;
                Console.Write(okraj ? "*" : " ");
            }
            Console.WriteLine();
        }
    }
}
```

Díky parametrům je metoda univerzální — jeden kód, libovolné rozměry. To je hlavní síla vlastních metod: napsat jednou, používat opakovaně.

</details>

### Samostatná cvičení

1. **Základní** — Napište metodu `PozdravUzivatele(string jmeno, int hodina)`, která podle hodiny vypíše "Dobré ráno/odpoledne/večer, {jmeno}".
2. **Pokročilejší** — Napište metodu `VykresliTrojuhelnik(int vyska)`, která vykreslí trojúhelník z hvězdiček. Pak přidej druhou variantu obrácenou vzhůru nohama.
3. **Bonus (*)** — Napište metodu `JePrvocislo(int n)` vracející `bool` a s její pomocí vypište všechna prvočísla do 100. Všimněte si, jak volání `if (JePrvocislo(i))` zpřehledňuje kód.