using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
[DisallowMultipleComponent]
public class ModularText : MonoBehaviour {

	void Awake() {

		foreach (var text in GetComponents<Text>()) {

			text.text = text.text
				// COMMON
				.Replace("{app.name}", AppInfo.Common.NAME)
				.Replace("{app.author}", AppInfo.Common.AUTHOR)
				.Replace("{app.website}", AppInfo.Common.WEBSITE)

				// VERSION
				.Replace("{version.major}", AppInfo.Common.VERSION.major.ToString())
				.Replace("{version.minor}", AppInfo.Common.VERSION.minor.ToString())
				.Replace("{version.build}", AppInfo.Common.VERSION.build.ToString())
				.Replace("{version.label}", AppInfo.Common.VERSION.label.ToString())
				.Replace("{version}", AppInfo.Common.VERSION.formatted);

		}

	}
	
}
