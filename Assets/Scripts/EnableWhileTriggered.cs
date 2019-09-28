using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace ReachBeyond {

	public class EnableWhileTriggered : MonoBehaviour {

		public float triggerExpireTime = 0.1f;
		public GameObject targetObj;

		private float timeOfLastTrigger = Mathf.NegativeInfinity;

		private void Awake() {
			Assert.IsNotNull(targetObj,
				gameObject.name
				+ ": Nothing to enable/disable with the trigger."
			);
		}

		private void OnTriggerStay2D(Collider2D collision) {
			timeOfLastTrigger = Time.time;
		}

		private void Update() {
			bool triggered =
				Time.time < timeOfLastTrigger + triggerExpireTime;

			targetObj.SetActive(triggered);
		}


	}
}
