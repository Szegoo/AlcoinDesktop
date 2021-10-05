using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ShopApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Product> Products { get; }
        = new ObservableCollection<Product>();
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += LoadedHandler;
        }
        private async void LoadedHandler(object sender, RoutedEventArgs e)
		{
            await getProducts();
		}
        async public Task getProducts()
		{
            string url = "http://alcoin-shop.herokuapp.com/api/posts?category=null&page=0";
            try
            {
                //We will now define your HttpClient with your first using statement which will use a IDisposable.
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(url)) 
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
							Console.WriteLine(data);

                            if(data != null)
							{
                                var dataArr = JArray.Parse(data);
                                for(int i = 0; i < dataArr.Count; i++)
								{
                                    var dataObj = dataArr[i];
                                    Product prod = new Product($"{dataObj["title"]}",
                                        $"{dataObj["price"]}", $"{dataObj["image"]}");
                                    this.Products.Add(prod);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception Hit------------");
                Console.WriteLine(exception);
            }
		}
    }
}
