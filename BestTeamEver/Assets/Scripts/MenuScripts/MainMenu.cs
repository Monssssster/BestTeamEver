using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadPlatformer()
    {
        PlayerPrefs.SetInt("CurrentLevel", 1);
        SceneManager.LoadScene(1);
    }

    public void LoadHorror()
    {
        PlayerPrefs.SetInt("CurrentLevel", 2);
        SceneManager.LoadScene(2);
    }

    public void LoadShooter()
    {
        PlayerPrefs.SetInt("CurrentLevel", 3);
        SceneManager.LoadScene(3);
    }

    public void LoadBackrooms()
    {
        PlayerPrefs.SetInt("CurrentLevel", 4);
        SceneManager.LoadScene(4);
    }

    public void GameExitButton()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        var CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        var NewSceneIndex = CurrentSceneIndex + 1;
        PlayerPrefs.SetInt("CurrentLevel", NewSceneIndex);
        SceneManager.LoadScene(CurrentSceneIndex + 1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadCurrentLevel()
    {
        var CurrentLevel = PlayerPrefs.GetInt("CurrentLevel");
        SceneManager.LoadScene(CurrentLevel);
    }
}
