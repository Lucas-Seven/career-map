using Aprovatos.Models;
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
    public partial class PositionRequirementsPage : ContentPage
    {
        //private CompanyPositionRequirementsService _service;
        public PositionRequirementsPage()
        {
            InitializeComponent();
        }

        public PositionRequirementsPage(CompanyPosition companyPosition) : this()
        {
            //_service = new CompanyPositionRequirementsService(companyPosition);
        }

        private async void lstPositionRequirements_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //if (e.SelectedItem == null)
            //{
            //    return;
            //}

            //var requirements = e.SelectedItem as PositionRequirement;


            //if (requirements is null)
            //{
            //    await DisplayAlert("Erro", "Ocorreu um erro.", "Ok");
            //}
            //else
            //{
            //    await DisplayAlert("Selecionado", $"{requirements.RequirementName}", "ok");
            //    //await Navigation.PushAsync(new PositionRequirementsPage(requirements));
            //    //await Navigation.PushAsync(new CompanyPositionsPage(career));
            //}

            //((ListView)sender).SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                loadData();
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", "Ocorreu um erro.", "Ok");
            }
        }

        private async void loadData()
        {
            //CompanyPositionRequirements cmCompanyPositions = await _service.LoadDataFromApi();
            //lblBreadcrumb.Text = $"{cmCompanyPositions.CareerMap.CareerMapName}";

            //lstCompanyPositions.ItemsSource = new ObservableCollection<CompanyPosition>(cmCompanyPositions.CompanyPositions);
        }
    }
}