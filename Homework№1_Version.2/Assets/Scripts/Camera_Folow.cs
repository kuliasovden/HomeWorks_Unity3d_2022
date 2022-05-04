using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Folow : MonoBehaviour
{
    [SerializeField] private Vector3 cam = new Vector3(0f, 1.5f, -6f);
    [SerializeField] private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform; 
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = target.TransformPoint(cam);
        this.transform.LookAt(target);
    }
}
