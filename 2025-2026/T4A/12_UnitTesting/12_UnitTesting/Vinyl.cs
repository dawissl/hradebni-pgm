using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_UnitTesting
{
    public class Vinyl
    {

        private int _id;
        private string _artist;
        private string _title;
        private int _bpm;
        private string _genre;
        private string _condition; // např. "Mint", "Very Good", "Good", "Fair"

        public int Id { get { return _id; } set { _id = value; } }

        public string Artist { get { return _artist; } }

        public string Title { get { return _title; } }

        public int Bpm { get { return _bpm; } set { if (value > 0 && value <= 300) { _bpm = value; } } }

        public string Genre { get { return _genre; } set { _genre = value; } }

        public string Condition { get { return _condition; } set { _condition = value; } }


        public Vinyl()
        {
            _id = 0;
            _artist = "";
            _title = "";
            _bpm = 120;
            _genre = "";
            _condition = "Good";
        }


        public Vinyl(int id, string artist, string title, int bpm, string genre, string condition)
        {
            _id = id;
            _artist = artist;
            _title = title;
            _bpm = bpm;
            _genre = genre;
            _condition = condition;
        }


        public override string ToString()
        {
            return $"{_artist} - {_title} | {_bpm} BPM | {_genre} | Stav: {_condition}";
        }
    }
}
