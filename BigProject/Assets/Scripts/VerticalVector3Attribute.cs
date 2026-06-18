using UnityEngine;
using UnityEditor;

public class VerticalVector3Attribute : PropertyAttribute { }

[CustomPropertyDrawer(typeof(VerticalVector3Attribute))]
public class VerticalVector3Drawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUIUtility.singleLineHeight * 4;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.LabelField(
            new Rect(position.x, position.y, position.width, 20),
            label
        );

        float y = position.y + 20;

        EditorGUI.PropertyField(
            new Rect(position.x, y, position.width, 20),
            property.FindPropertyRelative("x")
        );

        EditorGUI.PropertyField(
            new Rect(position.x, y + 20, position.width, 20),
            property.FindPropertyRelative("y")
        );

        EditorGUI.PropertyField(
            new Rect(position.x, y + 40, position.width, 20),
            property.FindPropertyRelative("z")
        );
    }
}