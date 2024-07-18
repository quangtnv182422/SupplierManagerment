using DataAccessObjects.BussinessObjects;
using Repositories;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page, INotifyPropertyChanged
    {
        private readonly AccountRepository accountRepository;
        private readonly AccountMember authenticatedUser;
        private bool isAdmin;
        private bool isMember;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsAdmin
        {
            get => isAdmin;
            set
            {
                isAdmin = value;
                OnPropertyChanged(nameof(IsAdmin));
            }
        }

        public bool IsMember
        {
            get => isMember;
            set
            {
                isMember = value;
                OnPropertyChanged(nameof(IsMember));
            }
        }

        public AccountPage(AccountMember user)
        {
            InitializeComponent();
            accountRepository = new AccountRepository();
            authenticatedUser = user;
            DataContext = this;
            LoadAccountMembers();
            SetUserRole();
            UpdateUIBasedOnRole();
        }

        private void LoadAccountMembers()
        {
            dgData.ItemsSource = accountRepository.GetAllAccountMember();
        }

        private void SetUserRole()
        {
            IsAdmin = authenticatedUser?.MemberRole == 1;
            IsMember = authenticatedUser?.MemberRole == 3;
        }

        private void UpdateUIBasedOnRole()
        {
            // Enable or disable CRUD buttons based on role
            btnCreate.IsEnabled = IsAdmin;
            btnUpdate.IsEnabled = IsAdmin;
            btnDelete.IsEnabled = IsAdmin;
        }

      
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (!IsAdmin)
            {
                MessageBox.Show("You do not have permission to perform this action.");
                return;
            }

            AccountMember accountMember = new AccountMember
            {
                MemberId = txtMemberId.Text,
                MemberPassword = txtPassword.Password,
                FullName = txtFullName.Text,
                EmailAddress = txtEmail.Text,
                MemberRole = int.TryParse(txtRole.Text, out int role) ? role : (int?)null
            };
            accountRepository.AddAccountMember(accountMember);
            LoadAccountMembers();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (!IsAdmin)
            {
                MessageBox.Show("You do not have permission to perform this action.");
                return;
            }

            if (dgData.SelectedItem is AccountMember selectedAccountMember)
            {
                selectedAccountMember.MemberPassword = txtPassword.Password;
                selectedAccountMember.FullName = txtFullName.Text;
                selectedAccountMember.EmailAddress = txtEmail.Text;
                selectedAccountMember.MemberRole = int.TryParse(txtRole.Text, out int role) ? role : (int?)null;
                accountRepository.UpdateAccountMember(selectedAccountMember);
                LoadAccountMembers();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!IsAdmin)
            {
                MessageBox.Show("You do not have permission to perform this action.");
                return;
            }

            if (dgData.SelectedItem is AccountMember selectedAccountMember)
            {
                accountRepository.DeleteAccountMember(selectedAccountMember);
                LoadAccountMembers();
            }
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem is AccountMember selectedAccountMember)
            {
                txtMemberId.Text = selectedAccountMember.MemberId;
                txtPassword.Password = selectedAccountMember.MemberPassword;
                txtFullName.Text = selectedAccountMember.FullName;
                txtEmail.Text = selectedAccountMember.EmailAddress;
                txtRole.Text = selectedAccountMember.MemberRole?.ToString();
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtMemberId.Text = string.Empty;
            txtPassword.Password = string.Empty;
            txtFullName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtRole.Text = string.Empty;
            dgData.SelectedItem = null;
        }

        private void btnFilterByName_Click(object sender, RoutedEventArgs e)
        {
            string name = txtFilterName.Text;
            dgData.ItemsSource = accountRepository.GetAllAccountMember()
                .Where(a => a.FullName.Contains(name))
                .ToList();
        }

        private void btnFilterByRole_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtFilterRole.Text, out int role))
            {
                dgData.ItemsSource = accountRepository.GetAllAccountMember()
                    .Where(a => a.MemberRole == role)
                    .ToList();
            }
            else
            {
                MessageBox.Show("Please enter a valid role number.");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}