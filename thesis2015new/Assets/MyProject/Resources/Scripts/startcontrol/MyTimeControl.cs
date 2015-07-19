using UnityEngine;
using System;
using System.Collections;

public class MyTimeControl : MonoBehaviour {
	
	GameObject[] carplayerobjects;
	GameObject[] cameraobjects;

	private DateTime _startTime;
	private int count;
	private int limittime = 3;
	private DateTime startTime;
	private bool countdownflag = false;

	void Awake () {
		carplayerobjects = GameObject.FindGameObjectsWithTag ("Player");
		cameraobjects = GameObject.FindGameObjectsWithTag ("Camera");
		count = limittime;
	}

	void Start () {
		enableReflectCount(false);
		startTime = DateTime.Now;
	}

	// need kaizen of algorithm
	void Update () {
		TimeSpan pastTime = DateTime.Now -startTime;
		count = pastTime.Seconds - limittime;
		reflectCount (pastTime.Minutes, pastTime.Seconds, pastTime.Milliseconds);
		if (!countdownflag && isCountZero ()) {
			countdownflag = true;
			removeCarKinematic();
			enableReflectCount(true);
			startTime = DateTime.Now;
		}
		if (isCountDown ()) {
			if(countdownflag) {
				limittime = 0;
			}
			reflectCountDown();
		}
	}

	private void enableReflectCount(bool flag) {
		foreach(GameObject cameraobject in cameraobjects) {
			cameraobject.GetComponent<MyCamera>().showCount(flag);
		}
	}
	
	private bool isCountDown() {
		return count < 2;
	}
	
	private bool isCountZero() {
		return count == 0;
	}

	private void reflectCountDown() {
		foreach(GameObject cameraobject in cameraobjects) {
			cameraobject.GetComponent<MyCamera>().showCountDown((-1)*count);
		}
	}

	private void reflectCount(int minutes, int seconds, int milliseconds) {
		foreach(GameObject cameraobject in cameraobjects) {
			cameraobject.GetComponent<MyCamera>().showNowCount(minutes, seconds, milliseconds);
		}
	}
	
	private void removeCarKinematic() {
		foreach(GameObject carobject in carplayerobjects) {
			carobject.rigidbody.isKinematic = false;
		}
	}
}
