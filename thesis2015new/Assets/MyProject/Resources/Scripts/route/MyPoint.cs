using UnityEngine;
using System.Collections;

public class MyPoint : MonoBehaviour {

	private int pointnumber;

	public void changePointNumber(int number) {
		pointnumber = number;
	}
	
	public Vector3 getPointDirection() {
		return gameObject.transform.localEulerAngles;
	}
	
	public int getPointNumber() {
		return pointnumber;
	}
	
	public Vector3 getPointPosition() {
		return gameObject.transform.position;
	}
}