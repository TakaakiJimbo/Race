using UnityEngine;
using System.Collections;

public class MyCarPoint : MyCar {

	private int nowpointnumber    = -1;
	private int beforepointnumber = -1;
	private int maxpointnumber;
	private MyRoute myroute;
	[SerializeField] private AudioClip reverseaudio;

	protected override void initialize() {
		myroute = GameObject.Find ("Route").GetComponent<MyRoute> ();
	}
	
	void Start() {
		maxpointnumber = myroute.getPointMaxNumber();
		reflectReverse(false);
		targetcamera.showProgression(0, maxpointnumber);
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Point") {
			nowpointnumber = other.gameObject.GetComponent<MyPoint>().getPointNumber();
			warnReverseRun();
			reflectProgression();
		}
	}

	private bool checkReverseRun(int pointnumber) {
		if(pointnumber == 0 && beforepointnumber == maxpointnumber) {
			return false;
		}
		return pointnumber < beforepointnumber;
	}

	public void fadeIn(){
		targetcamera.fadeIn();
	}
	
	public void fadeOut(){
		targetcamera.fadeOut();
	}

	public int getNowPointNumber() {
		return nowpointnumber;
	}

	private void reflectReverse(bool flag) {
		targetcamera.enabledReverse(flag);
	}

	private void reflectProgression() {
		targetcamera.showProgression (nowpointnumber, maxpointnumber);
	}
	
	private void warnReverseRun(){
		if (checkReverseRun (nowpointnumber)) {
			reflectReverse (true);
			audio.Play();
		}
		else {
			reflectReverse (false);
		}
		beforepointnumber = nowpointnumber;
	}
}