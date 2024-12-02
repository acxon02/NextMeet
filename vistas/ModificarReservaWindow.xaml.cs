using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace NextMeet
{
    public partial class ModificarReservaWindow : Window
    {
        private Reserva _reserva;

        public ModificarReservaWindow(Reserva reserva)
        {
            InitializeComponent();
            _reserva = reserva;

            // Rellenar los campos con los datos de la reserva seleccionada
            NombreClienteTextBox.Text = _reserva.NombreCliente;
            CorreoClienteTextBox.Text = _reserva.CorreoCliente;
            FechaDatePicker.SelectedDate = _reserva.Fecha;

            // Llenar las opciones de hora
            if (_reserva.HoraInicio != null)
            {
                string horaInicioString = _reserva.HoraInicio.ToString(@"hh\:mm");
                // Buscar el ComboBoxItem que coincida con la hora
                foreach (ComboBoxItem item in HoraInicioComboBox.Items)
                {
                    if (item.Content.ToString() == horaInicioString)
                    {
                        HoraInicioComboBox.SelectedItem = item;
                        break;
                    }
                }
            }

            // Repetir lo mismo para la Hora de Fin si es necesario
            if (_reserva.HoraFin != null)
            {
                string horaFinString = _reserva.HoraFin.ToString(@"hh\:mm");

                foreach (ComboBoxItem item in HoraFinComboBox.Items)
                {
                    if (item.Content.ToString() == horaFinString)
                    {
                        HoraFinComboBox.SelectedItem = item;
                        break;
                    }
                }
            }

            TipoSalaTextBox.Text = _reserva.TipoSala;
        }

        // Guardar los cambios realizados en la reserva
        private void GuardarCambios_Click(object sender, RoutedEventArgs e)
        {
            _reserva.NombreCliente = NombreClienteTextBox.Text;
            _reserva.CorreoCliente = CorreoClienteTextBox.Text;
            _reserva.Fecha = FechaDatePicker.SelectedDate ?? DateTime.Now;

            // Convertir la hora seleccionada de vuelta a TimeSpan
            // Para la hora de inicio
            // Para la hora de inicio
            if (HoraInicioComboBox.SelectedItem != null)
            {
                var horaInicioString = (HoraInicioComboBox.SelectedItem as ComboBoxItem).Content.ToString();
                _reserva.HoraInicio = ConvertirHoraAFormatoTimeSpan(horaInicioString); // Convierte la hora de inicio
            }
            else
            {
                MessageBox.Show("Formato de hora de inicio no válido.");
            }

            // Para la hora de fin
            if (HoraFinComboBox.SelectedItem != null)
            {
                var horaFinString = (HoraFinComboBox.SelectedItem as ComboBoxItem).Content.ToString();
                _reserva.HoraFin = ConvertirHoraAFormatoTimeSpan(horaFinString); // Convierte la hora de fin
            }
            else
            {
                MessageBox.Show("Formato de hora de fin no válido.");
            }



            _reserva.TipoSala = TipoSalaTextBox.Text;

            // Guardar los cambios en la base de datos
            var context = new NextMeetContext();
            context.SaveChanges();

            // Cerrar la ventana emergente
            this.Close();
        }

        // Método para convertir hora seleccionada de string a TimeSpan
        // Método para convertir hora seleccionada de string a TimeSpan en formato 12 horas con AM/PM
        private TimeSpan ConvertirHoraAFormatoTimeSpan(string hora)
        {
            try
            {
                // Convertimos la hora del formato 12 horas a DateTime usando "hh:mm tt"
                var horaFormateada = DateTime.ParseExact(hora, "hh:mm tt", CultureInfo.InvariantCulture);

                // Retornamos solo la parte de la hora como un TimeSpan
                return horaFormateada.TimeOfDay;
            }
            catch (FormatException)
            {
                MessageBox.Show("Formato de hora no válido.");
                return TimeSpan.Zero;
            }
        }


        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para cerrar la ventana
            this.Close();
        }

        




    }
}
