using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;
    [SerializeField] private GameObject[] _powerUpPrefab;
    private int powerUpIndex;



    public float moveSpeed;
    public Transform player;
    public float range;
    public float distToPlayer;

    protected Animator anim;
    protected Rigidbody2D rb;
    protected SpriteRenderer sr;

    protected virtual void Awake()
    {
        _health = _maxHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }


    public void TakeDamage()
    {
        _health--;
        if(_health <= 0)
        {
            Die();
        }
    }

 public void Die()
    {
        if (gameObject.tag == "Enemy2")
        {
            Destroy(gameObject);
        }
        if (gameObject.tag == "Enemy")
        {
            SpawnRandomPowerUp();
            Destroy(gameObject);
        }
    }

 public virtual  void SpawnRandomPowerUp()
    {
       powerUpIndex = Random.Range(0,_powerUpPrefab.Length);
        Instantiate(_powerUpPrefab[powerUpIndex], transform.position, transform.rotation);
    }


}
