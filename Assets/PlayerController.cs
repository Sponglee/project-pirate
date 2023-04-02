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

    private void Start()
    {

    }

    private void Update()
    {
        playerAnimation.MoveAnim(playerMovement.IsMoving);
        playerAnimation.AttackAnim(playerAttack.IsFire1);
        playerAnimation.JumpAnim(playerMovement.IsJumping);
    }



}
