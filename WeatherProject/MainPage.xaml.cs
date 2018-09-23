using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeatherProject

    /**
     * Main Page to get the api and combine withe the Objects with the DisplayHolder
     * 
     * Further down I give two links for the api.
     * The first one is an example link from the website to create the app.
     * The second one is a real api link with the weather data from my home town. But you are only allowed to use it once each 10 minutes,
     * because it is forbidden to use it to sell the app.
     * */
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent(); 
            DownloadWeatherDataAsync();
        }

        private async void DownloadWeatherDataAsync()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetStringAsync("http://api.openweathermap.org/data/2.5/weather?id=2842647&APPID=aa7f8c0c6727ac8784e731c8529fd60e");
            //Example link for London with static weather: https://samples.openweathermap.org/data/2.5/weather?q=London,uk&appid=b6907d289e10d714a6e88b30761fae22
            //Real weather in Saarbrucken: http://api.openweathermap.org/data/2.5/weather?id=2842647&APPID=aa7f8c0c6727ac8784e731c8529fd60e

            WeatherRootObject weatherRootObject = JsonConvert.DeserializeObject<WeatherRootObject>(response);

            //Downloadlink for WeatherIcon
            string pngUrl = "http://openweathermap.org/img/w/" + weatherRootObject.weather[0].icon + ".png";

            //Creating the Objects for de data binding in the xaml file
            DisplayHolder displayHolder = new DisplayHolder();
            displayHolder.DisplayTemp           = "  Temperature: "+ (int)(weatherRootObject.main.temp - 273.0) + "°C";
            displayHolder.DisplayName           = weatherRootObject.name + "";
            displayHolder.DisplayTempMin        = "Temperature: " + (int)(weatherRootObject.main.temp_min - 273.0) + "°C";
            displayHolder.DisplayTempMax        = "Temperature: " + (int)(weatherRootObject.main.temp_max - 273.0) + "°C";
            displayHolder.DisplayDescription    = weatherRootObject.weather[0].description.ToUpper();
            displayHolder.DisplayWeatherImage   = ImageSource.FromUri(new Uri(pngUrl));
            BindingContext = displayHolder;
        }
    }
}
