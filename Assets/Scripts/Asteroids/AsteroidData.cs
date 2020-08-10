using UnityEngine;

[CreateAssetMenu(fileName = "New AsteroidData", menuName = "Asteroid Data", order = 51)]
public class AsteroidData : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private int _damage;
    [SerializeField] private Sprite _sprite;

    public float Speed => _speed;
    public int Health => _health;
    public Sprite Sprite => _sprite;
    public int Damage => _damage;
    public int Reward => _reward;
}
