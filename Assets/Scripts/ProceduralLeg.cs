using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralLeg : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public AnimationCurve legShape;

    private Vector3 TipPos;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void FixedUpdate()
    {

        lineRenderer.SetPosition(0, Vector3.zero);

        for (int i = 1; i < lineRenderer.positionCount - 1; i++)
        {
            float lerp = (float)i / (float)lineRenderer.positionCount;

            lineRenderer.SetPosition(i,
            Vector3.Lerp(Vector3.zero, transform.InverseTransformPoint(TipPos), lerp)
            + Vector3.back * legShape.Evaluate(lerp));
        }

        lineRenderer.SetPosition(lineRenderer.positionCount - 1, transform.InverseTransformPoint(TipPos));

    }
    public void SetTipPos(Vector3 aPos)
    {
        TipPos = aPos;
    }
}
