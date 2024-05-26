using UnityEngine;

public class ModelChanging : MonoBehaviour
{
    public GameObject Skeleton;
    public GameObject SpongeBob;
    public GameObject Elephant;
    public GameObject BananaCat;

    public bool SkeletonIsActive = true;
    public bool SpongeBobIsActive = false;
    public bool ElephantIsActive = false;
    public bool BananaCatIsActive = false;

    private int KillCount;

    private void Update()
    {
        KillCount = KillCounter.KillCount;

        if (KillCount >= 5 && !SpongeBobIsActive && SkeletonIsActive)
        {
            ChangeIntoSpongeBob();
        }

        if (KillCount >= 10 && !ElephantIsActive && SpongeBobIsActive)
        {
            ChangeIntoElephant();
        }

        if (KillCount >= 15 && !SkeletonIsActive && ElephantIsActive)
        {
            ChangeIntoCat();
        }

    }

    private void ChangeIntoSpongeBob()
    {
        SpongeBobIsActive = true;
        SkeletonIsActive = false;
        Skeleton.SetActive(false);
        SpongeBob.SetActive(true);
    }

    private void ChangeIntoElephant()
    {
        ElephantIsActive = true;
        SpongeBobIsActive = false;
        SpongeBob.SetActive(false);
        Elephant.SetActive(true);
    }

    private void ChangeIntoCat()
    {
        BananaCatIsActive = true;
        ElephantIsActive = false;
        Elephant.SetActive(false);
        BananaCat.SetActive(true);
    }
}
