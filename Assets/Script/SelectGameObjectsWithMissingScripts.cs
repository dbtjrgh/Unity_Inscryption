using UnityEditor;
using UnityEngine;

public class SelectGameObjectsWithMissingScripts : Editor
{
    [MenuItem("Utility/Remove Missing Script")]
    private static void RemoveAllMissingScriptComponents()
    {
        var selectedGameObjects = Selection.gameObjects;
        int totalComponentCount = 0;
        int totalGameObjectCount = 0;

        foreach (var gameObject in selectedGameObjects)
        {
            // Get all child game objects including the root object
            var allTransforms = gameObject.GetComponentsInChildren<Transform>(true);

            foreach (var transform in allTransforms)
            {
                var childGameObject = transform.gameObject;
                int missingScriptCount = GameObjectUtility.GetMonoBehavioursWithMissingScriptCount(childGameObject);

                if (missingScriptCount > 0)
                {
                    Undo.RegisterCompleteObjectUndo(childGameObject, "Remove Missing Scripts");
                    GameObjectUtility.RemoveMonoBehavioursWithMissingScript(childGameObject);

                    totalComponentCount += missingScriptCount;
                    totalGameObjectCount++;
                }
            }
        }

        Debug.Log($"Removed {totalComponentCount} missing script component(s) from {totalGameObjectCount} game object(s).");
    }
}
