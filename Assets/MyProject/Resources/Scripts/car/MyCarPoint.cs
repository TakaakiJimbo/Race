using UnityEngine;
using System.Collections;

public class MyCarPoint : MyCar {

	private int nowpointnumber    = 0;
	private int beforepointnumber = -1;
	private int maxpointnumber;
	private AudioSource reversesound;

	private MyRoute     myroute;

	protected override void initialize() {
		myroute = GameObject.Find ("Route").GetComponent<MyRoute> ();
	}

	private bool isBattleMode() {
		return maxpointnumber <= 1;
	}

	void Start() {
		reversesound   = gameObject.GetComponent<AudioSource>();
		maxpointnumber = myroute.getPointMaxNumber();
		reflectReverse(false);
		if(isBattleMode()) {
			reflectStartGoalIcon(false);
		}
		targetcamera.showProgression(0, maxpointnumber);
	}

	private void reflectStartGoalIcon(bool flag) {
		targetcamera.enabledStartGoalIcon(flag);
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Point" && !isBattleMode()) {
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
			reversesound.Play();
		}
		else {
			reflectReverse (false);
		}
		beforepointnumber = nowpointnumber;
	}
}