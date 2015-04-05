using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartAction : MonoBehaviour {
	private  GameObject message;
	private  Text       messagevalue;
	private  float      timer;

	// Use this for initialization
	void Start () {
		message = GameObject.Find("Message").gameObject;
		messagevalue = message.GetComponent<Text>();
		timer = 3.0f;
	}
	
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0.0f)
		{
			messagevalue.text = "" ;
			Destroy(gameObject);
		}
		else if (timer <= 1.0f)
		{
			messagevalue.text = "1" ;
		}
		else if (timer <= 2.0f)
		{
			messagevalue.text = "2" ;
		}
	}
	
}
