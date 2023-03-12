using Anthill;
using Anthill.Core;
using Anthill.Inject;
using UnityEngine;

public class DamageUIController : ISystem
{
    [Inject] public Game Game { get; set; }

    public Camera _worldCam;

    private DamageUIView _view;
    private bool _isHasHandlers;
    public void AddedToEngine()
    {
        AntInject.Inject<DamageUIController>(this);
        _view = ObjectCreator.Create<DamageUIView>("UI/DamageUIView/DamageUIView", Game.UIRoot);
        _worldCam = Camera.main;
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


    public void SpawnDamageNumber(float damageAmount, Vector3 worldPos)
    {
        DamageItem tmpDamageUI = GameObject.Instantiate(_view.damageItem, _worldCam.WorldToScreenPoint(worldPos + _view.damageItemOffset)
                        + new Vector3(0f/*Random.Range(_view.damageItemOffsetSpread.x, _view.damageItemOffsetSpread.y)*/, Random.Range(_view.damageItemOffsetSpread.x, _view.damageItemOffsetSpread.y), 0f),
                                                            Quaternion.identity, _view.itemContainer).GetComponent<DamageItem>();

        tmpDamageUI.Initialize(_view.damageItemScaleSpread, _view.damageItemLifetimeSpread);
    }




}
