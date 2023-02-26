using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsController : MonoBehaviour
{
    public Transform leftHand;
    public Transform rightHand;

    public Transform leftHandHandle;
    public Transform rightHandHandle;

    public float lagAmount = 0.5f;

    private void FixedUpdate()
    {
        leftHand.position = Vector3.Lerp(leftHand.position, leftHandHandle.position, lagAmount);
        rightHand.position = Vector3.Lerp(rightHand.position, rightHandHandle.position, lagAmount);
    }
}
