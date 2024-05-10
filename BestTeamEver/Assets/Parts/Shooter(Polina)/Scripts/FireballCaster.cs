using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public Fireball FireballPrefab;
    public Transform FireballSourceTransform;
    public float Delay = 0.35f;
    public float ElapsedTime = 0f;

    void Update()
    {
        ElapsedTime += Time.deltaTime;
        FireballCast();
    }
    private void FireballCast()
    {
        if (Input.GetMouseButtonDown(0) && ElapsedTime > Delay)
        {
            ElapsedTime = 0;
            Instantiate(FireballPrefab, FireballSourceTransform.position, FireballSourceTransform.rotation);
        }
    }
}
