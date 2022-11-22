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
            Raspored raspored;
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
            int nbRows = 8;
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
            prvaLabela.Content = viewModel.Cos[prva].ToString();
            drugaLabela.Content = viewModel.Cos[druga].ToString();
            trecaLabela.Content = viewModel.Cos[treca].ToString();
            cetvrtaLabela.Content = viewModel.Cos[cetvrta].ToString();
            petaLabela.Content = viewModel.Cos[peta].ToString();
            sestaLabela.Content = viewModel.Cos[sesta].ToString();
            za_labele_index = 0;
            string neznam = " cas";
            for (int row = 0; row < redovi; row++)
            {
                if (row == 0)
                {
                    SvSala.Columns.Add("DAN");
                }
                else
                {
                    SvSala.Columns.Add(row.ToString() + neznam);
                }

                if(row == 0)
                {
                    Grupe.Columns.Add("DAN");
                }
                else
                {
                    Grupe.Columns.Add(row.ToString() + neznam);
                }
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
                                dr[col] = "Ponedeljak";
                                drr[col] = "Ponedeljak";
                            }
                            if (viewModel.rezultatiPonedeljak[col][i].Contains("/"))
                            {
                                string[] ime = viewModel.ponedeljak.RasporedCasova[col][i].Split("/");
                                string[] niz = viewModel.rezultatiPonedeljak[col][i].Split("/");
                                dr[col] += viewModel.lista_odeljenja[i].Ime_odeljenja + ": ";
                                if (viewModel.ponedeljak.RasporedCasova[col][i] == "reg/reg")
                                {
                                    for(int j = 0; j < niz.Length; j++)
                                    {   
                                        if(j % 2 == 0) 
                                        {
                                            dr[col] += "grupaA - " + niz[j] + ", ";
                                        }
                                        else{
                                            dr[col] += "grupaB - " + niz[j] + ", ";
                                        }
                                    }
                                    dr[col] += "\n";
                                }
                                else 
                                {
                                    for(int j = 0; j < niz.Length; j++)
                                    {   
                                        if(ime[j] == "reg") 
                                        {
                                            dr[col] += "grupa - " + niz[j] + ", ";
                                        }
                                        else{
                                            dr[col] += ime[j] + " - " + niz[j] + ", ";
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
                                dr[col] = "Utorak";
                                drr[col] = "Utorak";
                            }
                            if (viewModel.rezultatiUtorak[col][i].Contains("/"))
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
                                            dr[col] += "grupaA - " + niz[j] + ", ";
                                        }
                                        else
                                        {
                                            dr[col] += "grupaB - " + niz[j] + ", ";
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
                                            dr[col] += "grupa - " + niz[j] + ", ";
                                        }
                                        else
                                        {
                                            dr[col] += ime[j] + " - " + niz[j] + ", ";
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
                                dr[col] = "Sreda";
                                drr[col] = "Sreda";
                            }
                            if (viewModel.rezultatiSreda[col][i].Contains("/"))
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
                                            dr[col] += "grupaA - " + niz[j] + ", ";
                                        }
                                        else
                                        {
                                            dr[col] += "grupaB - " + niz[j] + ", ";
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
                                            dr[col] += "grupa - " + niz[j] + ", ";
                                        }
                                        else
                                        {
                                            dr[col] += ime[j] + " - " + niz[j] + ", ";
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
                                dr[col] = "Cetvrtak";
                                drr[col] = "Cetvrtak";
                            }

                            if (viewModel.rezultatiCetvrtak[col][i].Contains("/"))
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
                                            dr[col] += "grupaA - " + niz[j] + ", ";
                                        }
                                        else
                                        {
                                            dr[col] += "grupaB - " + niz[j] + ", ";
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
                                            dr[col] += "grupa - " + niz[j] + ", ";
                                        }
                                        else
                                        {
                                            dr[col] += ime[j] + " - " + niz[j] + ", ";
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
                                dr[col] = "Petak";
                                drr[col] = "Petak";
                            }
                            if (viewModel.rezultatiPetak[col][i].Contains("/"))
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
                                            dr[col] += "grupaA - " + niz[j] + ", ";
                                        }
                                        else
                                        {
                                            dr[col] += "grupaB - " + niz[j] + ", ";
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
                                            dr[col] += "grupa - " + niz[j] + ", ";
                                        }
                                        else
                                        {
                                            dr[col] += ime[j] + " - " + niz[j] + ", ";
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
            }
            for (int i = 0; i < kolona; i++)
            {
                if (i == 0)
                {
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
                        prvo1[col] = viewModel.rezultatiPonedeljak[row][prva];
                        prvo2[col] = viewModel.rezultatiPonedeljak[row][druga];
                        prvo3[col] = viewModel.rezultatiPonedeljak[row][treca];
                        drugo1[col] = viewModel.rezultatiPonedeljak[row][cetvrta];
                        drugo2[col] = viewModel.rezultatiPonedeljak[row][peta];
                        drugo3[col] = viewModel.rezultatiPonedeljak[row][sesta];
                    }
                    else if (col == 1)
                    {
                        prvo1[col] = viewModel.rezultatiUtorak[row][prva];
                        prvo2[col] = viewModel.rezultatiUtorak[row][druga];
                        prvo3[col] = viewModel.rezultatiUtorak[row][treca];
                        drugo1[col] = viewModel.rezultatiUtorak[row][cetvrta];
                        drugo2[col] = viewModel.rezultatiUtorak[row][peta];
                        drugo3[col] = viewModel.rezultatiUtorak[row][sesta];
                    }
                    else if (col == 2)
                    {
                        prvo1[col] = viewModel.rezultatiSreda[row][prva];
                        prvo2[col] = viewModel.rezultatiSreda[row][druga];
                        prvo3[col] = viewModel.rezultatiSreda[row][treca];
                        drugo1[col] = viewModel.rezultatiSreda[row][cetvrta];
                        drugo2[col] = viewModel.rezultatiSreda[row][peta];
                        drugo3[col] = viewModel.rezultatiSreda[row][sesta];
                    }
                    else if (col == 3)
                    {
                        prvo1[col] = viewModel.rezultatiCetvrtak[row][prva];
                        prvo2[col] = viewModel.rezultatiCetvrtak[row][druga];
                        prvo3[col] = viewModel.rezultatiCetvrtak[row][treca];
                        drugo1[col] = viewModel.rezultatiCetvrtak[row][cetvrta];
                        drugo2[col] = viewModel.rezultatiCetvrtak[row][peta];
                        drugo3[col] = viewModel.rezultatiCetvrtak[row][sesta];
                    }
                    else
                    {
                        prvo1[col] = viewModel.rezultatiPetak[row][prva];
                        prvo2[col] = viewModel.rezultatiPetak[row][druga];
                        prvo3[col] = viewModel.rezultatiPetak[row][treca];
                        drugo1[col] = viewModel.rezultatiPetak[row][cetvrta];
                        drugo2[col] = viewModel.rezultatiPetak[row][peta];
                        drugo3[col] = viewModel.rezultatiPetak[row][sesta];
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


            DataRow stati = Staticne.NewRow();
            //ispis za rezultate
            za_labele_index = 0;
            for (int i = 0; i < nbColumns; i++)
            {
                Staticne.Columns.Add(viewModel.lista_odeljenja[i].Ime_odeljenja.ToString());
                if (viewModel.lista_odeljenja[i].Id_ucionice == null)
                {
                    stati[i] += "Lutajuce";
                    if(za_labele_index == 0)
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
                else
                {
                    stati[i] += viewModel.lista_ucionica.First(ucionica => ucionica.Id == viewModel.lista_odeljenja[i].Id_ucionice).Ime_ucionice;
                }

            }
            Staticne.Rows.Add(stati);
            staticne.ItemsSource = Staticne.DefaultView;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InputWindow window1 = new InputWindow();
            window1.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window1.Show();
            Close();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            var a = this.Width;
            //TestPage fixedPage = new TestPage();
            btn.Visibility = Visibility.Collapsed;
            FixedDocument fixedDoc = new FixedDocument();
            PageContent pageContent = new PageContent();
            FixedPage fixedPage = new FixedPage();



            PrintDialog printDlg = new PrintDialog();
            Size pageSize = new Size(printDlg.PrintableAreaWidth, printDlg.PrintableAreaHeight - 100);


            var visual = ((System.Windows.Controls.Panel)this.Content).Children[0] as UIElement;
            ((System.Windows.Controls.Panel)this.Content).Children.Remove(visual);
            fixedPage.Children.Add(visual);

            ((System.Windows.Markup.IAddChild)pageContent).AddChild(fixedPage);

            fixedDoc.Pages.Add(pageContent);


            // write to PDF file
            string tempFilename = "temp.xps";
            File.Delete(tempFilename);
            XpsDocument xpsd = new XpsDocument(tempFilename, FileAccess.ReadWrite);
            System.Windows.Xps.XpsDocumentWriter xw = XpsDocument.CreateXpsDocumentWriter(xpsd);
            xw.Write(fixedDoc);
            xpsd.Close();
            //PdfSharp.Xps.XpsConverter.Convert(tempFilename, "D:/testing.pdf", 1);
            Process.Start("D:/testing.pdf");

            btn.Visibility = Visibility.Visible;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
