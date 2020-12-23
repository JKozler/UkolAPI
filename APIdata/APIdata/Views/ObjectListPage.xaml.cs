using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using APIdata.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APIdata.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ObjectListPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public ObjectListPage()
        {
            InitializeComponent();
            AllCurentObjects telesa = new AllCurentObjects();
            BindingContext = telesa;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
