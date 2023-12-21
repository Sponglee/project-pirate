using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegRotator : MonoBehaviour
{
    [Range(0f, 180f)]
    public float offset = 0f;
    public float rotationSpeed = 1000f;
    // Rotation space
    public Space space = Space.Self;

    private bool isHold = true;


    void FixedUpdate()
    {
        if (isHold)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), 0.5f);
            return;
        }

        this.transform.Rotate(Vector3.right * rotationSpeed * Time.fixedDeltaTime, space);
    }

    public void Hold()
    {
        if (isHold) return;
        isHold = true;
    }

    public void Engage()
    {
        if (!isHold) return;

        isHold = false;
        transform.localRotation = Quaternion.Euler(offset, 0f, 0f);

    }
}
