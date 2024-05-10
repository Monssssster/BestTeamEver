using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Gravity = 9.8f;
    public float JumpForce;
    public float Speed;
    //public Animator Animator;
    private float _fallVelocity = 0;
    private CharacterController _characterController;
    private Vector3 _moveVector;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _moveVector = Vector3.zero;
        Speed = 3;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }
        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            Speed *= 2;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -JumpForce;
            //Animator.SetBool("IsGrounded", false);
        }
        if(_moveVector != Vector3.zero)
        {
            //Animator.SetBool("IsRunning", true);
        }
        else
        {
            //Animator.SetBool("IsRunning", false);
        }

    }

    void FixedUpdate()
    {
        _characterController.Move(_moveVector.normalized * Time.fixedDeltaTime * Speed);
        _fallVelocity += Gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
}
