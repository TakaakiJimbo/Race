using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyCheckPoint : MonoBehaviour {

	[SerializeField]              private AudioClip checkedsound;
	[SerializeField, Range(1, 3)] private int       checkpointnumber;
	private int rank = 0;

	void Start () {
		iTween.ColorTo(gameObject.transform.root.gameObject,iTween.Hash("a",0,"looptype","pingpong","time",1f));
	}

	// layer 8 is "Car"
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer == 8) {
			GameObject carobject     = other.transform.root.gameObject;
			MyCarRank  carrank       = carobject.GetComponent<MyCarRank>();
			Vector3    carposition   = carobject.transform.position;
			markCheckPoint(checkpointnumber, carrank , carposition);
		}
	}

	private void markCheckPoint(int checkpointnumber, MyCarRank carrank, Vector3 carposition) {
		if (carrank.getCheckPoint() == checkpointnumber) {
			rank++;
			carrank.receiveRank(checkpointnumber, rank);
			AudioSource.PlayClipAtPoint (checkedsound, carposition);
		}
	}
}