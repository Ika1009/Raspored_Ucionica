
namespace Raspored_Ucionica.Model
{
    public class Odeljenje
    {
        static int brojac_odeljenja = -1;
        private readonly int id;
        int broj_ucenika;
        int? id_ucionice;
        string ime_odeljenja;
        public int Id
        {
            get => id;
        }
        public int Broj_ucenika
        {
            get => broj_ucenika;
            set
            {
                if (value > 40)
                    broj_ucenika = 40;
                else
                    broj_ucenika = value;
            }
        }
        public int? Id_ucionice { 
            get => id_ucionice;
            set
            {
                id_ucionice = value;
            } 
        }
        public string Ime_odeljenja 
        {
            get => ime_odeljenja;
            set
            {
                ime_odeljenja = value;
            }
        }
        public Odeljenje(string imeOdeljenjaUnos, int brojucenikaUnos, int unosUcionica)
        {
            id = brojac_odeljenja + 1;
            brojac_odeljenja++;
            Broj_ucenika = brojucenikaUnos;
            Id_ucionice = unosUcionica;
            Ime_odeljenja = imeOdeljenjaUnos;
        }
        public Odeljenje(string imeOdeljenjaUnos, int brojucenikaUnos)
        {
            id = brojac_odeljenja + 1;
            brojac_odeljenja++;
            Broj_ucenika = brojucenikaUnos;
            Id_ucionice = null;
            Ime_odeljenja = imeOdeljenjaUnos;
        }
    }
}
