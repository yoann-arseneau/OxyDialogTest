using OxyPlot;
using OxyPlot.Series;
using System.Windows.Input;

namespace OxyDialogTest {
	class Point {
		public static implicit operator Point(in (double x, double y) pair) {
			return new(pair.x, pair.y);
		}

		public double X { get; }
		public double Y { get; }

		public Point(double x, double y) {
			X = x;
			Y = y;
		}
	}

	class MainWindowViewModel : ViewModelBase {
		private PlotModel _WindowPlot;
		public PlotModel WindowPlot {
			get => _WindowPlot;
			set => ChangeProperty(ref _WindowPlot, value);
		}
		private PlotModel _DialogPlot;
		public PlotModel DialogPlot {
			get => _DialogPlot;
			set => ChangeProperty(ref _DialogPlot, value);
		}

		private ICommand _swapCommand;
		public ICommand SwapCommand => _swapCommand ??= new DelegateCommand(DoSwap);

		public MainWindowViewModel() {
			WindowPlot = NewModel("Window Plot", (1, 1), (2, 1), (3, 2), (4, 2), (5, 4));
			DialogPlot = NewModel("Dialog Plot", (1, 3), (2, 1), (3, 4), (4, 3), (5, 4));

			static PlotModel NewModel(string title, params Point[] data) {
				return new() {
					Title = title,
					Series = {
						new LineSeries() {
							ItemsSource = data,
							DataFieldX = nameof(Point.X),
							DataFieldY = nameof(Point.Y),
						},
					},
				};
			}
		}

		public void DoSwap() {
			var wp = WindowPlot;
			var dp = DialogPlot;
			WindowPlot = null;
			DialogPlot = null;
			WindowPlot = dp;
			DialogPlot = wp;
		}
	}
}
