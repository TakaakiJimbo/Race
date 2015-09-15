using UnityEngine;
using System.Collections;

public abstract class MyGameControl : MonoBehaviour {

	protected GameObject[] carobjects;
	protected int          number = 0;

	protected abstract void initialize();

	void Awake () {
		carobjects = GameObject.FindGameObjectsWithTag("Player");
		foreach(GameObject car in carobjects) {
			number++;
		}
		initialize();
	}
}