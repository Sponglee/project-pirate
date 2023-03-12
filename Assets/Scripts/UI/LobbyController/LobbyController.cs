using Anthill;
using Anthill.Core;
using Anthill.Inject;
using UnityEngine;

public class LobbyController : ISystem
{
    [Inject] public Game Game { get; set; }

    private LobbyView _view;
    private bool _isHasHandlers;
    public void AddedToEngine()
    {
        AntInject.Inject<LobbyController>(this);
        _view = ObjectCreator.Create<LobbyView>("UI/LobbyView/LobbyView", Game.UIRoot);

        AddHandlers();
        _view.Hide();
    }

    public void RemovedFromEngine()
    {
        RemoveHandlers();
        GameObject.Destroy(_view.gameObject);
    }

    private void AddHandlers()
    {
        if (_isHasHandlers) return;
        _isHasHandlers = true;

        _view.EventStartGame += StartGameHandler;
    }

    private void RemoveHandlers()
    {
        if (!_isHasHandlers) return;
        _isHasHandlers = false;
        _view.EventStartGame -= StartGameHandler;
    }

    public void Show()
    {
        _view.Show();
    }

    public void Hide()
    {
        _view.Hide();
    }

    public void StartGameHandler()
    {
        Debug.Log("HERE");
        Game.GameManager.StartGame();
    }



}
