using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{

    public delegate void AttackDelegate(IAttackable aAttackable);
    private AttackDelegate callBackDelegate;

    public MeleeWeaponTrail trail;

    public float damageAmount = 1f;

    public LayerMask layerMask;

    private Collider _collider;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        ActivateWeapon(false);
    }

    private void OnTriggerStay(Collider other)
    {
        Attack(other);
    }

    public void Attack(Collider other)
    {
        IAttackable tmpTarget = other.GetComponent<IAttackable>();

        if (tmpTarget != null)
        {
            var collisionPoint = other.ClosestPoint(transform.position);
            tmpTarget.TakeDamage(1f, transform, collisionPoint);
        }
    }


    public void ActivateWeapon(bool aToggle)
    {
        _collider.enabled = aToggle;
        trail.Emit = aToggle;
    }
}
