﻿#pragma checksum "C:\Users\Cactus\Desktop\EGE\EGE\Mathpract10.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "29D920FC1685DB3EBD24BEE50DAB48D8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EGE
{
    partial class Mathpract10 : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.16.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // Mathpract10.xaml line 9
                {
                    this.grid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 2: // Mathpract10.xaml line 58
                {
                    this.nameInput = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3: // Mathpract10.xaml line 59
                {
                    global::Windows.UI.Xaml.Controls.Button element3 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element3).Tapped += this.Mathpract1_Click;
                }
                break;
            case 4: // Mathpract10.xaml line 55
                {
                    this.Zadanie1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5: // Mathpract10.xaml line 41
                {
                    this.dialogBox = (global::Windows.UI.Xaml.Controls.Flyout)(target);
                }
                break;
            case 6: // Mathpract10.xaml line 44
                {
                    global::Windows.UI.Xaml.Controls.Button element6 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element6).Click += this.Rait_Click;
                }
                break;
            case 7: // Mathpract10.xaml line 45
                {
                    global::Windows.UI.Xaml.Controls.Button element7 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element7).Click += this.Menu_Click;
                }
                break;
            case 8: // Mathpract10.xaml line 46
                {
                    global::Windows.UI.Xaml.Controls.Button element8 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element8).Click += this.Exit_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.16.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

