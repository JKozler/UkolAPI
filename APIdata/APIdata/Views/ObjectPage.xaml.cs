using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using APIdata.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APIdata.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ObjectPage : ContentPage
    {
        ObservableCollection<Telesa> cCollection;
        public ObjectPage()
        {
            InitializeComponent();
        }
        public ObjectPage(Telesa tl, ObservableCollection<Telesa> telesas)
        {
            InitializeComponent();
            cCollection = telesas;
            typeObject.Items.Add("True");
            typeObject.Items.Add("False");
            nameTxt.Text = tl.Name;
            closeTxt.Date = tl.CloseApproachDate;
            speedTxt.Text = tl.KMPerHour.ToString();
            missTxt.Text = tl.MissDistance.ToString();
            typeObject.SelectedItem = tl.IsDangerous.ToString();
        }

        private void Submit_Clicked(object sender, EventArgs e)
        {
            var ob = cCollection.FirstOrDefault(i => i.Name == nameTxt.Text);
            cCollection.Remove(ob);
            cCollection.Add(new Telesa { Name = nameTxt.Text, CloseApproachDate = Convert.ToDateTime(closeTxt.Date), IsDangerous = Convert.ToBoolean(typeObject.SelectedItem), KMPerHour = Convert.ToDouble(speedTxt.Text), MissDistance = Convert.ToDouble(missTxt.Text) });
            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}