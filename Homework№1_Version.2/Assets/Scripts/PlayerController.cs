using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float jumpVelocity;
    [SerializeField] private float distanceToGround;
    private Rigidbody rb;
    private CapsuleCollider col;

    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        Jump();
    }

    void Movement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 rotation = Vector3.up * horizontalMovement * rotateSpeed;
        Quaternion angelRotation = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        rb.MovePosition(transform.position + transform.forward * verticalMovement * speed * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * angelRotation);

    }

    void Jump()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }
    }

   private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z);

        bool grounded = Physics.CheckCapsule(col.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);

        return grounded;
    }
}
