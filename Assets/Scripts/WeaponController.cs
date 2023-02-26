using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Transform sheathePoint;
    public Transform armedPoint;
    public Transform deflectPoint;

    public Animator weaponAnimator;
    public WeaponBase weaponRef;


    public WeaponMode weaponMode;

    private void Start()
    {

        weaponRef.transform.SetParent(GetModePoint());
        weaponRef.transform.localPosition = Vector3.zero;
        weaponRef.transform.localEulerAngles = Vector2.zero;
    }



    private void Update()
    {

        if (Input.GetButton("Fire1"))
        {
            weaponAnimator.SetBool("IsFire1", true);
        }
        else
        {
            weaponAnimator.SetBool("IsFire1", false);
        }

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
