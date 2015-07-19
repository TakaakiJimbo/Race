using UnityEngine;
using System;

public class  MyCarapace : MonoBehaviour {

	private float movePower = 1f;
	private Vector3 cashVelocity;

	void OnEnable() {
		Invoke ("initializeCarapace", 0.001f);	// timelag
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
		if (other.gameObject.tag.IndexOf("Player") >= 0) {
			iTween.MoveTo(other.gameObject.transform.root.gameObject, iTween.Hash("y", 20, "time", 1.5f));
			iTween.RotateTo(other.gameObject.transform.root.gameObject, iTween.Hash("x", 1080 , "y", 1080, "z", 1080, "time", 2.5f));
		}
	}
	
	void DoubleDestroy(GameObject other) {
		Destroy (other);
		Destroy (gameObject);
	}
}
