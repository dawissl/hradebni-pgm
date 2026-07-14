---
layout: post
title: "Grafika a animace"
order: 31
---

WinForms umožňuje kreslit přímo na formulář nebo komponentu — čáry, obdélníky, kruhy, text, obrázky. K tomu slouží třída `Graphics` z jmenného prostoru `System.Drawing`. Tato a následující dvě kapitoly vám ukážou, jak s ní pracovat.

---

## Přehled

| Kapitola | Obsah |
|---|---|
| **[Grafika a animace](./31-grafika.md)** | Přehled, první krok, souřadnicový systém |
| **[Základy práce s grafikou](./32-grafika-zaklady.md)** | Pen, Brush, kreslicí metody, událost Paint |
| **[Animace a časovač](./33-animace.md)** | Timer, pohyblivé objekty, překreslování |

---

## Třída `Graphics`

`Graphics` je objekt reprezentující „plátno", na které kreslíte. Nezískaš ho přes `new` — vždy ho dostaneš z události nebo z komponenty.

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

> ⚠️ Kreslení mimo událost `Paint` se při překreslení okna ztratí — okno se obnoví, WinForms zavolá `Paint`, a vše, co jste nakreslili mimo něj, zmizí. Používejte `Paint` jako hlavní místo pro kreslení.

---

## Souřadnicový systém

Počátek `[0, 0]` je v **levém horním** rohu komponenty. Osa X roste doprava, osa Y roste **dolů**.

![Souřadnicový systém WinForms: počátek vlevo nahoře, X doprava, Y dolů, s vyznačenými body např. [100, 50]](../assets/grafika-souradnice.png)

```csharp
// Bod [100, 50] je 100 px od levého okraje, 50 px od horního okraje
g.DrawRectangle(Pens.Black, 100, 50, 200, 100);
// parametry: pero, x, y, šířka, výška
```

---

## Vyvolání překreslení

Chcete-li, aby se kreslení aktualizovalo (např. po změně dat), zavolejte:

```csharp
this.Invalidate();  // označí formulář jako „potřebuje překreslit"
// WinForms automaticky zavolá Paint
```

---

## Co vás čeká v dalších kapitolách

V kapitole 32 se naučíte kreslit základní tvary pomocí `Pen` a `Brush`, psát text a pracovat s obrázky. V kapitole 33 to rozšíříme o animaci pomocí `Timer`.
---

## Otázky k zamyšlení

1. Proč se ve WinForms kreslí v události `Paint`, a ne třeba jednorázově po startu aplikace?
2. Co se stane s nakreslenou grafikou, když okno minimalizujete a obnovíte? Kdo a proč překreslení vyvolá?
3. Jaký je rozdíl mezi souřadným systémem v matematice a na obrazovce? Kde je bod (0, 0)?

---

## Procvičení

### Řešený příklad

**Zadání (teoretické):** Vysvětlete, proč tento přístup nefunguje spolehlivě, a popište správné řešení:

```csharp
private void btnKresli_Click(object sender, EventArgs e)
{
    Graphics g = this.CreateGraphics();
    g.FillEllipse(Brushes.Red, 50, 50, 100, 100);
}
```

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

Kód sice kruh nakreslí, ale jen "na jedno použití". Okno si nakreslený obsah **nepamatuje** — jakmile ho něco překryje, minimalizujete ho nebo změníte velikost, systém vyvolá překreslení a kruh zmizí, protože nikdo neví, že tam měl být.

Správné řešení: kreslicí kód patří do události `Paint`, kterou systém volá vždy, když je potřeba obsah obnovit:

```csharp
private bool kreslitKruh = false;

private void btnKresli_Click(object sender, EventArgs e)
{
    kreslitKruh = true;
    this.Invalidate();   // požádá o překreslení → vyvolá Paint
}

private void Form1_Paint(object sender, PaintEventArgs e)
{
    if (kreslitKruh)
        e.Graphics.FillEllipse(Brushes.Red, 50, 50, 100, 100);
}
```

Vzor k zapamatování: **stav** (co se má kreslit) drží proměnné, **kreslení** dělá výhradně `Paint`, a změna stavu volá `Invalidate()`.

</details>

### Samostatná cvičení

1. **Základní** — Vyjmenujte tři situace, kdy operační systém vyvolá překreslení okna, aniž by uživatel klikl na cokoli v aplikaci.
2. **Pokročilejší** — Rozmyslete (bez kódu), jak byste uchovali "stav" pro kreslicí program, kde uživatel klikáním přidává kruhy: jaká struktura, co je jejím prvkem, kdy se volá `Invalidate`.
3. **Bonus (*)** — Zjistěte rozdíl mezi `Invalidate()`, `Update()` a `Refresh()`.