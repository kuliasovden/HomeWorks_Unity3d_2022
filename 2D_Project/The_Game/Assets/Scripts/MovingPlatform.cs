using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField]private int _startingPoint;
    [SerializeField]private Transform[] _points;

    private int _i;

    // Start is called before the first frame update
   private void Start()
    {
        transform.position = _points[_startingPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, _points[_i].position) < 0.02f)
        {
            _i++;
            if (_i==_points.Length)
            {
                _i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, _points[_i].position, _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
