using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform movementTransform;
    public Rigidbody rb;
    public bool IsOnGround = false;
    public bool IsJumping = false;
    public float jumpForce = 10f;
    public float speed = 10f;
    public float movementX;
    public float movementY;
}
