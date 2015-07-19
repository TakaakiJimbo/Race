using UnityEngine;
using System.Collections;

public class MyLifePoint : MyCarCamera  {

	[SerializeField]  private int lifepoint = 3;	//  if lifepoint  > 0, the car will be alive
	
	public void changeLifePoint(int changepoint) {
		lifepoint += changepoint;
		if(!isAliveLifePoint ()) {
			lifepoint = 0;
			Invoke("dieAction", 1);
		}
		reflectLifePoint ();
	}

	public int getLifePoint() {
		return lifepoint;
	}
	
	protected override void initialize() {
		reflectLifePoint ();
	}

	public bool isAliveLifePoint() {
		return lifepoint >= 0;
	}

	private void reflectLifePoint() {
		targetcamera.showLifePoint (lifepoint);
	}


	// need to kaizen
	private void dieAction() {
		gameObject.GetComponent<Detonator>().Explode();
		iTween.ScaleTo(gameObject, iTween.Hash("x", 0, "y", 0, "z", 0, "time", 0.0f));
		gameObject.rigidbody.isKinematic = true;
	}
}
