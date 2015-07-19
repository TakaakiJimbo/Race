using UnityEngine;
using System.Collections;

public class MyBanana : MonoBehaviour {

	void OnCollisionEnter(Collision other) {
		iTween.RotateTo(gameObject, iTween.Hash("y", 1080, "time", 2.0f));
	}

}
