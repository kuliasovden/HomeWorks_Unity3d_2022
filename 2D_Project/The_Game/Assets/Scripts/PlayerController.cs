using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private float _moveSpeed;
    [SerializeField]private float _jumpForce;
    [SerializeField]private Transform _firePoint;
    [SerializeField]private GameObject _bulletPrefab;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rb;
    private BoxCollider2D _boxColl;
    private SpriteRenderer _sr;
    private Animator _anim;
    private bool _grounded;
    private bool _facingRight = true;
    private float _vInput;
    private bool _jumpInput = false;

    

    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _boxColl = GetComponent<BoxCollider2D>();
        _sr = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        _vInput = Input.GetAxis("Horizontal") * _moveSpeed;

        if (Input.GetKey(KeyCode.Space))
        {
            _jumpInput = true;
        }

        Shoot();
    }

    private void FixedUpdate()
    {
        Movement();

    }

    public void Movement()
    {     
        _rb.velocity = new Vector2(_vInput, _rb.velocity.y);
        
        if (_jumpInput && isGrounded())
        {
            Jump();
            _jumpInput = false;
        }

        if (_vInput > 0 && !_facingRight)
        {
            Flip();
        }
        else if(_vInput < 0 && _facingRight)
        {
            Flip();
        }

        _anim.SetBool("Run", _vInput != 0);
        _anim.SetBool("Grounded", isGrounded());

    }

    // Поворот обьекта
   private void Flip()
    {
        _facingRight = !_facingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    private void Jump()
    {
        _rb.AddForce(Vector2.up*_jumpForce, ForceMode2D.Impulse);
        _anim.SetTrigger("Jump");        
        _jumpInput = false;
        _grounded = true;
    }

    //Стрельба
    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);

                _anim.SetTrigger("Attac");
             
        }              
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            _grounded = true;
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(_boxColl.bounds.center, _boxColl.bounds.size, 0, Vector2.down, 0.1f, _groundLayer);
        return raycastHit.collider !=null;
    }

}
