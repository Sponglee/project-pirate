using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public Transform movePivot;
    public Transform lookPivot;
    public Transform modelHolder;
    public Animator modelAnimator;
    public float recenterTreshold = 2f;

    public bool IsMoving = false;
    public bool IsJumping = false;

    private Camera _worldCam;
    private NavMeshAgent agent;
    private float horMove;
    private float verticalMove;
    private float timer = 0f;
    private bool lookEngaged = false;
    
    private static readonly int IsJump = Animator.StringToHash("IsJump");
    private static readonly int IsRoll = Animator.StringToHash("IsRoll");

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
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }

    void Update()
    {
        horMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        var move = new Vector3(horMove, 0f, verticalMove);
        movePivot.position = transform.position + Vector3.Scale(_worldCam.transform.rotation * move * 5f, new Vector3(1, 0, 1)).normalized;

        IsMoving = move.magnitude >= 0.02f;

        if (Input.GetButtonDown("Jump"))
        {
            modelAnimator.SetBool(IsJump, true);
            IsJumping = true;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            modelAnimator.SetBool(IsJump, false);
            IsJumping = false;
        }

        if (Input.GetButtonDown("Roll"))
        {
            modelAnimator.SetBool(IsRoll, true);
        }
        else if (Input.GetButtonUp("Roll"))
        {
            modelAnimator.SetBool(IsRoll, false);
        }

    }

    private void FixedUpdate()
    {
        if (MoveDir().magnitude <= 0.02f)
        {
            agent.ResetPath();
            modelHolder.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(LookDir(), Vector3.up), 0.5f);
        }
        else
        {
            agent.Move(MoveDir() * (agent.speed * Time.fixedDeltaTime));
            modelHolder.rotation = Quaternion.Lerp(modelHolder.rotation, Quaternion.LookRotation(MoveDir(), Vector3.up), 0.5f);
        }

        if (LookDir().magnitude != 0)
            modelHolder.LookAt(lookPivot.position);
        
        if (LookEngaged)
        {
            timer += Time.deltaTime;
            if (timer >= recenterTreshold)
            {
                LookEngaged = false;
                timer = 0f;

                if (MoveDir().magnitude >= 0.02f)
                    lookPivot.position = Vector3.Lerp(lookPivot.position, movePivot.position, 0.5f);
            }
        }
        else
        {
            if (MoveDir().magnitude >= 0.02f)
                lookPivot.position = Vector3.Lerp(lookPivot.position, movePivot.position, 0.5f);
        }
    }
    
    public Vector3 MoveDir()
    {
        return (movePivot.position - transform.position).normalized;
    }

    public Vector3 LookDir()
    {
        return (lookPivot.position - transform.position).normalized;
    }

    private void OnDrawGizmos()
    {
        if (movePivot != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(movePivot.position, 0.5f);
        }

        if (lookPivot != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(lookPivot.position, 1f);
        }
    }
}
