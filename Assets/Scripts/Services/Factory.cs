using System.Linq;
using UnityEngine;

public class Factory
{
    private readonly MonoBehaviour[] _prefabs;
    private readonly Logger _logger;

    public Factory(Logger logger, params MonoBehaviour[] prefabs)
    {
        _prefabs = prefabs;
        _logger = logger;
    }

    public T CreateInstanceOfType<T>(Transform container = null, Vector2? position = null) where T : MonoBehaviour
    {
        T seekedPrefab = FindPrefab<T>();
        position ??= Vector2.zero;

        T instance = Object.Instantiate(seekedPrefab, container);
        instance.transform.position = position.Value;
        
        _logger.Log($"Created object <color=yellow>{instance.name}</color>", instance);
        
        return instance;
    }
    
    private T FindPrefab<T>()
    {
        if (_prefabs.FirstOrDefault(m => m is T) is not T obj)
            throw new($"Invalid type received: <color=green>{typeof(T)}</color>");

        return obj;
    }
}