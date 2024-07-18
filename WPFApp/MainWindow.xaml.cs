using DataAccessObjects.BussinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AccountMember authenticatedUser;

        public MainWindow(AccountMember user)
        {
            InitializeComponent();
            authenticatedUser = user;
            UpdateUIBasedOnRole();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void accountpage_Click(object sender, RoutedEventArgs e)
        {
            admin.Content = new AccountPage(authenticatedUser);
        }

        private void supplierpage_Click(object sender, RoutedEventArgs e)
        {
            admin.Content = new SuppliersPage(authenticatedUser);
        }

        private void productpage_Click(object sender, RoutedEventArgs e)
        {
            admin.Content = new ProductsPage(authenticatedUser);
        }





        private void Categories_Click(object sender, RoutedEventArgs e)
        {
            admin.Content = new ProductCategoriesPage(authenticatedUser);
        }

        private void UpdateUIBasedOnRole()
        {
            if (authenticatedUser.MemberRole == 3)
            {
                accountpage.Visibility = Visibility.Collapsed;
                Statistic.Visibility = Visibility.Collapsed;
                lbmember.Content = "Member";
                lbmember.FontSize = 55;
            }
            else
            {
                Statistic.Visibility = Visibility.Visible;
            }
        }


        private void logout_Click(object sender, RoutedEventArgs e)
        {

            Login loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }

        private void Statistic_Click(object sender, RoutedEventArgs e)
        {
            if (authenticatedUser.MemberRole == 1)
            {
                admin.Content = new Statistic();
            }
            else
            {
                System.Windows.MessageBox.Show("You do not have permission to access this page.", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}