using FranpetteWPF.FranpetteWindow.HomeControls.CenterNews;
using FranpetteWPF.FranpetteWindow.HomeControls.CenterServerList;
using FranpetteWPF.FranpetteWindow.HomeControls.CenterOptions;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FranpetteWPF.FranpetteWindow.HomeControls
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        private HomeDataContext _homeContext;

        public Home()
        {
            InitializeComponent();
            _homeContext = new HomeDataContext();
            DataContext = _homeContext;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _homeContext.CenterNews = new CNews();
            _homeContext.CenterServerList = new CServerList();
            _homeContext.CenterOptions = new COptions();

            UCTopBar.NewsUCEvent += LoadCNews;
            UCTopBar.ServerListUCEvent += LoadCServerList;
            UCTopBar.OptionsUCEvent += LoadCOptions;

            _homeContext.HomeContent = _homeContext.CenterServerList;
        }

        private void LoadCNews()
        {
            _homeContext.HomeContent = _homeContext.CenterNews;
        }

        private void LoadCServerList()
        {
            _homeContext.HomeContent = _homeContext.CenterServerList;
        }

        private void LoadCOptions()
        {
            _homeContext.HomeContent = _homeContext.CenterOptions;
        }
    }
}
