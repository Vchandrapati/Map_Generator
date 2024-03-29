﻿#pragma checksum "..\..\..\Generators\Maze_Generator.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DDFD2EBC83B3356204E1F27DB6DBB114E14C57E08C380936D806E12674867085"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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


namespace Map_Generator.Generators {
    
    
    /// <summary>
    /// MazeGenerator
    /// </summary>
    public partial class MazeGenerator : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\Generators\Maze_Generator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image MapView;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Generators\Maze_Generator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackToMenu;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Generators\Maze_Generator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas MenuBar;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Generators\Maze_Generator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Close;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Generators\Maze_Generator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas Canvas;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Generators\Maze_Generator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Minimize;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Generators\Maze_Generator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Generate;
        
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
            System.Uri resourceLocater = new System.Uri("/Map_Generator;component/generators/maze_generator.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Generators\Maze_Generator.xaml"
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
            this.MapView = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.BackToMenu = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\Generators\Maze_Generator.xaml"
            this.BackToMenu.Click += new System.Windows.RoutedEventHandler(this.BtnBack);
            
            #line default
            #line hidden
            return;
            case 3:
            this.MenuBar = ((System.Windows.Controls.Canvas)(target));
            return;
            case 4:
            this.Close = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\Generators\Maze_Generator.xaml"
            this.Close.Click += new System.Windows.RoutedEventHandler(this.BtnClose);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Canvas = ((System.Windows.Controls.Canvas)(target));
            return;
            case 6:
            this.Minimize = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\Generators\Maze_Generator.xaml"
            this.Minimize.Click += new System.Windows.RoutedEventHandler(this.BtnMinimize);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Generate = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\Generators\Maze_Generator.xaml"
            this.Generate.Click += new System.Windows.RoutedEventHandler(this.BtnGenerate);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

