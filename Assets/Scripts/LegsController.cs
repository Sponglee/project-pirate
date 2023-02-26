using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegsController : MonoBehaviour
{
    public ProceduralLeg[] legs;



    private float timer = 0f;
    private int currentLegIndex = 0;

    [SerializeField] private float stepDuration = 0.1f;
    [SerializeField] private float stride = 0.5f;

    RaycastHit hit;

    Vector3 lastHitPoint;

    private void FixedUpdate()
    {
        if (legs.Length == 0) return;

        timer += Time.fixedDeltaTime;
        if (timer >= stepDuration)
        {
            timer = 0f;
            currentLegIndex++;
            currentLegIndex = currentLegIndex % legs.Length;
            if (Physics.Raycast(legs[currentLegIndex].transform.position, Vector3.down, out hit, 100.0f, LayerMask.GetMask("Ground")))
            {
                lastHitPoint = hit.point;
            }
        }

        if (Physics.Raycast(legs[currentLegIndex].transform.position, Vector3.down, out hit, 100.0f, LayerMask.GetMask("Ground")))
        {
            GetStepPoint(hit.point);
        }
    }

    private void GetStepPoint(Vector3 hitPoint)
    {

        Vector3 basePoint = new Vector3(legs[currentLegIndex].transform.position.x, hitPoint.y, legs[currentLegIndex].transform.position.z);
        float stepLength = Vector3.Magnitude(basePoint - lastHitPoint);
        if (stepLength >= stride)
            legs[currentLegIndex].SetTipPos(basePoint + transform.forward * stepLength);
        // else
        //     legs[currentLegIndex].SetTipPos(basePoint + transform.forward * stepLength);
    }
}
