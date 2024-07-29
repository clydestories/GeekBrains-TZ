using System;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    private Weapon _weapon;

    public event Action<int, int> BulletsValueChanged;

    private void Start()
    {
        BulletsValueChanged?.Invoke(_weapon.BulletsInMagazine, _weapon.BulletsInInventory);
    }

    public void Shoot()
    {
        if (_weapon != null)
        {
            _weapon.Shoot();
            BulletsValueChanged?.Invoke(_weapon.BulletsInMagazine, _weapon.BulletsInInventory);
        }
    }

    public void Reload()
    {
        if (_weapon != null)
        {
            _weapon.Reload();
            BulletsValueChanged?.Invoke(_weapon.BulletsInMagazine, _weapon.BulletsInInventory);
        }
    }

    public void SetWeapon(Weapon weapon)
    {
        if (_weapon != null)
        {
            _weapon.gameObject.SetActive(false);
        }

        _weapon = weapon;
    }
}
