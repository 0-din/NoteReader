using System.Windows;
using System.Windows.Media;

namespace NoteReader
{
    public partial class MainWindow : Window
    {
		public MainWindow()
		{
			InitializeComponent();

			double pixelsPerDip = VisualTreeHelper.GetDpi(this).PixelsPerDip;
			
			DrawingVisual visual = new DrawingVisual();
			var page = new Rect(0, 0, 800, 400);

			using (DrawingContext context = visual.RenderOpen())
			{
				var staff = new Sheet(context, page, "♯", pixelsPerDip);

				staff.Render();
			}

			canvas.Source = new DrawingImage(visual.Drawing);
		}
	}
}
