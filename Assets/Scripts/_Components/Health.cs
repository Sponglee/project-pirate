using Anthill.Core;
using UnityEngine;

public class Health : MonoBehaviour
{
    public bool CanTakeDamage = true;
    public float cashedDamage = 0;
    public float health = 100.0f;
    public bool CanDie = true;
    private AntEntity _entity;

    private void Start()
    {
        _entity = GetComponent<AntEntity>();
        AntEngine.AddEntity(_entity);
    }

    public bool IsDead()
    {
        return CanDie ? health <= 0f : false;
    }
}