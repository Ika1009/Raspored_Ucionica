
namespace Raspored_Ucionica.Model
{
    public class Ucionica
    {
        static int brojac_ucionice = -1;
        readonly int id;
        bool slobodna;
        int velicina;
        string ime_ucionice;
        bool? tip;
        public string Ime_ucionice
        {
            get => ime_ucionice;
            set
            {
                ime_ucionice = value;
            }
        }//evo
        public int Id
        {
            get => id;
        }
        public int Velicina
        {
            get => velicina;
            set
            {
                if (value > 40)
                    velicina = 40;
                else
                    velicina = value;
            }
        }
        public bool Slobodna {
            get => slobodna;
            set
            {
                slobodna = value;
            }
        }

        public bool? Tip
        {
            get => tip;
            set
            {
                tip = value;
            }
        }

        public Ucionica(string ime_ucionice, int velicinaUnos, bool slobodnaUnos, bool tipUnos)
        {
            id = brojac_ucionice + 1;
            brojac_ucionice++;
            Velicina = velicinaUnos;
            Slobodna = slobodnaUnos;
            Ime_ucionice = ime_ucionice;
            Tip = tipUnos;
        }
        public Ucionica(string ime_ucionice, int velicinaUnos, bool slobodnaUnos)
        {
            id = brojac_ucionice + 1;
            brojac_ucionice++;
            Velicina = velicinaUnos;
            Slobodna = slobodnaUnos;
            Ime_ucionice = ime_ucionice;
            Tip = null;
        }
    }
}
