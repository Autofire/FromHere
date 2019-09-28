using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewColorPalette", menuName = "ReachBeyond/Color palette", order = 1)]
public class ColorPalette : ScriptableObject
{
	private const int SIZE = 4;

	#pragma warning disable CS0649
	[SerializeField] private Color[] _colors = new Color[SIZE];
	#pragma warning restore CS0649

	public Color[] Colors {
		get {
			return _colors;
		}
		private set {
			_colors = value;
		}
	}

	public Vector4[] V4Colors {
		get {
			Vector4[] result = new Vector4[Colors.Length];

			for(int i = 0; i < Colors.Length; i++) {
				result[i] = Colors[i]; //new Vector4(Colors[i].r, Colors[i].g, Colors[i].b, Colors[i].a);
			}

			return result;
		}
	}

	void OnValidate() {
		if(_colors.Length != SIZE) {
			Debug.LogWarning("Don't change the 'Colors' field's array size!");
			Array.Resize(ref _colors, SIZE);
		}
	}
}
