// Updated by XamlIntelliSenseFileGenerator 11/25/2021 2:04:01 AM
#pragma checksum "..\..\Food.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E86306EC7DA5DA954E294F7A3D3B965C99184B4590B9FD30B3A67EA62D45A7F8"
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


namespace UI
{


    /// <summary>
    /// food
    /// </summary>
    public partial class food : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden


#line 87 "..\..\Food.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Home;

#line default
#line hidden


#line 96 "..\..\Food.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Exit;

#line default
#line hidden


#line 106 "..\..\Food.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Minimize;

#line default
#line hidden


#line 125 "..\..\Food.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSearch;

#line default
#line hidden


#line 128 "..\..\Food.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btSearch;

#line default
#line hidden


#line 147 "..\..\Food.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbCate;

#line default
#line hidden


#line 164 "..\..\Food.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPrice;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/QLQA;component/food.xaml", System.UriKind.Relative);

#line 1 "..\..\Food.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.lvAccount = ((System.Windows.Controls.ListView)(target));
                    return;
                case 2:
                    this.them = ((System.Windows.Controls.Button)(target));
                    return;
                case 3:
                    this.xoa = ((System.Windows.Controls.Button)(target));
                    return;
                case 4:
                    this.sua = ((System.Windows.Controls.Button)(target));
                    return;
                case 5:
                    this.xem = ((System.Windows.Controls.Button)(target));
                    return;
                case 6:
                    this.Home = ((System.Windows.Controls.Button)(target));

#line 90 "..\..\Food.xaml"
                    this.Home.Click += new System.Windows.RoutedEventHandler(this.Home_Click);

#line default
#line hidden
                    return;
                case 7:
                    this.Exit = ((System.Windows.Controls.Button)(target));

#line 100 "..\..\Food.xaml"
                    this.Exit.Click += new System.Windows.RoutedEventHandler(this.Exit_Click);

#line default
#line hidden
                    return;
                case 8:
                    this.Minimize = ((System.Windows.Controls.Button)(target));

#line 110 "..\..\Food.xaml"
                    this.Minimize.Click += new System.Windows.RoutedEventHandler(this.Minimize_Click);

#line default
#line hidden
                    return;
                case 9:
                    this.tbSearch = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 10:
                    this.btSearch = ((System.Windows.Controls.Button)(target));

#line 132 "..\..\Food.xaml"
                    this.btSearch.Click += new System.Windows.RoutedEventHandler(this.btSearch_Click);

#line default
#line hidden
                    return;
                case 11:
                    this.ID = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 12:
                    this.Foodname = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 13:
                    this.cbCate = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 14:
                    this.tbPrice = ((System.Windows.Controls.TextBox)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.ListView lvFood;
        internal System.Windows.Controls.Button btAdd;
        internal System.Windows.Controls.Button btDelete;
        internal System.Windows.Controls.Button btView;
        internal System.Windows.Controls.TextBox tbID;
        internal System.Windows.Controls.TextBox tbFoodname;
        internal System.Windows.Controls.Button btUpdate;
    }
}

