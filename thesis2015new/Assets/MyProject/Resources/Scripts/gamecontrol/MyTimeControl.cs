using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MyTimeControl : MyGameControl {

	private GameObject[]   carplayerobjects;
	private GameObject[]   cameraobjects;
	private int            limittime     = 3;
	private TimeSpan       pastTime;
	private DateTime       startTime;
	private List<MyCamera> carcameras    = new List<MyCamera> ();
	private bool           countdownflag = true;

	protected override void initialize() {
		carplayerobjects = GameObject.FindGameObjectsWithTag ("Player");
		cameraobjects    = GameObject.FindGameObjectsWithTag ("Camera");
		foreach(GameObject cameraobject in cameraobjects) {
			carcameras.Add(cameraobject.GetComponent<MyCamera>());
		}
		foreach(GameObject carobject in carplayerobjects) {
			carobject.GetComponent<UnityStandardAssets.Vehicles.Car.MyCarUserControl>().enabled = false;
		}
		Application.targetFrameRate = 30;
		QualitySettings.vSyncCount = 0;
	}

	void Start () {
		startTime = DateTime.Now;
		enableReflectCount(false);
	}
	
	void Update () {
		pastTime = DateTime.Now - startTime;
		reflectCount(pastTime.Minutes, pastTime.Seconds, pastTime.Milliseconds);
		if(countdownflag) {
			int time = limittime - pastTime.Seconds;
			if(time > 0) {
				reflectCountDown(limittime - pastTime.Seconds);
			}
			else if(time == 0) {
				countdownflag = false;
				reflectCountDown(limittime - pastTime.Seconds);
				timeStart();
				removeCarKinematic();
				StartCoroutine(enableReflectCountDown(1, false));
			}
		}
	}

	private void enableReflectCount(bool flag) {
		foreach(MyCamera carcamera in carcameras) {
			carcamera.enabledCount(flag);
		}
	}

	private IEnumerator enableReflectCountDown(float delay, bool flag) {
		yield return new WaitForSeconds(delay);
		foreach(MyCamera carcamera in carcameras) {
			carcamera.enabledCountDown(flag);
		}
	}

	private void reflectCountDown(int second) {
		foreach(MyCamera carcamera in carcameras) {
			carcamera.showCountDown(second);
		}
	}

	private void reflectCount(int minutes, int seconds, int milliseconds) {
		foreach(MyCamera carcamera in carcameras) {
			carcamera.showNowCount(minutes, seconds, milliseconds);
		}
	}
	
	private void removeCarKinematic() {
		foreach(GameObject carobject in carplayerobjects) {
			carobject.GetComponent<UnityStandardAssets.Vehicles.Car.MyCarUserControl>().enabled = true;
		}
	}

	private void timeStart() {
		enableReflectCount(true);
		startTime = DateTime.Now;
	}
}