using TMPro;
using UnityEngine;

public class Pause : MonoBehaviour
{

    [SerializeField] GameObject _pausePanel;
    [SerializeField] GameObject _choosePanel;

    bool _isPaused = false;

    float _scaledTime;
    float _unscaledTime;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
        _isPaused = true;
    }

    public void ResumeGame()
    {
        _pausePanel.SetActive(false);
        _choosePanel.SetActive(false);
        Time.timeScale = 1;
        _isPaused = false;
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        _isPaused = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
