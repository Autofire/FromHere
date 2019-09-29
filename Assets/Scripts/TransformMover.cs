using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ReachBeyond.VariableObjects;

namespace ReachBeyond {
	public class TransformMover : MonoBehaviour {
		public TransformConstReference targetTransform;
		public TransformConstReference targetPosition;
		public UnityEvent onFinish;

		public void MoveTransform() {
			targetTransform.ConstValue.position = targetPosition.ConstValue.position;

			onFinish.Invoke();
		}
	}
}
