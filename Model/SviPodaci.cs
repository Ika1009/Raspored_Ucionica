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
            string path = @"SlobodniKabinetiXLS.csv";
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

            split0 = procitano[17].Split(",");
            split1 = procitano[18].Split(",");
            split2 = procitano[19].Split(",");
            split3 = procitano[20].Split(",");
            split4 = procitano[21].Split(",");
            Kcetvrtak = new(new List<List<string>> // optimizovao
            {
                new List<string>() { split0[0], split0[1], split0[2], split0[3], split0[4], split0[5], split0[6], split0[7]}, //22
                new List<string>() { split1[0], split1[1], split1[2], split1[3], split1[4], split1[5], split1[6], split1[7]}, //29
                new List<string>() {split2[0], split2[1], split2[2], split2[3], split2[4], split2[5], split2[6], split2[7]}, //23a
                new List<string>() {split3[0], split3[1], split3[2], split3[3], split3[4], split3[5], split3[6], split3[7]}, //Sremac
                new List<string>() {split4[0], split4[1], split4[2], split4[3], split4[4], split4[5], split4[6], split4[7]}, //Multimedijalna(MM)
            });

            split0 = procitano[23].Split(",");
            split1 = procitano[24].Split(",");
            split2 = procitano[25].Split(",");
            split3 = procitano[26].Split(",");
            split4 = procitano[27].Split(",");
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
				new List<string>() {split0[0],split0[1],split0[2],split0[3],split0[4],split0[5],split0[6],split0[7],split0[8],split0[9],split0[10],split0[11],split0[12],split0[13],split0[14],split0[15],split0[16],split0[17],split0[18],split0[19],split0[20],split0[21],split0[22],split0[23],split0[24],split0[25],split0[26],split0[27],split0[28],split0[29],split0[30],split0[31]},
new List<string>() {split1[0],split1[1],split1[2],split1[3],split1[4],split1[5],split1[6],split1[7],split1[8],split1[9],split1[10],split1[11],split1[12],split1[13],split1[14],split1[15],split1[16],split1[17],split1[18],split1[19],split1[20],split1[21],split1[22],split1[23],split1[24],split1[25],split1[26],split1[27],split1[28],split1[29],split1[30],split1[31]},
new List<string>() {split2[0],split2[1],split2[2],split2[3],split2[4],split2[5],split2[6],split2[7],split2[8],split2[9],split2[10],split2[11],split2[12],split2[13],split2[14],split2[15],split2[16],split2[17],split2[18],split2[19],split2[20],split2[21],split2[22],split2[23],split2[24],split2[25],split2[26],split2[27],split2[28],split2[29],split2[30],split2[31]},
new List<string>() {split3[0],split3[1],split3[2],split3[3],split3[4],split3[5],split3[6],split3[7],split3[8],split3[9],split3[10],split3[11],split3[12],split3[13],split3[14],split3[15],split3[16],split3[17],split3[18],split3[19],split3[20],split3[21],split3[22],split3[23],split3[24],split3[25],split3[26],split3[27],split3[28],split3[29],split3[30],split3[31]},
new List<string>() {split4[0],split4[1],split4[2],split4[3],split4[4],split4[5],split4[6],split4[7],split4[8],split4[9],split4[10],split4[11],split4[12],split4[13],split4[14],split4[15],split4[16],split4[17],split4[18],split4[19],split4[20],split4[21],split4[22],split4[23],split4[24],split4[25],split4[26],split4[27],split4[28],split4[29],split4[30],split4[31]},
new List<string>() {split5[0],split5[1],split5[2],split5[3],split5[4],split5[5],split5[6],split5[7],split5[8],split5[9],split5[10],split5[11],split5[12],split5[13],split5[14],split5[15],split5[16],split5[17],split5[18],split5[19],split5[20],split5[21],split5[22],split5[23],split5[24],split5[25],split5[26],split5[27],split5[28],split5[29],split5[30],split5[31]},
new List<string>() {split6[0],split6[1],split6[2],split6[3],split6[4],split6[5],split6[6],split6[7],split6[8],split6[9],split6[10],split6[11],split6[12],split6[13],split6[14],split6[15],split6[16],split6[17],split6[18],split6[19],split6[20],split6[21],split6[22],split6[23],split6[24],split6[25],split6[26],split6[27],split6[28],split6[29],split6[30],split6[31]},
new List<string>() {split7[0],split7[1],split7[2],split7[3],split7[4],split7[5],split7[6],split7[7],split7[8],split7[9],split7[10],split7[11],split7[12],split7[13],split7[14],split7[15],split7[16],split7[17],split7[18],split7[19],split7[20],split7[21],split7[22],split7[23],split7[24],split7[25],split7[26],split7[27],split7[28],split7[29],split7[30],split7[31]}
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
							   new List<string>() {split0[0],split0[1],split0[2],split0[3],split0[4],split0[5],split0[6],split0[7],split0[8],split0[9],split0[10],split0[11],split0[12],split0[13],split0[14],split0[15],split0[16],split0[17],split0[18],split0[19],split0[20],split0[21],split0[22],split0[23],split0[24],split0[25],split0[26],split0[27],split0[28],split0[29],split0[30],split0[31]},
new List<string>() {split1[0],split1[1],split1[2],split1[3],split1[4],split1[5],split1[6],split1[7],split1[8],split1[9],split1[10],split1[11],split1[12],split1[13],split1[14],split1[15],split1[16],split1[17],split1[18],split1[19],split1[20],split1[21],split1[22],split1[23],split1[24],split1[25],split1[26],split1[27],split1[28],split1[29],split1[30],split1[31]},
new List<string>() {split2[0],split2[1],split2[2],split2[3],split2[4],split2[5],split2[6],split2[7],split2[8],split2[9],split2[10],split2[11],split2[12],split2[13],split2[14],split2[15],split2[16],split2[17],split2[18],split2[19],split2[20],split2[21],split2[22],split2[23],split2[24],split2[25],split2[26],split2[27],split2[28],split2[29],split2[30],split2[31]},
new List<string>() {split3[0],split3[1],split3[2],split3[3],split3[4],split3[5],split3[6],split3[7],split3[8],split3[9],split3[10],split3[11],split3[12],split3[13],split3[14],split3[15],split3[16],split3[17],split3[18],split3[19],split3[20],split3[21],split3[22],split3[23],split3[24],split3[25],split3[26],split3[27],split3[28],split3[29],split3[30],split3[31]},
new List<string>() {split4[0],split4[1],split4[2],split4[3],split4[4],split4[5],split4[6],split4[7],split4[8],split4[9],split4[10],split4[11],split4[12],split4[13],split4[14],split4[15],split4[16],split4[17],split4[18],split4[19],split4[20],split4[21],split4[22],split4[23],split4[24],split4[25],split4[26],split4[27],split4[28],split4[29],split4[30],split4[31]},
new List<string>() {split5[0],split5[1],split5[2],split5[3],split5[4],split5[5],split5[6],split5[7],split5[8],split5[9],split5[10],split5[11],split5[12],split5[13],split5[14],split5[15],split5[16],split5[17],split5[18],split5[19],split5[20],split5[21],split5[22],split5[23],split5[24],split5[25],split5[26],split5[27],split5[28],split5[29],split5[30],split5[31]},
new List<string>() {split6[0],split6[1],split6[2],split6[3],split6[4],split6[5],split6[6],split6[7],split6[8],split6[9],split6[10],split6[11],split6[12],split6[13],split6[14],split6[15],split6[16],split6[17],split6[18],split6[19],split6[20],split6[21],split6[22],split6[23],split6[24],split6[25],split6[26],split6[27],split6[28],split6[29],split6[30],split6[31]},
new List<string>() {split7[0],split7[1],split7[2],split7[3],split7[4],split7[5],split7[6],split7[7],split7[8],split7[9],split7[10],split7[11],split7[12],split7[13],split7[14],split7[15],split7[16],split7[17],split7[18],split7[19],split7[20],split7[21],split7[22],split7[23],split7[24],split7[25],split7[26],split7[27],split7[28],split7[29],split7[30],split7[31]}      });

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
				   new List<string>() {split0[0],split0[1],split0[2],split0[3],split0[4],split0[5],split0[6],split0[7],split0[8],split0[9],split0[10],split0[11],split0[12],split0[13],split0[14],split0[15],split0[16],split0[17],split0[18],split0[19],split0[20],split0[21],split0[22],split0[23],split0[24],split0[25],split0[26],split0[27],split0[28],split0[29],split0[30],split0[31]},
new List<string>() {split1[0],split1[1],split1[2],split1[3],split1[4],split1[5],split1[6],split1[7],split1[8],split1[9],split1[10],split1[11],split1[12],split1[13],split1[14],split1[15],split1[16],split1[17],split1[18],split1[19],split1[20],split1[21],split1[22],split1[23],split1[24],split1[25],split1[26],split1[27],split1[28],split1[29],split1[30],split1[31]},
new List<string>() {split2[0],split2[1],split2[2],split2[3],split2[4],split2[5],split2[6],split2[7],split2[8],split2[9],split2[10],split2[11],split2[12],split2[13],split2[14],split2[15],split2[16],split2[17],split2[18],split2[19],split2[20],split2[21],split2[22],split2[23],split2[24],split2[25],split2[26],split2[27],split2[28],split2[29],split2[30],split2[31]},
new List<string>() {split3[0],split3[1],split3[2],split3[3],split3[4],split3[5],split3[6],split3[7],split3[8],split3[9],split3[10],split3[11],split3[12],split3[13],split3[14],split3[15],split3[16],split3[17],split3[18],split3[19],split3[20],split3[21],split3[22],split3[23],split3[24],split3[25],split3[26],split3[27],split3[28],split3[29],split3[30],split3[31]},
new List<string>() {split4[0],split4[1],split4[2],split4[3],split4[4],split4[5],split4[6],split4[7],split4[8],split4[9],split4[10],split4[11],split4[12],split4[13],split4[14],split4[15],split4[16],split4[17],split4[18],split4[19],split4[20],split4[21],split4[22],split4[23],split4[24],split4[25],split4[26],split4[27],split4[28],split4[29],split4[30],split4[31]},
new List<string>() {split5[0],split5[1],split5[2],split5[3],split5[4],split5[5],split5[6],split5[7],split5[8],split5[9],split5[10],split5[11],split5[12],split5[13],split5[14],split5[15],split5[16],split5[17],split5[18],split5[19],split5[20],split5[21],split5[22],split5[23],split5[24],split5[25],split5[26],split5[27],split5[28],split5[29],split5[30],split5[31]},
new List<string>() {split6[0],split6[1],split6[2],split6[3],split6[4],split6[5],split6[6],split6[7],split6[8],split6[9],split6[10],split6[11],split6[12],split6[13],split6[14],split6[15],split6[16],split6[17],split6[18],split6[19],split6[20],split6[21],split6[22],split6[23],split6[24],split6[25],split6[26],split6[27],split6[28],split6[29],split6[30],split6[31]},
new List<string>() {split7[0],split7[1],split7[2],split7[3],split7[4],split7[5],split7[6],split7[7],split7[8],split7[9],split7[10],split7[11],split7[12],split7[13],split7[14],split7[15],split7[16],split7[17],split7[18],split7[19],split7[20],split7[21],split7[22],split7[23],split7[24],split7[25],split7[26],split7[27],split7[28],split7[29],split7[30],split7[31]}          });

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
						  new List<string>() {split0[0],split0[1],split0[2],split0[3],split0[4],split0[5],split0[6],split0[7],split0[8],split0[9],split0[10],split0[11],split0[12],split0[13],split0[14],split0[15],split0[16],split0[17],split0[18],split0[19],split0[20],split0[21],split0[22],split0[23],split0[24],split0[25],split0[26],split0[27],split0[28],split0[29],split0[30],split0[31]},
new List<string>() {split1[0],split1[1],split1[2],split1[3],split1[4],split1[5],split1[6],split1[7],split1[8],split1[9],split1[10],split1[11],split1[12],split1[13],split1[14],split1[15],split1[16],split1[17],split1[18],split1[19],split1[20],split1[21],split1[22],split1[23],split1[24],split1[25],split1[26],split1[27],split1[28],split1[29],split1[30],split1[31]},
new List<string>() {split2[0],split2[1],split2[2],split2[3],split2[4],split2[5],split2[6],split2[7],split2[8],split2[9],split2[10],split2[11],split2[12],split2[13],split2[14],split2[15],split2[16],split2[17],split2[18],split2[19],split2[20],split2[21],split2[22],split2[23],split2[24],split2[25],split2[26],split2[27],split2[28],split2[29],split2[30],split2[31]},
new List<string>() {split3[0],split3[1],split3[2],split3[3],split3[4],split3[5],split3[6],split3[7],split3[8],split3[9],split3[10],split3[11],split3[12],split3[13],split3[14],split3[15],split3[16],split3[17],split3[18],split3[19],split3[20],split3[21],split3[22],split3[23],split3[24],split3[25],split3[26],split3[27],split3[28],split3[29],split3[30],split3[31]},
new List<string>() {split4[0],split4[1],split4[2],split4[3],split4[4],split4[5],split4[6],split4[7],split4[8],split4[9],split4[10],split4[11],split4[12],split4[13],split4[14],split4[15],split4[16],split4[17],split4[18],split4[19],split4[20],split4[21],split4[22],split4[23],split4[24],split4[25],split4[26],split4[27],split4[28],split4[29],split4[30],split4[31]},
new List<string>() {split5[0],split5[1],split5[2],split5[3],split5[4],split5[5],split5[6],split5[7],split5[8],split5[9],split5[10],split5[11],split5[12],split5[13],split5[14],split5[15],split5[16],split5[17],split5[18],split5[19],split5[20],split5[21],split5[22],split5[23],split5[24],split5[25],split5[26],split5[27],split5[28],split5[29],split5[30],split5[31]},
new List<string>() {split6[0],split6[1],split6[2],split6[3],split6[4],split6[5],split6[6],split6[7],split6[8],split6[9],split6[10],split6[11],split6[12],split6[13],split6[14],split6[15],split6[16],split6[17],split6[18],split6[19],split6[20],split6[21],split6[22],split6[23],split6[24],split6[25],split6[26],split6[27],split6[28],split6[29],split6[30],split6[31]},
new List<string>() {split7[0],split7[1],split7[2],split7[3],split7[4],split7[5],split7[6],split7[7],split7[8],split7[9],split7[10],split7[11],split7[12],split7[13],split7[14],split7[15],split7[16],split7[17],split7[18],split7[19],split7[20],split7[21],split7[22],split7[23],split7[24],split7[25],split7[26],split7[27],split7[28],split7[29],split7[30],split7[31]} });

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
			new List<string>() {split0[0],split0[1],split0[2],split0[3],split0[4],split0[5],split0[6],split0[7],split0[8],split0[9],split0[10],split0[11],split0[12],split0[13],split0[14],split0[15],split0[16],split0[17],split0[18],split0[19],split0[20],split0[21],split0[22],split0[23],split0[24],split0[25],split0[26],split0[27],split0[28],split0[29],split0[30],split0[31]},
			new List<string>() {split1[0],split1[1],split1[2],split1[3],split1[4],split1[5],split1[6],split1[7],split1[8],split1[9],split1[10],split1[11],split1[12],split1[13],split1[14],split1[15],split1[16],split1[17],split1[18],split1[19],split1[20],split1[21],split1[22],split1[23],split1[24],split1[25],split1[26],split1[27],split1[28],split1[29],split1[30],split1[31]},
			new List<string>() {split2[0],split2[1],split2[2],split2[3],split2[4],split2[5],split2[6],split2[7],split2[8],split2[9],split2[10],split2[11],split2[12],split2[13],split2[14],split2[15],split2[16],split2[17],split2[18],split2[19],split2[20],split2[21],split2[22],split2[23],split2[24],split2[25],split2[26],split2[27],split2[28],split2[29],split2[30],split2[31]},
			new List<string>() {split3[0],split3[1],split3[2],split3[3],split3[4],split3[5],split3[6],split3[7],split3[8],split3[9],split3[10],split3[11],split3[12],split3[13],split3[14],split3[15],split3[16],split3[17],split3[18],split3[19],split3[20],split3[21],split3[22],split3[23],split3[24],split3[25],split3[26],split3[27],split3[28],split3[29],split3[30],split3[31]},
			new List<string>() {split4[0],split4[1],split4[2],split4[3],split4[4],split4[5],split4[6],split4[7],split4[8],split4[9],split4[10],split4[11],split4[12],split4[13],split4[14],split4[15],split4[16],split4[17],split4[18],split4[19],split4[20],split4[21],split4[22],split4[23],split4[24],split4[25],split4[26],split4[27],split4[28],split4[29],split4[30],split4[31]},
			new List<string>() {split5[0],split5[1],split5[2],split5[3],split5[4],split5[5],split5[6],split5[7],split5[8],split5[9],split5[10],split5[11],split5[12],split5[13],split5[14],split5[15],split5[16],split5[17],split5[18],split5[19],split5[20],split5[21],split5[22],split5[23],split5[24],split5[25],split5[26],split5[27],split5[28],split5[29],split5[30],split5[31]},
			new List<string>() {split6[0],split6[1],split6[2],split6[3],split6[4],split6[5],split6[6],split6[7],split6[8],split6[9],split6[10],split6[11],split6[12],split6[13],split6[14],split6[15],split6[16],split6[17],split6[18],split6[19],split6[20],split6[21],split6[22],split6[23],split6[24],split6[25],split6[26],split6[27],split6[28],split6[29],split6[30],split6[31]},
			new List<string>() {split7[0],split7[1],split7[2],split7[3],split7[4],split7[5],split7[6],split7[7],split7[8],split7[9],split7[10],split7[11],split7[12],split7[13],split7[14],split7[15],split7[16],split7[17],split7[18],split7[19],split7[20],split7[21],split7[22],split7[23],split7[24],split7[25],split7[26],split7[27],split7[28],split7[29],split7[30],split7[31]}          });



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

