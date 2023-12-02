using UnityEngine;
using Object = UnityEngine.Object;

[AddComponentMenu("Systems/Logger")]
public class Logger : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string _prefix;
    [SerializeField] private Color _prefixColor;
    [Space, SerializeField] private bool _showLogs;
    
    public void Log(string message, Object sender)
    {
        if (!_showLogs)
            return;
        
        Debug.Log($"<b><color={_prefixColor}>{_prefix}</color></b>: {message}", sender);
    }
}