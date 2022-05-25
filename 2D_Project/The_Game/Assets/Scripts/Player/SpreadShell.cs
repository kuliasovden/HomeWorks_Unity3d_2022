using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadShell : MonoBehaviour
{
    [SerializeField]private GameObject projectile;
    [SerializeField] private float _range;
    [SerializeField] private Vector3 _rot;
    // Start is called before the first frame update
    private void Start()
    {
        _rot = transform.localEulerAngles;

        if(FindObjectsOfType<Bullet>().Length < 10)
        {
            Instantiate(projectile, transform.position, Quaternion.Euler(_rot.x, _rot.y, _rot.z));
        }
        if (FindObjectsOfType<Bullet>().Length < 10)
        {
            Instantiate(projectile, transform.position, Quaternion.Euler(_rot.x, _rot.y, _rot.z - _range));
        }
        if (FindObjectsOfType<Bullet>().Length < 10)
        {
            Instantiate(projectile, transform.position, Quaternion.Euler(_rot.x, _rot.y, _rot.z + _range));
        }
        if (FindObjectsOfType<Bullet>().Length < 10)
        {
            Instantiate(projectile, transform.position, Quaternion.Euler(_rot.x, _rot.y, _rot.z - _range*2));
        }
        if (FindObjectsOfType<Bullet>().Length < 10)
        {
            Instantiate(projectile, transform.position, Quaternion.Euler(_rot.x, _rot.y, _rot.z + _range * 2));
        }
        Destroy(gameObject);
    }
}
