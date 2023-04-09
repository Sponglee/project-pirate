using System;
using System.Collections;
using System.Collections.Generic;
using Anthill.Core;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public Transform weaponModel;

    public delegate void AttackDelegate();
    private AttackDelegate callBackDelegate;

    public MeleeWeaponTrail trail;

    public float damageAmount = 1f;

    public LayerMask layerMask;

    public ScriptableAttackBase[] attackSequence;

    public int currentAttackIndex = 0;

    public bool IsAttackInProgress = false;
    private PlayerController playerController;

    public bool IsOnCoolDown = false;

    [SerializeField] private float timer = 0f;
    [SerializeField] private float attackSpeed = 1f;

    private void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        callBackDelegate = AnimationFinishedHandler;
        ActivateWeapon(false);
    }

    private void Update()
    {
        if (IsOnCoolDown)
        {
            timer += Time.deltaTime;
            if (timer > attackSpeed)
            {
                timer = 0f;
                IsOnCoolDown = false;
            }
        }
    }

    public ScriptableAttackBase GetCurrentAttack()
    {
        if (IsAttackInProgress) return null;
        return attackSequence[currentAttackIndex];
    }

    public void ExecuteAttack()
    {
        if (IsOnCoolDown)
        {
            Debug.Log("COOLDOWN " + attackSequence[currentAttackIndex].name);

            return;
        }

        if (IsAttackInProgress)
        {
            Debug.Log("ATTACK IN PROGRESS" + attackSequence[currentAttackIndex].name);
            return;
        }

        ActivateWeapon(true);
        currentAttackIndex = (currentAttackIndex + 1) % attackSequence.Length;
        playerController.playerAnimation.playerAnim.runtimeAnimatorController = attackSequence[currentAttackIndex].animatorOverrideController;
        Debug.Log(">>" + attackSequence[currentAttackIndex]);
        playerController.playerAnimation.AttackAnim(true);


        // IAttackable[] tmpTargets = Physics.OverlapSphereNonAlloc()

        // if (tmpTarget != null)
        // {
        //     var collisionPoint = other.ClosestPoint(transform.position);
        //     tmpTarget.TakeDamage(Random.Range(12, 13), transform, collisionPoint);
        // }
    }


    public void ActivateWeapon(bool aToggle)
    {
        trail.Emit = aToggle;
        IsAttackInProgress = aToggle;

        if (aToggle)
        {
            IsOnCoolDown = true;
            timer = 0f;
        }
        else if (aToggle == false && callBackDelegate != null)
        {
            callBackDelegate();
        }
    }

    private void AnimationFinishedHandler()
    {
        playerController.playerAnimation.AttackAnim(false);
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            attackSequence[currentAttackIndex].OnGizmos(transform);
        }
        else
        {
            for (int i = 0; i < attackSequence.Length; i++)
            {
                attackSequence[i].OnGizmos(transform);
            }

        }
    }
}
