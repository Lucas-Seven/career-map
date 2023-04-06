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
    public partial class PositionRequirementsPage : ContentPage
    {
        public PositionRequirementsPage()
        {
            InitializeComponent();
        }

        private void lstPositionRequirements_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}