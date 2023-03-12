using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LobbyView : MonoBehaviour
{
    public event System.Action EventStartGame;
    public Button btn_start;
    private bool _isHasHandlers;


    public void Show()
    {
        if (_isHasHandlers) return;
        _isHasHandlers = true;

        gameObject.SetActive(true);
        btn_start.onClick.AddListener(StartHandler);
    }

    public void Hide()
    {
        if (!_isHasHandlers) return;
        _isHasHandlers = false;

        gameObject.SetActive(false);
        btn_start.onClick.RemoveListener(StartHandler);
    }

    public void StartHandler()
    {
        EventStartGame?.Invoke();
    }
}
