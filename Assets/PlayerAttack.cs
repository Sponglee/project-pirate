using System.Collections;
using System.Collections.Generic;
using Anthill.Core;
using Anthill.Inject;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Camera _worldCam;
    private WeaponStateController weaponStateController;
    [Inject] public Game Game { get; set; }
    public bool IsFire1 = false;
    private void Start()
    {
        AntInject.InjectMono(this);
        _worldCam = Camera.main;
        weaponStateController = GetComponent<WeaponStateController>();
    }

    private void Update()
    {
        if (Game.StateMachine.CheckState() != StateEnum.PlayState) return;

        if (Input.GetButtonDown("Fire3"))
        {
            weaponStateController.ToggleWeaponMode();
            return;
        }

        if (Input.GetButton("Fire1"))
        {
            RaycastHit hit;
            Ray ray = _worldCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Ground")))
            {
                IsFire1 = true;
            }
        }
        else
        {
            IsFire1 = false;
        }



    }
}
