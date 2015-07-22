using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyRoute : MonoBehaviour {

	private MyPoint[] point;
	private int       pointmaxnumber = 0;

	void Awake() {
		point          = gameObject.GetComponentsInChildren<MyPoint>();
		pointmaxnumber = point.Length - 1;
		for (int i = pointmaxnumber ; i >= 0 ; i--) {
			point[i].changePointNumber(point.Length - 1 - i);
		}
	}

	public Vector3 getNextPointNumberPosition(int pointnumber) {
		int pointnextnumber = pointmaxnumber - pointnumber - 1;
		if(pointnextnumber > -1) {
			return point[pointnextnumber].getPointPosition();
		}
		return point[pointmaxnumber].getPointPosition();
	}

	public int getPointMaxNumber() {
		return pointmaxnumber;
	}

	public Vector3 getPointNumberPosition(int pointnumber) {
		return point[pointmaxnumber - pointnumber].getPointPosition();
	}

}