using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    [SerializeField] private WaveConfiguration[] _waves;
    
    private readonly List<BaseEnemy> _enemies = new();

    private MainCharacter _characterInstance;
    private WaveHandler _waveHandler;
    private float _nextWaveTime;

    public void Build(MainCharacter characterInstance, Factory enemyFactory)
    {
        _characterInstance = characterInstance;
        
        _waveHandler = new(enemyFactory, _waves);
        _waveHandler.OnEnemySpawn += newEnemy =>
        {
            _enemies.Add(newEnemy);
        };
    }
    
    private void Update()
    {
        for (int i = 0; i < _enemies.Count; i++)
            _enemies[i].Move(_characterInstance.transform.position);
    }

    public void StartWaves()
    {
        StartCoroutine(NextWave());
    }

    private IEnumerator NextWave()
    {
        if(_waveHandler.IsEmpty)
            yield break;
        
        yield return new WaitForSeconds(_nextWaveTime);
        
        _nextWaveTime = _waveHandler.SpawnNextWave(_characterInstance.transform.position);
        yield return NextWave();
    }
}