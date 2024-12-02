using Nextmeet;
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


using System.Data.SqlClient;

namespace NextMeet
{
    public partial class ConfiguracionPage : Page
    {
        private string connectionString = "Data Source=USER8891-PC\\SQLEXPRESS;Initial Catalog=NextMeet;Integrated Security=True;"; // Cadena de conexión actualizada

        public ConfiguracionPage()
        {
            InitializeComponent();
            LoadUsers();
        }

        // Método para cargar los usuarios desde la base de datos
        private void LoadUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT [Username], [Nombre], [Email], [FechaRegistro] FROM [NextMeet].[dbo].[Usuarios]"; // Actualiza la tabla a 'Usuarios'
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Username = reader["Username"].ToString(),
                        Nombre = reader["Nombre"].ToString(),
                        Email = reader["Email"].ToString(),
                        FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"])
                    });
                }
            }

            UsersListView.ItemsSource = users;
        }

        // Método para registrar un nuevo usuario
        private void RegisterUser_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string nombre = FullNameTextBox.Text;
            string email = EmailTextBox.Text;
            DateTime fechaRegistro = DateTime.Now;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO [NextMeet].[dbo].[Usuarios] (Username, Password, Nombre, Email, FechaRegistro) VALUES (@Username, @Password, @Nombre, @Email, @FechaRegistro)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);  // Nota: Considera almacenar la contraseña de manera segura (encriptada)
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@FechaRegistro", fechaRegistro);

                command.ExecuteNonQuery();
            }

            // Limpiar campos
            UsernameTextBox.Clear();
            PasswordBox.Clear();
            FullNameTextBox.Clear();
            EmailTextBox.Clear();

            // Recargar la lista de usuarios
            LoadUsers();
        }

        // Método para eliminar un usuario
        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (UsersListView.SelectedItem is User selectedUser)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM [NextMeet].[dbo].[Usuarios] WHERE Username = @Username";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", selectedUser.Username);
                    command.ExecuteNonQuery();
                }

                // Recargar la lista de usuarios
                LoadUsers();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un usuario para eliminar.");
            }
        }

        // Método para modificar la contraseña de un usuario
       
    }

    public class User
    {
        public string Username { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}

