using Xamarin.Forms;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Net;
using ThesisXamarin.Model;
using System.Collections.Generic;
using System;

namespace ThesisXamarin.Logic
{
    public interface ListItemsLoader
    {
        Task<ObservableCollection<ListItem>> LoadItems();
    }

    public class LocalListItemsLoader : ListItemsLoader
    {
        public Task<ObservableCollection<ListItem>> LoadItems()
        {
            return Task<ObservableCollection<ListItem>>.Run(() => {
                Assembly assembly = Assembly.GetExecutingAssembly();
                using (Stream stream = assembly.GetManifestResourceStream("ThesisXamarin.Assets.listItems.json"))
                using (StreamReader reader = new StreamReader(stream))
                {
                    string fileStr = reader.ReadToEnd();
                    List<ListItemData> itemDatas = JsonConvert.DeserializeObject<List<ListItemData>>(fileStr);

                    List<ListItem> mappedItems = itemDatas.ConvertAll<ListItem>((item) =>
                    {
                        return new ListItem(item.description, ImageSource.FromResource(item.imageSrc));
                    });

                    return new ObservableCollection<ListItem>(mappedItems);
                }
            });
        }
    }

    public class NetworkListItemsLoader : ListItemsLoader
    {
        public Task<ObservableCollection<ListItem>> LoadItems()
        {
            return Task<ObservableCollection<ListItem>>.Run(() =>
            {
                using (WebClient wc = new WebClient())
                {
                    string jsonStr = wc.DownloadString("http://192.168.1.158/thesis/listItems.json");
                    List<ListItemData> itemDatas = JsonConvert.DeserializeObject<List<ListItemData>>(jsonStr);
                    
                    List<ListItem> mappedItems = itemDatas.ConvertAll<ListItem>((item) =>
                    {
                        return new ListItem(item.description, ImageSource.FromUri(new Uri(item.imageSrc)));
                    });

                    return new ObservableCollection<ListItem>(mappedItems);
                }
            });
        }
    }

    class ListItemData
    {
        public string description;
        public string imageSrc;

        public ListItemData(string description, string imageSrc)
        {
            this.description = description;
            this.imageSrc = imageSrc;
        }
    }
}
