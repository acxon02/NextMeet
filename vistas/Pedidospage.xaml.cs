using NextMeet;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
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
using System.Globalization;
using Nextmeet;



namespace NextMeet
{
    public partial class PedidosPage : Page
    {
        public PedidosPage()
        {
            InitializeComponent();
            // Aquí se llama al método para mostrar la configuración
           
        }
        



        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Obtener la hora de inicio y fin seleccionadas
                var selectedStartTime = (StartTimeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
                var selectedEndTime = (EndTimeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

                // Verificar que no esté vacío
                if (string.IsNullOrEmpty(selectedStartTime) || string.IsNullOrEmpty(selectedEndTime))
                {
                    MessageBox.Show("Por favor, selecciona tanto la hora de inicio como la de fin.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                DateTime startDateTime;
                DateTime endDateTime;

                // Intentar convertir la hora de inicio y fin al formato correcto
                bool isStartTimeValid = DateTime.TryParseExact(selectedStartTime, "hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDateTime);
                bool isEndTimeValid = DateTime.TryParseExact(selectedEndTime, "hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDateTime);

                if (!isStartTimeValid || !isEndTimeValid)
                {
                    MessageBox.Show("El formato de la hora no es válido. Asegúrate de usar el formato hh:mm AM/PM.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Verificar si la hora de inicio es mayor que la de fin
                if (startDateTime >= endDateTime)
                {
                    MessageBox.Show("La hora de inicio no puede ser igual o mayor que la hora de fin.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Convertir a TimeSpan
                TimeSpan startTime = startDateTime.TimeOfDay;
                TimeSpan endTime = endDateTime.TimeOfDay;

                // Obtener otros valores de la interfaz
                string clientName = ClientNameTextBox.Text;  // Nombre del cliente
                string clientEmail = ClientEmailTextBox.Text;  // Correo del cliente
                DateTime selectedDate = SelectedDatePicker.SelectedDate ?? DateTime.Now;  // Fecha de la reserva
                string roomType = (RoomTypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();  // Tipo de sala
                decimal totalAmount = CalculateTotalAmount();  // Total calculado

                // Mostrar en el resumen de selección
                SelectedDateText.Text = $"Fecha: {selectedDate.ToString("dd/MM/yyyy")}";
                SelectedStartTimeText.Text = $"Hora de Inicio: {startDateTime.ToString("hh:mm tt")}";
                SelectedEndTimeText.Text = $"Hora de Fin: {endDateTime.ToString("hh:mm tt")}";
                SelectedRoomTypeText.Text = $"Tipo de Sala: {roomType}";
                SelectedExtrasText.Text = $"Complementos: {GetExtras()}";  // Asumiendo que tienes un método GetExtras() para obtener los complementos seleccionados
                TotalPriceText.Text = $"Total a Pagar: {totalAmount:C}";  // Usando el formato de moneda

                // Guardar la reserva en la base de datos
                GuardarReservaEnBaseDeDatos(clientName, clientEmail, selectedDate, startTime, endTime, roomType, totalAmount);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }







        private decimal CalculateTotalAmount()
        {
            // Definir precios para cada tipo de habitación
            decimal roomPrice = 0m;
            string selectedRoomType = (RoomTypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            // Asignar el precio de la habitación dependiendo de la selección
            switch (selectedRoomType)
            {
                case "Sala Multiusos":
                    roomPrice = 1000m; // Ejemplo de precio en pesos mexicanos
                    break;
                case "Sala de Reunión Estándar":
                    roomPrice = 600m;
                    break;
                case "Sala de Reunión Ejecutiva":
                    roomPrice = 1200m;
                    break;
                case "Salas de Talleres":
                    roomPrice = 800m;
                    break;
            }

            // Agregar costo por los complementos seleccionados
            decimal extrasPrice = 0m;
            if (ProyectorCheckBox.IsChecked == true) extrasPrice += 200m; // Precio del proyector
            if (PizarraCheckBox.IsChecked == true) extrasPrice += 150m;  // Precio de la pizarra
            if (CafeCheckBox.IsChecked == true) extrasPrice += 100m;  // Precio del café/refrescos

            // Calcular el total
            decimal totalAmount = roomPrice + extrasPrice;

            return totalAmount;
        }

        private string GetExtras()
        {
            string extras = string.Empty;

            if (ProyectorCheckBox.IsChecked == true)
                extras += "Proyector, ";
            if (PizarraCheckBox.IsChecked == true)
                extras += "Pizarra, ";
            if (CafeCheckBox.IsChecked == true)
                extras += "Café/Refrescos, ";

            if (string.IsNullOrEmpty(extras))
                return "Ninguno";

            return extras.TrimEnd(',', ' ');
        }

        private void GuardarReservaEnBaseDeDatos(string clientName, string clientEmail, DateTime selectedDate, TimeSpan startTime, TimeSpan endTime, string roomType, decimal totalPrice)
        {
            try
            {
                using (var context = new NextMeetContext())
                {
                    // Crear la nueva reserva con los valores proporcionados
                    var nuevaReserva = new Reserva
                    {
                        NombreCliente = clientName,  // Nombre del cliente
                        CorreoCliente = clientEmail,  // Correo del cliente
                        Fecha = selectedDate,  // Fecha seleccionada
                        HoraInicio = startTime,  // Hora de inicio seleccionada
                        HoraFin = endTime,  // Hora de fin seleccionada
                        TipoSala = roomType,  // Tipo de sala seleccionada
                        TotalPago = totalPrice  // Precio total calculado
                    };

                    context.Reservas.Add(nuevaReserva);  // Agrega la reserva a la base de datos
                    context.SaveChanges();  // Guarda los cambios
                }

                MessageBox.Show("La reserva se ha guardado correctamente.", "Reserva Confirmada", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar la reserva: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            // Calcular el monto total
            decimal totalAmount = CalculateTotalAmount();

            // Convertir el total a formato string (en pesos mexicanos)
            string totalAmountString = totalAmount.ToString("C", new CultureInfo("es-MX"));

            // Preguntar si el usuario está seguro de confirmar el pago
            MessageBoxResult result = MessageBox.Show(
                "¿Estás seguro que deseas confirmar el pago por " + totalAmountString + "?",
                "Confirmar Pago",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Crear la ventana de pago (PayWindow) y pasar el totalAmount como argumento
                PayWindow payWindow = new PayWindow(totalAmountString);
                payWindow.ShowDialog(); // Mostrar la ventana emergente
            }
            else
            {
                MessageBox.Show("El pago ha sido cancelado.", "Pago Cancelado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}

