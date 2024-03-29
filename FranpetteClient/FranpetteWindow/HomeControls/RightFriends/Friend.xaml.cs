﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace FranpetteClient.FranpetteWindow.HomeControls.RightFriends
{
    /// <summary>
    /// Logique d'interaction pour Friend.xaml
    /// </summary>
    public partial class Friend : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _fName;
        public string FName
        {
            get { return _fName; }
            set
            {
                _fName = value;
                OnPropertyChanged("FName");
            }
        }

        private bool _fOnline;
        public bool FOnline
        {
            get { return _fOnline; }
            set
            {
                _fOnline = value;
                OnPropertyChanged("FOnline");
            }
        }

        private bool _fAfk;
        public bool FAfk
        {
            get { return _fAfk; }
            set
            {
                _fAfk = value;
                OnPropertyChanged("FAfk");
            }
        }

        private string _statusIcon;
        public string StatusIcon
        {
            get
            {
                if (FOnline)
                    return (FAfk) ? "⚫" : "⚫";
                else
                    return "⚪";
            }
            set
            {
                _statusIcon = value;
                OnPropertyChanged("StatusIcon");
            }
        }

        private string _statusDesc;
        public string StatusDesc
        {
            get
            {
                if (FOnline)
                    return (FAfk) ? "Absent" : "En ligne";
                else
                    return "Hors ligne";
            }
            set
            {
                _statusDesc = value;
                OnPropertyChanged("FOnline");
            }
        }

        public Brush StatusIconColor
        {
            get
            {
                if (FOnline)
                    return (FAfk) ? (Brush)(new BrushConverter().ConvertFrom("#FFB400")) : (Brush)(new BrushConverter().ConvertFrom("#00FF00"));
                else
                    return (Brush)(new BrushConverter().ConvertFrom("#808e9b"));
            }
        }

        public Brush StatusNameColor
        {
            get { return (FOnline) ? (Brush)(new BrushConverter().ConvertFrom("#0fbcf9")) : (Brush)(new BrushConverter().ConvertFrom("#808e9b")); }
        }

        public Friend(string name, bool online = true, bool afk = false)
        {
            InitializeComponent();
            DataContext = this;

            FName = name;
            FOnline = online;
            FAfk = afk;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
