using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadLook : MonoBehaviour
{

    private PlayerMovement _playerMovement;

    void Start()
    {
        _playerMovement = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion tmpRotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_playerMovement.LookDir(), Vector3.up), 0.5f);

    }
}
