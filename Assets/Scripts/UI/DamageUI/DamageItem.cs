using DG.Tweening;
using UnityEngine;
using TMPro;

public class DamageItem : MonoBehaviour
{
    public Tween scaleTween;

    public TextMeshProUGUI numberText;


    private Vector3 _worldPos;
    private Camera _worldCam;

    public void SaveStartWorldPos(Vector3 aWorldPos, Camera aCam)
    {
        _worldPos = aWorldPos;
        _worldCam = aCam;
    }

    public void Initialize(float damageAmount, Vector2 scaleSpread, Vector2 lifetimeSpread)
    {
        scaleTween?.Kill();

        numberText.text = damageAmount.ToString();

        transform.localScale = Vector3.one * Random.Range(scaleSpread.x, scaleSpread.y);
        scaleTween = transform.DOScale(Vector3.one, Random.Range(lifetimeSpread.x, lifetimeSpread.y)).SetEase(Ease.InCubic)
        .OnUpdate(() =>
        {
            transform.position = _worldCam.WorldToScreenPoint(_worldPos);
        })
        .OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }
}
