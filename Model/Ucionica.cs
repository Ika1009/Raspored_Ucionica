
namespace Raspored_Ucionica.Model
{
    public class Ucionica
    {
        static readonly int brojac_ucionice = 0;
        readonly int id;
        bool slobodna;
        int velicina;
        string ime_ucionice;
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

        public Ucionica(string ime_ucionice, int velicinaUnos, bool slobodnaUnos)
        {
            id = brojac_ucionice + 1;
            Velicina = velicinaUnos;
            Slobodna = slobodnaUnos;
            Ime_ucionice = ime_ucionice;
        }
    }
}
