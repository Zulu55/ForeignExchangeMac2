namespace ForeignExchangeMac2.ViewModels
{
    using System.ComponentModel;
    using System.Windows.Input;
	using GalaSoft.MvvmLight.Command;
    using Xamarin.Forms;

    public class MainViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
		#endregion

		#region Attributes
		string _dollars;
		string _euros;
		string _pounds;
		#endregion

		#region Properties
		public string Pesos { get; set; }

		public string Dollars 
        { 
            get
            {
                return _dollars;
            }
            set
            {
                if (_dollars != value)
                {
                    _dollars = value;
                    PropertyChanged?.Invoke(
						this,
						new PropertyChangedEventArgs(nameof(Dollars)));
                } 
            }
        }

		public string Euros
		{
			get
			{
				return _euros;
			}
			set
			{
				if (_euros != value)
				{
					_euros = value;
					PropertyChanged?.Invoke(
						this,
						new PropertyChangedEventArgs(nameof(Euros)));
				}
			}
		}

		public string Pounds
		{
			get
			{
				return _pounds;
			}
			set
			{
				if (_pounds != value)
				{
					_pounds = value;
					PropertyChanged?.Invoke(
						this,
						new PropertyChangedEventArgs(nameof(Pounds)));
				}
			}
		}
		#endregion

		#region Constructors
		public MainViewModel()
        {
        }
		#endregion

        #region Commands
        public ICommand ConvertCommand 
        { 
            get { return new RelayCommand(Convert); } 
        }

        async void Convert()
        {
            if (string.IsNullOrEmpty(Pesos))
			{
                await Application.Current.MainPage.DisplayAlert(
                    "Error", 
                    "You must enter a value in  pesos..", 
                    "Accept");
				return;
			}

			decimal pesos = 0;
            if (!decimal.TryParse(Pesos, out pesos))
			{
				await Application.Current.MainPage.DisplayAlert(
                    "Error", 
                    "You must enter a value numeric in  pesos..", 
                    "Accept");
				return;
			}

			var dollars = pesos / 3003.003M;
			var euros = pesos / 3531.05105M;
			var pounds = pesos / 3907.23724M;

			Dollars = string.Format("${0:N2}", dollars);
			Euros = string.Format("€{0:N2}", euros);
			Pounds = string.Format("£{0:N2}", pounds);
		}
        #endregion
    }
}