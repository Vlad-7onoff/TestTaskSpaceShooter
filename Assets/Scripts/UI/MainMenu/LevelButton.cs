using UnityEngine;
using IJunior.TypedScenes;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]
public class LevelButton : MonoBehaviour
{
    [SerializeField] private LevelHandlerData _levelHandlerData;
    public LevelHandlerData LevelHandlerData => _levelHandlerData;

    private Image _image;
    private Button _button;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
    }

    public void OnPlayButtonClick()
    {
        Game.Load(_levelHandlerData);
    }

    public void SetNotActiveState()
    {
        _image.color = Color.red;
        _button.interactable = false;
    }

    public void SetActiveState()
    {
        _image.color = Color.white;
        _button.interactable = true;
    }

    public void SetCompletedState()
    {
        _image.color = Color.green;
        _button.interactable = true;
    }
}
