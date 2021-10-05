using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ShopApp
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class AddProd : Page
	{
		public string message = "";
		public AddProd()
		{
			this.InitializeComponent();
		}

		async private void AddProduct(object sender, RoutedEventArgs e)
		{
			HttpClient client = new HttpClient();
			string url = "http://alcoin-shop.herokuapp.com/api/addNavItem";
			var values = new Dictionary<string, string>
			{
				{ "name", prodName.Text }
			};
			var content = new FormUrlEncodedContent(values);

			var response = await client.PostAsync(url, content);
			message = "Category added!";
		}
	}
}
