using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitInMenu : MonoBehaviour
{
    public GameObject FinalScreen;

    public GameObject Button;

    public void MainMenu()
    {

        FinalScreen.SetActive(true);
        Invoke("LoadingScene", 7);
        Button.SetActive(false);
 
    }

    private void LoadingScene()
    {
        SceneManager.LoadScene(0);
    }
}
