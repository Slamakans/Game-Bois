using UnityEngine;
using System.Collections;

namespace ExtensionMethods {
	public static class CameraExtensions {

		/// <summary>
		/// Transforms position from world space to canvas space.
		/// </summary>
		public static Vector2 WorldToCanvasPoint(this Camera cam, Vector3 position) {
			var viewportPos = cam.WorldToViewportPoint(position);

			var canvasRect = GameGlobals.canvasRect;
			viewportPos.x *= canvasRect.sizeDelta.x;
			viewportPos.y *= canvasRect.sizeDelta.y;

			viewportPos.x -= canvasRect.sizeDelta.x * canvasRect.pivot.x;
			viewportPos.y -= canvasRect.sizeDelta.y * canvasRect.pivot.y;

			return viewportPos;
		}

	}
}