using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    private PlayerMovement _playerMovement;


    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        // IsMoving
    }

}
