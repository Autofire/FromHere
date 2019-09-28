using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ReachBeyond {
	public class TriggerOnClick : MonoBehaviour {

		public UnityEvent onMouseEnter;
		public UnityEvent onMouseExit;
		public UnityEvent onMouseDown;
		public UnityEvent onMouseUp;
		public float triggerExpireTime = 0.01f;

		private bool clicking = false;
		private bool wasOverLastFrame = false;
		private float timeOfLastTrigger = Mathf.NegativeInfinity;
		private bool IsOver => Time.time < timeOfLastTrigger + triggerExpireTime;


		private void OnMouseOver() {
			timeOfLastTrigger = Time.time;		
		}


		private void OnMouseDown() {
			if(!clicking) {
				clicking = true;

				onMouseDown.Invoke();
			}
		}

		private void OnMouseUp() {
			if(clicking) {
				clicking = false;

				onMouseUp.Invoke();
			}
		}

		private void Update() {

			if(IsOver) {

				if(!wasOverLastFrame) {
					onMouseEnter.Invoke();
					wasOverLastFrame = IsOver;
				}
			}
			else {

				clicking = false;

				if(wasOverLastFrame) {
					onMouseExit.Invoke();
					wasOverLastFrame = IsOver;
				}
			}


			
		}

	}
}
