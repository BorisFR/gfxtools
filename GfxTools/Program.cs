using System;
using System.IO;

namespace GfxTools
{
	class MainClass
	{
		private static string basePath = string.Empty;
		private static string outputPath = string.Empty;
		private static Tools tools = null;

		private static int COL_BASE = 0;
		private static int COL_CLIFF = 60;
		private static int COL_ROAD = 120;
		private static int COL_CRATER_DOWN = 180;
		private static int COL_LAVA = 240;
		private static int COL_WATER = 300;
		private static int COL_MOUNTAIN = 360;
		private static int COL_SNOW = 420;
		private static int COL_SAND = 480;
		private static int COL_SN2 = 540;
		private static int COL_CRATER = 600;
		private static int COL_END = COL_CRATER + 60;

		private static int LINE0 = 700;
		private static int LINE1 = 300;
		//private static int LINE2 = 200;
		//private static int LINE3 = 300;
		private static int LINE4 = 000;
		private static int LINE5 = 200;
		private static int LINE6 = 600;
		private static int LINE7 = 100;
		private static int LINE3 = 500;
		//private static int LINE9 = 900;
		private static int LINE2 = 400;
		private static int LINE_END = 800;

		public static void Main (string[] args)
		{
			basePath = "/Users/sfardoux/Pictures/GFX/Hard Vacuum/Terrain Tiles/"; //"/Users/sfardoux/PROJETS/PERSO/GfxTools/GfxTools/bin/Debug/";
			outputPath = "/Users/sfardoux/Pictures/GFX/";

			string destination = Path.Combine (outputPath, "gfx.png");

			tools = new Tools ();
			tools.PrepareNewImage (COL_END, LINE_END);
			// Cliffmask
			// CrtrJnt
			// CrtrRDst
			DoOne ("Crater.bmp", COL_CLIFF, LINE0);
			DoOne ("Crtr2Lav.bmp", COL_LAVA, LINE0);
			DoOne ("Crtr2Wtr.bmp", COL_WATER, LINE0);
			DoOne ("CrtrRoad.bmp", COL_ROAD, LINE0); // pas complet
			tools.LoadImage (fileName ("CrtrMisc.bmp"));
			tools.CopyGraphics (0, 01, 60, LINE0 + 60, 20, 20);
			tools.CopyGraphics (0, 41, 60, LINE0 + 80, 20, 20);

			// GrassRDst
			// Grs2Crtc
			DoOne4 ("Grass.bmp", COL_BASE, LINE1);
			DoOne ("GrasClif.bmp", COL_CLIFF, LINE1);
			DoOne ("GrasRoad.bmp", COL_ROAD, LINE1); // pas complet
			DoOne ("Grs2CrtB.bmp", COL_CRATER_DOWN, LINE1);
			DoOne ("Grs2Watr.bmp", COL_WATER, LINE1);
			DoOne ("Grss2Lav.bmp", COL_LAVA, LINE1);
			DoOne ("Grs2Crtr.bmp", COL_CRATER, LINE1); // pas complet
			tools.CopyGraphics (120, 001, 00, LINE0 + 60, 20, 20);
			tools.CopyGraphics (120, 161, 00, LINE0 + 80, 20, 20);
			tools.CopyGraphics (120, 121, 60, LINE0 + 60, 20, 20);
			tools.CopyGraphics (120, 081, 240, LINE0 + 80, 20, 20);
			tools.CopyGraphics (120, 041, 300, LINE0 + 80, 20, 20);

			DoOne3 ("Grass2.bmp", COL_SAND, LINE1);
			DoOne3 ("TreeGrs.bmp", COL_SN2, LINE1); // déborde et pas complet
			Do3Crater ("GrssCrtr.bmp", LINE1);
			tools.LoadImage (fileName ("GrssMisc.bmp"));
			tools.CopyGraphics (0, 21, COL_CRATER_DOWN, LINE1 + 60, 20, 40);
			tools.CopyGraphics (0, 81, COL_LAVA, LINE1 + 80, 20, 20);
			tools.CopyGraphics (40, 81, COL_WATER, LINE1 + 80, 20, 20);
			tools.CopyGraphics (80, 81, COL_MOUNTAIN, LINE1 + 80, 20, 20);
			tools.CopyGraphics (40, 41, COL_SAND, LINE1 + 60, 20, 20);
			tools.CopyGraphics (80, 41, COL_SAND, LINE1 + 80, 20, 20);
			tools.CopyGraphics (120, 1, COL_SAND, LINE1 + 100, 40, 80);
			// SwpAni
			// SwmpBubl
			// SwmpRDst
			DoOne3 ("Swamp.bmp", COL_MOUNTAIN, LINE1); // pas bon endroit
			DoOne ("SwmpRoad.bmp", COL_SNOW, LINE1);
			// LavaBubl
			// LavaRDest
			DoOne ("Lava.bmp", COL_MOUNTAIN, LINE4); // pas bon endroit
			DoOne ("LavaRoad.bmp", COL_MOUNTAIN, LINE6);
			DoOne ("LavaFlow.bmp", COL_SNOW, LINE6);
			DoOneBis (COL_SAND, LINE6);
			// Mnt2Crtc
			// MntRDst
			//DoOne ("Grs2Mnt.bmp", COL_MOUNTAIN, LINE4); // NOT GOOD
			DoOne ("Mnt2Crtb.bmp", COL_CRATER_DOWN, LINE4);
			DoOne ("MntCliff.bmp", COL_CLIFF, LINE4);
			DoOne ("Mnt2Lava.bmp", COL_LAVA, LINE4);
			DoOne ("Mnt2Sand.bmp", COL_SAND, LINE4);
			DoOne ("Mnt2Watr.bmp", COL_WATER, LINE4);
			DoOne ("MntRoad.bmp", COL_ROAD, LINE4);
			DoOne ("Mountains.bmp", COL_BASE, LINE4);
			DoOne ("Mnt2Crtr.bmp", COL_CRATER, LINE4);
			DoOne ("Snw2Mnt.bmp", COL_SN2, LINE4);
			DoOne ("Grs2Mnt.bmp", COL_SNOW, LINE4);
			tools.LoadImage (fileName ("MntMisc.bmp"));
			tools.CopyGraphics (120, 81, COL_SNOW, LINE4 + 100, 40, 40);
			tools.CopyGraphics (0, 101, 0, LINE4 + 60, 20, 20);
			tools.CopyGraphics (40, 101, 0, LINE4 + 80, 20, 20);
			tools.CopyGraphics (80, 101, 60, LINE4 + 60, 20, 20);
			tools.CopyGraphics (40, 1, COL_CRATER_DOWN, LINE4 + 60, 20, 40);
			tools.CopyGraphics (0, 1, COL_MOUNTAIN, LINE4 + 60, 20, 40);
			tools.CopyGraphics (0, 61, COL_LAVA, LINE4 + 80, 20, 20);
			tools.CopyGraphics (40, 61, COL_WATER, LINE4 + 80, 20, 20);
			tools.CopyGraphics (80, 61, COL_SNOW, LINE4 + 80, 20, 20);
			tools.CopyGraphics (80, 21, COL_SNOW, LINE4 + 60, 20, 20);
			// RoadDest
			// SandRDst
			DoOne ("Sand.bmp", COL_BASE, LINE5);
			DoOne ("Sand2Lav.bmp", COL_LAVA, LINE5);
			DoOne ("SandRoad.bmp", COL_ROAD, LINE5); // pas complet
			DoOne ("Snd2Crtb.bmp", COL_CRATER_DOWN, LINE5);
			DoOne ("SndCliff.bmp", COL_CLIFF, LINE5);
			DoOne ("Snd2Watr.bmp", COL_WATER, LINE5);
			DoOne ("Snd2Crtr.bmp", COL_CRATER, LINE5);
			DoOne ("IceRoad.bmp", COL_MOUNTAIN, LINE5);
			Do3Crater ("SandCrtr.bmp", LINE5);
			tools.LoadImage (fileName ("SandMisc.bmp"));
			tools.CopyGraphics (0, 1, COL_SNOW, LINE5 - 60, 40, 60);
			tools.CopyGraphics (60, 21, COL_CRATER_DOWN, LINE5 + 60, 20, 40);
			tools.CopyGraphics (100, 21, COL_SAND, LINE5 + 60, 20, 40);
			tools.CopyGraphics (0, 81, COL_LAVA, LINE5 + 80, 20, 20);
			tools.CopyGraphics (40, 81, COL_WATER, LINE5 + 80, 20, 20);
			tools.CopyGraphics (80, 81, COL_SNOW, LINE5 + 80, 20, 20);
			tools.CopyGraphics (120, 81, COL_SN2, LINE5 + 80, 20, 20);
			tools.CopyGraphics (160, 81, COL_SN2, LINE5 + 60, 20, 20);
			DoOne ("RoadJnt.bmp", COL_SAND, LINE3);
			// Sn2-2Crc
			// Sn2-RDst
			//DoOne ("Sn2-2Crb.bmp", COL_CRATER_DOWN, LINE6); // NOT GOOD
			DoOne ("Sn2-2Wtr.bmp", COL_WATER, LINE6);
			DoOne ("Sn2-Clif.bmp", COL_CLIFF, LINE6);
			DoOne ("Snw2-Lav.bmp", COL_LAVA, LINE6);
			DoOne ("RoadSnw2.bmp", COL_ROAD, LINE6);
			DoOne ("Sn22Crtr.bmp", COL_CRATER, LINE6);
			// Snw2Crtc
			DoOne ("Road.bmp", COL_ROAD, LINE7);
			DoOne ("Snow.bmp", COL_BASE, LINE7);
			DoOne ("Snow2.bmp", COL_SAND, LINE7);
			DoOne ("Snw2Crtb.bmp", COL_CRATER_DOWN, LINE7);
			DoOne ("Snw2Crtr.bmp", COL_CRATER, LINE7);
			DoOne ("Snw2Lav.bmp", COL_LAVA, LINE7);
			DoOne ("Snw2Watr.bmp", COL_WATER, LINE7);
			DoOne ("SnwCliff.bmp", COL_CLIFF, LINE7);
			DoOne3 ("Trees.bmp", COL_SN2, LINE7); // déborde et pas complet
			Do3Crater ("SnwCratr.bmp", LINE7);
			// IceRDest
			DoOne ("Ice2Snow.bmp", COL_MOUNTAIN, LINE7);
			DoOne2 ("Ice2Watr.bmp", COL_SNOW, LINE5);
			DoOne2 ("IceBrk1.bmp", COL_SAND, LINE5);
			DoOne2 ("IceBrk2.bmp", COL_SN2, LINE5);
			// Stn2Crtc
			DoOne ("Stn2Crtb.bmp", COL_CRATER_DOWN, LINE2);
			DoOne ("Stn2Crtr.bmp", COL_CRATER, LINE2);
			DoOne ("Stn2Lav.bmp", COL_LAVA, LINE2);
			DoOne ("Stn2SnwB.bmp", COL_SN2, LINE2);
			DoOne ("Stn2Watr.bmp", COL_WATER, LINE2);
			DoOne ("StnCliff.bmp", COL_CLIFF, LINE2);
			Do3Crater ("StnCratr.bmp", LINE2);
			// Stne2Snw
			// StnRDst
			DoOne ("StneRoad.bmp", COL_ROAD, LINE2);
			tools.LoadImage (fileName ("StnMisc.bmp"));
			tools.CopyGraphics (00, 1, COL_CRATER_DOWN, LINE2 + 80, 20, 20);
			tools.CopyGraphics (40, 1, COL_LAVA, LINE2 + 80, 20, 20);
			tools.CopyGraphics (80, 1, COL_WATER, LINE2 + 80, 20, 20);
			tools.CopyGraphics (120, 1, COL_MOUNTAIN, LINE2, 40, 40);
			//DoOne ("Stone.bmp", COL_BASE, LINE8);
			// TechRDst
			DoOne ("Tch2CrtB.bmp", COL_CRATER_DOWN, LINE3);
			DoOne ("Tch2Crtr.bmp", COL_CRATER, LINE3);
			DoOne ("Tch2Lava.bmp", COL_LAVA, LINE3);
			DoOne ("Tch2Watr.bmp", COL_WATER, LINE3);
			DoOne ("TchCliff.bmp", COL_CLIFF, LINE3);
			DoOne ("TechRoad.bmp", COL_ROAD, LINE3);
			tools.LoadImage (fileName ("TechMsc1.bmp"));
			tools.CopyGraphics (120, 41, 0, LINE3 + 60, 20, 20);
			tools.CopyGraphics (120, 81, 0, LINE3 + 80, 20, 20);
			tools.CopyGraphics (120, 121, COL_CLIFF, LINE3 + 60, 20, 20);
			tools.CopyGraphics (120, 161, COL_CLIFF, LINE3 + 80, 20, 20);
			tools.CopyGraphics (120, 1, COL_ROAD, LINE3 + 60, 20, 20);

			tools.CopyGraphics (0, 41, COL_MOUNTAIN, LINE3, 20, 20);
			tools.CopyGraphics (0, 161, COL_MOUNTAIN + 20, LINE3, 20, 20);
			tools.CopyGraphics (40, 41, COL_MOUNTAIN + 40, LINE3, 20, 20);
			tools.CopyGraphics (0, 121, COL_MOUNTAIN, LINE3 + 20, 20, 20);
			tools.CopyGraphics (80, 1, COL_MOUNTAIN + 20, LINE3 + 20, 20, 20);
			tools.CopyGraphics (40, 121, COL_MOUNTAIN + 40, LINE3 + 20, 20, 20);
			tools.CopyGraphics (0, 81, COL_MOUNTAIN, LINE3 + 40, 20, 20);
			tools.CopyGraphics (40, 161, COL_MOUNTAIN + 20, LINE3 + 40, 20, 20);
			tools.CopyGraphics (40, 81, COL_MOUNTAIN + 40, LINE3 + 40, 20, 20);
			tools.CopyGraphics (80, 161, COL_SNOW, LINE3, 20, 20);
			tools.CopyGraphics (0, 1, COL_SNOW + 20, LINE3, 20, 20);
			tools.CopyGraphics (80, 121, COL_SNOW + 40, LINE3, 20, 20);
			tools.CopyGraphics (80, 81, COL_SNOW, LINE3 + 20, 20, 20);
			tools.CopyGraphics (40, 1, COL_SNOW, LINE3 + 40, 20, 20);
			tools.CopyGraphics (80, 41, COL_SNOW, LINE3 + 60, 20, 20);

			// WatrRDst
			DoOne ("Water2.bmp", COL_SN2, LINE0);
			DoOneBis (COL_CRATER, LINE0);
			DoOne ("WatrFlow.bmp", COL_SNOW, LINE0);
			DoOneBis (COL_SAND, LINE0);
			DoOne ("WatrRoad.bmp", COL_MOUNTAIN, LINE0);

			tools.DoSave (destination);

		}

		private static string fileName (string file)
		{
			return Path.Combine (basePath, file);
		}

		private static void DoOne (string filePath, int offsetX, int offsetY)
		{
			string file = Path.Combine (basePath, filePath);
			if (!File.Exists (file))
				return;
			tools.LoadImage (file);

			tools.CopyGraphics (00, 1, offsetX + 00, offsetY + 0, 20, 20);
			tools.CopyGraphics (40, 1, offsetX + 20, offsetY + 0, 20, 20);
			tools.CopyGraphics (80, 1, offsetX + 40, offsetY + 0, 20, 20);

			tools.CopyGraphics (00, 41, offsetX + 00, offsetY + 20, 20, 20);
			tools.CopyGraphics (40, 41, offsetX + 20, offsetY + 20, 20, 20);
			tools.CopyGraphics (80, 41, offsetX + 40, offsetY + 20, 20, 20);

			tools.CopyGraphics (00, 81, offsetX + 00, offsetY + 40, 20, 20);
			tools.CopyGraphics (40, 81, offsetX + 20, offsetY + 40, 20, 20);
			tools.CopyGraphics (80, 81, offsetX + 40, offsetY + 40, 20, 20);

			tools.CopyGraphics (40, 121, offsetX + 40, offsetY + 80, 20, 20);
			tools.CopyGraphics (80, 121, offsetX + 20, offsetY + 80, 20, 20);
			tools.CopyGraphics (40, 161, offsetX + 40, offsetY + 60, 20, 20);
			tools.CopyGraphics (80, 161, offsetX + 20, offsetY + 60, 20, 20);

			tools.CopyGraphics (0, 161, offsetX + 0, offsetY + 60, 20, 20);
			tools.CopyGraphics (0, 121, offsetX + 0, offsetY + 80, 20, 20);
		}

		private static void DoOneBis (int offsetX, int offsetY)
		{
			tools.CopyGraphics (120 + 00, 1, offsetX + 00, offsetY + 0, 20, 20);
			tools.CopyGraphics (120 + 40, 1, offsetX + 20, offsetY + 0, 20, 20);
			tools.CopyGraphics (120 + 80, 1, offsetX + 40, offsetY + 0, 20, 20);

			tools.CopyGraphics (120 + 00, 41, offsetX + 00, offsetY + 20, 20, 20);
			tools.CopyGraphics (120 + 40, 41, offsetX + 20, offsetY + 20, 20, 20);
			tools.CopyGraphics (120 + 80, 41, offsetX + 40, offsetY + 20, 20, 20);

			tools.CopyGraphics (120 + 00, 81, offsetX + 00, offsetY + 40, 20, 20);
			tools.CopyGraphics (120 + 40, 81, offsetX + 20, offsetY + 40, 20, 20);
			tools.CopyGraphics (120 + 80, 81, offsetX + 40, offsetY + 40, 20, 20);

			tools.CopyGraphics (120 + 40, 121, offsetX + 40, offsetY + 80, 20, 20);
			tools.CopyGraphics (120 + 80, 121, offsetX + 20, offsetY + 80, 20, 20);
			tools.CopyGraphics (120 + 40, 161, offsetX + 40, offsetY + 60, 20, 20);
			tools.CopyGraphics (120 + 80, 161, offsetX + 20, offsetY + 60, 20, 20);

			tools.CopyGraphics (120 + 0, 161, offsetX + 0, offsetY + 60, 20, 20);
			tools.CopyGraphics (120 + 0, 121, offsetX + 0, offsetY + 80, 20, 20);
		}

		private static void DoOne2 (string filePath, int offsetX, int offsetY)
		{
			string file = Path.Combine (basePath, filePath);
			if (!File.Exists (file))
				return;
			tools.LoadImage (file);

			tools.CopyGraphics (00, 1, offsetX + 00, offsetY + 0, 20, 20);
			tools.CopyGraphics (40, 1, offsetX + 20, offsetY + 0, 20, 20);
			tools.CopyGraphics (80, 1, offsetX + 40, offsetY + 0, 20, 20);

			tools.CopyGraphics (00, 41, offsetX + 00, offsetY + 20, 20, 20);
			tools.CopyGraphics (40, 41, offsetX + 20, offsetY + 20, 20, 20);
			tools.CopyGraphics (80, 41, offsetX + 40, offsetY + 20, 20, 20);

			tools.CopyGraphics (00, 81, offsetX + 00, offsetY + 40, 20, 20);
			tools.CopyGraphics (40, 81, offsetX + 20, offsetY + 40, 20, 20);
			tools.CopyGraphics (80, 81, offsetX + 40, offsetY + 40, 20, 20);

			tools.CopyGraphics (00, 121, offsetX + 40, offsetY + 80, 20, 20);
			tools.CopyGraphics (40, 121, offsetX + 20, offsetY + 80, 20, 20);
			tools.CopyGraphics (00, 161, offsetX + 40, offsetY + 60, 20, 20);
			tools.CopyGraphics (40, 161, offsetX + 20, offsetY + 60, 20, 20);

			tools.CopyGraphics (80, 161, offsetX + 0, offsetY + 80, 20, 20);
			tools.CopyGraphics (80, 121, offsetX + 0, offsetY + 60, 20, 20);
		}

		private static void DoOne3 (string filePath, int offsetX, int offsetY)
		{
			string file = Path.Combine (basePath, filePath);
			if (!File.Exists (file))
				return;
			tools.LoadImage (file);

			tools.CopyGraphics (00, 1, offsetX + 00, offsetY + 0, 20, 20);
			tools.CopyGraphics (40, 1, offsetX + 20, offsetY + 0, 20, 20);
			tools.CopyGraphics (80, 1, offsetX + 40, offsetY + 0, 20, 20);

			tools.CopyGraphics (00, 41, offsetX + 00, offsetY + 20, 20, 20);
			tools.CopyGraphics (40, 41, offsetX + 20, offsetY + 20, 20, 20);
			tools.CopyGraphics (80, 41, offsetX + 40, offsetY + 20, 20, 20);

			tools.CopyGraphics (00, 81, offsetX + 00, offsetY + 40, 20, 20);
			tools.CopyGraphics (40, 81, offsetX + 20, offsetY + 40, 20, 20);
			tools.CopyGraphics (80, 81, offsetX + 40, offsetY + 40, 20, 20);

			tools.CopyGraphics (40, 121, offsetX + 20, offsetY + 60, 20, 20);
			tools.CopyGraphics (80, 121, offsetX + 40, offsetY + 60, 20, 20);
			tools.CopyGraphics (40, 161, offsetX + 20, offsetY + 80, 20, 20);
			tools.CopyGraphics (80, 161, offsetX + 40, offsetY + 80, 20, 20);

			tools.CopyGraphics (0, 161, offsetX + 0, offsetY + 80, 20, 20);
			tools.CopyGraphics (0, 121, offsetX + 0, offsetY + 60, 20, 20);
		}

		private static void DoOne4 (string filePath, int offsetX, int offsetY)
		{
			string file = Path.Combine (basePath, filePath);
			if (!File.Exists (file))
				return;
			tools.LoadImage (file);

			tools.CopyGraphics (00, 1, offsetX + 00, offsetY + 0, 20, 20);
			tools.CopyGraphics (40, 1, offsetX + 20, offsetY + 0, 20, 20);
			tools.CopyGraphics (80, 1, offsetX + 40, offsetY + 0, 20, 20);

			tools.CopyGraphics (00, 41, offsetX + 00, offsetY + 20, 20, 20);
			tools.CopyGraphics (40, 41, offsetX + 20, offsetY + 20, 20, 20);
			tools.CopyGraphics (80, 41, offsetX + 40, offsetY + 20, 20, 20);

			tools.CopyGraphics (00, 81, offsetX + 00, offsetY + 40, 20, 20);
			tools.CopyGraphics (40, 81, offsetX + 20, offsetY + 40, 20, 20);
			tools.CopyGraphics (80, 81, offsetX + 40, offsetY + 40, 20, 20);

			tools.CopyGraphics (40, 121, offsetX + 20, offsetY + 60, 20, 20);
			tools.CopyGraphics (80, 121, offsetX + 20, offsetY + 80, 20, 20);
			tools.CopyGraphics (40, 161, offsetX + 40, offsetY + 60, 20, 20);
			tools.CopyGraphics (80, 161, offsetX + 40, offsetY + 80, 20, 20);

			tools.CopyGraphics (0, 161, offsetX + 0, offsetY + 60, 20, 20);
			tools.CopyGraphics (0, 121, offsetX + 0, offsetY + 80, 20, 20);
		}

		private static void Do3Crater (string filePath, int offsetY)
		{
			string file = Path.Combine (basePath, filePath);
			if (!File.Exists (file))
				return;
			tools.LoadImage (file);

			tools.CopyGraphics (00, 1, 0, offsetY + 60, 20, 20);
			tools.CopyGraphics (40, 1, 0, offsetY + 80, 20, 20);
			tools.CopyGraphics (80, 1, 60, offsetY + 60, 20, 20);
		}

	}
}