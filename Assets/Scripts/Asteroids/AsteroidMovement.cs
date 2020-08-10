using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    private float _speed;

    private void Update()
    {
        Falling();
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    private void Falling()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }
}
