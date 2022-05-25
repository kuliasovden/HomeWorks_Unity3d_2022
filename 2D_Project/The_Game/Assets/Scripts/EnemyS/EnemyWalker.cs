using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalker : EnemyManager
{
    [SerializeField] private Transform _groundCheckPos;
    [SerializeField] private Collider2D bodyCollider;
    private bool mustTurn;
    private bool mustPatrol;

    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {       
    }

    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(_groundCheckPos.position, 0.1f, groundLayer);
            Patrol();
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
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
        moveSpeed *= -1;        
        mustPatrol = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<LivesController>().TakeDamage();
        }
    }
}
