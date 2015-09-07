using UnityEngine;
using System.Collections;

public class MyCarRecover : MyCourseOut {

	[SerializeField] private int damagecarvalue = -1;

	private MyCarLifePoint carlifepoint;
	private bool           recover = true;

	// I do not know why enable to read "OnCollisionEnter" from "MyCourseOut" class nevertheless setting private class
	protected override void OnCollisionEnter (Collision other) {
	}

	void Start() {
		carlifepoint = gameObject.GetComponent<MyCarLifePoint> ();
	}

	public IEnumerator enabledRecover(float delay, bool flag) {
		yield return new WaitForSeconds(delay);
		recover = true;
	}

	public void recoverStage(bool buttondown){
		if(buttondown && recover) {
			recover = false;
			carlifepoint.changeLifePoint(damagecarvalue);
			returnCourse(gameObject);
			StartCoroutine(enabledRecover(2f, true));
		}
	}

}