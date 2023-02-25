using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsController : MonoBehaviour
{
    public ProceduralHand leftHand;
    public ProceduralHand rightHand;

    public Transform leftHandHandle;
    public Transform rightHandHandle;



    private void Update()
    {
        leftHand.SetTipPos(leftHandHandle.position);
        rightHand.SetTipPos(rightHandHandle.position);
    }
}
