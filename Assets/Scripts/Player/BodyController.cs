using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReachBeyond.Player {

	[RequireComponent(typeof(Rigidbody2D))]
	public class BodyController : MonoBehaviour {

#pragma warning disable CS0649
		[SerializeField] private float walkSpeed;
#pragma warning restore CS0649

		private Rigidbody2D rb;

		private void Awake() {
			rb = GetComponent<Rigidbody2D>();
		}
		public void Walk(float xMagnitude) {
			rb.velocity =
				Vector2.up * rb.velocity +
				Vector2.right * walkSpeed * xMagnitude;
		}
	}
}
