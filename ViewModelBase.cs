using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OxyDialogTest {
	abstract class ViewModelBase : INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged;

		protected void ChangeProperty<T>(ref T field, T newValue, [CallerMemberName] string name = null) {
			field = newValue;
			OnPropertyChanged(name);
		}
		protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new(name));
	}
}
