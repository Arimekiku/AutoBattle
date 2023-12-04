using UnityEngine;

public class GameplayEntry : MonoBehaviour
{
    [Header("Preferences")]
    [SerializeField] private Transform _mainCharacterSpawnPoint;
    
    [Space]
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private GameFlow _gameFlow;
    
    [Space, Header("Loggers")]
    [SerializeField] private Logger _factoryLogger;

    private const string MainCharacter = "Templates/Character/Prefab";
    private const string Ghost = "Templates/Enemies/Ghost/Prefab";

    private Factory _playerFactory;
    private Factory _enemyFactory;
    private MainCharacter _characterInstance;

    private void Awake()
    {
        BuildFactories();
        BuildPlayer();
        BuildInputs();

        _enemyFactory = new(_factoryLogger, AssetProvider.GetBehaviourOfType<BaseEnemy>(Ghost));
        _gameFlow.Build(_characterInstance, _enemyFactory);
        _gameFlow.StartWaves();
    }
    
    private void BuildFactories() 
    {
        _playerFactory = new(_factoryLogger, AssetProvider.GetBehaviourOfType<MainCharacter>(MainCharacter));
    }

    private void BuildPlayer()
    {
        _characterInstance = _playerFactory.CreateInstanceOfType<MainCharacter>(position: _mainCharacterSpawnPoint.position);
    }

    private void BuildInputs()
    {
        BattleInput bi = new(_inputHandler);
        bi.OnInputVectorReceived += _characterInstance.MoveCharacter;
        
        PauseInput pi = new(_inputHandler);
        
        _inputHandler.Build(bi, pi);
    }
}