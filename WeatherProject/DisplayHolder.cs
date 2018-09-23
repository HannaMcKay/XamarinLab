using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WeatherProject

    /**
     * For better structur of the code, because json gives more than one class.
     * Holds the important ui objects.
     * **/
{
    class DisplayHolder
    {
        public string DisplayTemp { get; set; }
        public string DisplayName { get; set; }
        public string DisplayTempMax { get; set; }
        public string DisplayTempMin { get; set; }
        public string DisplayDescription { get; set; }
        public ImageSource DisplayWeatherImage { get; set; }

        public DisplayHolder() { }
    }
}
