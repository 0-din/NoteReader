using System.Windows;
using System.Windows.Media;

namespace NoteReader;

internal class Sheet
{
	private readonly DrawingContext context;
	private readonly Rect page;
	private readonly double _pixelsPerDip;
	private readonly string Keys = "";

	private Staff Stave
	{
		get;
		set;
	}

	public Sheet(DrawingContext context, Rect page, string keys, double pixelsPerDip = 1)
	{
		_pixelsPerDip = pixelsPerDip;
	
		this.context = context;
		this.page = page;
		this.Keys = keys;
		this.Stave = new Staff(context, page, pixelsPerDip, keys);

		context.DrawRectangle(Brushes.White, new Pen(Brushes.Gray, 1), page);
	}

	public void Render()
	{
		Stave.Draw();
	}
}
