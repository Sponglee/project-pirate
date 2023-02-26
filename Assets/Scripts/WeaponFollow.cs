using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFollow : MonoBehaviour
{
    public Transform modelHolderRef;
    public float lagAmount = 0.5f;

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, modelHolderRef.position, lagAmount);
        transform.rotation = Quaternion.Lerp(transform.rotation, modelHolderRef.rotation, lagAmount);
    }
}
