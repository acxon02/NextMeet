using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;




namespace NextMeet
{
    public partial class App : Application
    {
        [STAThread]
        public static void Main()
        {
            // Iniciar la ventana de login al arrancar la aplicación
            LoginWindow loginWindow = new LoginWindow();
            bool? result = loginWindow.ShowDialog();

            // Si el login es exitoso (result es true), mostrar la ventana principal
            if (result == true)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
        }
    }
}
