using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public int CoinCount = 0;
    public TextMeshProUGUI CoinsText;
    public Transform SpawnPoint;
    public AudioSource CoinCollected;

    private void Start()
    {
        CoinsText.text = "Crystals Collected: " + CoinCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            CoinCount++;
            CoinsText.text = "Crystals Collected: " + CoinCount;
            CoinCollected.Play();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Exit" && CoinCount == 50)
        {
            SceneManager.LoadScene(2);
        }
    }
}
