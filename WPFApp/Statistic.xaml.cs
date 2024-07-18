using Microsoft.Data.SqlClient;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Repositories;
using Services;
using System.Linq;
using System.Windows.Controls;

namespace WPFApp
{
    public partial class Statistic : Page
    {
        private readonly IProductService productService;

        public Statistic()
        {
            InitializeComponent();
            IProductRepository productRepository = new ProductRepository();
            productService = new ProductService(productRepository);

            LoadProductCountBySupplier();
            LoadProductDistributionByPackageType();
            LoadAverageUnitPriceBySupplier();
            LoadProductDistributionByColor();
        }

        private void LoadProductCountBySupplier()
        {
            var data = new List<dynamic>();

            using (var connection = new SqlConnection("Server=(local);uid=sa;pwd=123;database=SupplierManagementDB;Encrypt=false;"))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT SupplierID, COUNT(*) AS Count FROM Products GROUP BY SupplierID", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            data.Add(new { SupplierId = reader.GetInt32(0), Count = reader.GetInt32(1) });
                        }
                    }
                }
            }

            var plotModel = new PlotModel { Title = "Product Count by Supplier" };
            var categoryAxis = new CategoryAxis { Position = AxisPosition.Left };
            var valueAxis = new LinearAxis { Position = AxisPosition.Bottom, Title = "Count" };

            foreach (var item in data)
            {
                categoryAxis.Labels.Add(item.SupplierId.ToString());
            }

            var series = new BarSeries
            {
                ItemsSource = data.Select(d => new BarItem(d.Count)).ToList(),
                LabelPlacement = LabelPlacement.Inside,
                LabelFormatString = "{0}"
            };

            plotModel.Axes.Add(categoryAxis);
            plotModel.Axes.Add(valueAxis);
            plotModel.Series.Add(series);

            ProductCountBySupplierChart.Model = plotModel;
        }



        private void LoadProductDistributionByPackageType()
        {
            var data = productService.GetAllProducts()
                .GroupBy(p => p.PackageType)
                .Select(g => new { PackageType = g.Key, Count = g.Count() })
                .ToList();

            var plotModel = new PlotModel { Title = "Product Distribution by Package Type" };

            var series = new PieSeries();
            foreach (var item in data)
            {
                series.Slices.Add(new PieSlice(item.PackageType, item.Count));
            }

            plotModel.Series.Add(series);
            ProductDistributionByPackageTypeChart.Model = plotModel;
        }

        private void LoadAverageUnitPriceBySupplier()
        {
            var data = new List<dynamic>();

            using (var connection = new SqlConnection("Server=(local);uid=sa;pwd=123;database=SupplierManagementDB;Encrypt=false;"))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT SupplierID, AVG(UnitPrice) AS AveragePrice FROM Products GROUP BY SupplierID", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            data.Add(new { SupplierId = reader.GetInt32(0), AveragePrice = reader.GetDecimal(1) });
                        }
                    }
                }
            }

            var plotModel = new PlotModel { Title = "Average Unit Price by Supplier" };
            var categoryAxis = new CategoryAxis { Position = AxisPosition.Left };
            var valueAxis = new LinearAxis { Position = AxisPosition.Bottom, Title = "Average Price" };

            foreach (var item in data)
            {
                categoryAxis.Labels.Add(item.SupplierId.ToString());
            }

            var series = new BarSeries
            {
                ItemsSource = data.Select(d => new BarItem((double)d.AveragePrice)).ToList(),
                LabelPlacement = LabelPlacement.Inside,
                LabelFormatString = "{0:C}"
            };

            plotModel.Axes.Add(categoryAxis);
            plotModel.Axes.Add(valueAxis);
            plotModel.Series.Add(series);

            AverageUnitPriceBySupplierChart.Model = plotModel;
        }


        private void LoadProductDistributionByColor()
        {
            var data = productService.GetAllProducts()
                .GroupBy(p => p.Color)
                .Select(g => new { Color = g.Key, Count = g.Count() })
                .ToList();

            var plotModel = new PlotModel { Title = "Product Distribution by Color" };

            var series = new PieSeries();
            foreach (var item in data)
            {
                series.Slices.Add(new PieSlice(item.Color, item.Count));
            }

            plotModel.Series.Add(series);
            ProductDistributionByColorChart.Model = plotModel;
        }
    }
}
