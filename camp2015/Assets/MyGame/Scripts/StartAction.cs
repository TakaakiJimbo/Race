using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartAction : MonoBehaviour {
	public  GameObject startcount;
	private Text       startcountvalue;
	public  float      timer;

	// Use this for initialization
	void Start () {
		startcount = GameObject.Find("StartCount").gameObject;
		startcountvalue = startcount.GetComponent<Text>();
		timer = 3.0f;
	}
	
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0.0f)
		{
			Destroy(startcount);
			Destroy(gameObject);
		}
		else if (timer <= 1.0f)
		{
			startcountvalue.text = "1" ;
		}
		else if (timer <= 2.0f)
		{
			startcountvalue.text = "2" ;
		}
	}
	
}
