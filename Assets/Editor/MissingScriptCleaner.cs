using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class MissingScriptCleaner : EditorWindow
{
    [MenuItem("Tools/Clean Missing Scripts")]
    public static void ShowWindow()
    {
        GetWindow(typeof(MissingScriptCleaner));
    }

    void OnGUI()
    {
        if (GUILayout.Button("Clean Missing Scripts in All Scenes"))
        {
            CleanAllScenes();
        }

        if (GUILayout.Button("Clean Missing Scripts in All Prefabs"))
        {
            CleanAllPrefabs();
        }
    }

    static void CleanAllScenes()
    {
        foreach (var scene in EditorBuildSettings.scenes)
        {
            if (scene.enabled)
            {
                EditorSceneManager.OpenScene(scene.path);
                CleanScene();
                EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
            }
        }
    }

    static void CleanScene()
    {
        GameObject[] rootObjects = EditorSceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject g in rootObjects)
        {
            CleanGameObject(g);
        }
    }

    static void CleanAllPrefabs()
    {
        string[] allPrefabs = AssetDatabase.FindAssets("t:Prefab");
        foreach (string guid in allPrefabs)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            CleanGameObject(prefab);
            PrefabUtility.SavePrefabAsset(prefab);
        }
    }

    static void CleanGameObject(GameObject g)
    {
        SerializedObject so = new SerializedObject(g);
        SerializedProperty prop = so.FindProperty("m_Component");

        int r = 0;
        for (int j = 0; j < prop.arraySize; j++)
        {
            SerializedProperty component = prop.GetArrayElementAtIndex(j - r);
            if (component.objectReferenceValue == null)
            {
                prop.DeleteArrayElementAtIndex(j - r);
                r++;
            }
        }

        so.ApplyModifiedProperties();

        foreach (Transform child in g.transform)
        {
            CleanGameObject(child.gameObject);
        }
    }
}
