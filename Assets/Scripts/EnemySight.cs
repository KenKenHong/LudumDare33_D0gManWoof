using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour
{
	public float fieldOfViewAngle = 110f;
	public bool playerInSight;
	public Vector3 personalLastSighting;

	private NavMeshAgent nav;
	private SphereCollider col;
	private Animator anim;
	//private LastPlayerSighting LastPlayerSighting;
	private GameObject player;
	private Animator playerAnim;
	private Vector3 previousSighting;

	void Start()
	{
		nav = GetComponent<NavMeshAgent>();
        col = GetComponent<SphereCollider>();
        anim = GetComponent<Animator>();
        lastPlayerSighting = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<LastPlayerSighting>();
        //player = GameObject.FindGameObjectWithTag(Tags.player);
        playerAnim = player.GetComponent<Animator>();
        //hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();

        //personalLastSighting = lastPlayerSighting.resetPosition;
        //previousSighting = lastPlayerSighting.resetPosition;
	}

	void Update()
	{
		
	}
	
}
