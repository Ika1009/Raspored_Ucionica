using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
                DataTable Staticne = new DataTable();
                DataTable Slobodne = new DataTable();
                DataTable SvSala = new DataTable();
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                DataTable dt4 = new DataTable();
                DataTable dt5 = new DataTable();
                DataTable Prvo1 = new DataTable();
                DataTable Prvo2 = new DataTable();
                DataTable Prvo3 = new DataTable();
                DataTable Drugo1 = new DataTable();
                DataTable Drugo2 = new DataTable();
                DataTable Drugo3 = new DataTable();
                int kolona = 5, redovi = 8;
                int nbColumns = 32;
                int nbRows = 8;
                for (int row = 0; row < redovi; row++)
                {
                    SvSala.Columns.Add(row.ToString());
                }
                for (int row = 0; row < kolona; row++)
                {
                    DataRow drr = SvSala.NewRow();
                    for (int col = 0; col < redovi; col++)
                    {

                        for (int i = 0; i < nbColumns; i++)
                        {
                            if (row == 0)
                            {
                                if (viewModel.rezultatiPonedeljak[col][i].Contains("svecana sala") /*|| viewModel.rezultatiUtorak[col][i].Contains("svecana sala") || viewModel.rezultatiSreda[col][i].Contains("svecana sala") || viewModel.rezultatiCetvrtak[col][i].Contains("svecana sala") || viewModel.rezultatiPetak[col][i].Contains("svecana sala")*/)
                                {
                                    drr[col] += "zauzeta";
                                }
                            }

                            else if (row == 1)
                            {
                                if (viewModel.rezultatiUtorak[col][i].Contains("svecana sala"))
                                {
                                    drr[col] += "zauzeta";
                                }
                            }
                            else if (row == 2)
                            {
                                if (viewModel.rezultatiSreda[col][i].Contains("svecana sala"))
                                {
                                    drr[col] += "zauzeta";
                                }
                            }
                            else if (row == 3)
                            {
                                if (viewModel.rezultatiCetvrtak[col][i].Contains("svecana sala"))
                                {
                                    drr[col] += "zauzeta";
                                }
                            }
                            else
                            {
                                if (viewModel.rezultatiPetak[col][i].Contains("svecana sala"))
                                {
                                    drr[col] += "zauzeta";
                                }
                            }
                        }

                    }
                    SvSala.Rows.Add(drr);
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
                            prvo1[col] = viewModel.rezultatiPonedeljak[row][0];
                            prvo2[col] = viewModel.rezultatiPonedeljak[row][1];
                            prvo3[col] = viewModel.rezultatiPonedeljak[row][2];
                            drugo1[col] = viewModel.rezultatiPonedeljak[row][8];
                            drugo2[col] = viewModel.rezultatiPonedeljak[row][9];
                            drugo3[col] = viewModel.rezultatiPonedeljak[row][10];
                        }
                        else if (col == 1)
                        {
                            prvo1[col] = viewModel.rezultatiUtorak[row][0];
                            prvo2[col] = viewModel.rezultatiUtorak[row][1];
                            prvo3[col] = viewModel.rezultatiUtorak[row][2];
                            drugo1[col] = viewModel.rezultatiUtorak[row][8];
                            drugo2[col] = viewModel.rezultatiUtorak[row][9];
                            drugo3[col] = viewModel.rezultatiUtorak[row][10];
                        }
                        else if (col == 2)
                        {
                            prvo1[col] = viewModel.rezultatiSreda[row][0];
                            prvo2[col] = viewModel.rezultatiSreda[row][1];
                            prvo3[col] = viewModel.rezultatiSreda[row][2];
                            drugo1[col] = viewModel.rezultatiSreda[row][8];
                            drugo2[col] = viewModel.rezultatiSreda[row][9];
                            drugo3[col] = viewModel.rezultatiSreda[row][10];
                        }
                        else if (col == 3)
                        {
                            prvo1[col] = viewModel.rezultatiCetvrtak[row][0];
                            prvo2[col] = viewModel.rezultatiCetvrtak[row][1];
                            prvo3[col] = viewModel.rezultatiCetvrtak[row][2];
                            drugo1[col] = viewModel.rezultatiCetvrtak[row][8];
                            drugo2[col] = viewModel.rezultatiCetvrtak[row][9];
                            drugo3[col] = viewModel.rezultatiCetvrtak[row][10];
                        }
                        else
                        {
                            prvo1[col] = viewModel.rezultatiPetak[row][0];
                            prvo2[col] = viewModel.rezultatiPetak[row][1];
                            prvo3[col] = viewModel.rezultatiPetak[row][2];
                            drugo1[col] = viewModel.rezultatiPetak[row][8];
                            drugo2[col] = viewModel.rezultatiPetak[row][9];
                            drugo3[col] = viewModel.rezultatiPetak[row][10];
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


                DataRow stati = Staticne.NewRow();
                //ispis za rezultate
                for (int i = 0; i < nbColumns; i++)
                {
                    Staticne.Columns.Add(viewModel.lista_odeljenja[i].Ime_odeljenja.ToString());
                    if (viewModel.lista_odeljenja[i].Id_ucionice == null)
                    {
                        stati[i] += "Lutajuce";
                    }
                    else
                    {
                        stati[i] += viewModel.lista_ucionica.First(ucionica => ucionica.Id == viewModel.lista_odeljenja[i].Id_ucionice).Ime_ucionice;
                    }

                    dt.Columns.Add(viewModel.lista_odeljenja[i].Ime_odeljenja.ToString());
                    dt2.Columns.Add(viewModel.lista_odeljenja[i].Ime_odeljenja.ToString());
                    dt3.Columns.Add(viewModel.lista_odeljenja[i].Ime_odeljenja.ToString());
                    dt4.Columns.Add(viewModel.lista_odeljenja[i].Ime_odeljenja.ToString());
                    dt5.Columns.Add(viewModel.lista_odeljenja[i].Ime_odeljenja.ToString());
                }
                Staticne.Rows.Add(stati);
                for (int row = 0; row < nbRows; row++)
                {

                    DataRow dr2 = dt2.NewRow();
                    DataRow dr = dt.NewRow();
                    DataRow dr3 = dt3.NewRow();
                    DataRow dr4 = dt4.NewRow();
                    DataRow dr5 = dt5.NewRow();
                    for (int col = 0; col < nbColumns; col++)
                    {

                        dr[col] = viewModel.rezultatiPonedeljak[row][col];
                        dr2[col] = viewModel.rezultatiUtorak[row][col];
                        dr3[col] = viewModel.rezultatiSreda[row][col];
                        dr4[col] = viewModel.rezultatiCetvrtak[row][col];
                        dr5[col] = viewModel.rezultatiPetak[row][col];
                    }
                    dt.Rows.Add(dr);
                    dt2.Rows.Add(dr2);
                    dt3.Rows.Add(dr3);
                    dt4.Rows.Add(dr4);
                    dt5.Rows.Add(dr5);
                }



                staticne.ItemsSource = Staticne.DefaultView;
                /*rezultatiPon.ItemsSource = dt.DefaultView;
                rezultatiUto.ItemsSource = dt2.DefaultView;
                rezultatiSre.ItemsSource = dt3.DefaultView;
                rezultatiCet.ItemsSource = dt4.DefaultView;
                rezultatiPet.ItemsSource = dt5.DefaultView;*/

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InputWindow window1 = new InputWindow();
            window1.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window1.Show();
            Close();
        }
    }
}
