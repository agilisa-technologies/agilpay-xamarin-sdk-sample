using Agilisa.Paymentsdk.Xamarin;
using agilpay.client.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace agilpay_xamarin_sdk_sample
{
    public partial class MainPage : ContentPage, IPaymentResult
    {
        public MainPage()
        {
            InitializeComponent();

            entryInvoice.Text = Guid.NewGuid().ToString().Substring(0, 8).Replace("-", "");
        }

        public void OnError(string error)
        {
            Console.WriteLine(error);
        }

        public void OnPaymentResult(Transaction result)
        {
            Console.WriteLine(result);
        }

        private async void ProcessPaymentClicked(object sender, EventArgs e)
        {
            try
            {
                progress.IsRunning = true;
                progress.IsVisible = true;

                if (!PaymentService.IsInitialized)
                {
                    await PaymentService.Initialize(entryUrl.Text, entryClientId.Text, entryClientSecret.Text);
                }

                double.TryParse(entryAmount.Text, out double amount);

                await PaymentService.ProcessPayment(new Agilisa.Paymentsdk.Xamarin.Models.PaymentRequest
                {
                    Amount = amount,
                    Currency = entryCurrency.Text,
                    CustomerEmail = entryEmail.Text,
                    CustomerId = entryCustomerId.Text,
                    CustomerName = entryCustomerName.Text,
                    Invoice = entryInvoice.Text,
                    MerchantKey = entryMerchantKey.Text,
                    Tax = 0
                }, this);

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                await DisplayAlert("Error", ex.Message, "Ok");
            }
            progress.IsRunning = false;
            progress.IsVisible = false;
        }

        private async void ShowCredentials(object sender, EventArgs e)
        {
            layoutCredentials.IsVisible = !layoutCredentials.IsVisible;

            await Task.Delay(100);

            btnShowCredentials.Text = layoutCredentials.IsVisible ? "Hide credentials" : "Show credentials";
        }
    }
}
