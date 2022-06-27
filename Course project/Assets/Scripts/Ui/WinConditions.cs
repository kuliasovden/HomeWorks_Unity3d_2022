using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinConditions : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private GameObject _menu;

    void Update()
    {
        _enemies = GameObject.FindGameObjectsWithTag("Opponent");
        if (_enemies.Length == 0)
        {

            _menu.SetActive(true);
        }
    }

}
