﻿#pragma checksum "..\..\..\..\..\FranpetteWindow\HomeControls\TopBar\TBar.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "42E0C92FF058AB9B78295B5B87B617720BD740738D38BF85A7F30E511F9D37E7"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace FranpetteClient.FranpetteWindow.HomeControls.TopBar {
    
    
    /// <summary>
    /// TBar
    /// </summary>
    public partial class TBar : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\..\..\FranpetteWindow\HomeControls\TopBar\TBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem test_upload;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\FranpetteWindow\HomeControls\TopBar\TBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem test_download;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\FranpetteWindow\HomeControls\TopBar\TBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem test_utils;
        
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
            System.Uri resourceLocater = new System.Uri("/FranpetteClient;component/franpettewindow/homecontrols/topbar/tbar.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\FranpetteWindow\HomeControls\TopBar\TBar.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            this.test_upload = ((System.Windows.Controls.MenuItem)(target));
            
            #line 27 "..\..\..\..\..\FranpetteWindow\HomeControls\TopBar\TBar.xaml"
            this.test_upload.Click += new System.Windows.RoutedEventHandler(this.test_upload_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.test_download = ((System.Windows.Controls.MenuItem)(target));
            
            #line 28 "..\..\..\..\..\FranpetteWindow\HomeControls\TopBar\TBar.xaml"
            this.test_download.Click += new System.Windows.RoutedEventHandler(this.test_download_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.test_utils = ((System.Windows.Controls.MenuItem)(target));
            
            #line 29 "..\..\..\..\..\FranpetteWindow\HomeControls\TopBar\TBar.xaml"
            this.test_utils.Click += new System.Windows.RoutedEventHandler(this.test_utils_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

