using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarView : MonoBehaviour
{
    public GameObject healthBarItemPrefab;
    public Transform container;



    private List<HealthBarItem> _healthBars = new List<HealthBarItem>();
    // private Tween _tweenAlpha;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public int RequestBar(HealthBarKind aKind)
    {
        for (int i = 0, n = _healthBars.Count; i < n; i++)
        {
            if (!_healthBars[i].Active)
            {
                _healthBars[i].Active = true;
                _healthBars[i].SetKind(aKind);
                return i;
            }
        }

        int index = MakeBar();
        _healthBars[index].SetKind(aKind);
        return index;
    }

    public void ReleaseBar(int aIndex)
    {
        if (aIndex >= 0 && aIndex < _healthBars.Count && _healthBars[aIndex] != null)
        {
            _healthBars[aIndex].Active = false;
        }
    }


    public void UpdateBarPosition(int aBarIndex, Vector3 aWorldPosition)
    {
        if (aBarIndex >= 0 && aBarIndex < _healthBars.Count)
        {
            var bar = _healthBars[aBarIndex];
            bar.UpdatePosition(aWorldPosition);
        }
    }

    public void UpdateBarValue(int aBarIndex, float aValue)
    {
        if (aBarIndex >= 0 && aBarIndex < _healthBars.Count)
        {
            var bar = _healthBars[aBarIndex];
            bar.UpdateHealthBar(aValue);
        }
    }

    private int MakeBar()
    {
        var go = Instantiate(healthBarItemPrefab);
        go.transform.SetParent(container, false);
        var hb = go.GetComponent<HealthBarItem>();
        _healthBars.Add(hb);
        hb.Active = true;
        return _healthBars.Count - 1;
    }



}
