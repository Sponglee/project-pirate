using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BoxAttack", order = 1)]
public class BoxScriptableAttack : ScriptableAttackBase
{

    public Vector3 attackDimentions;

    public Vector3 offset;

    private float gizmoLifetime = 10f;

    private bool _gizmoShown = false;
    public override void Attack(WeaponBase aWeapon)
    {
        Collider[] tmpTargets = Physics.OverlapBox(aWeapon.transform.position + aWeapon.transform.rotation * offset, attackDimentions / 2f,
                                                    aWeapon.transform.rotation,
                                                    aWeapon.layerMask);



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
        if (!_gizmoShown) return;

        Gizmos.color = Color.red;

        Gizmos.matrix = Matrix4x4.TRS(aTransform.position + aTransform.rotation * offset, aTransform.rotation, attackDimentions);

        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
    }
}