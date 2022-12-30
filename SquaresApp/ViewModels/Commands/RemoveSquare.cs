using System;
using System.Linq;
using System.Windows.Input;

namespace SquaresApp.ViewModels.Commands
{
    internal class RemoveSquare : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private QuickPickViewModel _vm;
        public RemoveSquare(QuickPickViewModel vm)
        {
            _vm = vm;
        }
        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            if (_vm.Squares == null || _vm.Squares.Count < 1)
                return;

            _vm.Squares.Remove(_vm.Squares.Last());
        }
    }
}