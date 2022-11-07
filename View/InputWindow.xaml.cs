using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Raspored_Ucionica.ViewModel;

namespace Raspored_Ucionica
{
    public partial class InputWindow : Window
    {
        InputWindowViewModel viewModel;
        public InputWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            viewModel = new();
            DataContext = viewModel;
            noviwindowButton.Visibility = Visibility.Hidden;
        }
        private void lutajucaButton_Click(object sender, RoutedEventArgs e)
        {
            noviwindowButton.Visibility= Visibility.Visible;
            lutajucaButton.Visibility= Visibility.Hidden;
            checkboxLabel.Content = "Изаберите учионице за статична одељења: ";
            label11.Visibility = Visibility.Visible;
            label12.Visibility = Visibility.Visible;
            label13.Visibility = Visibility.Visible;
            label14.Visibility = Visibility.Visible;
            label15.Visibility = Visibility.Visible;
            label16.Visibility = Visibility.Visible;
            label17.Visibility = Visibility.Visible;
            label18.Visibility = Visibility.Visible;
            label21.Visibility = Visibility.Visible;
            label22.Visibility = Visibility.Visible;
            label23.Visibility = Visibility.Visible;
            label24.Visibility = Visibility.Visible;
            label25.Visibility = Visibility.Visible;
            label26.Visibility = Visibility.Visible;
            label27.Visibility = Visibility.Visible;
            label28.Visibility = Visibility.Visible;
            label31.Visibility = Visibility.Visible;
            label32.Visibility = Visibility.Visible;
            label33.Visibility = Visibility.Visible;
            label34.Visibility = Visibility.Visible;
            label35.Visibility = Visibility.Visible;
            label36.Visibility = Visibility.Visible;
            label37.Visibility = Visibility.Visible;
            label38.Visibility = Visibility.Visible;
            label41.Visibility = Visibility.Visible;
            label42.Visibility = Visibility.Visible;
            label43.Visibility = Visibility.Visible;
            label44.Visibility = Visibility.Visible;
            label45.Visibility = Visibility.Visible;
            label46.Visibility = Visibility.Visible;
            label47.Visibility = Visibility.Visible;
            label48.Visibility = Visibility.Visible;
            checked11.Visibility = Visibility.Hidden;
            checked12.Visibility = Visibility.Hidden;
            checked13.Visibility = Visibility.Hidden;
            checked14.Visibility = Visibility.Hidden;
            checked15.Visibility = Visibility.Hidden;
            checked16.Visibility = Visibility.Hidden;
            checked17.Visibility = Visibility.Hidden;
            checked18.Visibility = Visibility.Hidden;
            checked21.Visibility = Visibility.Hidden;
            checked22.Visibility = Visibility.Hidden;
            checked23.Visibility = Visibility.Hidden;
            checked24.Visibility = Visibility.Hidden;
            checked25.Visibility = Visibility.Hidden;
            checked26.Visibility = Visibility.Hidden;
            checked27.Visibility = Visibility.Hidden;
            checked28.Visibility = Visibility.Hidden;
            checked31.Visibility = Visibility.Hidden;
            checked32.Visibility = Visibility.Hidden;
            checked33.Visibility = Visibility.Hidden;
            checked34.Visibility = Visibility.Hidden;
            checked35.Visibility = Visibility.Hidden;
            checked36.Visibility = Visibility.Hidden;
            checked37.Visibility = Visibility.Hidden;
            checked38.Visibility = Visibility.Hidden;
            checked41.Visibility = Visibility.Hidden;
            checked42.Visibility = Visibility.Hidden;
            checked43.Visibility = Visibility.Hidden;
            checked44.Visibility = Visibility.Hidden;
            checked45.Visibility = Visibility.Hidden;
            checked46.Visibility = Visibility.Hidden;
            checked47.Visibility = Visibility.Hidden;
            checked48.Visibility = Visibility.Hidden;
            textbox11.Visibility = Visibility.Visible;
            textbox12.Visibility = Visibility.Visible;
            textbox13.Visibility = Visibility.Visible;
            textbox14.Visibility = Visibility.Visible;
            textbox15.Visibility = Visibility.Visible;
            textbox16.Visibility = Visibility.Visible;
            textbox17.Visibility = Visibility.Visible;
            textbox18.Visibility = Visibility.Visible;
            textbox21.Visibility = Visibility.Visible;
            textbox22.Visibility = Visibility.Visible;
            textbox23.Visibility = Visibility.Visible;
            textbox24.Visibility = Visibility.Visible;
            textbox25.Visibility = Visibility.Visible;
            textbox26.Visibility = Visibility.Visible;
            textbox27.Visibility = Visibility.Visible;
            textbox28.Visibility = Visibility.Visible;
            textbox31.Visibility = Visibility.Visible;
            textbox32.Visibility = Visibility.Visible;
            textbox33.Visibility = Visibility.Visible;
            textbox34.Visibility = Visibility.Visible;
            textbox35.Visibility = Visibility.Visible;
            textbox36.Visibility = Visibility.Visible;
            textbox37.Visibility = Visibility.Visible;
            textbox38.Visibility = Visibility.Visible;
            textbox41.Visibility = Visibility.Visible;
            textbox42.Visibility = Visibility.Visible;
            textbox43.Visibility = Visibility.Visible;
            textbox44.Visibility = Visibility.Visible;
            textbox45.Visibility = Visibility.Visible;
            textbox46.Visibility = Visibility.Visible;
            textbox47.Visibility = Visibility.Visible;
            textbox48.Visibility = Visibility.Visible;
        }
        private void noviwindowButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow mainWindow = new MainWindow(viewModel);
                mainWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                mainWindow.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doslo je do problema, proverite da li postoji resenje za odgovarajuci izbor lutajucih ucionica!\nGreska: " + ex.Message, "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Checkovanje(object sender, RoutedEventArgs e)
        {
            CheckBox? checkBox = sender! as CheckBox;
            switch (checkBox!.Name)
            {
                case "checked11":
                    viewModel.Checked11 = true;
                    textbox11.Text = "Лутајуће";
                    textbox11.IsEnabled = false;
                    break;
                case "checked12":
                    viewModel.Checked12 = true;
                    textbox12.Text = "Лутајуће";
                    textbox12.IsEnabled = false;
                    break;
                case "checked13":
                    viewModel.Checked13 = true;
                    textbox13.Text = "Лутајуће";
                    textbox13.IsEnabled = false;
                    break;
                case "checked21":
                    viewModel.Checked21 = true;
                    textbox21.Text = "Лутајуће";
                    textbox21.IsEnabled = false;
                    break;
                case "checked22":
                    viewModel.Checked22 = true;
                    textbox22.Text = "Лутајуће";
                    textbox22.IsEnabled = false;
                    break;
                case "checked23":
                    viewModel.Checked23 = true;
                    textbox23.Text = "Лутајуће";
                    textbox23.IsEnabled = false;
                    break;
                case "checked31":
                    viewModel.Checked31 = true;
                    textbox31.Text = "Лутајуће";
                    textbox31.IsEnabled = false;
                    break;
                case "checked32":
                    viewModel.Checked32 = true;
                    textbox32.Text = "Лутајуће";
                    textbox32.IsEnabled = false;
                    break;
                case "checked33":
                    viewModel.Checked33 = true;
                    textbox33.Text = "Лутајуће";
                    textbox33.IsEnabled = false;
                    break;
                case "checked34":
                    viewModel.Checked34 = true;
                    textbox34.Text = "Лутајуће";
                    textbox34.IsEnabled = false;
                    break;
                case "checked41":
                    viewModel.Checked41 = true;
                    textbox41.Text = "Лутајуће";
                    textbox41.IsEnabled = false;
                    break;
                case "checked42":
                    viewModel.Checked42 = true;
                    textbox42.Text = "Лутајуће";
                    textbox42.IsEnabled = false;
                    break;
                case "checked43":
                    viewModel.Checked43 = true;
                    textbox43.Text = "Лутајуће";
                    textbox43.IsEnabled = false;
                    break;
                default:
                    MessageBox.Show("Nesto je poslo opasno naopako");
                    break;
            }
        }
        private void UnCheckovanje(object sender, RoutedEventArgs e)
        {
            CheckBox? checkBox = sender! as CheckBox;
            switch (checkBox!.Name)
            {
                case "checked11":
                    viewModel.Checked11 = false;
                    textbox11.Text = "";
                    textbox11.IsEnabled = true;
                    break;
                case "checked12":
                    viewModel.Checked12 = false;
                    textbox12.Text = "";
                    textbox12.IsEnabled = true;
                    break;
                case "checked13":
                    viewModel.Checked13 = false;
                    textbox13.Text = "";
                    textbox13.IsEnabled = true;
                    break;
                case "checked21":
                    viewModel.Checked21 = false;
                    textbox21.Text = "";
                    textbox21.IsEnabled = true;
                    break;
                case "checked22":
                    viewModel.Checked22 = false;
                    textbox22.Text = "";
                    textbox22.IsEnabled = true;
                    break;
                case "checked23":
                    viewModel.Checked23 = false;
                    textbox32.Text = "";
                    textbox32.IsEnabled = true;
                    break;
                case "checked31":
                    viewModel.Checked31 = false;
                    textbox31.Text = "";
                    textbox31.IsEnabled = true;
                    break;
                case "checked32":
                    viewModel.Checked32 = false;
                    textbox32.Text = "";
                    textbox32.IsEnabled = true;
                    break;
                case "checked33":
                    viewModel.Checked33 = false;
                    textbox33.Text = "";
                    textbox33.IsEnabled = true;
                    break;
                case "checked41":
                    viewModel.Checked41 = false;
                    textbox41.Text = "";
                    textbox41.IsEnabled = true;
                    break;
                case "checked42":
                    viewModel.Checked42 = false;
                    textbox42.Text = "";
                    textbox42.IsEnabled = true;
                    break;
                case "checked43":
                    viewModel.Checked43 = false;
                    textbox43.Text = "";
                    textbox43.IsEnabled = true;
                    break;
                default:
                    MessageBox.Show("Nesto je poslo opasno naopako");
                    break;

            }
        }


    }
}
