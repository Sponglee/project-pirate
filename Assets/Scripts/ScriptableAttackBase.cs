using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ScriptableAttack", order = 1)]
public class ScriptableAttackBase : ScriptableObject
{
    public AnimatorOverrideController animatorOverrideController;

    public virtual void Attack(WeaponBase aWeapon)
    {


    }

    public virtual void DrawGizmo(Transform aTransform)
    {

    }
}