using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[DisallowMultipleComponent]
public sealed class GameGlobals : MonoBehaviour {

	private static GameGlobals instance;

	//[Header("Prefabs")]
	//public GameObject _questUI;

	[Header("Existing objects")]
	public Canvas _canvas;
	private RectTransform _canvasRect;
	public Slider _playerHPSlider;
	public Player _player;
	public b0ss _b0ss;

	// Prefabs
	//public static GameObject questUI { get { return instance._questUI; } }
	// Existing objects
	public static Canvas canvas { get { return instance._canvas; } }
	public static RectTransform canvasRect { get { return instance._canvasRect; } }
	public static Slider playerHPSlider { get { return instance._playerHPSlider; } }
	public static Player player { get { return instance._player; } }
	public static b0ss b0ss { get { return instance._b0ss; } }

	private void Awake() {
		instance = this;
		if (_canvas != null)
			_canvasRect = _canvas.GetComponent<RectTransform>();
	}
}
