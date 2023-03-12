using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DamageItem : MonoBehaviour
{
    public Vector3 offset;

    public Tween scaleTween;


    public void Initialize(Vector2 scaleSpread, Vector2 lifetimeSpread)
    {
        scaleTween?.Kill();
        transform.localScale = Vector3.one * Random.Range(scaleSpread.x, scaleSpread.y);
        scaleTween = transform.DOScale(Vector3.one, Random.Range(lifetimeSpread.x, lifetimeSpread.y)).SetEase(Ease.InCubic).OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }
}
