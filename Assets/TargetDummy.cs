using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TargetDummy : MonoBehaviour, IAttackable
{

    public float hp = 100f;

    public Renderer dummyRenderer;
    public Color flashColor;

    private Material dummyMat;
    private Color startColor;
    private Tween flashTween;

    void Start()
    {
        dummyMat = dummyRenderer.material;
        startColor = dummyMat.color;
    }

    public void TakeDamage(float damageAmount)
    {
        hp -= damageAmount;
        Flash();
    }

    private void Flash()
    {
        dummyMat.color = flashColor;
        flashTween?.Kill();
        flashTween = dummyMat.DOColor(startColor, 0.5f).SetEase(Ease.OutSine);
    }
}
