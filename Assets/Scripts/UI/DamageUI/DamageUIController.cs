using Anthill;
using Anthill.Core;
using Anthill.Inject;
using UnityEngine;

public class DamageUIController : ISystem
{
    [Inject] public Game Game { get; set; }

    private DamageUIView _view;
    private bool _isHasHandlers;
    public void AddedToEngine()
    {
        AntInject.Inject<DamageUIController>(this);
        _view = ObjectCreator.Create<DamageUIView>("UI/DamageUIView/DamageUIView", Game.UIRoot);

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

    }

    private void RemoveHandlers()
    {
        if (!_isHasHandlers) return;
        _isHasHandlers = false;
    }

    public void Show()
    {
        _view.Show();
    }

    public void Hide()
    {
        _view.Hide();
    }





}
