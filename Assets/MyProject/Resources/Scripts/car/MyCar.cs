using UnityEngine;
using System.Collections;

public abstract class MyCar : MonoBehaviour {

	protected GameObject  carobject;
	protected MyCamera    targetcamera;
	protected MySubCamera targetsubcamera;
	protected string      targetcameraname;
	protected string      targetsubcameraname;
	protected int         identifier;

	protected virtual void initialize() {}

	void Awake() {
		string targetname           = gameObject.transform.root.name;
		identifier                  = int.Parse(targetname.Substring(3));
		string carobjectname        = "/" + targetname + "/Car" ;
		carobject                   = GameObject.Find (carobjectname).gameObject;
		targetcameraname            = "/" + targetname + "/Camera" ;
		targetcamera                = GameObject.Find (targetcameraname).GetComponent<MyCamera>();
		targetsubcameraname         = "/" + targetname + "/SubCamera";
		targetsubcamera             = GameObject.Find (targetsubcameraname).GetComponent<MySubCamera>();
		initialize ();
	}
}