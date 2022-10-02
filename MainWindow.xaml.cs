﻿using System.Collections.ObjectModel;
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

        
        public MainWindow()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
           /* DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            DataTable dt5 = new DataTable();*/
            int nbColumns = 32;
            int nbRows = 8;
            MainPageViewModel viewModel = new MainPageViewModel();
            //dt.Columns.Add("");
            for (int i = 0; i < nbColumns; i++)
            {
                dt.Columns.Add((i/8+1).ToString() + "-" + (i % 8 + 1).ToString(), typeof(string));
                dt2.Columns.Add((i / 8 + 1).ToString() + "-" + (i % 8 + 1).ToString(), typeof(string));
                /*dt3.Columns.Add((i / 8 + 1).ToString() + "-" + (i % 8 + 1).ToString(), typeof(string));
                dt4.Columns.Add((i / 8 + 1).ToString() + "-" + (i % 8 + 1).ToString(), typeof(string));
                dt5.Columns.Add((i / 8 + 1).ToString() + "-" + (i % 8 + 1).ToString(), typeof(string));*/
            }
            

            for (int row = 0; row < nbRows; row++)
            {
                //dt.Rows.Add(row.ToString() + ".cas");
                DataRow dr2 = dt2.NewRow();
                DataRow dr = dt.NewRow();
                /*DataRow dr3 = dt3.NewRow();
                DataRow dr4 = dt4.NewRow();
                DataRow dr5 = dt5.NewRow();*/
                for (int col = 0; col < nbColumns; col++)
                {
                    
                    dr[col] = viewModel.rezultatiPonedeljak[row][col];
                    dr2[col] = viewModel.rezultatiUtorak[row][col];
                    /*dr3[col] = viewModel.rezultatiSreda[row][col];
                    dr4[col] = viewModel.rezultatiCetvrtak[row][col];
                    dr5[col] = viewModel.rezultatiPetak[row][col];*/
                }
                dt.Rows.Add(dr);
                dt2.Rows.Add(dr2);
                /*dt3.Rows.Add(dr3);
                dt4.Rows.Add(dr4);
                dt5.Rows.Add(dr5);*/
            }

            rezultatiPon.ItemsSource = dt.DefaultView;
            rezultatiUto.ItemsSource = dt2.DefaultView;
           /* rezultatiSre.ItemsSource = dt3.DefaultView;
            rezultatiCet.ItemsSource = dt4.DefaultView;
            rezultatiPet.ItemsSource = dt5.DefaultView;*/
        }

    }
}
