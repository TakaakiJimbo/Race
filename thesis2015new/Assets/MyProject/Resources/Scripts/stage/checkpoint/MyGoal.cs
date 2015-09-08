using UnityEngine;
using System.Collections;

public class MyGoal : MonoBehaviour {

	private bool goalflag = false;

	// layer 8 is "Car"
	void OnTriggerEnter(Collider other) {
		if ((other.gameObject.layer == 8) && !goalflag) {
			Destroy(GameObject.Find("/Stage/CheckPoint/Goal/wall").gameObject);
			goalflag = true;
		}
	}
}