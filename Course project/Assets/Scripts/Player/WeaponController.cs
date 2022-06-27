using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Transform _playerCamera;
    [SerializeField] private ParticleSystem _barrelFlash;
    [SerializeField] private GameObject _impactEffect;
    [SerializeField] private Animator _animator;

    [SerializeField] private float _range = 20;
    [SerializeField] private float _impactForce = 150;
    [SerializeField] private int _fireRate = 10;
    [SerializeField] private int _maxAmmo = 10;
    [SerializeField] private float _reloadTime = 2f;
    [SerializeField] private int _damageAmmount = 20;

    private float _nextTimeToFire = 0;
    private bool _isReloading;

    public int currentAmmo;
    public int magazineSize = 30;

    private void Start()
    {
         currentAmmo = _maxAmmo;
        _animator.SetBool("isReloading", false);
    }

    void Update()
    {
        if(currentAmmo ==0 && magazineSize == 0)
        {
            _animator.SetBool("isShooting", false);
            return;
        }

        if (_isReloading)
        {
            return;
        }

        if (CrossPlatformInputManager.GetButton("Shoot")&& Time.time >= _nextTimeToFire)
        {
            _nextTimeToFire = Time.time + 1f / _fireRate;
            _animator.Play("Shoot");
         
            Fire();
        }

        if(currentAmmo == 0 && magazineSize > 0 && !_isReloading)
        {
            StartCoroutine(Reload());
        }
    }

    private void Fire()
    {
        RaycastHit hit;

        AudioManager.instance.Play("Shoot");
        _barrelFlash.Play();

        currentAmmo--;

        if (Physics.Raycast(_playerCamera.transform.position + _playerCamera.forward, _playerCamera.forward, out hit, _range))
        {
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * _impactForce);
            }

            EnemyController enemy = hit.transform.GetComponent<EnemyController>();

            if(enemy != null)
            {
                enemy.TakeDamage(_damageAmmount);
                return;
            }

            Quaternion impactRotation = Quaternion.LookRotation(hit.normal);
            GameObject impact =  Instantiate(_impactEffect, hit.point, impactRotation);
            impact.transform.parent = hit.transform;
            Destroy(impact, 5);
        }
    }

    private void OnEnable()
    {
        _isReloading = false;
    }

    IEnumerator Reload()
    {
        _isReloading = true;
       _animator.SetBool("isReloading", true);

        yield return new WaitForSeconds(_reloadTime);
        _animator.SetBool("isReloading", false);
        if (magazineSize >= _maxAmmo)
        {
            currentAmmo = _maxAmmo;
            magazineSize -= _maxAmmo;
        }
        else
        {
            currentAmmo = magazineSize;
            magazineSize = 0;
        }

        _isReloading = false;
    }
}
