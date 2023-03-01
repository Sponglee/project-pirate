using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{

    public delegate void AttackDelegate(IAttackable aAttackable);
    private AttackDelegate callBackDelegate;

    public float damageAmount = 1f;

    public LayerMask layerMask;

    private void OnTriggerEnter(Collider other)
    {
        IAttackable tmpTarget = other.GetComponent<IAttackable>();

        if (tmpTarget != null)
        {
            tmpTarget.TakeDamage(damageAmount);
        }
    }



}
