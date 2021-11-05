using System;
using Tester.MobileApp.Services;
using Tester.MobileApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.FirebasePushNotification;
using Tester.MobileApp.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace Tester.MobileApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
            CrossFirebasePushNotification.Current.OnTokenRefresh += Current_OnTokenRefresh;
            CrossFirebasePushNotification.Current.OnNotificationOpened += Current_OnNotificationOpened;
            CrossFirebasePushNotification.Current.OnNotificationReceived += Current_OnNotificationReceived;
        }

        private void Current_OnNotificationReceived(object source, FirebasePushNotificationDataEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("RECEIVED");
        }

        private void Current_OnNotificationOpened(object source, FirebasePushNotificationResponseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("OPENED");
        }

        private void Current_OnTokenRefresh(object source, FirebasePushNotificationTokenEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"TOKEN: {e.Token}");
            Send(e.Token);
        }

        private async Task Send(string token)
        {
            //var phone = new Phone
            //{
            //    ID = 0,
            //    Number = "+77771085418",
            //    Token = token
            //};

            NotificationModel notificationModel = new NotificationModel
            {
                DeviceId = token,
                IsAndroiodDevice = true,

            };

            string json = JsonConvert.SerializeObject(notificationModel);
            HttpContent content = new StringContent(json);

            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri("http://localhost:63539/api/mobile/send");
            request.Method = HttpMethod.Post;
            request.Content = content;
            HttpResponseMessage response = await client.SendAsync(request);

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
