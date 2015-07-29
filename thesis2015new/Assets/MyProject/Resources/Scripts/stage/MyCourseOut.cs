using UnityEngine;
using System.Collections;

public class MyCourseOut : MonoBehaviour {

	[SerializeField] private AudioClip returnsound;
	private MyRoute route;

	void Awake() {
		route = GameObject.Find ("Route").GetComponent<MyRoute> ();
	}

	void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag.IndexOf ("Player") >= 0) {
			GameObject carobject = other.transform.root.gameObject;
			returnCourse(carobject);
		}
		else if(other.gameObject.tag.IndexOf ("Item") >= 0) {
			Destroy(other.transform.root.gameObject);
		}
	}

	private void backPoint (MyCarPoint mycarpoint, GameObject carobject, Vector3 nowposition, Vector3 nextposition) {
		mycarpoint.fadeIn();
		audio.Play();
		StartCoroutine(startReracing(1.0f, mycarpoint, carobject, nowposition, nextposition));
	}

	private void returnCourse(GameObject carobject) {
		MyCarPoint   mycarpoint    = carobject.FindDeep("TriggerPoint").GetComponent<MyCarPoint> ();
		int          nownumber     = mycarpoint.getNowPointNumber ();
		Vector3      nowposition   = route.getPointNumberPosition (nownumber);
		Vector3      nextposition  = route.getNextPointNumberPosition(nownumber);
		backPoint(mycarpoint, carobject, nowposition, nextposition);
	}

	private void setPointPosition(GameObject carobject, Vector3 nowposition, Vector3 nextposition) {
		carobject.rigidbody.velocity = Vector3.zero;
		carobject.transform.position = nowposition + Vector3.up;
		carobject.transform.LookAt(nextposition);
	}

	public IEnumerator startReracing (float delay, MyCarPoint mycarpoint, GameObject carobject, Vector3 nowposition, Vector3 nextposition) {
		yield return new WaitForSeconds(delay);
		setPointPosition (carobject, nowposition, nextposition);
		mycarpoint.fadeOut();
	}
}