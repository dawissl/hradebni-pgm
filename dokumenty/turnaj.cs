using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TurnajHracu
{
    public partial class Form1 : Form
    {
        private List<Hrac> hraci = new List<Hrac>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnPridat_Click(object sender, EventArgs e)
        {
            // TODO:
            // 1. Načti jméno z txtJmeno
            // 2. Načti body z txtBody
            // 3. Ověř, že jméno není prázdné
            // 4. Ověř, že body jsou kladné
            // 5. Vytvoř objekt Hrac
            // 6. Přidej hráče do kolekce
            // 7. Aktualizuj ListBox
        }

        private void btnVyhodnotit_Click(object sender, EventArgs e)
        {
            // TODO:
            // 1. Ověř, že existuje alespoň jeden hráč
            // 2. Najdi hráče s nejvyšším počtem bodů
            // 3. Spočítej průměr bodů
            // 4. Vypiš výsledek do lblVysledek
        }

        private void btnSmazat_Click(object sender, EventArgs e)
        {
            // TODO:
            // 1. Vymaž kolekci hráčů
            // 2. Vymaž ListBox
            // 3. Vymaž výsledek
        }

        private void AktualizujSeznam()
        {
            // TODO:
            // 1. Vymaž ListBox
            // 2. Pomocí cyklu projdi všechny hráče
            // 3. Každého hráče přidej do ListBoxu
        }

        private double SpocitejPrumer()
        {
            // TODO:
            // 1. Vytvoř proměnnou pro součet
            // 2. Pomocí cyklu sečti body všech hráčů
            // 3. Vrať průměr

            return 0;
        }

        private Hrac NajdiViteze()
        {
            // TODO:
            // 1. Jako vítěze nastav prvního hráče
            // 2. Pomocí cyklu projdi všechny hráče
            // 3. Pokud má některý hráč více bodů, nastav ho jako vítěze
            // 4. Vrať vítěze

            return null;
        }
    }
    
    public class Hrac
    {
        private string jmeno;
        private int body;

        public string Jmeno { get { return jmeno; } }

        public int Body { get { return body; } }

        public Hrac(string jmeno, int body)
        {
            this.jmeno = jmeno;
            this.body = body;
        }

        public override string ToString()
        {
            return $"{jmeno} - {body} bodů";
        }
    }
}

