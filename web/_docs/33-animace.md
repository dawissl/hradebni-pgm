---
layout: post
title: "Animace a časovač"
order: 330
---

Animace ve WinForms stojí na jednoduchém principu: v pravidelných intervalech aktualizujete stav (pozici, barvu, velikost) a překreslíte scénu. K tomu slouží `Timer` z kapitoly 29 v kombinaci s `Graphics` z kapitoly 32.

---

## Princip animace

```
Timer.Tick → aktualizuj stav → Invalidate() → Paint → nakresli nový stav
```

Tento cyklus se opakuje každých `Interval` milisekund.

---

## Pohyblivý objekt — příklad

Míč, který se pohybuje po formuláři a odráží od stěn.

```csharp
public partial class Form1 : Form
{
    int x = 100, y = 100;       // pozice míče
    int dx = 5, dy = 3;         // rychlost (px za tik)
    int polomer = 20;

    public Form1()
    {
        InitializeComponent();
        timer1.Interval = 16;   // ~60 FPS
        timer1.Start();

        this.DoubleBuffered = true;  // zabrání blikání
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        // Aktualizuj pozici
        x += dx;
        y += dy;

        // Odrazy od okrajů
        if (x - polomer < 0 || x + polomer > this.ClientSize.Width)
            dx = -dx;
        if (y - polomer < 0 || y + polomer > this.ClientSize.Height)
            dy = -dy;

        this.Invalidate();  // vyžádej překreslení
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.Clear(Color.White);  // smaž předchozí snímek

        g.FillEllipse(Brushes.DodgerBlue,
            x - polomer, y - polomer,
            polomer * 2, polomer * 2);
    }
}
```

---

## DoubleBuffered — zbavení se blikání

Bez `DoubleBuffered = true` WinForms kreslí přímo na obrazovku — při každém překreslení chvíli vidíte prázdné pozadí, což způsobí blikání.

S `DoubleBuffered = true` se celý snímek nejprve složí do paměti a teprve hotový se zobrazí.

```csharp
this.DoubleBuffered = true;  // vždy zapněte u animací
```

---

## Malířův algoritmus

Při každém snímku kresli objekty **od pozadí k popředí** — každý objekt překryje to, co bylo pod ním. Tomuto principu se říká malířův algoritmus.

```csharp
private void Form1_Paint(object sender, PaintEventArgs e)
{
    Graphics g = e.Graphics;

    // 1. Pozadí
    g.Clear(Color.LightSkyBlue);

    // 2. Objetky na pozadí (tráva, mraky...)
    g.FillRectangle(Brushes.Green, 0, this.ClientSize.Height - 60,
                    this.ClientSize.Width, 60);

    // 3. Pohyblivé objekty (v popředí)
    g.FillEllipse(Brushes.Yellow, slunceX, 20, 60, 60);
    g.FillEllipse(Brushes.Red, micX - polomer, micY - polomer,
                  polomer * 2, polomer * 2);
}
```

---

## Více pohyblivých objektů

Pro více objektů stejného typu použij seznam:

```csharp
class Hvezdicka
{
    public float X, Y, Rychlost;
    public int Polomer;
}

List<Hvezdicka> hvezdicky = new List<Hvezdicka>();

private void Form1_Load(object sender, EventArgs e)
{
    Random rnd = new Random();
    for (int i = 0; i < 20; i++)
    {
        hvezdicky.Add(new Hvezdicka {
            X = rnd.Next(0, this.ClientSize.Width),
            Y = rnd.Next(0, this.ClientSize.Height),
            Rychlost = (float)(rnd.NextDouble() * 3 + 1),
            Polomer = rnd.Next(3, 10)
        });
    }
    timer1.Start();
}

private void timer1_Tick(object sender, EventArgs e)
{
    foreach (var h in hvezdicky)
    {
        h.Y += h.Rychlost;
        if (h.Y > this.ClientSize.Height)
            h.Y = 0;
    }
    this.Invalidate();
}

private void Form1_Paint(object sender, PaintEventArgs e)
{
    Graphics g = e.Graphics;
    g.Clear(Color.Black);

    foreach (var h in hvezdicky)
        g.FillEllipse(Brushes.White,
            h.X - h.Polomer, h.Y - h.Polomer,
            h.Polomer * 2, h.Polomer * 2);
}
```

---

## Shrnutí

| Krok | Co uděláte |
|---|---|
| Nastavte `Timer.Interval` | Určuje rychlost animace (16 ms ≈ 60 FPS) |
| `DoubleBuffered = true` | Zabrání blikání |
| V `Tick` aktualizujte stav | Přepočítejte pozice, fyziku |
| Zavolejte `Invalidate()` | Vyžádá překreslení |
| V `Paint` nakreslete scénu | Od pozadí k popředí (malířův algoritmus) |
---

## Otázky k zamyšlení

1. Jak vzniká na obrazovce dojem pohybu? Jaké dvě věci se musí pravidelně opakovat?
2. Co dělá vlastnost `Interval` u komponenty `Timer` a jaký interval odpovídá zhruba 30 snímkům za sekundu?
3. Proč se poloha animovaného objektu drží v proměnných formuláře, a ne v lokálních proměnných metody `Tick`?

---

## Procvičení

### Řešený příklad

**Zadání:** Vytvořte animaci míčku, který se pohybuje po formuláři a odráží se od jeho okrajů.

<details markdown="1">
<summary>💡 Zobrazit řešení</summary>

Stav animace = poloha a rychlost. `Tick` časovače stav posune a vyžádá překreslení; `Paint` jen kreslí aktuální stav:

```csharp
private int x = 50, y = 50;      // poloha míčku
private int dx = 4, dy = 3;      // rychlost (posun na 1 tik)
private const int R = 30;        // průměr míčku

public Form1()
{
    InitializeComponent();
    this.DoubleBuffered = true;  // odstraní blikání
    timer1.Interval = 20;        // ~50 fps
    timer1.Start();
}

private void timer1_Tick(object sender, EventArgs e)
{
    x += dx;
    y += dy;

    // odrazy od stěn: otočíme znaménko rychlosti
    if (x <= 0 || x + R >= ClientSize.Width) dx = -dx;
    if (y <= 0 || y + R >= ClientSize.Height) dy = -dy;

    Invalidate();
}

private void Form1_Paint(object sender, PaintEventArgs e)
{
    e.Graphics.FillEllipse(Brushes.OrangeRed, x, y, R, R);
}
```

Dva detaily, které rozhodují o kvalitě: `DoubleBuffered = true` (bez něj animace bliká) a použití `ClientSize` místo `Width`/`Height` (rozměry bez rámečku a titulku okna).

</details>

### Samostatná cvičení

1. **Základní** — Přidejte dvě tlačítka: Start/Stop animace a "Zrychlit" (zmenšení `Interval` nebo zvětšení rychlosti).
2. **Pokročilejší** — Přidejte druhý míček s jinou rychlostí a barvou. Pak zobecněte: `List` míčků (poloha, rychlost, barva) a cykly v `Tick` i `Paint`.
3. **Bonus (*)** — Udělejte z míčku jednoduchou hru: dole se pohybuje pálka ovládaná šipkami (událost `KeyDown`), míček se od ní odráží; když propadne dolů, hra končí.