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
    public partial class ItemsListPage : ContentPage
    {
        string relationship;
        public ItemsListPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeItems = -1;
            List<Item> list = await App.Database.GetItemsAsync();
            int result;

            foreach (var item in list)
            {
                result = DateTime.Today.CompareTo(item.Item_date);
                if (result < 0)
                    relationship = "is earlier than";
                else if (result == 0)
                    relationship = "is the same time as";
                else
                    relationship = "is later than";
                if (item.Name.ToLower() == "soap")//nothing happen
                {
                    item.QualityOutPut = item.QualityInput;
                    item.NumersOfDaysToSellOutPut = item.NumersOfDaysToSellOutPut;

                }
                if (item.Name.ToLower() == "frozen item")// decreases in Quality by 1 
                {
                    if (item.QualityInput <= 50)
                    {
                        item.QualityOutPut = item.QualityInput - result;
                        item.NumersOfDaysToSellOutPut = item.NumersOfDaysToSellInput - result;
                    }
                    else if (item.QualityInput > 50)
                    {
                        item.QualityOutPut = 50;
                        item.NumersOfDaysToSellOutPut = item.NumersOfDaysToSellInput - result;
                    }


                }
                if (item.Name.ToLower() == "fresh Item")//degrade in Quality twice as fast as “Frozen Item
                {
                    item.QualityInput = item.QualityOutPut - (result * 2);
                    item.NumersOfDaysToSellOutPut = item.NumersOfDaysToSellInput - result;

                }
                if (item.Name.ToLower() == "aged brie")//increases in Quality the older it gets 
                {
                    if (item.Name.ToLower() == "christmas crackers")
                    {
                        if (result <= 10)
                        {
                            item.QualityInput = item.QualityOutPut + (result * 2);
                            item.NumersOfDaysToSellOutPut = item.NumersOfDaysToSellInput - result;
                        }
                        else if (result <= 5)
                        {
                            item.QualityInput = item.QualityOutPut + (result * 3);
                            item.NumersOfDaysToSellOutPut = item.NumersOfDaysToSellInput - result;
                        }
                        else if (result < 0)
                        {
                            item.QualityInput = 0;
                            item.NumersOfDaysToSellOutPut = item.NumersOfDaysToSellInput - result;


                        }
                    }

                    if (item.Name.ToLower() == "christmas crackers")
                    {
                        if (result <= 10)
                        {
                            item.QualityInput = item.QualityOutPut + (result * 2);
                            item.NumersOfDaysToSellOutPut = item.NumersOfDaysToSellInput - result;
                        }
                        else if (result <= 5)
                        {
                            item.QualityInput = item.QualityOutPut + (result * 3);
                            item.NumersOfDaysToSellOutPut = item.NumersOfDaysToSellInput - result;
                        }
                        else if (result < 0)
                        {
                            item.QualityInput = 0;
                            item.NumersOfDaysToSellOutPut = item.NumersOfDaysToSellInput - result;


                        }
                    }                   

                }
                if (item.QualityOutPut < 0)
                    item.QualityOutPut = 0;
                await App.Database.SaveItemAsync(item);


            }
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemPage
            {
                BindingContext = new Item()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TodoItem).ID;
            //Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TodoItem).ID);
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ItemPage
                {
                    BindingContext = e.SelectedItem as Item
                });
            }
        }
    }
}
