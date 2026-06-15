---
layout: post
title: "Zapouzdření"
order: 43
---

Zapouzdření je první z pilířů OOP. Říká: **data objektu by měla být skryta před okolím a přístupná jen přes definované rozhraní**. Objekt je „černá skříňka" — víš, co dělá, ale nemusíš vědět, jak to dělá uvnitř.

---

## Proč skrývat data?

Bez zapouzdření může kdokoli zvenčí nastavit atribut objektu na libovolnou hodnotu — včetně nesmyslné:

```csharp
class Osoba
{
    public int Vek;
}

Osoba o = new Osoba();
o.Vek = -50;  // nikdo to nezastaví — ale záporný věk nedává smysl
```

Zapouzdření toto řeší: pole skryjeme a přístup k němu řídíme přes property.

---

## Modifikátory přístupu

| Modifikátor | Přístup |
|---|---|
| `public` | Odkudkoli |
| `private` | Pouze uvnitř třídy |
| `protected` | Uvnitř třídy a odvozených tříd |
| `internal` | Pouze v rámci stejného assembly (projektu) |

Základní pravidlo: **pole jsou `private`, přístup k nim je přes `public` properties**.

---

## Zapouzdření přes properties

```csharp
class Osoba
{
    private int vek;  // skryté pole

    public int Vek    // veřejná property
    {
        get { return vek; }
        set
        {
            if (value >= 0 && value <= 150)
                vek = value;
            // neplatná hodnota se tiše ignoruje
            // (nebo lze vyhodit výjimku — viz kapitola 35)
        }
    }
}
```

```csharp
Osoba o = new Osoba();
o.Vek = 25;   // ✅ projde setterem
o.Vek = -50;  // setter to odmítne
Console.WriteLine(o.Vek);  // 25
```

---

## Příklad: Bankovní účet

Klasický příklad zapouzdření — zůstatek lze měnit pouze přes metody, ne přímým přiřazením:

```csharp
class BankovniUcet
{
    private decimal zustatek;

    public decimal Zustatek => zustatek;  // pouze pro čtení zvenčí

    public void Vlozit(decimal castka)
    {
        if (castka <= 0)
            throw new ArgumentException("Částka musí být kladná.");
        zustatek += castka;
    }

    public void Vybrat(decimal castka)
    {
        if (castka <= 0)
            throw new ArgumentException("Částka musí být kladná.");
        if (castka > zustatek)
            throw new InvalidOperationException("Nedostatek prostředků.");
        zustatek -= castka;
    }
}
```

```csharp
BankovniUcet ucet = new BankovniUcet();
ucet.Vlozit(1000);
ucet.Vybrat(300);
Console.WriteLine(ucet.Zustatek);  // 700

// ucet.zustatek = 999999;  ❌ private — nepřístupné
```

Zůstatek nelze nastavit libovolně — vždy prochází logikou v metodách.

---

## Readonly properties

Pokud chceš property, do které lze zapsat jen uvnitř třídy (typicky v konstruktoru):

```csharp
public string Jmeno { get; private set; }  // zvenčí jen pro čtení

// nebo ještě striktnější — jen v konstruktoru:
public string Jmeno { get; init; }  // C# 9+
```

---

## Třída jako černá skříňka

Dobře zapouzdřená třída:

- **skrývá implementaci** — jak přesně počítá, ukládá, ověřuje, je vnitřní věcí třídy
- **definuje jasné rozhraní** — public metody a properties, se kterými uživatel třídy pracuje
- **chrání konzistenci dat** — nemůžeš dostat objekt do neplatného stavu

Díky tomu můžeš změnit vnitřek třídy (algoritmus, datovou strukturu) bez dopadu na kód, který třídu používá — pokud zachováš veřejné rozhraní.

---

## Shrnutí

| Pojem | Vysvětlení |
|---|---|
| Zapouzdření | Skrytí vnitřního stavu, přístup přes rozhraní |
| `private` | Přístupné jen uvnitř třídy |
| `public` | Přístupné odkudkoli |
| `protected` | Přístupné v třídě a potomcích |
| Property | Řízený přístup k soukromému poli přes get/set |