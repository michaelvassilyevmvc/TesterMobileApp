using System.ComponentModel;
using Tester.MobileApp.ViewModels;
using Xamarin.Forms;

namespace Tester.MobileApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}