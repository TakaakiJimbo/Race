using UnityEngine;
using System.Collections;

public class MyCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Car 
	void OnTriggerEnter(Collider other) {
		switch (CheckColliderTag (other.gameObject.tag)) {
		case 1 :
			break;
		default :
			break;
		}
	}

	int CheckColliderTag(string tag) {
		switch (tag) {
			case "Dashboard" : 
				return 1;
				break;
			default :
				return 0;
				break;
		}
	}

}
