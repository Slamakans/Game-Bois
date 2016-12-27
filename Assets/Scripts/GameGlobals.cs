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
	public Slider _playerHPSlider;

	[Header("Variables")]
	public int _playerHP = 100;
	public int _playerHPMax = 100;

	// Prefabs
	//public static GameObject questUI { get { return instance._questUI; } }
	// Existing objects
	public static Canvas canvas { get { return instance._canvas; } }
	public static RectTransform canvasRect { get { return instance._canvasRect; } }
	public static Slider playerHPSlider { get { return instance._playerHPSlider; } }
	// Variables
	public static int playerHP {
		get { return instance._playerHP; }
		set { playerHPSlider.value = instance._playerHP = value; }
	}
	public static int playerHPMax {
		get { return instance._playerHPMax; }
		set { playerHPSlider.maxValue = instance._playerHPMax = value; }
	}


	protected override void Awake() {
		base.Awake();
		if (_canvas != null)
			_canvasRect = _canvas.GetComponent<RectTransform>();
	}
}
