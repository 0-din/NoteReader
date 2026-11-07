using System.Windows;
using System.Windows.Media;

namespace NoteReader;

public class Staff
{
	private readonly DrawingContext context;
	private readonly Rect page;
	private readonly double _pixelsPerDip;
	private readonly string Keys = "";
	private const double margin = 30;
	private const double lineSpacing = 8;
	private const double staffGap = 28;
	private const int linePerStaff = 5;

	public Staff(DrawingContext context, Rect page, double pixelsPerDip, string keys)
	{
		this.context = context;
		this.page = page;
		_pixelsPerDip = pixelsPerDip;
		Keys = keys;
	}

	public void Draw()
	{
		var pen = new Pen(Brushes.Black, 1);
		double left = page.Left + margin;
		double right = page.Right - margin;
		double staffHeight = (linePerStaff - 1) * lineSpacing;

		for (double top = page.Top + margin; top + margin <= page.Bottom; top += staffHeight + staffGap)
		{
			DrawClef(top);
			DrawBar(top);

			for (int line = 0; line < linePerStaff; line++)
			{
				double y = top + line * lineSpacing;
				context.DrawLine(pen, new Point(left, y), new Point(right, y));

				DrawKey(left + 40, y - 12);
			}
		}
	}

	private void DrawBar(double top)
	{
		const int barPerLine = 4;
		double barWidth = page.Width / barPerLine;
		var pen = new Pen(Brushes.Black, 1.5);

		for (int bar = 0; bar < barPerLine; bar++)
		{
			double x = margin + bar * barWidth;
			context.DrawLine(pen, new Point(x, top), new Point(x, top + lineSpacing * (linePerStaff - 1)));
		}
	}

	private void DrawClef(double top)
	{
		var text = new FormattedText(
			"𝄞",
			System.Globalization.CultureInfo.InvariantCulture,
			FlowDirection.LeftToRight,
			new Typeface("Segoe UI Symbol"),
			64,
			Brushes.Black,
			_pixelsPerDip);

		Geometry clef = text.BuildGeometry(new Point(0, 0));
		Rect ink = clef.Bounds;
		double scale = (7 * lineSpacing) / ink.Height;

		double curlY = ink.Top + ink.Height * 0.625;
		double gLineY = top + 3 * lineSpacing;
		double left = page.Left + margin + lineSpacing;

		clef.Transform = new MatrixTransform(
			scale, 0, 0, scale,
			left - ink.Left * scale,
			gLineY - curlY * scale);

		context.DrawGeometry(Brushes.Black, null, clef);
	}

	private void DrawKey(double x, double y)
	{
		for (int k = 0; k < Keys.Length; k++)
		{
			var key = Keys[k];

			var text = new FormattedText(
				$"{key}",
				System.Globalization.CultureInfo.InvariantCulture,
				FlowDirection.LeftToRight,
				new Typeface("Segoe UI Symbol"),
				16,
				Brushes.Black,
				_pixelsPerDip);

			context.DrawText(text, new Point(x, y));
		}
	}
}