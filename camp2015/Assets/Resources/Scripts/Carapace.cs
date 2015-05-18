using UnityEngine;

public class Carapace : MonoBehaviour {

	private float movePower = 50f;
	private Vector3 cashVelocity;

	void OnEnable() {
		Invoke ("initializeCarapace", 0.1f);	// timelag
	}

	void initializeCarapace() {
		rigidbody.velocity = transform.forward * movePower;
	}

	void Update () {
		if (rigidbody.velocity.z * cashVelocity.z < 0 ||rigidbody.velocity.x * cashVelocity.x < 0 ) {
			transform.LookAt(transform.position + rigidbody.velocity);
		}
		if (rigidbody.velocity.y * cashVelocity.y < 0) {
			rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
		}
		cashVelocity = rigidbody.velocity;
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Banana") {
			DoubleDestroy(other.gameObject);
		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Carapace") {
			DoubleDestroy (other.gameObject);
		}
	}

	void DoubleDestroy(GameObject other) {
		Destroy (other);
		Destroy (gameObject);
	}
}
