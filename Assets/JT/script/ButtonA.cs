using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonA : MonoBehaviour {
	
	public static int playerNum = 0;
	float time = 0.0f;
	private AudioSource sound01;

	void Start () {
		sound01 = GetComponent<AudioSource>();
	}

	public void OnClick(int number){
		sound01.PlayOneShot(sound01.clip);
		switch (number) {
			
		case 0:
			playerNum = 0;
			Debug.Log("player:" + playerNum);
			break;
		
		case 1:
			playerNum = 1;
			Debug.Log("player:" + playerNum);
			break;
		
		default:
			break;
		}
		
	}
}