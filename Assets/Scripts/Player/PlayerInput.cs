using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private ShipMovement _movement;
    [SerializeField] private Gun _gun;
    [SerializeField] private MobileJoystick _joystick;

    private float _moveHorizontal;
    private float _moveVertical;

    private void OnEnable()
    {
        _joystick.ClickedToMoveHorizontal += SetMoveHorizontal;
        _joystick.ClickedToMoveVertical += SetMoveVertical;
        _joystick.ClickedToShoot += TryShoot;
    }

    private void OnDisable()
    {
        _joystick.ClickedToMoveHorizontal -= SetMoveHorizontal;
        _joystick.ClickedToMoveVertical -= SetMoveVertical;
        _joystick.ClickedToShoot -= TryShoot;
    }

    private void Start()
    {
#if UNITY_ANDROID || UNITY_IOS
        _joystick.Activate();
#endif
    }

    private void FixedUpdate()
    {
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.W))
            SetMoveVertical(Vector3.up.y);
        if (Input.GetKey(KeyCode.A))
            SetMoveHorizontal(Vector3.left.x);
        if (Input.GetKey(KeyCode.S))
            SetMoveVertical(Vector3.down.y);
        if (Input.GetKey(KeyCode.D))
            SetMoveHorizontal(Vector3.right.x);
        if (Input.GetKey(KeyCode.Space))
            TryShoot();
#endif

        _movement.Move(_moveHorizontal, _moveVertical);

        _moveHorizontal = 0;
        _moveVertical = 0;
    }

    private void SetMoveHorizontal(float xDir)
    {
        _moveHorizontal = xDir;
    }

    private void SetMoveVertical(float yDir)
    {
        _moveVertical = yDir;
    }

    private void TryShoot()
    {
        _gun.TryShoot();
    }
}
