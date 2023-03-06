using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimationTriggers : MonoBehaviour
{
    public WeaponBase weaponRef;

    public void OnWeaponAnimationEnter()
    {
        weaponRef.ActivateWeapon(true);
    }
    public void OnWeaponAnimationExit()
    {
        weaponRef.ActivateWeapon(false);
    }
}
