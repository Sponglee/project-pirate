using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ScriptableAttack", order = 1)]
public class ScriptableAttackBase : ScriptableObject
{
    public AnimatorOverrideController animatorOverrideController;

    public virtual void Attack()
    {

    }

    public virtual void OnGizmos(Transform aTransform)
    {

    }
}