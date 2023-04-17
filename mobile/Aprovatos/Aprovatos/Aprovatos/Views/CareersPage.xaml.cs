using Aprovatos.Service;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Aprovatos.ViewModels;

namespace Aprovatos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CareersPage : ContentPage
    {
        private CareerMapService _service;
        public CareersPage()
        {
            InitializeComponent();
            _service = new CareerMapService();
        }

        private async void lstCareers_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            var career = e.SelectedItem as CareerMapVM;


            if(career is null) 
            {
                //await DisplayAlert("Selecionado", $"{career.CareerMapId} - {career.CareerMapName}", "ok");
                await DisplayAlert("Erro", "Ocorreu um erro.", "Ok");
            }
            else
            {
                await Navigation.PushAsync(new CompanyPositionsPage(career));
            }

            ((ListView)sender).SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                loadData();
            }
            catch(Exception ex)
            {
                DisplayAlert("Erro", "Ocorreu um erro.", "Ok");
            }
        }

        private async void loadData()
        {
            //var data = await _service.LoadDataFromApi();
            var data = await _service.GetCareerMapList();
            ObservableCollection<CareerMapVM> careers = new ObservableCollection<CareerMapVM>(data);
            lstCareers.ItemsSource = careers;
        }
    }
}