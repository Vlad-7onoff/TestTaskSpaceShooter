using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using IJunior.TypedScenes;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(CanvasGroup))]
public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private LevelHandler _levelHandler;
    [SerializeField] private Ship _ship;
    [SerializeField] private Button _restart;
    [SerializeField] private Button _menu;

    private AudioSource _audioSource;
    private CanvasGroup _gameOverGroup;

    private void OnEnable()
    {
        _menu.onClick.AddListener(OnMenuButtonClick);
        _restart.onClick.AddListener(OnRestartClick);
        _ship.Died += GameOver;
    }

    private void OnDisable()
    {
        _menu.onClick.RemoveListener(OnMenuButtonClick);
        _restart.onClick.RemoveListener(OnRestartClick);
        _ship.Died -= GameOver;
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0;
        _gameOverGroup.interactable = false;
        _gameOverGroup.blocksRaycasts = false;
    }

    private void OnMenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    private void OnRestartClick()
    {
        Time.timeScale = 1;
        Game.Load(_levelHandler.LevelHandlerData);
    }

    private void GameOver()
    {
        _audioSource.Play();
        Time.timeScale = 0;
        _gameOverGroup.alpha = 1;
        _gameOverGroup.interactable = true;
        _gameOverGroup.blocksRaycasts = true;
    }
}