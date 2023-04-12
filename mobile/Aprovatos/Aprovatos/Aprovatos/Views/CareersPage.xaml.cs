using Aprovatos.Service;
using System;
using System.Collections.ObjectModel;
using Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

            //await Navigation.PushAsync(new ProdutosListaPage(fornecedor));
            //await Navigation.PushAsync(new CompanyPositionsPage());

            await DisplayAlert("Selectionado", $"{career.CareerMapId} - {career.CareerMapName}", "ok");

            ((ListView)sender).SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                carregaDados();
            }
            catch(Exception ex)
            {
                DisplayAlert("Erro", "Ocorreu um erro.", "Ok");
            }
        }

        private async void carregaDados()
        {
            var data = await _service.LoadDataFromApi();
            ObservableCollection<CareerMapVM> careers = new ObservableCollection<CareerMapVM>(data);
            lstCareers.ItemsSource = careers;
        }
    }
}