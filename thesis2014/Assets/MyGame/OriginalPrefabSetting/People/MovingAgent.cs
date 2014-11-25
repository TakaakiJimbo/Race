using UnityEngine;
using System.Collections;

public class MovingAgent : MonoBehaviour {

//	public GameObject			particle;
	protected NavMeshAgent		agent;
	protected Animator			animator;

	protected Locomotion locomotion;
//	protected Object particleClone;

	public float agentDestX;
	public float agentDestY;
	public float agentDestZ;
	protected Vector3 agentDest;
	protected Vector3 agentStart;

	public float agentSpeedLevel;	// 1:run, 2:walk ......

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;

		animator = GetComponent<Animator>();
		locomotion = new Locomotion(animator);

//		agentStart = agent.nextPosition;
		agentStart = this.transform.position;
		agentDest = new Vector3(agentDestX, agentDestY, agentDestZ);
		agent.destination = agentDest;
		agent.speed = agent.speed / agentSpeedLevel;

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
		if (AgentStopping())
		{
			agent.destination = agentStart;
			agentStart = agentDest;
			agentDest = agent.destination;

		}
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
		ChangeDestination ();
		SetupAgentLocomotion();
	}
}
