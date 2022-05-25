using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour
{
    [SerializeField] private GameObject[] _hearts;
    [SerializeField] private int _life;
    [SerializeField] GameObject _deathMenu;
    private bool dead;

    // Start is called before the first frame update
    void Start()
    {
        _life = _hearts.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if(_life<=0)
        {
            _deathMenu.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("You DIE");
        }
    }

   public void TakeDamage()
    {
        if (_life >= 1)
        {
            _life --;
            _hearts[_life].gameObject.SetActive(false);            
        }
        
    }

    public void RestoreHealth()
    {
            _hearts[_life].gameObject.SetActive(true);
            _life += 1;
    }
}
