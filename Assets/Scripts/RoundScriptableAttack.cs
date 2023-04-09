using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RoundAttack", order = 1)]
public class RoundScriptableAttack : ScriptableAttackBase
{
    public float attackRadius;
    public Vector3 offset;


    public override void Attack(WeaponBase aWeapon)
    {
        Collider[] tmpTargets = Physics.OverlapSphere(aWeapon.transform.position + aWeapon.transform.rotation * offset, attackRadius, aWeapon.layerMask);
        Debug.Log(tmpTargets.Length);
        if (tmpTargets != null)
        {
            for (int i = 0; i < tmpTargets.Length; i++)
            {
                IAttackable tmpAttackable = tmpTargets[i].GetComponent<IAttackable>();
                if (tmpAttackable != null)
                {
                    var collisionPoint = tmpTargets[i].ClosestPoint(aWeapon.transform.position);
                    tmpAttackable.TakeDamage(aWeapon.GetDamageNumber(), aWeapon.transform, collisionPoint);

                }
            }
        }
    }

    public override void DrawGizmo(Transform aTransform)
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(aTransform.position + aTransform.rotation * offset, attackRadius);
    }
}