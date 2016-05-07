using UnityEngine;
using System.Collections;

public class MySoloGoal : MonoBehaviour {

	private bool goalflag = false;

	// layer 8 is "Car"
	void OnTriggerEnter(Collider other) {
		if ((other.gameObject.layer == 8) && !goalflag) {
			Destroy(GameObject.Find("/Stage/CheckPoint/Goal/wall").gameObject);
			Destroy(GameObject.Find("/Stage/CheckPoint/Start").gameObject);
			goalflag = true;
			Invoke ("result", 4.0f);
		}
	}

	void result(){
		Application.LoadLevel ("main");
	}

}