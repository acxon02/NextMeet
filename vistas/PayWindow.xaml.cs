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


namespace NextMeet
{
    public partial class PayWindow : Window
    {
        public string TotalAmount { get; set; }

        public PayWindow(string totalAmount)
        {
            InitializeComponent();
            TotalAmount = totalAmount;
            TotalAmountText.Text = $"${TotalAmount}";
        }

        private void ConfirmPayment_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Pago confirmado. ¡Gracias por su compra!", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void CancelPayment_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
