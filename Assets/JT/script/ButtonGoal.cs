using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonGoal : MonoBehaviour {

	float time = 0.0f;
	private AudioSource sound01;
	
	void Start () {
		sound01 = GetComponent<AudioSource>();
	}

	void Retry(){
		Application.LoadLevel ("Ready");
	}

	void BackTitle(){
		Application.LoadLevel ("Main");
	}

	public void OnClick (int number){
		
		switch (number) {
			
		case 0:
			sound01.PlayOneShot(sound01.clip);
			Invoke("Retry",0.5f);
			break;

		case 1:
			sound01.PlayOneShot(sound01.clip);
			Invoke("BackTitle",0.5f);
			break;

		default:
			break;
		}
		
	}
}