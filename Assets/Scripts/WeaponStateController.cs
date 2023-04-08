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


    public bool ToggleWeaponMode()
    {
        ChangeWeaponMode(weaponMode == WeaponMode.Sheathe ? WeaponMode.Armed : WeaponMode.Sheathe);
        return weaponMode == WeaponMode.Armed;
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
        weaponRef.weaponModel.transform.SetParent(GetModePoint());
        weaponRef.weaponModel.transform.localPosition = Vector3.zero;
        weaponRef.weaponModel.transform.localEulerAngles = Vector2.zero;
    }

    public enum WeaponMode
    {
        Sheathe,
        Armed,
    }

}
