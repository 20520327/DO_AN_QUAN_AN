﻿#pragma checksum "..\..\Maintable.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "52DB6DB3E7816AE469BB1B6F99241C7FF67951B53959BD75D086FE538DEB659D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using UI;


namespace UI {
    
    
    /// <summary>
    /// maintable
    /// </summary>
    public partial class maintable : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\Maintable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Mainform;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Maintable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Home;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\Maintable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btExit;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\Maintable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Minimize;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\Maintable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btOrder;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\Maintable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btEmployee;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\Maintable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btTable;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\Maintable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btList;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\Maintable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btFood;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\Maintable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btHistory;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\Maintable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btAccount;
        
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
            System.Uri resourceLocater = new System.Uri("/QLQA;component/maintable.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Maintable.xaml"
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
            this.Mainform = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.Home = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\Maintable.xaml"
            this.Home.Click += new System.Windows.RoutedEventHandler(this.Home_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btExit = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\Maintable.xaml"
            this.btExit.Click += new System.Windows.RoutedEventHandler(this.Exit_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Minimize = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\Maintable.xaml"
            this.Minimize.Click += new System.Windows.RoutedEventHandler(this.Minimize_Click_1);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btOrder = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\Maintable.xaml"
            this.btOrder.Click += new System.Windows.RoutedEventHandler(this.btOrder_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btEmployee = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\Maintable.xaml"
            this.btEmployee.Click += new System.Windows.RoutedEventHandler(this.btEmployee_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btTable = ((System.Windows.Controls.Button)(target));
            
            #line 96 "..\..\Maintable.xaml"
            this.btTable.Click += new System.Windows.RoutedEventHandler(this.btTable_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btList = ((System.Windows.Controls.Button)(target));
            
            #line 104 "..\..\Maintable.xaml"
            this.btList.Click += new System.Windows.RoutedEventHandler(this.btList_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btFood = ((System.Windows.Controls.Button)(target));
            
            #line 116 "..\..\Maintable.xaml"
            this.btFood.Click += new System.Windows.RoutedEventHandler(this.btFood_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btHistory = ((System.Windows.Controls.Button)(target));
            
            #line 124 "..\..\Maintable.xaml"
            this.btHistory.Click += new System.Windows.RoutedEventHandler(this.btHistory_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btAccount = ((System.Windows.Controls.Button)(target));
            
            #line 133 "..\..\Maintable.xaml"
            this.btAccount.Click += new System.Windows.RoutedEventHandler(this.btAccount_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

