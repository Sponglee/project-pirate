using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public Transform modelHolder;
    public Transform weaponHolder;
    public Animator playerAnimator;
    private PlayerMovement _playerMovement;
    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public void JumpAnim(bool aToggle)
    {

    }

    public void RollAnim()
    {

    }


}
