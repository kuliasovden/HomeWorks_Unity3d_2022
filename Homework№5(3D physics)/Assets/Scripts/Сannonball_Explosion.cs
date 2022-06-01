using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Сannonball_Explosion : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _power = 1000;
    [SerializeField] private GameObject _explosionVFX;

    private float _liftPower = 10.0f;
    private float _countdown;
    private float _delay = 9f;
    private bool hasExplode = false;

    

    private void Start()
    {
        _countdown = _delay;       
    }

    private void FixedUpdate()
    {        
        Timer();
    }



    private void Explode()
         {
              Instantiate(_explosionVFX, transform.position, transform.rotation);

              Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

             foreach (Collider hit in colliders)
             {
                 Rigidbody rb = hit.GetComponent<Rigidbody>();

                 if (rb != null)
                 {
                     rb.AddExplosionForce(_power, transform.position, _radius, _liftPower);
                 }
             }

        Destroy(gameObject);
    } 

    private void Timer()
    {
        _countdown -= Time.deltaTime;
        if (_countdown <= 0f && !hasExplode)
        {
            Explode();
            hasExplode = true;
        }
    }
}
