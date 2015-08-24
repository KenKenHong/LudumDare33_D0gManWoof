// using UnityEngine;
// using System.Collections;

// public class EnemyController : MonoBehaviour {

// 	public float patrolSpeed = 2f;
// 	public float chaseSpeed = 5f;
// 	public float chaseWaitTime = 5f;
// 	public float patrolWaitTime = 1f;
// 	public Transform[] patrolWayPoints;

// 	private EnemySight enemySight;
// 	private NavMeshAgent nav;
// 	private Transform player;
// 	private LastPlayerSighting lastPlayerSighting;
// 	private float chaseTimer;
// 	private float patrolTimer;
// 	private int wayPointIndex;

// 	void Start()
// 	{
// 		enemySight = GetComponent<EnemySight>();
// 		nav = GetComponent<NavMeshAgent>();
// 		player = GameObject.FindGameObjectWithTag(Tags.player).transform;
// 		//lastPlayerSighting = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<LastPlayerSighting>();
// 	}

// 	void Update()
// 	{
// 		if(enemySight.playerInSight)
// 		{
// 			Chase();
// 		}
// 		else
// 		{
// 			Patrol();
// 		}
// 	}

// 	void Chase()
// 	{
// 		Vector3 sightingDeltaPos = enemySight.personalLastSignting - transform.position;

// 		if(sightingDeltaPos.sqrMagnitude > 4f)
// 		{
// 			nav.destination = enemySignt.personalSighting;
// 		}

// 		nav.speed = chaseSpeed;

// 		if(nav.remainingDistance < nav.stoppingDistance)
// 		{
// 			chaseTimer += Time.deltaTime;

// 			if(chaseTimer >= chaseWaitTime)
// 			{
// 				lastPlayerSighting.position = lastPlayerSighting.resetPosition;
// 				enemySight.personalLastSignting = lastPlayerSighting.resetPosition;
// 				chaseTimer = 0f;
// 			}
// 			else
// 			{
// 				chaseTimer = 0f;
// 			}
// 		}
// 	}

// 	voic Patrol()
// 	{
// 		nav.speed = patrolSpeed;

// 		if(nav.destination == lastPlayerSighting.resetPosition || nav.remainingDistance < nav.stoppingDistance)
// 		{
// 			patrolTimer += Time.deltaTime;

// 			if(patrolTimer >= patrolWaitTime)
// 			{
// 				if(wayPointIndex == patrolWayPoints.Length - 1)
// 				{
// 					wayPointIndex = 0;
// 				}
// 				else
// 				{
// 					wayPointIndex++;
// 				}

// 				patrolTimer = 0;
// 			}
// 		}
// 		else
// 		{
// 			patrolTimer = 0;
// 		}
// 		nav.destination = patrolWayPoints[wayPointIndex].position;
// 	}
// }
