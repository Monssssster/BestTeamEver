using UnityEngine;
using TMPro;

public class KillCounter : MonoBehaviour
{
    public static int KillCount;
    public TextMeshProUGUI CountText;

    private void Start()
    {
        KillCount = 0;
    }

    private void Update()
    {
        CountText.text = KillCount.ToString();
    }
}
