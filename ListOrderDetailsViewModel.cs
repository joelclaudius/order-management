using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WpfApp
{
    internal class ListOrderDetailsViewModel : INotifyPropertyChanged
    {
        private readonly DataAccessUtility _dataAccessUtility;
        private ObservableCollection<OrderDetail> _orderDetails;

        public ListOrderDetailsViewModel()
        {
            _dataAccessUtility = new DataAccessUtility(new OMSContext());
            LoadOrderDetailsCommand = new RelayCommand(async () => await LoadOrderDetailsAsync());
        }

        public ObservableCollection<OrderDetail> OrderDetails
        {
            get => _orderDetails;
            set
            {
                _orderDetails = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand LoadOrderDetailsCommand { get; }

        private async Task LoadOrderDetailsAsync()
        {
            // Load order details from the database
            List<OrderDetail> orderDetails = await _dataAccessUtility.GetAllOrderDetailsAsync();

            // Update the collection
            OrderDetails = new ObservableCollection<OrderDetail>(orderDetails);
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

