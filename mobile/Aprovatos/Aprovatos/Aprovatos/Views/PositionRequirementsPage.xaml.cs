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
    public partial class PositionRequirementsPage : ContentPage
    {
        private RequirementService _service;
        public PositionRequirementsPage()
        {
            InitializeComponent();
        }

        public PositionRequirementsPage(CompanyPositionVM companyPosition) : this()
        {
            _service = new RequirementService(companyPosition);
        }

        private async void lstPositionRequirements_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            var requirement = e.SelectedItem as RequirementVM;


            if (requirement is null)
            {
                await DisplayAlert("Erro", "Ocorreu um erro.", "Ok");
            }
            else
            {
                
                await DisplayAlert("Selecionado", $"navegar para a pagina  dos testes de {requirement.GroupName}/{requirement.RequirementName}", "Ok");
                //await Navigation.PushAsync(new PositionRequirementsPage(position));
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
            catch (Exception ex)
            {
                DisplayAlert("Erro", "Ocorreu um erro.", "Ok");
            }
        }

        private async void loadData()
        {
            RequirementListVM requirements = await _service.GetRequirementsList();
            lblBreadcrumb.Text = $"{requirements.CompanyPosition.ParentCareerMapVm.CareerMapName} > {requirements.CompanyPosition.CompanyPositionName}";

            lstPositionRequirements.ItemsSource = new ObservableCollection<RequirementVM>(requirements.Requirements);
       }
    }
}