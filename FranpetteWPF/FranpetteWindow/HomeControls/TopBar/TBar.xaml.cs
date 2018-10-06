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

namespace FranpetteWPF.FranpetteWindow.HomeControls.TopBar
{
    /// <summary>
    /// Logique d'interaction pour TBar.xaml
    /// </summary>
    public partial class TBar : UserControl
    {
        private TBarDataContext _context = new TBarDataContext();

        public TBar()
        {
            InitializeComponent();
            DataContext = _context;
            
            _context.CurrentLang = "Français";
            _context.UserName = "ManuStrozor";
        }
    }
}
