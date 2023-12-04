using Player;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MainCharacter : MonoBehaviour
{
    [SerializeField] private CharacterSettings _settings;

    private float _currentMovementSpeed;
    private int _currentHealth;
    
    private Rigidbody2D _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();

        _currentMovementSpeed = _settings.MovementSpeed;
        _currentHealth = _settings.BaseHealth;
    }

    public void MoveCharacter(Vector2 movementVector)
    {
        Vector2 movementAmount = movementVector * (Time.deltaTime * _currentMovementSpeed);
        
        _body.MovePosition(_body.position + movementAmount);
    }
}
