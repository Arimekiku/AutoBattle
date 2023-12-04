using UnityEngine;

public static class AssetProvider
{
    public static T GetBehaviourOfType<T>(string path) where T : MonoBehaviour
    {
        T obj = Resources.Load<T>(path);
        
        if (obj is null)
            throw new($"Invalid path received: <color=green>{path}</color>");

        return obj;
    }
}