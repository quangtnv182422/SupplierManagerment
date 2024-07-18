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
    /// Interaction logic for SuppliersPage.xaml
    /// </summary>
    public partial class SuppliersPage : Page, INotifyPropertyChanged
    {
        private readonly ISupplierService supplierService;
        private readonly ISupplierCategoriesService supplierCategoriesService;
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

        public SuppliersPage(AccountMember user)
        {
            InitializeComponent();
            ISupplierRepository supplierRepository = new SupplierRepository();
            ISupplierCategoriesRepository supplierCategoriesRepository = new SupplierCategoriesRepository();
            supplierService = new SupplierService(supplierRepository);
            supplierCategoriesService = new SupplierCategoriesService(supplierCategoriesRepository);
            authenticatedUser = user;
            DataContext = this;
            LoadSuppliers();
            LoadSupplierCategories();
            SetUserRole();
            UpdateUIBasedOnRole();
        }

        private void LoadSuppliers()
        {
            dgData.ItemsSource = supplierService.GetAllSuppliers();
        }

        private void LoadSupplierCategories()
        {
            cbFilterCategory.ItemsSource = supplierCategoriesService.GetAllSupplierCategories();
            cbFilterCategory.DisplayMemberPath = "SupplierCategoryName";
            cbFilterCategory.SelectedValuePath = "SupplierCategoryId";
        }

        private void SetUserRole()
        {
            IsAdmin = authenticatedUser?.MemberRole == 1;
            IsMember = authenticatedUser?.MemberRole == 3;
        }

        private void UpdateUIBasedOnRole()
        {
            btnCreate.IsEnabled = IsAdmin;
            btnUpdate.IsEnabled = IsAdmin;
            btnDelete.IsEnabled = IsAdmin;
            if (authenticatedUser.MemberRole == 3)
            {
                btnCreate.Visibility = Visibility.Collapsed;
                btnUpdate.Visibility = Visibility.Collapsed;
                btnDelete.Visibility = Visibility.Collapsed;
            }
            else
            {
                btnCreate.Visibility = Visibility.Visible;
                btnUpdate.Visibility = Visibility.Visible;
                btnDelete.Visibility = Visibility.Visible;
            }
        }

        private void txtSearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = txtSearchText.Text.ToLower();
            dgData.ItemsSource = supplierService.GetAllSuppliers()
                .Where(s => s.SupplierName != null && s.SupplierName.ToLower().Contains(searchText))
                .ToList();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (!IsAdmin)
            {
                MessageBox.Show("You do not have permission to perform this action.");
                return;
            }

            Supplier supplier = new Supplier
            {
                SupplierName = txtSupplierName.Text,
                DeliveryMethod = txtDeliveryMethod.Text,
                DeliveryCity = txtDeliveryCity.Text,
                SupplierReference = txtReference.Text,
                BankAccountName = txtBankAccountName.Text,
                BankAccountBranch = txtBankAccountBranch.Text,
                BankAccountCode = txtBankAccountCode.Text,
                BankAccountNumber = txtBankAccountNumber.Text,
                BankInternationalCode = txtBankInternationalCode.Text,
                PaymentDays = int.TryParse(txtPaymentDays.Text, out int paymentDays) ? paymentDays : (int?)null,
                PhoneNumber = txtPhoneNumber.Text,
                FaxNumber = txtFaxNumber.Text,
                WebsiteUrl = txtWebsiteUrl.Text,
                DeliveryAddressLine1 = txtDeliveryAddressLine1.Text,
                DeliveryAddressLine2 = txtDeliveryAddressLine2.Text,
                DeliveryPostalCode = txtDeliveryPostalCode.Text
            };
            supplierService.AddSupplier(supplier);
            LoadSuppliers();
            ResetFields();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (!IsAdmin)
            {
                MessageBox.Show("You do not have permission to perform this action.");
                return;
            }

            if (dgData.SelectedItem is Supplier selectedSupplier)
            {
                selectedSupplier.SupplierName = txtSupplierName.Text;
                selectedSupplier.DeliveryMethod = txtDeliveryMethod.Text;
                selectedSupplier.DeliveryCity = txtDeliveryCity.Text;
                selectedSupplier.SupplierReference = txtReference.Text;
                selectedSupplier.BankAccountName = txtBankAccountName.Text;
                selectedSupplier.BankAccountBranch = txtBankAccountBranch.Text;
                selectedSupplier.BankAccountCode = txtBankAccountCode.Text;
                selectedSupplier.BankAccountNumber = txtBankAccountNumber.Text;
                selectedSupplier.BankInternationalCode = txtBankInternationalCode.Text;
                selectedSupplier.PaymentDays = int.TryParse(txtPaymentDays.Text, out int paymentDays) ? paymentDays : (int?)null;
                selectedSupplier.PhoneNumber = txtPhoneNumber.Text;
                selectedSupplier.FaxNumber = txtFaxNumber.Text;
                selectedSupplier.WebsiteUrl = txtWebsiteUrl.Text;
                selectedSupplier.DeliveryAddressLine1 = txtDeliveryAddressLine1.Text;
                selectedSupplier.DeliveryAddressLine2 = txtDeliveryAddressLine2.Text;
                selectedSupplier.DeliveryPostalCode = txtDeliveryPostalCode.Text;

                supplierService.UpdateSupplier(selectedSupplier);
                LoadSuppliers();
                ResetFields();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!IsAdmin)
            {
                MessageBox.Show("You do not have permission to perform this action.");
                return;
            }

            if (dgData.SelectedItem is Supplier selectedSupplier)
            {
                supplierService.DeleteSupplier(selectedSupplier);
                LoadSuppliers();
                ResetFields();
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ResetFields();
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem is Supplier selectedSupplier)
            {
                txtSupplierId.Text = selectedSupplier.SupplierId.ToString();
                txtSupplierName.Text = selectedSupplier.SupplierName;
                txtDeliveryMethod.Text = selectedSupplier.DeliveryMethod;
                txtDeliveryCity.Text = selectedSupplier.DeliveryCity;
                txtReference.Text = selectedSupplier.SupplierReference;
                txtBankAccountName.Text = selectedSupplier.BankAccountName;
                txtBankAccountBranch.Text = selectedSupplier.BankAccountBranch;
                txtBankAccountCode.Text = selectedSupplier.BankAccountCode;
                txtBankAccountNumber.Text = selectedSupplier.BankAccountNumber;
                txtBankInternationalCode.Text = selectedSupplier.BankInternationalCode;
                txtPaymentDays.Text = selectedSupplier.PaymentDays?.ToString();
                txtPhoneNumber.Text = selectedSupplier.PhoneNumber;
                txtFaxNumber.Text = selectedSupplier.FaxNumber;
                txtWebsiteUrl.Text = selectedSupplier.WebsiteUrl;
                txtDeliveryAddressLine1.Text = selectedSupplier.DeliveryAddressLine1;
                txtDeliveryAddressLine2.Text = selectedSupplier.DeliveryAddressLine2;
                txtDeliveryPostalCode.Text = selectedSupplier.DeliveryPostalCode;
            }
        }

        private void ResetFields()
        {
            txtSupplierId.Text = string.Empty;
            txtSupplierName.Text = string.Empty;
            txtDeliveryMethod.Text = string.Empty;
            txtDeliveryCity.Text = string.Empty;
            txtReference.Text = string.Empty;
            txtBankAccountName.Text = string.Empty;
            txtBankAccountBranch.Text = string.Empty;
            txtBankAccountCode.Text = string.Empty;
            txtBankAccountNumber.Text = string.Empty;
            txtBankInternationalCode.Text = string.Empty;
            txtPaymentDays.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtFaxNumber.Text = string.Empty;
            txtWebsiteUrl.Text = string.Empty;
            txtDeliveryAddressLine1.Text = string.Empty;
            txtDeliveryAddressLine2.Text = string.Empty;
            txtDeliveryPostalCode.Text = string.Empty;
            dgData.SelectedItem = null;
        }



        private void btnFilterByName_Click(object sender, RoutedEventArgs e)
        {
            string filterName = txtFilterName.Text;
            dgData.ItemsSource = supplierService.GetAllSuppliers()
                .Where(s => s.SupplierName.Contains(filterName))
                .ToList();
        }

  
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void btnFilterByCategory_Click(object sender, RoutedEventArgs e)
        {
            if (cbFilterCategory.SelectedValue is int categoryId)
            {
                dgData.ItemsSource = supplierService.GetAllSuppliers()
                    .Where(s => s.SupplierCategoryId == categoryId)
                    .ToList();
            }
        }

        private void cbFilterCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbFilterCategory.SelectedValue is int categoryId)
            {
                dgData.ItemsSource = supplierService.GetAllSuppliers()
                    .Where(s => s.SupplierCategoryId == categoryId)
                    .ToList();
            }
        }
    }
}