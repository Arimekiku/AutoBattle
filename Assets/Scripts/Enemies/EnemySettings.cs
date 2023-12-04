using UnityEngine;

namespace Enemies
{
    [CreateAssetMenu(fileName = "EnemySettings", menuName = "Scriptable/Enemy Settings", order = 0)]
    public class EnemySettings : ScriptableObject
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private int _baseHealth;
        [SerializeField] private int _baseDamage;

        public float MovementSpeed => _movementSpeed;
        public int BaseHealth => _baseHealth;
        public int BaseDamage => _baseDamage;
    }
}