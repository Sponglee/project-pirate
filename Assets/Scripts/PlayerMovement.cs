using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public PlayerController playerController;

    public Transform movePivot;
    public float recenterTreshold = 2f;
    public bool IsMoving = false;
    public bool IsJumping = false;

    private Camera _worldCam;
    private CharacterController characterController;
    public float movementSpeed = 15f;
    public float rotationSpeed = 10f;
    private float horMove;
    private float verticalMove;
    private float timer = 0f;
    private bool lookEngaged = false;
    public bool LookEngaged
    {
        get => lookEngaged; set
        {
            lookEngaged = value;

            if (value)
                timer = 0f;
        }
    }

    void Start()
    {
        _worldCam = Camera.main;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        horMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        var move = new Vector3(horMove, 0f, verticalMove);
        movePivot.position = transform.position +
        Vector3.Scale(_worldCam.transform.rotation * move * 5f, new Vector3(1, 0, 1)).normalized;

        IsMoving = move.magnitude >= characterController.minMoveDistance;

        if (Input.GetButtonDown("Jump") && !IsJumping)
        {
            playerController.JumpAnim(false);
            IsJumping = true;
        }
        else if (Input.GetButtonUp("Jump") && IsJumping)
        {
            playerController.JumpAnim(false);
            IsJumping = false;
        }

        if (Input.GetButtonDown("Roll"))
        {
            playerController.RollAnim();
        }


        HandleRotation();
        HandleMovement();

    }
    private void HandleRotation()
    {
        Vector3 positionLookAt = MoveDir();
        positionLookAt.y = 0f;

        if (IsMoving)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(positionLookAt), rotationSpeed * Time.deltaTime);
    }

    private void HandleMovement()
    {
        characterController.SimpleMove(MoveDir() * movementSpeed);
    }

    public Vector3 MoveDir()
    {
        return (movePivot.position - transform.position).normalized;
    }



    private void OnDrawGizmos()
    {

        if (movePivot != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(movePivot.position, 0.5f);
        }


    }
}
