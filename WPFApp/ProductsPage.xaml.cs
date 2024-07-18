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
    /// Interaction logic for ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page, INotifyPropertyChanged
    {
        private readonly IProductService productService;
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

        public ProductsPage(AccountMember user)
        {
            InitializeComponent();
            IProductRepository productRepository = new ProductRepository();
            productService = new ProductService(productRepository);
            authenticatedUser = user;
            DataContext = this;
            LoadProducts();
            SetUserRole();
            UpdateUIBasedOnRole();
        }

        private void LoadProducts()
        {
            dgData.ItemsSource = productService.GetAllProducts();
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
            try
            {
                dgData.ItemsSource = productService.GetAllProducts()
                    .Where(p => p.ProductName.ToLower().Contains(searchText) || (p.Color != null && p.Color.ToLower().Contains(searchText)))
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }


        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (!IsAdmin)
            {
                MessageBox.Show("You do not have permission to perform this action.");
                return;
            }

            Product product = new Product
            {
                ProductId = int.Parse(txtProductId.Text),
                ProductName = txtProductName.Text,
                SupplierId = int.TryParse(txtSupplierId.Text, out int supplierId) ? supplierId : (int?)null,
                Color = txtColor.Text,
                PackageType = txtPackageType.Text,
                Size = txtSize.Text,
                TaxRate = decimal.TryParse(txtTaxRate.Text, out decimal taxRate) ? taxRate : (decimal?)null,
                UnitPrice = decimal.TryParse(txtUnitPrice.Text, out decimal unitPrice) ? unitPrice : (decimal?)null,
                RecommendedRetailPrice = decimal.TryParse(txtRecommendedRetailPrice.Text, out decimal recommendedRetailPrice) ? recommendedRetailPrice : (decimal?)null,
                TypicalWeightPerUnit = decimal.TryParse(txtTypicalWeightPerUnit.Text, out decimal typicalWeightPerUnit) ? typicalWeightPerUnit : (decimal?)null
            };
            productService.AddProduct(product);
            LoadProducts();
            ResetFields();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (!IsAdmin)
            {
                MessageBox.Show("You do not have permission to perform this action.");
                return;
            }

            if (dgData.SelectedItem is Product selectedProduct)
            {
                selectedProduct.ProductName = txtProductName.Text;
                selectedProduct.SupplierId = int.TryParse(txtSupplierId.Text, out int supplierId) ? supplierId : (int?)null;
                selectedProduct.Color = txtColor.Text;
                selectedProduct.PackageType = txtPackageType.Text;
                selectedProduct.Size = txtSize.Text;
                selectedProduct.TaxRate = decimal.TryParse(txtTaxRate.Text, out decimal taxRate) ? taxRate : (decimal?)null;
                selectedProduct.UnitPrice = decimal.TryParse(txtUnitPrice.Text, out decimal unitPrice) ? unitPrice : (decimal?)null;
                selectedProduct.RecommendedRetailPrice = decimal.TryParse(txtRecommendedRetailPrice.Text, out decimal recommendedRetailPrice) ? recommendedRetailPrice : (decimal?)null;
                selectedProduct.TypicalWeightPerUnit = decimal.TryParse(txtTypicalWeightPerUnit.Text, out decimal typicalWeightPerUnit) ? typicalWeightPerUnit : (decimal?)null;

                productService.UpdateProduct(selectedProduct);
                LoadProducts();
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

            if (dgData.SelectedItem is Product selectedProduct)
            {
                productService.DeleteProduct(selectedProduct);
                LoadProducts();
                ResetFields();
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ResetFields();
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem is Product selectedProduct)
            {
                txtProductId.Text = selectedProduct.ProductId.ToString();
                txtProductName.Text = selectedProduct.ProductName;
                txtSupplierId.Text = selectedProduct.SupplierId?.ToString();
                txtColor.Text = selectedProduct.Color;
                txtPackageType.Text = selectedProduct.PackageType;
                txtSize.Text = selectedProduct.Size;
                txtTaxRate.Text = selectedProduct.TaxRate?.ToString();
                txtUnitPrice.Text = selectedProduct.UnitPrice?.ToString();
                txtRecommendedRetailPrice.Text = selectedProduct.RecommendedRetailPrice?.ToString();
                txtTypicalWeightPerUnit.Text = selectedProduct.TypicalWeightPerUnit?.ToString();
            }
        }

        private void ResetFields()
        {
            txtProductId.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtSupplierId.Text = string.Empty;
            txtColor.Text = string.Empty;
            txtPackageType.Text = string.Empty;
            txtSize.Text = string.Empty;
            txtTaxRate.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
            txtRecommendedRetailPrice.Text = string.Empty;
            txtTypicalWeightPerUnit.Text = string.Empty;
            dgData.SelectedItem = null;
        }
        private void btnFilterBySupplier_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtSupplierId.Text, out int supplierId))
            {
                dgData.ItemsSource = productService.GetProductsBySupplier(supplierId);
            }
        }

        private void btnFilterByColor_Click(object sender, RoutedEventArgs e)
        {
            string color = txtColor.Text;
            dgData.ItemsSource = productService.GetProductsByColor(color);
        }

        private void btnSortByName_Click(object sender, RoutedEventArgs e)
        {
            dgData.ItemsSource = productService.GetProductsSortedByName();
        }

        private void btnSortByTaxRate_Click(object sender, RoutedEventArgs e)
        {
            dgData.ItemsSource = productService.GetProductsSortedByTaxRate();
        }

        private void btnSortByWeight_Click(object sender, RoutedEventArgs e)
        {
            dgData.ItemsSource = productService.GetProductsSortedByTypicalWeightPerUnit();
        }

      

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}