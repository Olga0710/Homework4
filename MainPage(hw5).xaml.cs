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
        enum Column
        {
            Name,
            Price,
            Country,
            Description,
            Type,
            Quantity,
            Unit,
            Expiration,
            Authors,
            Publisher,
            Pages
        }
        public MainPage()
        {
            Title = "Goods store";
            productsGrid = new Grid()
            {
                ColumnDefinitions = Columns.Define(
                    (Column.Name, GridLength.Auto),
                    (Column.Price, GridLength.Auto),
                    (Column.Country, GridLength.Auto),
                    (Column.Description, GridLength.Auto),
                    (Column.Type, GridLength.Auto),
                    (Column.Quantity, GridLength.Auto),
                    (Column.Unit, GridLength.Auto),
                    (Column.Expiration, GridLength.Auto),
                    (Column.Authors, GridLength.Auto),
                    (Column.Publisher, GridLength.Auto),
                    (Column.Pages, GridLength.Auto)

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
            productsGrid.Add(new Label { Text = "Name", FontAttributes = FontAttributes.Bold }, 0, 0);
            productsGrid.Add(new Label { Text = "Price", FontAttributes = FontAttributes.Bold }, 1, 0);
            productsGrid.Add(new Label { Text = "Country", FontAttributes = FontAttributes.Bold }, 2, 0);
            productsGrid.Add(new Label { Text = "Description", FontAttributes = FontAttributes.Bold }, 3, 0);
            productsGrid.Add(new Label { Text = "Type", FontAttributes = FontAttributes.Bold }, (int)Column.Type, 0);
            productsGrid.Add(new Label { Text = "Quantity", FontAttributes = FontAttributes.Bold }, (int)Column.Quantity, 0);
            productsGrid.Add(new Label { Text = "Unit", FontAttributes = FontAttributes.Bold }, (int)Column.Unit, 0);
            productsGrid.Add(new Label { Text = "Term", FontAttributes = FontAttributes.Bold }, (int)Column.Expiration, 0);
            productsGrid.Add(new Label { Text = "Authors", FontAttributes = FontAttributes.Bold }, (int)Column.Authors, 0);
            productsGrid.Add(new Label { Text = "Publishing house", FontAttributes = FontAttributes.Bold }, (int)Column.Publisher, 0);
            productsGrid.Add(new Label { Text = "Pages", FontAttributes = FontAttributes.Bold }, (int)Column.Pages, 0);
           
            for (int i=0; i<product.Count; i++)
            {
                var p = product[i];
                productsGrid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
                int row = i + 1;
                productsGrid.Add(new Label { Text = p._name }, (int)Column.Name, row);
                productsGrid.Add(new Label { Text = p._price.ToString("C") }, (int)Column.Price, row);
                productsGrid.Add(new Label { Text = p._country }, (int)Column.Country, row);
                productsGrid.Add(new Label { Text = p._description }, (int)Column.Description, row);

                if (p is FoodProduct f)
                {
                    productsGrid.Add(new Label { Text = "food" }, (int)Column.Type, row);
                    productsGrid.Add(new Label { Text = f._quantity.ToString() }, (int)Column.Quantity, row);
                    productsGrid.Add(new Label { Text = f._unitMeasure }, (int)Column.Unit, row);
                    productsGrid.Add(new Label { Text = f._expirationDate.ToString() }, (int)Column.Expiration, row);
                    productsGrid.Add(new Label { Text = " - " }, (int)Column.Authors, row);
                    productsGrid.Add(new Label { Text = " - "}, (int)Column.Publisher, row);
                    productsGrid.Add(new Label { Text = " - " }, (int)Column.Pages, row);
                }

                else if (p is Books b)
                {
                    productsGrid.Add(new Label { Text = "book" }, (int)Column.Type, row);
                    productsGrid.Add(new Label { Text = " - "}, (int)Column.Quantity, row);
                    productsGrid.Add(new Label { Text = " - "}, (int)Column.Unit, row);
                    productsGrid.Add(new Label { Text = " - "}, (int)Column.Expiration, row);
                    productsGrid.Add(new Label { Text = b._authors }, (int)Column.Authors, row);
                    productsGrid.Add(new Label { Text = b._publisher }, (int)Column.Publisher, row);
                    productsGrid.Add(new Label { Text = b._pages.ToString() }, (int)Column.Pages, row);
                }
            }

        }

        async void AddProduct(object sender, EventArgs e)
        {
            string type = await DisplayPromptAsync("Product type", "Enter product type (Food/Book) ");
            if (string.IsNullOrWhiteSpace(type)) return;

            type = type.Trim().ToLower();

            if (type != "food" && type != "book")
            {
                await DisplayAlert("Error", "Unknown product type. Enter 'Food' or 'Book'.", "OK");
                return;
            }

            string name = await DisplayPromptAsync("Name", "Enter product name");
            if (string.IsNullOrWhiteSpace(type)) return;

            string priceInput = await DisplayPromptAsync("Price", "Enter product price (e.g. 45.50)");
            if (!decimal.TryParse(priceInput, out decimal price) || price < 0)
            {
                await DisplayAlert("Error", "Incorrect price!", "OK");
                return;
            }

            string country = await DisplayPromptAsync("Country", "Enter country of origin");
            if (string.IsNullOrWhiteSpace(type)) return;

            string description = await DisplayPromptAsync("Description", "Enter a short description of the product");
            if (string.IsNullOrWhiteSpace(type)) return;

            if (type == "food")
            {
                string quantityInput = await DisplayPromptAsync("Quantity ", "Enter quantity");
                if (!int.TryParse(quantityInput, out int quantity) || quantity < 0)
                {
                    await DisplayAlert("Error", "Incorrect data! Quantity must be a non-negative number", "OK");
                    return;
                }

                string unitMeasure = await DisplayPromptAsync("Unit of measure", "Enter unit (kg, l, psc, etc)");

                string expInput = await DisplayPromptAsync("Expiration date", "Enter number of days");
                if (!int.TryParse(expInput, out int expiration) || expiration < 0)
                {
                    await DisplayAlert("Error", "Incorrect data! Expiration must be non-negative", "OK");
                    return;
                }

                product.Add(new FoodProduct
                {
                    _name = name,
                    _price = price,
                    _country = country,
                    _description = description,
                    _packageData = DateTime.Now,
                    _quantity = quantity,
                    _unitMeasure = unitMeasure,
                    _expirationDate = expiration

                });

            }
            else if (type == "book")
            {
                string amountPages = await DisplayPromptAsync("Pages ", "Enter the number of pages");
                if (!int.TryParse(amountPages, out int pages) || pages < 0)
                {
                    await DisplayAlert("Error", "Incorrect data! Pages must be a non-negative number", "OK");
                    return;
                }

                string publisher = await DisplayPromptAsync("Publisher ", "Enter the name of the publisher");
                string authors = await DisplayPromptAsync("Author(s)", "Enter the first and last name of the author(s)");

                product.Add(new Books
                {
                    _name = name,
                    _price = price,
                    _country = country,
                    _description = description,
                    _packageData = DateTime.Now,
                    _pages = pages,
                    _publisher = publisher,
                    _authors = authors
                }
                );
            }
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

