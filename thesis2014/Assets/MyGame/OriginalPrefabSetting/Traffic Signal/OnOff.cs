using UnityEngine;
using System.Collections;

public class OnOff : MonoBehaviour {
	private float nextTime;
	public float change = 15f;	// 周期
	public bool state = true;	// true or false
	
	// Use this for initialization
	void Start ()
	{
		nextTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ( Time.time > nextTime ) {
			state = !state;
			change_state(state);
			nextTime += change;
		}
	}

	void change_state(bool state)
	{
		if (state) {
			Debug.Log ("aaa");
		} else {
			Debug.Log ("bbb");
		}
	}

	void walker_signal_blue()
	{
	
	}
	
	void walker_signal_blue_flashing()
	{
		
	}

	void walker_signal_red()
	{
		
	}

	void signal_blue()
	{

	}

	void signal_yellow()
	{
		
	}

	void signal_red()
	{
		
	}

}
