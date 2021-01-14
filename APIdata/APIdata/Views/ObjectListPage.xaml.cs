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
        AllCurentObjects telesa = new AllCurentObjects();
        public ObjectListPage()
        {
            InitializeComponent();
            BindingContext = telesa;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).BackgroundColor = new Color(255,120,255);
            if (e.Item == null)
                return;

            Page p = new ObjectPage((((ListView)sender).SelectedItem) as Telesa, (BindingContext as AllCurentObjects).AllObjects);
            NavigationPage np = new NavigationPage(p);
            await Application.Current.MainPage.Navigation.PushAsync(np);

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private async void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            if (Convert.ToDateTime(datePicker.Date) > DateTime.Now)
                await DisplayAlert("Bad date.", "Date have to be in past.", "OK");
            else
                await LoadNewValues();
        }

        public async Task LoadNewValues() 
        {
            await telesa.GetFromAPIByDate(Convert.ToDateTime(datePicker.Date));
            BindingContext = telesa;
        }
    }
}
