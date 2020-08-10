using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    private float _topBoundary;

    private void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        if (transform.position.y >= _topBoundary)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Asteroid asteroid))
        {
            asteroid.TakeDamage(_damage);
            Die();
        }
    }

    public void SetTopBoundary(float topBounady)
    {
        _topBoundary = topBounady;
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
