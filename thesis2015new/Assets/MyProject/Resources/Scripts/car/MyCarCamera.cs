using UnityEngine;
using System.Collections;

public abstract class MyCarCamera : MonoBehaviour {

	protected MyCamera targetcamera;

	void Awake () {
		string targetname = gameObject.transform.root.name;
		targetname = "Camera" + targetname.Substring(3);
		targetcamera = GameObject.Find (targetname).gameObject.GetComponent<MyCamera>();
		initialize ();
	}

	protected virtual void initialize() {
	}
}