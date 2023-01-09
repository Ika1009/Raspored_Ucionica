﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
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
using Raspored_Ucionica.Model;
using System.IO;

namespace Raspored_Ucionica
{
    public partial class InputWindow : Window
    {
        string[] brojeviUcionice = new string[32];
        InputWindowViewModel viewModel;
        public InputWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            viewModel = new();
            DataContext = viewModel;
            noviwindowButton.Visibility = Visibility.Hidden;
            Odeljenje();
        }
        private void Odeljenje()
        {
            string path = @"BrojUcenikaUOdeljenjimaXLS.csv";
            if (!File.Exists(path))
            {
                //MessageBox.Show("Ne postoji!");
                using (FileStream fs = File.Create(path))
                brojeviUcionice[0] = "19";
                brojeviUcionice[1] = "19";
                brojeviUcionice[2] = "18";
                brojeviUcionice[3] = "30";
                brojeviUcionice[4] = "35";
                brojeviUcionice[5] = "35";
                brojeviUcionice[6] = "32";
                brojeviUcionice[7] = "29";
                brojeviUcionice[8] = "19";
                brojeviUcionice[9] = "20";
                brojeviUcionice[10] = "17";
                brojeviUcionice[11] = "28";
                brojeviUcionice[12] = "34";
                brojeviUcionice[13] = "36";
                brojeviUcionice[14] = "29";
                brojeviUcionice[15] = "31";
                brojeviUcionice[16] = "20";
                brojeviUcionice[17] = "18";
                brojeviUcionice[18] = "18";
                brojeviUcionice[19] = "23";
                brojeviUcionice[20] = "35";
                brojeviUcionice[21] = "35";
                brojeviUcionice[22] = "31";
                brojeviUcionice[23] = "32";
                brojeviUcionice[24] = "19";
                brojeviUcionice[25] = "21";
                brojeviUcionice[26] = "19";
                brojeviUcionice[27] = "29";
                brojeviUcionice[28] = "30";
                brojeviUcionice[29] = "27";
                brojeviUcionice[30] = "37";
                brojeviUcionice[31] = "36";

                File.WriteAllLines(path, brojeviUcionice);
            }
            else
            {
                //MessageBox.Show("Postoji!");
                brojeviUcionice = File.ReadAllLines(path);
            }

            // za excel kabineta
            path = @"SlobodniKabineti.csv";
            if (!File.Exists(path))
            {
                Kabineti? Kponedeljak, Kutorak, Ksreda, Kcetvrtak, Kpetak;
                string zaUpisivanje = "";
                zaUpisivanje += "I-1,I-1,I-2,I-2,III-2,III-2,III-2,III-2\n";
                //zaUpisivanje += 

                Kponedeljak = new(new List<List<string>> // optimizovao
                {
                    new List<string>() {}, //22
                    new List<string>() {"true", "I-8", "I-8", "I-7", "I-7", "II-3", "II-3", "I-1"}, //29
                    new List<string>() {"true", "true", "true", "true", "true", "IV-3", "IV-3", "true"}, //23a
                    new List<string>() {"IV-4", "IV-4", "III-4", "III-4", "II-5", "II-5", "II-5", "II-5"}, //Sremac
                    new List<string>() {"true", "IV-6", "IV-6", "III-7", "III-6", "II-3", "II-3", "true"}, //Multimedijalna(MM)
                });
                Kutorak = new(new List<List<string>> // optimizovao
                {
                    new List<string>() {"true", "II-1", "II-1", "I-2", "I-2", "II-2", "II-2", "IV-7"}, //22
                    new List<string>() {"true", "III-2", "III-2", "III-2", "III-1", "III-1", "III-1", "III-1"}, //29
                    new List<string>() {"true", "I-1", "I-1", "I-1", "I-1", "I-1", "I-1", "true"}, //23a
                    new List<string>() {"true", "IV-5", "IV-5", "III-5", "III-8", "III-8", "III-3", "III-3"}, //SremaC
                    new List<string>() {"true", "true", "I-1", "I-1", "I-1", "I-1", "II-4", "II-4"}, //Multimedijalna
                });
                Ksreda = new(new List<List<string>> // optimizovao
                {
                    new List<string>() {"true", "II-1","II-1", "IV-2", "IV-1", "III-6", "I-4", "I-4"}, //22
                    new List<string>() {"true", "III-1", "III-1", "III-1", "I-3", "I-3", "I-6", "I-6"}, //29
                    new List<string>() {"IV-6", "IV-6", "II-2", "II-2", "II-2", "II-2", "true", "true"}, //23a
                    new List<string>() {"true", "II-2", "II-2", "II-2", "II-2", "II-2", "II-2", "IV-7"}, //Sremac
                    new List<string>() {"II-6", "II-6", "II-6", "II-6", "I-3", "I-3", "I-6", "I-6"}, //Multimedijalna
                });
                Kcetvrtak = new(new List<List<string>> // optimizovao
                {
                    new List<string>() {"true", "II-1", "II-1", "II-1", "II-1", "II-1", "II-1", "true"}, //22
                    new List<string>() {"true", "I-5", "I-5", "II-7", "II-7", "II-8", "II-8", "I-2"}, //29
                    new List<string>() {"true", "true", "II-1", "II-1", "II-1", "II-1", "III-3", "III-3"}, //23a
                    new List<string>() { "true", "true", "true", "II-7", "II-7", "II-8", "II-8", "true"}, //Sremac
                    new List<string>() {"true", "IV-8", "II-4", "II-4", "true", "true", "I-4", "I-4"}, //Multimedijalna
                });
                Kpetak = new(new List<List<string>> // optimizovao
                {
                    new List<string>() {"true", "I-5", "I-5", "III-5", "III-7", "IV-8", "true", "true"}, //22
                    new List<string>() {"true", "I-1", "I-1", "II-2", "II-2", "true", "true", "true"}, //29
                    new List<string>() {"true", "I-2", "I-2", "I-2", "I-2", "I-2", "I-2", "true"}, //23a
                    new List<string>() { "true", "IV-5", "IV-5", "true", "true", "true", "true", "true"}, //Sremac
                    new List<string>() {"IV-4", "IV-4", "I-2", "I-2", "I-2", "I-2", "true", "true"}, //Multimedijalna
                });
                for (int i = 0; i < 10; i++)
                {

                }
                using FileStream fs = File.Create(path);
                File.WriteAllLines(path, brojeviUcionice);

            }

            OdeljenjeTextbox11.Text = brojeviUcionice[0];
            OdeljenjeTextbox12.Text = brojeviUcionice[1];
            OdeljenjeTextbox13.Text = brojeviUcionice[2];
            OdeljenjeTextbox14.Text = brojeviUcionice[3];
            OdeljenjeTextbox15.Text = brojeviUcionice[4];
            OdeljenjeTextbox16.Text = brojeviUcionice[5];
            OdeljenjeTextbox17.Text = brojeviUcionice[6];
            OdeljenjeTextbox18.Text = brojeviUcionice[7];
            OdeljenjeTextbox21.Text = brojeviUcionice[8];
            OdeljenjeTextbox22.Text = brojeviUcionice[9];
            OdeljenjeTextbox23.Text = brojeviUcionice[10];
            OdeljenjeTextbox24.Text = brojeviUcionice[11];
            OdeljenjeTextbox25.Text = brojeviUcionice[12];
            OdeljenjeTextbox26.Text = brojeviUcionice[13];
            OdeljenjeTextbox27.Text = brojeviUcionice[14];
            OdeljenjeTextbox28.Text = brojeviUcionice[15];
            OdeljenjeTextbox31.Text = brojeviUcionice[16];
            OdeljenjeTextbox32.Text = brojeviUcionice[17];
            OdeljenjeTextbox33.Text = brojeviUcionice[18];
            OdeljenjeTextbox34.Text = brojeviUcionice[19];
            OdeljenjeTextbox35.Text = brojeviUcionice[20];
            OdeljenjeTextbox36.Text = brojeviUcionice[21];
            OdeljenjeTextbox37.Text = brojeviUcionice[22];
            OdeljenjeTextbox38.Text = brojeviUcionice[23];
            OdeljenjeTextbox41.Text = brojeviUcionice[24];
            OdeljenjeTextbox42.Text = brojeviUcionice[25];
            OdeljenjeTextbox43.Text = brojeviUcionice[26];
            OdeljenjeTextbox44.Text = brojeviUcionice[27];
            OdeljenjeTextbox45.Text = brojeviUcionice[28];
            OdeljenjeTextbox46.Text = brojeviUcionice[29];
            OdeljenjeTextbox47.Text = brojeviUcionice[30];
            OdeljenjeTextbox48.Text = brojeviUcionice[31];

        }
        private void NazadOdeljenjeButton_Click(object sender, RoutedEventArgs e)
        {
            OdeljenjecheckboxLabel.Visibility = Visibility.Hidden;
            IzmeniOdeljenjeButton.Visibility = Visibility.Hidden;
            NazadOdeljenjeButton.Visibility = Visibility.Hidden;
            OdeljenjaButton.Visibility = Visibility.Visible;
            NapraviRasporedButton.Visibility = Visibility.Visible;
            naslovLabel.Visibility = Visibility.Hidden;
            naslovLabel1.Visibility = Visibility.Visible;
            podNaslovLabel.Visibility = Visibility.Hidden;
            podNaslovLabel1.Visibility = Visibility.Visible;
            OdeljenjeTextbox11.Visibility = Visibility.Hidden;
            OdeljenjeTextbox12.Visibility = Visibility.Hidden;
            OdeljenjeTextbox13.Visibility = Visibility.Hidden;
            OdeljenjeTextbox14.Visibility = Visibility.Hidden;
            OdeljenjeTextbox15.Visibility = Visibility.Hidden;
            OdeljenjeTextbox16.Visibility = Visibility.Hidden;
            OdeljenjeTextbox17.Visibility = Visibility.Hidden;
            OdeljenjeTextbox18.Visibility = Visibility.Hidden;
            OdeljenjeTextbox21.Visibility = Visibility.Hidden;
            OdeljenjeTextbox22.Visibility = Visibility.Hidden;
            OdeljenjeTextbox23.Visibility = Visibility.Hidden;
            OdeljenjeTextbox24.Visibility = Visibility.Hidden;
            OdeljenjeTextbox25.Visibility = Visibility.Hidden;
            OdeljenjeTextbox26.Visibility = Visibility.Hidden;
            OdeljenjeTextbox27.Visibility = Visibility.Hidden;
            OdeljenjeTextbox28.Visibility = Visibility.Hidden;
            OdeljenjeTextbox31.Visibility = Visibility.Hidden;
            OdeljenjeTextbox32.Visibility = Visibility.Hidden;
            OdeljenjeTextbox33.Visibility = Visibility.Hidden;
            OdeljenjeTextbox34.Visibility = Visibility.Hidden;
            OdeljenjeTextbox35.Visibility = Visibility.Hidden;
            OdeljenjeTextbox36.Visibility = Visibility.Hidden;
            OdeljenjeTextbox37.Visibility = Visibility.Hidden;
            OdeljenjeTextbox38.Visibility = Visibility.Hidden;
            OdeljenjeTextbox41.Visibility = Visibility.Hidden;
            OdeljenjeTextbox42.Visibility = Visibility.Hidden;
            OdeljenjeTextbox43.Visibility = Visibility.Hidden;
            OdeljenjeTextbox44.Visibility = Visibility.Hidden;
            OdeljenjeTextbox45.Visibility = Visibility.Hidden;
            OdeljenjeTextbox46.Visibility = Visibility.Hidden;
            OdeljenjeTextbox47.Visibility = Visibility.Hidden;
            OdeljenjeTextbox48.Visibility = Visibility.Hidden;
            OdeljenjeLabel11.Visibility = Visibility.Hidden;
            OdeljenjeLabel12.Visibility = Visibility.Hidden;
            OdeljenjeLabel13.Visibility = Visibility.Hidden;
            OdeljenjeLabel14.Visibility = Visibility.Hidden;
            OdeljenjeLabel15.Visibility = Visibility.Hidden;
            OdeljenjeLabel16.Visibility = Visibility.Hidden;
            OdeljenjeLabel17.Visibility = Visibility.Hidden;
            OdeljenjeLabel18.Visibility = Visibility.Hidden;
            OdeljenjeLabel21.Visibility = Visibility.Hidden;
            OdeljenjeLabel22.Visibility = Visibility.Hidden;
            OdeljenjeLabel23.Visibility = Visibility.Hidden;
            OdeljenjeLabel24.Visibility = Visibility.Hidden;
            OdeljenjeLabel25.Visibility = Visibility.Hidden;
            OdeljenjeLabel26.Visibility = Visibility.Hidden;
            OdeljenjeLabel27.Visibility = Visibility.Hidden;
            OdeljenjeLabel28.Visibility = Visibility.Hidden;
            OdeljenjeLabel31.Visibility = Visibility.Hidden;
            OdeljenjeLabel32.Visibility = Visibility.Hidden;
            OdeljenjeLabel33.Visibility = Visibility.Hidden;
            OdeljenjeLabel34.Visibility = Visibility.Hidden;
            OdeljenjeLabel35.Visibility = Visibility.Hidden;
            OdeljenjeLabel36.Visibility = Visibility.Hidden;
            OdeljenjeLabel37.Visibility = Visibility.Hidden;
            OdeljenjeLabel38.Visibility = Visibility.Hidden;
            OdeljenjeLabel41.Visibility = Visibility.Hidden;
            OdeljenjeLabel42.Visibility = Visibility.Hidden;
            OdeljenjeLabel43.Visibility = Visibility.Hidden;
            OdeljenjeLabel44.Visibility = Visibility.Hidden;
            OdeljenjeLabel45.Visibility = Visibility.Hidden;
            OdeljenjeLabel46.Visibility = Visibility.Hidden;
            OdeljenjeLabel47.Visibility = Visibility.Hidden;
            OdeljenjeLabel48.Visibility = Visibility.Hidden;
        }
        private void OdeljenjaButton_Click(object sender, RoutedEventArgs e)
        {

            OdeljenjecheckboxLabel.Visibility = Visibility.Visible;
            IzmeniOdeljenjeButton.Visibility = Visibility.Visible;
            NazadOdeljenjeButton.Visibility = Visibility.Visible;
            OdeljenjaButton.Visibility = Visibility.Hidden;
            NapraviRasporedButton.Visibility = Visibility.Hidden;
            naslovLabel.Visibility = Visibility.Visible;
            naslovLabel1.Visibility = Visibility.Hidden;
            podNaslovLabel.Visibility = Visibility.Visible;
            podNaslovLabel1.Visibility = Visibility.Hidden;
            OdeljenjeTextbox11.Visibility = Visibility.Visible;
            OdeljenjeTextbox12.Visibility = Visibility.Visible;
            OdeljenjeTextbox13.Visibility = Visibility.Visible;
            OdeljenjeTextbox14.Visibility = Visibility.Visible;
            OdeljenjeTextbox15.Visibility = Visibility.Visible;
            OdeljenjeTextbox16.Visibility = Visibility.Visible;
            OdeljenjeTextbox17.Visibility = Visibility.Visible;
            OdeljenjeTextbox18.Visibility = Visibility.Visible;
            OdeljenjeTextbox21.Visibility = Visibility.Visible;
            OdeljenjeTextbox22.Visibility = Visibility.Visible;
            OdeljenjeTextbox23.Visibility = Visibility.Visible;
            OdeljenjeTextbox24.Visibility = Visibility.Visible;
            OdeljenjeTextbox25.Visibility = Visibility.Visible;
            OdeljenjeTextbox26.Visibility = Visibility.Visible;
            OdeljenjeTextbox27.Visibility = Visibility.Visible;
            OdeljenjeTextbox28.Visibility = Visibility.Visible;
            OdeljenjeTextbox31.Visibility = Visibility.Visible;
            OdeljenjeTextbox32.Visibility = Visibility.Visible;
            OdeljenjeTextbox33.Visibility = Visibility.Visible;
            OdeljenjeTextbox34.Visibility = Visibility.Visible;
            OdeljenjeTextbox35.Visibility = Visibility.Visible;
            OdeljenjeTextbox36.Visibility = Visibility.Visible;
            OdeljenjeTextbox37.Visibility = Visibility.Visible;
            OdeljenjeTextbox38.Visibility = Visibility.Visible;
            OdeljenjeTextbox41.Visibility = Visibility.Visible;
            OdeljenjeTextbox42.Visibility = Visibility.Visible;
            OdeljenjeTextbox43.Visibility = Visibility.Visible;
            OdeljenjeTextbox44.Visibility = Visibility.Visible;
            OdeljenjeTextbox45.Visibility = Visibility.Visible;
            OdeljenjeTextbox46.Visibility = Visibility.Visible;
            OdeljenjeTextbox47.Visibility = Visibility.Visible;
            OdeljenjeTextbox48.Visibility = Visibility.Visible;
            OdeljenjeLabel11.Visibility = Visibility.Visible;
            OdeljenjeLabel12.Visibility = Visibility.Visible;
            OdeljenjeLabel13.Visibility = Visibility.Visible;
            OdeljenjeLabel14.Visibility = Visibility.Visible;
            OdeljenjeLabel15.Visibility = Visibility.Visible;
            OdeljenjeLabel16.Visibility = Visibility.Visible;
            OdeljenjeLabel17.Visibility = Visibility.Visible;
            OdeljenjeLabel18.Visibility = Visibility.Visible;
            OdeljenjeLabel21.Visibility = Visibility.Visible;
            OdeljenjeLabel22.Visibility = Visibility.Visible;
            OdeljenjeLabel23.Visibility = Visibility.Visible;
            OdeljenjeLabel24.Visibility = Visibility.Visible;
            OdeljenjeLabel25.Visibility = Visibility.Visible;
            OdeljenjeLabel26.Visibility = Visibility.Visible;
            OdeljenjeLabel27.Visibility = Visibility.Visible;
            OdeljenjeLabel28.Visibility = Visibility.Visible;
            OdeljenjeLabel31.Visibility = Visibility.Visible;
            OdeljenjeLabel32.Visibility = Visibility.Visible;
            OdeljenjeLabel33.Visibility = Visibility.Visible;
            OdeljenjeLabel34.Visibility = Visibility.Visible;
            OdeljenjeLabel35.Visibility = Visibility.Visible;
            OdeljenjeLabel36.Visibility = Visibility.Visible;
            OdeljenjeLabel37.Visibility = Visibility.Visible;
            OdeljenjeLabel38.Visibility = Visibility.Visible;
            OdeljenjeLabel41.Visibility = Visibility.Visible;
            OdeljenjeLabel42.Visibility = Visibility.Visible;
            OdeljenjeLabel43.Visibility = Visibility.Visible;
            OdeljenjeLabel44.Visibility = Visibility.Visible;
            OdeljenjeLabel45.Visibility = Visibility.Visible;
            OdeljenjeLabel46.Visibility = Visibility.Visible;
            OdeljenjeLabel47.Visibility = Visibility.Visible;
            OdeljenjeLabel48.Visibility = Visibility.Visible;
        }
        private void NazadPocetnaButton_Click(object sender, RoutedEventArgs e)
        {
            NazadPocetnaButton.Visibility = Visibility.Hidden;
            checkboxLabel_Copy.Visibility = Visibility.Hidden;
            checkboxLabel_Copy1.Visibility = Visibility.Hidden;
            checkboxLabel_Copy2.Visibility = Visibility.Hidden;
            checkboxLabel_Copy3.Visibility = Visibility.Hidden;
            brojCheckboxaLabel.Visibility = Visibility.Hidden;
            brojLutajucihLabel.Visibility = Visibility.Hidden;
            lutajucaButton.Visibility = Visibility.Hidden;
            checkboxLabel.Visibility = Visibility.Hidden;
            NapraviRasporedButton.Visibility = Visibility.Visible;
            OdeljenjaButton.Visibility = Visibility.Visible;
            naslovLabel.Visibility = Visibility.Hidden;
            naslovLabel1.Visibility = Visibility.Visible;
            podNaslovLabel.Visibility = Visibility.Hidden;
            podNaslovLabel1.Visibility = Visibility.Visible;
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
        }
        private void NapraviRasporedButton_Click(object sender, RoutedEventArgs e)
        {
            NazadPocetnaButton.Visibility = Visibility.Visible;
            checkboxLabel_Copy.Visibility = Visibility.Visible;
            checkboxLabel_Copy1.Visibility = Visibility.Visible;
            checkboxLabel_Copy2.Visibility = Visibility.Visible;
            checkboxLabel_Copy3.Visibility = Visibility.Visible;
            brojCheckboxaLabel.Visibility = Visibility.Visible;
            brojLutajucihLabel.Visibility = Visibility.Visible;
            lutajucaButton.Visibility = Visibility.Visible;
            checkboxLabel.Visibility = Visibility.Visible;
            NapraviRasporedButton.Visibility = Visibility.Hidden;
            OdeljenjaButton.Visibility = Visibility.Hidden;
            naslovLabel.Visibility = Visibility.Visible;
            naslovLabel1.Visibility = Visibility.Hidden;
            podNaslovLabel.Visibility = Visibility.Visible;
            podNaslovLabel1.Visibility = Visibility.Hidden;
            checked11.Visibility = Visibility.Visible;
            checked12.Visibility = Visibility.Visible;
            checked13.Visibility = Visibility.Visible;
            checked14.Visibility = Visibility.Visible;
            checked15.Visibility = Visibility.Visible;
            checked16.Visibility = Visibility.Visible;
            checked17.Visibility = Visibility.Visible;
            checked18.Visibility = Visibility.Visible;
            checked21.Visibility = Visibility.Visible;
            checked22.Visibility = Visibility.Visible;
            checked23.Visibility = Visibility.Visible;
            checked24.Visibility = Visibility.Visible;
            checked25.Visibility = Visibility.Visible;
            checked26.Visibility = Visibility.Visible;
            checked27.Visibility = Visibility.Visible;
            checked28.Visibility = Visibility.Visible;
            checked31.Visibility = Visibility.Visible;
            checked32.Visibility = Visibility.Visible;
            checked33.Visibility = Visibility.Visible;
            checked34.Visibility = Visibility.Visible;
            checked35.Visibility = Visibility.Visible;
            checked36.Visibility = Visibility.Visible;
            checked37.Visibility = Visibility.Visible;
            checked38.Visibility = Visibility.Visible;
            checked41.Visibility = Visibility.Visible;
            checked42.Visibility = Visibility.Visible;
            checked43.Visibility = Visibility.Visible;
            checked44.Visibility = Visibility.Visible;
            checked45.Visibility = Visibility.Visible;
            checked46.Visibility = Visibility.Visible;
            checked47.Visibility = Visibility.Visible;
            checked48.Visibility = Visibility.Visible;
        }
        private void NazadRasporedButton_Click(object sender, RoutedEventArgs e)
        {
            NazadPocetnaButton.Visibility = Visibility.Visible;
            NazadRasporedButton.Visibility = Visibility.Hidden;
            legendaTextBlock.Visibility = Visibility.Hidden;
            noviwindowButton.Visibility = Visibility.Hidden;
            lutajucaButton.Visibility = Visibility.Visible;
            checkboxLabel.Content = "Изаберите лутајућа одељења: ";
            label11.Visibility = Visibility.Hidden;
            label12.Visibility = Visibility.Hidden;
            label13.Visibility = Visibility.Hidden;
            label14.Visibility = Visibility.Hidden;
            label15.Visibility = Visibility.Hidden;
            label16.Visibility = Visibility.Hidden;
            label17.Visibility = Visibility.Hidden;
            label18.Visibility = Visibility.Hidden;
            label21.Visibility = Visibility.Hidden;
            label22.Visibility = Visibility.Hidden;
            label23.Visibility = Visibility.Hidden;
            label24.Visibility = Visibility.Hidden;
            label25.Visibility = Visibility.Hidden;
            label26.Visibility = Visibility.Hidden;
            label27.Visibility = Visibility.Hidden;
            label28.Visibility = Visibility.Hidden;
            label31.Visibility = Visibility.Hidden;
            label32.Visibility = Visibility.Hidden;
            label33.Visibility = Visibility.Hidden;
            label34.Visibility = Visibility.Hidden;
            label35.Visibility = Visibility.Hidden;
            label36.Visibility = Visibility.Hidden;
            label37.Visibility = Visibility.Hidden;
            label38.Visibility = Visibility.Hidden;
            label41.Visibility = Visibility.Hidden;
            label42.Visibility = Visibility.Hidden;
            label43.Visibility = Visibility.Hidden;
            label44.Visibility = Visibility.Hidden;
            label45.Visibility = Visibility.Hidden;
            label46.Visibility = Visibility.Hidden;
            label47.Visibility = Visibility.Hidden;
            label48.Visibility = Visibility.Hidden;
            checked11.IsChecked = false;
            checked12.IsChecked = false;
            checked13.IsChecked = false;
            checked14.IsChecked = false;
            checked15.IsChecked = false;
            checked16.IsChecked = false;
            checked17.IsChecked = false;
            checked18.IsChecked = false;
            checked21.IsChecked = false;
            checked22.IsChecked = false;
            checked23.IsChecked = false;
            checked24.IsChecked = false;
            checked25.IsChecked = false;
            checked26.IsChecked = false;
            checked27.IsChecked = false;
            checked28.IsChecked = false;
            checked31.IsChecked = false;
            checked32.IsChecked = false;
            checked33.IsChecked = false;
            checked34.IsChecked = false;
            checked35.IsChecked = false;
            checked36.IsChecked = false;
            checked37.IsChecked = false;
            checked38.IsChecked = false;
            checked41.IsChecked = false;
            checked42.IsChecked = false;
            checked43.IsChecked = false;
            checked44.IsChecked = false;
            checked45.IsChecked = false;
            checked46.IsChecked = false;
            checked47.IsChecked = false;
            checked48.IsChecked = false;
            checked11.Visibility = Visibility.Visible;
            checked12.Visibility = Visibility.Visible;
            checked13.Visibility = Visibility.Visible;
            checked14.Visibility = Visibility.Visible;
            checked15.Visibility = Visibility.Visible;
            checked16.Visibility = Visibility.Visible;
            checked17.Visibility = Visibility.Visible;
            checked18.Visibility = Visibility.Visible;
            checked21.Visibility = Visibility.Visible;
            checked22.Visibility = Visibility.Visible;
            checked23.Visibility = Visibility.Visible;
            checked24.Visibility = Visibility.Visible;
            checked25.Visibility = Visibility.Visible;
            checked26.Visibility = Visibility.Visible;
            checked27.Visibility = Visibility.Visible;
            checked28.Visibility = Visibility.Visible;
            checked31.Visibility = Visibility.Visible;
            checked32.Visibility = Visibility.Visible;
            checked33.Visibility = Visibility.Visible;
            checked34.Visibility = Visibility.Visible;
            checked35.Visibility = Visibility.Visible;
            checked36.Visibility = Visibility.Visible;
            checked37.Visibility = Visibility.Visible;
            checked38.Visibility = Visibility.Visible;
            checked41.Visibility = Visibility.Visible;
            checked42.Visibility = Visibility.Visible;
            checked43.Visibility = Visibility.Visible;
            checked44.Visibility = Visibility.Visible;
            checked45.Visibility = Visibility.Visible;
            checked46.Visibility = Visibility.Visible;
            checked47.Visibility = Visibility.Visible;
            checked48.Visibility = Visibility.Visible;
            textbox11.Visibility = Visibility.Hidden;
            textbox12.Visibility = Visibility.Hidden;
            textbox13.Visibility = Visibility.Hidden;
            textbox14.Visibility = Visibility.Hidden;
            textbox15.Visibility = Visibility.Hidden;
            textbox16.Visibility = Visibility.Hidden;
            textbox17.Visibility = Visibility.Hidden;
            textbox18.Visibility = Visibility.Hidden;
            textbox21.Visibility = Visibility.Hidden;
            textbox22.Visibility = Visibility.Hidden;
            textbox23.Visibility = Visibility.Hidden;
            textbox24.Visibility = Visibility.Hidden;
            textbox25.Visibility = Visibility.Hidden;
            textbox26.Visibility = Visibility.Hidden;
            textbox27.Visibility = Visibility.Hidden;
            textbox28.Visibility = Visibility.Hidden;
            textbox31.Visibility = Visibility.Hidden;
            textbox32.Visibility = Visibility.Hidden;
            textbox33.Visibility = Visibility.Hidden;
            textbox34.Visibility = Visibility.Hidden;
            textbox35.Visibility = Visibility.Hidden;
            textbox36.Visibility = Visibility.Hidden;
            textbox37.Visibility = Visibility.Hidden;
            textbox38.Visibility = Visibility.Hidden;
            textbox41.Visibility = Visibility.Hidden;
            textbox42.Visibility = Visibility.Hidden;
            textbox43.Visibility = Visibility.Hidden;
            textbox44.Visibility = Visibility.Hidden;
            textbox45.Visibility = Visibility.Hidden;
            textbox46.Visibility = Visibility.Hidden;
            textbox47.Visibility = Visibility.Hidden;
            textbox48.Visibility = Visibility.Hidden;
        }
        private void lutajucaButton_Click(object sender, RoutedEventArgs e)
        {
            NazadPocetnaButton.Visibility = Visibility.Hidden;
            NazadRasporedButton.Visibility = Visibility.Visible;
            legendaTextBlock.Visibility = Visibility.Visible;
            noviwindowButton.Visibility = Visibility.Visible;
            lutajucaButton.Visibility = Visibility.Hidden;
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
            //try
            //{
            viewModel.boxovi = new List<string>() {textbox11.Text, textbox12.Text, textbox13.Text, textbox14.Text,
                textbox15.Text, textbox16.Text, textbox17.Text, textbox18.Text,
                textbox21.Text, textbox22.Text, textbox23.Text, textbox24.Text,
                textbox25.Text, textbox26.Text, textbox27.Text, textbox28.Text,
                textbox31.Text, textbox32.Text, textbox33.Text, textbox34.Text,
                textbox35.Text, textbox36.Text, textbox37.Text, textbox38.Text,
                textbox41.Text, textbox42.Text, textbox43.Text, textbox44.Text,
                textbox45.Text, textbox46.Text, textbox47.Text, textbox48.Text};
            MainWindow mainWindow = new MainWindow(viewModel);
            mainWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            mainWindow.Show();
            Close();
            /*}
            catch (Exception ex)
            {
                MessageBox.Show("Doslo je do problema, proverite da li postoji resenje za odgovarajuci izbor lutajucih ucionica!\nGreska: " + ex.Message, "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }*/
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
                    textbox23.Text = "";
                    textbox23.IsEnabled = true;
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
                case "checked34":
                    viewModel.Checked34 = false;
                    textbox34.Text = "";
                    textbox34.IsEnabled = true;
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

        private void IzmeniOdeljenjeButton_Click(object sender, RoutedEventArgs e)
        {
            string[] brojeviUcionice = new string[32];
            MessageBox.Show("Успешно сте изменили величину одељења!", "Зоки", MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK);

            brojeviUcionice[0] = OdeljenjeTextbox11.Text;
            brojeviUcionice[1] = OdeljenjeTextbox12.Text;
            brojeviUcionice[2] = OdeljenjeTextbox13.Text;
            brojeviUcionice[3] = OdeljenjeTextbox14.Text;
            brojeviUcionice[4] = OdeljenjeTextbox15.Text;
            brojeviUcionice[5] = OdeljenjeTextbox16.Text;
            brojeviUcionice[6] = OdeljenjeTextbox17.Text;
            brojeviUcionice[7] = OdeljenjeTextbox18.Text;
            brojeviUcionice[8] = OdeljenjeTextbox21.Text;
            brojeviUcionice[9] = OdeljenjeTextbox22.Text;
            brojeviUcionice[10] = OdeljenjeTextbox23.Text;
            brojeviUcionice[11] = OdeljenjeTextbox24.Text;
            brojeviUcionice[12] = OdeljenjeTextbox25.Text;
            brojeviUcionice[13] = OdeljenjeTextbox26.Text;
            brojeviUcionice[14] = OdeljenjeTextbox27.Text;
            brojeviUcionice[15] = OdeljenjeTextbox28.Text;
            brojeviUcionice[16] = OdeljenjeTextbox31.Text;
            brojeviUcionice[17] = OdeljenjeTextbox32.Text;
            brojeviUcionice[18] = OdeljenjeTextbox33.Text;
            brojeviUcionice[19] = OdeljenjeTextbox34.Text;
            brojeviUcionice[20] = OdeljenjeTextbox35.Text;
            brojeviUcionice[21] = OdeljenjeTextbox36.Text;
            brojeviUcionice[22] = OdeljenjeTextbox37.Text;
            brojeviUcionice[23] = OdeljenjeTextbox38.Text;
            brojeviUcionice[24] = OdeljenjeTextbox41.Text;
            brojeviUcionice[25] = OdeljenjeTextbox42.Text;
            brojeviUcionice[26] = OdeljenjeTextbox43.Text;
            brojeviUcionice[27] = OdeljenjeTextbox44.Text;
            brojeviUcionice[28] = OdeljenjeTextbox45.Text;
            brojeviUcionice[29] = OdeljenjeTextbox46.Text;
            brojeviUcionice[30] = OdeljenjeTextbox47.Text;
            brojeviUcionice[31] = OdeljenjeTextbox48.Text;

            File.WriteAllLines("BrojUcenikaUOdeljenjimaXLS.csv", brojeviUcionice);
            Odeljenje();
            OdeljenjecheckboxLabel.Visibility = Visibility.Hidden;
            IzmeniOdeljenjeButton.Visibility = Visibility.Hidden;
            NazadOdeljenjeButton.Visibility = Visibility.Hidden;
            OdeljenjaButton.Visibility = Visibility.Visible;
            NapraviRasporedButton.Visibility = Visibility.Visible;
            naslovLabel.Visibility = Visibility.Hidden;
            naslovLabel1.Visibility = Visibility.Visible;
            podNaslovLabel.Visibility = Visibility.Hidden;
            podNaslovLabel1.Visibility = Visibility.Visible;
            OdeljenjeTextbox11.Visibility = Visibility.Hidden;
            OdeljenjeTextbox12.Visibility = Visibility.Hidden;
            OdeljenjeTextbox13.Visibility = Visibility.Hidden;
            OdeljenjeTextbox14.Visibility = Visibility.Hidden;
            OdeljenjeTextbox15.Visibility = Visibility.Hidden;
            OdeljenjeTextbox16.Visibility = Visibility.Hidden;
            OdeljenjeTextbox17.Visibility = Visibility.Hidden;
            OdeljenjeTextbox18.Visibility = Visibility.Hidden;
            OdeljenjeTextbox21.Visibility = Visibility.Hidden;
            OdeljenjeTextbox22.Visibility = Visibility.Hidden;
            OdeljenjeTextbox23.Visibility = Visibility.Hidden;
            OdeljenjeTextbox24.Visibility = Visibility.Hidden;
            OdeljenjeTextbox25.Visibility = Visibility.Hidden;
            OdeljenjeTextbox26.Visibility = Visibility.Hidden;
            OdeljenjeTextbox27.Visibility = Visibility.Hidden;
            OdeljenjeTextbox28.Visibility = Visibility.Hidden;
            OdeljenjeTextbox31.Visibility = Visibility.Hidden;
            OdeljenjeTextbox32.Visibility = Visibility.Hidden;
            OdeljenjeTextbox33.Visibility = Visibility.Hidden;
            OdeljenjeTextbox34.Visibility = Visibility.Hidden;
            OdeljenjeTextbox35.Visibility = Visibility.Hidden;
            OdeljenjeTextbox36.Visibility = Visibility.Hidden;
            OdeljenjeTextbox37.Visibility = Visibility.Hidden;
            OdeljenjeTextbox38.Visibility = Visibility.Hidden;
            OdeljenjeTextbox41.Visibility = Visibility.Hidden;
            OdeljenjeTextbox42.Visibility = Visibility.Hidden;
            OdeljenjeTextbox43.Visibility = Visibility.Hidden;
            OdeljenjeTextbox44.Visibility = Visibility.Hidden;
            OdeljenjeTextbox45.Visibility = Visibility.Hidden;
            OdeljenjeTextbox46.Visibility = Visibility.Hidden;
            OdeljenjeTextbox47.Visibility = Visibility.Hidden;
            OdeljenjeTextbox48.Visibility = Visibility.Hidden;
            OdeljenjeLabel11.Visibility = Visibility.Hidden;
            OdeljenjeLabel12.Visibility = Visibility.Hidden;
            OdeljenjeLabel13.Visibility = Visibility.Hidden;
            OdeljenjeLabel14.Visibility = Visibility.Hidden;
            OdeljenjeLabel15.Visibility = Visibility.Hidden;
            OdeljenjeLabel16.Visibility = Visibility.Hidden;
            OdeljenjeLabel17.Visibility = Visibility.Hidden;
            OdeljenjeLabel18.Visibility = Visibility.Hidden;
            OdeljenjeLabel21.Visibility = Visibility.Hidden;
            OdeljenjeLabel22.Visibility = Visibility.Hidden;
            OdeljenjeLabel23.Visibility = Visibility.Hidden;
            OdeljenjeLabel24.Visibility = Visibility.Hidden;
            OdeljenjeLabel25.Visibility = Visibility.Hidden;
            OdeljenjeLabel26.Visibility = Visibility.Hidden;
            OdeljenjeLabel27.Visibility = Visibility.Hidden;
            OdeljenjeLabel28.Visibility = Visibility.Hidden;
            OdeljenjeLabel31.Visibility = Visibility.Hidden;
            OdeljenjeLabel32.Visibility = Visibility.Hidden;
            OdeljenjeLabel33.Visibility = Visibility.Hidden;
            OdeljenjeLabel34.Visibility = Visibility.Hidden;
            OdeljenjeLabel35.Visibility = Visibility.Hidden;
            OdeljenjeLabel36.Visibility = Visibility.Hidden;
            OdeljenjeLabel37.Visibility = Visibility.Hidden;
            OdeljenjeLabel37.Visibility = Visibility.Hidden;
            OdeljenjeLabel38.Visibility = Visibility.Hidden;
            OdeljenjeLabel41.Visibility = Visibility.Hidden;
            OdeljenjeLabel42.Visibility = Visibility.Hidden;
            OdeljenjeLabel43.Visibility = Visibility.Hidden;
            OdeljenjeLabel44.Visibility = Visibility.Hidden;
            OdeljenjeLabel45.Visibility = Visibility.Hidden;
            OdeljenjeLabel46.Visibility = Visibility.Hidden;
            OdeljenjeLabel47.Visibility = Visibility.Hidden;
            OdeljenjeLabel48.Visibility = Visibility.Hidden;

        }
    }
}
