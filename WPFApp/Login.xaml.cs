using DataAccessObjects.BussinessObjects;
using Services;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly IAccountService iAccountService;
        public Login()
        {
            InitializeComponent();
            iAccountService = new AccountService();
        }

        private void btnLogin_Click_1(object sender, RoutedEventArgs e)
        {
            AccountMember accountMember = iAccountService.GetAccountMemberById(user.Text);
            if (accountMember != null && accountMember.MemberPassword.Equals(pass.Password))
            {
                if (accountMember.MemberRole == 1 || accountMember.MemberRole == 3)
                {
                    MainWindow mainWindow = new MainWindow(accountMember);
                    mainWindow.Show();
                }
                else if (accountMember.MemberRole == 2)
                {
                    StaffWindow staffWindow = new StaffWindow(accountMember);
                    staffWindow.Show();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Account is invalid!");
            }
        }
    }
}
