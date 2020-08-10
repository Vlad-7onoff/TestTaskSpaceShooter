using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(CanvasGroup))]
public class WinPanel : MonoBehaviour
{
    [SerializeField] private LevelHandler _levelHandler;
    [SerializeField] private PointStorage _pointStorage;
    [SerializeField] private Button _accept;

    private AudioSource _audioSource;
    private CanvasGroup _gameOverGroup;

    private void OnEnable()
    {
        _accept.onClick.AddListener(AcceptButtonClick);
        _pointStorage.Collected += Win;
    }

    private void OnDisable()
    {
        _accept.onClick.RemoveListener(AcceptButtonClick);
        _pointStorage.Collected -= Win;
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

    public void AcceptButtonClick()
    {
        Debug.Log(_levelHandler.LevelNumber.ToString());
        Debug.Log(PlayerPrefs.GetInt(_levelHandler.LevelNumber.ToString()));
        if (PlayerPrefs.GetInt(_levelHandler.LevelNumber.ToString()) == 1)
        {
            PlayerPrefs.SetInt(_levelHandler.LevelNumber.ToString(), 2);
        }
        SceneManager.LoadScene(0);
    }

    private void Win()
    {
        _audioSource.Play();
        Time.timeScale = 0;
        _gameOverGroup.alpha = 1;
        _gameOverGroup.interactable = true;
        _gameOverGroup.blocksRaycasts = true;
    }
}
