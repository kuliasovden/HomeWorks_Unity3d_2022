using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float _height = 4;
    public int type;

    private void Start()
    {
        GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * _height, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().ChangeWeapon(type);
            Destroy(gameObject);
        }
    }
}
