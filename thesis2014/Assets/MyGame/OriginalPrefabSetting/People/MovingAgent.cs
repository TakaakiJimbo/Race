using UnityEngine;
using System;
using System.Collections;

public class MovingAgent : MonoBehaviour {

//	public GameObject			particle;
	protected NavMeshAgent		agent;
	protected Animator			animator;

	protected Locomotion locomotion;
//	protected Object particleClone;

	public int agentDestLocation;
	protected float[] agentDestPos = new float[3];
	protected Vector3 agentDest;
	protected Vector3 agentStart;
	
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;

		animator = GetComponent<Animator>();
		locomotion = new Locomotion(animator);

		switch (agentDestLocation) 
		{
			case 0:	// BlockA : convenience store
				agentDestPos[0] = -981.9131f;
				agentDestPos[1] = 7.907458f;
				agentDestPos[2] = -104.3788f;
				break;
			case 1:	// BlockB : family restaurant
				agentDestPos[0] = -791.6163f;
				agentDestPos[1] = 7.650063f;
				agentDestPos[2] = -139.248f;
				break;
			case 2:	//  BlockC : tall building
				agentDestPos[0] = -374.0801f;
				agentDestPos[1] = 8.129205f;
				agentDestPos[2] = -142.1313f;
				break;
			case 3:	// BlockD : grenn and blue something
				agentDestPos[0] = -969.7093f;
				agentDestPos[1] = 4.226419f;
				agentDestPos[2] = -421.7555f;
				break;
			case 4:	// BlockE : wanted advertisement
				agentDestPos[0] = -223.357f;
				agentDestPos[1] = 6.180432f;
				agentDestPos[2] = -638.4968f;
				break;
			case 5:	// BlockF : street
				agentDestPos[0] = -141.5191f;
				agentDestPos[1] = 6.16483f;
				agentDestPos[2] = -414.2057f;
				break;
			case 6:	// BlockG : CVS24
				agentDestPos[0] = -1174.267f;
				agentDestPos[1] = 4.207728f;
				agentDestPos[2] = -970.4562f;
				break;
			case 7:	// BlockH : potato
				agentDestPos[0] = -240.7657f;
				agentDestPos[1] = 6.173015f;
				agentDestPos[2] = -862.8098f;
				break;
			case 8:	// BlockI : donuts shop
				agentDestPos[0] = -184.5517f;
				agentDestPos[1] = 6.12671f;
				agentDestPos[2] = -946.6146f;
				break;
			case 9:	// akb electric shop
				agentDestPos[0] = -206.8f;
				agentDestPos[1] = 6.85f;
				agentDestPos[2] = -384.41f;
				break;
		}
		agentStart = this.transform.position;
		agentDest = new Vector3(agentDestPos[0], agentDestPos[1], agentDestPos[2]);
		agent.destination = agentDest;
		//		particleClone = null;
	}
	
	protected void SetDestination()
	{
		//		// Construct a ray from the current mouse coordinates
//		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//		RaycastHit hit = new RaycastHit();
//		if (Physics.Raycast(ray, out hit))
//		{
//			if (particleClone != null)
//			{
//				GameObject.Destroy(particleClone);
//				particleClone = null;
//			}
//
//			// Create a particle if hit
//			Quaternion q = new Quaternion();
//			q.SetLookRotation(hit.normal, Vector3.forward);
//			particleClone = Instantiate(particle, hit.point, q);
//
//			agent.destination = hit.point;
//		}
	}

//	void OnTriggerStay(Collider other) 
//	{
//		if ( this.enabled == false ) return;
//		Vector3 dir = this.transform.position - other.transform.position;
//		Vector3 pos = this.transform.position + dir * 0.5f;
//		agent.destination = pos;
//	}

	protected void SetupAgentLocomotion()
	{
		if (AgentDone())
		{
			locomotion.Do(0, 0);
			ChangeDestination ();
//			if (particleClone != null)
//			{
//				GameObject.Destroy(particleClone);
//				particleClone = null;
//			}
		}
		else
		{
			float speed = agent.desiredVelocity.magnitude;

			Vector3 velocity = Quaternion.Inverse(transform.rotation) * agent.desiredVelocity;

			float angle = Mathf.Atan2(velocity.x, velocity.z) * 180.0f / 3.14159f;

			locomotion.Do(speed, angle);
		}
	}

    void OnAnimatorMove()
    {
        agent.velocity = animator.deltaPosition / Time.deltaTime;
		transform.rotation = animator.rootRotation;
    }

	void ChangeDestination()
	{
			agent.destination = agentStart;
			agentStart = agentDest;
			agentDest = agent.destination;
	}

	protected bool AgentDone()
	{
		return !agent.pathPending && AgentStopping();
	}

	protected bool AgentStopping()
	{
		return agent.remainingDistance <= agent.stoppingDistance;
	}

	// Update is called once per frame
	void Update () 
	{
//		if (Input.GetButtonDown ("Fire1")) 
//			SetDestination();
//		Debug.Log (agentStart);
		SetupAgentLocomotion();
	}
}
