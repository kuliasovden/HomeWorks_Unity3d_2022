using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Transform firePoint;
    public GameObject bulletPrefab;


    private Rigidbody2D rb;
    private BoxCollider2D boxColl;
    private SpriteRenderer sr;
    private Animator anim;
    private bool grounded;
    private bool facingRight = true;
    [SerializeField] private LayerMask groundLayer;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxColl = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Shoot();
    }

    void FixedUpdate()
    {
        Movement();

    }

    public void Movement()
    {
        float movement = Input.GetAxis("Horizontal");      
        rb.velocity = new Vector2(movement * moveSpeed, rb.velocity.y);
        
        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            Jump();          
        }

        if (movement > 0 && !facingRight)
        {
            Flip();
        }
        else if(movement < 0 && facingRight)
        {
            Flip();
        }

        anim.SetBool("Run", movement != 0);
        anim.SetBool("Grounded", isGrounded());

    }

    // Поворот обьекта
    void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        anim.SetTrigger("Jump");
        //grounded = false;
    }

    //Стрельба
    void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

                anim.SetTrigger("Attac");
             
        }              
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            //grounded = true;
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxColl.bounds.center, boxColl.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider !=null;
    }

}
