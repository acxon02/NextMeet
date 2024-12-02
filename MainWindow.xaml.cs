using NextMeet;
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


namespace NextMeet
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Cargar la página de Pedidos por defecto al iniciar la aplicación
            MainFrame.Content = new PedidosPage(); // Asegúrate de tener una página PedidosPage.xaml
        }

        // Evento para el botón "Pedido"
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Cargar la página de PedidosPage
            MainFrame.Content = new PedidosPage(); // Asegúrate de que esta página exista
        }

        // Evento para el botón "Reservas"
        private void ReservaButton_Click(object sender, RoutedEventArgs e)
        {
            // Cargar la página de ReservasPage
            MainFrame.Content = new ReservaPage(); // Asegúrate de que esta página exista
        }

        private void ConfiguracionButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ConfiguracionPage(); // Asegúrate de que esta página exista
        }
        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown(); // Cierra la aplicación completamente
        }
    }
}

