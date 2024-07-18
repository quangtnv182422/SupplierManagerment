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
    /// Interaction logic for PurchaseOderPage.xaml
    /// </summary>
    public partial class PurchaseOrderPage : Page
    {
        private readonly IPurchaseOrderService purchaseOrderService;

        public PurchaseOrderPage()
        {
            InitializeComponent();
            IPurchaseOrderRepository purchaseOrderRepository = new PurchaseOrderRepository();
            purchaseOrderService = new PurchaseOrderService(purchaseOrderRepository);
            LoadPurchaseOrders();
        }

        private void LoadPurchaseOrders()
        {
            dgData.ItemsSource = purchaseOrderService.GetAllPurchaseOrders();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            PurchaseOrder purchaseOrder = new PurchaseOrder
            {
                SupplierId = int.TryParse(txtSupplier.Text, out int supplierId) ? supplierId : (int?)null,
                DeliveryMethod = txtDeliveryMethod.Text,
                OrderDate = dpOrderDate.SelectedDate.HasValue ? DateOnly.FromDateTime(dpOrderDate.SelectedDate.Value) : DateOnly.MinValue,
                ExpectedDeliveryDate = dpExpectedDeliveryDate.SelectedDate.HasValue ? DateOnly.FromDateTime(dpExpectedDeliveryDate.SelectedDate.Value) : (DateOnly?)null,
                SupplierReference = txtSupplierReference.Text
            };

            purchaseOrderService.AddPurchaseOrder(purchaseOrder);
            LoadPurchaseOrders();
            ResetFields();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dgData.SelectedItem is PurchaseOrder selectedOrder)
            {
                selectedOrder.SupplierId = int.TryParse(txtSupplier.Text, out int supplierId) ? supplierId : (int?)null;
                selectedOrder.DeliveryMethod = txtDeliveryMethod.Text;
                selectedOrder.OrderDate = dpOrderDate.SelectedDate.HasValue ? DateOnly.FromDateTime(dpOrderDate.SelectedDate.Value) : DateOnly.MinValue;
                selectedOrder.ExpectedDeliveryDate = dpExpectedDeliveryDate.SelectedDate.HasValue ? DateOnly.FromDateTime(dpExpectedDeliveryDate.SelectedDate.Value) : (DateOnly?)null;
                selectedOrder.SupplierReference = txtSupplierReference.Text;

                purchaseOrderService.UpdatePurchaseOrder(selectedOrder);
                LoadPurchaseOrders();
                ResetFields();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgData.SelectedItem is PurchaseOrder selectedOrder)
            {
                purchaseOrderService.DeletePurchaseOrder(selectedOrder);
                LoadPurchaseOrders();
                ResetFields();
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ResetFields();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchText = txtSearchText.Text;
            dgData.ItemsSource = purchaseOrderService.GetAllPurchaseOrders()
                .Where(po => po.SupplierReference.Contains(searchText))
                .ToList();
        }

        private void txtSearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = txtSearchText.Text;
            dgData.ItemsSource = purchaseOrderService.GetAllPurchaseOrders()
                .Where(po => po.SupplierReference.Contains(searchText))
                .ToList();
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem is PurchaseOrder selectedOrder)
            {
                txtId.Text = selectedOrder.PurchaseOrderId.ToString();
                txtSupplier.Text = selectedOrder.SupplierId.ToString();
                txtDeliveryMethod.Text = selectedOrder.DeliveryMethod;
                dpOrderDate.SelectedDate = selectedOrder.OrderDate.ToDateTime(new TimeOnly(0, 0));
                dpExpectedDeliveryDate.SelectedDate = selectedOrder.ExpectedDeliveryDate?.ToDateTime(new TimeOnly(0, 0));
                txtSupplierReference.Text = selectedOrder.SupplierReference;
            }
        }

        private void ResetFields()
        {
            txtId.Text = string.Empty;
            txtSupplier.Text = string.Empty;
            txtDeliveryMethod.Text = string.Empty;
            dpOrderDate.SelectedDate = null;
            dpExpectedDeliveryDate.SelectedDate = null;
            txtSupplierReference.Text = string.Empty;
            dgData.SelectedItem = null;
        }
    }
}