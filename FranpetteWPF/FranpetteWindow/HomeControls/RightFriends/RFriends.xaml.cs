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
        private static Thickness RightPushed = new Thickness(0, 0, -250, 0);
        private static Thickness NotPushed = new Thickness(0);

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
            DependencyProperty.Register("RightMargin", typeof(Thickness), typeof(RFriends), new PropertyMetadata(RightPushed));

        private BackEase backEase = new BackEase();
        private ThicknessAnimation showAnimation = new ThicknessAnimation(RightPushed, NotPushed, new Duration(TimeSpan.FromSeconds(0.5)));
        private ThicknessAnimation hideAnimation = new ThicknessAnimation(NotPushed, RightPushed, new Duration(TimeSpan.FromSeconds(0.5)));

        public RFriends()
        {
            InitializeComponent();
        }

        public void Show()
        {
            IsShown = true;
            backEase.EasingMode = EasingMode.EaseOut;
            showAnimation.EasingFunction = backEase;
            BeginAnimation(RightMarginProperty, showAnimation);
        }

        public void Hide()
        {
            IsShown = false;
            backEase.EasingMode = EasingMode.EaseIn;
            hideAnimation.EasingFunction = backEase;
            BeginAnimation(RightMarginProperty, hideAnimation);
        }
    }
}
