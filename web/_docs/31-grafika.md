---
layout: post
title: "Grafika a animace"
order: 31
---

WinForms umožňuje kreslit přímo na formulář nebo komponentu — čáry, obdélníky, kruhy, text, obrázky. K tomu slouží třída `Graphics` z jmenného prostoru `System.Drawing`. Tato a následující dvě kapitoly ti ukážou, jak s ní pracovat.

---

## Přehled

| Kapitola | Obsah |
|---|---|
| **[Grafika a animace](./31-grafika.md)** | Přehled, první krok, souřadnicový systém |
| **[Základy práce s grafikou](./32-grafika-zaklady.md)** | Pen, Brush, kreslicí metody, událost Paint |
| **[Animace a časovač](./33-animace.md)** | Timer, pohyblivé objekty, překreslování |

---

## Třída `Graphics`

`Graphics` je objekt reprezentující „plátno", na které kreslíš. Nezískaš ho přes `new` — vždy ho dostaneš z události nebo z komponenty.

Dva nejčastější způsoby:

```csharp
// 1. V události Paint — správný způsob pro kreslení na formulář
private void Form1_Paint(object sender, PaintEventArgs e)
{
    Graphics g = e.Graphics;
    // kresli pomocí g
}

// 2. Ručně — pro jednorázové kreslení mimo Paint (méně časté)
Graphics g = this.CreateGraphics();
// kresli...
g.Dispose();  // vždy uvolnit!
```

> ⚠️ Kreslení mimo událost `Paint` se při překreslení okna ztratí — okno obnoví, WinForms zavolá `Paint`, a vše co jsi nakreslil mimo něj zmizí. Používej `Paint` jako hlavní místo pro kreslení.

---

## Souřadnicový systém

Počátek `[0, 0]` je v **levém horním** rohu komponenty. Osa X roste doprava, osa Y roste **dolů**.

![Souřadnicový systém WinForms: počátek vlevo nahoře, X doprava, Y dolů, s vyznačenými body např. [100, 50]](assets/grafika-souradnice.png)

```csharp
// Bod [100, 50] je 100 px od levého okraje, 50 px od horního okraje
g.DrawRectangle(Pens.Black, 100, 50, 200, 100);
// parametry: pero, x, y, šířka, výška
```

---

## Vyvolání překreslení

Chceš-li, aby se kreslení aktualizovalo (např. po změně dat), zavolej:

```csharp
this.Invalidate();  // označí formulář jako „potřebuje překreslit"
// WinForms automaticky zavolá Paint
```

---

## Co tě čeká v dalších kapitolách

V kapitole 32 se naučíš kreslit základní tvary pomocí `Pen` a `Brush`, psát text a pracovat s obrázky. V kapitole 33 to rozšíříme o animaci pomocí `Timer`.