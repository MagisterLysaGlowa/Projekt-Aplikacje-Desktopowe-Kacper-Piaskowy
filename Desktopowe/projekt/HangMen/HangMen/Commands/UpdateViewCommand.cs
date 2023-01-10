using HangMen.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HangMen.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;
        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if(parameter.ToString() == "Home")
            {
                viewModel.SelectedViewModel = new HomeViewModel();
            }
            else if(parameter.ToString() == "Account")
            {
                viewModel.SelectedViewModel = new RankingViewModel();
            }
            else if(parameter.ToString() == "PasswordOperations")
            {
                viewModel.SelectedViewModel = new PasswordOperationsViewModel();
            }
        }
    }
}
