using Raspored_Ucionica.Model;
using System.Windows.Data;

namespace Raspored_Ucionica
{
    public class SviPodaci
    {
        protected readonly List<Odeljenje>? lista_odeljenja;
        protected readonly List<Ucionica>? lista_ucionica;
        protected readonly List<Ucionica>? lista_prioriteta;
        protected readonly Raspored? ponedeljak, utorak, sreda, cetvrtak, petak;
        protected readonly Kabineti? Kponedeljak, Kutorak, Ksreda, Kcetvrtak, Kpetak;
        public SviPodaci()
        {
            Kponedeljak = new(new List<List<string>> // optimizovao
            {
                new List<string>() {"false", "false", "false", "false", "false", "false", "false", "false"},
                new List<string>() {"true", "false", "false", "false", "false", "false", "false", "false"},
                new List<string>() {"true", "false", "false", "false", "false", "false", "false", "true"},
                new List<string>() {"false", "false", "false", "false", "false", "false", "false", "false"},
                new List<string>() {"true", "false", "false", "false", "false", "false", "false", "true"},
            });
            Kutorak = new(new List<List<string>> // optimizovao
            {
                new List<string>() {"false", "false", "false", "false", "false", "false", "false", "false"},
                new List<string>() {"false", "false", "false", "false", "false", "false", "false", "false"},
                new List<string>() {"false", "false", "false", "false", "false", "false", "false", "true"},
                new List<string>() {"true", "false", "false", "false", "false", "false", "false", "false"},
                new List<string>() {"true", "true", "false", "false", "false", "false", "false", "false"},
            });
            Ksreda = new(new List<List<string>> // optimizovao
            {
                new List<string>() {"true", "false", "false", "false", "false", "false", "false", "false"},
                new List<string>() {"true", "false", "false", "false", "false", "false", "false", "false"},
                new List<string>() {"false", "false", "false", "false", "false", "false", "true", "true"},
                new List<string>() {"true", "false", "false", "false", "false", "false", "false", "false"},
                new List<string>() {"false", "false", "false", "false", "false", "false", "false", "false"},
            });
            Kcetvrtak = new(new List<List<string>> // optimizovao
            {
                new List<string>() {"true", "false", "false", "false", "false", "false", "false", "false"},
                new List<string>() {"true", "false", "false", "false", "false", "false", "false", "false"},
                new List<string>() {"true", "true", "false", "false", "false", "false", "false", "false"},
                new List<string>() {"true", "true", "true", "false", "false", "false", "false", "true"},
                new List<string>() {"true", "false", "false", "false", "true", "true", "false", "false"},
            });
            Kpetak = new(new List<List<string>> // optimizovao
            {
                new List<string>() {"true", "false", "false", "false", "false", "false", "true", "true"},
                new List<string>() {"false", "false", "false", "false", "false", "true", "true", "true"},
                new List<string>() {"true", "false", "false", "false", "false", "false", "false", "true"},
                new List<string>() {"true", "false", "false", "true", "true", "true", "true", "true"},
                new List<string>() {"false", "false", "false", "false", "false", "false", "true", "true"},
            });
            ponedeljak = new(new List<List<string>> // optimizovao
            {
                new List<string>() {"info", "", "", "", "reg", "", "", "", "", "verska", "", "reg", "reg", "verska", "reg", "", "", "", "", "reg","reg", "", "", "", "", "", "", "info", "", "", "reg", ""},
                new List<string>() {"info", "reg", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "reg", "reg", "n/f/i/r", "reg", "n/f/i/r", "reg", "reg", "reg", "reg", "fv","reg", "reg", "reg", "reg", "g1", "", "reg/hem", "info", "reg", "info", "reg", "fv"},
                new List<string>() {"reg", "info", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "fv", "reg/reg", "reg", "reg/reg", "reg", "reg", "reg", "reg", "reg", "reg/info","reg", "fv", "reg", "reg", "reg", "reg", "reg/hem", "reg", "reg", "info", "reg", "reg"},
                new List<string>() {"reg", "info", "reg", "n/f/r", "n/f/i/r", "reg", "info", "n/f/i/r", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "fv", "reg/info","reg", "reg", "reg/info", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "fv", "reg"},
                new List<string>() {"reg", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "reg", "reg", "reg", "hem/info", "reg", "fv", "reg", "reg", "info", "reg/reg", "reg","reg", "info/reg", "reg", "fv", "reg", "reg", "reg", "n/reg/f", "n/f/reg", "reg", "n/reg", "reg"},
                new List<string>() {"fv", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "info", "reg/hem", "hem/info", "reg", "reg", "reg", "reg", "info", "reg", "reg","reg", "reg", "fv", "reg", "reg", "reg", "info/reg", "reg", "reg", "n/f/reg", "reg", "n/f/reg"},
                new List<string>() { "reg", "fv", "reg", "fv", "reg", "", "reg", "reg", "reg", "reg", "info", "reg", "info", "reg", "verska", "verska", "reg", "info", "reg", "n/f", "reg", "n/f/reg", "reg", "n/f/reg", "reg", "reg", "reg/info", "reg", "reg", "reg", "", "reg"},
                new List<string>() { "info", "reg", "fv", "reg", "", "", "", "fv", "reg", "reg", "", "reg", "info", "reg", "", "", "reg", "info", "", "", "", "", "reg", "", "reg", "reg", "reg", "", "verska/g1", "verska/g1", "", "reg"}
            });

            utorak = new(new List<List<string>>
            {
                new List<string>() {"", "", "verska/g2", "verska/g2", "reg", "", "reg", "", "", "", "", "", "", "", "", "", "", "", "", "","", "", "", "", "info", "", "reg", "reg", "", "reg", "reg", ""},
                new List<string>() {"info", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg/reg", "fv", "reg", "", "reg", "reg", "reg", "info", "reg", "reg","reg", "reg", "reg", "reg", "info", "reg", "reg", "reg", "info", "reg", "reg", "reg"},
                new List<string>() {"info", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "reg", "reg", "fv", "reg/hem", "reg", "reg", "info", "reg", "reg","reg", "reg", "reg/reg", "reg", "info", "reg", "reg", "reg", "info", "reg", "reg", "reg"},
                new List<string>() {"info", "info", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "n/f/reg", "reg", "n/f/reg", "reg/hem", "fv", "info", "reg", "reg","reg/info", "reg", "reg", "reg", "info", "reg", "reg", "reg", "reg", "reg", "fv", "reg"},
                new List<string>() {"info", "info", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "fv", "reg/reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "fv","reg", "reg", "reg", "reg/info", "info", "reg", "reg", "reg", "reg", "reg", "reg", "reg"},
                new List<string>() {"info", "reg", "reg/hem", "reg", "fv", "reg", "reg", "reg", "reg", "info", "reg", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "reg","reg/reg", "reg", "reg", "reg/info", "info", "fv", "reg", "reg", "reg", "reg", "reg", "reg"},
                new List<string>() { "info", "reg", "reg/hem", "reg", "reg", "fv", "reg", "reg", "reg", "info", "reg", "info", "reg/reg", "reg", "reg", "fv", "info", "reg", "info", "verska","reg", "reg", "verska", "reg", "info", "reg", "reg", "reg", "reg", "reg", "reg", "reg"},
                new List<string>() { "", "reg", "reg", "", "reg", "verska", "fv", "verska", "reg", "reg", "reg", "info", "g2", "reg", "reg", "reg", "info","reg" ,"info", "reg", "fv", "", "", "", "info", "g1", "g1","g1" ,"reg", "", "reg/info", ""}
            });
            sreda = new(new List<List<string>>
            {
                new List<string>() {"", "g3", "", "", "", "", "g3", "", "", "", "", "", "reg", "info", "", "", "", "", "verska/g4", "","", "", "", "verska/g4", "", "", "", "", "reg", "info", "reg", ""},
                new List<string>() {"reg", "fv", "reg", "n/f", "n/f", "reg", "reg", "n/f", "info", "info", "reg", "reg", "reg", "info", "reg", "reg", "info", "info", "reg", "reg","reg", "reg", "reg", "fv", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg"},
                new List<string>() {"fv", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "info", "info", "reg", "reg","reg" ,"reg/hem", "reg", "reg","info", "info", "reg", "reg", "reg", "reg","fv", "reg", "reg", "reg", "reg", "n/f", "n/f/i/r", "reg", "n/i/r", "reg"},
                new List<string>() {"reg", "reg", "reg", "reg", "reg", "reg", "reg", "fv", "reg", "info", "reg", "reg", "reg", "reg/hem", "reg", "reg", "info", "info", "reg", "n/f","reg", "n/f/i/r", "reg", "n/f/i/r", "fv", "info", "reg", "reg/reg", "reg", "reg", "reg", "reg"},
                new List<string>() {"reg", "reg", "info", "fv", "reg", "reg", "reg", "reg", "reg", "info", "reg", "fv", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg","reg","reg/hem", "reg", "reg", "info", "reg", "reg", "reg/reg", "reg", "n/f", "reg", "n/f"},
                new List<string>() {"reg", "reg", "info", "reg", "reg", "fv", "reg", "reg", "fv", "info", "reg", "reg", "reg/reg", "n/reg", "reg", "reg", "reg", "info", "reg", "reg","reg", "hem/info", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg/reg"},
                new List<string>() { "reg", "reg", "reg", "info", "reg", "info", "reg", "reg", "reg", "info", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg","fv", "reg", "reg", "reg", "reg", "reg", "reg", "verska", "fv", "reg", "reg", "reg"},
                new List<string>() { "reg", "verska", "", "info", "fv", "info", "verska", "reg", "reg", "", "reg", "reg", "fv", "reg", "g2", "reg", "reg", "info", "reg", "","reg", "reg", "reg", "reg", "reg", "reg", "reg", "", "", "", "reg/info", ""}
            });
            cetvrtak = new(new List<List<string>>
            {
                new List<string>() { "g3", "", "", "", "", "g3", "", "", "", "", "", "", "", "", "", "", "verksa/g4", "verska/g4", "", "reg","", "", "", "", "", "info", "reg", "", "", "reg", "reg", "reg"},
                new List<string>() { "reg", "reg", "fv", "reg", "info", "reg", "reg", "reg", "info","reg","g5", "verska", "reg", "g5", "reg", "reg", "fv", "reg", "reg", "reg/hem", "reg","reg", "reg", "reg", "reg", "info", "reg", "reg", "reg", "reg", "reg", "info/reg"},
                new List<string>() { "reg", "reg", "reg", "reg", "info", "reg", "reg", "reg", "info","reg" ,"reg","hem/info", "reg", "reg", "reg", "reg", "reg", "fv", "reg", "reg", "reg", "reg","reg", "reg", "reg", "info", "reg", "fv", "reg", "reg/reg", "reg", "reg"},
                new List<string>() { "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "hem/info", "reg", "reg", "info", "reg", "reg", "reg", "reg/reg", "reg","reg", "reg", "reg", "reg", "reg", "info", "fv", "reg", "reg/reg", "fv", "reg", "reg"},
                new List<string>() { "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg/hem","reg", "reg/reg","fv", "info", "reg", "reg", "reg", "reg", "reg", "reg", "reg","reg", "reg/reg", "fv", "info", "reg", "reg", "reg/reg", "reg", "reg", "reg"},
                new List<string>() { "reg", "reg", "reg", "reg", "reg", "reg", "fv", "reg", "info", "reg", "reg/hem", "reg/reg", "reg", "reg", "reg", "info", "reg", "reg", "reg", "reg","reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "fv", "reg", "reg", "reg"},
                new List<string>() {  "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "reg", "fv", "reg/reg", "reg", "info", "info", "reg", "hem/info", "reg","verska", "verska/g4", "reg", "reg", "reg", "info", "", "reg", "reg", "reg/reg", "", "reg"},
                new List<string>() {  "verska", "info", "reg", "info", "verska", "reg", "", "reg", "", "fv", "reg", "g2", "", "reg", "", "reg","reg", "reg", "hem/info", "reg", "","", "reg/reg","reg" ,"", "info", "", "reg", "reg", "reg", "", ""}
            });
            petak = new(new List<List<string>>
            {
                new List<string>() { "", "", "", "", "", "", "", "g3", "verska", "", "", "", "verska", "", "reg", "", "", "", "", "","g1", "", "", "", "", "", "", "info", "", "", "", "reg"},
                new List<string>() {"info", "info", "", "reg", "info", "reg", "reg", "reg", "reg", "reg", "reg/reg", "reg", "reg", "reg", "reg", "reg", "info", "fv", "reg", "reg","reg", "reg", "reg", "reg", "reg", "reg", "", "info", "info", "reg", "", "reg"},
                new List<string>() {"info", "info", "reg", "reg", "info", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "reg","reg", "fv", "reg", "reg", "reg", "reg", "reg", "fv", "info", "reg", "reg/reg", "reg"},
                new List<string>() {"reg", "info", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "reg", "reg", "reg", "n/reg", "info", "reg", "fv", "reg","hem/info", "reg", "reg", "reg", "reg", "fv", "reg", "reg", "reg", "reg", "reg", "reg"},
                new List<string>() {"reg", "info", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "reg", "reg/reg", "reg", "fv", "info", "reg", "reg", "reg","reg/hem", "reg", "reg/info", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "fv"},
                new List<string>() {"reg", "info", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "fv", "reg", "reg", "reg", "reg", "fv", "reg", "info", "reg", "reg", "reg","reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg/info"},
                new List<string>() { "reg", "info", "reg", "reg", "reg", "reg", "reg", "", "reg", "reg", "reg", "reg", "", "reg", "reg", "reg", "info", "reg", "reg", "reg","reg", "reg", "reg", "reg", "reg", "reg", "fv", "reg", "reg", "fv", "verska/g2", "verska/g1"},
                new List<string>() { "", "", "", "reg", "reg", "reg", "", "", "fv", "reg", "", "", "", "", "", "g2", "info", "reg", "", "","", "reg", "", "", "verska", "verska", "verska", "reg", "reg", "", "", ""}
            });
            
            

            lista_ucionica = new()
            {
                new Ucionica("P4", 15, true, true),
                new Ucionica("jezicka1", 16, true, true),
                new Ucionica("8", 20, true),
                new Ucionica("23b", 20, false),
                new Ucionica("11", 22, false),
                new Ucionica("33", 24, false),
                new Ucionica("30", 24, false),
                new Ucionica("jezicka2", 24, true, true),
                new Ucionica("biblioteka", 25, true, true),
                new Ucionica("21", 26, false),
                new Ucionica("35", 26, false),
                new Ucionica("39", 28, false),
                new Ucionica("P3", 28, false),
                new Ucionica("P1", 30, false),
                new Ucionica("28", 30, false),
                new Ucionica("42", 30, false),
                new Ucionica("13", 32, false),
                new Ucionica("25", 32, false),
                new Ucionica("26", 32, false),
                new Ucionica("27", 32, false),
                new Ucionica("37", 32, false),
                new Ucionica("24", 35, false),
                new Ucionica("P2", 36, false),
                new Ucionica("20", 36, false),
                new Ucionica("31", 36, false),
                new Ucionica("32", 36, false),
                new Ucionica("36", 36, false),
                new Ucionica("40", 36, false),
                new Ucionica("41", 36, false),
                new Ucionica("9", 40, false),
                new Ucionica("10", 40, false),
                new Ucionica("svecana sala",40,true),

            };
           
            lista_odeljenja = new()
            {
                new Odeljenje("I-1", 19),//lutajuca
                new Odeljenje("I-2",19),//lutajuca
                new Odeljenje("I-3",18),//lutajuca
                new Odeljenje("I-4",30, lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "28").Id), // svuda da se stavi
                new Odeljenje("I-5",35, lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "31").Id),
                new Odeljenje("I-6",35, lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "10").Id),
                new Odeljenje("I-7",32, lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "25").Id),
                new Odeljenje("I-8",29, lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "37").Id),
                new Odeljenje("II-1", 19),//lutajuca
                new Odeljenje("II-2",20),//lutajuca
                //new Odeljenje("II-3",17, lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "29").Id),//lutajuca
                new Odeljenje("II-3",17),//lutajuca
                new Odeljenje("II-4",28, lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "27").Id),
                new Odeljenje("II-5",34, lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "24").Id),
                new Odeljenje("II-6",36, lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "20").Id),
                new Odeljenje("II-7",29, lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "42").Id),
                new Odeljenje("II-8",31, lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "26").Id),
                new Odeljenje("III-1", 20, lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "35").Id),
                new Odeljenje("III-2",18, lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "39").Id),
                new Odeljenje("III-3",18, lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "23b").Id),
                new Odeljenje("III-4",23, lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "21").Id),
                new Odeljenje("III-5",35, lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "40").Id),
                new Odeljenje("III-6",35, lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "32").Id),
                new Odeljenje("III-7",31, lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "13").Id),
                new Odeljenje("III-8",32, lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "36").Id),
                new Odeljenje("IV-1", 19, lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "30").Id),
                new Odeljenje("IV-2",21, lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "33").Id),
                new Odeljenje("IV-3",19, lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "11").Id),
                new Odeljenje("IV-4",29, lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "P3").Id),
                new Odeljenje("IV-5",30, lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "P1").Id),
                new Odeljenje("IV-6",27, lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "P2").Id),
                new Odeljenje("IV-7",37, lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "9").Id),
                new Odeljenje("IV-8",36, lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "41").Id),
            };
        }
    }
}