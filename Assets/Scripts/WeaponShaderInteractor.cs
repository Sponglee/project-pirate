using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShaderInteractor : MonoBehaviour
{
    public Transform WeaponTip;
    public Transform playerTransform;
    public float lagAmount = 0.3f;


    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(WeaponTip.position.x, playerTransform.position.y, WeaponTip.position.z), lagAmount);
        transform.rotation = playerTransform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
