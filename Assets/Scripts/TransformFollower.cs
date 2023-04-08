using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformFollower : MonoBehaviour
{
    public Transform tragetRef;
    public float lagAmount = 0.5f;

    public bool IsLocalSpace = false;

    private float timer = 0f;
    Vector3 testedPos;


    void FixedUpdate()
    {

        if (IsLocalSpace)
        {
            transform.position = Vector3.Lerp(transform.position, testedPos, lagAmount);
            // transform.rotation = Vector3.Lerp(transform.eulerAngles, transform.InverseTransformVector(tragetRef.eulerAngles), lagAmount);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, tragetRef.position, lagAmount);
            // transform.rotation = Quaternion.Lerp(transform.rotation, tragetRef.rotation, lagAmount);
        }
    }
}
