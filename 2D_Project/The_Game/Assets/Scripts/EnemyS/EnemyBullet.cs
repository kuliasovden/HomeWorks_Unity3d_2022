using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float dieTime;
    [SerializeField] int damage;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(CountDownTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject other = coll.gameObject;
        if (other.tag == "Player")
        {

            if (other.GetComponent<LivesController>() != null)
            {
                other.GetComponent<LivesController>().TakeDamage();

            }

            DestroySelf();
        } else if(other.tag == "Ground")
        {
            DestroySelf();
        }
        DestroySelf();
        
    }
  
    IEnumerator CountDownTimer()
    {
        yield return new WaitForSeconds(dieTime);

        Destroy(gameObject);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
