using System;
using System.Drawing;

namespace GfxTools
{
	public class Tools
	{
		Bitmap source = null;
		Bitmap destination = null;
		Graphics graphics = null;
		Color color;
		Color ignoredColor1 = Color.FromArgb (0, 138, 118);
		Color ignoredColor2 = Color.FromArgb (0, 0, 0);
		Color transparent = Color.FromArgb (0, 0, 0, 0);

		public Tools ()
		{
		}

		public void LoadImage (string fileName)
		{
			source = new Bitmap (fileName);
		}

		public int SourceWidth { get { return source.Width; } }

		public int SourceHeight { get { return source.Height; } }

		public void PrepareNewImage (int width, int height)
		{
			destination = new Bitmap (width, height);
			graphics = Graphics.FromImage (destination);
		}

		public void CopyGraphics (int fromX, int fromY, int toX, int toY, int width, int height)
		{
			color = source.GetPixel (fromX, fromY);
			if (color == ignoredColor1) {
				color = source.GetPixel (fromX + width - 1, fromY + height - 1);
				if (color == ignoredColor1) {
					color = source.GetPixel (fromX, fromY + height - 1);
					if (color == ignoredColor1) {
						color = source.GetPixel (fromX + width - 1, fromY);
						if (color == ignoredColor1)
							return;
					}
				}
			} else {
				if (color == ignoredColor2)
					return;
			}
			Rectangle s = new Rectangle (fromX, fromY, width, height);
			Rectangle d = new Rectangle (toX, toY, width, height);
			graphics.DrawImage (source, d, s, GraphicsUnit.Pixel);

			for (int i = 0; i < width; i++)
				for (int j = 0; j < height; j++) {
					color = source.GetPixel (fromX + i, fromY + j);
					if (color == ignoredColor1)
						destination.SetPixel (toX + i, toY + j, transparent);
				}
		}

		public void DoSave (string fileName)
		{
			destination.Save (fileName);
		}

	}
}