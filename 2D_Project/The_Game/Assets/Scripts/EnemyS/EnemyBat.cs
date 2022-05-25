using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBat : EnemyManager
{
    [SerializeField] private float _amplitude;
    [SerializeField] private float _frequency;

    public float y;

    // Start is called before the first frame update
    void Start()
    {
        y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, y + _amplitude * Mathf.Sin(transform.position.x * _frequency));
    }

    public void Activate()
    {
        Flip();
        rb.AddRelativeForce(Vector2.right * moveSpeed*Time.fixedDeltaTime, ForceMode2D.Impulse);
    }

    private void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
       moveSpeed*= -1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<LivesController>().TakeDamage();
        }
    }
}
