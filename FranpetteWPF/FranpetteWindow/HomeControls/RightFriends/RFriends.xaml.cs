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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FranpetteWPF.FranpetteWindow.HomeControls.RightFriends
{
    /// <summary>
    /// Logique d'interaction pour RFriends.xaml
    /// </summary>
    public partial class RFriends : UserControl
    {
        public bool IsShown
        {
            get { return (bool)GetValue(IsShownProperty); }
            set { SetValue(IsShownProperty, value); }
        }

        public static readonly DependencyProperty IsShownProperty =
            DependencyProperty.Register("IsShown", typeof(bool), typeof(RFriends), new PropertyMetadata(false));

        public Thickness RightMargin
        {
            get { return (Thickness)GetValue(RightMarginProperty); }
            set { SetValue(RightMarginProperty, value); }
        }

        public static readonly DependencyProperty RightMarginProperty =
            DependencyProperty.Register("RightMargin", typeof(Thickness), typeof(RFriends), new PropertyMetadata(new Thickness(0, 0, -200, 0)));

        private ThicknessAnimation showAnimation = new ThicknessAnimation(new Thickness(0, 0, -200, 0), new Thickness(0), new Duration(TimeSpan.FromSeconds(0.15)));
        private ThicknessAnimation hideAnimation = new ThicknessAnimation(new Thickness(0), new Thickness(0, 0, -200, 0), new Duration(TimeSpan.FromSeconds(0.15)));

        public RFriends()
        {
            InitializeComponent();
        }

        public void Show()
        {
            IsShown = true;
            BeginAnimation(RightMarginProperty, showAnimation);
        }

        public void Hide()
        {
            IsShown = false;
            BeginAnimation(RightMarginProperty, hideAnimation);
        }
    }
}
