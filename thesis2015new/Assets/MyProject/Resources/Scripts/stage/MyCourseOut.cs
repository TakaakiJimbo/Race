using UnityEngine;
using System.Collections;

public class MyCourseOut : MonoBehaviour {

	[SerializeField] private AudioClip returnsound;

	void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag.IndexOf ("Player") >= 0) {
			GameObject carobject = other.transform.root.gameObject;
			returnCourse(carobject);
		}
	}

	private void returnCourse(GameObject carobject) {
		MyWayPoint mywaypoint = carobject.FindDeep ("TriggerWayPoint").GetComponent<MyWayPoint> ();
		int gonumber = mywaypoint.getNowPointNumber ();
		Vector3 goposition = GameObject.Find ("Route").GetComponent<MyRoute> ().getPointNumberPosition (gonumber);
		Vector3 lookdirection = GameObject.Find ("Route").GetComponent<MyRoute> ().getPointNumberDirection (gonumber);
		backPoint (mywaypoint, carobject, goposition, lookdirection);
	}

	private void setPointPosition(GameObject carobject, Vector3 pointposition, Vector3 lookdirection) {
		carobject.rigidbody.velocity = Vector3.zero;
		carobject.transform.position = pointposition + Vector3.up;
		carobject.transform.rotation = Quaternion.Euler(lookdirection);
	}

	public IEnumerator startReracing (float delay, MyWayPoint mywaypoint, GameObject carobject, Vector3 pointposition, Vector3 lookdirection) {
		yield return new WaitForSeconds(delay);
		mywaypoint.startFadeOut ();
		setPointPosition (carobject, pointposition, lookdirection);
	}

	private void backPoint (MyWayPoint mywaypoint, GameObject carobject, Vector3 pointposition, Vector3 lookdirection) {
		audio.Play ();
		mywaypoint.startFadeIn ();
		StartCoroutine(startReracing(1.0f, mywaypoint, carobject, pointposition, lookdirection));
	}
}