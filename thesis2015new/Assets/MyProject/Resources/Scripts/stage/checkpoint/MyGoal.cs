using UnityEngine;
using System.Collections;

public class MyGoal : MonoBehaviour {

	private bool goalflag = false;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.IndexOf ("Car") >= 0 && !goalflag) {
			Destroy(gameObject.FindDeep("wall").gameObject);
			goalflag = true;
		}
	}
}