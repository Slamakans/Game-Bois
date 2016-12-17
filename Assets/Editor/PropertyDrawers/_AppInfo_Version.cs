using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomPropertyDrawer(typeof(AppInfo.Version))]
public class _AppInfo_Version : PropertyDrawer {

	public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
		return EditorGUIUtility.singleLineHeight * 3;
	}

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
		EditorGUI.BeginProperty(position, label, property);

		position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

		var indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;

		float padding = 5;
		var labelRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
		var majorRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight, position.width*0.333333f-padding, EditorGUIUtility.singleLineHeight);
		var minorRect = new Rect(position.x + position.width*0.333333f+padding*0.5f, majorRect.y, position.width*0.333333f-padding, EditorGUIUtility.singleLineHeight);
		var buildRect = new Rect(position.x + position.width*0.666666f+padding, majorRect.y, position.width*0.333333f-padding, EditorGUIUtility.singleLineHeight);
		var formattedRect = new Rect(position.x, buildRect.y + EditorGUIUtility.singleLineHeight, position.width, EditorGUIUtility.singleLineHeight);

		var labelProp = property.FindPropertyRelative("label");
		var majorProp = property.FindPropertyRelative("major");
		var minorProp = property.FindPropertyRelative("minor");
		var buildProp = property.FindPropertyRelative("build");
		
		EditorGUI.PropertyField(labelRect, labelProp, GUIContent.none);
		EditorGUI.PropertyField(majorRect, majorProp, GUIContent.none);
		EditorGUI.PropertyField(minorRect, minorProp, GUIContent.none);
		EditorGUI.PropertyField(buildRect, buildProp, GUIContent.none);
		EditorGUI.SelectableLabel(formattedRect, "Formatted: " + new AppInfo.Version((AppInfo.Version.Label)labelProp.enumValueIndex, majorProp.intValue, minorProp.intValue, buildProp.intValue).formatted);

		EditorGUI.indentLevel = indent;
		EditorGUI.EndProperty();
	}

}
