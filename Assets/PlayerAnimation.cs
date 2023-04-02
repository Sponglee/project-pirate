using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    public Animator playerAnim;

    public void JumpAnim(bool aToggle)
    {
        playerAnim.SetBool("IsJumping", aToggle);
    }

    public void RollAnim()
    {

    }

    public void MoveAnim(bool aToggle)
    {
        playerAnim.SetBool("IsMoving", aToggle);
    }

    public void AttackAnim(bool aToggle)
    {
        playerAnim.SetBool("IsAttacking", aToggle);
    }
}
