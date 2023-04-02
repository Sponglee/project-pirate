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

    }


}
