using SquaresApp.Models;
using System;
using System.Linq;
using System.Windows.Input;

namespace SquaresApp.ViewModels.Commands
{
    internal class ChangeColor : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private QuickPickViewModel _vm;
        public ChangeColor(QuickPickViewModel vm)
        {
            _vm = vm;
        }
        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            var color = Square.GetRandomColor();
            var index = _vm.Squares.IndexOf(_vm.Squares.First(s => s.Id == (Guid)parameter));

            // To create a new instance is safer
            _vm.Squares[index] = new Square(color);
        }
    }
}