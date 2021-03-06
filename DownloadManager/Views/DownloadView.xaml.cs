﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
using DownloadManager.ViewModels;

namespace DownloadManager.Views
{
    /// <summary>
    /// Interaction logic for DownloadView.xaml
    /// </summary>
    public partial class DownloadView : Window
    {
        public DownloadView(HomeViewModel homeViewModel, string url)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            var downloadViewModel = new DownloadViewModel(homeViewModel, url);
            DataContext = downloadViewModel;
            downloadViewModel.Closing += (s, e) => Close();
        }
    }
}
