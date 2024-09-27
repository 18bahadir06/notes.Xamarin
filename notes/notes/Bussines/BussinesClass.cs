using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace notes.Bussines
{
    public class BussinesClass
    {
        public Color RandomColor()
        {
            Random rnd = new Random();
            int x = rnd.Next(0,255);
            int y = rnd.Next(0,255);
            int z = rnd.Next(0, 255);
            return Color.FromRgb(x, y, z);
        }
        public string ColorToHex(Color color) 
        {
            int r = (int)(color.R * 255);
            int g = (int)(color.G * 255);
            int b = (int)(color.B * 255);
            return $"#{r:X2}{g:X2}{b:X2}";
        }
        public Color HexToColor(string hex) 
        {
           return Color.FromHex(hex);
        }
    }
}
