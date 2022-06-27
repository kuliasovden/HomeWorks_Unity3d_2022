using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Animator _animator;
    [SerializeField] private FixedJoystick _joystick;

    [SerializeField] private float _moveSpeed = 15;
    [SerializeField] private float _gravity = -10;
    [SerializeField] private float _jumpHighe = 8f;

    [SerializeField]private Transform _groundCheck;
    [SerializeField]private LayerMask _groundLayer;

    private Vector3 _velocity;
    private Vector3 _move;
    private bool _isGrounded;
    private float _checkRadius = 0.1f;

   private void Update()
    {
        float x = _joystick.Horizontal;
        float z = _joystick.Vertical;

        _animator.SetFloat("Speed", Mathf.Abs(x) + Mathf.Abs(z));
        
        _move =  transform.right * x + transform.forward * z;

        _controller.Move(_move * _moveSpeed * Time.deltaTime);

        IsGrounded();
    }

    private void IsGrounded()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _checkRadius, _groundLayer);

        if (_isGrounded && CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Jump();
        }
        else
        {
            _velocity.y += _gravity * Time.deltaTime;
        }

        _controller.Move(_velocity * Time.deltaTime);

    }

    private void Jump()
    {
        AudioManager.instance.Play("Move");
        _velocity.y = Mathf.Sqrt(_jumpHighe * 2 *- _gravity);
    }
}
