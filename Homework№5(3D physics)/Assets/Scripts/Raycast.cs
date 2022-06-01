using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    private Ray _ray;
    private RaycastHit _raycastHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        var mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.transform.position.z;
        _ray = Camera.main.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(_ray, out _raycastHit))
        {
            Destroy(_raycastHit.collider.gameObject);
        }
    }

    private void CreateShootImpact(Vector3 position)
    {

    }
}
