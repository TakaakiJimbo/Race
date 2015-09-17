using UnityEngine;
using System.Collections;

public class MyCarLifePoint : MyCar  {

	[SerializeField] public int lifepoint = 3;	//  if lifepoint  > 0, the car will be alive

	void Start() {
		reflectLifePoint();
	}

	public void changeLifePoint(int changepoint) {
		if(!targetcamera.isResult()) {
			lifepoint += changepoint;
			if(!isAliveLifePoint()) {
				lifepoint = 0;
				gameObject.GetComponent<MyCarRank>().receiveRank(3, -1);	// finish mode, failed to goal
				Invoke("diedAnimation", 1);
			}
			reflectLifePoint();
		}
	}

	public int getLifePoint() {
		return lifepoint;
	}

	public bool isAliveLifePoint() {
		return lifepoint > 0;
	}

	private void reflectLifePoint() {
		targetcamera.showLifePoint(lifepoint);
	}
	
	private void diedAnimation() {
		gameObject.GetComponent<UnityStandardAssets.Vehicles.Car.MyCarUserControl>().enabled = false;
		gameObject.GetComponent<Rigidbody>().isKinematic = true;
		gameObject.GetComponent<Detonator>().Explode();
		iTween.ScaleTo(gameObject, iTween.Hash("x", 0, "y", 0, "z", 0, "time", 0.0f));
		gameObject.GetComponents<AudioSource>()[0].Play();	// die sound
	}
}