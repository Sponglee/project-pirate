using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaponController : MonoBehaviour
{
    public Transform sheathePoint;
    public Transform armedPoint;

    public Animator weaponAnimator;



    private void Start()
    {
    }



    private void Update()
    {

        if (Input.GetButton("Fire1"))
        {
            weaponAnimator.SetTrigger("Attack");
        }

    }

}
