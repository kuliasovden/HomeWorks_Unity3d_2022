using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class PlayerManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _playerHPText;

    private int _startHealth;
    private static bool _isGameOver;

    public static int playerHealth = 100;

    private void Start()
    {
        _startHealth = playerHealth;
        _isGameOver = false;
    }

   private void Update()
    {
        _playerHPText.text = "+" + playerHealth;

        if (_isGameOver)
        {
            SceneManager.LoadScene("Level_1");
            Debug.Log("Game Over");
            playerHealth = _startHealth;
        }
    }

    public  static void TakeDamage(int damageAmount)
    {
        playerHealth -= damageAmount;
        if (playerHealth <= 0)
        {
            _isGameOver = true;
        }
    }

}
