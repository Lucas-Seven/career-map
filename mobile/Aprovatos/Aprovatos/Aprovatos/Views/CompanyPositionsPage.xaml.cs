using Aprovatos.ViewModels;
using Aprovatos.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aprovatos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompanyPositionsPage : ContentPage
    {
        //private CompanyPositionService _service;
        public CompanyPositionsPage()
        {
            InitializeComponent();
        }

        public CompanyPositionsPage(CareerMap career) : this()
        {
            //_service = new CompanyPositionService(career);
        }

        //private async void lstCompanyPositions_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    if (e.SelectedItem == null)
        //    {
        //        return;
        //    }

        //    var position = e.SelectedItem as CompanyPosition;


        //    if (position is null)
        //    {
        //        await DisplayAlert("Erro", "Ocorreu um erro.", "Ok");
        //    }
        //    else
        //    {
        //        await Navigation.PushAsync(new PositionRequirementsPage(position));
        //    }

        //    ((ListView)sender).SelectedItem = null;
        //}

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    try
        //    {
        //        loadData();
        //    }
        //    catch (Exception ex)
        //    {
        //        DisplayAlert("Erro", "Ocorreu um erro.", "Ok");
        //    }
        //}

        //private async void loadData()
        //{
        //    CareerMapCompanyPositions cmCompanyPositions = await _service.LoadDataFromApi();
        //    lblBreadcrumb.Text = $"{cmCompanyPositions.CareerMap.CareerMapName}";

        //    lstCompanyPositions.ItemsSource = new ObservableCollection<CompanyPosition>(cmCompanyPositions.CompanyPositions);
        //}
    }
}