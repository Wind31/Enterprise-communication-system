﻿#pragma checksum "..\..\OneToOne.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "282A1319A98F222505D2B5A26383766DA90C383C"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Enterprise_communication;
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


namespace Enterprise_communication {
    
    
    /// <summary>
    /// OneToOne
    /// </summary>
    public partial class OneToOne : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\OneToOne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label chattingname;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\OneToOne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCheckRe;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\OneToOne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\OneToOne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer textscroll;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\OneToOne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox sendmsg;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\OneToOne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSendFile;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\OneToOne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSendMessage;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\OneToOne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer msgscroll;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\OneToOne.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ShowMessage;
        
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
            System.Uri resourceLocater = new System.Uri("/Enterprise_communication;component/onetoone.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\OneToOne.xaml"
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
            
            #line 8 "..\..\OneToOne.xaml"
            ((Enterprise_communication.OneToOne)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.chattingname = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.btnCheckRe = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\OneToOne.xaml"
            this.btnCheckRe.Click += new System.Windows.RoutedEventHandler(this.btnCheckRe_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\OneToOne.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.btnBack_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.textscroll = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 6:
            this.sendmsg = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btnSendFile = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\OneToOne.xaml"
            this.btnSendFile.Click += new System.Windows.RoutedEventHandler(this.btnSendFile_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnSendMessage = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\OneToOne.xaml"
            this.btnSendMessage.Click += new System.Windows.RoutedEventHandler(this.btnSendMessage_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.msgscroll = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 10:
            this.ShowMessage = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

