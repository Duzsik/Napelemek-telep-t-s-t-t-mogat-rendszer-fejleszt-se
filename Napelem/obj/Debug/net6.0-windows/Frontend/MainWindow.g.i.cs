﻿#pragma checksum "..\..\..\..\Frontend\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9651DA29C2D34339744D1ACF79806578DEF24156"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Napelem;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Napelem {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\Frontend\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox userTextBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Frontend\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock UserLabel;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Frontend\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PassLabel;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Frontend\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Loginbtn;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Frontend\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock titleTextBlock;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Frontend\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passwordBox;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Frontend\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox passwordTxtBox;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\Frontend\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ShowPass;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Napelem;V1.0.0.0;component/frontend/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Frontend\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\..\Frontend\MainWindow.xaml"
            ((System.Windows.Controls.Grid)(target)).ContextMenuClosing += new System.Windows.Controls.ContextMenuEventHandler(this.Grid_ContextMenuClosing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.userTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.UserLabel = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.PassLabel = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.Loginbtn = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\Frontend\MainWindow.xaml"
            this.Loginbtn.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.titleTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.passwordBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 8:
            this.passwordTxtBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.ShowPass = ((System.Windows.Controls.CheckBox)(target));
            
            #line 46 "..\..\..\..\Frontend\MainWindow.xaml"
            this.ShowPass.Checked += new System.Windows.RoutedEventHandler(this.ShowPass_Checked);
            
            #line default
            #line hidden
            
            #line 46 "..\..\..\..\Frontend\MainWindow.xaml"
            this.ShowPass.Unchecked += new System.Windows.RoutedEventHandler(this.ShowPass_Unchecked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

