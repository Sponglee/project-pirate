using System.Collections;
using System.Collections.Generic;
using Anthill.Core;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public HealthBarKind healthBarKind;
    public Vector3 offset;
    private HealthBarController _healthBarController;

    private int healthBarIndex = -1;

    private void Start()
    {
        _healthBarController = AntEngine.Get<Menu>().Get<HealthBarController>();
        healthBarIndex = _healthBarController.RequestBar(healthBarKind);
    }

    private void FixedUpdate()
    {
        if (_healthBarController == null || healthBarIndex == -1) return;

        _healthBarController.UpdateBarPosition(healthBarIndex, transform.position + offset);
    }

    private void OnDestroy()
    {
        _healthBarController.ReleaseBar(healthBarIndex);
    }


}

