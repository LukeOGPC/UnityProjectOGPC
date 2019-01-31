using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour 
{
	private PlayerController player;
	UnityEngine.AI.NavMeshAgent agent;

	void Start () 
	{
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		player = FindObjectOfType<PlayerController> ();
	}

	void Update () 
	{
		agent.SetDestination (player.transform.position);
	}
}
