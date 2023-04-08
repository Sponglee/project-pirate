using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RoundAttack", order = 1)]
public class RoundScriptableAttack : ScriptableAttackBase
{
    public float attackRadius;
    public Vector3 offset;

    public override void Attack()
    {

    }

    public override void OnGizmos(Transform aTransform)
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(aTransform.position + aTransform.rotation * offset, attackRadius);
    }
}