using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(ModularText))]
public class e_ModularText : Editor {

	public override void OnInspectorGUI() {

		EditorGUILayout.HelpBox("Will replace text in Text objects.", MessageType.Info);
		EditorGUILayout.LabelField("Cheat Sheet", EditorStyles.boldLabel);
		CheatSheet("Application Name", "{app.name}");
		CheatSheet("Application Author", "{app.author}");
		CheatSheet("Application Website", "{app.website}");
		EditorGUILayout.Space();
		CheatSheet("Formatted Version", "{version}");
		CheatSheet("Version Label", "{version.label}");
		CheatSheet("Version Major", "{version.major}");
		CheatSheet("Version Minor", "{version.minor}");
		CheatSheet("Version Build", "{version.build}");
	}

	void CheatSheet(string name, string value) {
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField(name, GUILayout.Width(EditorGUIUtility.labelWidth - 4));
		EditorGUILayout.SelectableLabel(value, EditorStyles.textField, GUILayout.Height(EditorGUIUtility.singleLineHeight));
		EditorGUILayout.EndHorizontal();
	}

}
