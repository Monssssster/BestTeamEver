using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordGen : MonoBehaviour
{
    [HideInInspector] public int CurrentNumber;

    public Codelock Codelock;
 
    void Start()
    {
        CurrentNumber = Random.Range(0, Codelock.numbers_materials_AR.Length);
        GetComponent<MeshRenderer>().material = Codelock.numbers_materials_AR[CurrentNumber];
    }
}
