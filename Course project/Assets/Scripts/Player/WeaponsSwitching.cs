using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityStandardAssets.CrossPlatformInput;

public class WeaponsSwitching : MonoBehaviour
{
    [SerializeField] private int _selectedWeapon = 1;
    [SerializeField] private TextMeshProUGUI _ammoInfoText;

   private void Start()
    {
        SelectWeapon();
    }

   private void Update()
    {
        WeaponScroll();

        WeaponController currentWeapon =  FindObjectOfType<WeaponController>();
        _ammoInfoText.text = currentWeapon.currentAmmo + " /" + currentWeapon.magazineSize;
    }

    private void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == _selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            i++;
        }
    }

    private void WeaponScroll()
    {
        int previousSelectedeWeapon = _selectedWeapon;

        if (CrossPlatformInputManager.GetButton("Switch1"))
        {
            _selectedWeapon = 0;
        }

        if (CrossPlatformInputManager.GetButton("Switch2") && transform.childCount>=2)
        {
            _selectedWeapon = 1;
        }

        if(previousSelectedeWeapon != _selectedWeapon)
        {
            SelectWeapon();
        }

    }
}
