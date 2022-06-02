using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fling : MonoBehaviour
{
    [SerializeField] private int _velocity;
    [SerializeField] private Text _timerText;

    private float _countdown;
    private float _delay = 5f;
    private bool _trigger = false;

    // Start is called before the first frame update
    private void Start()
    {
        _countdown = _delay;
        _timerText.text = _countdown.ToString();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(_trigger)
        {
            Timer();
        }
    }
    public void StartCatapulte()
    {       
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, _velocity);
    }
    private void Timer()
    {
        _countdown -= Time.deltaTime;
        _timerText.text = Mathf.Round(_countdown).ToString();
        if (_countdown <= 0f)
        {
            StartCatapulte();            
        }
        if (_countdown <= 0)
        {
            _timerText.text = "0";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            _trigger = true;
            Debug.LogFormat("Triggerd");
        }
    }

}
