using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        private readonly DataAccessUtility _dataAccessUtility;

        public MainWindow()
        {
            InitializeComponent();
            _dataAccessUtility = new DataAccessUtility(new OMSContext());
            Loaded += MainWindow_Loaded;

            // Attach event handlers
            comboBoxShoppers.SelectionChanged += comboBoxShoppers_SelectionChanged;
            dataGridBaskets.SelectionChanged += dataGridBaskets_SelectionChanged;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Load data when the window is loaded
            await LoadShoppersComboBoxAsync();
        }

        private async Task LoadShoppersComboBoxAsync()
        {
            // Retrieve all shoppers from the database
            List<Shopper> shoppers = await _dataAccessUtility.GetAllShoppersAsync();

            // Bind shoppers to the ComboBox
            comboBoxShoppers.ItemsSource = shoppers;
            comboBoxShoppers.DisplayMemberPath = "Email"; // Display shoppers' email addresses
        }

        private async void comboBoxShoppers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle selection change in the shoppers ComboBox
            if (comboBoxShoppers.SelectedItem != null && comboBoxShoppers.SelectedItem is Shopper selectedShopper)
            {
                // Retrieve baskets for the selected shopper
                List<Basket> baskets = await _dataAccessUtility.GetBasketsForShopperAsync(selectedShopper.IdShopper);

                // Bind baskets to the DataGrid
                dataGridBaskets.ItemsSource = baskets;
            }
        }

        private async void dataGridBaskets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle selection change in the baskets DataGrid
            if (dataGridBaskets.SelectedItem != null && dataGridBaskets.SelectedItem is Basket selectedBasket)
            {
                // Optionally, you can retrieve and display basket items for the selected basket here
                // Example: await LoadBasketItemsAsync(selectedBasket.IdBasket);
            }
        }
    }
}
