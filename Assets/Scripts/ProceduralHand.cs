using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralHand : MonoBehaviour
{
    private LineRenderer lineRenderer;

    public AnimationCurve handShape;
    public float handLength;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetTipPos(Vector3 aPos)
    {
        float effectiveHandLength = Vector3.Magnitude(aPos - transform.position);

        lineRenderer.SetPosition(0, Vector3.zero);

        for (int i = 1; i < lineRenderer.positionCount - 1; i++)
        {
            float lerp = (float)i / (float)lineRenderer.positionCount;

            lineRenderer.SetPosition(i,
            Vector3.Lerp(Vector3.zero, transform.InverseTransformPoint(aPos), lerp)
            + Vector3.right * handShape.Evaluate(lerp));
        }

        lineRenderer.SetPosition(lineRenderer.positionCount - 1, transform.InverseTransformPoint(aPos));
    }
}
