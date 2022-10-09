using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raspored_Ucionica.Model
{
    public class Kabineti
    {
        readonly List<List<string>> rasporedKabineta = new(260);

        public List<List<string>> RasporedKabineta
        {
            get => rasporedKabineta;
        }

        public Kabineti(List<List<string>> kabinetiUnos)
        {
            rasporedKabineta = kabinetiUnos;
        }
    }
}
