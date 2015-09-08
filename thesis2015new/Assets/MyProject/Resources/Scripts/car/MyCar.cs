using UnityEngine;
using System.Collections;

public abstract class MyCar : MonoBehaviour {

	protected MyCamera    targetcamera;
	protected MySubCamera targetsubcamera;
	protected int         identifier;
	
	protected virtual void initialize() {}

	void Awake() {
		string targetname           = gameObject.transform.root.name;
		identifier                  = int.Parse(targetname.Substring(3));
		string targetcameraname     = "/" + targetname + "/Camera" ;
		targetcamera                = GameObject.Find (targetcameraname).GetComponent<MyCamera>();
		string targetsubcameraname  = "/" + targetname + "/SubCamera";
		targetsubcamera             = GameObject.Find (targetsubcameraname).GetComponent<MySubCamera>();
		initialize ();
	}
}