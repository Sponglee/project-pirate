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
        // float timer = 0f;
        float duration = Random.Range(lifetimeSpread.x, lifetimeSpread.y);

        transform.localScale = Vector3.one * Random.Range(scaleSpread.x, scaleSpread.y);
        scaleTween = transform.DOScale(Vector3.one, duration).SetEase(Ease.InCubic)
        .OnUpdate(() =>
        {
            // timer += Time.deltaTime;
            // numberText.fontMaterial.SetFloat("_UnderlayOffsetX", Mathf.Lerp(1f, 0f, timer / duration));
            // numberText.fontMaterial.SetFloat("_UnderlayOffsetY", Mathf.Lerp(-1f, 0f, timer / duration));

            transform.position = _worldCam.WorldToScreenPoint(_worldPos);
        })
        .OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }
}
