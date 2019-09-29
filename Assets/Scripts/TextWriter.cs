using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReachBeyond.VariableObjects;
using UnityEngine.Events;

namespace ReachBeyond {

	public class TextWriter : MonoBehaviour {

		public string pageBreak = "\\p";
		public float charDelay = 0.1f;
		public int linesPerPage = 3;
		public int lineLength = 34;

		[Space(10)]
		public StringConstReference source;
		public TMPro.TextMeshProUGUI display;

		[Space(10)]
		public string nextPageButton = "Fire1";
		public UnityEvent onBeginWritingFirstPage;
		public UnityEvent onBeginWritingPage;
		public UnityEvent onFinishPage;
		public UnityEvent onFinishLastPage;
		public UnityEvent onEnd;

		private string[] pages;
		private int pageIndex;
		private int charIndex;
		private float timeOfLastChar;

		private bool IsOnLastPage => pageIndex == pages.Length - 1;

		private void OnEnable() {

			pages = source.ConstValue.Split(
				new string[] { pageBreak },
				System.StringSplitOptions.None
			);

			pageIndex = 0;
			charIndex = 0;

		}

		private void OnDisable() {
			display.text = "";
		}

		private void Update() {

			bool doneWriting =
				pageIndex >= pages.Length
				|| charIndex >= pages[pageIndex].Length;

			if(doneWriting) {
				if(Input.GetButtonDown(nextPageButton)) {
					NextPage();
				}
			}
			else {

				if(Input.GetButtonDown(nextPageButton)) {
					display.text = pages[pageIndex];
					charIndex = pages[pageIndex].Length;
					timeOfLastChar = Time.time;
				}

				if(Time.time > timeOfLastChar + charDelay) {

					if(charIndex == 0) {
						onBeginWritingPage.Invoke();

						if(pageIndex == 0) {
							onBeginWritingFirstPage.Invoke();
						}
					}

					display.text += pages[pageIndex][charIndex];
					++charIndex;
					timeOfLastChar = Time.time;
				}

				if(charIndex >= pages[pageIndex].Length) {

					if(IsOnLastPage) {
						onFinishLastPage.Invoke();
					}
					else {
						onFinishPage.Invoke();
					}
				}

			}
		}


		public void NextPage() {

			display.text = "";
			pageIndex++;

			if(pageIndex < pages.Length) {
				charIndex = 0;
			}
			else {
				onEnd.Invoke();
			}
		}

	}
}
