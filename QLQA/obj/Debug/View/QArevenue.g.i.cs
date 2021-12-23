﻿#pragma checksum "..\..\..\View\QArevenue.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6868EB6FE1D8F18B08839F1D97D4D3DBE47898F3340A85018FB0562AD0F7D441"
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
using QLQA.Command;
using QLQA.View;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace QLQA.View {
    
    
    /// <summary>
    /// QArevenue
    /// </summary>
    public partial class QArevenue : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\View\QArevenue.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Home;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\View\QArevenue.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Exit;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\View\QArevenue.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Minimize;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\View\QArevenue.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btStatistical;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\View\QArevenue.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btExcell;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\View\QArevenue.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpDayfrom;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\View\QArevenue.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpDateto;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\View\QArevenue.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid lvRevenue;
        
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
            System.Uri resourceLocater = new System.Uri("/QLQA;component/view/qarevenue.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\QArevenue.xaml"
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
            this.Home = ((System.Windows.Controls.Button)(target));
            return;
            case 2:
            this.Exit = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.Minimize = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.btStatistical = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\..\View\QArevenue.xaml"
            this.btStatistical.Click += new System.Windows.RoutedEventHandler(this.btStatistical_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btExcell = ((System.Windows.Controls.Button)(target));
            
            #line 84 "..\..\..\View\QArevenue.xaml"
            this.btExcell.Click += new System.Windows.RoutedEventHandler(this.btExcel_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.dpDayfrom = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.dpDateto = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.lvRevenue = ((System.Windows.Controls.DataGrid)(target));
            
            #line 103 "..\..\..\View\QArevenue.xaml"
            this.lvRevenue.Loaded += new System.Windows.RoutedEventHandler(this.lvRevenue_Loaded);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

