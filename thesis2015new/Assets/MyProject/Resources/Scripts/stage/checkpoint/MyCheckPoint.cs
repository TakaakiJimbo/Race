using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyCheckPoint : MonoBehaviour {

	[SerializeField]              private AudioClip checkedsound;
	[SerializeField, Range(1, 3)] private int       checkpointnumber;
	private int rank = 0;
	
	// layer 8 is "Car"
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer == 8) {
			string     targetname    = "/" + other.transform.root.gameObject.name + "/Car";
			GameObject carobject     = GameObject.Find(targetname);
			MyCarRank  carrank       = carobject.GetComponent<MyCarRank>();
			Vector3    carposition   = carobject.transform.position;
			markCheckPoint(checkpointnumber, carrank , carposition);
			if(checkpointnumber == 2) {
				GameObject.Find("Stage").GetComponent<AudioSource>().pitch = 1.25f;
			}
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