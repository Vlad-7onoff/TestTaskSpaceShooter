using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private LevelPanel _levelPanel;
    [SerializeField] private Button _start;
    [SerializeField] private Button _exit;

    private void OnEnable()
    {
        _start.onClick.AddListener(OnStartButtonClick);
        _exit.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _start.onClick.RemoveListener(OnStartButtonClick);
        _exit.onClick.RemoveListener(OnExitButtonClick);
    }

    private void Awake()
    {
        if (PlayerPrefs.GetInt("FirstStart") == 0)
        {
            PlayerPrefs.SetInt("FirstStart", 1);
            LevelButton[] levels = _levelPanel.GetComponentsInChildren<LevelButton>();
            foreach (LevelButton level in levels)
                PlayerPrefs.SetInt(level.LevelHandlerData.LevelNumber.ToString(), 0);
            PlayerPrefs.SetInt(levels[0].LevelHandlerData.LevelNumber.ToString(), 1);
        }
    }

    private void OnStartButtonClick()
    {
        _levelPanel.OpenPanel();
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
