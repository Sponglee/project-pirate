using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{

    public Transform movePivot;
    public Transform lookPivot;
    public Transform modelHolder;
    public Transform weaponController;
    public float recenterTreshold = 2f;



    private NavMeshAgent agent;
    private float horMove;
    private float verticalMove;
    private Camera _worldCam;
    private float timer = 0f;
    private bool lookEngaged = false;

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

        if (Input.GetButton("Fire1"))
        {
            RaycastHit hit;
            Ray ray = _worldCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Ground")))
            {
                lookPivot.transform.position = transform.position + (hit.point - transform.position).normalized * 5f;
                lookEngaged = true;
                timer = 0f;
            }
        }
    }

    private void FixedUpdate()
    {
        if (MoveDir().magnitude <= 0.02f)
        {
            agent.ResetPath();
            weaponController.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(LookDir(), Vector3.up), 0.5f);
        }
        else
        {
            // agent.SetDestination(transform.position + camMove * 2f);
            agent.Move(MoveDir() * agent.speed * Time.fixedDeltaTime);
            modelHolder.rotation = Quaternion.Lerp(modelHolder.rotation, Quaternion.LookRotation(MoveDir(), Vector3.up), 0.5f);
        }

        if (LookDir().magnitude != 0)
            weaponController.LookAt(lookPivot.position);



        if (lookEngaged)
        {
            timer += Time.deltaTime;
            if (timer >= recenterTreshold)
            {
                lookEngaged = false;
                timer = 0f;

                if (MoveDir().magnitude >= 0.02f)
                    lookPivot.position = movePivot.position;
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
