using System;
using System.Drawing;

namespace GfxTools
{
	public class Tools
	{
		Bitmap source = null;
		Bitmap destination = null;
		Graphics graphics = null;

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
			Rectangle s = new Rectangle (fromX, fromY, width, height);
			Rectangle d = new Rectangle (toX, toY, width, height);
			graphics.DrawImage (source, d, s, GraphicsUnit.Pixel);
		}

		public void DoSave (string fileName)
		{
			destination.Save (fileName);
		}

	}
}