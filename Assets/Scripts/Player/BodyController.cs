using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReachBeyond.Player {

	[RequireComponent(typeof(Rigidbody2D))]
	public class BodyController : MonoBehaviour {

		public float baseWalkSpeed = 1.9f;
		public float walkSpeedMod = 1.0f;

		[Space(10)]
		public Animator animController;
		public SpriteRenderer spriteRenderer;
		public float walkDeadzone = 0.05f;
		public string standAnim = "Idle";
		public string walkAnim = "Walk";
		public string walkSpeedVar = "WalkSpeed";

		private Rigidbody2D rb;

		private void Awake() {
			rb = GetComponent<Rigidbody2D>();
		}

		public void Walk(float xMagnitude) {
			rb.velocity =
				Vector2.up * rb.velocity +
				Vector2.right * baseWalkSpeed * walkSpeedMod * xMagnitude;

			float absMag = Mathf.Abs(xMagnitude);

			if(absMag > walkDeadzone) {
				spriteRenderer.flipX = xMagnitude > 0;
				animController.SetFloat(walkSpeedVar, absMag * walkSpeedMod);
				animController.Play(walkAnim);
			}
			else {
				animController.Play(standAnim);
			}
		}
	}
}
