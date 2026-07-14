---
layout: post
title: "Základy práce s grafikou"
order: 32
---

Tato kapitola navazuje na přehled z kapitoly 31. Naučíte se kreslit základní tvary, pracovat s barvami a textem a správně obsluhovat událost `Paint`.

---

## Pen a Brush

Pro kreslení potřebujete dva nástroje:

| Nástroj | Třída | Použití |
|---|---|---|
| Pero | `Pen` | Obrysy čar a tvarů |
| Štětec | `Brush` | Výplně ploch |

```csharp
// Hotová pera z třídy Pens (nepotřebuješ Dispose)
Pens.Black
Pens.Red

// Vlastní pero — barva a tloušťka
using Pen pero = new Pen(Color.Blue, 3);

// Štětce — plné barvy
using SolidBrush stetec = new SolidBrush(Color.LightYellow);
```

> 💡 Vlastní `Pen` a `Brush` jsou `IDisposable` — použijte `using`, aby se automaticky uvolnily po použití.

> 📌 Toto je jiný význam `using` než ten z kapitoly 5 (import jmenného prostoru). Tady `using Pen pero = ...;` znamená „až tato proměnná vypadne z platnosti, automaticky zavolej `pero.Dispose()`" — hodí se u objektů, které si berou omezené systémové prostředky (zde: kreslicí nástroj) a je potřeba je po použití uvolnit.

---

## Kreslicí metody

Všechny metody voláte na objektu `Graphics`. Metody s `Draw` kreslí obrys, s `Fill` kreslí vyplněný tvar.

### Čára

```csharp
g.DrawLine(Pens.Black, 10, 10, 200, 100);
// parametry: pero, x1, y1, x2, y2
```

### Obdélník

```csharp
g.DrawRectangle(Pens.Black, 50, 50, 150, 80);
g.FillRectangle(Brushes.LightBlue, 50, 50, 150, 80);
// parametry: pero/štětec, x, y, šířka, výška
```

### Elipsa (a kruh)

```csharp
g.DrawEllipse(Pens.Red, 100, 100, 120, 80);  // elipsa
g.FillEllipse(Brushes.Yellow, 200, 50, 60, 60);  // kruh (stejná šířka i výška)
// parametry: pero/štětec, x, y, šířka, výška — ohraničující obdélník
```

### Mnohoúhelník

```csharp
Point[] body = {
    new Point(150, 20),
    new Point(250, 80),
    new Point(200, 160),
    new Point(100, 160),
    new Point(50, 80)
};
g.DrawPolygon(Pens.DarkGreen, body);
g.FillPolygon(Brushes.LightGreen, body);
```

---

## Text

```csharp
using Font font = new Font("Arial", 14, FontStyle.Bold);
using SolidBrush stetec = new SolidBrush(Color.DarkBlue);

g.DrawString("Ahoj světe!", font, stetec, 50, 30);
// parametry: text, font, štětec, x, y
```

---

## Událost Paint — kompletní příklad

```csharp
private void Form1_Paint(object sender, PaintEventArgs e)
{
    Graphics g = e.Graphics;

    // Pozadí
    g.FillRectangle(Brushes.White, this.ClientRectangle);

    // Domeček
    g.FillRectangle(Brushes.SandyBrown, 100, 150, 200, 150);    // stěny
    g.DrawRectangle(Pens.Black, 100, 150, 200, 150);

    Point[] strecha = {
        new Point(80, 150),
        new Point(200, 60),
        new Point(320, 150)
    };
    g.FillPolygon(Brushes.Firebrick, strecha);   // střecha
    g.DrawPolygon(Pens.Black, strecha);

    g.FillRectangle(Brushes.SkyBlue, 170, 170, 60, 50);  // okno
    g.DrawRectangle(Pens.Black, 170, 170, 60, 50);

    g.FillRectangle(Brushes.SaddleBrown, 175, 240, 50, 60);  // dveře
}
```

![Výsledek kreslení domečku na formuláři — hnědé stěny, červená střecha, modré okno, hnědé dveře](../assets/grafika-domecek.png)

---

## Práce s obrázky

```csharp
// Načtení obrázku ze souboru
Image obrazek = Image.FromFile("logo.png");
g.DrawImage(obrazek, 10, 10);                        // původní velikost
g.DrawImage(obrazek, new Rectangle(10, 10, 100, 80)); // přizpůsobená velikost
```

Pro opakované použití obrázku ho načtěte jednou (např. v `Form_Load`) do proměnné třídy — nevoláte `Image.FromFile` při každém překreslení.

---

## Shrnutí

| Metoda | Co kreslí |
|---|---|
| `DrawLine` | Čára |
| `DrawRectangle` / `FillRectangle` | Obdélník (obrys / výplň) |
| `DrawEllipse` / `FillEllipse` | Elipsa / kruh |
| `DrawPolygon` / `FillPolygon` | Mnohoúhelník |
| `DrawString` | Text |
| `DrawImage` | Obrázek |
---

## Otázky k zamyšlení

1. Jaký je rozdíl mezi `Pen` a `Brush`? Které metody `Graphics` používají který?
2. Metody jako `DrawRectangle(x, y, sirka, vyska)` — co přesně znamenají parametry x a y? Kde je "kotva" obdélníku?
3. Proč je dobré objekty `Pen`/`Brush` vytvořené přes `new` uzavírat do `using`?

---

## Procvičení

### Řešený příklad

**Zadání:** V události `Paint` nakreslete jednoduchý domeček: čtvercové tělo, trojúhelníková střecha, obdélníkové dveře a kruhové okno.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

```csharp
private void Form1_Paint(object sender, PaintEventArgs e)
{
    Graphics g = e.Graphics;

    // tělo domu
    g.FillRectangle(Brushes.BurlyWood, 100, 150, 200, 150);
    g.DrawRectangle(Pens.Black, 100, 150, 200, 150);

    // střecha – trojúhelník ze tří bodů
    Point[] strecha =
    {
        new Point(90, 150),    // levý okraj
        new Point(310, 150),   // pravý okraj
        new Point(200, 70)     // vrchol
    };
    g.FillPolygon(Brushes.Firebrick, strecha);
    g.DrawPolygon(Pens.Black, strecha);

    // dveře
    g.FillRectangle(Brushes.SaddleBrown, 170, 220, 60, 80);

    // okno
    g.FillEllipse(Brushes.LightBlue, 120, 180, 40, 40);
    g.DrawEllipse(Pens.Black, 120, 180, 40, 40);
}
```

Všimněte si dvojice `Fill...` (výplň štětcem) + `Draw...` (obrys perem) — pro pěkný výsledek se často kombinují, výplň vždy dřív. Souřadnice si při návrhu klidně načrtněte na papír: (0,0) je levý horní roh, y roste dolů.

</details>

### Samostatná cvičení

1. **Základní** — Rozšiřte domeček o slunce (žlutý kruh s čárami-paprsky přes `DrawLine`) a komín.
2. **Pokročilejší** — Nakreslete šachovnici 8×8 pomocí dvou vnořených cyklů — barvu políčka určete z podmínky `(radek + sloupec) % 2`.
3. **Bonus (*)** — Nakreslete terč z pěti soustředných kruhů. Kruhy musí být vystředěné na střed formuláře i po změně jeho velikosti (`ClientSize`, událost `Resize` + `Invalidate`).