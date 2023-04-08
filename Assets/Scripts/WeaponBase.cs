using System.Collections;
using System.Collections.Generic;
using Anthill.Core;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public Transform weaponModel;

    public delegate void AttackDelegate(IAttackable aAttackable);
    private AttackDelegate callBackDelegate;

    public MeleeWeaponTrail trail;

    public float damageAmount = 1f;

    public LayerMask layerMask;

    public ScriptableAttackBase[] attackSequence;

    public int currentAttackIndex = 0;

    public bool IsAttackInProgress = false;

    private void Start()
    {
        ActivateWeapon(false);
    }



    public ScriptableAttackBase Attack()
    {
        if (IsAttackInProgress) return null;
        IsAttackInProgress = true;
        currentAttackIndex = (currentAttackIndex + 1) % attackSequence.Length;

        return attackSequence[currentAttackIndex];
        // IAttackable[] tmpTargets = Physics.OverlapSphereNonAlloc()

        // if (tmpTarget != null)
        // {
        //     var collisionPoint = other.ClosestPoint(transform.position);
        //     tmpTarget.TakeDamage(Random.Range(12, 13), transform, collisionPoint);
        // }
    }


    public void ActivateWeapon(bool aToggle)
    {
        // _collider.enabled = aToggle;
        trail.Emit = aToggle;
        IsAttackInProgress = aToggle;
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
