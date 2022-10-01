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

namespace Raspored_Ucionica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {

        /*public class Rezultati
        {
            public string? imeOdeljenja { get; set; }
            public string? ucionica { get; set; }
           // public Collection<string>? kurac { get; set; }
        }
        private List<Rezultati> LoadCollectionData()
        {
            List<Rezultati> authors = new List<Rezultati>();
            Collection<string> kolekcija = new Collection<string>() { "1", "2" };
            authors.Add(new Rezultati()
            {
                imeOdeljenja = "I1",
                ucionica = "23",
                //kurac = kolekcija.In
            }) ;

            

            return authors;
        }*/
        public MainWindow()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            int nbColumns = 32;
            int nbRows = 8;
            MainPageViewModel viewModel = new MainPageViewModel();
            for (int i = 1; i <= nbColumns; i++)
            {
                dt.Columns.Add(i.ToString(), typeof(string));
                
            }
            /*for(int i = 0; i < nbRows; i++)
            {
                dt.Rows.Add(i.ToString() + ".cas");
            }*/

            for (int row = 0; row < nbRows; row++)
            {
                
                DataRow dr = dt.NewRow();
                for (int col = 0; col <= nbColumns; col++)
                {
                    dr[col] = viewModel.rezultatiPonedeljak[col][row];
                }
                dt.Rows.Add(dr);
            }

            rezultatiPon.ItemsSource = dt.DefaultView;
        }

    }
}
