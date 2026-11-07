using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NoteReader;

internal class Clef
{
	private readonly DrawingContext context;
	private readonly Rect page;
	private readonly double _pixelsPerDip;

	public Clef(DrawingContext context, Rect page, double pixelsPerDip)
	{
		this.context = context;
		this.page = page;
		_pixelsPerDip = pixelsPerDip;
	}

	public void Draw()
	{
	//	var text = new FormattedText(
	//"𝄞",
	//System.Globalization.CultureInfo.InvariantCulture,
	//FlowDirection.LeftToRight,
	//new Typeface("Segoe UI Symbol"),
	//64,
	//Brushes.Black,
	//_pixelsPerDip);

	//	// Measure the visible outline instead of the font's text layout box.
	//	Geometry clef = text.BuildGeometry(new Point(0, 0));
	//	Rect ink = clef.Bounds;
	//	double scale = (7 * lineSpacing) / ink.Height;

	//	// This anchor is calibrated for the Segoe UI Symbol treble clef:
	//	// its G-line curl is about 5/8 of the way down the visible outline.
	//	double curlY = ink.Top + ink.Height * 0.625;
	//	double gLineY = top + 3 * lineSpacing;
	//	double left = page.Left + margin + lineSpacing;

	//	clef.Transform = new MatrixTransform(
	//		scale, 0, 0, scale,
	//		left - ink.Left * scale,
	//		gLineY - curlY * scale);

	//	context.DrawGeometry(Brushes.Black, null, clef);
	}
}
