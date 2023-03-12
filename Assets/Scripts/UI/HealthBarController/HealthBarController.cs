using Anthill;
using Anthill.Core;
using Anthill.Inject;
using UnityEngine;

public class HealthBarController : ISystem
{
    [Inject] public Game Game { get; set; }

    private HealthBarView _view;

    public void AddedToEngine()
    {
        AntInject.Inject<HealthBarController>(this);
        _view = ObjectCreator.Create<HealthBarView>("UI/HealthBarView/HealthBarView", Game.UIRoot);

        _view.Hide();
    }

    public void RemovedFromEngine()
    {
        GameObject.Destroy(_view.gameObject);
    }

    public void Show()
    {
        _view.Show();
    }
    public void Hide()
    {
        _view.Hide();
    }

    public void UpdateBarPosition(int aIndex, Vector3 aPos)
    {
        _view.UpdateBarPosition(aIndex, aPos);
    }

    public void UpdateBarValue(int aIndex, float aValue)
    {
        _view.UpdateBarValue(aIndex, aValue);
    }

    public int RequestBar(HealthBarKind aKind)
    {
        return _view.RequestBar(aKind);
    }

    public void ReleaseBar(int aIndex)
    {
        _view.ReleaseBar(aIndex);
    }

}
