using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sniper : EnemyManager
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float shootSpeed;
    [SerializeField] private float shootDelay;

    private bool canShoot;


    // Start is called before the first frame update
    private void Start()
    {
        canShoot = true;

    }

    // Update is called once per frame
   private void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, player.position);
    }

    private void FixedUpdate()
    {
        if (distToPlayer <= range && canShoot && player.position.x < transform.position.x && transform.localScale.x > 0)
        {

            StartCoroutine(Shoot());
            anim.SetTrigger("Attack");
        }
        else
        {
            anim.SetTrigger("StopAttack");
        }

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

        GameObject newBullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity =  transform.right *shootSpeed*Time.fixedDeltaTime;
        canShoot = true;
    }

}
