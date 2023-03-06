using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStateController : MonoBehaviour
{
    public Transform sheathePoint;
    public Transform armedPoint;
    public Transform deflectPoint;
    public WeaponBase weaponRef;
    public WeaponMode weaponMode;

    private void Start()
    {

        weaponRef.transform.SetParent(GetModePoint());
        weaponRef.transform.localPosition = Vector3.zero;
        weaponRef.transform.localEulerAngles = Vector2.zero;
    }

    public Transform GetModePoint()
    {
        switch (weaponMode)
        {
            case WeaponMode.Sheathe:
                return sheathePoint;
            case WeaponMode.Armed:
                return armedPoint;
            case WeaponMode.Deflect:
                return deflectPoint;
            default:
                return sheathePoint;
        }
    }

    public enum WeaponMode
    {
        Sheathe,
        Armed,
        Deflect
    }

}
