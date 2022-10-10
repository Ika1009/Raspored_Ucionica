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
        }

        private void noviwindowButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            mainWindow.Show();
            Close();
        }
        private void Checkovanje(object sender, RoutedEventArgs e)
        {
            CheckBox? checkBox = sender! as CheckBox;
            switch (checkBox!.Name)
            {
                case "checked11":
                    viewModel.Checked11 = true;
                    break;
                case "checked12":
                    viewModel.Checked12 = true;
                    break;
                case "checked13":
                    viewModel.Checked13 = true;
                    break;
                case "checked21":
                    viewModel.Checked21 = true;
                    break;
                case "checked22":
                    viewModel.Checked22 = true;
                    break;
                case "checked23":
                    viewModel.Checked23 = true;
                    break;
                case "checked31":
                    viewModel.Checked31 = true;
                    break;
                case "checked32":
                    viewModel.Checked32 = true;
                    break;
                case "checked33":
                    viewModel.Checked33 = true;
                    break;
                case "checked41":
                    viewModel.Checked41 = true;
                    break;
                case "checked42":
                    viewModel.Checked42 = true;
                    break;
                case "checked43":
                    viewModel.Checked43 = true;
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
                    break;
                case "checked12":
                    viewModel.Checked12 = false;
                    break;
                case "checked13":
                    viewModel.Checked13 = false;
                    break;
                case "checked21":
                    viewModel.Checked21 = false;
                    break;
                case "checked22":
                    viewModel.Checked22 = false;
                    break;
                case "checked23":
                    viewModel.Checked23 = false;
                    break;
                case "checked31":
                    viewModel.Checked31 = false;
                    break;
                case "checked32":
                    viewModel.Checked32 = false;
                    break;
                case "checked33":
                    viewModel.Checked33 = false;
                    break;
                case "checked41":
                    viewModel.Checked41 = false;
                    break;
                case "checked42":
                    viewModel.Checked42 = false;
                    break;
                case "checked43":
                    viewModel.Checked43 = false;
                    break;
                default:
                    MessageBox.Show("Nesto je poslo opasno naopako");
                    break;

            }
        }
    }
}
