using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   [SerializeField]private Vector3 _camerPposition = new Vector3(0f, 2f, -4f);

    private Transform _target;

    // Start is called before the first frame update
    void Start()
    {
        _target = GameObject.Find("Player").transform;        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = _target.TransformPoint(_camerPposition);
        transform.LookAt(_target);
    }
}
