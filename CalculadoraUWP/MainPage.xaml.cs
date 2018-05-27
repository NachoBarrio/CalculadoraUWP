using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace CalculadoraUWP
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            tb.Text += b.Content.ToString();
        }

        private void Button_Calcular(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Calcular();
            }
            catch (Exception ex)
            {
                tb.Text = "Error en la operación";
            }
        }

        private void Button_Borrar(object sender, RoutedEventArgs e)
        {
            tb.Text = "";
        }


        private void Calcular()
        {
            String operacion;
            int indexSeparador = 0;
            if (tb.Text.Contains("+"))
            {
                indexSeparador = tb.Text.IndexOf("+");
            }
            else if (tb.Text.Contains("-"))
            {
                indexSeparador = tb.Text.IndexOf("-");
            }
            else if (tb.Text.Contains("*"))
            {
                indexSeparador = tb.Text.IndexOf("*");
            }
            else if (tb.Text.Contains("/"))
            {
                indexSeparador = tb.Text.IndexOf("/");
            }
            else
            {
                throw new Exception();   
            }

            operacion = tb.Text.Substring(indexSeparador, 1);
            double op1 = Convert.ToDouble(tb.Text.Substring(0, indexSeparador));
            double op2 = Convert.ToDouble(tb.Text.Substring(indexSeparador + 1, tb.Text.Length - indexSeparador - 1));

            if (operacion == "+")
            {
                tb.Text =  (op1 + op2).ToString();
            }
            else if (operacion == "-")
            {
                tb.Text = (op1 - op2).ToString();
            }
            else if (operacion == "*")
            {
                tb.Text = (op1 * op2).ToString();
            }
            else
            {
                tb.Text =  (op1 / op2).ToString();
            }
        }
    }

}
