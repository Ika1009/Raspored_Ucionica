using Raspored_Ucionica.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.IO;
using System;
using System.Reflection;

namespace Raspored_Ucionica.ViewModel
{
    public class MainPageViewModel : SviPodaci
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        public List<List<string>> rezultatiPonedeljak, rezultatiUtorak, rezultatiSreda, rezultatiCetvrtak, rezultatiPetak;
        public List<List<string>> Slobodne;
        public List<List<string>> ZaLutajuca;
        public List<string> Cos = new List<string>();
        public string[] Lutajuca;

        InputWindowViewModel inputViewModel;
        public MainPageViewModel(InputWindowViewModel inputVM)
        {
            inputViewModel = inputVM;

            List<Odeljenje> neizabrana = new List<Odeljenje>();
            int i = 0;
            foreach (string ime in inputVM.boxovi)
            {
                if (ime == "")
                {
                    neizabrana.Add(lista_odeljenja[i]);
                }
                else if (ime != "Лутајуће")
                {
                    Ucionica ucionica = lista_ucionica.Find(ucionica => ucionica.Ime_ucionice.ToUpper() == ime.ToUpper());
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
            new List<string>() {"", "", "", "", ""},
            new List<string>() {"", "", "", "", ""},
            new List<string>() {"", "", "", "", ""},
            new List<string>() {"", "", "", "", ""},
            new List<string>() {"", "", "", "", ""},
            new List<string>() {"", "", "", "", ""},
            new List<string>() { "", "", "", "", ""}
            };

            ZaLutajuca = new()
            {
            new List<string>() {"", "", "", "", "", "", "", ""},
            new List<string>() {"", "", "", "", "", "", "", ""},
            new List<string>() {"", "", "", "", "", "", "", ""},
            new List<string>() {"", "", "", "", "", "", "", ""},
            new List<string>() {"", "", "", "", "", "", "", "" }
            };


            rezultatiPonedeljak = NapraviRaspored(ponedeljak, Kponedeljak);
            rezultatiUtorak = NapraviRaspored(utorak, Kutorak);
            rezultatiSreda = NapraviRaspored(sreda, Ksreda);
            rezultatiCetvrtak = NapraviRaspored(cetvrtak, Kcetvrtak);
            rezultatiPetak = NapraviRaspored(petak, Kpetak);
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


            foreach (Ucionica ucionica in lista_ucionica)
            {
                if (ucionica.Slobodna == true && ucionica.Tip is null && ucionica.Ime_ucionice != "8" && ucionica.Velicina >= (Velicina_odeljenja - 1))
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
            Lutajuca = MiniFunkcijaZaProveru();
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
                if (!Da_Li_Se_Koristi_J2) { lista_ucionica!.First(ucionica => ucionica.Ime_ucionice == "7").Tip = null; }

            }
            string[] MiniFunkcijaZaProveru()
            {
                string[] lutajuca = new string[12];
                int br = 0;
                foreach (Odeljenje odeljenje in lista_odeljenja)
                {
                    if (odeljenje.Id_ucionice == null)
                    {
                        lutajuca[br] = odeljenje.Id.ToString();
                        br++;
                    }
                }
                lutajuca[7] = "7";
                return lutajuca;
            }
            void DrziLutajuce(int i, int j)
            {
                Odeljenje Temp = lista_odeljenja!.First(odeljenje => odeljenje.Id == j);

                // ovo slobodna sam stavio zbog optimizacije da ne pozivamo duplo funkciju -Ilija Doncic
                Ucionica? slobodna = lista_ucionica!.FirstOrDefault(ucionica => ucionica.Slobodna && ucionica.Tip is null && ucionica.Ime_ucionice != "8" && ucionica.Ime_ucionice != "7" && ucionica.Ime_ucionice != "svecana sala");
                //Prvo proverava da li je odeljenje lutajuće
                //(funkcija se koristi i za grupe)
                if (lista_odeljenja[j].Id_ucionice == null)
                {
                    int Dan = 0;
                    if (dan == ponedeljak)
                        Dan = 0;
                    else if (dan == utorak)
                        Dan = 1;
                    else if (dan == sreda)
                        Dan = 2;
                    else if (dan == cetvrtak)
                        Dan = 3;
                    else
                        Dan = 4;
                    //Prenos predstavlja sve učionice koje se mogu dati lutajućima
                    var prenos = ZaLutajuca[Dan][i].Split(',');
                    int duzina = ZaLutajuca[Dan][i].Count(x => x == ',');
                    string Ucionica;
                    Ucionica trazena = null; //učionica koju je odeljenje već koristilo
                    Ucionica Slobodna = null; //slobodna koja ne dira tražene učionice drugih
                    Ucionica Slobodna2 = null; //slobodna koja dira učionicu drugog, ali drugog izbora nema
                    for (int p = 0; p < duzina; p++)
                    {
                        Ucionica = prenos[p];
                        Ucionica ucionica = lista_ucionica.FirstOrDefault(ucionica => ucionica.Ime_ucionice == Ucionica);
                        if (ucionica.Slobodna == true && (i != 0 && rezultati[i][j] == ucionica.Ime_ucionice))
                        {
                            trazena = ucionica;
                            int indeks = Lutajuca.ToList().IndexOf(j.ToString()) + 6;
                            Lutajuca[indeks] = trazena.Ime_ucionice;
                            break;
                        }
                        else if (ucionica.Slobodna == true && (Lutajuca.ToList().LastIndexOf(j.ToString()) < 6))
                        {
                            Slobodna = ucionica;
                        }
                        else if (ucionica.Slobodna == true)
                        {
                            Slobodna2 = ucionica;
                        }
                    }

                    //Dodeljivanje - tamo gde je moguće
                    //Ako nije, idemo kroz sve slobodne (cena: nećemo ostati u istoj učionici)
                    if (trazena != null)
                    {
                        rezultati[i][j] += trazena.Ime_ucionice + "/";
                        trazena.Slobodna = false;
                    }
                    else if (Slobodna != null)
                    {
                        rezultati[i][j] += Slobodna.Ime_ucionice + "/";
                        Slobodna.Slobodna = false;
                    }
                    else if (Slobodna2 != null)
                    {
                        rezultati[i][j] += Slobodna2.Ime_ucionice + "/";
                        Slobodna2.Slobodna = false;
                    }
                    else
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
                        else if (slobodna is not null)
                        {
                            rezultati[i][j] += slobodna.Ime_ucionice + "/";
                            slobodna.Slobodna = false;
                        }
                        else if (lista_ucionica.FirstOrDefault(ucionica => ucionica.Slobodna == true && ucionica.Tip is null && ucionica.Ime_ucionice != "svecana sala" && ucionica.Velicina >= (Temp.Broj_ucenika - 3)) is not null)
                        {
                            slobodna = lista_ucionica!.First(ucionica => ucionica.Slobodna == true && ucionica.Tip is null && ucionica.Ime_ucionice != "svecana sala" && ucionica.Velicina >= (Temp.Broj_ucenika - 3));
                            // i ovaj else if promenio zbog optimizacije - Ilija Jedan Jedini 
                            rezultati[i][j] += slobodna.Ime_ucionice + "/";
                            slobodna.Slobodna = false;
                        }
                        else
                        {
                            slobodna = lista_ucionica!.First(ucionica => ucionica.Slobodna == true && ucionica.Ime_ucionice != "biblioteka" && ucionica.Ime_ucionice != "P4");
                            rezultati[i][j] += slobodna.Ime_ucionice + "/";
                            slobodna.Slobodna = false;
                        }
                    }
                }
                else
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
                    else if (slobodna is not null)
                    {
                        rezultati[i][j] += slobodna.Ime_ucionice + "/";
                        slobodna.Slobodna = false;
                    }
                    else if (lista_ucionica.FirstOrDefault(ucionica => ucionica.Slobodna == true && ucionica.Tip is null && ucionica.Ime_ucionice != "svecana sala" && ucionica.Velicina >= (Temp.Broj_ucenika - 3)) is not null)
                    {
                        slobodna = lista_ucionica!.First(ucionica => ucionica.Slobodna == true && ucionica.Tip is null && ucionica.Ime_ucionice != "svecana sala" && ucionica.Velicina >= (Temp.Broj_ucenika - 3));
                        // i ovaj else if promenio zbog optimizacije - Ilija Jedan Jedini 
                        rezultati[i][j] += slobodna.Ime_ucionice + "/";
                        slobodna.Slobodna = false;
                    }
                    else
                    {
                        slobodna = lista_ucionica!.First(ucionica => ucionica.Slobodna == true && ucionica.Ime_ucionice != "biblioteka" && ucionica.Ime_ucionice != "P4");
                        rezultati[i][j] += slobodna.Ime_ucionice + "/";
                        slobodna.Slobodna = false;
                    }

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
            void Nemacki(string imeCasa, ref bool imanjeCasa, ref string imeUcioniceZaNemacki, int i, int j)
            {
                if (!imanjeCasa)
                {
                    imeUcioniceZaNemacki = lista_ucionica!.Where(ucionica => ucionica.Slobodna == true && ucionica.Ime_ucionice != "P4" && ucionica.Ime_ucionice != "biblioteka").Last().Ime_ucionice;
                    // .last jer ne staju za sredu 2 cas, mozda da se napravi provera za da li moze druga ?
                    imanjeCasa = true;
                }
                SpajanjeOdeljenja(imeCasa, imeUcioniceZaNemacki, i, j);
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
                    if (ucionica.Slobodna == true && ucionica.Ime_ucionice != "biblioteka" && ucionica.Ime_ucionice != "P4")
                    {
                        Slobodne[i][k] += ucionica.Ime_ucionice + "/";
                    }
                    id--;
                }

            }
            void OdrediUcioniceZaLutajuca()
            {
                //Funkcija koja određuje slobodne, korisne učionice za dodeljivanje lutajućim odeljenjima
                //Kako lutajuća mogu da koriste samo učionice statičnih, a potrebne su im tokom više časova...
                //Najlogičnije je bilo gledati kada su učionice statičnih slobodne na duže vremena, dakle - info ili fv
                //Drugi dvočasi su ili reg, ili deljenje na grupe gde se koristi statična učionica odeljenja

                int Dan = 0;
                for (Dan = 0; Dan < 5; Dan++)
                {
                    for (int cas = 0; cas < 8; cas++)
                    {
                        //Automatski dodaje učionicu koja će uvek biti korišćena
                        //Naravno, to ne mora biti nijedna učionica
                        ZaLutajuca[Dan][cas] += "";
                    }
                }
                //Switch, zbog dana
                if (dan == ponedeljak)
                    Dan = 0;
                else if (dan == utorak)
                    Dan = 1;
                else if (dan == sreda)
                    Dan = 2;
                else if (dan == cetvrtak)
                    Dan = 3;
                else
                    Dan = 4;
                //Prolazak kroz raspored za svaki dan
                for (int cas = 0; cas < 8; cas++)
                {
                    for (int odeljenje = 0; odeljenje < 32; odeljenje++)
                    {
                        if ((dan!.RasporedCasova[cas][odeljenje] == "info" || dan!.RasporedCasova[cas][odeljenje] == "info")
                            && (((cas != 0 && (dan!.RasporedCasova[cas - 1][odeljenje] == "info" || dan!.RasporedCasova[cas - 1][odeljenje] == "fv"))
                            || (cas != 7 && (dan!.RasporedCasova[cas + 1][odeljenje] == "info" || dan!.RasporedCasova[cas + 1][odeljenje] == "fv")))))
                        {
                            if (lista_odeljenja[odeljenje].Id_ucionice != null)
                            {
                                Ucionica ucionica = lista_ucionica.First(ucionica => ucionica.Id == lista_odeljenja[odeljenje].Id_ucionice);
                                ZaLutajuca[Dan][cas] += ucionica.Ime_ucionice + ",";
                            }
                        }
                    }
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
                            for (int r = 0; r < 6; r++)
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
            OdrediUcioniceZaLutajuca();
            for (int i = 0; i < 32; i++) //za nulti cas
            {

                bool g1Ima = false, g2Ima = false, g3Ima = false, g4Ima = false, g5Ima = false;
                string imeUcioniceZaGradjansko1 = "", imeUcioniceZaGradjansko2 = "", imeUcioniceZaGradjansko3 = "", imeUcioniceZaGradjansko4 = "", imeUcioniceZaGradjansko5 = "";
                rezultati[0][i] = "";

                if (dan!.RasporedCasova[0][i] == "info")
                    rezultati[0][i] = "kab.";

                if (dan.RasporedCasova[0][i] == "reg" || dan.RasporedCasova[0][i] == "dreg")
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
                bool g1Ima = false, g2Ima = false, g3Ima = false, g4Ima = false, g5Ima = false, n1Ima = false;
                string imeUcioniceZaNemacki1 = "", imeUcioniceZaRuski = "", imeUcioniceZaFrancuski = "", imeUcioniceZaItalijanski = "", imeUcioniceZaGradjansko1 = "", imeUcioniceZaGradjansko2 = "", imeUcioniceZaGradjansko3 = "", imeUcioniceZaGradjansko4 = "", imeUcioniceZaGradjansko5 = "";
                bool imanjeCasaRuski = false, imanjeCasaItalijanski = false, imanjeCasaFrancuski = false;
                Random random = new();
                int rand = random.Next(0, 1);
                Ucionica jezicka2 = lista_ucionica!.First(ucionica => ucionica.Ime_ucionice == "7");
                Ucionica jezicka1 = lista_ucionica!.First(ucionica => ucionica.Ime_ucionice == "6");
                ZatvoriStaticneUcionice();
                OslobodiLutajuceUcionice();
                OslobodiSveUcionice(i);
                OslobodiJezickeUcionice(i);
                if (dan == ponedeljak && i < 5)
                {
                    Ucionica osmica = lista_ucionica!.First(ucionica => ucionica.Ime_ucionice == "8");
                    osmica.Slobodna = false;
                }
                if (dan == ponedeljak && i == 5)
                {
                    NadjiCos();
                }
                for (var j = 0; j < 32; j++)
                {
                    //lista_ucionica!.Last().Slobodna = true;
                    if (dan!.RasporedCasova[i][j] == "reg" || dan!.RasporedCasova[i][j] == "dreg")
                    {
                        // Da se doda kod za 3-2 da ne stavlja u 8
                        DrziOdeljenje(i, j);
                    }
                    else if (dan!.RasporedCasova[i][j] == "info")
                        rezultati[i][j] = "kab.";
                    else if (dan!.RasporedCasova[i][j] == "fv")
                        rezultati[i][j] = "fv";
                    else if (dan.RasporedCasova[i][j] == "verska")
                        SpajanjeOdeljenja(dan.RasporedCasova[i][j], "biblioteka", i, j);
                    else if (dan!.RasporedCasova[i][j].Contains('/'))
                    {

                        rezultati[i][j] = "";
                        string cas = dan!.RasporedCasova[i][j];
                        int brojac = cas.Count(c => c == '/');
                        bool provera = false, proveraN = false;
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

                            else if (trenutno == "reg" || trenutno == "dreg")
                            {
                                if (provera) // provara da li je vec uso ovde
                                    DrziLutajuce(i, j);
                                else
                                {
                                    DrziOdeljenje(i, j);
                                    provera = true;
                                }
                            }
                            else if (trenutno == "info")
                            {
                                if (string.IsNullOrEmpty(rezultati[i][j]))
                                    rezultati[i][j] = "kab/";
                                else
                                    rezultati[i][j] += "/kab/";
                            }
                            else if (trenutno == "/verska") // ne zauzme se biblioteka
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
                            else if (trenutno == "n")
                            {
                                if (proveraN) // provara da li je vec uso ovde
                                    DrziLutajuce(i, j);
                                else
                                {
                                    DrziOdeljenje(i, j);
                                    proveraN = true;
                                }
                            }
                            else if (trenutno == "n1")
                                Nemacki("n1", ref n1Ima, ref imeUcioniceZaNemacki1, i, j);
                            else if (trenutno == "i")
                            {
                                if (jezicka1.Slobodna)
                                {
                                    rezultati[i][j] += "/6/";
                                    jezicka1.Slobodna = false;
                                    imanjeCasaItalijanski = true;
                                    imeUcioniceZaItalijanski = "6";
                                }
                                else
                                {
                                    if (!imanjeCasaItalijanski)
                                    {
                                        imeUcioniceZaItalijanski = lista_ucionica!.Where(ucionica => ucionica.Slobodna == true && ucionica.Ime_ucionice != "P4").First().Ime_ucionice;
                                        imanjeCasaItalijanski = true;
                                    }
                                    SpajanjeOdeljenja("i", imeUcioniceZaItalijanski, i, j);
                                }

                            }
                            else if (trenutno == "f")
                            {
                                if (jezicka2.Slobodna && rand % 2 == 0) // random nekad upadne nekad ovde nekad za biblioteku
                                {
                                    rezultati[i][j] += "/7/";
                                    jezicka2.Slobodna = false;
                                    imanjeCasaFrancuski = true;
                                    imeUcioniceZaFrancuski = "7";
                                }
                                else if (biblioteka.Slobodna && rand % 2 == 1 && !imanjeCasaFrancuski)
                                {
                                    rezultati[i][j] += "/biblioteka/";
                                    biblioteka.Slobodna = false;
                                    imanjeCasaFrancuski = true;
                                    imeUcioniceZaFrancuski = "biblioteka";
                                }
                                else
                                {
                                    if (!imanjeCasaFrancuski)
                                    {
                                        imeUcioniceZaFrancuski = lista_ucionica!.Where(ucionica => ucionica.Slobodna == true && ucionica.Ime_ucionice != "P4").First().Ime_ucionice;
                                        imanjeCasaFrancuski = true;
                                    }
                                    SpajanjeOdeljenja("f", imeUcioniceZaFrancuski, i, j);
                                }
                            }
                            else if (trenutno == "r")
                            {
                                if (biblioteka.Slobodna && rand % 2 == 0) // random nekad upadne ovde nekad dole za 6
                                {
                                    rezultati[i][j] += "/biblioteka/";
                                    biblioteka.Slobodna = false;
                                    imanjeCasaRuski = true;
                                    imeUcioniceZaRuski = "biblioteka";
                                }
                                else if (jezicka2.Slobodna && rand % 2 == 1 && !imanjeCasaRuski)
                                {
                                    rezultati[i][j] += "/7/";
                                    jezicka2.Slobodna = false;
                                    imanjeCasaRuski = true;
                                    imeUcioniceZaRuski = "7";
                                }
                                else
                                {
                                    if (!imanjeCasaRuski)
                                    {
                                        imeUcioniceZaRuski = lista_ucionica!.Where(ucionica => ucionica.Slobodna == true && ucionica.Ime_ucionice != "P4").First().Ime_ucionice;
                                        imanjeCasaRuski = true;
                                    }
                                    SpajanjeOdeljenja("r", imeUcioniceZaRuski, i, j);
                                }
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
            int Dan = 0;
            if (dan == ponedeljak)
                Dan = 0;
            else if (dan == utorak)
                Dan = 1;
            else if (dan == sreda)
                Dan = 2;
            else if (dan == cetvrtak)
                Dan = 3;
            else
                Dan = 4;

            for (int i = 0; i < 8; i++)
            {
                string UcionicaFrancuski = "-";
                string UcionicaItalijanski = "-";
                string UcionicaRuski = "-";
                for (int j = 0; j < 32; j++)
                {                    
                    string[] raspored = dan.RasporedCasova[i][j].Split('/');
                    string[] rezultat = rezultati[i][j].Split('/');
                    string[] slobodne = Slobodne[i][Dan].Split('/');
                    for (int k = 0; k < raspored.Length; k++)
                    {
                        if (raspored[k] == "f")
                        {
                            if (rezultat[k] == "6" || rezultat[k] == "7" || rezultat[k] == "8" || rezultat[k] == "biblioteka")
                            {
                                if (UcionicaFrancuski == "-")
                                {
                                    for (int l = 0; l < slobodne.Length; l++)
                                    {

                                        if (slobodne[l] != "6" && slobodne[l] != "7" && slobodne[l] != "8" && slobodne[l] != "kab" && slobodne[l] != "biblioteka" && slobodne[l] != "" && slobodne[l] != " ")
                                        {

                                            string temp = slobodne[l];
                                            slobodne[l] = rezultat[k];
                                            rezultat[k] = temp;
                                            UcionicaFrancuski = rezultat[k];
                                            break;

                                        }
                                    }
                                }
                                else
                                {
                                    rezultat[k] = UcionicaFrancuski;
                                }
                            }
                        }
                        //if (raspored[k] == "i")
                        //{
                        //    //MessageBox.Show(rezultat[k] + " rezultat pocetno");
                        //    if (rezultat[k] == "6" || rezultat[k] == "7" || rezultat[k] == "8" || rezultat[k] == "biblioteka")
                        //    {
                        //        if (UcionicaItalijanski == "-")
                        //        {
                        //            for (int l = 0; l < slobodne.Length; l++)
                        //            {

                        //                if (slobodne[l] != "6" && slobodne[l] != "7" && slobodne[l] != "8" && slobodne[l] != "kab" && slobodne[l] != "biblioteka" && slobodne[l] != "" && slobodne[l] != " ")
                        //                {

                        //                    string temp = slobodne[l];
                        //                    slobodne[l] = rezultat[k];
                        //                    rezultat[k] = temp;
                        //                    UcionicaItalijanski = rezultat[k];
                        //                    break;

                        //                }
                        //            }
                        //        }
                        //        else
                        //        {
                        //            rezultat[k] = UcionicaItalijanski;
                        //        }
                        //    }
                        //}
                        //if (raspored[k] == "r")
                        //{
                        //    //MessageBox.Show(rezultat[k] + " rezultat pocetno");
                        //    if (rezultat[k] == "6" || rezultat[k] == "7" || rezultat[k] == "8" || rezultat[k] == "biblioteka")
                        //    {
                        //        if (UcionicaRuski == "-")
                        //        {
                        //            for (int l = 0; l < slobodne.Length; l++)
                        //            {

                        //                if (slobodne[l] != "6" && slobodne[l] != "7" && slobodne[l] != "8" && slobodne[l] != "kab" && slobodne[l] != "biblioteka" && slobodne[l] != "" && slobodne[l] != " ")
                        //                {

                        //                    string temp = slobodne[l];
                        //                    slobodne[l] = rezultat[k];
                        //                    rezultat[k] = temp;
                        //                    UcionicaRuski = rezultat[k];
                        //                    break;

                        //                }
                        //            }
                        //        }
                        //        else
                        //        {
                        //            rezultat[k] = UcionicaRuski;
                        //        }
                        //    }
                        //}

                    }
                    string konacno = "";
                    for(int t = 0; t<rezultat.Length; t++)
                    {
                        
                        if (t != rezultat.Length - 1)
                        {
                            konacno += rezultat[t] + "/";
                        }
                        else
                        {
                            konacno += rezultat[t];
                        }
                    }
                    string sloboda = "";
                    for (int t = 0; t < slobodne.Length; t++)
                    {

                        if (t != slobodne.Length - 1)
                        {
                            sloboda += slobodne[t] + "/";
                        }
                        else
                        {
                            sloboda += slobodne[t];
                        }
                    }
                    rezultati[i][j] = konacno;
                    Slobodne[i][Dan] = sloboda;
                }
            }

            return rezultati;
        }
        public static string Cirilica(string b)
        {
            if (b == "biblioteka") return "библ";
            if (b == "j1") return "7";
            if (b == "j2") return "8";
            if (b == "svecana sala") return "свечана сала";
            if (b == "Svecana") return "Свечана";
            char[] s = b.ToCharArray();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'q') s[i] = 'l';
                if (s[i] == 'w') s[i] = 'l';
                if (s[i] == 'e') s[i] = 'е';
                if (s[i] == 'r') s[i] = 'р';
                if (s[i] == 't') s[i] = 'т';
                if (s[i] == 'y') s[i] = 'l';
                if (s[i] == 'u') s[i] = 'у';
                if (s[i] == 'i') s[i] = 'и';
                if (s[i] == 'o') s[i] = 'о';
                if (s[i] == 'p') s[i] = 'п';
                if (s[i] == 'a') s[i] = 'а';
                if (s[i] == 's') s[i] = 'с';
                if (s[i] == 'd') s[i] = 'д';
                if (s[i] == 'f') s[i] = 'ф';
                if (s[i] == 'g') s[i] = 'г';
                if (s[i] == 'h') s[i] = 'х';
                if (s[i] == 'j') s[i] = 'ј';
                if (s[i] == 'k') s[i] = 'к';
                if (s[i] == 'l') s[i] = 'л';
                if (s[i] == 'z') s[i] = 'l';
                if (s[i] == 'x') s[i] = 'l';
                if (s[i] == 'c' && s[0] == 'с')
                {
                    s[i] = 'ч';
                }
                else if (s[i] == 'c') s[i] = 'ц';
                if (s[i] == 'v') s[i] = 'в';
                if (s[i] == 'b') s[i] = 'б';
                if (s[i] == 'n') s[i] = 'н';
                if (s[i] == 'm') s[i] = 'м';
                if (s[i] == 'P') s[i] = 'П';
                if (s[i] == 'M') s[i] = 'М';
                if (s[i] == 'S') s[i] = 'С';
            }
            b = "";
            for (int i = 0; i < s.Length; i++)
            {
                b += s[i];
            }
            return b;
        }
    }

}
