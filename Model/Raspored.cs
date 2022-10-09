using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raspored_Ucionica.Model
{
    public class Raspored
    {
        readonly List<List<string>> rasporedCasova = new(45);

        public List<List<string>> RasporedCasova
        {
            get => rasporedCasova; 
        }

        public Raspored(List<List<string>> rasporedUnos)
        {
            rasporedCasova = rasporedUnos;
        }
    }
}
