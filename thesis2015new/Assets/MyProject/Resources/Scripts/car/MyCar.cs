using UnityEngine;
using System.Collections;

public abstract class MyCar : MonoBehaviour {

	protected MyCamera targetcamera;
	protected int      identifier;
	
	protected virtual void initialize() {}

	void Awake() {
		string targetname = gameObject.transform.root.name;
		identifier        = int.Parse(targetname.Substring(3));
		targetname        = "Camera" + targetname.Substring(3);
		targetcamera      = GameObject.Find (targetname).gameObject.GetComponent<MyCamera>();
		initialize ();
	}
}