using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] [Range(0, 1)] private float _left, _up, _right, _down;

    private Vector3 _leftDownCorner;
    private Vector3 _rightUpCorner;

    public Vector3 LeftDownCorner => _leftDownCorner;
    public Vector3 RightUpCorner => _rightUpCorner;

    private void Awake()
    {
        ViewportToWorldRect(_mainCamera);
    }

    private void ViewportToWorldRect(Camera camera)
    {
        _leftDownCorner = camera.ViewportToWorldPoint(new Vector3(0 + _left, 0 + _down, camera.nearClipPlane));
        _rightUpCorner = camera.ViewportToWorldPoint(new Vector3(1 - _right, 1 - _up, camera.nearClipPlane));
    }
}
