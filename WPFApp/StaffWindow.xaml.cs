using DataAccessObjects.BussinessObjects;
using Microsoft.VisualBasic.ApplicationServices;
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

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for StaffWindow.xaml
    /// </summary>
    public partial class StaffWindow : Window
    {
        private readonly AccountMember authenticatedUser;
        public StaffWindow(AccountMember user)
        {
            InitializeComponent();
            authenticatedUser = user;
        }

        private void purchaseoderpageStaff_Click(object sender, RoutedEventArgs e)
        {
            Staff.Content = new PurchaseOrderPage();
        }

        private void exitStaff_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void purchaselineStaff_Click(object sender, RoutedEventArgs e)
        {
            Staff.Content = new PurchaseOrdersLinesPage();
        }

        private void suppliertransacpageStaff_Click(object sender, RoutedEventArgs e)
        {
            Staff.Content = new SupplierTransactionPage();  
        }

        private void logoutStaff_Click(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }
    }
}
