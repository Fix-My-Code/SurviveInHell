#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Utilities.ColorHierarchy
{
    [InitializeOnLoad]
    public class HierarchyLabel : MonoBehaviour 
    {
        private static ColorHierarchy colorData;

        static HierarchyLabel() 
        {

            colorData = Resources.Load<ColorHierarchy>("ColorHierarchy");
            EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
        }

        private static void HierarchyWindowItemOnGUI(int instanceID, Rect selectionRect) 
        {
            var obj = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

            if (obj == null) 
            {
                return;
            }
            
            bool ProperName(string firstPartName) 
            {
                return obj.name.StartsWith(firstPartName);
            }

            void ModifyObjectName(string firstPartName, Color color) 
            {
                EditorGUI.DrawRect(selectionRect, color);
                EditorGUI.DropShadowLabel(selectionRect, obj.name.Remove(0, firstPartName.Length));
            }

            if (ProperName("!")) {
                ModifyObjectName("!", colorData.color);
            }else if (ProperName("~")) {
                ModifyObjectName("~", colorData.color1);
            }else if (ProperName("-")) {
                ModifyObjectName("-", colorData.color2);
            } else if (ProperName("*")) {
                ModifyObjectName("*", colorData.color3);
            } else if (ProperName("&")) {
                ModifyObjectName("&", colorData.color4);
            }
        }
    }
}

#endif