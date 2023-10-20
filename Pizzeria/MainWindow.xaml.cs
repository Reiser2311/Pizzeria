using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pizzeria
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Reset1_Click(object sender, RoutedEventArgs e)
        {
            borrarRB(Tipo_de_masa);
            borrarRB(Bebida);
            borrarCB(Ingredientes);
            Pedido1.Text = "Pedido:";
        }

        private void borrarRB(StackPanel stackPanel)
        {
            for (int i = 0; i < stackPanel.Children.Count; i++)
            {
                if (stackPanel.Children[i].GetType() == typeof(RadioButton))
                {
                    RadioButton rb = (RadioButton)stackPanel.Children[i];
                    rb.IsChecked = false;
                }
            }
        }

        private void borrarCB(StackPanel stackPanel)
        {
            for (int i = 0; i < stackPanel.Children.Count; i++)
            {
                if (stackPanel.Children[i].GetType() == typeof(CheckBox))
                {
                    CheckBox rb = (CheckBox)stackPanel.Children[i];
                    rb.IsChecked = false;
                }
            }
        }

        private void Pedir_Click(object sender, RoutedEventArgs e)
        {
            String pedido = "Pedido:\n";
            pedido += ponerTexto(Tipo_de_masa) + "\n";
            pedido += ponerTexto(Bebida) + "\n";
            pedido += ponerTexto(Ingredientes) + "\n";

            Pedido1.Text = pedido;

        }

        public String ponerTexto (StackPanel stackPanel)
        {
            String texto = "";

            for (int i = 0;i < stackPanel.Children.Count;i++)
            {
                if (stackPanel.Children[i].GetType() == typeof(CheckBox))
                {
                    CheckBox rb = (CheckBox)stackPanel.Children[i];
                    String piña = rb.Content.ToString();
                    if (rb.IsChecked == true)
                    {
                        if (piña != "Piña")
                        {
                            texto += rb.Content.ToString() + "\n";
                        } else
                        {
                            texto += "\nEn este establecimiento no permitimos la pizza con piña, por ello a su pizza no se le añadirá piña";
                        }
                    }
                }

                if (stackPanel.Children[i].GetType() == typeof(RadioButton))
                {
                    RadioButton rb = (RadioButton)stackPanel.Children[i];
                    if (rb.IsChecked == true)
                    {
                        texto += rb.Content.ToString();
                    }
                }
            }

            return texto;
        }

        public void cambiarImagen(StackPanel stackPanel, String ruta)
        {
            for (int i = 0; i < stackPanel.Children.Count; i++)
            {
                if (stackPanel.Children[i].GetType() == typeof(Image))
                {
                    Image img = (Image)stackPanel.Children[i];
                    img.Source = new BitmapImage(new Uri(ruta,UriKind.Relative));
                }
            }
        }

        private void CocaCola_Checked(object sender, RoutedEventArgs e)
        {
            cambiarImagen(Bebida, "/CocaCola.png");
        }

        private void Sprite_Checked(object sender, RoutedEventArgs e)
        {
            cambiarImagen(Bebida, "/Sprite.png");
        }

        private void Fanta_Checked(object sender, RoutedEventArgs e)
        {
            cambiarImagen(Bebida, "/Fanta.png");
        }

        private void Nestea_Checked(object sender, RoutedEventArgs e)
        {
            cambiarImagen(Bebida, "/Nestea.png");
        }

        private void DrPepper_Checked(object sender, RoutedEventArgs e)
        {
            cambiarImagen(Bebida, "/DrPepper.png");
        }
    }
}
