using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : EnemyManager
{

    [SerializeField] private Transform _groundCheckPos;
    [SerializeField] private Collider2D bodyCollider;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField]private float shootSpeed;
    [SerializeField] private float shootDelay;

    private bool mustTurn;
    private bool mustPatrol;
    private bool canShoot;


    public LayerMask groundLayer;

    // Start is called before the first frame update
   private void Start()
    {
        mustPatrol = true;
        canShoot = true;
    }


    private void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, player.position);


    }
    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(_groundCheckPos.position, 0.1f, groundLayer);
            Patrol();
        }

        if (distToPlayer <= range)
        {
            if (player.position.x > transform.position.x && transform.localScale.x < 0 || player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flip();
            }
            mustPatrol = false;
            rb.velocity = Vector2.zero;
            if (canShoot)
            {
                StartCoroutine(Shoot());
            }
        }
        else
        {
            mustPatrol = true;
        }


    }

    private void Patrol()
    {
        if (mustTurn || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }
        rb.velocity = new Vector2(moveSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

     private void Flip()
     {
         mustPatrol = false;
         transform.localScale = new Vector2(transform.localScale.x* -1, transform.localScale.y);
         moveSpeed *= -1;
         mustPatrol = true;
     }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<LivesController>().TakeDamage();
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootDelay);
             
        GameObject newBullet =  Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed*moveSpeed*Time.fixedDeltaTime, 0f);
        canShoot = true;
    }

}
