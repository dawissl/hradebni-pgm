---
layout: post
title: "Struktura a enumerace"
order: 17
---

Dosud jsme pracovali s vestavěnými datovými typy (`int`, `string`, `bool`…) a s třídami. C# nabízí ještě dva uživatelsky definované typy, které se hodí v konkrétních situacích: **`struct`** a **`enum`**.

---

## Enum

`enum` (zkratka z *enumerated type* – výčtový typ) umožňuje definovat **pojmenované konstanty** pro sadu příbuzných hodnot. Místo neprůhledných čísel pracuješ se čitelnými jmény.

### Deklarace

```csharp
enum DaysOfWeek
{
    Sun, Mon, Tue, Wed, Thu, Fri, Sat
}
```

> 💡 `enum` se deklaruje mimo třídu (nebo uvnitř třídy), ale **ne** uvnitř metody.

### Použití

```csharp
DaysOfWeek today = DaysOfWeek.Wed;
Console.WriteLine(today); // Wed
```

### Výchozí číselné hodnoty

Každý člen enumu má přiřazenu celočíselnou hodnotu – výchozí je `0` pro první člen, pak postupně +1:

```csharp
// Sun = 0, Mon = 1, Tue = 2, ... Sat = 6
```

Hodnoty lze přepsat:

```csharp
enum Priority
{
    Low = 1,
    Medium = 5,
    High = 10,
    Critical // automaticky 11
}
```

### Přetypování

Enum a `int` jsou vzájemně přetypovatelné:

```csharp
DaysOfWeek day = DaysOfWeek.Mon;

int num = (int)day;               // 1  – enum → int
DaysOfWeek back = (DaysOfWeek)3;  // Wed – int → enum

Console.WriteLine(num);  // 1
Console.WriteLine(back); // Wed
```

Převod na `string` a zpět:

```csharp
string name = DaysOfWeek.Fri.ToString();    // "Fri"
DaysOfWeek parsed = Enum.Parse<DaysOfWeek>("Fri"); // DaysOfWeek.Fri
```

### Změna podkladového typu

Výchozí typ je `int`. Lze změnit na libovolný celočíselný typ kromě `char`:

```csharp
enum Status : byte
{
    Active,    // 0
    Inactive,  // 1
    Banned     // 2
}
```

### Enum ve `switch`

Enum se přirozeně kombinuje se `switch` – kód je pak velmi čitelný:

```csharp
DaysOfWeek today = DaysOfWeek.Sat;

string type = today switch
{
    DaysOfWeek.Sat or DaysOfWeek.Sun => "víkend",
    _ => "pracovní den"
};

Console.WriteLine(type); // víkend
```

### Kdy použít enum?

- Proměnná může nabývat jen **omezeného počtu předem daných hodnot**
- Chceš, aby kód byl **čitelný** bez komentářů (`Status.Active` je jasnější než `1`)
- Chceš zabránit neplatným hodnotám (kompilátor odmítne `Status.Deleted`, pokud neexistuje)

Typické příklady: dny v týdnu, směry (sever/jih/východ/západ), stavy objednávky, kategorie, priority.

---

## Struct

`struct` je hodnotový typ, který – podobně jako třída – seskupuje **příbuzná data a chování** do jednoho celku. Na rozdíl od třídy je ale uložen na zásobníku (stack), nikoli na haldě (heap).

### Deklarace

```csharp
struct Point
{
    public int X;
    public int Y;
}
```

### Konstruktor

Struct může mít konstruktor – musí inicializovat **všechna** pole:

```csharp
struct Point
{
    public int X;
    public int Y;

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}
```

### Properties

Stejně jako třídy může struct obsahovat properties:

```csharp
struct Rectangle
{
    public double Width  { get; }
    public double Height { get; }

    public Rectangle(double width, double height)
    {
        Width  = width;
        Height = height;
    }

    public double Area => Width * Height;
}
```

### Metody

```csharp
struct Point
{
    public int X;
    public int Y;

    public Point(int x, int y) { X = x; Y = y; }

    public double DistanceTo(Point other)
    {
        int dx = X - other.X;
        int dy = Y - other.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    public override string ToString() => $"({X}, {Y})";
}
```

Použití:

```csharp
Point a = new Point(0, 0);
Point b = new Point(3, 4);

Console.WriteLine(a.DistanceTo(b)); // 5
Console.WriteLine(b);               // (3, 4)
```

### Struct je hodnotový typ

Klíčový rozdíl oproti třídě: přiřazení struct **vytvoří kopii**:

```csharp
Point p1 = new Point(1, 2);
Point p2 = p1;  // p2 je kopie, ne odkaz

p2.X = 99;

Console.WriteLine(p1.X); // 1 – p1 se nezměnil
Console.WriteLine(p2.X); // 99
```

U třídy by obě proměnné sdílely stejný objekt. U struct každá drží vlastní data.

---

## Struct vs. třída – kdy co použít?

| Vlastnost | `struct` | `class` |
|---|---|---|
| Typ | Hodnotový (stack) | Referenční (heap) |
| Přiřazení | Vytvoří kopii | Zkopíruje odkaz |
| Dědičnost | ✗ nepodporuje | ✅ podporuje |
| `null` | ✗ nemůže být `null` | ✅ může být `null` |
| Typické použití | Malá, jednoduchá data | Složitější objekty s chováním |

### Kdy zvolit `struct`?

- Data jsou **malá a jednoduchá** (2–4 pole)
- Logicky reprezentují **jednu hodnotu** (bod, barva, souřadnice, rozměr)
- Nepotřebuješ dědičnost
- Potřebuješ kopírování hodnotou (nechceš sdílené reference)

Typické příklady: `Point`, `Color`, `Size`, `Rectangle`, `Vector2D`.

> 💡 Zabudované typy jako `int`, `double` nebo `bool` jsou interně také structs.

### Kdy zůstat u třídy?

- Objekt má **složitou logiku a chování**
- Potřebuješ **dědičnost** nebo polymorfismus
- Data jsou velká nebo se mění za běhu
- Potřebuješ `null` jako platnou hodnotu

---

## Kompletní příklad

Struct a enum kombinované v jednom programu – jednoduchý model úkolu:

```csharp
enum Priority { Low, Medium, High }

struct Task
{
    public string Title    { get; }
    public Priority Level  { get; }
    public bool IsDone     { get; private set; }

    public Task(string title, Priority level)
    {
        Title   = title;
        Level   = level;
        IsDone  = false;
    }

    public void Complete() => IsDone = true; // struct metoda

    public override string ToString() =>
        $"[{(IsDone ? "✓" : " ")}] {Title} ({Level})";
}
```

```csharp
Task t1 = new Task("Napsat testy", Priority.High);
Task t2 = new Task("Aktualizovat dokumentaci", Priority.Low);

t1.Complete();

Console.WriteLine(t1); // [✓] Napsat testy (High)
Console.WriteLine(t2); // [ ] Aktualizovat dokumentaci (Low)
```

---

## Shrnutí

| Pojem | Klíčové info |
|---|---|
| `enum` | Pojmenované konstanty, výchozí typ `int`, přetypovatelné |
| `enum` + `switch` | Přirozená kombinace pro větvení |
| `struct` | Hodnotový typ, kopírování hodnotou, bez dědičnosti |
| `struct` vs `class` | Struct pro malá data, třída pro složité objekty |
| Kdy `struct` | Bod, barva, souřadnice, rozměr – malé, neměnné hodnoty |
