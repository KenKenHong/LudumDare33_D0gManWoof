using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour
{
	public float fieldOfViewAngle = 110f;
	public bool playerInSight = false;
	public Vector3 personalLastSighting;

	private NavMeshAgent nav;
    private SphereCollider hearing;
	private Animator anim;
	private LastPlayerPosition lastPlayerPosition;
	private GameObject player;
	private Animator playerAnim;
	private Vector3 previousSighting;
    private PlayerHealth playerHealth;
    private HashIDs hash;

	void Awake()
	{
        nav = GetComponent<NavMeshAgent>();
        hearing = GetComponent<SphereCollider>();
        anim = GetComponent<Animator>();

        lastPlayerPosition = GameObject.FindGameObjectWithTag("GameController").GetComponent<LastPlayerPosition>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

        playerAnim = player.GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();

        personalLastSighting = lastPlayerPosition.resetPosition;
        previousSighting = lastPlayerPosition.resetPosition;
	}

	void Update()
	{
        if (lastPlayerPosition.position != previousSighting)
            personalLastSighting = lastPlayerPosition.position;

        previousSighting = lastPlayerPosition.position;

        //if (playerHealth.health > 0f)
            anim.SetBool(hash.foundPlayerBool, playerInSight);
        //else
            anim.SetBool(hash.foundPlayerBool, false);
	}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            playerInSight = false;

            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.up);

            if(angle < fieldOfViewAngle * 0.5f)
            {
                RaycastHit hit;

                if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, hearing.radius))
                {
                    if (hit.collider.gameObject.tag.Equals("Player"))
                    {
                        playerInSight = true;
                        lastPlayerPosition.position = player.transform.position;
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            playerInSight = false;
            lastPlayerPosition.position = lastPlayerPosition.resetPosition;
        }
    }

    float CalculatePathLength(Vector3 targetPosition)
    {
        NavMeshPath path = new NavMeshPath();
        if (nav.enabled)
            nav.CalculatePath(targetPosition, path);

        Vector3[] wayPoints = new Vector3[path.corners.Length + 2];
        wayPoints[0] = transform.position;
        wayPoints[wayPoints.Length - 1] = targetPosition;

        for (int i = 0; i < path.corners.Length; i++)
            wayPoints[i] = path.corners[i];

        float pathLength = 0;

        for (int i = 0; i < wayPoints.Length - 1; i++)
            pathLength += Vector3.Distance(wayPoints[i], wayPoints[i + 1]);

        return pathLength;
    }
}