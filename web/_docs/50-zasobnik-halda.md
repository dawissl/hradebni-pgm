---
layout: post
title: "Zásobník a halda"
order: 50
---

Víme, že hodnotové typy uchovávají hodnotu přímo a referenční typy ukládají odkaz. Ale kde se tato data fyzicky nacházejí v paměti? Odpověď jsou dvě oblasti: **zásobník** (stack) a **halda** (heap).

---

## Zásobník (Stack)

Zásobník je rychlá paměťová oblast organizovaná jako LIFO (Last In, First Out) — poslední přidaný prvek je první odebraný.

Každé volání metody přidá na zásobník **rámec** (frame) s:
- lokálními proměnnými metody
- parametry metody
- návratovou adresou

Po skončení metody se rámec automaticky odebere — vše se vyčistí samo.

![Zásobník se třemi rámci: Main → VolejA → VolejB; šipka ukazuje na vrchol zásobníku](assets/stack-diagram.png)

**Hodnotové typy** (lokální proměnné jako `int`, `bool`, `struct`) se ukládají přímo na zásobník.

```csharp
void Metoda()
{
    int x = 10;       // na zásobníku
    double y = 3.14;  // na zásobníku
    // po skončení metody — oba zmizí automaticky
}
```

---

## Halda (Heap)

Halda je větší, ale pomalejší oblast paměti pro data s proměnnou životností. Objekty (instance tříd, pole) se alokují na haldě.

Proměnná (na zásobníku) drží **odkaz** (adresu) na objekt na haldě.

```csharp
void Metoda()
{
    int[] pole = new int[100];
    //  ↑ odkaz na zásobníku    ↑ 100 intů na haldě
}
```

![Zásobník s proměnnou pole obsahující šipku; šipka míří na objekt na haldě](assets/heap-diagram.png)

---

## Kopírování a sdílení

Toto vysvětluje chování z kapitoly 49:

```csharp
int a = 5;
int b = a;
// Zásobník: a=5, b=5 — dvě nezávislé hodnoty
```

```csharp
int[] x = new int[] { 1, 2, 3 };
int[] y = x;
// Zásobník: x=adresa1, y=adresa1 — dva odkaz na stejný objekt na haldě
```

---

## Praktické dopady

**Velikost zásobníku je omezená** — výchozí velikost je typicky 1–8 MB. Příliš hluboká rekurze způsobí `StackOverflowException`.

```csharp
// Toto způsobí StackOverflowException — zásobník se přeplní
void Nekonecna()
{
    Nekonecna();  // volá sama sebe bez podmínky ukončení
}
```

**Halda je spravována garbage collectorem** — viz kapitola 51. Objekty na haldě existují, dokud na ně existuje alespoň jeden odkaz.

---

## Shrnutí

| | Zásobník (Stack) | Halda (Heap) |
|---|---|---|
| Organizace | LIFO | Libovolná |
| Rychlost | Velmi rychlý | Pomalejší |
| Správa | Automatická (rámce metod) | Garbage collector |
| Ukládá | Hodnotové typy, odkazy | Objekty (referenční typy) |
| Omezení | Omezená velikost | Větší, ale fragmentuje se |
