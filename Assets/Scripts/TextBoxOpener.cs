using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ReachBeyond.VariableObjects;
using ReachBeyond.EventObjects;

namespace ReachBeyond {
	public class TextBoxOpener : MonoBehaviour {
		public StringVariable displayBuffer;
		public EventObject textBoxCloseEvent;
		public UnityEvent onTextBoxClose;

		[TextArea(3, 30)]
		public string text;

		public void Open() {
			displayBuffer.StoredValue = text;
			textBoxCloseEvent?.RegisterListener(OnClose);
		}

		private void OnClose() {
			textBoxCloseEvent.UnregisterListener(OnClose);
			onTextBoxClose.Invoke();
		}

	}
}
