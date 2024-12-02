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
using System.Windows.Shapes;
using System.Collections.ObjectModel; // Directiva necesaria

using Nextmeet.NextMeetDB;


namespace NextMeet
{
    public partial class ReservaPage : Page
    {
        private NextMeetContext _context;

        public ObservableCollection<Reserva> Reservas { get; set; }

        public ReservaPage()
        {
            InitializeComponent();

            // Inicializa el contexto de la base de datos
            _context = new NextMeetContext();

            // Cargar las reservas desde la base de datos
            CargarReservas();
        }

        // Cargar las reservas desde la base de datos y vincular al DataGrid
        private void CargarReservas()
        {
            var reservaDb = _context.Reservas.ToList(); // Recupera todas las reservas
            Reservas = new ObservableCollection<Reserva>(reservaDb); // Convierte la lista a ObservableCollection
            ReservasDataGrid.ItemsSource = Reservas; // Vincula al DataGrid
        }

        // Evento para agregar una nueva reserva
        private void AgregarReserva_Click(object sender, RoutedEventArgs e)
        {
            // Redirigir a la página de Pedido
            NavigationService.Navigate(new PedidosPage());
        }

        // Evento para modificar una reserva
        private void ModificarButton_Click(object sender, RoutedEventArgs e)
        {
            // Verifica si hay una reserva seleccionada en el DataGrid
            if (ReservasDataGrid.SelectedItem is Reserva reservaSeleccionada)
            {
                // Crear una instancia de la ventana ModificarReservaWindow
                ModificarReservaWindow modificarWindow = new ModificarReservaWindow(reservaSeleccionada);

                // Mostrar la ventana de modificación
                modificarWindow.ShowDialog();

                // Después de cerrar la ventana, recargar las reservas para reflejar los cambios
                CargarReservas();
            }
        }

        // Evento para eliminar una reserva
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ReservasDataGrid.SelectedItem is Reserva reservaSeleccionada)
            {
                _context.Reservas.Remove(reservaSeleccionada); // Eliminar la reserva de la base de datos
                _context.SaveChanges(); // Guardar los cambios en la base de datos

                // Recargar las reservas para reflejar el cambio
                CargarReservas();
            }
        }

        private void ReservasDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
