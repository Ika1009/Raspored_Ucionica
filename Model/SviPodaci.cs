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
            //Zauzetost kabineta
            string path = @"SlobodniKabineti.csv";
            string[] procitano = File.ReadAllLines(path);

            string[] split0 = procitano[0].Split(",");
            string[] split1 = procitano[1].Split(",");
            string[] split2 = procitano[2].Split(",");
            string[] split3 = procitano[3].Split(",");
            string[] split4 = procitano[4].Split(",");

            Kponedeljak = new(new List<List<string>> // optimizovao
            {
                new List<string>() { split0[0], split0[1], split0[2], split0[3], split0[4], split0[5], split0[6], split0[7]}, //22
                new List<string>() { split1[0], split1[1], split1[2], split1[3], split1[4], split1[5], split1[6], split1[7]}, //29
                new List<string>() {split2[0], split2[1], split2[2], split2[3], split2[4], split2[5], split2[6], split2[7]}, //23a
                new List<string>() {split3[0], split3[1], split3[2], split3[3], split3[4], split3[5], split3[6], split3[7]}, //Sremac
                new List<string>() {split4[0], split4[1], split4[2], split4[3], split4[4], split4[5], split4[6], split4[7]}, //Multimedijalna(MM)
            });

            split0 = procitano[6].Split(",");
            split1 = procitano[7].Split(",");
            split2 = procitano[8].Split(",");
            split3 = procitano[9].Split(",");
            split4 = procitano[10].Split(",");
            Kutorak = new(new List<List<string>> // optimizovao
            {
                new List<string>() { split0[0], split0[1], split0[2], split0[3], split0[4], split0[5], split0[6], split0[7]}, //22
                new List<string>() { split1[0], split1[1], split1[2], split1[3], split1[4], split1[5], split1[6], split1[7]}, //29
                new List<string>() {split2[0], split2[1], split2[2], split2[3], split2[4], split2[5], split2[6], split2[7]}, //23a
                new List<string>() {split3[0], split3[1], split3[2], split3[3], split3[4], split3[5], split3[6], split3[7]}, //Sremac
                new List<string>() {split4[0], split4[1], split4[2], split4[3], split4[4], split4[5], split4[6], split4[7]}, //Multimedijalna(MM)
            });

            split0 = procitano[12].Split(",");
            split1 = procitano[13].Split(",");
            split2 = procitano[14].Split(",");
            split3 = procitano[15].Split(",");
            split4 = procitano[16].Split(",");
            Ksreda = new(new List<List<string>> // optimizovao
            {
                new List<string>() { split0[0], split0[1], split0[2], split0[3], split0[4], split0[5], split0[6], split0[7]}, //22
                new List<string>() { split1[0], split1[1], split1[2], split1[3], split1[4], split1[5], split1[6], split1[7]}, //29
                new List<string>() {split2[0], split2[1], split2[2], split2[3], split2[4], split2[5], split2[6], split2[7]}, //23a
                new List<string>() {split3[0], split3[1], split3[2], split3[3], split3[4], split3[5], split3[6], split3[7]}, //Sremac
                new List<string>() {split4[0], split4[1], split4[2], split4[3], split4[4], split4[5], split4[6], split4[7]}, //Multimedijalna(MM)
            });

            split0 = procitano[18].Split(",");
            split1 = procitano[19].Split(",");
            split2 = procitano[20].Split(",");
            split3 = procitano[21].Split(",");
            split4 = procitano[22].Split(",");
            Kcetvrtak = new(new List<List<string>> // optimizovao
            {
                new List<string>() { split0[0], split0[1], split0[2], split0[3], split0[4], split0[5], split0[6], split0[7]}, //22
                new List<string>() { split1[0], split1[1], split1[2], split1[3], split1[4], split1[5], split1[6], split1[7]}, //29
                new List<string>() {split2[0], split2[1], split2[2], split2[3], split2[4], split2[5], split2[6], split2[7]}, //23a
                new List<string>() {split3[0], split3[1], split3[2], split3[3], split3[4], split3[5], split3[6], split3[7]}, //Sremac
                new List<string>() {split4[0], split4[1], split4[2], split4[3], split4[4], split4[5], split4[6], split4[7]}, //Multimedijalna(MM)
            });

            split0 = procitano[24].Split(",");
            split1 = procitano[25].Split(",");
            split2 = procitano[27].Split(",");
            split3 = procitano[28].Split(",");
            split4 = procitano[29].Split(",");
            Kpetak = new(new List<List<string>> // optimizovao
            {
                new List<string>() { split0[0], split0[1], split0[2], split0[3], split0[4], split0[5], split0[6], split0[7]}, //22
                new List<string>() { split1[0], split1[1], split1[2], split1[3], split1[4], split1[5], split1[6], split1[7]}, //29
                new List<string>() {split2[0], split2[1], split2[2], split2[3], split2[4], split2[5], split2[6], split2[7]}, //23a
                new List<string>() {split3[0], split3[1], split3[2], split3[3], split3[4], split3[5], split3[6], split3[7]}, //Sremac
                new List<string>() {split4[0], split4[1], split4[2], split4[3], split4[4], split4[5], split4[6], split4[7]}, //Multimedijalna(MM)
            });

            path = @"RasporedCasova.csv";
            procitano = File.ReadAllLines(path);

            split0 = procitano[0].Split(",");
            split1 = procitano[1].Split(",");
            split2 = procitano[2].Split(",");
            split3 = procitano[3].Split(",");
            split4 = procitano[4].Split(",");
            string[] split5 = procitano[5].Split(",");
            string[] split6 = procitano[6].Split(",");
            string[] split7 = procitano[7].Split(",");

            ponedeljak = new(new List<List<string>> // optimizovao
            {
                new List<string>() {"info", "", "", "", "g1"/*reg*/, "", "", "", "", "verska", "", "reg", "reg", "verska", "reg", "", "", "", "", "reg","reg", "", "", "", "", "", "", "info", "", "", "", ""},
                new List<string>() {"info", "reg", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "reg", "reg", "n1/f/i/r", "reg", "n1/f/i/r", "reg", "reg", "reg", "reg", "fv","reg", "reg", "reg", "reg", "g1", "", "reg/hem", "info", "reg", "info", "reg", "fv"},
                new List<string>() {"dreg", "info", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "fv", "reg/reg", "reg", "reg/reg", "reg", "reg", "reg", "dreg", "reg", "reg/info","reg", "fv", "reg", "reg", "reg", "reg", "reg/hem", "reg", "reg", "info", "reg", "reg"},
                new List<string>() {"dreg", "info", "reg", "n/f/r", "n/f/i/r", "reg", "info", "n/f/i/r", "dreg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "dreg", "dreg", "fv", "reg/info","reg", "reg", "reg/info", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "fv", "reg"},
                new List<string>() {"reg", "reg", "reg", "reg", "reg", "reg", "info", "reg", "dreg", "reg", "reg", "reg", "hem/info", "reg", "fv", "reg", "dreg", "info", "reg/reg", "reg","reg", "info/reg", "reg", "fv", "reg", "reg", "reg", "n/f/reg", "n1/f/reg", "reg", "n1/reg", "reg"},
                new List<string>() {"fv", "reg", "reg", "reg", "reg", "", "reg", "reg", "reg", "dreg", "info", "reg/reg", "hem/info", "reg", "reg", "reg", "reg", "info", "reg", "reg","reg", "reg", "fv", "reg", "reg", "reg", "info/reg", "reg", "reg", "n/f/reg", "reg", "n/f/reg"},
                new List<string>() { "reg", "fv", "reg", "fv", "reg", "", "", "reg", "reg", "dreg", "info", "reg", "info", "reg", "verska", "verska", "reg", "info", "reg", "n/f", "reg", "n/f/reg", "reg", "n/f/reg", "reg", "reg", "reg/info", "reg", "reg", "reg", "reg", "reg"},
                new List<string>() { "info", "reg", "fv", "", "", "", "", "fv", "reg", "reg", "", "reg", "info", "reg", "", "", "reg", "info", "", "", "", "", "reg", "", "reg", "reg", "reg", "", "verska/g1", "verska/g1", "reg", "reg"}
            });

            split0 = procitano[8].Split(",");
            split1 = procitano[9].Split(",");
            split2 = procitano[10].Split(",");
            split3 = procitano[11].Split(",");
            split4 = procitano[12].Split(",");
            split5 = procitano[13].Split(",");
            split6 = procitano[14].Split(",");
            split7 = procitano[15].Split(",");

            utorak = new(new List<List<string>>
            {
                new List<string>() {"", "", "verska/g2", "verska/g2", "reg", "", "reg", "", "", "", "", "", "", "", "", "", "", "", "", "","", "", "", "", "info", "", "reg", "reg", "", "reg", "reg", ""},
                new List<string>() {"info", "reg", "reg", "reg", "reg", "reg", "reg", "", "info", "reg", "reg/reg", "fv", "reg", "", "reg", "reg", "reg", "info", "dreg", "reg","reg", "reg", "reg", "reg", "info", "reg", "reg", "", "info", "reg", "reg", "reg"},
                new List<string>() {"info", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "reg", "reg", "fv", "reg/hem", "reg", "reg", "info", "dreg", "reg","reg", "reg", "reg/reg", "reg", "info", "dreg", "reg", "reg", "info", "reg", "reg", "reg"},
                new List<string>() {"info", "info", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "n1/f/reg", "reg", "n1/f/reg", "reg/hem", "fv", "info", "reg", "reg","reg/info", "reg", "reg", "reg", "info", "dreg", "reg", "reg", "reg", "reg", "fv", "reg"},
                new List<string>() {"info", "info", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "fv", "reg/reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "fv","reg", "reg", "reg", "reg/info", "info", "reg", "reg", "reg", "reg", "reg", "reg", "reg"},
                new List<string>() {"info", "reg", "reg/hem", "reg", "fv", "reg", "reg", "reg", "reg", "info", "reg", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "reg","reg/reg", "reg", "reg", "reg/info", "info", "fv", "reg", "reg", "reg", "reg", "reg", "reg"},
                new List<string>() { "info", "reg", "reg/hem", "reg", "reg", "fv", "reg", "reg", "reg", "info", "reg", "info", "reg/reg", "reg", "reg", "fv", "info", "reg", "info", "verska","reg", "reg", "verska", "reg", "info", "reg", "reg", "reg", "reg", "reg", "reg", ""},
                new List<string>() { "", "reg", "", "", "reg", "verska", "fv", "verska", "reg", "reg", "reg", "info", "g2", "", "reg", "reg", "info","reg" ,"info", "", "fv", "", "", "", "info", "g1", "g1","g1" ,"reg", "", "reg/info", ""}
            });

            split0 = procitano[17].Split(",");
            split1 = procitano[18].Split(",");
            split2 = procitano[19].Split(",");
            split3 = procitano[20].Split(",");
            split4 = procitano[21].Split(",");
            split5 = procitano[22].Split(",");
            split6 = procitano[23].Split(",");
            split7 = procitano[24].Split(",");

            sreda = new(new List<List<string>>
            {
                new List<string>() {"", "g3", "", "", "", "", "g3", "", "", "", "", "", "reg", "info", "", "", "", "", "verska/g4", "","", "", "", "verska/g4", "", "", "", "", "reg", "info", "reg", ""},
                new List<string>() {"reg", "fv", "reg", "n/f", "n/f", "reg", "reg", "n/f", "info", "info", "reg", "reg", "reg", "info", "reg", "reg", "info", "info", "reg", "reg","reg", "reg", "reg", "fv", "reg", "reg", "dreg", "reg", "", "info", "reg", "reg"},
                new List<string>() {"fv", "dreg", "reg", "reg", "reg", "reg", "reg", "reg", "info", "info", "reg", "reg","reg" ,"info/hem", "reg", "reg","info", "info", "reg", "reg", "reg", "reg","fv", "reg", "reg", "reg", "dreg", "n/f", "n1/f/i/r", "reg", "n1/i/r", "reg"},
                new List<string>() {"reg", "dreg", "reg", "reg", "reg", "reg", "reg", "fv", "reg", "info", "reg", "reg", "reg", "info/hem", "reg", "reg", "info", "info", "reg", "n/f","reg", "n/f/i/r", "reg", "n/f/i/r", "fv", "info", "reg", "reg/reg", "reg", "reg", "reg", "reg"},
                new List<string>() {"reg", "reg", "info", "fv", "reg", "reg", "reg", "reg", "reg", "info", "reg", "fv", "reg", "reg", "reg", "reg", "reg", "info", "dreg", "reg","reg","reg/hem", "reg", "reg", "info", "reg", "reg", "reg/reg", "reg", "n/f", "reg", "n/f"},
                new List<string>() {"dreg", "dreg", "info", "reg", "reg", "fv", "reg", "reg", "fv", "info", "reg", "reg", "reg/reg", "n/reg", "reg", "reg", "reg", "info", "dreg", "reg","reg", "hem/info", "reg", "", "reg", "reg", "reg", "reg", "reg", "", "reg", "reg/reg"},
                new List<string>() { "dreg", "dreg", "reg", "info", "reg", "info", "reg", "reg", "reg", "info", "reg", "reg", "reg", "reg", "reg", "reg", "dreg", "info", "reg", "reg","fv", "reg", "", "", "reg", "reg", "reg", "verska", "fv", "", "reg", "reg"},
                new List<string>() { "reg", "verska", "", "info", "fv", "info", "verska", "", "reg", "", "reg", "reg", "fv", "", "g2", "reg", "dreg", "info", "reg", "","", "", "", "", "reg", "reg", "reg", "", "", "", "reg/info", ""}
            });

            split0 = procitano[26].Split(",");
            split1 = procitano[27].Split(",");
            split2 = procitano[28].Split(",");
            split3 = procitano[29].Split(",");
            split4 = procitano[30].Split(",");
            split5 = procitano[31].Split(",");
            split6 = procitano[32].Split(",");
            split7 = procitano[33].Split(",");

            cetvrtak = new(new List<List<string>>
            {
                new List<string>() { "g3", "", "", "", "", "g3", "", "", "", "", "", "", "", "", "", "", "verksa/g4", "verska/g4", "", "reg","", "", "", "", "", "info", "reg", "", "", "reg", "", "reg"},
                new List<string>() { "reg", "reg", "fv", "", "info", "reg", "reg", "reg", "info","reg","g5", "verska", "reg", "g5", "reg", "reg", "fv", "reg", "reg", "reg/hem", "reg","", "reg", "", "reg", "info", "reg", "reg", "reg", "reg", "reg", "info/reg"},
                new List<string>() { "reg", "reg", "dreg", "reg", "info", "reg", "reg", "reg", "info","reg" ,"reg","hem/info", "reg", "reg", "reg", "reg", "dreg", "fv", "reg", "reg", "reg", "reg","reg", "reg", "reg", "info", "reg", "fv", "reg", "reg/reg", "reg", "reg"},
                new List<string>() { "reg", "reg", "dreg", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "hem/info", "reg", "reg", "info", "reg", "dreg", "reg", "reg/reg", "reg","reg", "reg", "reg", "reg", "reg", "info", "fv", "reg", "reg/reg", "fv", "reg", "reg"},
                new List<string>() { "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "info", "dreg", "reg/hem","reg", "reg/reg","fv", "info", "reg", "reg", "reg", "reg", "reg", "reg", "reg","reg", "reg/reg", "fv", "info", "reg", "reg", "reg/reg", "reg", "reg", "reg"},
                new List<string>() { "reg", "reg", "dreg", "reg", "reg", "reg", "fv", "reg", "info", "dreg", "reg/hem", "reg/reg", "reg", "reg", "reg", "info", "reg", "dreg", "reg", "reg","reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "fv", "reg", "reg", "reg"},
                new List<string>() {  "reg", "reg", "dreg", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "reg", "fv", "reg/reg", "reg", "info", "info", "dreg", "hem/info", "","verska", "verska/g4", "reg", "reg", "reg", "info", "", "reg", "", "reg/reg", "", "reg"},
                new List<string>() {  "verska", "info", "reg", "info", "verska", "", "", "reg", "", "fv", "reg", "g2", "", "reg", "", "reg","reg", "reg", "hem/info", "", "","", "reg/reg","reg" ,"", "info", "", "", "", "reg", "", ""}
            });

            split0 = procitano[35].Split(",");
            split1 = procitano[36].Split(",");
            split2 = procitano[37].Split(",");
            split3 = procitano[38].Split(",");
            split4 = procitano[39].Split(",");
            split5 = procitano[40].Split(",");
            split6 = procitano[41].Split(",");
            split7 = procitano[42].Split(",");
            petak = new(new List<List<string>>
            {
                new List<string>() { "", "", "", "", "", "", "", "g3", "verska", "", "", "", "verska", "", "reg", "", "", "", "", "","g1", "", "", "", "", "", "", "info", "", "", "", "reg"},
                new List<string>() {"info", "info", "reg", "reg", "info", "reg", "reg", "reg", "reg", "reg", "reg/reg", "reg", "reg", "reg", "reg", "reg", "info", "fv", "reg", "reg","reg", "reg", "reg", "reg", "reg", "", "", "info", "info", "reg", "", "reg"},
                new List<string>() {"info", "info", "reg", "reg", "info", "reg", "reg", "reg", "dreg", "reg", "dreg", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "reg","reg", "fv", "reg", "reg", "reg", "reg", "reg", "fv", "info", "reg", "reg/reg", "reg"},
                new List<string>() {"dreg", "info", "reg", "reg", "reg", "reg", "reg", "reg", "dreg", "info", "dreg", "reg", "reg", "reg", "reg", "n/reg", "info", "dreg", "fv", "reg","hem/info", "reg", "reg", "reg", "dreg", "fv", "reg", "reg", "reg", "reg", "reg", "reg"},
                new List<string>() {"dreg", "info", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "info", "reg", "reg", "reg", "reg/reg", "reg", "fv", "info", "dreg", "dreg", "reg","reg/hem", "reg", "reg/info", "reg", "dreg", "reg", "reg", "reg", "reg", "reg", "reg", "fv"},
                new List<string>() {"reg", "info", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "fv", "dreg", "reg", "reg", "reg", "fv", "reg", "info", "reg", "dreg", "reg","reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg", "reg/info"},
                new List<string>() { "reg", "info", "reg", "reg", "reg", "reg", "reg", "", "reg", "reg", "dreg", "reg"/*?*/, "", "reg", "reg", "reg", "info", "reg", "reg", "reg","reg", "reg", "reg", "reg", "reg", "reg", "fv", "reg", "reg", "fv", "verska/g2", "verska/g1"},
                new List<string>() { "", "", "", "reg", "reg", "reg", "", "", "fv", "", "", "", "", "", "", "g2", "info", "reg", "", "","", "", "", "", "verska", "verska", "verska", "", "", "", "", ""}
            });



            lista_ucionica = new()
            {
                new Ucionica("P4", 15, true, true),
                new Ucionica("6", 16, true, true),
                new Ucionica("8", 20, true),
                new Ucionica("23b", 20, true),
                new Ucionica("11", 22, true),
                new Ucionica("33", 24, true),
                new Ucionica("30", 24, true),
                new Ucionica("7", 24, true, true),
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

