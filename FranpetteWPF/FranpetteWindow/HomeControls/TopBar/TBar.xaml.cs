using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
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
using FranpetteWPF.Managers.Tools;

namespace FranpetteWPF.FranpetteWindow.HomeControls.TopBar
{
    /// <summary>
    /// Logique d'interaction pour TBar.xaml
    /// </summary>
    public partial class TBar : UserControl
    {
        private TBarDataContext _context = new TBarDataContext();

        public delegate void OnProgressChangeDelegate(int progressValue);
        public event OnProgressChangeDelegate OnProgressChange;

        public TBar()
        {
            InitializeComponent();
            DataContext = _context;
            
            _context.CurrentLang = "Français";
            _context.UserName = "ManuStrozor";
        }

        private void test_download_Click(object sender, RoutedEventArgs e)
        {
            WebClient Client = new WebClient();
            Client.DownloadFileAsync(new Uri("https://www.bundle-manager.com/files/b.jar"), @"C:\test\b.jar");
            Client.DownloadProgressChanged += WebClientDownloadProgressChanged;
            Client.DownloadFileCompleted += WebClientCompleted;
        }

        private void test_upload_Click(object sender, RoutedEventArgs e)
        {
            WebClient Client = new WebClient();
            Client.UploadFileAsync(new Uri("https://www.bundle-manager.com/up.php"), @"C:\test\b.jar");
            Client.UploadProgressChanged += WebClientUploadProgressChanged;
            Client.UploadFileCompleted += WebClientCompleted;
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            OnProgressChange(e.ProgressPercentage);
        }

        private void WebClientUploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            OnProgressChange(e.ProgressPercentage * 2);
        }

        private void WebClientCompleted(object sender, AsyncCompletedEventArgs e)
        {
            OnProgressChange(0);
        }

        private void test_utils_Click(object sender, RoutedEventArgs e)
        {
            Utils.doSomething();
        }
    }
}
