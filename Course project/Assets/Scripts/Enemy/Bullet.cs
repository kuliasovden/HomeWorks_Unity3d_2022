using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _impactEffect;
    [SerializeField] private float _explosionRadius = 3f;
    [SerializeField] private int _damgeAmount = 5;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject impact = Instantiate(_impactEffect, transform.position, transform.rotation);
        AudioManager.instance.Play("Granade");
        Destroy(impact, 2);
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);
        foreach(Collider nearbyObject in colliders)
        {
            if(nearbyObject.tag == "PlayerBody")
            {
                PlayerManager.TakeDamage(_damgeAmount);
            }
        }
        Destroy(gameObject);
    }

}
