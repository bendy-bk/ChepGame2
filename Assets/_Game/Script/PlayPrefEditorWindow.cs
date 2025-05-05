using UnityEditor;
using UnityEngine;

public class PlayerPrefsEditor
    //: EditorWindow
{
    private string key = "";
    private string value = "";

    [MenuItem("Tools/PlayerPrefs Editor")]
    public static void ShowWindow()
    {
        //GetWindow<PlayerPrefsEditor>("PlayerPrefs Editor");
    }

    private void OnGUI()
    {
        GUILayout.Label("Get / Set PlayerPrefs", EditorStyles.boldLabel);

        key = EditorGUILayout.TextField("Key", key);
        value = EditorGUILayout.TextField("Value", value);

        GUILayout.Space(10);

        if (GUILayout.Button("Get String"))
            value = PlayerPrefs.GetString(key, "Key not found");

        if (GUILayout.Button("Set String"))
            PlayerPrefs.SetString(key, value);

        if (GUILayout.Button("Delete Key"))
            PlayerPrefs.DeleteKey(key);

        if (GUILayout.Button("Delete All"))
            PlayerPrefs.DeleteAll();
    }
}
