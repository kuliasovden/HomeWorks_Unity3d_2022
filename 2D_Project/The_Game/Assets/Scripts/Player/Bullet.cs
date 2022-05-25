using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]private float _speed = 10f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("DestroySelf", 3f); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.right * _speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            DestroySelf();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy"|| other.tag == "Enemy2")
        {
            if(other.GetComponent<EnemyManager>() != null)
            {
                other.GetComponent<EnemyManager>().TakeDamage();
            }

            DestroySelf();
        }       
    }
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
