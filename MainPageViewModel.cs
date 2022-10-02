using Raspored_Ucionica.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Raspored_Ucionica
{

    public class MainPageViewModel : SviPodaci
    {
        // public event PropertyChangedEventHandler? PropertyChanged;
        public List<List<string>> rezultatiPonedeljak, rezultatiUtorak, rezultatiSreda, rezultatiCetvrtak, rezultatiPetak;
        public MainPageViewModel()
        {
            rezultatiPonedeljak = new();
            rezultatiUtorak = new();
            rezultatiSreda = new();
            rezultatiCetvrtak = new();
            rezultatiPetak = new();

            rezultatiPonedeljak = NapraviRaspored(ponedeljak);
            rezultatiUtorak = NapraviRaspored(utorak);
            rezultatiSreda = NapraviRaspored(ponedeljak);
            rezultatiCetvrtak = NapraviRaspored(utorak);
            rezultatiPetak = NapraviRaspored(ponedeljak);
        }
        public List<List<string>> NapraviRaspored(Raspored? dan)
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
                if (lista_odeljenja![i].Id_ucionice is not null)
                    lista_ucionica![lista_odeljenja[i].Id_ucionice!.Value].Slobodna = true;// oslobadja se njihova ucionica


                Ucionica ucionica = lista_ucionica!.First(ucionica => ucionica.Ime_ucionice == imeUcionice);
                rezultati[i][j] = ucionica.Ime_ucionice;
                ucionica.Slobodna = false; // ucionica ne moze da se koristi za druge predmete, ali moze za isti kad se spoji
            }
            void DrziOdeljenje(int i, int j) // nalazi slobodnu ucionicu za oba odeljenja
            {
                if (lista_odeljenja![j].Id_ucionice is not null) // nije lutajuce
                {
                    lista_ucionica![lista_odeljenja![j].Id_ucionice!.Value].Slobodna = false;
                    rezultati[i][j] = lista_ucionica[lista_odeljenja[j].Id_ucionice!.Value].Ime_ucionice;
                }
                else // lutajuce
                {
                    Ucionica slobodna = lista_ucionica!.First(ucionica => ucionica.Slobodna == true && ucionica.Tip is null);
                    rezultati[i][j] = slobodna.Ime_ucionice;
                    slobodna.Slobodna = false;
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
                bool oslobodi;
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
                    if (dan!.RasporedCasova[i][j] == "" || dan.RasporedCasova[i][j] == "fv" || dan.RasporedCasova[i][j] == "info" 
                        || dan!.RasporedCasova[i][j] == "hem/info" || dan!.RasporedCasova[i][j] == "info/hem")
                    {
                        if (lista_odeljenja![j].Id_ucionice is not null) // nije lutajuce
                            OslobodiUcionicu(i, j);
                    }
                }
            }

            for (int i = 0; i < 32; i++) //za nulti cas
            {

                if (dan!.RasporedCasova[0][i] == "")
                    rezultati[0][i] = "/";

                if (dan!.RasporedCasova[0][i] == "info")
                    rezultati[0][i] = "info";

                if (dan.RasporedCasova[0][i] == "reg")
                    DrziOdeljenje(0, i);

                else if (dan.RasporedCasova[0][i] == "verska")
                    SpajanjeOdeljenja(dan.RasporedCasova[0][i], "biblioteka", 0, i);
            }

            for (int i = 1; i < 8; i++) // za dan
            {
                OslobodiLutajuceUcionice();
                ZatvoriStaticneUcionice();
                OslobodiSveUcionice(i);
                for (var j = 0; j < 32; j++)
                {
                    if (dan!.RasporedCasova[i][j] == "reg")
                    {
                        DrziOdeljenje(i, j);
                    }
                    else if (dan!.RasporedCasova[i][j] == "info")
                        rezultati[i][j] = "info";
                    else if (dan!.RasporedCasova[i][j] == "fv")
                        rezultati[i][j] = "fv";
                    else if (dan!.RasporedCasova[i][j].Contains('/'))
                    {
                        rezultati[i][j] = "";
                        string cas = dan!.RasporedCasova[i][j];
                        int brojac = cas.Count(c => c == '/');
                        for (int c = 0; c <= brojac; c++)
                        {
                            bool provera = false;
                            string trenutno = cas.Split("/")[c];
                            Ucionica biblioteka = lista_ucionica!.First(ucionica => ucionica.Ime_ucionice == "biblioteka");
                            if (trenutno == "hem")
                                rezultati[i][j] += "hem kabinet";
                            else if (trenutno == "reg" || trenutno == "n")
                            {
                                if (provera) // provara da li je vec uso ovde
                                {
                                    Ucionica slobodna = lista_ucionica!.First(ucionica => ucionica.Slobodna == true && ucionica.Tip is null);
                                    rezultati[i][j] += slobodna.Ime_ucionice;
                                    slobodna.Slobodna = false;
                                }
                                provera = true;
                                DrziOdeljenje(i, j);
                            }
                            else if (trenutno == "info")
                                rezultati[i][j] += "/info";
                            else if (trenutno == "i")
                                rezultati[i][j] += "/jezicka1";
                            else if (trenutno == "r")
                                rezultati[i][j] += "/jezicka2";
                            else if (trenutno == "f" && biblioteka.Slobodna == true)
                                rezultati[i][j] += "/biblioteka";
                            else if (trenutno == "f" && biblioteka.Slobodna == false)
                            {
                                Ucionica slobodna = lista_ucionica!.First(ucionica => ucionica.Slobodna == true && ucionica.Tip is null);
                                rezultati[i][j] += slobodna.Ime_ucionice;
                                slobodna.Slobodna = false;
                            }

                        }

                    }
                    else
                        rezultati[i][j] = ".";

                }

                // fali za hemiju, jezike, gradjansko  
            }
            return rezultati;
        }
    }

}

    
