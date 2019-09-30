using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

namespace ReachBeyond.Graphics {
	public class PaletteFader : MonoBehaviour {

		public ColorPalette target;
		[Tooltip("If this is null, we blend into the color (from target) specified by blendIntoIndex")]
		public ColorPalette source;
		[Tooltip("Ignored if source is non-null")]
		public int blendIntoIndex;
		public float fadeDuration = 1.0f;
		public UnityEvent onFinish;

		private void Awake() {
			Assert.IsNotNull(target, name + " in " + gameObject.name + " has to palette to fade.");
		}

		public void BeginFade() {
			StartCoroutine(Fade());
		}

		private IEnumerator Fade() {
			Color targetColor = target.Colors[blendIntoIndex];
			float yieldDuration = fadeDuration / target.Colors.Length;

			for(int i = 0; i < target.Colors.Length; i++) {
				if(source != null) {
					target.Colors[i] = source.Colors[i];
				}
				else {
					target.Colors[i] = targetColor;
				}


				if(!Mathf.Approximately(yieldDuration, 0f)) {
					yield return new WaitForSecondsRealtime(yieldDuration);
				}
			}


			onFinish.Invoke();


			// Just ensure that we actually return something at some point
			yield return null;
		}


	}
}
