using System;
using System.Collections.Generic;
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
        public CompanyPositionsPage()
        {
            InitializeComponent();
        }

        private async void lstCompanyPositions_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new PositionRequirementsPage());
        }
    }
}