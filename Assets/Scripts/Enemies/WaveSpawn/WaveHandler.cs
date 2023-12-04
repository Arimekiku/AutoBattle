using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveHandler
{
    private const float MinimumDistance = 10f;
    
    public event Action<BaseEnemy> OnEnemySpawn;
    
    private readonly Queue<WaveConfiguration> _waves;
    private readonly Factory _enemyFactory;

    public WaveHandler(Factory enemyFactory, params WaveConfiguration[] waves)
    {
        _enemyFactory = enemyFactory;
        
        _waves = new(waves);
    }

    public float SpawnNextWave(Vector2 target)
    {
        WaveConfiguration nextWave = _waves.Dequeue();
        Dictionary<BaseEnemy, int> waveInfo = nextWave.WaveInfo;
        
        foreach (BaseEnemy enemy in waveInfo.Keys)
        {
            for (int i = waveInfo[enemy]; i > 0; i--)
            {
                float circleRadius = Random.Range(MinimumDistance, MinimumDistance * 1.2f);
                float xPosition = Random.Range(target.x - circleRadius, target.x + circleRadius);
                float yPosition = Mathf.Sqrt(circleRadius * circleRadius - Mathf.Pow(xPosition - target.x, 2)) + target.y;

                Vector2 resultPosition = new(xPosition, yPosition);
                
                BaseEnemy enemyInstance = _enemyFactory.CreateInstanceOfType<BaseEnemy>(position: resultPosition);
                
                OnEnemySpawn?.Invoke(enemyInstance);
            }
        }

        return nextWave.TimeForWave;
    }

    public bool IsEmpty => _waves.Count == 0;
} 