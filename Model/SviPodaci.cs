using System.Windows.Data;
using System.IO;
using System.Windows;

namespace Raspored_Ucionica.Model
{
    public class SviPodaci
    {
        public readonly List<Odeljenje>? lista_odeljenja;
        public readonly List<Ucionica>? lista_ucionica;
        public readonly List<int>? lista_id_ucionica_slobodnih_za_staticne;
        protected readonly List<Ucionica>? lista_prioriteta;
        public readonly Raspored? ponedeljak, utorak, sreda, cetvrtak, petak;
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
                new List<string>() {"info", "", "", "", "g1"/*reg*/, "", "", "", "", "verska", "", "reg", "reg", "verska", "reg", "", "", "", "", "reg","reg", "", "", "", "", "", "", "info", "", "", "", ""},
                new List<string>() {"info", "reg", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "reg", "reg", "n/f/i/r", "reg", "n/f/i/r", "reg", "reg", "reg", "reg", "fv","reg", "reg", "reg", "reg", "g1", "", "reg/hem", "info", "reg", "info", "reg", "fv"},
                new List<string>() {"reg", "info", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "fv", "reg/reg", "reg", "reg/reg", "reg", "reg", "reg", "reg", "reg", "reg/info","reg", "fv", "reg", "reg", "reg", "reg", "reg/hem", "reg", "reg", "info", "reg", "reg"},
                new List<string>() {"reg", "info", "reg", "n/f/r", "n/f/i/r", "reg", "info", "n/f/i/r", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "fv", "reg/info","reg", "reg", "reg/info", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "fv", "reg"},
                new List<string>() {"reg", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "reg", "reg", "reg", "hem/info", "reg", "fv", "reg", "reg", "info", "reg/reg", "reg","reg", "info/reg", "reg", "fv", "reg", "reg", "reg", "n/f/reg", "n1/f/reg", "reg", "n1/reg", "reg"},
                new List<string>() {"fv", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "info", "reg/reg", "hem/info", "reg", "reg", "reg", "reg", "info", "reg", "reg","reg", "reg", "fv", "reg", "reg", "reg", "info/reg", "reg", "reg", "n/f/reg", "reg", "n/f/reg"},
                new List<string>() { "reg", "fv", "reg", "fv", "reg", "", "reg", "reg", "reg", "reg", "info", "reg", "info", "reg", "verska", "verska", "reg", "info", "reg", "n/f", "reg", "n/f/reg", "reg", "n/f/reg", "reg", "reg", "reg/info", "reg", "reg", "reg", "reg", "reg"},
                new List<string>() { "info", "reg", "fv", "reg", "", "", "", "fv", "reg", "reg", "", "reg", "info", "reg", "", "", "reg", "info", "", "", "", "", "reg", "", "reg", "reg", "reg", "", "verska/g1", "verska/g1", "reg", "reg"}
            });

            utorak = new(new List<List<string>>
            {
                new List<string>() {"", "", "verska/g2", "verska/g2", "reg", "", "reg", "", "", "", "", "", "", "", "", "", "", "", "", "","", "", "", "", "info", "", "reg", "reg", "", "reg", "reg", ""},
                new List<string>() {"info", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg/reg", "fv", "reg", "", "reg", "reg", "reg", "info", "reg", "reg","reg", "reg", "reg", "reg", "info", "reg", "reg", "reg", "info", "reg", "reg", "reg"},
                new List<string>() {"info", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "reg", "reg", "fv", "reg/hem", "reg", "reg", "info", "reg", "reg","reg", "reg", "reg/reg", "reg", "info", "reg", "reg", "reg", "info", "reg", "reg", "reg"},
                new List<string>() {"info", "info", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "n1/f/reg", "reg", "n1/f/reg", "reg/hem", "fv", "info", "reg", "reg","reg/info", "reg", "reg", "reg", "info", "reg", "reg", "reg", "reg", "reg", "fv", "reg"},
                new List<string>() {"info", "info", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "fv", "reg/reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "fv","reg", "reg", "reg", "reg/info", "info", "reg", "reg", "reg", "reg", "reg", "reg", "reg"},
                new List<string>() {"info", "reg", "reg/hem", "reg", "fv", "reg", "reg", "reg", "reg", "info", "reg", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "reg","reg/reg", "reg", "reg", "reg/info", "info", "fv", "reg", "reg", "reg", "reg", "reg", "reg"},
                new List<string>() { "info", "reg", "reg/hem", "reg", "reg", "fv", "reg", "reg", "reg", "info", "reg", "info", "reg/reg", "reg", "reg", "fv", "info", "reg", "info", "verska","reg", "reg", "verska", "reg", "info", "reg", "reg", "reg", "reg", "reg", "reg", "reg"},
                new List<string>() { "", "reg", "", "", "reg", "verska", "fv", "verska", "reg", "reg", "reg", "info", "g2", "reg", "reg", "reg", "info","reg" ,"info", "reg", "fv", "", "", "", "info", "g1", "g1","g1" ,"reg", "", "reg/info", ""}
            });
            sreda = new(new List<List<string>>
            {
                new List<string>() {"", "g3", "", "", "", "", "g3", "", "", "", "", "", "reg", "info", "", "", "", "", "verska/g4", "","", "", "", "verska/g4", "", "", "", "", "reg", "info", "reg", ""},
                new List<string>() {"reg", "fv", "reg", "n/f", "n/f", "reg", "reg", "n/f", "info", "info", "reg", "reg", "reg", "info", "reg", "reg", "info", "info", "reg", "reg","reg", "reg", "reg", "fv", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg"},
                new List<string>() {"fv", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "info", "info", "reg", "reg","reg" ,"info/hem", "reg", "reg","info", "info", "reg", "reg", "reg", "reg","fv", "reg", "reg", "reg", "reg", "n/f", "n1/f/i/r", "reg", "n1/i/r", "reg"},//moguce da se ne spajaju
                new List<string>() {"reg", "reg", "reg", "reg", "reg", "reg", "reg", "fv", "reg", "info", "reg", "reg", "reg", "info/hem", "reg", "reg", "info", "info", "reg", "n/f","reg", "n/f/i/r", "reg", "n/f/i/r", "fv", "info", "reg", "reg/reg", "reg", "reg", "reg", "reg"},
                new List<string>() {"reg", "reg", "info", "fv", "reg", "reg", "reg", "reg", "reg", "info", "reg", "fv", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg","reg","reg/hem", "reg", "reg", "info", "reg", "reg", "reg/reg", "reg", "n/f", "reg", "n/f"},
                new List<string>() {"reg", "reg", "info", "reg", "reg", "fv", "reg", "reg", "fv", "info", "reg", "reg", "reg/reg", "n/reg", "reg", "reg", "reg", "info", "reg", "reg","reg", "hem/info", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg/reg"},
                new List<string>() { "reg", "reg", "reg", "info", "reg", "info", "reg", "reg", "reg", "info", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg","fv", "reg", "reg", "reg", "reg", "reg", "reg", "verska", "fv", "reg", "reg", "reg"},
                new List<string>() { "reg", "verska", "", "info", "fv", "info", "verska", "reg", "reg", "", "reg", "reg", "fv", "reg", "g2", "reg", "reg", "info", "reg", "","reg", "reg", "reg", "reg", "reg", "reg", "reg", "", "", "", "reg/info", ""}
            });
            cetvrtak = new(new List<List<string>>
            {
                new List<string>() { "g3", "", "", "", "", "g3", "", "", "", "", "", "", "", "", "", "", "verksa/g4", "verska/g4", "", "reg","", "", "", "", "", "info", "reg", "", "", "reg", "", "reg"},
                new List<string>() { "reg", "reg", "fv", "reg", "info", "reg", "reg", "reg", "info","reg","g5", "verska", "reg", "g5", "reg", "reg", "fv", "reg", "reg", "reg/hem", "reg","reg", "reg", "reg", "reg", "info", "reg", "reg", "reg", "reg", "reg", "info/reg"},
                new List<string>() { "reg", "reg", "reg", "reg", "info", "reg", "reg", "reg", "info","reg" ,"reg","hem/info", "reg", "reg", "reg", "reg", "reg", "fv", "reg", "reg", "reg", "reg","reg", "reg", "reg", "info", "reg", "fv", "reg", "reg/reg", "reg", "reg"},
                new List<string>() { "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "hem/info", "reg", "reg", "info", "reg", "reg", "reg", "reg/reg", "reg","reg", "reg", "reg", "reg", "reg", "info", "fv", "reg", "reg/reg", "fv", "reg", "reg"},
                new List<string>() { "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg/hem","reg", "reg/reg","fv", "info", "reg", "reg", "reg", "reg", "reg", "reg", "reg","reg", "reg/reg", "fv", "info", "reg", "reg", "reg/reg", "reg", "reg", "reg"},
                new List<string>() { "reg", "reg", "reg", "reg", "reg", "reg", "fv", "reg", "info", "reg", "reg/hem", "reg/reg", "reg", "reg", "reg", "info", "reg", "reg", "reg", "reg","reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "fv", "reg", "reg", "reg"},
                new List<string>() {  "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "reg", "fv", "reg/reg", "reg", "info", "info", "reg", "hem/info", "reg","verska", "verska/g4", "reg", "reg", "reg", "info", "", "reg", "reg", "reg/reg", "reg", "reg"},
                new List<string>() {  "verska", "info", "reg", "info", "verska", "reg", "", "reg", "", "fv", "reg", "g2", "", "reg", "", "reg","reg", "reg", "hem/info", "reg", "","", "reg/reg","reg" ,"", "info", "", "reg", "reg", "reg", "reg", ""}
            });
            petak = new(new List<List<string>>
            {
                new List<string>() { "", "", "", "", "", "", "", "g3", "verska", "", "", "", "verska", "", "reg", "", "", "", "", "","g1", "", "", "", "", "", "", "info", "", "", "", "reg"},
                new List<string>() {"info", "info", "reg", "reg", "info", "reg", "reg", "reg", "reg", "reg", "reg/reg", "reg", "reg", "reg", "reg", "reg", "info", "fv", "reg", "reg","reg", "reg", "reg", "reg", "reg", "reg", "", "info", "info", "reg", "", "reg"},
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
                new Ucionica("6", 16, true, true),
                new Ucionica("8", 20, true),//S
                new Ucionica("23b", 20, true),
                new Ucionica("11", 22, true),
                new Ucionica("33", 24, true),
                new Ucionica("30", 24, true),
                new Ucionica("7", 24, true, true), //S
                new Ucionica("biblioteka", 25, true, true), 
                new Ucionica("21", 26, true), 
                new Ucionica("35", 26, true),
                new Ucionica("39", 28, true),
                new Ucionica("P3", 28, true),
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
                new Ucionica("31", 36, true),
                new Ucionica("32", 36, true),
                new Ucionica("36", 36, true),
                new Ucionica("40", 36, true),
                new Ucionica("41", 36, true),
                new Ucionica("20", 36, true),
                new Ucionica("9", 40, true),
                new Ucionica("10", 40, true),
                new Ucionica("svecana sala",40,true),
               

            };
            //lista_id_ucionica_slobodnih_za_staticne = new()
            //{
            //    lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "39").Id,
            //    lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "35").Id,
            //    lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "21").Id,
            //    lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "23b").Id,
            //    lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "30").Id,
            //    lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "33").Id,
            //    lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "11").Id
            //};
            string[] brojeviUcionice = new string[32];
            brojeviUcionice = File.ReadAllLines("BrojUcenikaUOdeljenjimaXLS.csv");
            lista_odeljenja = new()
            {
                new Odeljenje("I-1", int.Parse(brojeviUcionice[0])),//lutajuca
                new Odeljenje("I-2",int.Parse(brojeviUcionice[1])),//lutajuca
                new Odeljenje("I-3",int.Parse(brojeviUcionice[2])),//lutajuca
                new Odeljenje("I-4",int.Parse(brojeviUcionice[3]), lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "28").Id),
                new Odeljenje("I-5",int.Parse(brojeviUcionice[4]), lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "31").Id),
                new Odeljenje("I-6",int.Parse(brojeviUcionice[5]), lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "10").Id),
                new Odeljenje("I-7",int.Parse(brojeviUcionice[6]), lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "25").Id),
                new Odeljenje("I-8",int.Parse(brojeviUcionice[7]), lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "37").Id),
                new Odeljenje("II-1", int.Parse(brojeviUcionice[8])),//lutajuca
                //new Odeljenje("II-2",20,lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "svecana sala").Id), 
                new Odeljenje("II-2",int.Parse(brojeviUcionice[9])),//lutajuca              
                new Odeljenje("II-3",int.Parse(brojeviUcionice[10])),//lutajuca
                new Odeljenje("II-4",int.Parse(brojeviUcionice[11]), lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "27").Id),
                new Odeljenje("II-5",int.Parse(brojeviUcionice[12]), lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "24").Id),
                new Odeljenje("II-6",int.Parse(brojeviUcionice[13]), lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "20").Id),
                new Odeljenje("II-7",int.Parse(brojeviUcionice[14]), lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "42").Id),
                new Odeljenje("II-8",int.Parse(brojeviUcionice[15]), lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "26").Id),
                new Odeljenje("III-1", int.Parse(brojeviUcionice[16])),
                new Odeljenje("III-2",int.Parse(brojeviUcionice[17])),
                new Odeljenje("III-3",int.Parse(brojeviUcionice[18])),
                new Odeljenje("III-4",int.Parse(brojeviUcionice[19])),
                new Odeljenje("III-5",int.Parse(brojeviUcionice[20]), lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "40").Id),
                new Odeljenje("III-6",int.Parse(brojeviUcionice[21]), lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "32").Id),
                new Odeljenje("III-7",int.Parse(brojeviUcionice[22]), lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "13").Id),
                new Odeljenje("III-8",int.Parse(brojeviUcionice[23]), lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "36").Id),
                new Odeljenje("IV-1", int.Parse(brojeviUcionice[24])),
                new Odeljenje("IV-2",int.Parse(brojeviUcionice[25])),
                new Odeljenje("IV-3",int.Parse(brojeviUcionice[26])),
                new Odeljenje("IV-4",int.Parse(brojeviUcionice[27]), lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "P3").Id),
                new Odeljenje("IV-5",int.Parse(brojeviUcionice[28]), lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "P1").Id),
                new Odeljenje("IV-6",int.Parse(brojeviUcionice[29]), lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "P2").Id),
                new Odeljenje("IV-7",int.Parse(brojeviUcionice[30]), lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "9").Id),
                new Odeljenje("IV-8",int.Parse(brojeviUcionice[31]), lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "41").Id),
            };

        }
    }
}
