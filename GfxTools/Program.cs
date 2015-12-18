using System;
using System.IO;

namespace GfxTools
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			/*
			if (args == null || args.Length == 0)
				return;

			string fileName = args [0];
			if (!File.Exists (fileName))
				return;
			*/

			foreach (string file in Directory.GetFiles ("/Users/sfardoux/PROJETS/PERSO/GfxTools/GfxTools/bin/Debug/","*.bmp")) {
				
				string destination = Path.ChangeExtension (file, "png");

				Tools t = new Tools ();

				t.LoadImage (file);
				t.PrepareNewImage (60, 100);

				t.CopyGraphics (00, 1, 00, 0, 20, 20);
				t.CopyGraphics (40, 1, 20, 0, 20, 20);
				t.CopyGraphics (80, 1, 40, 0, 20, 20);

				t.CopyGraphics (00, 41, 00, 20, 20, 20);
				t.CopyGraphics (40, 41, 20, 20, 20, 20);
				t.CopyGraphics (80, 41, 40, 20, 20, 20);

				t.CopyGraphics (00, 81, 00, 40, 20, 20);
				t.CopyGraphics (40, 81, 20, 40, 20, 20);
				t.CopyGraphics (80, 81, 40, 40, 20, 20);

				t.CopyGraphics (40, 121, 40, 80, 20, 20);
				t.CopyGraphics (80, 121, 20, 80, 20, 20);
				t.CopyGraphics (40, 161, 40, 60, 20, 20);
				t.CopyGraphics (80, 161, 20, 60, 20, 20);

				t.CopyGraphics (0, 161, 0, 60, 20, 20);
				t.CopyGraphics (0, 121, 0, 80, 20, 20);

				t.DoSave (destination);

			}
		}
	}
}