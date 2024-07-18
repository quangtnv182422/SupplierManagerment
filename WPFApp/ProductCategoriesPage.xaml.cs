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
    /// Interaction logic for ProductCategoriesPage.xaml
    /// </summary>
    public partial class ProductCategoriesPage : Page, INotifyPropertyChanged
    {
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

        public ProductCategoriesPage(AccountMember user)
        {
            InitializeComponent();
            ISupplierCategoriesRepository supplierCategoriesRepository = new SupplierCategoriesRepository();
            supplierCategoriesService = new SupplierCategoriesService(supplierCategoriesRepository);
            authenticatedUser = user;
            DataContext = this;
            LoadCategories();
            SetUserRole();
            UpdateUIBasedOnRole();
        }

        private void LoadCategories()
        {
            dgCategories.ItemsSource = supplierCategoriesService.GetAllSupplierCategories();
        }

        private void SetUserRole()
        {
            IsAdmin = authenticatedUser?.MemberRole == 1;
            IsMember = authenticatedUser?.MemberRole == 3;
        }

        private void UpdateUIBasedOnRole()
        {
            btnAddCategory.IsEnabled = IsAdmin;
            btnUpdateCategory.IsEnabled = IsAdmin;
            btnDeleteCategory.IsEnabled = IsAdmin;
            if (authenticatedUser.MemberRole == 3)
            {
                btnAddCategory.Visibility = Visibility.Collapsed;
                btnUpdateCategory.Visibility = Visibility.Collapsed;
                btnDeleteCategory.Visibility = Visibility.Collapsed;
            }
            else
            {
                btnAddCategory.Visibility = Visibility.Visible;
                btnUpdateCategory.Visibility = Visibility.Visible;
                btnDeleteCategory.Visibility = Visibility.Visible;
            }
        }

        private void txtSearchCategory_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = txtSearchCategory.Text;
            dgCategories.ItemsSource = supplierCategoriesService.GetAllSupplierCategories()
                .Where(c => c.SupplierCategoryName.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        private void btnSearchCategory_Click(object sender, RoutedEventArgs e)
        {
            txtSearchCategory_TextChanged(sender, null);
        }

        private void btnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            if (!IsAdmin)
            {
                MessageBox.Show("You do not have permission to perform this action.");
                return;
            }

            SupplierCategory category = new SupplierCategory
            {
                SupplierCategoryName = txtCategoryName.Text
            };
            supplierCategoriesService.AddSupplierCategory(category);
            LoadCategories();
            ResetFields();
        }

        private void btnUpdateCategory_Click(object sender, RoutedEventArgs e)
        {
            if (!IsAdmin)
            {
                MessageBox.Show("You do not have permission to perform this action.");
                return;
            }

            if (dgCategories.SelectedItem is SupplierCategory selectedCategory)
            {
                selectedCategory.SupplierCategoryName = txtCategoryName.Text;
                supplierCategoriesService.UpdateSupplierCategory(selectedCategory);
                LoadCategories();
                ResetFields();
            }
        }

        private void btnDeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            if (!IsAdmin)
            {
                MessageBox.Show("You do not have permission to perform this action.");
                return;
            }

            if (dgCategories.SelectedItem is SupplierCategory selectedCategory)
            {
                supplierCategoriesService.DeleteSupplierCategory(selectedCategory);
                LoadCategories();
                ResetFields();
            }
        }

        private void btnRefreshCategories_Click(object sender, RoutedEventArgs e)
        {
            txtCategoryId.Text = string.Empty;
            txtCategoryName.Text = string.Empty ;
            LoadCategories();
        }

        private void dgCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgCategories.SelectedItem is SupplierCategory selectedCategory)
            {
                txtCategoryId.Text = selectedCategory.SupplierCategoryId.ToString();
                txtCategoryName.Text = selectedCategory.SupplierCategoryName;
            }
        }

        private void ResetFields()
        {
            txtCategoryId.Text = string.Empty;
            txtCategoryName.Text = string.Empty;
            dgCategories.SelectedItem = null;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}