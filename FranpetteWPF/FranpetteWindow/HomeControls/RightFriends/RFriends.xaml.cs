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
        private RFriendsDataContext _context = new RFriendsDataContext();

        public static readonly DependencyProperty IsShownProperty = DependencyProperty.Register("IsShown", typeof(bool), typeof(RFriends), new PropertyMetadata(false));
        public static readonly DependencyProperty RightMarginProperty = DependencyProperty.Register("RightMargin", typeof(Thickness), typeof(RFriends), new PropertyMetadata(new Thickness(0, 0, -300, 0)));

        public bool IsShown
        {
            get { return (bool)GetValue(IsShownProperty); }
            set { SetValue(IsShownProperty, value); }
        }
        public Thickness RightMargin
        {
            get { return (Thickness)GetValue(RightMarginProperty); }
            set { SetValue(RightMarginProperty, value); }
        }

        private BackEase backEase = new BackEase();
        private ThicknessAnimation showAnimation;
        private ThicknessAnimation hideAnimation;

        public RFriends()
        {
            InitializeComponent();
            DataContext = _context;
            showAnimation = new ThicknessAnimation(new Thickness(0, 0, -300, 0), new Thickness(0), new Duration(TimeSpan.FromSeconds(0.25)));
            hideAnimation = new ThicknessAnimation(new Thickness(0), new Thickness(0, 0, -300, 0), new Duration(TimeSpan.FromSeconds(0.25)));

            _context.FriendList.Add(new RFriend("Marc Alexandre"));
            _context.FriendList.Add(new RFriend("Hugo Menard", true, true));
            _context.FriendList.Add(new RFriend("SamSam", false));
            _context.FriendList.Add(new RFriend("Méowin", false));
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
