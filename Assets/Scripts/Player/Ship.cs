using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Ship : MonoBehaviour
{
    [SerializeField] [Range(0, 3)] private int _health;
    [SerializeField] private ParticleSystem _particleSystem;

    public UnityAction<int> HealthChanged;
    public UnityAction Died;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(damage);
        _audioSource.Play();
        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        _particleSystem.Play();
        
        StartCoroutine(Dies());
    }

    private IEnumerator Dies()
    {
        yield return new WaitForSeconds(1f);
        Died.Invoke();
    }
}
