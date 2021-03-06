﻿using System;
using System.Collections.Generic;
using CocosSharp;

namespace Xevious
{
	public class GameLayer : CCLayerColor
	{
		public GameLayer () : base (CCColor4B.AliceBlue)
		{
			// Load and instantate your assets here

			// Make any renderable node objects (e.g. sprites) children of this layer
		}

		protected override void AddedToScene ()
		{
			base.AddedToScene ();

			// Use the bounds to layout the positioning of our drawable assets
			CCRect bounds = VisibleBoundsWorldspace;

			// Register for touch events
			var touchListener = new CCEventListenerTouchAllAtOnce ();
			touchListener.OnTouchesEnded = OnTouchesEnded;
			AddEventListener (touchListener, this);
		}

		void OnTouchesEnded (List<CCTouch> touches, CCEvent touchEvent)
		{
			if (touches.Count > 0) {
				// Perform touch handling here
			}
		}
	}
}
