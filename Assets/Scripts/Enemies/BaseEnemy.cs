using Enemies;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BaseEnemy : MonoBehaviour
{
    [SerializeField] private EnemySettings _settings;

    private float _currentMovementSpeed;
    private int _currentHealth;
    private int _currentDamage;
    
    private Rigidbody2D _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();

        _currentMovementSpeed = _settings.MovementSpeed;
        _currentHealth = _settings.BaseHealth;
        _currentDamage = _settings.BaseDamage;
    }

    public void Move(Vector2 targetPosition)
    {
        Vector2 movementVector = targetPosition - _body.position;
        Vector2 movementAmount = movementVector.normalized * (Time.deltaTime * _currentMovementSpeed);
        
        _body.MovePosition(_body.position + movementAmount);
    }

    public virtual void Attack()
    {
        
    }
}