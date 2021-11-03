using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.LocalNotification;
using System.Net.Http;
using Tester.MobileApp.Models;

namespace Tester.MobileApp.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            NotificationCenter.Current.NotificationReceived += Current_NotificationReceived;
            NotificationCenter.Current.NotificationTapped += Current_NotificationTapped;
        }

        

        private void Current_NotificationTapped(NotificationEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                DisplayAlert("Notification tapped", e.Request.ReturningData, "Ok");
            });
        }

        private void Current_NotificationReceived(NotificationEventArgs e)
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    DisplayAlert(e.Request.Title, e.Request.Description, "Ok");
                });
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var notification = new NotificationRequest
            {
                BadgeNumber = 1,
                Description = "Test Description",
                Title = "Notification",
                ReturningData = "Dummy Data",
                NotificationId = 1337,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(5)
                },
            };

            NotificationCenter.Current.Show(notification);
        }
    }
}