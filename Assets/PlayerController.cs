using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public Transform modelHolder;
    public Transform weaponHolder;
    public PlayerMovement playerMovement;
    public PlayerAnimation playerAnimation;
    public WeaponStateController weaponStateController;
    public PlayerAttack playerAttack;
    public WeaponAnimationTriggers animationTriggers;
    private void Start()
    {
        animationTriggers.weaponRef = weaponStateController.weaponRef;
    }

    private void Update()
    {
        playerAnimation.MoveAnim(playerMovement.IsMoving);
        playerAnimation.JumpAnim(playerMovement.IsJumping);
    }



}
