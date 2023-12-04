using UnityEngine;

public class GameplayEntry : MonoBehaviour
{
    [Header("Preferences")]
    [SerializeField] private Transform _mainCharacterSpawnPoint;

    [Space, Header("Inputs")] 
    [SerializeField] private InputHandler _inputHandler;
    
    [Space, Header("Loggers")]
    [SerializeField] private Logger _factoryLogger;

    private const string MainCharacter = "Templates/Character/Prefab";

    private Factory _playerFactory;
    private MainCharacter _characterInstance;

    private void Awake()
    {
        BuildFactories();
        BuildPlayer();
        BuildInputs();
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