using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[DisallowMultipleComponent]
public sealed class GameGlobals : SingletonBase<GameGlobals> {

	//[Header("Prefabs")]
	//public GameObject _questUI;

	[Header("Existing objects")]
	public Canvas _canvas;
	private RectTransform _canvasRect;

	//[Header("Variables")]
	//public int _playerBits;

	// Prefabs
	//public static GameObject questUI { get { return instance._questUI; } }
	// Existing objects
	public static Canvas canvas { get { return instance._canvas; } }
	public static RectTransform canvasRect { get { return instance._canvasRect; } }
	// Variables
	//public static int playerBits { get { return instance._playerBits; } }

	protected override void Awake() {
		base.Awake();
		if (_canvas != null)
			_canvasRect = _canvas.GetComponent<RectTransform>();
	}
}
