using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    [SerializeField] private PlayerShooter _shooter;
    [SerializeField] private List<Weapon> _weapons;

    private void Awake()
    {
        ChangeWeapon(1);
    }

    public void ChangeWeapon(int weaponIndex)
    {
        weaponIndex--;

        if (weaponIndex < _weapons.Count && weaponIndex >= 0)
        {
            _shooter.SetWeapon(_weapons[weaponIndex]);
            _weapons[weaponIndex].gameObject.SetActive(true);
        }
        else
        {
            throw new ArgumentException("Non existing weapon index");
        }
    }
}

public enum WeaponName
{
    AK74,
    M4
}