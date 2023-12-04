using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Scriptable/Wave", order = 0)]
public class WaveConfiguration : ScriptableObject
{
    [SerializeField, SerializedDictionary("Enemy", "Count")] 
    private SerializedDictionary<BaseEnemy, int> _waveInfo;
    [SerializeField] private float _timeForWave;

    public Dictionary<BaseEnemy, int> WaveInfo => _waveInfo;
    public float TimeForWave => _timeForWave;
}