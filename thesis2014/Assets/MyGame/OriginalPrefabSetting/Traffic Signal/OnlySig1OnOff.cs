using System;
using UnityEngine;
using System.Collections;

public class OnlySig1OnOff : MonoBehaviour {
	private float nextTime;
	
	protected int change_color_time;    // cycle
	
	protected bool  signal_flag;    // move or stop
	protected int   signal_flag_a;  // move or stop
	protected int   signal_flag_b;  // move or stop
	
//	protected GameObject[] SignalParent = new GameObject[2];
//	protected GameObject[] OnlySignalParent = new GameObject[2];
	
//	protected GameObject[,] SignalParentColor = new GameObject[2,3];    // blue, yellow, red;
//	protected GameObject[,] walker_SignalParentColor = new GameObject[2,2]; // blue, red
	protected GameObject[,] walker_OnlySignalParentColor = new GameObject[2, 2];    // blue, red

	protected GameObject walker_signal_collider;
	protected Rigidbody walker_signal_collider_rigidbody;
	protected Vector3 walker_signal_collider_rigidbody_position_default;

	// Use this for initialization
	void Start ()
	{
		nextTime = Time.time;
		
		change_color_time = 5;
		
		signal_flag = true;
		
		//      SignalParent[0]                     = gameObject.transform.FindChild("Signal0Parent").gameObject;
		//      SignalParent[1]                     = gameObject.transform.FindChild("Signal1Parent").gameObject;
		//      OnlySignalParent[0]                 = gameObject.transform.FindChild("OnlySignal0Parent").gameObject;
		//      OnlySignalParent[1]                 = gameObject.transform.FindChild("OnlySignal1Parent").gameObject;
		//      SignalParentColor [0, 0]            = SignalParent[0].transform.FindChild("signal_blue").gameObject;
		//      SignalParentColor [0, 1]            = SignalParent[0].transform.FindChild("signal_yellow").gameObject;
		//      SignalParentColor [0, 2]            = SignalParent[0].transform.FindChild("signal_red").gameObject;
		//      SignalParentColor [1, 0]            = SignalParent[1].transform.FindChild("signal_blue").gameObject;
		//      SignalParentColor [1, 1]            = SignalParent[1].transform.FindChild("signal_yellow").gameObject;
		//      SignalParentColor [1, 2]            = SignalParent[1].transform.FindChild("signal_red").gameObject;
		//      walker_SignalParentColor [0, 0]     = SignalParent[0].transform.FindChild("walker_signal_blue").gameObject;
		//      walker_SignalParentColor [0, 1]     = SignalParent[0].transform.FindChild("walker_signal_red").gameObject;
		//      walker_SignalParentColor [1, 0]     = SignalParent[1].transform.FindChild("walker_signal_blue").gameObject;
		//      walker_SignalParentColor [1, 1]     = SignalParent[1].transform.FindChild("walker_signal_red").gameObject;
		//      walker_OnlySignalParentColor [0, 0] = OnlySignalParent[0].transform.FindChild("walker_signal_blue").gameObject;
		//      walker_OnlySignalParentColor [0, 1] = OnlySignalParent[0].transform.FindChild("walker_signal_red").gameObject;
		//      walker_OnlySignalParentColor [1, 0] = OnlySignalParent[1].transform.FindChild("walker_signal_blue").gameObject;
		//      walker_OnlySignalParentColor [1, 1] = OnlySignalParent[1].transform.FindChild("walker_signal_red").gameObject;
		walker_OnlySignalParentColor [1, 0] = gameObject.transform.FindChild("walker_signal_blue").gameObject;
		walker_OnlySignalParentColor [1, 1] = gameObject.transform.FindChild("walker_signal_red").gameObject;
	
		walker_signal_collider = gameObject.transform.FindChild("walker_signal_collider").gameObject;
		walker_signal_collider_rigidbody = walker_signal_collider.rigidbody;
		walker_signal_collider_rigidbody_position_default = walker_signal_collider_rigidbody.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ( Time.time > nextTime ) {
			signal_flag = !signal_flag;
			change_state();
			nextTime += change_color_time;
		}

		if (!signal_flag)
		{
			walker_signal_collider_rigidbody.rigidbody.WakeUp();
		}
	}
	
	void change_state()
	{
		signal_flag_a = Convert.ToInt32(signal_flag);
		signal_flag_b = Convert.ToInt32(!signal_flag);
		//      onoff (SignalParentColor [0, 0]            , signal_flag_a);
		//      onoff (SignalParentColor [0, 2]            , signal_flag_b);
		//      onoff (SignalParentColor [1, 0]            , signal_flag_b);
		//      onoff (SignalParentColor [1, 2]            , signal_flag_a);
		//      onoff (walker_SignalParentColor [0, 0]     , signal_flag_b);
		//      onoff (walker_SignalParentColor [0, 1]     , signal_flag_a);
		//      onoff (walker_SignalParentColor [1, 0]     , signal_flag_a);
		//      onoff (walker_SignalParentColor [1, 1]     , signal_flag_b);
		//      onoff (walker_OnlySignalParentColor [0, 0] , signal_flag_b);
		//      onoff (walker_OnlySignalParentColor [0, 1] , signal_flag_a);
		onoff (walker_OnlySignalParentColor [1, 0] , signal_flag_a);
		onoff (walker_OnlySignalParentColor [1, 1] , signal_flag_b);
		signal_flashing ();
		change_collider ();
	}
	
	void onoff(GameObject obj, int signal)
	{
		if (signal == 1)
		{
			obj.renderer.material.shader = Shader.Find( "Self-Illumin/VertexLit" );
		} else {
			obj.renderer.material.shader = Shader.Find( "Diffuse" );
		}
	}
	
	void signal_flashing()
	{
		//      if (signal_flag) {
		//          onoff (SignalParentColor [1, 1], 0);
		//          Invoke("middlesignal", change_color_time-2);
		//      } else {
		//          onoff (SignalParentColor [0, 1], 0);
		//          Invoke("middlesignal", change_color_time-2);
		//      }
	}
	
	void middlesignal()
	{
		//      if (signal_flag) {
		//          onoff (SignalParentColor [0, 0], 0);
		//          onoff (SignalParentColor [0, 1], 1);
		//      } else
		//      {
		//          onoff (SignalParentColor [1, 0], 0);
		//          onoff (SignalParentColor [1, 1], 1);
		//      }
	}

	void change_collider()
	{
		if (!signal_flag) {
			walker_signal_collider_rigidbody.transform.position = walker_signal_collider_rigidbody_position_default;
		} else {
			walker_signal_collider_rigidbody.transform.Translate(0, 10, 0);
		}
	}
}