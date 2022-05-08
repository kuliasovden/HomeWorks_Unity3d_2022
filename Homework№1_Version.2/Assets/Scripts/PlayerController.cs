using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _jumpVelocity;

    public float distanceToGround = 0.1f;
    public LayerMask groundLayer;

    private float _hInput;
    private float _vInput;
    private bool _jumpFlag = false;
    private Rigidbody _rb;
    private CapsuleCollider _col;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        _vInput = Input.GetAxis("Vertical") * _speed;
        _hInput = Input.GetAxis("Horizontal") * _rotateSpeed;

        if (Input.GetKeyDown(KeyCode.Space)&&IsGrounded())
        {
            _jumpFlag = true;
        }
    }

    private void FixedUpdate()
    {
        Movement();
        Jump();
    }

   private void Movement()
    {
        Vector3 rotation = Vector3.up * _hInput;
        Quaternion angelRotation = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(transform.position + transform.forward * _vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angelRotation);
    }

   private void Jump()
    {
        if (_jumpFlag && IsGrounded())
        {
            _rb.AddForce(Vector3.up * _jumpVelocity, ForceMode.Impulse);
            _jumpFlag = false;
        }
    }

   private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);

        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);

        return grounded;
    }
}
