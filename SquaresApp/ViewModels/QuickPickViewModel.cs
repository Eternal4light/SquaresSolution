using SquaresApp.Models;
using SquaresApp.ViewModels.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SquaresApp.ViewModels
{
    internal class QuickPickViewModel : INotifyPropertyChanged
    {
        private const int DEFAULT_SQUARES_QUANTITY = 10;
        private ObservableCollection<Square> squares;

        private AddSquare addSquare;
        private RemoveSquare removeSquare;
        private ChangeColor changeColor;

        private void Initialize()
        {
            Squares = new ObservableCollection<Square>();

            for (int i = 0; i < DEFAULT_SQUARES_QUANTITY; i++)
            {
                Squares.Add(new Square(Square.GetRandomColor()));
            }
        }
        public AddSquare AddSquare
        {
            get { return addSquare ?? (addSquare = new AddSquare(this)); }
        }
        public RemoveSquare RemoveSquare
        {
            get { return removeSquare ?? (removeSquare = new RemoveSquare(this)); }
        }
        public ChangeColor ChangeColor
        {
            get { return changeColor ?? (changeColor = new ChangeColor(this)); }
        }

        public QuickPickViewModel()
        {
            Initialize();
        }

        public ObservableCollection<Square> Squares
        {
            get { return squares; }
            set
            {
                squares = value;
                OnPropertyChanged("Squares");
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