using UnityEngine;
using UnityEngine.Assertions;
using ReachBeyond.VariableObjects;

[ExecuteInEditMode]
public class Recolor : MonoBehaviour
{
	#pragma warning disable CS0649
	[SerializeField] private ColorPalette _palette;
	#pragma warning restore CS0649


	private Material _mat;

	private void OnEnable() {
		if(_palette == null) {
			enabled = false;
		}

		Shader shader = Shader.Find("Hidden/PaletteSwap-Postprocessor");
		if(_mat == null) {
			_mat = new Material(shader);
		}

		//Camera.onPostRender += (
	}

	private void OnDisable() {
		if(_mat != null)
			DestroyImmediate(_mat);
	}

	private void OnValidate() {
		if(_palette == null) {
			enabled = false;
		}
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination) {

		_mat.SetVectorArray( "_Palette", _palette.V4Colors );
		Graphics.Blit(source, destination, _mat);

	}

}
