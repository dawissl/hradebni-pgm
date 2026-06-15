---
layout: post
title: "Animace a časovač"
order: 33
---

Animace ve WinForms stojí na jednoduchém principu: v pravidelných intervalech aktualizuješ stav (pozici, barvu, velikost) a překreslíš scénu. K tomu slouží `Timer` z kapitoly 29 v kombinaci s `Graphics` z kapitoly 32.

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

Bez `DoubleBuffered = true` WinForms kreslí přímo na obrazovku — při každém překreslení chvíli vidíš prázdné pozadí, což způsobí blikání.

S `DoubleBuffered = true` se celý snímek nejprve složí do paměti a teprve hotový se zobrazí.

```csharp
this.DoubleBuffered = true;  // vždy zapni u animací
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

| Krok | Co uděláš |
|---|---|
| Nastav `Timer.Interval` | Určuje rychlost animace (16 ms ≈ 60 FPS) |
| `DoubleBuffered = true` | Zabrání blikání |
| V `Tick` aktualizuj stav | Přepočítej pozice, fyziku |
| Zavolej `Invalidate()` | Vyžádá překreslení |
| V `Paint` nakresli scénu | Od pozadí k popředí (malířův algoritmus) |