using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BoxAttack", order = 1)]
public class BoxScriptableAttack : ScriptableAttackBase
{

    public Vector3 attackDimentions;

    public Vector3 offset;

    public override void Attack()
    {

    }

    public override void OnGizmos(Transform aTransform)
    {
        Gizmos.color = Color.red;

        Gizmos.matrix = Matrix4x4.TRS(aTransform.position + aTransform.rotation * offset, aTransform.rotation, attackDimentions);

        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
    }
}