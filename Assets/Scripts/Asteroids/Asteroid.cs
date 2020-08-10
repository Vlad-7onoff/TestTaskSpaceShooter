using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AsteroidMovement))]
[RequireComponent(typeof(SpriteRenderer))]
public class Asteroid : MonoBehaviour
{
    private AsteroidMovement _movement;
    private float _speed;
    private int _damage;
    private int _health;
    private int _reward;
    private Sprite _sprite;
    private SpriteRenderer _spriteRenderer;

    public UnityAction<int> ShotDown;

    private void Awake()
    {
        _movement = GetComponent<AsteroidMovement>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Fill(AsteroidData asteroidData)
    {
        _speed = asteroidData.Speed;
        _health = asteroidData.Health;
        _damage = asteroidData.Damage;
        _sprite = asteroidData.Sprite;
        _reward = asteroidData.Reward;
        Init();
    }

    private void Init()
    {
        _movement.SetSpeed(_speed);
        _spriteRenderer.sprite = _sprite;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            ShotDown?.Invoke(_reward);
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Ship ship))
        {
            ship.TakeDamage(_damage);
            Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
