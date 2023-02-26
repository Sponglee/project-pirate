using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegsController : MonoBehaviour
{

    public LegRotator[] legs;
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        if (_playerMovement.IsMoving)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_playerMovement.MoveDir(), Vector3.up), 0.5f);

            for (int i = 0; i < legs.Length; i++)
            {
                legs[i].Engage();
            }
        }
        else
        {
            for (int i = 0; i < legs.Length; i++)
            {
                legs[i].Hold();
            }
        }
    }


}
