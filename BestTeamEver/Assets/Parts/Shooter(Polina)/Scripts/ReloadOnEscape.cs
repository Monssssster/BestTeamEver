using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadOnEscape : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TheEnd.End = 0;
            KillCounter.KillCount = 0;
            EnemySpawnerController.Count = 0;
            GrenadeLauncherController.Count = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
