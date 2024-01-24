using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(RaycastDetection))]
public class TagSelector : Editor
{
    private SerializedProperty tagsProperty;

    private void OnEnable()
    {
        // Assuming you have a SerializedProperty for tags in your script
        tagsProperty = serializedObject.FindProperty("tags");
    }

    public override void OnInspectorGUI()
    {
        // Update the serialized object
        serializedObject.Update();

        // Display the default inspector property field
        DrawDefaultInspector();

        // Draw the custom tag selector dropdown
        DrawTagSelector();

        // Apply changes to the serialized object
        serializedObject.ApplyModifiedProperties();
    }

    private void DrawTagSelector()
    {
        EditorGUI.BeginChangeCheck();

        // Get the current selected tags as a mask
        int selectedTags = TagsToMask(tagsProperty.stringValue);

        // Draw the dropdown for selecting multiple tags
        selectedTags = EditorGUILayout.MaskField("Select Tags", selectedTags, InternalEditorUtility.tags);

        if (EditorGUI.EndChangeCheck())
        {
            // Update the serialized property with the selected tags
            tagsProperty.stringValue = MaskToTags(selectedTags);
        }
    }

    // Custom utility method to convert tags to a mask
    private static int TagsToMask(string tags)
    {
        string[] tagArray = InternalEditorUtility.tags;
        int mask = 0;

        for (int i = 0; i < tagArray.Length; i++)
        {
            if (tags.Contains(tagArray[i]))
            {
                mask |= 1 << i;
            }
        }

        return mask;
    }

    // Custom utility method to convert a mask to tags
    private static string MaskToTags(int mask)
    {
        string[] tagArray = InternalEditorUtility.tags;
        string result = "";

        for (int i = 0; i < tagArray.Length; i++)
        {
            if ((mask & (1 << i)) != 0)
            {
                if (!string.IsNullOrEmpty(result))
                {
                    result += ",";
                }

                result += tagArray[i];
            }
        }

        return result;
    }
}
