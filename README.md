# AgilPay SDK Xamarin Sample
Sample project that guide you how to use the Paynet mobile SDK for Xamarin.Forms

# Setup
 * SDK Available on NuGet: https://www.nuget.org/packages/AgilPay.SDK.Xamarin/
 * Install into your .NETStandard project and Client projects.


# Getting Started
After installing the package on your Shared, Android and iOS projects you should initialize the SDK by calling the Initialize method:
 

```csharp
var environmentUrl = "https://sandbox-webapi.agilpay.net/";
var clientId = "API-001";
var clientSecret = "Dynapay";
await PaymentService.Initialize(environmentUrl, clientId, clientSecret);
```

**The environment URLs are:**
* for test environment: https://sandbox-webpay.agilpay.net/ 
* for production environment: https://webpay.agilpay.net/ 

Now you are ready to use process payments

# Usage

```csharp
await PaymentService.ProcessPayment(new Agilisa.Paymentsdk.Xamarin.Models.PaymentRequest
                {
                    Amount = 15.33,
                    Currency = "840",
                    CustomerEmail = "YourEmail@Mail.com",
                    CustomerId = "YourUser",
                    CustomerName = "John Doe",
                    Invoice = "123456",
                    MerchantKey = "TEST-001",
                    Tax = 1.43
                }, this);
```
To get the response of the process payment, we use the interface Agilisa.Paymentsdk.Xamarin.IPaymentResult, with the methods
* OnPaymentResult(Transaction transaction);
* OnError(string error);

if transaction.ResponseCode is equal to "00" the transaction was approved otherwise it was declined