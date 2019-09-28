using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace ReachBeyond.Player {
	public class PlayerBrain : MonoBehaviour {
		public BodyController body;
		public string inputAxis = "Horizontal";

		private void Awake() {
			Assert.IsNotNull(body);
		}

		private void Update() {
			body.Walk(Input.GetAxis(inputAxis));
		}
	}
}
