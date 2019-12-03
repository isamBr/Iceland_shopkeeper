using Iceland_shopkeeper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Iceland_shopkeeper.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemPage : ContentPage
    {
        int result;
        public ItemPage()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var ItemSelected = (Item)BindingContext;
            ItemSelected.Item_date = DateTime.Today;
            result = DateTime.Today.CompareTo(ItemSelected.Item_date);
            string relationship;

            if (result < 0)
                relationship = "is earlier than";
            else if (result == 0)
            {
                relationship = "is the same time as";
                ItemSelected.NumersOfDaysToSellOutPut = ItemSelected.NumersOfDaysToSellInput;
                ItemSelected.QualityOutPut = ItemSelected.QualityInput ;

            }
            else
                relationship = "is later than";


            int n;
            var isNumeric = int.TryParse(quality.Text, out n);
            if (string.IsNullOrWhiteSpace(NameI.Text))
            {
                await DisplayAlert("Warning", "Name must has value !", "OK");
                return;
            }
            if (!string.IsNullOrWhiteSpace(quality.Text) && !isNumeric&& ItemSelected .QualityInput<= 50)
            {
                await DisplayAlert("Warning", "Quality must be number between 0 and 50 !", "OK");
                return;
            }
            isNumeric = int.TryParse(DaysToSell.Text, out n);
            if (!string.IsNullOrWhiteSpace(DaysToSell.Text) && !isNumeric)
            {
                await DisplayAlert("Warning", "Days To Sell must be number !", "OK");
                return;
            }




            if (!(ItemSelected.Name.ToLower() == "soap") &&
                !(ItemSelected.Name.ToLower() == "frozen item") &&
                !(ItemSelected.Name.ToLower() == "fresh Item") &&
                !(ItemSelected.Name.ToLower() == "aged brie") &&
                !(ItemSelected.Name.ToLower() == "christmas crackers"))
            {
                await DisplayAlert("Warning", " NO SUCH ITEM NAME "+ ItemSelected.Name, "OK");
                return;

            }
        
            await App.Database.SaveItemAsync(ItemSelected);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var ItemSelected = (Item)BindingContext;        
            await App.Database.DeleteItemAsync(ItemSelected);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
  
    }
}
