using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonB : MonoBehaviour {
	
	public static int modeNum = 0;
	private AudioSource sound01;
	
	void Start () {
		sound01 = GetComponent<AudioSource>();
	}
	
	public void OnClick(int number){
		sound01.PlayOneShot(sound01.clip);
		switch (number) {
			
		case 0:
			modeNum = 0;
			Debug.Log("mode:" + modeNum);
			break;
			
		case 1:
			modeNum = 1;
			Debug.Log( "mode:" + modeNum);
			break;
			
		default:
			break;
		}
		
	}
}