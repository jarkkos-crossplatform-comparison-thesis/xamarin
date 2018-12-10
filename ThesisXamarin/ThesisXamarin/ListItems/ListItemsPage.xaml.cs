using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using ThesisXamarin.Logic;
using ThesisXamarin.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThesisXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListItemsPage : ContentPage
    {
        public ObservableCollection<ListItem> ListItems { get; set; }

        public ListItemsPage(ListItemsLoader itemsLoader)
        {
            InitializeComponent();
            LoadingItemsIndicator.IsVisible = true;
            loadItems(itemsLoader);
        }

        private async void loadItems(ListItemsLoader itemsLoader)
        {
            ListItems = await itemsLoader.LoadItems();
            LoadingItemsIndicator.IsVisible = false;
            ItemListView.ItemsSource = ListItems;
        }
    }
}
