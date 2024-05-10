using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Codelock : MonoBehaviour
{
    public PasswordGen[] PasswordGen_AR;
    [HideInInspector] public int[] Numbers_AR;
    public char[] PasswordChar_AR;
    [HideInInspector] public string Password;
    public Material[] numbers_materials_AR;
    public string SimplePassword_0 = "0000";
    public string SimplePassword_1 = "1111";
    public string SimplePassword_2 = "2222";
    public string SimplePassword_3 = "3333";
    public string SimplePassword_4 = "4444";
    public string SimplePassword_5 = "5555";
    public string SimplePassword_6 = "6666";
    public string SimplePassword_7 = "7777";
    public string SimplePassword_8 = "8888";
    public string SimplePassword_9 = "9999";
    public string NormalPassword = "6284";
    public Transform Camera_TR;
    public AudioSource ButtonSound;
    public AudioSource LockOpenSound;
    public AudioSource WrongCodeSound;
    public Door Door;
    public LayerMask ray_layermask;
    
    private string _enteredPassword;
    private RaycastHit hit;

    IEnumerator Start()
    {
        Numbers_AR = new int[PasswordGen_AR.Length];
        PasswordChar_AR = new char[PasswordGen_AR.Length];
        yield return new WaitForSeconds(1f);
        int i = 0;
        while (i < PasswordGen_AR.Length)
        {
            Numbers_AR[i] = PasswordGen_AR[i].CurrentNumber;
            string st = Numbers_AR[i].ToString();
            PasswordChar_AR[i] = st.ToCharArray()[0];
            i++;
        }
        Password = string.Join(null, PasswordChar_AR);
        if (Password == SimplePassword_0 || Password == SimplePassword_1 || Password == SimplePassword_2 || Password == SimplePassword_3 || Password == SimplePassword_4 || Password == SimplePassword_5 || Password == SimplePassword_6 || Password == SimplePassword_7 || Password == SimplePassword_8 || Password == SimplePassword_9)
        {
            Password = NormalPassword;
        }
        print("Code = " + Password);
        _enteredPassword = "0000";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(Physics.Raycast(Camera_TR.position, Camera_TR.TransformDirection(Vector3.forward), out hit, 7, ray_layermask))
            {
                if(hit.collider.tag == "CodelockButton")
                {
                    if(hit.collider.name != "Enter")
                    {
                        _enteredPassword = _enteredPassword.Remove(0, 1);
                        _enteredPassword = _enteredPassword.Insert(Password.Length - 1, hit.collider.name);
                        print(hit.collider.name);
                        print("Entered " + _enteredPassword);
                    }
                    else
                    {
                        print("Checking password");
                        if (_enteredPassword == Password)
                        {
                            print("Codelock Opened");
                            LockOpenSound.Play();
                            Door.Using();
                            Destroy(this);
                        }
                        else
                        {
                            WrongCodeSound.Play();
                            print("Wrong Password");
                        }
                    }
                    ButtonSound.Play();
                }
            }
        }
    }
}
