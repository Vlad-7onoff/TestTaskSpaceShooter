using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class LevelPanel : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
        LevelButton[] levelButtons = GetComponentsInChildren<LevelButton>();
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelNumber = levelButtons[i].LevelHandlerData.LevelNumber;
            if (PlayerPrefs.GetInt(levelNumber.ToString()) == 2 && i + 1 < levelButtons.Length)
            {
                int nextLevelNumber = levelNumber + 1;
                if (PlayerPrefs.GetInt(nextLevelNumber.ToString()) != 2)
                    PlayerPrefs.SetInt(nextLevelNumber.ToString(), 1);
            }
            SetState(PlayerPrefs.GetInt(levelButtons[i].LevelHandlerData.LevelNumber.ToString()), levelButtons[i]);
        }
    }

    public void OpenPanel()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

    public void SetState(int state, LevelButton levelButton)
    {
        switch (state)
        {
            case 0:
                levelButton.SetNotActiveState();
                break;
            case 1:
                levelButton.SetActiveState();
                break;
            case 2:
                levelButton.SetCompletedState();
                break;
        }
    }
}
