using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DamageUIView : MonoBehaviour
{
    public GameObject damageItem;

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
