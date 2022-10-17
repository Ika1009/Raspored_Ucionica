using Raspored_Ucionica.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows;

namespace Raspored_Ucionica.ViewModel
{

    public class MainPageViewModel : SviPodaci
    {
        // public event PropertyChangedEventHandler? PropertyChanged;
        public List<List<string>> rezultatiPonedeljak, rezultatiUtorak, rezultatiSreda, rezultatiCetvrtak, rezultatiPetak;
        public List<List<string>> Slobodne;
        InputWindowViewModel inputViewModel;
        public MainPageViewModel(InputWindowViewModel inputVM)
        {
            inputViewModel = inputVM;
            IzaberiLutajuce();
            Ucionica Temp = lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "39");
            Temp.Slobodna = false;
            List<Odeljenje> lista_odeljenjaSort;
            lista_odeljenjaSort = lista_odeljenja.OrderByDescending(x => x.Broj_ucenika).ToList();
            foreach (Odeljenje odeljenje in lista_odeljenjaSort)
            {
                if(odeljenje.Ime_odeljenja.Contains("3") == false && odeljenje.Ime_odeljenja.Contains("2") == false && odeljenje.Ime_odeljenja.Contains("1") == false && odeljenje.Ime_odeljenja != "III-4")
                {
                    IzaberiStaticno(odeljenje.Ime_odeljenja, odeljenje.Broj_ucenika);
                }
            }
            
            //for (int i = 0; i >= 31; i++)
            //{
            //    if (lista_odeljenjaSort[i].Id_ucionice != null)
            //    {
            //        if (lista_odeljenjaSort[i].Ime_odeljenja == "III-2")
            //        {
            //            lista_odeljenjaSort[i].Id_ucionice = lista_ucionica.First(trazeno => trazeno.Ime_ucionice == "39").Id;
            //            Ucionica temp = lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "39");
            //            temp.Slobodna = false;
            //        }
            //        Ucionica ucionica = lista_ucionica.First(ucionica => ucionica.Slobodna == true && ucionica.Tip is null && ucionica.Ime_ucionice != "svecana sala");
            //        lista_odeljenjaSort[i].Id_ucionice = lista_ucionica.First(trazeno => trazeno.Ime_ucionice == ucionica.Ime_ucionice).Id;
            //        ucionica.Slobodna = false;
            //    }
            //}
            rezultatiPonedeljak = new();
            rezultatiUtorak = new();
            rezultatiSreda = new();
            rezultatiCetvrtak = new();
            rezultatiPetak = new();
            Slobodne = new()
        {
            new List<string>() {"", "", "", "", ""},
            new List<string>() {"", ".", ".", ".", "."},
            new List<string>() {"", ".", ".", ".", "."},
            new List<string>() {"", ".", ".", ".", "."},
            new List<string>() {"", ".", ".", ".", "."},
            new List<string>() {"", ".", ".", ".", "."},
            new List<string>() {"", ".", ".", ".", "."},
            new List<string>() {"", ".", ".", ".", "."}
        };
            rezultatiPonedeljak = NapraviRaspored(ponedeljak, Kponedeljak);
            rezultatiUtorak = NapraviRaspored(utorak, Kutorak);
            rezultatiSreda = NapraviRaspored(sreda, Ksreda);
            rezultatiCetvrtak = NapraviRaspored(cetvrtak, Kcetvrtak);
            rezultatiPetak = NapraviRaspored(petak, Kpetak);
            foreach (Ucionica ucionica in lista_ucionica)
            {
                ucionica.Slobodna = true;
            }
            
            
        }
        public void IzaberiLutajuce()
        {
            int br = 0; 
            void DodajLutajuce(string imeOdeljenja) // dodaje mu stalnu ucionicu
            {
                Random random = new();
                Odeljenje odeljenjeTemp;
                Ucionica ucionicaTemp;
                odeljenjeTemp = lista_odeljenja!.First(odeljenje => odeljenje.Ime_odeljenja == imeOdeljenja);
                int rendomBroj = random.Next(0, lista_id_ucionica_slobodnih_za_staticne!.Count - 1);
                odeljenjeTemp.Id_ucionice = lista_id_ucionica_slobodnih_za_staticne![rendomBroj];
                ucionicaTemp = lista_ucionica.First(ucionica => ucionica.Id == odeljenjeTemp.Id_ucionice);
                ucionicaTemp.Slobodna = false;
                lista_id_ucionica_slobodnih_za_staticne.RemoveAt(rendomBroj);
                br++;
            }
            if (!inputViewModel.Checked11)
                DodajLutajuce("I-1");
            if (!inputViewModel.Checked12)
                DodajLutajuce("I-2");
            if (!inputViewModel.Checked13)
                DodajLutajuce("I-3");
            if (!inputViewModel.Checked21)
                DodajLutajuce("II-1");
            if (!inputViewModel.Checked22)
                DodajLutajuce("II-2");
            if (!inputViewModel.Checked23)
                DodajLutajuce("II-3");
            if (!inputViewModel.Checked31)
                DodajLutajuce("III-1");
            if (!inputViewModel.Checked32)
                DodajLutajuce("III-4");
            if (!inputViewModel.Checked33)
                DodajLutajuce("III-3");
            if (!inputViewModel.Checked41)
                DodajLutajuce("IV-1");
            if (!inputViewModel.Checked42)
                DodajLutajuce("IV-2");
            if (!inputViewModel.Checked43)
                DodajLutajuce("IV-3");
        }
        public void IzaberiStaticno(string Ime_odeljenja, int Velicina_odeljenja)
        {
            List<Ucionica> lista_mogucih = new List<Ucionica>();
            Random random = new();
            Odeljenje odeljenjeTemp;
            odeljenjeTemp = lista_odeljenja!.First(odeljenje => odeljenje.Ime_odeljenja == Ime_odeljenja);
            
            
            foreach(Ucionica ucionica in lista_ucionica)
            {
                if(ucionica.Slobodna == true && ucionica.Tip is null && ucionica.Velicina > (Velicina_odeljenja - 3))
                {
                    lista_mogucih.Add(ucionica);
                }
            }
            int rendomBroj = random.Next(0, lista_mogucih!.Count - 1);
            Ucionica Odabrana = lista_mogucih[rendomBroj];
            odeljenjeTemp.Id_ucionice = Odabrana.Id;
            Odabrana.Slobodna = false;
            lista_mogucih.Clear();
        }
        public List<List<string>> NapraviRaspored(Raspored? dan, Kabineti? Kdan)
        {

            List<List<string>> rezultati;
            rezultati = new()
            {
                new List<string>(){".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".",},
                new List<string>(){".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".",},
                new List<string>(){".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".",},
                new List<string>(){".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".",},
                new List<string>(){".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".",},
                new List<string>(){".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".",},
                new List<string>(){".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".",},
                new List<string>(){".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".",},
            };

            void SpajanjeOdeljenja(string imeCasa, string imeUcionice, int i, int j) // kad se odeljenja spajaju zajedno
            {
                //if (lista_odeljenja![i].Id_ucionice is not null)
                //    lista_ucionica![lista_odeljenja[i].Id_ucionice!.Value].Slobodna = true;// oslobadja se njihova ucionica

                Ucionica ucionica = lista_ucionica!.First(ucionica => ucionica.Ime_ucionice == imeUcionice);

                rezultati[i][j] += ucionica.Ime_ucionice + "/";
                ucionica.Slobodna = false; // ucionica ne moze da se koristi za druge predmete, ali moze za isti kad se spoji
            }

            void DrziOdeljenje(int i, int j) // nalazi slobodnu ucionicu za oba odeljenja
            {

                if (lista_odeljenja![j].Id_ucionice is not null) // nije lutajuce
                {
                    lista_ucionica![lista_odeljenja![j].Id_ucionice!.Value].Slobodna = false;
                    rezultati[i][j] += lista_ucionica[lista_odeljenja[j].Id_ucionice!.Value].Ime_ucionice + "/";
                }
                else // lutajuce
                {
                    DrziLutajuce(i, j);
                }
            }
            void OslobodiLutajuceUcionice()
            {
                bool oslobodi;
                foreach (Ucionica ucionicaTemp in lista_ucionica!)
                {
                    oslobodi = true;
                    foreach (Odeljenje odeljenje1 in lista_odeljenja!)
                    {
                        if (odeljenje1.Id_ucionice == ucionicaTemp.Id)
                            oslobodi = false;
                    }
                    if (oslobodi)
                        ucionicaTemp.Slobodna = true;
                }
            }
            void ZatvoriStaticneUcionice()
            {
                foreach (Ucionica ucionicaTemp in lista_ucionica!)
                {
                    foreach (Odeljenje odeljenje1 in lista_odeljenja!)
                    {
                        if (odeljenje1.Id_ucionice == ucionicaTemp.Id)
                        {
                            ucionicaTemp.Slobodna = false;
                        }
                    }
                }
            }
            void OslobodiUcionicu(int i, int j)
            {
                Ucionica ucionicaTemp = lista_ucionica!.First(ucionica => ucionica.Id == lista_odeljenja![j].Id_ucionice);
                ucionicaTemp.Slobodna = true;
                //rezultati[i][j] = ponedeljak!.RasporedCasova[i][j];

            }
            void OslobodiSveUcionice(int i)
            {
                for (int j = 0; j < 32; j++)
                {
                    if (dan!.RasporedCasova[i][j] == "." || dan!.RasporedCasova[i][j] == "" || dan.RasporedCasova[i][j] == "fv" || dan.RasporedCasova[i][j] == "info" ||
                        dan!.RasporedCasova[i][j] == "hem/info" || dan!.RasporedCasova[i][j] == "info/hem" ||
                        dan!.RasporedCasova[i][j] == "g1" || dan!.RasporedCasova[i][j] == "g2" || dan!.RasporedCasova[i][j] == "g3" ||
                        dan!.RasporedCasova[i][j] == "g4" || dan!.RasporedCasova[i][j] == "g5")
                    {
                        if (lista_odeljenja![j].Id_ucionice is not null) // nije lutajuce
                            OslobodiUcionicu(i, j);
                    }
                }
            }
            void OslobodiJezickeUcionice(int i)
            {
                bool Da_Li_Se_Koristi_J2 = false;
                for (int j = 0; j < 32; j++)
                {
                    int duzina = dan.RasporedCasova[i][j].Count(x => x == '/');
                    for (int k = 0; k <= duzina; k++)
                    {
                        string trenutno = dan.RasporedCasova[i][j].Split("/")[k];
                        if (trenutno == "r") { Da_Li_Se_Koristi_J2 = true; }
                    }
                }
                if (!Da_Li_Se_Koristi_J2) { lista_ucionica!.First(ucionica => ucionica.Ime_ucionice == "jezicka2").Tip = null; }

            }
            void DrziLutajuce(int i, int j)
            {
                if (lista_ucionica!.FirstOrDefault(ucionica => ucionica.Slobodna == true && ucionica.Tip is null) is null)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        string a = "";
                        if (Kdan.RasporedKabineta[k][i] == "true")
                        {
                            switch (k)
                            {
                                case 0: a = "22"; break;
                                case 1: a = "29"; break;
                                case 2: a = "23a"; break;
                                case 3: a = "Sremac"; break;
                                case 4: a = "Multimedijalna"; break;
                            }
                            rezultati[i][j] += a + "/";
                            Kdan.RasporedKabineta[k][i] = "false";
                            break;
                        }
                    }
                }
                //Funkcija za korišćenje osmice
                //else if (lista_ucionica!.FirstOrDefault(ucionica => ucionica.Slobodna == true && ucionica.Tip is null && ucionica.Ime_ucionice != "8") is not null)
                //{
                //    Ucionica slobodna = lista_ucionica!.First(ucionica => ucionica.Slobodna == true && ucionica.Tip is null && ucionica.Ime_ucionice != "8");
                //    rezultati[i][j] += slobodna.Ime_ucionice + "/";
                //    slobodna.Slobodna = false;
                //}
                else
                {
                    Ucionica slobodna = lista_ucionica!.First(ucionica => ucionica.Slobodna == true && ucionica.Tip is null);
                    rezultati[i][j] += slobodna.Ime_ucionice + "/";
                    slobodna.Slobodna = false;
                }
            }
            void Gradjansko(string imeCasa, ref bool imanjeCasa, ref string imeUcioniceZaGradjansko, int i, int j)
            {
                if (!imanjeCasa)
                {
                    imeUcioniceZaGradjansko = lista_ucionica!.Where(ucionica => ucionica.Slobodna == true && ucionica.Tip is null && ucionica.Ime_ucionice != "svecana sala").Last().Ime_ucionice;
                    imanjeCasa = true;
                }
                SpajanjeOdeljenja(imeCasa, imeUcioniceZaGradjansko, i, j);
            }
            void NadjiSlobodne(int i)
            {
                int id = lista_ucionica!.Last().Id;
                id--;
                int k;
                if (dan == ponedeljak)
                    k = 0;
                else if (dan == utorak)
                    k = 1;
                else if (dan == sreda)
                    k = 2;
                else if (dan == cetvrtak)
                    k = 3;
                else
                    k = 4;
                while (id >= 0)
                {
                    Ucionica ucionica = lista_ucionica!.First(ucionica => ucionica.Id == id && ucionica.Tip is null);
                    if (ucionica.Slobodna == true)
                    {
                        Slobodne[i][k] += ucionica.Ime_ucionice + "/";
                    }
                    id--;
                }

            }
            for (int i = 0; i < 32; i++) //za nulti cas
            {
                bool g1Ima = false, g2Ima = false, g3Ima = false, g4Ima = false, g5Ima = false;
                string imeUcioniceZaGradjansko1 = "", imeUcioniceZaGradjansko2 = "", imeUcioniceZaGradjansko3 = "", imeUcioniceZaGradjansko4 = "", imeUcioniceZaGradjansko5 = "";
                if (dan!.RasporedCasova[0][i] == "")
                    rezultati[0][i] = "/";

                if (dan!.RasporedCasova[0][i] == "info")
                    rezultati[0][i] = "info";

                if (dan.RasporedCasova[0][i] == "reg")
                    DrziOdeljenje(0, i);

                else if (dan.RasporedCasova[0][i] == "verska")
                    SpajanjeOdeljenja(dan.RasporedCasova[0][i], "biblioteka", 0, i);

                else if (dan!.RasporedCasova[0][i] == "g1")
                {
                    if (!g1Ima)
                    {
                        imeUcioniceZaGradjansko1 = lista_ucionica!.Where(ucionica => ucionica.Slobodna == true && ucionica.Tip is null && ucionica.Ime_ucionice != "svecana sala").Last().Ime_ucionice;
                        g1Ima = true;
                    }
                    SpajanjeOdeljenja("g1", imeUcioniceZaGradjansko1, 0, i);

                }
                else if (dan!.RasporedCasova[0][i] == "g2")
                {
                    if (!g2Ima)
                    {
                        imeUcioniceZaGradjansko2 = lista_ucionica!.Where(ucionica => ucionica.Slobodna == true && ucionica.Tip is null && ucionica.Ime_ucionice != "svecana sala").Last().Ime_ucionice;
                        g2Ima = true;
                    }
                    SpajanjeOdeljenja("g2", imeUcioniceZaGradjansko2, 0, i);
                }
                else if (dan!.RasporedCasova[0][i] == "g3")
                {
                    if (!g3Ima)
                    {
                        imeUcioniceZaGradjansko3 = lista_ucionica!.Where(ucionica => ucionica.Slobodna == true && ucionica.Tip is null && ucionica.Ime_ucionice != "svecana sala").Last().Ime_ucionice;
                        g3Ima = true;
                    }
                    SpajanjeOdeljenja("g3", imeUcioniceZaGradjansko3, 0, i);
                }
                else if (dan!.RasporedCasova[0][i] == "g4")
                {
                    if (!g4Ima)
                    {
                        imeUcioniceZaGradjansko4 = lista_ucionica!.Where(ucionica => ucionica.Slobodna == true && ucionica.Tip is null && ucionica.Ime_ucionice != "svecana sala").Last().Ime_ucionice;
                        g4Ima = true;
                    }
                    SpajanjeOdeljenja("g4", imeUcioniceZaGradjansko4, 0, i);
                }
                else if (dan!.RasporedCasova[0][i] == "g5")
                {
                    if (!g5Ima)
                    {
                        imeUcioniceZaGradjansko5 = lista_ucionica!.Where(ucionica => ucionica.Slobodna == true && ucionica.Tip is null && ucionica.Ime_ucionice != "svecana sala").Last().Ime_ucionice;
                        g5Ima = true;
                    }
                    SpajanjeOdeljenja("g5", imeUcioniceZaGradjansko5, 0, i);
                }


            }
            //NadjiSlobodne(0);

            //!!//
            //!GLAVNA FOR PETLJA!//
            //!!!//
            for (int i = 1; i < 8; i++) // za dan
            {
                bool g1Ima = false, g2Ima = false, g3Ima = false, g4Ima = false, g5Ima = false;
                string imeUcioniceZaFrancuski = "", imeUcioniceZaGradjansko1 = "", imeUcioniceZaGradjansko2 = "", imeUcioniceZaGradjansko3 = "", imeUcioniceZaGradjansko4 = "", imeUcioniceZaGradjansko5 = "";
                bool imanjeCasaFrancuski = false;
                Ucionica jezicka2 = lista_ucionica!.First(ucionica => ucionica.Ime_ucionice == "jezicka2");
                jezicka2.Tip = true;
                ZatvoriStaticneUcionice();
                OslobodiLutajuceUcionice();
                OslobodiSveUcionice(i);
                OslobodiJezickeUcionice(i);
                for (var j = 0; j < 32; j++)
                {
                    //lista_ucionica!.Last().Slobodna = true;
                    if (dan!.RasporedCasova[i][j] == "reg")
                    {
                        DrziOdeljenje(i, j);
                    }
                    else if (dan!.RasporedCasova[i][j] == "info")
                        rezultati[i][j] = "info";
                    else if (dan!.RasporedCasova[i][j] == "fv")
                        rezultati[i][j] = "fv";
                    else if (dan.RasporedCasova[i][j] == "verska")
                        SpajanjeOdeljenja(dan.RasporedCasova[i][j], "biblioteka", i, j);
                    else if (dan!.RasporedCasova[i][j].Contains('/'))
                    {

                        rezultati[i][j] = "";
                        string cas = dan!.RasporedCasova[i][j];
                        int brojac = cas.Count(c => c == '/');
                        bool provera = false;
                        for (int c = 0; c <= brojac; c++)
                        {
                            string trenutno = cas.Split("/")[c];
                            Ucionica biblioteka = lista_ucionica!.First(ucionica => ucionica.Ime_ucionice == "biblioteka");
                            if (trenutno == "hem")
                            {
                                if (string.IsNullOrEmpty(rezultati[i][j]))
                                    rezultati[i][j] = "hemk";
                                else
                                    rezultati[i][j] += "/hemk";
                            }

                            else if (trenutno == "reg" || trenutno == "n")
                            {
                                if (provera) // provara da li je vec uso ovde
                                {
                                    DrziLutajuce(i, j);
                                    //Ucionica slobodna = lista_ucionica!.First(ucionica => ucionica.Slobodna == true && ucionica.Tip is null);
                                    //rezultati[i][j] += slobodna.Ime_ucionice +"/";
                                    //slobodna.Slobodna = false;
                                }
                                else
                                {
                                    DrziOdeljenje(i, j);
                                    provera = true;
                                }
                            }
                            else if (trenutno == "info")
                            {
                                if (string.IsNullOrEmpty(rezultati[i][j]))
                                    rezultati[i][j] = "info";
                                else
                                    rezultati[i][j] += "/info/";
                            }
                            else if (trenutno == "/verska")
                                rezultati[i][j] += "/bibl" + "/";
                            else if (trenutno == "g1")
                                Gradjansko("g1", ref g1Ima, ref imeUcioniceZaGradjansko1, i, j);
                            else if (trenutno == "g2")
                                Gradjansko("g2", ref g2Ima, ref imeUcioniceZaGradjansko2, i, j);
                            else if (trenutno == "g3")
                                Gradjansko("g3", ref g3Ima, ref imeUcioniceZaGradjansko3, i, j);
                            else if (trenutno == "g4")
                                Gradjansko("g4", ref g4Ima, ref imeUcioniceZaGradjansko4, i, j);
                            else if (trenutno == "g5")
                                Gradjansko("g5", ref g5Ima, ref imeUcioniceZaGradjansko5, i, j);
                            else if (trenutno == "i")
                                rezultati[i][j] += "/j1";
                            else if (trenutno == "r")
                                rezultati[i][j] += "/j2";
                            else if (trenutno == "f" && biblioteka.Slobodna == true)
                                rezultati[i][j] += "/bibl" + "/";
                            else if (trenutno == "f" && biblioteka.Slobodna == false)
                            {
                                if (!imanjeCasaFrancuski)
                                {
                                    imeUcioniceZaFrancuski = lista_ucionica!.Where(ucionica => ucionica.Slobodna == true && ucionica.Tip is null && ucionica.Ime_ucionice != "svecana sala").Last().Ime_ucionice;
                                    imanjeCasaFrancuski = true;
                                }
                                SpajanjeOdeljenja("f", imeUcioniceZaFrancuski, i, j);
                            }

                        }

                    }

                    else if (dan!.RasporedCasova[i][j] == "g1")
                    {
                        if (!g1Ima)
                        {
                            imeUcioniceZaGradjansko1 = lista_ucionica!.Where(ucionica => ucionica.Slobodna == true && ucionica.Tip is null && ucionica.Ime_ucionice != "svecana sala").Last().Ime_ucionice;
                            g1Ima = true;
                        }
                        SpajanjeOdeljenja("g1", imeUcioniceZaGradjansko1, i, j);

                    }
                    else if (dan!.RasporedCasova[i][j] == "g2")
                    {
                        if (!g2Ima)
                        {
                            imeUcioniceZaGradjansko2 = lista_ucionica!.Where(ucionica => ucionica.Slobodna == true && ucionica.Tip is null && ucionica.Ime_ucionice != "svecana sala").Last().Ime_ucionice;
                            g2Ima = true;
                        }
                        SpajanjeOdeljenja("g2", imeUcioniceZaGradjansko2, i, j);
                    }
                    else if (dan!.RasporedCasova[i][j] == "g3")
                    {
                        if (!g3Ima)
                        {
                            imeUcioniceZaGradjansko3 = lista_ucionica!.Where(ucionica => ucionica.Slobodna == true && ucionica.Tip is null && ucionica.Ime_ucionice != "svecana sala").Last().Ime_ucionice;
                            g3Ima = true;
                        }
                        SpajanjeOdeljenja("g3", imeUcioniceZaGradjansko3, i, i);
                    }
                    else if (dan!.RasporedCasova[i][j] == "g4")
                    {
                        if (!g4Ima)
                        {
                            imeUcioniceZaGradjansko4 = lista_ucionica!.Where(ucionica => ucionica.Slobodna == true && ucionica.Tip is null && ucionica.Ime_ucionice != "svecana sala").Last().Ime_ucionice;
                            g4Ima = true;
                        }
                        SpajanjeOdeljenja("g4", imeUcioniceZaGradjansko4, i, j);
                    }
                    else if (dan!.RasporedCasova[i][j] == "g5")
                    {
                        if (!g5Ima)
                        {
                            imeUcioniceZaGradjansko5 = lista_ucionica!.Where(ucionica => ucionica.Slobodna == true && ucionica.Tip is null && ucionica.Ime_ucionice != "svecana sala").Last().Ime_ucionice;
                            g5Ima = true;
                        }
                        SpajanjeOdeljenja("g5", imeUcioniceZaGradjansko5, i, j);
                    }
                    else
                        rezultati[i][j] = ".";

                }
                NadjiSlobodne(i);

            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    if (rezultati[i][j].IndexOf('.') != -1)
                        rezultati[i][j] = rezultati[i][j].Remove(rezultati[i][j].IndexOf('.'), 1);
                    if (rezultati[i][j].IndexOf('/') != -1 && rezultati[i][j].LastIndexOf('/') == rezultati[i][j].Length - 1)
                        rezultati[i][j] = rezultati[i][j].Remove(rezultati[i][j].LastIndexOf('/'));
                    if (rezultati[i][j].IndexOf("//") != -1)
                    {
                        rezultati[i][j] = rezultati[i][j].Replace("//", "/");
                    }

                }
            }

            return rezultati;
        }
    }

}


