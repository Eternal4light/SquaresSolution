using SquaresApp.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SquaresApp.ViewModels.Commands
{
    internal class AddSquare : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private QuickPickViewModel _vm;
        public AddSquare(QuickPickViewModel vm)
        {
            _vm = vm;
        }
        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            if (_vm.Squares == null)
                _vm.Squares = new ObservableCollection<Square>();

            _vm.Squares.Add(new Square(Square.GetRandomColor()));
        }
    }
}