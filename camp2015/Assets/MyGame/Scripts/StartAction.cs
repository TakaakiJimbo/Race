using UnityEngine;
using System.Collections;

public class StartAction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("DeleteCover", 3);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void DeleteCover(){
		Destroy (gameObject.transform.FindChild("StartCover").gameObject);
	}
}
