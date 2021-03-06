﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FranpetteClient.FranpetteWindow.HomeControls.BottomBar
{
    /// <summary>
    /// Logique d'interaction pour BBar.xaml
    /// </summary>
    public partial class BBar : UserControl
    {
        private BBarDataContext _bottomBarContext;

        public BBar()
        {
            InitializeComponent();
            _bottomBarContext = new BBarDataContext();
            this.DataContext = _bottomBarContext;
        }
    }
}
