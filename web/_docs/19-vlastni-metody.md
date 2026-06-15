---
layout: post
title: "Vlastní metody"
order: 19
---

V kapitole [Metody](./18-metody.md) jsme si ukázali, jak metodu definovat, zavolat a vrátit z ní hodnotu. Teď se podíváme na to, jak metody **navrhovat** – jak vypadá dobře rozdělený program – a na dvě věci, které ti ušetří práci při volání: **výchozí hodnoty parametrů** a **pojmenované argumenty**.

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

Pokud bys chtěl později cenu jen *spočítat* (bez vstupu a výstupu), např. v jiné části programu, nemůžeš – všechno je slité do jedné metody.

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

> 💡 Otestuj si metodu jednou větou: *"Tato metoda dělá ___."* Pokud do té věty potřebuješ slovo „a", je čas ji rozdělit.

---

## Signatura jako smlouva

**Signatura** metody (název + parametry + návratový typ) je „smlouva" mezi metodou a tím, kdo ji volá – říká, co metoda potřebuje na vstupu a co dostaneš na výstupu, bez nutnosti znát její vnitřní implementaci.

```csharp
double CalculateAverage(int[] scores)
```

Z této jediné řádky víš:

- potřebuješ pole celých čísel
- dostaneš zpět desetinné číslo

Díky tomu může metodu používat kdokoliv (i ty sám za měsíc), aniž by musel číst její tělo.

---

## Parametry s výchozí hodnotou

Parametru lze přiřadit hodnotu, která se použije, pokud argument při volání nepředáš.

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

Pojmenované argumenty se hodí zejména tehdy, když metoda má víc parametrů s výchozími hodnotami a ty chceš změnit jen jeden z nich – bez nich bys museli vypsat i ty, které se nemění.

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

Modifikátory `ref` a `out` a detailní práci s `return` probereme v následující kapitole.