using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Xps.Packaging;
using Raspored_Ucionica.Model;
using Raspored_Ucionica.ViewModel;

namespace Raspored_Ucionica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainWindow(InputWindowViewModel inputViewModel)
        {
            InitializeComponent();
            MainPageViewModel viewModel = new MainPageViewModel(inputViewModel);
            SviPodaci sviPodaci = new SviPodaci();
            DataTable Grupe = new DataTable();
            DataTable Staticne = new DataTable();
            DataTable Slobodne = new DataTable();
            DataTable SvSala = new DataTable();
            DataTable Prvo1 = new DataTable();
            DataTable Prvo2 = new DataTable();
            DataTable Prvo3 = new DataTable();
            DataTable Drugo1 = new DataTable();
            DataTable Drugo2 = new DataTable();
            DataTable Drugo3 = new DataTable();
            int kolona = 5, redovi = 8, prva = 0, druga = 0, treca = 0, cetvrta = 0, peta = 0, sesta = 0;
            int nbColumns = 32;
            int za_labele_index = 0;
            for (int i = 0; i < nbColumns; i++)
            {
                if (viewModel.lista_odeljenja[i].Id_ucionice == null)
                {
                    if (za_labele_index == 0)
                    {
                        prva = viewModel.lista_odeljenja[i].Id;
                        za_labele_index++;
                    }
                    else if (za_labele_index == 1)
                    {
                        druga = viewModel.lista_odeljenja[i].Id;
                        za_labele_index++;

                    }
                    else if (za_labele_index == 2)
                    {
                        treca = viewModel.lista_odeljenja[i].Id;
                        za_labele_index++;
                    }
                    else if (za_labele_index == 3)
                    {
                        cetvrta = viewModel.lista_odeljenja[i].Id;
                        za_labele_index++;

                    }
                    else if (za_labele_index == 4)
                    {
                        peta = viewModel.lista_odeljenja[i].Id;
                        za_labele_index++;

                    }
                    else
                    {
                        sesta = viewModel.lista_odeljenja[i].Id;
                        za_labele_index++;


                    }
                }
            }
            prvaLabela.Content = MainPageViewModel.Cirilica(viewModel.Cos[prva].ToString());  
            drugaLabela.Content = MainPageViewModel.Cirilica(viewModel.Cos[druga].ToString());
            trecaLabela.Content = MainPageViewModel.Cirilica(viewModel.Cos[treca].ToString());
            cetvrtaLabela.Content = MainPageViewModel.Cirilica(viewModel.Cos[cetvrta].ToString());
            petaLabela.Content = MainPageViewModel.Cirilica(viewModel.Cos[peta].ToString());
            sestaLabela.Content = MainPageViewModel.Cirilica(viewModel.Cos[sesta].ToString());
            za_labele_index = 0;
            string neznam = " час";
            for (int i = 0; i < 8; i++)
            {
                if(i == 0)
                {
                    Staticne.Columns.Add("с");
                }
                else if(i == 1)
                {
                    Staticne.Columns.Add("т");
                }
                else if (i == 2)
                {
                    Staticne.Columns.Add("a");
                }
                else if (i == 3)
                {
                    Staticne.Columns.Add("Т");
                }
                else if (i == 4)
                {
                    Staticne.Columns.Add("i");
                }
                else if (i == 5)
                {
                    Staticne.Columns.Add("ч");
                }
                else if (i == 6)
                {
                    Staticne.Columns.Add("н");
                }
                else
                {
                    Staticne.Columns.Add("e");
                }
            }
            for (int i = 0; i < kolona; i++)
            {
                if (i == 0)
                {
                    Grupe.Columns.Add("Понедељак");
                    //SvSala.Columns.Add("Понедељак");
                    Slobodne.Columns.Add("Понедељак");
                    Prvo1.Columns.Add("Понедељак");
                    Prvo2.Columns.Add("Понедељак");
                    Prvo3.Columns.Add("Понедељак");
                    Drugo1.Columns.Add("Понедељак");
                    Drugo2.Columns.Add("Понедељак");
                    Drugo3.Columns.Add("Понедељак");
                }
                else if (i == 1)
                {
                    Grupe.Columns.Add("Уторак");
                    //SvSala.Columns.Add("Уторак");
                    Slobodne.Columns.Add("Уторак");
                    Prvo1.Columns.Add("Уторак");
                    Prvo2.Columns.Add("Уторак");
                    Prvo3.Columns.Add("Уторак");
                    Drugo1.Columns.Add("Уторак");
                    Drugo2.Columns.Add("Уторак");
                    Drugo3.Columns.Add("Уторак");
                }
                else if (i == 2)
                {
                    Grupe.Columns.Add("Среда");
                    //SvSala.Columns.Add("Среда");
                    Slobodne.Columns.Add("Среда");
                    Prvo1.Columns.Add("Среда");
                    Prvo2.Columns.Add("Среда");
                    Prvo3.Columns.Add("Среда");
                    Drugo1.Columns.Add("Среда");
                    Drugo2.Columns.Add("Среда");
                    Drugo3.Columns.Add("Среда");
                }
                else if (i == 3)
                {
                    Grupe.Columns.Add("Четвртак");
                    //SvSala.Columns.Add("Четвртак");
                    Slobodne.Columns.Add("Четвртак");
                    Prvo1.Columns.Add("Четвртак");
                    Prvo2.Columns.Add("Четвртак");
                    Prvo3.Columns.Add("Четвртак");
                    Drugo1.Columns.Add("Четвртак");
                    Drugo2.Columns.Add("Четвртак");
                    Drugo3.Columns.Add("Четвртак");
                }
                else
                {
                    Grupe.Columns.Add("Петак");
                    //SvSala.Columns.Add("Петак");
                    Slobodne.Columns.Add("Петак");
                    Prvo1.Columns.Add("Петак");
                    Prvo2.Columns.Add("Петак");
                    Prvo3.Columns.Add("Петак");
                    Drugo1.Columns.Add("Петак");
                    Drugo2.Columns.Add("Петак");
                    Drugo3.Columns.Add("Петак");
                }

            }
            for (int row = 0; row < redovi; row++)
            {
                SvSala.Columns.Add(row.ToString() + neznam);

                /*if (row == 0)
                {
                    Grupe.Columns.Add("ДАН");
                }
                else
                {
                    Grupe.Columns.Add(row.ToString() + neznam);
                }*/
            }
            for (int row = 0; row < kolona; row++)
            {
                DataRow dr = Grupe.NewRow();
                DataRow drr = SvSala.NewRow();
                for (int col = 0; col < redovi; col++)
                {

                    for (int i = 0; i < nbColumns; i++)
                    {
                        if (row == 0)
                        {
                            if (col == 0)
                            {
                                drr[col] = "Понедељак";
                            }
                            if (viewModel.rezultatiPonedeljak[col][i].Contains("svecana sala"))
                            {
                                drr[col] += viewModel.lista_odeljenja[i].Ime_odeljenja + " ";
                            }
                        }

                        else if (row == 1)
                        {
                            if (col == 0)
                            {
                                drr[col] = "Уторак";
                            }
                            
                            if (viewModel.rezultatiUtorak[col][i].Contains("svecana sala"))
                            {
                                drr[col] += viewModel.lista_odeljenja[i].Ime_odeljenja + " ";
                            }
                        }
                        else if (row == 2)
                        {
                            if (col == 0)
                            {
                                drr[col] = "Среда";
                            }
                            if (viewModel.rezultatiSreda[col][i].Contains("svecana sala"))
                            {
                                drr[col] += viewModel.lista_odeljenja[i].Ime_odeljenja + " ";
                            }
                        }
                        else if (row == 3)
                        {
                            if (col == 0)
                            {
                                drr[col] = "Четвртак";
                            }

                            if (viewModel.rezultatiCetvrtak[col][i].Contains("svecana sala"))
                            {
                                drr[col] += viewModel.lista_odeljenja[i].Ime_odeljenja + " ";
                            }
                        }
                        else
                        {
                            if (col == 0)
                            {
                                drr[col] = "Петак";
                            }
                            if (viewModel.rezultatiPetak[col][i].Contains("svecana sala"))
                            {
                                drr[col] += viewModel.lista_odeljenja[i].Ime_odeljenja + " ";
                            }
                        }
                    }

                }
                SvSala.Rows.Add(drr);
            }

            int x = 1, u = 1, s = 1, c = 1, pe = 1;
            for (int row = 0; row < 8; row++)
            {
                DataRow dr = Grupe.NewRow();
                for (int col = 0; col < 5; col++)
                {
                    if (col == 0 && x < 8)
                    {
                        for (int i = 0; i < 32; i++)
                        {
                            if (viewModel.ponedeljak.RasporedCasova[x][i].Contains("/"))
                            {
                                string[] ime = viewModel.ponedeljak.RasporedCasova[x][i].Split("/");
                                string[] niz = viewModel.rezultatiPonedeljak[x][i].Split("/");
                                dr[col] += viewModel.lista_odeljenja[i].Ime_odeljenja + ": ";
                                if (viewModel.ponedeljak.RasporedCasova[x][i] == "reg/reg")
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (j % 2 == 0)
                                        {
                                            dr[col] += "групаA - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                        else
                                        {
                                            dr[col] += "групаB - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                    }
                                    dr[col] += "\n";
                                }
                                else
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (ime[j] == "reg")
                                        {
                                            dr[col] += "група - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                        else
                                        {
                                            dr[col] += MainPageViewModel.Cirilica(ime[j]) + " - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                    }
                                    dr[col] += "\n";
                                }
                            }
                        }
                        x++;
                    }
                    else if(col == 1 && u < 8)
                    {
                        for (int i = 0; i < 32; i++)
                        {
                            if (viewModel.utorak.RasporedCasova[u][i].Contains("/"))
                            {
                                string[] ime = viewModel.utorak.RasporedCasova[u][i].Split("/");
                                string[] niz = viewModel.rezultatiUtorak[u][i].Split("/");
                                dr[col] += viewModel.lista_odeljenja[i].Ime_odeljenja + ": ";
                                if (viewModel.utorak.RasporedCasova[u][i] == "reg/reg")
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (j % 2 == 0)
                                        {
                                            dr[col] += "групаA - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                        else
                                        {
                                            dr[col] += "групаB - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                    }
                                    dr[col] += "\n";
                                }
                                else
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (ime[j] == "reg")
                                        {
                                            dr[col] += "група - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                        else
                                        {
                                            dr[col] += MainPageViewModel.Cirilica(ime[j]) + " - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                    }
                                    dr[col] += "\n";
                                }
                            }
                        }
                        u++;
                    }
                    else if (col == 2 && s < 8)
                    {
                        for (int i = 0; i < 32; i++)
                        {
                            if (viewModel.sreda.RasporedCasova[s][i].Contains("/"))
                            {
                                string[] ime = viewModel.sreda.RasporedCasova[s][i].Split("/");
                                string[] niz = viewModel.rezultatiSreda[s][i].Split("/");
                                dr[col] += viewModel.lista_odeljenja[i].Ime_odeljenja + ": ";
                                if (viewModel.sreda.RasporedCasova[s][i] == "reg/reg")
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (j % 2 == 0)
                                        {
                                            dr[col] += "групаA - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                        else
                                        {
                                            dr[col] += "групаB - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                    }
                                    dr[col] += "\n";
                                }
                                else
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (ime[j] == "reg")
                                        {
                                            dr[col] += "група - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                        else
                                        {
                                            dr[col] += MainPageViewModel.Cirilica(ime[j]) + " - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                    }
                                    dr[col] += "\n";
                                }
                            }
                        }
                        s++;
                    }
                    else if (col == 3 && c < 8)
                    {
                        for (int i = 0; i < 32; i++)
                        {
                            if (viewModel.cetvrtak.RasporedCasova[c][i].Contains("/"))
                            {
                                string[] ime = viewModel.cetvrtak.RasporedCasova[c][i].Split("/");
                                string[] niz = viewModel.rezultatiCetvrtak[c][i].Split("/");
                                dr[col] += viewModel.lista_odeljenja[i].Ime_odeljenja + ": ";
                                if (viewModel.cetvrtak.RasporedCasova[c][i] == "reg/reg")
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (j % 2 == 0)
                                        {
                                            dr[col] += "групаA - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                        else
                                        {
                                            dr[col] += "групаB - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                    }
                                    dr[col] += "\n";
                                }
                                else
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (ime[j] == "reg")
                                        {
                                            dr[col] += "група - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                        else
                                        {
                                            dr[col] += MainPageViewModel.Cirilica(ime[j]) + " - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                    }
                                    dr[col] += "\n";
                                }
                            }
                        }
                        c++;
                    }
                    else if (pe < 8)
                    {
                        for (int i = 0; i < 32; i++)
                        {
                            if (viewModel.petak.RasporedCasova[pe][i].Contains("/"))
                            {
                                string[] ime = viewModel.petak.RasporedCasova[pe][i].Split("/");
                                string[] niz = viewModel.rezultatiPetak[pe][i].Split("/");
                                dr[col] += viewModel.lista_odeljenja[i].Ime_odeljenja + ": ";
                                if (viewModel.petak.RasporedCasova[pe][i] == "reg/reg")
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (j % 2 == 0)
                                        {
                                            dr[col] += "групаA - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                        else
                                        {
                                            dr[col] += "групаB - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                    }
                                    dr[col] += "\n";
                                }
                                else
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (ime[j] == "reg")
                                        {
                                            dr[col] += "група - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                        else
                                        {
                                            dr[col] += MainPageViewModel.Cirilica(ime[j]) + " - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                    }
                                    dr[col] += "\n";
                                }
                            }
                        }
                        pe++;
                    }
                }
                Grupe.Rows.Add(dr);
            }
            
            /*for (int row = 0; row < kolona; row++)
            {
                DataRow dr = Grupe.NewRow();
                DataRow drr = SvSala.NewRow();
                for (int col = 0; col < redovi; col++)
                {

                    for (int i = 0; i < nbColumns; i++)
                    {
                        if (row == 0)
                        {
                            if (col == 0)
                            {
                                dr[col] = "Понедељак";
                                drr[col] = "Понедељак";
                            }
                            if (viewModel.ponedeljak.RasporedCasova[col][i].Contains("/"))
                            {
                                string[] ime = viewModel.ponedeljak.RasporedCasova[col][i].Split("/");
                                string[] niz = viewModel.rezultatiPonedeljak[col][i].Split("/");
                                dr[col] += viewModel.lista_odeljenja[i].Ime_odeljenja + ": ";
                                if (viewModel.ponedeljak.RasporedCasova[col][i] == "reg/reg")
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (j % 2 == 0)
                                        {
                                            dr[col] += "групаA - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                        else
                                        {
                                            dr[col] += "групаB - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                    }
                                    
                                    if (ime.Length > niz.Length)
                                    {
                                        for(int p = 0; p < ime.Length - niz.Length; p++)
                                        {
                                            dr[col] += "nema, ";
                                        }

                                    }
                                    dr[col] += "\n";
                                }
                                else
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (ime[j] == "reg")
                                        {
                                            dr[col] += "група - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                        else
                                        {
                                            dr[col] += MainPageViewModel.Cirilica(ime[j]) + " - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                    }
                                    if (ime.Length > niz.Length)
                                    {
                                        for (int p = 0; p < ime.Length - niz.Length; p++)
                                        {
                                            dr[col] += "nema, ";
                                        }

                                    }
                                    dr[col] += "\n";
                                }
                            }


                            if (viewModel.rezultatiPonedeljak[col][i].Contains("svecana sala"))
                            {
                                drr[col] += viewModel.lista_odeljenja[i].Ime_odeljenja;
                            }
                        }

                        else if (row == 1)
                        {
                            if (col == 0)
                            {
                                dr[col] = "Уторак";
                                drr[col] = "Уторак";
                            }
                            if (viewModel.utorak.RasporedCasova[col][i].Contains("/"))
                            {
                                string[] ime = viewModel.utorak.RasporedCasova[col][i].Split("/");
                                string[] niz = viewModel.rezultatiUtorak[col][i].Split("/");
                                dr[col] += viewModel.lista_odeljenja[i].Ime_odeljenja + ": ";
                                if (viewModel.utorak.RasporedCasova[col][i] == "reg/reg")
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (j % 2 == 0)
                                        {
                                            dr[col] += "групаA - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                        else
                                        {
                                            dr[col] += "групаB - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                    }
                                    if (ime.Length > niz.Length)
                                    {
                                        for (int p = 0; p < ime.Length - niz.Length; p++)
                                        {
                                            dr[col] += "nema, ";
                                        }

                                    }
                                    dr[col] += "\n";
                                }
                                else
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (ime[j] == "reg")
                                        {
                                            dr[col] += "група - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                        else
                                        {
                                            dr[col] += MainPageViewModel.Cirilica(ime[j]) + " - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                    }
                                    if (ime.Length > niz.Length)
                                    {
                                        for (int p = 0; p < ime.Length - niz.Length; p++)
                                        {
                                            dr[col] += "nema, ";
                                        }

                                    }
                                    dr[col] += "\n";
                                }

                            }
                            if (viewModel.rezultatiUtorak[col][i].Contains("svecana sala"))
                            {
                                drr[col] += viewModel.lista_odeljenja[i].Ime_odeljenja;
                            }
                        }
                        else if (row == 2)
                        {
                            if (col == 0)
                            {
                                dr[col] = "Среда";
                                drr[col] = "Среда";
                            }
                            if (viewModel.sreda.RasporedCasova[col][i].Contains("/"))
                            {
                                string[] ime = viewModel.sreda.RasporedCasova[col][i].Split("/");
                                string[] niz = viewModel.rezultatiSreda[col][i].Split("/");
                                dr[col] += viewModel.lista_odeljenja[i].Ime_odeljenja + ": ";
                                if (viewModel.sreda.RasporedCasova[col][i] == "reg/reg")
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (j % 2 == 0)
                                        {
                                            dr[col] += "групаA - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                        else
                                        {
                                            dr[col] += "групаB - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                    }
                                    if (ime.Length > niz.Length)
                                    {
                                        for (int p = 0; p < ime.Length - niz.Length; p++)
                                        {
                                            dr[col] += "nema, ";
                                        }

                                    }
                                    dr[col] += "\n";
                                }
                                else
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (ime[j] == "reg")
                                        {
                                            dr[col] += "група - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                        else
                                        {
                                            dr[col] += MainPageViewModel.Cirilica(ime[j]) + " - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                    }
                                    if (ime.Length > niz.Length)
                                    {
                                        for (int p = 0; p < ime.Length - niz.Length; p++)
                                        {
                                            dr[col] += "nema, ";
                                        }

                                    }
                                    dr[col] += "\n";
                                }
                            }
                            if (viewModel.rezultatiSreda[col][i].Contains("svecana sala"))
                            {
                                drr[col] += viewModel.lista_odeljenja[i].Ime_odeljenja;
                            }
                        }
                        else if (row == 3)
                        {
                            if (col == 0)
                            {
                                dr[col] = "Четвртак";
                                drr[col] = "Четвртак";
                            }

                            if (viewModel.cetvrtak.RasporedCasova[col][i].Contains("/"))
                            {
                                string[] ime = viewModel.cetvrtak.RasporedCasova[col][i].Split("/");
                                string[] niz = viewModel.rezultatiCetvrtak[col][i].Split("/");
                                dr[col] += viewModel.lista_odeljenja[i].Ime_odeljenja + ": ";
                                if (viewModel.cetvrtak.RasporedCasova[col][i] == "reg/reg")
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (j % 2 == 0)
                                        {
                                            dr[col] += "групаA - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                        else
                                        {
                                            dr[col] += "групаB - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                    }
                                    if (ime.Length > niz.Length)
                                    {
                                        for (int p = 0; p < ime.Length - niz.Length; p++)
                                        {
                                            dr[col] += "nema, ";
                                        }

                                    }
                                    dr[col] += "\n";
                                }
                                else
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (ime[j] == "reg")
                                        {
                                            dr[col] += "група - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                        else
                                        {
                                            dr[col] += MainPageViewModel.Cirilica(ime[j]) + " - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                    }
                                    if (ime.Length > niz.Length)
                                    {
                                        for (int p = 0; p < ime.Length - niz.Length; p++)
                                        {
                                            dr[col] += "nema, ";
                                        }

                                    }
                                    dr[col] += "\n";
                                }
                            }
                            if (viewModel.rezultatiCetvrtak[col][i].Contains("svecana sala"))
                            {
                                drr[col] += viewModel.lista_odeljenja[i].Ime_odeljenja;
                            }
                        }
                        else
                        {
                            if (col == 0)
                            {
                                dr[col] = "Петак";
                                drr[col] = "Петак";
                            }
                            if (viewModel.petak.RasporedCasova[col][i].Contains("/"))
                            {
                                string[] ime = viewModel.petak.RasporedCasova[col][i].Split("/");
                                string[] niz = viewModel.rezultatiPetak[col][i].Split("/");
                                dr[col] += viewModel.lista_odeljenja[i].Ime_odeljenja + ": ";
                                if (viewModel.petak.RasporedCasova[col][i] == "reg/reg")
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (j % 2 == 0)
                                        {
                                            dr[col] += "групаA - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                        else
                                        {
                                            dr[col] += "групаB - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                    }
                                    if (ime.Length > niz.Length)
                                    {
                                        for (int p = 0; p < ime.Length - niz.Length; p++)
                                        {
                                            dr[col] += "nema, ";
                                        }

                                    }
                                    dr[col] += "\n";
                                }
                                else
                                {
                                    for (int j = 0; j < niz.Length; j++)
                                    {
                                        if (ime[j] == "reg")
                                        {
                                            dr[col] += "група - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                        else
                                        {
                                            dr[col] += MainPageViewModel.Cirilica(ime[j]) + " - " + MainPageViewModel.Cirilica(niz[j]) + ", ";
                                        }
                                    }
                                    if (ime.Length > niz.Length)
                                    {
                                        for (int p = 0; p < ime.Length - niz.Length; p++)
                                        {
                                            dr[col] += "nema, ";
                                        }

                                    }
                                    dr[col] += "\n";
                                }
                            }
                            if (viewModel.rezultatiPetak[col][i].Contains("svecana sala"))
                            {
                                drr[col] += viewModel.lista_odeljenja[i].Ime_odeljenja;
                            }
                        }
                    }

                }
                SvSala.Rows.Add(drr);
                Grupe.Rows.Add(dr);
            }*/
            
            
            
            
            
            
            
            
            

            for (int row = 0; row < redovi; row++)
            {
                DataRow dr = Slobodne.NewRow();

                DataRow prvo1 = Prvo1.NewRow();
                DataRow prvo2 = Prvo2.NewRow();
                DataRow prvo3 = Prvo3.NewRow();
                DataRow drugo1 = Drugo1.NewRow();
                DataRow drugo2 = Drugo2.NewRow();
                DataRow drugo3 = Drugo3.NewRow();
                for (int col = 0; col < kolona; col++)
                {
                    dr[col] = viewModel.Slobodne[row][col];
                    if (col == 0)
                    {
                        prvo1[col] = MainPageViewModel.Cirilica(viewModel.rezultatiPonedeljak[row][prva]);
                        prvo2[col] = MainPageViewModel.Cirilica(viewModel.rezultatiPonedeljak[row][druga]);
                        prvo3[col] = MainPageViewModel.Cirilica(viewModel.rezultatiPonedeljak[row][treca]);
                        drugo1[col] = MainPageViewModel.Cirilica(viewModel.rezultatiPonedeljak[row][cetvrta]);
                        drugo2[col] = MainPageViewModel.Cirilica(viewModel.rezultatiPonedeljak[row][peta]);
                        drugo3[col] = MainPageViewModel.Cirilica(viewModel.rezultatiPonedeljak[row][sesta]);
                    }
                    else if (col == 1)
                    {
                        prvo1[col] = MainPageViewModel.Cirilica(viewModel.rezultatiUtorak[row][prva]);
                        prvo2[col] = MainPageViewModel.Cirilica(viewModel.rezultatiUtorak[row][druga]);
                        prvo3[col] = MainPageViewModel.Cirilica(viewModel.rezultatiUtorak[row][treca]);
                        drugo1[col] = MainPageViewModel.Cirilica(viewModel.rezultatiUtorak[row][cetvrta]);
                        drugo2[col] = MainPageViewModel.Cirilica(viewModel.rezultatiUtorak[row][peta]);
                        drugo3[col] = MainPageViewModel.Cirilica(viewModel.rezultatiUtorak[row][sesta]);
                    }
                    else if (col == 2)
                    {
                        prvo1[col] = MainPageViewModel.Cirilica(viewModel.rezultatiSreda[row][prva]);
                        prvo2[col] = MainPageViewModel.Cirilica(viewModel.rezultatiSreda[row][druga]);
                        prvo3[col] = MainPageViewModel.Cirilica(viewModel.rezultatiSreda[row][treca]);
                        drugo1[col] = MainPageViewModel.Cirilica(viewModel.rezultatiSreda[row][cetvrta]);
                        drugo2[col] = MainPageViewModel.Cirilica(viewModel.rezultatiSreda[row][peta]);
                        drugo3[col] = MainPageViewModel.Cirilica(viewModel.rezultatiSreda[row][sesta]);
                    }
                    else if (col == 3)
                    {
                        prvo1[col] = MainPageViewModel.Cirilica(viewModel.rezultatiCetvrtak[row][prva]);
                        prvo2[col] = MainPageViewModel.Cirilica(viewModel.rezultatiCetvrtak[row][druga]);
                        prvo3[col] = MainPageViewModel.Cirilica(viewModel.rezultatiCetvrtak[row][treca]);
                        drugo1[col] = MainPageViewModel.Cirilica(viewModel.rezultatiCetvrtak[row][cetvrta]);
                        drugo2[col] = MainPageViewModel.Cirilica(viewModel.rezultatiCetvrtak[row][peta]);
                        drugo3[col] = MainPageViewModel.Cirilica(viewModel.rezultatiCetvrtak[row][sesta]);
                    }
                    else
                    {
                        prvo1[col] = MainPageViewModel.Cirilica(viewModel.rezultatiPetak[row][prva]);
                        prvo2[col] = MainPageViewModel.Cirilica(viewModel.rezultatiPetak[row][druga]);
                        prvo3[col] = MainPageViewModel.Cirilica(viewModel.rezultatiPetak[row][treca]);
                        drugo1[col] = MainPageViewModel.Cirilica(viewModel.rezultatiPetak[row][cetvrta]);
                        drugo2[col] = MainPageViewModel.Cirilica(viewModel.rezultatiPetak[row][peta]);
                        drugo3[col] = MainPageViewModel.Cirilica(viewModel.rezultatiPetak[row][sesta]);
                    }
                }
                Slobodne.Rows.Add(dr);

                Prvo1.Rows.Add(prvo1);
                Prvo2.Rows.Add(prvo2);
                Prvo3.Rows.Add(prvo3);
                Drugo1.Rows.Add(drugo1);
                Drugo2.Rows.Add(drugo2);
                Drugo3.Rows.Add(drugo3);
            }

            p1.ItemsSource = Prvo1.DefaultView;
            p2.ItemsSource = Prvo2.DefaultView;
            p3.ItemsSource = Prvo3.DefaultView;
            d1.ItemsSource = Drugo1.DefaultView;
            d2.ItemsSource = Drugo2.DefaultView;
            d3.ItemsSource = Drugo3.DefaultView;
            rezultatiSv.ItemsSource = SvSala.DefaultView;
            rezultatiSlob.ItemsSource = Slobodne.DefaultView;
            rezultatiGrupe.ItemsSource = Grupe.DefaultView;



            int z = 0, y = 0;
            za_labele_index = 0;
            for (int i = 0; i < 8; i++)
            {
                y = 0 + za_labele_index;
                z = 0 + za_labele_index;
                za_labele_index++;
                DataRow stati = Staticne.NewRow();
                for (int j = 0; j < 8; j++)
                {
                    if (j % 2 == 0)
                    {
                        stati[j] = viewModel.lista_odeljenja[z].Ime_odeljenja.ToString();
                        z += 8;
                    }
                    else if (j % 2 != 0) 
                    {
                        if (viewModel.lista_odeljenja[y].Id_ucionice == null)
                        {
                            stati[j] = "Лутајуће";
                        }
                        else
                        {
                            stati[j] += MainPageViewModel.Cirilica(viewModel.lista_ucionica.First(ucionica => ucionica.Id == viewModel.lista_odeljenja[y].Id_ucionice).Ime_ucionice);
                        }
                        y += 8;
                    }

                }
                Staticne.Rows.Add(stati);
            }
            staticne.ItemsSource = Staticne.DefaultView;


            za_labele_index = 0;
            for (int i = 0; i < nbColumns; i++)
            {
                if (viewModel.lista_odeljenja[i].Id_ucionice == null)
                {
                    if (za_labele_index == 0)
                    {
                        prvaLabel.Content = viewModel.lista_odeljenja[i].Ime_odeljenja.ToString();
                        za_labele_index++;
                    }
                    else if (za_labele_index == 1)
                    {
                        drugaLabel.Content = viewModel.lista_odeljenja[i].Ime_odeljenja.ToString();
                        za_labele_index++;
                    }
                    else if (za_labele_index == 2)
                    {
                        trecaLabel.Content = viewModel.lista_odeljenja[i].Ime_odeljenja.ToString();
                        za_labele_index++;
                    }
                    else if (za_labele_index == 3)
                    {
                        cetvrtaLabel.Content = viewModel.lista_odeljenja[i].Ime_odeljenja.ToString();
                        za_labele_index++;
                    }
                    else if (za_labele_index == 4)
                    {
                        petaLabel.Content = viewModel.lista_odeljenja[i].Ime_odeljenja.ToString();
                        za_labele_index++;
                    }
                    else
                    {
                        sestaLabel.Content = viewModel.lista_odeljenja[i].Ime_odeljenja.ToString();
                        za_labele_index++;
                    }
                }

            }


        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
