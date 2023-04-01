using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStateController : MonoBehaviour
{
    public PlayerController playerController;

    public Transform sheathePoint;
    public WeaponBase weaponRef;
    public WeaponMode weaponMode;

    private void Start()
    {
        ChangeWeaponMode(WeaponMode.Sheathe);
    }


    public void ToggleWeaponMode()
    {
        ChangeWeaponMode(weaponMode == WeaponMode.Sheathe ? WeaponMode.Armed : WeaponMode.Sheathe);
    }
    public Transform GetModePoint()
    {
        switch (weaponMode)
        {
            case WeaponMode.Sheathe:
                return sheathePoint;
            case WeaponMode.Armed:
                return playerController.weaponHolder;
            default:
                return sheathePoint;
        }
    }

    public void ChangeWeaponMode(WeaponMode aMode)
    {
        weaponMode = aMode;
        weaponRef.transform.SetParent(GetModePoint());
        weaponRef.transform.localPosition = Vector3.zero;
        weaponRef.transform.localEulerAngles = Vector2.zero;
    }

    public enum WeaponMode
    {
        Sheathe,
        Armed,
    }

}
