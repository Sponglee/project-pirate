using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    public void TakeDamage(float damageAmount, Transform damageSource, Vector3 hitPoint);


}
