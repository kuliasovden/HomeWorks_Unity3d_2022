using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public GameController gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
            Debug.Log("Item collected!");

            gameManager.Items += 1;
        }
    }
}
