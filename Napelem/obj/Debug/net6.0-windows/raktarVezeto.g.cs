﻿#pragma checksum "..\..\..\raktarVezeto.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8719CA4B1C23923E4B0B7EED5DB10811A03C53C3"
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
    /// raktarVezeto
    /// </summary>
    public partial class raktarVezeto : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\raktarVezeto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button mainExitBtn;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\raktarVezeto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox assetNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\raktarVezeto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox assetPriceTextBox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\raktarVezeto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox assetMaxTextBox;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\raktarVezeto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ProductComboBox;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\raktarVezeto.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NewPriceTextBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Napelem;component/raktarvezeto.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\raktarVezeto.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.mainExitBtn = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\raktarVezeto.xaml"
            this.mainExitBtn.Click += new System.Windows.RoutedEventHandler(this.mainExitBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.assetNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.assetPriceTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.assetMaxTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            
            #line 26 "..\..\..\raktarVezeto.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ProductComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.NewPriceTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 37 "..\..\..\raktarVezeto.xaml"
            this.NewPriceTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.NewPriceTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 39 "..\..\..\raktarVezeto.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

