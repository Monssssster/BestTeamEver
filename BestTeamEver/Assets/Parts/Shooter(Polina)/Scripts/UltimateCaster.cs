using UnityEngine;

public class UltimateCaster : MonoBehaviour
{
    public GameObject Skull;
    public float Cooldown = 10f;
    public AudioSource UltimateSound;

    private EnemySpawner EnemyList; 

    float _timer = 0f;

    private void Start()
    {
        EnemyList = GetComponent<EnemySpawner>();    
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.E) && _timer >= Cooldown)
        {
            CastHex();
        }
    }

    private void CastHex()
    {
        EnemyHealth[] enemies = FindObjectsOfType<EnemyHealth>();
        foreach (EnemyHealth enemy in enemies)
        {
            Destroy(enemy.gameObject);
            Instantiate(Skull, enemy.transform.position, enemy.transform.rotation);
        }
        EnemyList._enemies.Clear();
        KillCounter.KillCount += 2;
        UltimateSound.Play();
        _timer = 0;
    }
}