using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MobileJoystick : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _up;
    [SerializeField] private Button _left;
    [SerializeField] private Button _down;
    [SerializeField] private Button _right;
    [SerializeField] private Button _shoot;

    public UnityAction<float> ClickedToMoveHorizontal;
    public UnityAction<float> ClickedToMoveVertical;
    public UnityAction ClickedToShoot;

    private bool _moveUp;
    private bool _moveLeft;
    private bool _moveDown;
    private bool _moveRight;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void FixedUpdate()
    {
        if (_moveUp)
            ClickedToMoveVertical?.Invoke(Vector3.up.y);
        if (_moveLeft)
            ClickedToMoveHorizontal?.Invoke(Vector3.left.x);
        if (_moveDown)
            ClickedToMoveVertical?.Invoke(Vector3.down.y);
        if (_moveRight)
            ClickedToMoveHorizontal?.Invoke(Vector3.right.x);
    }

    public void Activate()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

    public void OnPressMoveUp()
    {
        _moveUp = true;
    }

    public void OnReleaseMoveUp()
    {
        _moveUp = false;
    }

    public void OnPressMoveLeft()
    {
        _moveLeft = true;
    }

    public void OnReleaseMoveLeft()
    {
        _moveLeft = false;
    }

    public void OnPressMoveDown()
    {
        _moveDown = true;
    }

    public void OnReleaseMoveDown()
    {
        _moveDown = false;
    }

    public void OnPressMoveRight()
    {
        _moveRight = true;
    }

    public void OnReleaseMoveRight()
    {
        _moveRight = false;
    }

    public void Shoot()
    {
        ClickedToShoot?.Invoke();
    }
}
