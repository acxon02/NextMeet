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

using System.Data.SqlClient;


namespace NextMeet
{
    public partial class LoginWindow : Window
    {
        // Cadena de conexión a la base de datos
        private string connectionString =
            "Data Source=USER8891-PC\\SQLEXPRESS;Initial Catalog=NextMeet;Integrated Security=True;MultipleActiveResultSets=True;";

        public LoginWindow()
        {
            InitializeComponent();
        }

        // Evento para cuando el campo de texto de usuario recibe el foco
        private void UsernameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            UsernamePlaceholder.Visibility = Visibility.Collapsed;
        }

        private void UsernameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(UsernameTextBox.Text))
                UsernamePlaceholder.Visibility = Visibility.Visible;
        }

        // Evento para cuando el campo de contraseña recibe el foco
        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PasswordBox.Password))
                PasswordPlaceholder.Visibility = Visibility.Visible;
        }

        // Validar usuario en la base de datos
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text.Trim();
            string password = PasswordBox.Password.Trim();

            if (ValidateUser(username, password))
            {
                MessageBox.Show("¡Inicio de sesión exitoso!", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                OpenMainWindow(); // Abrir la ventana principal
               
            }
            else
            {
                ErrorMessage.Text = "Usuario o contraseña incorrectos.";
                ErrorMessage.Visibility = Visibility.Visible;
            }
        }

        private bool ValidateUser(string username, string password)
        {
            bool isValid = false;
            string query = "SELECT COUNT(*) FROM Usuarios WHERE Username = @username AND Password = @password";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        int result = (int)command.ExecuteScalar();
                        isValid = result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return isValid;
        }

        private void OpenMainWindow()
        {
            // Crear e inicializar la ventana principal
            MainWindow mainWindow = new MainWindow();

            // Mostrar la ventana principal
            mainWindow.Show();
        }
    }
}
