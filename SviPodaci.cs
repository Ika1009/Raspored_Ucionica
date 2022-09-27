using Raspored_Ucionica.Model;

namespace Raspored_Ucionica
{
    public class SviPodaci
    {
        public readonly List<Odeljenje>? lista_odeljenja;
        public readonly List<Ucionica>? lista_ucionica;
        public readonly Raspored? Ponedeljak_raspored;
        public SviPodaci()
        {
            List<List<string>> list = new()
            {
                new List<string>() {"info", "", "", "", "izborni", "", "", "", "", "verska", "", "izborni", "izborni", "verska", "izborni", "", "", "", "", "izborni","pr.nauke", "", "", "", "", "", "", "info", "", "", "mni", ""},
                new List<string>() {"info", "mat", "mat", "mat", "mat", "nem", "geo", "info", "ist", "eng", "bio", "bio", "n/f/i/r", "fiz", "n/f/i/r", "mat", "fiz", "dmat", "srp", "","prnauke", "eng", "mat", "geo", "g1", "", "hem/bio", "info", "hem", "info", "srp", "fv"},
                new List<string>() {"mat", "info", "lat", "hem", "geo", "bio", "nem", "info", "fiz", "ist", "fv", "nem/eng", "mat", "bio/fiz", "mat", "geo", "dmat", "mat", "eng", "eng/info","srp", "fv", "mat", "bio", "socio", "mat", "hem/bio", "mat", "mat", "info", "srp", "muz"},
                new List<string>() {"mat", "info", "fiz", "n/f/r", "n/f/i/r", "muz", "info", "n/f/i/r", "srp", "fiz", "hem", "mat", "ist", "bio", "eng", "srp", "mat", "mat", "fiz", "fiz/info","geo", "hem", "eng/info", "mat", "mat", "srp", "mat", "mat", "socio", "bio", "fv", "srp"},
                new List<string>() {"eng", "hem", "srp", "bio", "ist", "geo", "info", "mat", "srp", "mat", "mat", "mat", "hem/info", "hem", "fv", "srp", "mat", "info", "bio/fiz", "geo","mat", "info/fiz", "eng", "fv", "bio", "srp", "bio", "nem/fiz/f", "n/f/e", "fiz", "nem/eng", "ist"},
                new List<string>() {"fv", "geo", "hem", "ist", "srp", "izborni", "mat", "geo", "mat", "srp", "info", "fiz/hem", "hem/info", "mat", "lat", "psiho", "eng", "info", "bio", "bio","mat", "geo", "fv", "srp", "fiz", "bio", "info/fiz", "srp", "filo", "n/f/e", "ist", "n/f/e"},
                new List<string>() { "srp", "fv", "geo", "fv", "lat", "", "jmk", "bio", "psiho", "srp", "info", "ist", "info", "psiho", "verska", "verska", "srp", "info", "hem", "nem", "savteh", "bio", "bio/strani", "izborni", "n/fiz/f", "srp", "eng", "info/fiz", "srp", "fiz", "filo", "", "mat"},
                new List<string>() { "info", "srp", "fv", "izborni", "", "", "", "fv", "izborni", "izborni", "", "jmk", "info", "geo", "", "", "bio", "info", "", "", "", "", "izborni", "", "srp", "fiz", "eng", "", "verska", "verska", "", "mni"}
            };

            Ponedeljak_raspored = new(list);
            
            lista_ucionica = new()
            {
                new Ucionica("P4", 15, true),
                new Ucionica("hemijski_kabinet", 15, true),
                new Ucionica("6", 16, true),
                new Ucionica("23b", 16, true),
                new Ucionica("5", 20, true),
                new Ucionica("23a", 20, true),
                new Ucionica("jezicka1", 20, true),
                new Ucionica("jezicka2", 20, true),
                new Ucionica("8", 20, true),
                new Ucionica("22", 22, true),
                new Ucionica("11", 22, true),
                new Ucionica("29", 22, true),
                new Ucionica("33", 24, true),
                new Ucionica("7", 24, true),
                new Ucionica("30", 24, true),
                new Ucionica("biblioteka", 25, true),
                new Ucionica("10", 26, true),
                new Ucionica("35", 26, true),
                new Ucionica("39", 28, true),
                new Ucionica("P3", 28, true),
                new Ucionica("multimedijska", 30, true),
                new Ucionica("P1", 30, true),
                new Ucionica("28", 30, true),
                new Ucionica("42", 30, true),
                new Ucionica("13", 32, true),
                new Ucionica("25", 32, true),
                new Ucionica("26", 32, true),
                new Ucionica("27", 32, true),
                new Ucionica("37", 32, true),
                new Ucionica("24", 35, true),
                new Ucionica("P2", 36, true),
                new Ucionica("20", 36, true),
                new Ucionica("31", 36, true),
                new Ucionica("32", 36, true),
                new Ucionica("36", 36, true),
                new Ucionica("40", 36, true),
                new Ucionica("41", 36, true),
                new Ucionica("9", 40, true),
                new Ucionica("10", 40, true),
                
                
          
                
                
                                


            };
            lista_odeljenja = new()
            {
                new Odeljenje("I-1", 19),
                new Odeljenje("I-2",19),
                new Odeljenje("I-3",18),
                new Odeljenje("I-4",30, 28),
                new Odeljenje("I-5",35, 31),
                new Odeljenje("I-6",35, 10),
                new Odeljenje("I-7",32, 25),
                new Odeljenje("I-8",29, 37),
                new Odeljenje("II-1", 19),
                new Odeljenje("II-2",20),
                new Odeljenje("II-3",17),
                new Odeljenje("II-4",28, 27),
                new Odeljenje("II-5",34, 24),
                new Odeljenje("II-6",39, 20),
                new Odeljenje("II-7",29, 42),
                new Odeljenje("II-8",31, 26),
                new Odeljenje("III-1", 20, 35),
                new Odeljenje("III-2",18, 39),
                new Odeljenje("III-3",18, 11),
                new Odeljenje("III-4",23, 21),
                new Odeljenje("III-5",35, 40),
                new Odeljenje("III-6",35, 32),
                new Odeljenje("III-7",31, 13),
                new Odeljenje("III-8",32, 36),
                new Odeljenje("IV-1", 19, 30),
                new Odeljenje("IV-2",21, 33),
                new Odeljenje("IV-3",19, 19),
                new Odeljenje("IV-4",29, 3),
                new Odeljenje("IV-5",30, 1),
                new Odeljenje("IV-6",27, 2),
                new Odeljenje("IV-7",37, 9),
                new Odeljenje("IV-8",39, 41),
            };
        }
    }
}
