 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private int _enemyHealth = 100;
    [SerializeField] private float _bulletSpeed = 30f;
    [SerializeField] private float _bulletVelocity = 7f;
    [SerializeField] private Animator _anim;
    [SerializeField] private GameObject _deathEffect;

    private void Shoot()
    {
        AudioManager.instance.Play("EnemyShoot");
        Rigidbody rb =  Instantiate(_projectile, _shootPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * _bulletSpeed, ForceMode.Impulse);
        rb.AddForce(transform.up * _bulletVelocity, ForceMode.Impulse);

    }

    public  void TakeDamage(int damageAmount)
    {
        _enemyHealth -= damageAmount;
        if(_enemyHealth <= 0)
        {
            _anim.SetTrigger("death");
            GetComponent<CapsuleCollider>().enabled = false;

            StartCoroutine(Explode()) ;
        }
        else
        {
            _anim.SetTrigger("damage"); 
        }
    }

    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(3f);

        AudioManager.instance.Play("EnemyDeath");
        Instantiate(_deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
