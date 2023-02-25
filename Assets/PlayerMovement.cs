using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public NavMeshAgent agent;

    public float horMove;
    public float verticalMove;
    public Transform _worldCam;
    // Start is called before the first frame update
    void Start()
    {
        _worldCam = Camera.main.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        horMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        var move = new Vector3(horMove, transform.position.y, verticalMove);
        var camMove = _worldCam.rotation * move;

        if (camMove.magnitude <= 0.02f)
        {
            agent.ResetPath();
        }
        else
        {
            agent.SetDestination(transform.position + camMove);
        }

    }
}
