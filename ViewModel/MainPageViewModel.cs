using Raspored_Ucionica.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.IO;

namespace Raspored_Ucionica.ViewModel
{
    public class MainPageViewModel : SviPodaci
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public List<List<string>> rezultatiPonedeljak, rezultatiUtorak, rezultatiSreda, rezultatiCetvrtak, rezultatiPetak;
        public List<List<string>> Slobodne;
        public List<string> Cos = new List<string>();
        
        InputWindowViewModel inputViewModel;
        public MainPageViewModel(InputWindowViewModel inputVM)
        {
            inputViewModel = inputVM;
      
            List<Odeljenje> neizabrana = new List<Odeljenje>();
            int i = 0;
            foreach(string ime in inputVM.boxovi)
            {
                if(ime == "")
                {
                    neizabrana.Add(lista_odeljenja[i]);
                }
                else if (ime != "Лутајуће")
                {
                    Ucionica ucionica = lista_ucionica.Find(ucionica => ucionica.Ime_ucionice == ime);
                    lista_odeljenja[i].Id_ucionice = ucionica.Id;
                    ucionica.Slobodna = false;
                }
                i++;
            }
            //Ucionica Temp = lista_ucionica.First(ucionica => ucionica.Ime_ucionice == "39");
            //Temp.Slobodna = false;
            List<Odeljenje> lista_odeljenjaSort;
            lista_odeljenjaSort = neizabrana!.OrderByDescending(x => x.Broj_ucenika).ToList();
            foreach (Odeljenje odeljenje in lista_odeljenjaSort)
            {
                IzaberiStaticno(odeljenje.Ime_odeljenja, odeljenje.Broj_ucenika);
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
            NapraviExcelAsync();
            foreach (Ucionica ucionica in lista_ucionica!)
            {
                ucionica.Slobodna = true;
            }
        }
        //public void IzaberiLutajuce()
        //{
        //    void DodajLutajuce(string imeOdeljenja) // dodaje mu stalnu ucionicu
        //    {
        //        Random random = new();
        //        Odeljenje odeljenjeTemp;
        //        Ucionica ucionicaTemp;
        //        odeljenjeTemp = lista_odeljenja!.First(odeljenje => odeljenje.Ime_odeljenja == imeOdeljenja);
        //        int rendomBroj = random.Next(0, lista_id_ucionica_slobodnih_za_staticne!.Count - 1);
        //        odeljenjeTemp.Id_ucionice = lista_id_ucionica_slobodnih_za_staticne![rendomBroj];
        //        ucionicaTemp = lista_ucionica!.First(ucionica => ucionica.Id == odeljenjeTemp.Id_ucionice && ucionica.Velicina >= (odeljenjeTemp.Broj_ucenika - 2));
        //        ucionicaTemp.Slobodna = false;
        //        lista_id_ucionica_slobodnih_za_staticne.RemoveAt(rendomBroj);
        //    }

        //    if (!inputViewModel.Checked32) // nase odeljenje prvo jer mora da se uzme 39 za nas ako treba
        //    {
        //        Odeljenje odeljenjeTemp = lista_odeljenja!.First(odeljenje => odeljenje.Ime_odeljenja == "III-2");
        //        odeljenjeTemp.Id_ucionice = lista_id_ucionica_slobodnih_za_staticne![0];
        //        lista_ucionica!.First(ucionica => ucionica.Id == odeljenjeTemp.Id_ucionice).Slobodna = false;
        //        lista_id_ucionica_slobodnih_za_staticne.RemoveAt(0);
        //    }
        //    if (!inputViewModel.Checked11)
        //        DodajLutajuce("I-1");
        //    if (!inputViewModel.Checked12)
        //        DodajLutajuce("I-2");
        //    if (!inputViewModel.Checked13)
        //        DodajLutajuce("I-3");
        //    if (!inputViewModel.Checked21)
        //        DodajLutajuce("II-1");
        //    if (!inputViewModel.Checked22)
        //        DodajLutajuce("II-2");
        //    if (!inputViewModel.Checked23)
        //        DodajLutajuce("II-3");
        //    if (!inputViewModel.Checked31)
        //        DodajLutajuce("III-1");
        //    if (!inputViewModel.Checked33)
        //        DodajLutajuce("III-3");
        //    if (!inputViewModel.Checked34)
        //        DodajLutajuce("III-4");
        //    if (!inputViewModel.Checked41)
        //        DodajLutajuce("IV-1");
        //    if (!inputViewModel.Checked42)
        //        DodajLutajuce("IV-2");
        //    if (!inputViewModel.Checked43)
        //        DodajLutajuce("IV-3");
        //}
        public void IzaberiStaticno(string Ime_odeljenja, int Velicina_odeljenja)
        {
            List<Ucionica> lista_mogucih = new List<Ucionica>();
            Random random = new();
            Odeljenje odeljenjeTemp;
            odeljenjeTemp = lista_odeljenja!.First(odeljenje => odeljenje.Ime_odeljenja == Ime_odeljenja);
            
            
            foreach(Ucionica ucionica in lista_ucionica)
            {
                if(ucionica.Slobodna == true && ucionica.Tip is null && ucionica.Ime_ucionice != "8" && ucionica.Velicina >= Velicina_odeljenja)
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
                    Odeljenje Temp = lista_odeljenja!.First(odeljenje => odeljenje.Id == j);
                    Ucionica slobodna = lista_ucionica!.First(ucionica => ucionica.Slobodna == true && ucionica.Tip is null && ucionica.Velicina >= (Temp.Broj_ucenika - 3));
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
                    Ucionica ucionica = lista_ucionica!.First(ucionica => ucionica.Id == id);
                    if (ucionica.Slobodna == true && ucionica.Tip is null)
                    {
                        Slobodne[i][k] += ucionica.Ime_ucionice + "/";
                    }
                    id--;
                }

            }
            void NadjiCos()
            {
                List<Ucionica> osloboditi = new List<Ucionica>();
                bool[] slobodne = { true, true, true, true, true, true };
                string[] ucionice = { "22", "29", "23a", "Sremac", "Multimedijalna", "Svecana" };
                Odeljenje trece_dva = lista_odeljenja.First(odeljenje => odeljenje.Ime_odeljenja == "III-2");
                if (trece_dva.Id_ucionice is null)
                {
                    slobodne[0] = false;
                }
                for (int i = 0; i < 32; i++)
                {
                    Odeljenje odeljenje = lista_odeljenja.First(odeljenje => odeljenje.Id == i);

                    if (odeljenje.Id_ucionice is not null)
                    {
                        Ucionica ucionica = lista_ucionica.First(ucionica => ucionica.Id == odeljenje.Id_ucionice);
                        Cos.Add(ucionica.Ime_ucionice);
                    }
                    else
                    {
                        if (odeljenje.Ime_odeljenja == "III-2")
                        {
                            Cos.Add(ucionice[0]);
                            slobodne[0] = false;
                        }
                        else if (rezultati[4][i].Contains("svecana") == true)
                        {
                            Cos.Add(ucionice[5]);
                            slobodne[5] = false;
                        }
                        else
                        {
                            for(int r=0; r<6; r++)
                            {  
                                if (slobodne[r] == true)
                                {
                                    Cos.Add(ucionice[r]);
                                    slobodne[r] = false;
                                    break;
                                }
                            }
                        }
                    }
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
                if (dan == ponedeljak && i == 5)
                {
                    NadjiCos();
                }
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
                                    rezultati[i][j] = "info/";
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

        public async void NapraviExcelAsync()
        {
            int kolona = 5, redovi = 8, prva = 0, druga = 0, treca = 0, cetvrta = 0, peta = 0, sesta = 0;
            int nbColumns = 32;
            int nbRows = 8;
            int za_labele_index = 0;
            string[] zaUpisivanje = new string[500];
            zaUpisivanje[0] += "Staticna Odeljenja: ";
            zaUpisivanje[69] += "Slobodne Ucionice: ";
            zaUpisivanje[79] += "Zauzetost svecane sale: ";
            zaUpisivanje[89] += "Grupe: ";
            for (int i = 0; i < lista_odeljenja!.Count; i++)
            {
                zaUpisivanje[2] += lista_odeljenja[i].Ime_odeljenja + ",";
                if (lista_odeljenja[i].Id_ucionice == null)
                    zaUpisivanje[3] += "Lutajuce,";
                else
                {
                    Ucionica Temp = lista_ucionica!.First(ucionica => ucionica.Id == lista_odeljenja[i].Id_ucionice);
                    zaUpisivanje[3] += Temp.Ime_ucionice + ",";
                }
            }




            for (int i = 0; i < nbColumns; i++)
            {
                if (lista_odeljenja[i].Id_ucionice == null)
                {
                    if (za_labele_index == 0)
                    {
                        zaUpisivanje[7] = lista_odeljenja[i].Ime_odeljenja.ToString() + " Cos: ,";
                        prva = lista_odeljenja[i].Id;
                        za_labele_index++;
                    }
                    else if (za_labele_index == 1)
                    {
                        zaUpisivanje[17] = lista_odeljenja[i].Ime_odeljenja.ToString() + " Cos: ,";
                        druga = lista_odeljenja[i].Id;
                        za_labele_index++;

                    }
                    else if (za_labele_index == 2)
                    {
                        zaUpisivanje[27] = lista_odeljenja[i].Ime_odeljenja.ToString() + " Cos: ,";
                        treca = lista_odeljenja[i].Id;
                        za_labele_index++;
                    }
                    else if (za_labele_index == 3)
                    {
                        zaUpisivanje[37] = lista_odeljenja[i].Ime_odeljenja.ToString() + " Cos: ,";
                        cetvrta = lista_odeljenja[i].Id;
                        za_labele_index++;

                    }
                    else if (za_labele_index == 4)
                    {
                        zaUpisivanje[47] = lista_odeljenja[i].Ime_odeljenja.ToString() + " Cos: ,";
                        peta = lista_odeljenja[i].Id;
                        za_labele_index++;

                    }
                    else
                    {
                        zaUpisivanje[57] = lista_odeljenja[i].Ime_odeljenja.ToString() + " Cos: ,";
                        sesta = lista_odeljenja[i].Id;
                        za_labele_index++;


                    }
                }
            }
            zaUpisivanje[7] += Cos[prva].ToString();
            zaUpisivanje[17] += Cos[druga].ToString();
            zaUpisivanje[27] += Cos[treca].ToString();
            zaUpisivanje[37] += Cos[cetvrta].ToString();
            zaUpisivanje[47] += Cos[peta].ToString();
            zaUpisivanje[57] += Cos[sesta].ToString();
            for (int row = 0; row < redovi; row++)
            {
                zaUpisivanje[70] += (row.ToString()) + ",";
                zaUpisivanje[80] += (row.ToString()) + ",";
            }
            for (int row = 0; row < kolona; row++)
            {
                for (int col = 0; col < redovi; col++)
                {

                    for (int i = 0; i < nbColumns; i++)
                    {
                        if (row == 0)
                        {

                            if (rezultatiPonedeljak[col][i].Contains("/"))
                            {
                                string[] ime = ponedeljak.RasporedCasova[col][i].Split("/");
                                string[] niz = rezultatiPonedeljak[col][i].Split("/");
                                zaUpisivanje[90 + col] += lista_odeljenja[i].Ime_odeljenja + ": ";
                                if (ponedeljak.RasporedCasova[col][i] == "reg/reg")
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (j % 2 == 0)
                                        {
                                            zaUpisivanje[90 + col] += "grupaA - " + niz[j] + "; ";
                                        }
                                        else
                                        {
                                            zaUpisivanje[90 + col] += "grupaB - " + niz[j] + "; ";
                                        }
                                    }
                                    zaUpisivanje[90 + col] += "\n";
                                }
                                else
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (ime[j] == "reg")
                                        {
                                            zaUpisivanje[90 + col] += "grupa - " + niz[j] + "; ";
                                        }
                                        else
                                        {
                                            zaUpisivanje[90 + col] += ime[j] + " - " + niz[j] + "; ";
                                        }
                                    }
                                    zaUpisivanje[90 + col] += "\n";
                                }
                            }

                            zaUpisivanje[80 + col] = ",";
                            if (rezultatiPonedeljak[col][i].Contains("svecana sala"))
                            {
                                zaUpisivanje[80 + col] += lista_odeljenja[i].Ime_odeljenja;
                            }
                            
                        }

                        else if (row == 1)
                        {
                            if (rezultatiUtorak[col][i].Contains("/"))
                            {
                                string[] ime = utorak.RasporedCasova[col][i].Split("/");
                                string[] niz = rezultatiUtorak[col][i].Split("/");
                                zaUpisivanje[90 + col] += lista_odeljenja[i].Ime_odeljenja + ": ";
                                if (ponedeljak.RasporedCasova[col][i] == "reg/reg")
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (j % 2 == 0)
                                        {
                                            zaUpisivanje[90 + col] += "grupaA - " + niz[j] + "; ";
                                        }
                                        else
                                        {
                                            zaUpisivanje[90 + col] += "grupaB - " + niz[j] + "; ";
                                        }
                                    }
                                    zaUpisivanje[90 + col] += "\n";
                                }
                                else
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (ime[j] == "reg")
                                        {
                                            zaUpisivanje[90 + col] += "grupa - " + niz[j] + "; ";
                                        }
                                        else
                                        {
                                            zaUpisivanje[90 + col] += ime[j] + " - " + niz[j] + "; ";
                                        }
                                    }
                                    zaUpisivanje[90 + col] += "\n";
                                }

                            }
                            zaUpisivanje[80 + col] = ",";
                            if (rezultatiUtorak[col][i].Contains("svecana sala"))
                            {
                                zaUpisivanje[80 + col] += lista_odeljenja[i].Ime_odeljenja;
                            }
                        }
                        else if (row == 2)
                        {
                            if (rezultatiSreda[col][i].Contains("/"))
                            {
                                string[] ime = sreda.RasporedCasova[col][i].Split("/");
                                string[] niz = rezultatiSreda[col][i].Split("/");
                                zaUpisivanje[90 + col] += lista_odeljenja[i].Ime_odeljenja + ": ";
                                if (ponedeljak.RasporedCasova[col][i] == "reg/reg")
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (j % 2 == 0)
                                        {
                                            zaUpisivanje[90 + col] += "grupaA - " + niz[j] + "; ";
                                        }
                                        else
                                        {
                                            zaUpisivanje[90 + col] += "grupaB - " + niz[j] + "; ";
                                        }
                                    }
                                    zaUpisivanje[90 + col] += "\n";
                                }
                                else
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (ime[j] == "reg")
                                        {
                                            zaUpisivanje[90 + col] += "grupa - " + niz[j] + "; ";
                                        }
                                        else
                                        {
                                            zaUpisivanje[90 + col] += ime[j] + " - " + niz[j] + "; ";
                                        }
                                    }
                                    zaUpisivanje[90 + col] += "\n";
                                }
                            }
                            zaUpisivanje[80 + col] = ",";
                            if (rezultatiSreda[col][i].Contains("svecana sala"))
                            {
                                zaUpisivanje[80 + col] += lista_odeljenja[i].Ime_odeljenja;
                            }

                        }
                        else if (row == 3)
                        {
                            if (rezultatiCetvrtak[col][i].Contains("/"))
                            {
                                string[] ime = cetvrtak.RasporedCasova[col][i].Split("/");
                                string[] niz = rezultatiCetvrtak[col][i].Split("/");
                                zaUpisivanje[90 + col] += lista_odeljenja[i].Ime_odeljenja + ": ";
                                if (ponedeljak.RasporedCasova[col][i] == "reg/reg")
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (j % 2 == 0)
                                        {
                                            zaUpisivanje[90 + col] += "grupaA - " + niz[j] + "; ";
                                        }
                                        else
                                        {
                                            zaUpisivanje[90 + col] += "grupaB - " + niz[j] + "; ";
                                        }
                                    }
                                    zaUpisivanje[90 + col] += "\n";
                                }
                                else
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (ime[j] == "reg")
                                        {
                                            zaUpisivanje[90 + col] += "grupa - " + niz[j] + "; ";
                                        }
                                        else
                                        {
                                            zaUpisivanje[90 + col] += ime[j] + " - " + niz[j] + "; ";
                                        }
                                    }
                                    zaUpisivanje[90 + col] += "\n";
                                }
                            }
                            zaUpisivanje[80 + col] = ",";
                            if (rezultatiCetvrtak[col][i].Contains("svecana sala"))
                            {
                                zaUpisivanje[80 + col] += lista_odeljenja[i].Ime_odeljenja;
                            }

                        }
                        else
                        {
                            if (rezultatiPetak[col][i].Contains("/"))
                            {
                                string[] ime = petak.RasporedCasova[col][i].Split("/");
                                string[] niz = rezultatiPetak[col][i].Split("/");
                                zaUpisivanje[90 + col] += lista_odeljenja[i].Ime_odeljenja + ": ";
                                if (ponedeljak.RasporedCasova[col][i] == "reg/reg")
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (j % 2 == 0)
                                        {
                                            zaUpisivanje[90 + col] += "grupaA - " + niz[j] + "; ";
                                        }
                                        else
                                        {
                                            zaUpisivanje[90 + col] += "grupaB - " + niz[j] + "; ";
                                        }
                                    }
                                    zaUpisivanje[90 + col] += "\n";
                                }
                                else
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (ime[j] == "reg")
                                        {
                                            zaUpisivanje[90 + col] += "grupa - " + niz[j] + "; ";
                                        }
                                        else
                                        {
                                            zaUpisivanje[90 + col] += ime[j] + " - " + niz[j] + "; ";
                                        }
                                    }
                                    zaUpisivanje[90 + col] += "\n";
                                }
                            }
                            zaUpisivanje[80 + col] += ",";
                            if (rezultatiPetak[col][i].Contains("svecana sala"))
                            {
                                zaUpisivanje[80 + col] += lista_odeljenja[i].Ime_odeljenja;
                            }
                        }
                    }

                }
            }
            for (int i = 0; i < kolona; i++)
            {
                if (i == 0)
                {
                    //SvSala.Columns.Add("Понедељак");
                    zaUpisivanje[10 + i] +="Ponedeljak,";
                    zaUpisivanje[20 + i] += "Ponedeljak,";
                    zaUpisivanje[30 + i] += "Ponedeljak,";
                    zaUpisivanje[40 + i] += "Ponedeljak,";
                    zaUpisivanje[50 + i] += "Ponedeljak,";
                    zaUpisivanje[60 + i] += "Ponedeljak,";
                }
                else if (i == 1)
                {
                    //SvSala.Columns.Add("Уторак");
                    zaUpisivanje[10 + i] += "Utorak,";
                    zaUpisivanje[20 + i] += "Utorak,";
                    zaUpisivanje[30 + i] += "Utorak,";
                    zaUpisivanje[40 + i] += "Utorak,";
                    zaUpisivanje[50 + i] += "Utorak,";
                    zaUpisivanje[60 + i] += "Utorak,";
                }
                else if (i == 2)
                {
                    //SvSala.Columns.Add("Среда");
                    zaUpisivanje[10 + i] += "Sreda";
                    zaUpisivanje[20 + i] += "Sreda";
                    zaUpisivanje[30 + i] += "Sreda";
                    zaUpisivanje[40 + i] += "Sreda";
                    zaUpisivanje[50 + i] += "Sreda";
                    zaUpisivanje[60 + i] += "Sreda";
                }
                else if (i == 3)
                {
                    //SvSala.Columns.Add("Четвртак");
                    zaUpisivanje[10 + i] += "Cetvrtak,";
                    zaUpisivanje[20 + i] += "Cetvrtak,";
                    zaUpisivanje[30 + i] += "Cetvrtak,";
                    zaUpisivanje[40 + i] += "Cetvrtak,";
                    zaUpisivanje[50 + i] += "Cetvrtak,";
                    zaUpisivanje[60 + i] += "Cetvrtak,";
                }
                else
                {
                    //SvSala.Columns.Add("Петак");
                    zaUpisivanje[10 + i] += "Petak,";
                    zaUpisivanje[20 + i] += "Petak,";
                    zaUpisivanje[30 + i] += "Petak,";
                    zaUpisivanje[40 + i] += "Petak,";
                    zaUpisivanje[50 + i] += "Petak,";
                    zaUpisivanje[60 + i] += "Petak,";
                }

            }
            for (int row = 0; row < redovi; row++)
            {
                for (int col = 0; col < kolona; col++)
                {
                    if (col == 0)
                    {
                        zaUpisivanje[10 + col] += rezultatiPonedeljak[row][prva] + ",";
                        zaUpisivanje[20 + col] += rezultatiPonedeljak[row][druga] + ",";
                        zaUpisivanje[30 + col] += rezultatiPonedeljak[row][treca] + ",";
                        zaUpisivanje[40 + col] += rezultatiPonedeljak[row][cetvrta] + ",";
                        zaUpisivanje[50 + col] += rezultatiPonedeljak[row][peta] + ",";
                        zaUpisivanje[60 + col] += rezultatiPonedeljak[row][sesta] + ",";
                    }
                    else if (col == 1)
                    {
                        zaUpisivanje[10 + col] += rezultatiUtorak[row][prva] + ",";
                        zaUpisivanje[20 + col] += rezultatiUtorak[row][druga] + ",";
                        zaUpisivanje[30 + col] += rezultatiUtorak[row][treca] + ",";
                        zaUpisivanje[40 + col] += rezultatiUtorak[row][cetvrta] + ",";
                        zaUpisivanje[50 + col] += rezultatiUtorak[row][peta] + ",";
                        zaUpisivanje[60 + col] += rezultatiUtorak[row][sesta] + ",";
                    }
                    else if (col == 2)
                    {
                        zaUpisivanje[10 + col] += rezultatiSreda[row][prva] + ",";
                        zaUpisivanje[20 + col] += rezultatiSreda[row][druga] + ",";
                        zaUpisivanje[30 + col] += rezultatiSreda[row][treca] + ",";
                        zaUpisivanje[40 + col] += rezultatiSreda[row][cetvrta] + ",";
                        zaUpisivanje[50 + col] += rezultatiSreda[row][peta] + ",";
                        zaUpisivanje[60 + col] += rezultatiSreda[row][sesta] + ",";
                    }
                    else if (col == 3)
                    {
                        zaUpisivanje[10 + col] += rezultatiCetvrtak[row][prva] + ",";
                        zaUpisivanje[20 + col] += rezultatiCetvrtak[row][druga] + ",";
                        zaUpisivanje[30 + col] += rezultatiCetvrtak[row][treca] + ",";
                        zaUpisivanje[40 + col] += rezultatiCetvrtak[row][cetvrta] + ",";
                        zaUpisivanje[50 + col] += rezultatiCetvrtak[row][peta] + ",";
                        zaUpisivanje[60 + col] += rezultatiCetvrtak[row][sesta] + ",";
                    }
                    else
                    {
                        zaUpisivanje[10 + col] += rezultatiPetak[row][prva] + ",";
                        zaUpisivanje[20 + col] += rezultatiPetak[row][druga] + ",";
                        zaUpisivanje[30 + col] += rezultatiPetak[row][treca] + ",";
                        zaUpisivanje[40 + col] += rezultatiPetak[row][cetvrta] + ",";
                        zaUpisivanje[50 + col] += rezultatiPetak[row][peta] + ",";
                        zaUpisivanje[60 + col] += rezultatiPetak[row][sesta] + ",";
                    }
                }
            }

            // linija tabele je jedan element u nizu stringova
            // dodaj ostalo i lagano

            string path = Path.GetFullPath("Raspored.csv");
            await File.WriteAllLinesAsync(path, zaUpisivanje);
        }
    }

}


