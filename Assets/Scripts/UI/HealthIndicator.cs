using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIndicator : MonoBehaviour
{
    [SerializeField] private HealthPoint[] _healthPoints;
    [SerializeField] private Ship _ship;

    private int _currentHealthPoint;

    private void OnEnable()
    {
        _ship.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _ship.HealthChanged -= OnHealthChanged;
    }

    private void Start()
    {
        _currentHealthPoint = _healthPoints.Length - 1;
    }

    private void OnHealthChanged(int damage)
    {
        for (int i = 0; i < damage; i++)
        {
            if (_currentHealthPoint >= 0)
            {
                _healthPoints[_currentHealthPoint].DisableHealthPoint();
                _currentHealthPoint--;
            }
        }
    }
}
