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
        public MainWindow()
        {
            InitializeComponent();
            MainPageViewModel mainPageViewModel = new MainPageViewModel();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    labelaa.Content += $"{mainPageViewModel.Ponedeljak_raspored.RasporedCasova[i][j]} ";
                }
                labelaa.Content += " | \n";
            }        
        }
    }
}
