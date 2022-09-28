using Raspored_Ucionica.Model;
using System.Linq;

namespace Raspored_Ucionica
{
    public class MainPageViewModel : SviPodaci
    {
        List<List<string>> rezultatiPonedeljak;
        public MainPageViewModel()
        {
            rezultatiPonedeljak = new();
        }
        public void spajanjeOdeljenja(string imeCasa, string imeUcionice, int i, int j) // kad se odeljenja spajaju zajedno
        {
            lista_ucionica[lista_odeljenja[i + 1].Id_ucionice.Value].Slobodna = true; // oslobadja se njihova ucionica
            int index = lista_ucionica.IndexOf(lista_ucionica.First(ucionica => ucionica.Ime_ucionice == imeUcionice));
            rezultatiPonedeljak[i][j] = lista_ucionica[index].Ime_ucionice;
            lista_ucionica[index].Slobodna = false; // ucionica ne moze da se koristi za druge predmete, ali moze za isti kad se spoji
        }
        public void drziOdeljenje(int i, int j)
        {
            if (lista_odeljenja[i+1].Id_ucionice is not null) // nije lutajuce
            {
                lista_ucionica[lista_odeljenja[i + 1].Id_ucionice.Value].Slobodna = false;
                rezultatiPonedeljak[i][j] = lista_ucionica[lista_odeljenja[i + 1].Id_ucionice.Value].Ime_ucionice;
            }
            else // lutajuce
            {

            }
        }
        public void NapraviRaspored()
        {
            for (int i = 0; i < 32; i++) //za nulti cas
            {
                if (Ponedeljak.RasporedCasova[0][i] == "")
                    continue;

                if(Ponedeljak.RasporedCasova[0][i] == "reg")
                {
                    drziOdeljenje(0, i);
                }

                else if (Ponedeljak.RasporedCasova[0][i] == "verska")
                {
                    spajanjeOdeljenja(Ponedeljak.RasporedCasova[0][i], "biblioteka", 0, i);
                } 
                else if(Ponedeljak.RasporedCasova[0][i] == "izborni")
                {

                }
            }
            for (int i = 1; i < 8; i++) // za ponedeljak
            {
                for(var j = 0; j < 32; j++)
                {


                }
            }
        }
    }
}
