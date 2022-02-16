using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 camerPposition = new Vector3(0f, 2f, -4f);

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.TransformPoint(camerPposition);
        transform.LookAt(target);
    }
}
