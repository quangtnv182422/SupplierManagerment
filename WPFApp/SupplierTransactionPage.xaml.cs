using DataAccessObjects.BussinessObjects;
using Repositories;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for SupplierTransactionPage.xaml
    /// </summary>
    public partial class SupplierTransactionPage : Page
    {
        private readonly ISupplierTransactionService supplierTransactionService;

        public SupplierTransactionPage()
        {
            InitializeComponent();
            ISupplierTransactionRepository supplierTransactionRepository = new SupplierTransactionRepository();
            supplierTransactionService = new SupplierTransactionService(supplierTransactionRepository);
            LoadSupplierTransactions();
        }

        private void LoadSupplierTransactions()
        {
            dgData.ItemsSource = supplierTransactionService.GetAllSupplierTransactions();
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem is SupplierTransaction selectedTransaction)
            {
                txtSupplierTransactionId.Text = selectedTransaction.SupplierTransactionId.ToString();
                txtSupplierId.Text = selectedTransaction.SupplierId?.ToString();
                txtTransactionType.Text = selectedTransaction.TransactionType;
                txtPurchaseOrderId.Text = selectedTransaction.PurchaseOrderId?.ToString();
                txtPaymentMethod.Text = selectedTransaction.PaymentMethod;
                txtSupplierInvoiceNumber.Text = selectedTransaction.SupplierInvoiceNumber;
                dpTransactionDate.SelectedDate = selectedTransaction.TransactionDate?.ToDateTime(new TimeOnly(0, 0));
                txtAmountExcludingTax.Text = selectedTransaction.AmountExcludingTax?.ToString();
                txtTaxAmount.Text = selectedTransaction.TaxAmount?.ToString();
                txtTransactionAmount.Text = selectedTransaction.TransactionAmount?.ToString();
                dpFinalizationDate.SelectedDate = selectedTransaction.FinalizationDate?.ToDateTime(new TimeOnly(0, 0));
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            SupplierTransaction transaction = new SupplierTransaction
            {
                SupplierId = int.TryParse(txtSupplierId.Text, out int supplierId) ? supplierId : (int?)null,
                TransactionType = txtTransactionType.Text,
                PurchaseOrderId = int.TryParse(txtPurchaseOrderId.Text, out int purchaseOrderId) ? purchaseOrderId : (int?)null,
                PaymentMethod = txtPaymentMethod.Text,
                SupplierInvoiceNumber = txtSupplierInvoiceNumber.Text,
                TransactionDate = dpTransactionDate.SelectedDate.HasValue ? DateOnly.FromDateTime(dpTransactionDate.SelectedDate.Value) : (DateOnly?)null,
                AmountExcludingTax = decimal.TryParse(txtAmountExcludingTax.Text, out decimal amountExcludingTax) ? amountExcludingTax : (decimal?)null,
                TaxAmount = decimal.TryParse(txtTaxAmount.Text, out decimal taxAmount) ? taxAmount : (decimal?)null,
                TransactionAmount = decimal.TryParse(txtTransactionAmount.Text, out decimal transactionAmount) ? transactionAmount : (decimal?)null,
                FinalizationDate = dpFinalizationDate.SelectedDate.HasValue ? DateOnly.FromDateTime(dpFinalizationDate.SelectedDate.Value) : (DateOnly?)null
            };
            supplierTransactionService.AddSupplierTransaction(transaction);
            LoadSupplierTransactions();
            ResetFields();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dgData.SelectedItem is SupplierTransaction selectedTransaction)
            {
                selectedTransaction.SupplierId = int.TryParse(txtSupplierId.Text, out int supplierId) ? supplierId : (int?)null;
                selectedTransaction.TransactionType = txtTransactionType.Text;
                selectedTransaction.PurchaseOrderId = int.TryParse(txtPurchaseOrderId.Text, out int purchaseOrderId) ? purchaseOrderId : (int?)null;
                selectedTransaction.PaymentMethod = txtPaymentMethod.Text;
                selectedTransaction.SupplierInvoiceNumber = txtSupplierInvoiceNumber.Text;
                selectedTransaction.TransactionDate = dpTransactionDate.SelectedDate.HasValue ? DateOnly.FromDateTime(dpTransactionDate.SelectedDate.Value) : (DateOnly?)null;
                selectedTransaction.AmountExcludingTax = decimal.TryParse(txtAmountExcludingTax.Text, out decimal amountExcludingTax) ? amountExcludingTax : (decimal?)null;
                selectedTransaction.TaxAmount = decimal.TryParse(txtTaxAmount.Text, out decimal taxAmount) ? taxAmount : (decimal?)null;
                selectedTransaction.TransactionAmount = decimal.TryParse(txtTransactionAmount.Text, out decimal transactionAmount) ? transactionAmount : (decimal?)null;
                selectedTransaction.FinalizationDate = dpFinalizationDate.SelectedDate.HasValue ? DateOnly.FromDateTime(dpFinalizationDate.SelectedDate.Value) : (DateOnly?)null;

                supplierTransactionService.UpdateSupplierTransaction(selectedTransaction);
                LoadSupplierTransactions();
                ResetFields();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgData.SelectedItem is SupplierTransaction selectedTransaction)
            {
                supplierTransactionService.DeleteSupplierTransaction(selectedTransaction);
                LoadSupplierTransactions();
                ResetFields();
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            ResetFields();
        }

        private void txtSearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = txtSearchText.Text;
            dgData.ItemsSource = supplierTransactionService.GetAllSupplierTransactions()
                .Where(st => st.SupplierInvoiceNumber.Contains(searchText) ||
                             st.TransactionType.Contains(searchText))
                .ToList();
        }

        private void ResetFields()
        {
            txtSupplierTransactionId.Text = string.Empty;
            txtSupplierId.Text = string.Empty;
            txtTransactionType.Text = string.Empty;
            txtPurchaseOrderId.Text = string.Empty;
            txtPaymentMethod.Text = string.Empty;
            txtSupplierInvoiceNumber.Text = string.Empty;
            dpTransactionDate.SelectedDate = null;
            txtAmountExcludingTax.Text = string.Empty;
            txtTaxAmount.Text = string.Empty;
            txtTransactionAmount.Text = string.Empty;
            dpFinalizationDate.SelectedDate = null;
            dgData.SelectedItem = null;
        }
    }
}