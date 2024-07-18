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
    /// Interaction logic for PurchaseOrdersLinesPage.xaml
    /// </summary>
    public partial class PurchaseOrdersLinesPage : Page
    {
        private readonly IPurchaseOrderLineService purchaseOrderLineService;

        public PurchaseOrdersLinesPage()
        {
            InitializeComponent();
            IPurchaseOrderLineRepository purchaseOrderLineRepository = new PurchaseOrderLineRepository();
            purchaseOrderLineService = new PurchaseOrderLineService(purchaseOrderLineRepository);
            LoadPurchaseOrderLines();
        }

        private void LoadPurchaseOrderLines()
        {
            dgData.ItemsSource = purchaseOrderLineService.GetAllPurchaseOrderLines();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            PurchaseOrderLine purchaseOrderLine = new PurchaseOrderLine
            {
                ProductId = int.TryParse(txtProductId.Text, out int productId) ? productId : (int?)null,
                Description = txtDescription.Text,
                PurchaseOrderId = int.TryParse(txtPurchaseOrderId.Text, out int purchaseOrderId) ? purchaseOrderId : (int?)null,
                OrderedQuantity = int.TryParse(txtOrderedQuantity.Text, out int orderedQuantity) ? orderedQuantity : (int?)null,
                ReceivedQuantity = int.TryParse(txtReceivedQuantity.Text, out int receivedQuantity) ? receivedQuantity : (int?)null,
                LastReceiptDate = dpLastReceiptDate.SelectedDate.HasValue ? DateOnly.FromDateTime(dpLastReceiptDate.SelectedDate.Value) : (DateOnly?)null
            };
            purchaseOrderLineService.AddPurchaseOrderLine(purchaseOrderLine);
            LoadPurchaseOrderLines();
            ResetFields();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dgData.SelectedItem is PurchaseOrderLine selectedPurchaseOrderLine)
            {
                selectedPurchaseOrderLine.ProductId = int.TryParse(txtProductId.Text, out int productId) ? productId : (int?)null;
                selectedPurchaseOrderLine.Description = txtDescription.Text;
                selectedPurchaseOrderLine.PurchaseOrderId = int.TryParse(txtPurchaseOrderId.Text, out int purchaseOrderId) ? purchaseOrderId : (int?)null;
                selectedPurchaseOrderLine.OrderedQuantity = int.TryParse(txtOrderedQuantity.Text, out int orderedQuantity) ? orderedQuantity : (int?)null;
                selectedPurchaseOrderLine.ReceivedQuantity = int.TryParse(txtReceivedQuantity.Text, out int receivedQuantity) ? receivedQuantity : (int?)null;
                selectedPurchaseOrderLine.LastReceiptDate = dpLastReceiptDate.SelectedDate.HasValue ? DateOnly.FromDateTime(dpLastReceiptDate.SelectedDate.Value) : (DateOnly?)null;

                purchaseOrderLineService.UpdatePurchaseOrderLine(selectedPurchaseOrderLine);
                LoadPurchaseOrderLines();
                ResetFields();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgData.SelectedItem is PurchaseOrderLine selectedPurchaseOrderLine)
            {
                purchaseOrderLineService.DeletePurchaseOrderLine(selectedPurchaseOrderLine);
                LoadPurchaseOrderLines();
                ResetFields();
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ResetFields();
        }

        private void txtSearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = txtSearchText.Text;
            dgData.ItemsSource = purchaseOrderLineService.GetAllPurchaseOrderLines()
                .Where(pol => pol.Description.Contains(searchText))
                .ToList();
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem is PurchaseOrderLine selectedPurchaseOrderLine)
            {
                txtPurchaseOrderLineId.Text = selectedPurchaseOrderLine.PurchaseOrderLineId.ToString();
                txtProductId.Text = selectedPurchaseOrderLine.ProductId.ToString();
                txtDescription.Text = selectedPurchaseOrderLine.Description;
                txtPurchaseOrderId.Text = selectedPurchaseOrderLine.PurchaseOrderId.ToString();
                txtOrderedQuantity.Text = selectedPurchaseOrderLine.OrderedQuantity.ToString();
                txtReceivedQuantity.Text = selectedPurchaseOrderLine.ReceivedQuantity.ToString();
                dpLastReceiptDate.SelectedDate = selectedPurchaseOrderLine.LastReceiptDate?.ToDateTime(new TimeOnly(0, 0));
            }
        }

        private void ResetFields()
        {
            txtPurchaseOrderLineId.Text = string.Empty;
            txtProductId.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtPurchaseOrderId.Text = string.Empty;
            txtOrderedQuantity.Text = string.Empty;
            txtReceivedQuantity.Text = string.Empty;
            dpLastReceiptDate.SelectedDate = null;
            dgData.SelectedItem = null;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchText = txtSearchText.Text;
            dgData.ItemsSource = purchaseOrderLineService.GetAllPurchaseOrderLines()
                .Where(pol => pol.Description.Contains(searchText))
                .ToList();
        }
    }
}