using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GroundEnemy : Enemy {

	[SerializeField] protected float speed;



	public override void Reset()
	{
		base.Reset ();
		NavMeshAgent agent = GetComponent<NavMeshAgent> ();
		agent.destination = target.position;
		//transform.Translate (Vector3.forward * speed * Time.deltaTime, Space.Self);
	}
}
