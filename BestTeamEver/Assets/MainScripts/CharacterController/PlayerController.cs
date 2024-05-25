using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Gravity = 9.8f;
    public float JumpForce;
    public float Speed;
    public GameObject BlackScreen;
    
    public Animator animator;
    
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
        MovementUpdate();
        JumpUpdate();

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

    private void MovementUpdate()
    {
        var RundDirection = 0;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            RundDirection = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            RundDirection = 2;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            RundDirection = 3;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
            RundDirection = 4;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed *= 2;
        }

        animator.SetInteger("RunDirection", RundDirection);
    }

    private void JumpUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -JumpForce;
            //Animator.SetBool("IsGrounded", false);
        }
    }
}
