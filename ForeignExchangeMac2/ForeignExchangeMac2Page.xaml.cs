using Xamarin.Forms;

namespace ForeignExchangeMac2
{
    public partial class ForeignExchangeMac2Page : ContentPage
    {
        public ForeignExchangeMac2Page()
        {
            InitializeComponent();

            ConvertButton.Clicked += ConvertButton_Clicked;
        }

        void ConvertButton_Clicked(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(PesosEntry.Text))
            {
				DisplayAlert("Error", "You must enter a value in  pesos..", "Accept");
                return;
			}

            decimal pesos = 0;
            if (!decimal.TryParse(PesosEntry.Text, out pesos))
            {
				DisplayAlert("Error", "You must enter a value numeric in  pesos..", "Accept");
				return;
			}

			var dollars = pesos / 3003.003M;
			var euros = pesos / 3531.05105M;
			var pounds = pesos / 3907.23724M;

			DollarsEntry.Text = string.Format("${0:N2}", dollars);
            EurosEntry.Text = string.Format("€{0:N2}", euros);
            PoundsEntry.Text = string.Format("£{0:N2}", pounds);
		}
    }
}
