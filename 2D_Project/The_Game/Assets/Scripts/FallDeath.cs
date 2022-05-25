using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDeath : MonoBehaviour
{
    [SerializeField] private GameObject _deathMenu;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _deathMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
