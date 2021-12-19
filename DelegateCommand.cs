using System;
using System.Windows.Input;

namespace OxyDialogTest {
	class DelegateCommand : ICommand {
		public event EventHandler CanExecuteChanged;

		private Action execute;

		public DelegateCommand(Action execute) {
			this.execute = execute;
		}

		public bool CanExecute(object parameter) => true;
		public void Execute(object parameter) => execute?.Invoke();
	}
}
