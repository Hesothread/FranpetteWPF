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

namespace FranpetteWPF.FranpetteWindow.HomeControls.CenterServerList
{
    /// <summary>
    /// Logique d'interaction pour CServerList.xaml
    /// </summary>
    public partial class CServerList : UserControl
    {
        private CServerListDataContext _context = new CServerListDataContext();

        public CServerList()
        {
            InitializeComponent();
            DataContext = _context;
            _context.ServerList.Add(new CServer());
            _context.ServerList.Add(new CServer());
            _context.ServerList.Add(new CServer());
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CServer server = sender as CServer;
        }
    }
}
