using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float jumpVelocity;

    private float verticalInput;
    private float horizontalInput;
    private bool isOnGround = true;
    private Rigidbody _playerRb;

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Control();
        Jump();
    }
    private void Control()
    {
        verticalInput = Input.GetAxis("Vertical") * moveSpeed;
        horizontalInput = Input.GetAxis("Horizontal") * rotateSpeed;


        Vector3 rotation = Vector3.up * horizontalInput;
        Quaternion angleRotation = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _playerRb.MovePosition(transform.position + transform.forward * verticalInput * Time.fixedDeltaTime);
        _playerRb.MoveRotation(_playerRb.rotation * angleRotation);

    }

    private void Jump()
    {
        if (isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            _playerRb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }

}
