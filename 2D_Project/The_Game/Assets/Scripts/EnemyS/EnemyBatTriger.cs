using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBatTriger : MonoBehaviour
{
    [SerializeField] private GameObject _bat;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _bat.GetComponent<EnemyBat>().y = transform.position.y;
            _bat.GetComponent<EnemyBat>().Activate();
        }
    }
}
