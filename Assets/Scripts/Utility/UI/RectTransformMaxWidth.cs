using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent(typeof(RectTransform))]
public class RectTransformMaxWidth : MonoBehaviour {

	public float width = 100;
	private RectTransform rect;

	void Awake() {
		rect = GetComponent<RectTransform>();
	}

	void Update () {
		Vector2 size = rect.sizeDelta;
		size.x = Mathf.Min(width, GameGlobals.canvasRect.sizeDelta.x);
		rect.sizeDelta = size;
	}
}
