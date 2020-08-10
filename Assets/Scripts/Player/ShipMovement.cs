using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipMovement : MonoBehaviour
{
    [SerializeField] private LevelBoundary _levelBoundary;
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(float moveHorizontal, float moveVertical)
    {
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        _rigidbody.velocity = movement * _speed;

        _rigidbody.position = new Vector3
        (
            Mathf.Clamp(_rigidbody.position.x, _levelBoundary.LeftDownCorner.x, _levelBoundary.RightUpCorner.x),
            Mathf.Clamp(_rigidbody.position.y, _levelBoundary.LeftDownCorner.y, _levelBoundary.RightUpCorner.y),
            0.0f
        );
    }
}
