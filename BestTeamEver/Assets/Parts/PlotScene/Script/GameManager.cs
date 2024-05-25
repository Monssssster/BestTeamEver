using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject FirstFrame;

    public GameObject SecondFrame;


    public void NextPage()
    {
        FirstFrame.SetActive(false);
        SecondFrame.SetActive(true);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
