using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "CharacterSettings", menuName = "Scriptable/Character Settings", order = 0)]
    public class CharacterSettings : ScriptableObject
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private int _baseHealth;

        public float MovementSpeed => _movementSpeed;
        public int BaseHealth => _baseHealth;
    }
}