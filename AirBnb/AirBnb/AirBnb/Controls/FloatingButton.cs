using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AirBnb.Controls
{
    public class FloatingButton : Button
    {
        public FloatingButton()
        {
            BackgroundColor = Color.FromHex("1E90FF");
            CornerRadius = 100;
            HeightRequest = 60;
            WidthRequest = 60;
            FontSize = 20;
            TextColor = Color.White;
            FontAttributes = FontAttributes.Bold;
        }
    }
}
