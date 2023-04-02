using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{


    public float movementSpeed = 15f;
    public float rotationSpeed = 10f;
    public float jumpForce = 100f;
    public bool IsMoving = false;
    public bool IsJumping = false;
    public bool IsRolling = false;
    public bool IsGrounded = false;
    private PlayerController playerController;
    private Camera _worldCam;
    private CharacterController characterController;
    [SerializeField] private float horMove = 0f;
    [SerializeField] private float verticalMove = 0f;
    private Vector3 move;
    [SerializeField] private float jumpVelocity = 0f;

    void Start()
    {
        _worldCam = Camera.main;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        horMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");

        move = new Vector3(horMove, jumpVelocity, verticalMove);

        IsMoving = Vector3.Scale(move, new Vector3(1, 0, 1)).magnitude > 0f;
        IsGrounded = characterController.isGrounded;

        if (Input.GetButtonDown("Jump") && characterController.isGrounded)
        {
            IsJumping = true;
        }
        else if (characterController.isGrounded && IsJumping)
        {
            IsJumping = false;
        }

        if (Input.GetButtonDown("Roll"))
        {
            IsRolling = true;
        }
        else if (Input.GetButtonUp("Roll"))
        {
            IsRolling = false;
        }


        HandleRotation();
        HandleMovement();
        HandlePhysics();
    }
    private void HandleRotation()
    {
        Vector3 positionLookAt = move;
        positionLookAt.y = 0f;

        if (IsMoving)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(positionLookAt), rotationSpeed * Time.deltaTime);
    }

    private void HandleMovement()
    {
        jumpVelocity = characterController.isGrounded ? -0.05f : -9.8f;
        if (IsJumping) jumpVelocity = characterController.isGrounded ? jumpForce : -9.8f;

        characterController.Move(move * movementSpeed * Time.deltaTime);
    }

    private void HandlePhysics()
    {

    }


    private void OnDrawGizmos()
    {


    }
}
