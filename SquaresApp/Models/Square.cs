using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace SquaresApp.Models
{
    internal class Square : INotifyPropertyChanged
    {
        private Guid id;
        private Color color;
        private string colorString;

        private string ValidateNumber(int number)
        {
            var res = Convert.ToString(number, 16);

            if (String.IsNullOrEmpty(res))
                return null;

            if (res.Length == 1)
                res = $"0{res}";

            return res;
        }
        internal static Color GetRandomColor()
        {
            Random rnd = new Random();

            // Max is 200 to avoid white ones
            int red = rnd.Next(0, 200);
            int green = rnd.Next(0, 200);
            int blue = rnd.Next(0, 200);

            return Color.FromArgb(red, green, blue);
        }

        internal Square(Color color)
        {
            id = Guid.NewGuid();
            this.color = color;
        }
        public string ColorString
        {
            get
            {
                colorString = $"#{ValidateNumber(Color.R)}{ValidateNumber(Color.G)}{ValidateNumber(Color.B)}";
                return colorString;
            }
            set
            {
                colorString = value;
                OnPropertyChanged("ColorString");
            }
        }
        public Guid Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public Color Color
        {
            get { return color; }
            set
            {
                color = value;
                OnPropertyChanged("Color");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}