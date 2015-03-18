using UnityEngine;
using System.Collections;

public class Carapace : MonoBehaviour {

	private float movePower = 200.0f;
	private Vector3 cashVelocity;
	private float maxSpeed = 20;
	
	// Update is called once per frame
	void Update () {
		rigidbody.AddForce (transform.forward * movePower * Time.deltaTime);
		if (rigidbody.velocity.z * cashVelocity.z < 0 ||rigidbody.velocity.x * cashVelocity.x < 0 ) {
			transform.LookAt(transform.position + rigidbody.velocity);
		}
		if (rigidbody.velocity.y * cashVelocity.y < 0) {
			rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
		}
		cashVelocity = rigidbody.velocity;
		if (rigidbody.velocity.magnitude > maxSpeed) {
			rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
		}
	}
}
