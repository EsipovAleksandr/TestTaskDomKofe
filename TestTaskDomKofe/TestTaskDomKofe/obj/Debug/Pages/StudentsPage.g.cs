﻿#pragma checksum "..\..\..\Pages\StudentsPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ACA1B3881C4EA5D2B97C2763BE031E4ED41F55CA"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using TestTaskDomKofe.Model;
using TestTaskDomKofe.Pages;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;


namespace TestTaskDomKofe.Pages {
    
    
    /// <summary>
    /// StudentsPage
    /// </summary>
    public partial class StudentsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\Pages\StudentsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lstStudent;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\Pages\StudentsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbSubject;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\Pages\StudentsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbTeachers;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\Pages\StudentsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbClassFilter;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\Pages\StudentsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridCarDetails;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\..\Pages\StudentsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFIO;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\..\Pages\StudentsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker txtDateOfBirth;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\..\Pages\StudentsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAddress;
        
        #line default
        #line hidden
        
        
        #line 145 "..\..\..\Pages\StudentsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.MaskedTextBox txtPhone;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\Pages\StudentsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbClass;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\..\Pages\StudentsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtStudentId;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\..\Pages\StudentsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txMiddle;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\..\Pages\StudentsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtError;
        
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
            System.Uri resourceLocater = new System.Uri("/TestTaskDomKofe;component/pages/studentspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\StudentsPage.xaml"
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
            
            #line 12 "..\..\..\Pages\StudentsPage.xaml"
            ((TestTaskDomKofe.Pages.StudentsPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lstStudent = ((System.Windows.Controls.ListView)(target));
            
            #line 30 "..\..\..\Pages\StudentsPage.xaml"
            this.lstStudent.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lstStudent_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 102 "..\..\..\Pages\StudentsPage.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.RadioButton_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 103 "..\..\..\Pages\StudentsPage.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.RadioButtonName_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 104 "..\..\..\Pages\StudentsPage.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.RadioButtonYear_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 105 "..\..\..\Pages\StudentsPage.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.RadioButtonСlass_Checked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cbSubject = ((System.Windows.Controls.ComboBox)(target));
            
            #line 110 "..\..\..\Pages\StudentsPage.xaml"
            this.cbSubject.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbSubject_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.cbTeachers = ((System.Windows.Controls.ComboBox)(target));
            
            #line 111 "..\..\..\Pages\StudentsPage.xaml"
            this.cbTeachers.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbTeachers_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.cbClassFilter = ((System.Windows.Controls.ComboBox)(target));
            
            #line 112 "..\..\..\Pages\StudentsPage.xaml"
            this.cbClassFilter.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbClassFilter_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 113 "..\..\..\Pages\StudentsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddStudent_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 114 "..\..\..\Pages\StudentsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteStudent);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 115 "..\..\..\Pages\StudentsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdateStudent_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.gridCarDetails = ((System.Windows.Controls.Grid)(target));
            return;
            case 14:
            this.txtFIO = ((System.Windows.Controls.TextBox)(target));
            return;
            case 15:
            this.txtDateOfBirth = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 16:
            this.txtAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 17:
            this.txtPhone = ((Xceed.Wpf.Toolkit.MaskedTextBox)(target));
            return;
            case 18:
            this.cbClass = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 19:
            this.txtStudentId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 20:
            this.txMiddle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 21:
            this.txtError = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

