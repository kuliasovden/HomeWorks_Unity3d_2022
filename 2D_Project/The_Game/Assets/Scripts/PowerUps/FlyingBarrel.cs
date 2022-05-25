using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBarrel : EnemyManager
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
        rb.AddRelativeForce(Vector2.right * moveSpeed, ForceMode2D.Impulse);
    }
}
