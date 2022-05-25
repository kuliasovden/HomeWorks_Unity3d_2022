using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBarrelTriger : MonoBehaviour
{
    [SerializeField] private GameObject _barrel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _barrel.GetComponent<FlyingBarrel>().y = transform.position.y;
            _barrel.GetComponent<FlyingBarrel>().Activate();
        }
    }

}
