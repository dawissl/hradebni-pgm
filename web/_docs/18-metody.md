---
layout: post
title: "Metody"
order: 18
---

Jak program roste, začíná být obtížné udržovat veškerý kód na jednom místě. Opakující se části programu zhoršují přehlednost a zvyšují riziko chyb.

Řešením jsou **metody** – pojmenované bloky kódu, které vykonávají konkrétní úkol. Metody umožňují rozdělit program na menší, přehlednější a znovupoužitelné části.

---

## Co je metoda?

Metoda je skupina příkazů, kterou lze spustit pod jejím názvem.

Místo opakovaného psaní stejného kódu vytvoříme metodu a tu následně voláme podle potřeby.

```csharp
SayHello();

void SayHello()
{
    Console.WriteLine("Ahoj světe!");
}
```

Výstup:

```
Ahoj světe!
```

---

## Proč používat metody?

Bez metod:

```csharp
Console.WriteLine("Ahoj Davide!");
Console.WriteLine("Vítej v programu.");

Console.WriteLine("Ahoj Jano!");
Console.WriteLine("Vítej v programu.");
```

S metodou:

```csharp
WelcomeUser("David");
WelcomeUser("Jana");

void WelcomeUser(string name)
{
    Console.WriteLine($"Ahoj {name}!");
    Console.WriteLine("Vítej v programu.");
}
```

Výhody metod:

- přehlednější kód
- menší množství opakování
- jednodušší údržba
- možnost opětovného použití
- snazší testování

---

## Deklarace a volání metody

Základní tvar metody:

```csharp
returnType MethodName(parameters)
{
    // tělo metody
}
```

Příklad:

```csharp
void PrintLine()
{
    Console.WriteLine("--------------------");
}
```

Volání:

```csharp
PrintLine();
```

---

## Metoda bez návratové hodnoty

Pokud metoda nic nevrací, používá návratový typ `void`.

```csharp
void ShowMenu()
{
    Console.WriteLine("1 - Nová hra");
    Console.WriteLine("2 - Načíst hru");
    Console.WriteLine("3 - Konec");
}
```

```csharp
ShowMenu();
```

---

## Parametry

Parametry umožňují předávat metodě data.

```csharp
void Greet(string name)
{
    Console.WriteLine($"Ahoj {name}!");
}
```

Volání:

```csharp
Greet("Kamil");
Greet("Jana");
```

Výstup:

```
Ahoj Kamil!
Ahoj Jana!
```

---

### Více parametrů

```csharp
void Introduce(string name, int age)
{
    Console.WriteLine($"{name} má {age} let.");
}
```

```csharp
Introduce("Tomáš", 18);
```

---

## Návratová hodnota

Metoda může vrátit výsledek pomocí klíčového slova `return`.

```csharp
int Add(int a, int b)
{
    return a + b;
}
```

Volání:

```csharp
int result = Add(5, 3);

Console.WriteLine(result);
```

Výstup:

```
8
```

---

### Metoda vracející text

```csharp
string GetFullName(string firstName, string lastName)
{
    return $"{firstName} {lastName}";
}
```

```csharp
string fullName = GetFullName("Jan", "Novák");

Console.WriteLine(fullName);
```

---

## Lokální proměnné

Proměnné vytvořené uvnitř metody existují pouze během jejího vykonávání.

```csharp
void Calculate()
{
    int result = 5 + 10;
    Console.WriteLine(result);
}
```

Proměnná `result` není mimo metodu dostupná.

```csharp
Calculate();

// Console.WriteLine(result); // chyba
```

---

## Předávání parametrů hodnotou

Ve výchozím nastavení se parametry předávají hodnotou.

```csharp
void Increase(int number)
{
    number++;
}

int value = 10;

Increase(value);

Console.WriteLine(value);
```

Výstup:

```
10
```

Změna proběhla pouze uvnitř metody.

---

## Metody vracející logickou hodnotu

Často potřebujeme zjistit, zda je splněna nějaká podmínka.

```csharp
bool IsAdult(int age)
{
    return age >= 18;
}
```

Použití:

```csharp
if (IsAdult(20))
{
    Console.WriteLine("Plnoletý");
}
```

---

## Rozdělení programu pomocí metod

Místo jednoho dlouhého programu:

```csharp
Console.Write("Zadej první číslo: ");
int a = Convert.ToInt32(Console.ReadLine());

Console.Write("Zadej druhé číslo: ");
int b = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"Součet: {a + b}");
```

můžeme program rozdělit:

```csharp
int first = ReadNumber("Zadej první číslo:");
int second = ReadNumber("Zadej druhé číslo:");

int result = Add(first, second);

Console.WriteLine($"Součet: {result}");

int ReadNumber(string message)
{
    Console.Write(message + " ");
    return Convert.ToInt32(Console.ReadLine());
}

int Add(int a, int b)
{
    return a + b;
}
```

Každá metoda řeší pouze jeden konkrétní úkol.

---

## Kompletní příklad

Program vypočítá obsah obdélníku.

```csharp
double width = ReadNumber("Zadej šířku:");
double height = ReadNumber("Zadej výšku:");

double area = CalculateArea(width, height);

Console.WriteLine($"Obsah: {area}");

double ReadNumber(string message)
{
    Console.Write(message + " ");
    return Convert.ToDouble(Console.ReadLine());
}

double CalculateArea(double width, double height)
{
    return width * height;
}
```

---

## Doporučení pro tvorbu metod

Dobrá metoda:

- řeší jeden konkrétní problém
- má výstižný název
- není zbytečně dlouhá
- pokud možno neprovádí více nesouvisejících činností

Příklad vhodného názvu:

```csharp
CalculateAverage()
ReadStudentName()
SaveFile()
```

Méně vhodné:

```csharp
DoStuff()
HandleEverything()
Method1()
```


## Přetěžování metod (Method Overloading)

V jednom programu můžeme mít více metod se stejným názvem, pokud se liší počtem nebo typem parametrů.

Tomu říkáme přetěžování metod.

```csharp

int Add(int a, int b)
{
    return a + b;
}

int Add(int a, int b, int c)
{
    return a + b + c;
}
```

Použití:

```csharp

Console.WriteLine(Add(5, 3));      // 8
Console.WriteLine(Add(5, 3, 2));   // 10
```

Přetěžovat lze i pomocí různých datových typů:

```csharp
double Add(double a, double b)
{
    return a + b;
}
```

> 💡 Přetěžování umožňuje používat stejný název metody pro podobné operace.

## Předávání pomocí `ref`

Ve výchozím stavu se parametry předávají hodnotou. Pokud chceme, aby metoda mohla změnit původní proměnnou, použijeme klíčové slovo `ref`.

```csharp

void Increase(ref int number)
{
    number++;
}
```

Použití:

```csharp
int value = 10;

Increase(ref value);

Console.WriteLine(value);
```

Výstup:

11

> 💡 Parametr označený jako ref musí být inicializovaný ještě před voláním metody.

## Předávání pomocí out

Klíčové slovo `out` umožňuje metodě vrátit více hodnot.

```csharp
void Divide(int a, int b, out int result, out int remainder)
{
    result = a / b;
    remainder = a % b;
}
```

Použití:

```csharp

Divide(17, 5, out int quotient, out int remainder);

Console.WriteLine($"Podíl: {quotient}");
Console.WriteLine($"Zbytek: {remainder}");
```

Výstup:

Podíl: 3
Zbytek: 2

> ⚠️ Parametr out nemusí být před voláním inicializován, ale metoda mu musí přiřadit hodnotu.

### Kdy použít return, ref a out?
|Technika	|Použití|
|return|	metoda vrací jeden výsledek|
|ref	|metoda upravuje existující proměnnou|
|out	|metoda vrací více výsledků|

Ve většině případů je nejlepší použít return. Konstrukce ref a out používej pouze tehdy, když dávají jasný smysl.


---

## Shrnutí

| Pojem | Příklad |
|---|---|
| Metoda | `PrintLine()` |
| Parametr | `PrintLine(string text)` |
| Návratová hodnota | `int Add(int a, int b)` |
| Bez návratové hodnoty | `void ShowMenu()` |
| Volání metody | `Add(5, 3)` |
| Návrat výsledku | `return result;` |
|Přetížení	|`Add(int, int) a Add(int, int, int)`|
|ref	|`Increase(ref number)`|
|out	|`Divide(..., out result)`|

---

## Závěr

Metody patří mezi nejdůležitější nástroje pro tvorbu kvalitního kódu. Umožňují rozdělit program na menší části, omezit opakování kódu a vytvářet přehlednější aplikace.

Při návrhu programu se vyplatí přemýšlet nad tím, které části kódu dávají smysl oddělit do samostatných metod. Čím lépe je program rozdělen, tím snadněji se rozšiřuje, testuje a opravuje.