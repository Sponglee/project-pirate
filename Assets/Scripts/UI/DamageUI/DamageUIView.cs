using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DamageUIView : MonoBehaviour
{
    public Vector3 damageItemOffset;
    public Vector2 damageItemOffsetSpread;
    public Vector2 damageItemScaleSpread;
    public Vector2 damageItemLifetimeSpread;
    
    public GameObject damageItem;

    public Transform itemContainer;

    private bool _isHasHandlers;


    public void Show()
    {
        if (_isHasHandlers) return;
        _isHasHandlers = true;

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        if (!_isHasHandlers) return;
        _isHasHandlers = false;

        gameObject.SetActive(false);
    }

}
