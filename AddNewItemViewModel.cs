using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WpfApp
{
    internal class AddNewItemViewModel : INotifyPropertyChanged
    {
        private readonly DataAccessUtility _dataAccessUtility;
        private ObservableCollection<Product> _products;
        private Product _selectedProduct;
        private int _quantity;

        public AddNewItemViewModel()
        {
            _dataAccessUtility = new DataAccessUtility(new OMSContext());
            LoadProductsCommand = new RelayCommand(async () => await LoadProductsAsync());
            AddToBasketCommand = new RelayCommand(AddToBasket);
        }

        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged();
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand LoadProductsCommand { get; }
        public RelayCommand AddToBasketCommand { get; }

        private async Task LoadProductsAsync()
        {
            // Load products from the database
            List<Product> products = await _dataAccessUtility.GetAllProductsAsync();

            // Update the collection
            Products = new ObservableCollection<Product>(products);
        }

        private void AddToBasket()
        {
            if (SelectedProduct == null || Quantity <= 0)
            {
                // Validation failed, handle accordingly
                return;
            }

            // Add the selected product to the basket with specified quantity
            // You can implement this logic according to your application requirements
            Console.WriteLine($"Adding {Quantity} of {SelectedProduct.ProductName} to the basket...");
        }

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
