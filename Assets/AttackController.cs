using System.Collections;
using System.Collections.Generic;
using Anthill.Core;
using Anthill.Inject;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Animator weaponAnimator;


    private Camera _worldCam;
    private PlayerMovement playerMovement;
    private WeaponStateController weaponStateController;
    [Inject] public Game Game { get; set; }
    public bool IsFire1 = false;
    private void Start()
    {
        AntInject.InjectMono(this);
        _worldCam = Camera.main;
        playerMovement = GetComponent<PlayerMovement>();
        weaponStateController = GetComponent<WeaponStateController>();
    }

    private void Update()
    {
        if (Game.StateMachine.CheckState() != StateEnum.PlayState) return;

        if (weaponStateController.weaponMode != WeaponStateController.WeaponMode.Armed) return;


        if (Input.GetButton("Fire1"))
        {
            RaycastHit hit;
            Ray ray = _worldCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Ground")))
            {
                playerMovement.lookPivot.transform.position = transform.position + (hit.point - transform.position).normalized * 5f;
                playerMovement.LookEngaged = true;
                IsFire1 = true;
                weaponAnimator.SetBool("IsFire1", true);
            }
        }
        else
        {
            IsFire1 = false;
            weaponAnimator.SetBool("IsFire1", false);
        }

    }
}
