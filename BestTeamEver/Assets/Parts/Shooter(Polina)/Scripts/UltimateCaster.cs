using UnityEngine;

public class UltimateCaster : MonoBehaviour
{
    public UltraFireball UltraNRGBallPrefab;

    public Transform NRGBallSourceTransform;
    public float Cooldown = 10f;

    public AudioSource Shoot;

    float _ultimateTimer = 0f;

    private void Update()
    {
        _ultimateTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.E) && _ultimateTimer >= Cooldown && Time.timeScale != 0)
        {
            CastHex();
        }
    }

    private void CastHex()
    {
        Instantiate(UltraNRGBallPrefab, NRGBallSourceTransform.position, NRGBallSourceTransform.rotation);
        Shoot.pitch = Random.Range(0.7f, 1.3f);
        Shoot.Play();

        _ultimateTimer = 0;
    }
}