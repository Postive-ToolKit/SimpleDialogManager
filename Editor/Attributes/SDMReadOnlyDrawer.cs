﻿using DialogSystem.Runtime.Attributes;
using UnityEditor;
using UnityEngine;

namespace DialogSystem.Editor.Attributes
{
    [CustomPropertyDrawer(typeof(SDMReadOnlyAttribute))]
    public class SDMReadOnlyDrawer : PropertyDrawer
    {
        // Necessary since some properties tend to collapse smaller than their content
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }
        // Draw a disabled property field
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.enabled = !Application.isPlaying && ((SDMReadOnlyAttribute)attribute).runtimeOnly;
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = true;
        }
    }
}