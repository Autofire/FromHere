using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReachBeyond {
	// Ok, Unity's event system is somehow too dumb to allow us to
	// directly change colors. Thus, I need to make a proxy component
	// just to change colors. JUST TO CHANGE COLORS. LAME.
	public class SpriteColorSetter : MonoBehaviour {
		public SpriteRenderer r;
		public Color[] colors;

		public void SetColor(int colorIndex) {
			r.color = colors[colorIndex];
		}
	}
}
