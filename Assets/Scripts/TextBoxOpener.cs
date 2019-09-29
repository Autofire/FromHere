using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReachBeyond.VariableObjects;

namespace ReachBeyond {
	public class TextBoxOpener : MonoBehaviour {
		public StringVariable displayBuffer;

		[TextArea(3, 30)]
		public string text;

		public void Open() {
			displayBuffer.StoredValue = text;
		}

	}
}
