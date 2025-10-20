using Microsoft.Maui.Controls;
using CommunityToolkit.Maui.Markup;
using MauiShop.Models;
using System.Data.Common;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;


namespace MauiShop
{
    public partial class MainPage : ContentPage
    {
        readonly List<Product> product = new();
        readonly Grid productsGrid;
        enum Column { Name, Price, Country, Description }
        public MainPage()
        {
            Title = "Goods store";
            productsGrid = new Grid()
            {
                ColumnDefinitions = Columns.Define(
                    (Column.Name, GridLength.Auto),
                    (Column.Price, GridLength.Auto),
                    (Column.Country, GridLength.Auto),
                    (Column.Description, GridLength.Auto)
                ),
                RowSpacing = 5,
                ColumnSpacing = 10,
                Padding = 10,


            };

            LoadInitialProduct();
            RefreshGrid();

            var addButton = new Button
            {
                Text = "Add product"
            };
            addButton.Clicked += AddProduct;

            var removeButton = new Button
            {
                Text = "Remove Broduct"
            };
            removeButton.Clicked += RemoveProduct;

            var label = new Label()
            {
                Text = "List of products",
                FontSize = 24,
                HorizontalOptions = LayoutOptions.Center
            };

            Content = new VerticalStackLayout
            {
                Padding = 20,
                Children =
            {
                label,
                productsGrid,
                new HorizontalStackLayout
                {
                    HorizontalOptions = LayoutOptions.Center,
                    Spacing = 15,
                    Children =
                    {
                        addButton,
                        removeButton
                    }
                }

            }
            };

        }
        void LoadInitialProduct()
        {
            product.Add(new FoodProduct
            {
                _name = "Milk",
                _price = 62m,
                _country = "Ukraine",
                _packageData = DateTime.Now.AddDays(-1),
                _description = "Fresh milk 3.2%",
                _quantity = 5,
                _unitMeasure = "l",
                _expirationDate = 7


            });

            product.Add(new Books
            {
                _name = "Kobzar",
                _price = 300m,
                _country = "Ukraine",
                _packageData = DateTime.Now,
                _description = "A collection of poems by T. Shevchenko",
                _pages = 400,
                _publisher = "Old lion",
                _authors = "Taras Shevchenko",
            });
        }
        void RefreshGrid()
        {
            productsGrid.Children.Clear();
            productsGrid.RowDefinitions.Clear();

            productsGrid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
            productsGrid.Add(new Label { Text = "Назва", FontAttributes = FontAttributes.Bold }, 0, 0);
            productsGrid.Add(new Label { Text = "Ціна", FontAttributes = FontAttributes.Bold }, 1, 0);
            productsGrid.Add(new Label { Text = "Країна", FontAttributes = FontAttributes.Bold }, 2, 0);
            productsGrid.Add(new Label { Text = "Опис", FontAttributes = FontAttributes.Bold }, 3, 0);

            for (int i=0; i<product.Count; i++)
            {
                var p = product[i];
                productsGrid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
                int row = i + 1;
                productsGrid.Add(new Label { Text = p._name }, 0, row);
                productsGrid.Add(new Label { Text = p._price.ToString("C") }, 1, row);
                productsGrid.Add(new Label { Text = p._country }, 2, row);
                productsGrid.Add(new Label { Text = p._description }, 3, row);

            }

        }

        void AddProduct(object sender, EventArgs e)
        {
            product.Add(new FoodProduct
            {
                _name = "Bread",
                _price = 30m,
                _country = "Ukraine",
                _packageData = DateTime.Now,
                _description = "Sliced ​​wheat kulinichi",
                _quantity = 7,
                _unitMeasure = "pieces",
                _expirationDate = 3


            });

            product.Add(new Books
            {
                _name = "Kaidashev family",
                _price = 188m,
                _country = "Ukraine",
                _packageData = DateTime.Now,
                _description = "Realistic socio-daily story",
                _pages = 132,
                _publisher = "Vikhola",
                _authors = "Ivan Nechuy-Levytskyi",
            });
            RefreshGrid();
        }

        void RemoveProduct(object sender, EventArgs e)
        {
            if (product.Count > 0)
            {
                product.RemoveAt(product.Count - 1);
            }
            RefreshGrid();
        }
    }
}

