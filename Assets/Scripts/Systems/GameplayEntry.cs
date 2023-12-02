using UnityEngine;

public class GameplayEntry : MonoBehaviour
{
    [Header("Preferences")]
    [SerializeField] private Transform _mainCharacterSpawnPoint;
    
    [Space, Header("Loggers")]
    [SerializeField] private Logger _factoryLogger;

    private const string MainCharacter = "Prefabs/Character";

    private Factory _playerFactory;

    private void Awake()
    {
        BuildFactories();
    }
    
    private void BuildFactories() 
    {
        _playerFactory = new(_factoryLogger, AssetProvider.GetBehaviourOfType<MainCharacter>(MainCharacter));
        _playerFactory.CreateInstanceOfType<MainCharacter>(position: _mainCharacterSpawnPoint.position);
    }
}