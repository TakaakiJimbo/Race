using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyCheck : MonoBehaviour {

	[SerializeField] private AudioClip checkedaudio;
	[SerializeField, Range(1, 3)] private int checkpointnumber;
	private int rank = 0;

	void Start () {
		iTween.ColorTo(gameObject.transform.root.gameObject,iTween.Hash("a",0,"looptype","pingpong","time",1f));
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.IndexOf ("Player") >= 0) {
			GameObject carobject = other.transform.root.gameObject;
			markCheckPoint(carobject.GetComponent<MyCheckPoint> (), checkpointnumber, carobject.GetComponent<MyRank> (), carobject.transform.position);
		}
	}

	private void markCheckPoint(MyCheckPoint carcheckpoint, int checkpointnumber, MyRank carrank, Vector3 position) {
		if (carcheckpoint.getcheckedpoint() == checkpointnumber) {
			rank++;
			carcheckpoint.changecheckedpoint(checkpointnumber);
			carrank.setRank(checkpointnumber, rank);
			carrank.reflectRank(checkpointnumber, rank);
			AudioSource.PlayClipAtPoint (checkedaudio, position);
		}
	}
}