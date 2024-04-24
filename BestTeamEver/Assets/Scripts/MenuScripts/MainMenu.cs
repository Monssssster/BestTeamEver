using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadPlatformer()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadHorror()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadShooter()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadBackrooms()
    {
        SceneManager.LoadScene(4);
    }

    public void GameExitButton()
    {
        Application.Quit();
    }
}
