using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ReachBeyond {
	public class AnimationPlayer : MonoBehaviour {
		public Animator animController;
		public string animationName;
		public float duration;
		public UnityEvent onDone;

		private void Awake() {
			UnityEngine.Assertions.Assert.IsNotNull(animController);
		}

		public void Play() {
			StartCoroutine(PlayCoroutine());
		}

		private IEnumerator PlayCoroutine() {

			animController.Play(animationName);

			yield return new WaitForSeconds(duration);

			onDone.Invoke();
		}
	}
}
