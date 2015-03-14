using UnityEngine;
using System.Collections;

public class Dashboard : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Car 
	void OnTriggerEnter(Collider other)
	{
		CheckColliderTag(other);
	}

	void CheckColliderTag(Collider other)
	{
		Debug.Log (other.gameObject.tag);
	}

}
