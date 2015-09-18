using UnityEngine;
using System.Collections;

public class MyCourseOut : MonoBehaviour {

	private MyRoute route;

	void Awake() {
		route = GameObject.Find ("Route").GetComponent<MyRoute> ();
	}

	// layer 8 is "Car"
	protected virtual void OnTriggerEnter (Collider other) {
		if (other.gameObject.layer == 8) {
			string     targetname = "/" + other.transform.root.gameObject.name + "/Car";
			GameObject carobject     = GameObject.Find(targetname);
			returnCourse(carobject);
		}
	}
	
	private void backPoint (MyCarPoint mycarpoint, GameObject carobject, Vector3 nowposition, Vector3 nextposition) {
		mycarpoint.fadeIn();
		carobject.GetComponents<AudioSource>()[1].Play();	// return
		StartCoroutine(startReracing(1.0f, mycarpoint, carobject, nowposition, nextposition));
	}

	public void returnCourse(GameObject carobject) {
		MyCarPoint   mycarpoint    = carobject.FindDeep("TriggerPoint").GetComponent<MyCarPoint> ();
		int          nownumber     = mycarpoint.getNowPointNumber ();
		Vector3      nowposition   = route.getPointNumberPosition (nownumber);
		Vector3      nextposition  = route.getNextPointNumberPosition(nownumber);
		backPoint(mycarpoint, carobject, nowposition, nextposition);
	}

	private void setPointPosition(GameObject carobject, Vector3 nowposition, Vector3 nextposition) {
		carobject.GetComponent<Rigidbody>().velocity = Vector3.zero;
		carobject.transform.position = nowposition + Vector3.up;
		carobject.transform.LookAt(nextposition);
	}

	public IEnumerator startReracing (float delay, MyCarPoint mycarpoint, GameObject carobject, Vector3 nowposition, Vector3 nextposition) {
		yield return new WaitForSeconds(delay);
		setPointPosition (carobject, nowposition, nextposition);
		mycarpoint.fadeOut();
	}
}