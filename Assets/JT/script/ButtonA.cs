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

	public void Ready(){
		sound01.PlayOneShot(sound01.clip);
		Invoke("scene",0.5f);
	}

	void scene(){
		Application.LoadLevel ("Ready");
	}

	public void OnClick(int number){
		switch (number) {
			
		case 0:
			playerNum = 2;
			Ready ();
			Debug.Log("player:" + playerNum);
			break;
		
		case 1:
			playerNum = 4;
			Debug.Log("player:" + playerNum);
			break;
		
		default:
			break;
		}
		
	}
}