﻿#pragma checksum "..\..\..\..\FranpetteWindow\HomeControls\Home.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "20A9A3582654B299B94D516C59D5CA2D1797462C8987383913917F9BE29C0060"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using FranpetteClient.FranpetteWindow.HomeControls.BottomBar;
using FranpetteClient.FranpetteWindow.HomeControls.MenuBar;
using FranpetteClient.FranpetteWindow.HomeControls.RightFriends;
using FranpetteClient.FranpetteWindow.HomeControls.TopBar;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace FranpetteClient.FranpetteWindow.HomeControls {
    
    
    /// <summary>
    /// Home
    /// </summary>
    public partial class Home : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\FranpetteWindow\HomeControls\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Root_HomeGrid;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\FranpetteWindow\HomeControls\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FranpetteClient.FranpetteWindow.HomeControls.TopBar.TBar UCTBar;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\FranpetteWindow\HomeControls\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FranpetteClient.FranpetteWindow.HomeControls.MenuBar.MBar UCMBar;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\FranpetteWindow\HomeControls\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FranpetteClient.FranpetteWindow.HomeControls.RightFriends.RFriends UCRFriends;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\FranpetteWindow\HomeControls\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FranpetteClient.FranpetteWindow.HomeControls.BottomBar.BBar UCBBar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FranpetteClient;component/franpettewindow/homecontrols/home.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\FranpetteWindow\HomeControls\Home.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\..\FranpetteWindow\HomeControls\Home.xaml"
            ((FranpetteClient.FranpetteWindow.HomeControls.Home)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Root_HomeGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.UCTBar = ((FranpetteClient.FranpetteWindow.HomeControls.TopBar.TBar)(target));
            return;
            case 4:
            this.UCMBar = ((FranpetteClient.FranpetteWindow.HomeControls.MenuBar.MBar)(target));
            return;
            case 5:
            this.UCRFriends = ((FranpetteClient.FranpetteWindow.HomeControls.RightFriends.RFriends)(target));
            return;
            case 6:
            this.UCBBar = ((FranpetteClient.FranpetteWindow.HomeControls.BottomBar.BBar)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
