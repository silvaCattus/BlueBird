using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _gameIsOverPanel;
    [SerializeField] private GameObject _messagePanel;

    [SerializeField] private Image _pauseButtonImage;
    [SerializeField] private Sprite _pauseOnSprite;
    [SerializeField] private Sprite _pauseOffSprite;

    [SerializeField] private string _startMessage;
    [SerializeField] private bool _toPrintStartMessage;

    private bool _isPaused;

    private void Start()
    {
        Time.timeScale = 1;
        OpenMessagePanel(_startMessage);
    }

    public void LevelIsCompleted()
    {
        OpenMessagePanel("Congrats!");
        Invoke(nameof(LoadNextLevel), 3f);
    }

    private void LoadNextLevel()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;

        if ((SceneManager.GetSceneAt(nextLevel) != null))
            SceneManager.LoadScene(nextLevel);
    }

    public void GameIsOver()
    {
        _gameIsOverPanel.SetActive(true);
        Invoke(nameof(ChangeTimeScale), 3f);
    }

    public void PauseButtonOnClick()
    {
        if (_isPaused)
        {
            _pausePanel.SetActive(false);
            _pauseButtonImage.sprite = _pauseOffSprite;
            ChangeTimeScale();
            _isPaused = !_isPaused;
        }
        else
        {
            _pausePanel.SetActive(true);
            _pauseButtonImage.sprite = _pauseOnSprite;
            ChangeTimeScale();
            _isPaused = !_isPaused;
        }
    }

    public void RestartButtonOnClick()
    {
        SceneManager.LoadSceneAsync(SceneManager.sceneCount);
    }

    public void ExitButtonOnClick()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void ChangeTimeScale()
    {
        if (Time.timeScale == 0f)
            Time.timeScale = 1.0f;
        else
            Time.timeScale = 0f;
    }

    public void OpenMessagePanel(string message)
    {
        _messagePanel.SetActive(true);
        _messagePanel.GetComponent<Messenger>().SetMessage(message);
        Invoke(nameof(CloseMessagePanel), 4f);
    }

    public void CloseMessagePanel()
    {
        _messagePanel.SetActive(false);
    }
}
