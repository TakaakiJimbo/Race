using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyRoute : MonoBehaviour {

	private MyPoint[] point;
	private int pointmaxnumber = 0;

	void Awake() {
		point = gameObject.GetComponentsInChildren<MyPoint>();
		for (int i = 0; i < point.Length; i++) {
			point[i].changePointNumber(i);
			pointmaxnumber++;
		}
	}

	public int getPointMaxNumber() {
		return pointmaxnumber;
	}

	public Vector3 getPointNumberPosition(int pointnumber) {
		return point[pointnumber].getPointPosition();
	}

	public Vector3 getPointNumberDirection(int pointnumber) {
		return point[pointnumber].getPointDirection();
	}
}
