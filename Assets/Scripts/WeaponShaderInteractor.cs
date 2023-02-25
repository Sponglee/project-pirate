using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShaderInteractor : MonoBehaviour
{
    public Transform WeaponTip;
    public Transform playerTransform;


    private void Update()
    {
        transform.position = new Vector3(WeaponTip.position.x, playerTransform.position.y, WeaponTip.position.z);
    }
}
