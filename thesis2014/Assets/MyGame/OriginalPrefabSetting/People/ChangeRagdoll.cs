using UnityEngine;
using System.Collections;

public class ChangeRagdoll : MonoBehaviour {
	
	public float forceDegree = 1.0f;
	protected float agentSpeed = 1;


	void OnCollisionEnter(Collision collision) 
	{
		GetComponent<Animator>().enabled = false;
		GetComponent<NavMeshAgent>().enabled = false;
		GetComponent<MovingAgent>().enabled = false;
		GetComponent<CapsuleCollider>().enabled = false;
		GetComponent<SphereCollider>().enabled = false;
		
		Vector3 vec = collision.impactForceSum;
		float mag = vec.magnitude;
		vec.Normalize();
		vec.y += 0.5f;
		vec.Normalize();
		vec *= mag;
		
		Rigidbody [] ragdollRB = this.gameObject.GetComponentsInChildren<Rigidbody>();
		foreach( Rigidbody rb in ragdollRB ) {
			rb.isKinematic = false;
			rb.AddForce( vec * forceDegree, ForceMode.Impulse );
		}
		this.enabled = false;
		Invoke ("DestroyComponent", 3);
	}

	void DestroyComponent(){
		Debug.Log("deleted");
		Destroy (gameObject);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player")
		{
			OnTriggerEnterSetSpeed();
		}
		else if (other.gameObject.tag == "AI")
		{
			OnTriggerEnterSetSpeed();
		}
		else if (other.gameObject.tag == "walker_signal_collider")
		{
			OnTriggerEnterSetSpeed();
		}
	}

	void OnTriggerEnterSetSpeed(){
		agentSpeed = GetComponent<NavMeshAgent> ().speed;
		GetComponent<NavMeshAgent>().speed = 0;
	}

	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "AI")
		{
			GetComponent<NavMeshAgent>().speed = 8;
		}
	}
	
	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player")
		{
			OnTriggerExitSetSpeed();
		}
		else if (other.gameObject.tag == "walker_signal_collider")
		{
			OnTriggerExitSetSpeed();
		}
	}

	void OnTriggerExitSetSpeed(){
		GetComponent<NavMeshAgent> ().speed = agentSpeed;
	}
}