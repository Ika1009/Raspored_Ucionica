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
        public List<List<string>> rezultatiPonedeljak;
        public List<List<string>> RezultatiPonedeljak 
        { 
            get => rezultatiPonedeljak; 
            set => rezultatiPonedeljak = value; 
        }
        public MainPageViewModel()
        {
            rezultatiPonedeljak = new()
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
            NapraviRaspored();
        }
        public void SpajanjeOdeljenja(string imeCasa, string imeUcionice, int i, int j) // kad se odeljenja spajaju zajedno
        {
            if(lista_odeljenja![i].Id_ucionice is not null)
                lista_ucionica![lista_odeljenja[i].Id_ucionice!.Value].Slobodna = true;// oslobadja se njihova ucionica
            

            Ucionica ucionica = lista_ucionica!.First(ucionica => ucionica.Ime_ucionice == imeUcionice);
            rezultatiPonedeljak[i][j] = ucionica.Ime_ucionice;
            ucionica.Slobodna = false; // ucionica ne moze da se koristi za druge predmete, ali moze za isti kad se spoji
        }
        public void DrziOdeljenje(int i, int j) // nalazi slobodnu ucionicu za oba odeljenja
        {
            if (lista_odeljenja![j].Id_ucionice is not null) // nije lutajuce
            {
                lista_ucionica![lista_odeljenja![j].Id_ucionice!.Value].Slobodna = false;
                rezultatiPonedeljak[i][j] = lista_ucionica[lista_odeljenja[j].Id_ucionice!.Value].Ime_ucionice;
            }
            else // lutajuce
            {
                Ucionica slobodna = lista_ucionica!.First(ucionica => ucionica.Slobodna == true && ucionica.Tip is null);
                rezultatiPonedeljak[i][j] = slobodna.Ime_ucionice;
                slobodna.Slobodna = false;
            }
        }
        public void OslobodiLutajuceUcionice()
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
        public void OslobodiUcionicu(int i, int j)
        {
            Ucionica ucionicaTemp = lista_ucionica!.First(ucionica => ucionica.Id == lista_odeljenja![j].Id_ucionice);
            ucionicaTemp.Slobodna = true;
            rezultatiPonedeljak[i][j] = ponedeljak!.RasporedCasova[i][j];

        }
        public void NapraviRaspored()
        {
            for (int i = 0; i < 32; i++) //za nulti cas
            {
                if (ponedeljak!.RasporedCasova[0][i] == "")
                    rezultatiPonedeljak[0][i] = "/";

                if (ponedeljak!.RasporedCasova[0][i] == "info")
                    rezultatiPonedeljak[0][i] = "info";

                if (ponedeljak.RasporedCasova[0][i] == "reg")
                    DrziOdeljenje(0, i);

                else if (ponedeljak.RasporedCasova[0][i] == "verska")
                    SpajanjeOdeljenja(ponedeljak.RasporedCasova[0][i], "biblioteka", 0, i);
            }

            for (int i = 1; i < 8; i++) // za ponedeljak
            {
                OslobodiLutajuceUcionice();
                for (var j = 0; j < 32; j++)
                {
                    if (ponedeljak!.RasporedCasova[i][j] == "" || ponedeljak.RasporedCasova[i][j] == "fv" || ponedeljak.RasporedCasova[i][j] == "info")
                    {
                        if (lista_odeljenja![j].Id_ucionice is not null) // nije lutajuce
                            OslobodiUcionicu(i, j);
                        if (ponedeljak!.RasporedCasova[i][j] == "info")
                            rezultatiPonedeljak[i][j] = "info";
                        if (ponedeljak!.RasporedCasova[i][j] == "fv")
                            rezultatiPonedeljak[i][j] = "fv";
                        else
                            rezultatiPonedeljak[i][j] = ".";
                    }
                    else if (ponedeljak!.RasporedCasova[i][j] == "reg")
                    {
                        DrziOdeljenje(i, j);
                    }
                    else if (ponedeljak!.RasporedCasova[i][j].Contains('/'))
                    {
                        string cas = ponedeljak!.RasporedCasova[i][j];
                        int brojac = cas.Count(c => c == '/');
                        for (int c = 0; c <= brojac; c++)
                        {
                            string trenutno = cas.Split("/")[c];
                            Ucionica biblioteka = lista_ucionica!.First(ucionica => ucionica.Ime_ucionice == "biblioteka");
                            if (trenutno == "reg" || trenutno == "n")
                            {
                                DrziOdeljenje(i, j);
                            }
                            if (trenutno == "i")
                                rezultatiPonedeljak[i][j] += " jezicka1";
                            if (trenutno == "r")
                                rezultatiPonedeljak[i][j] += " jezicka2";
                            if (trenutno == "f" && biblioteka.Slobodna == true)
                                rezultatiPonedeljak[i][j] += " biblioteka";
                            if (trenutno == "f" && biblioteka.Slobodna == false)
                            {
                                Ucionica slobodna = lista_ucionica!.First(ucionica => ucionica.Slobodna == true && ucionica.Tip is null);
                                rezultatiPonedeljak[i][j] += slobodna.Ime_ucionice;
                                slobodna.Slobodna = false;
                            }

                        }

                    }

                }
       
                    // fali za hemiju, jezike, gradjansko

                }
            }
        }
    
}
