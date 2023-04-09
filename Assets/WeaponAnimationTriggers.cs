using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimationTriggers : MonoBehaviour
{
    public WeaponBase weaponRef;

    private void Start()
    {

    }

    public void OnWeaponAnimationEnter()
    {
        weaponRef.ActivateWeapon(true);
    }
    public void OnWeaponAnimationExit()
    {
        weaponRef.ActivateWeapon(false);
    }
}
