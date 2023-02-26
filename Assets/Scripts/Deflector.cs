using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Deflector : MonoBehaviour
{
    public bool IsDeflecting = false;


    // Start is called before the first frame update
    void Start()
    {
        Sequence tmpSequence = DOTween.Sequence();

        Tween rotationTweenUp = transform.DOLocalRotate(new Vector3(-30f, 0f, 180f), 0.1f, RotateMode.Fast)
            .SetEase(Ease.Linear)
            .SetLoops(1);
        tmpSequence.Append(rotationTweenUp);

        Tween rotationTweenDown = transform.DOLocalRotate(new Vector3(30f, 0f, 360f), 0.1f, RotateMode.Fast)
            .SetEase(Ease.Linear)
            .SetLoops(1);
        tmpSequence.Append(rotationTweenDown);


        tmpSequence.SetEase(Ease.Linear);
        tmpSequence.SetLoops(-1);
        tmpSequence.PlayForward();

    }

    public void Deflect(bool aToggle)
    {
        // rotationTween?.Kill();
        // rotationTween.PlayForward();
    }
}
