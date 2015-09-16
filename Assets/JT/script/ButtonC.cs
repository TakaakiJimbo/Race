using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonC : MonoBehaviour {
	
	public static int courceNum = 0;
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
			
		case 1:
			courceNum = 1;
			Debug.Log( "cource:" + courceNum);
			Ready();
			break;

		case 2:
			courceNum = 2;
			Debug.Log("cource:" + courceNum);
			Ready();
			break;
			
		case 3:
			courceNum = 3;
			Debug.Log("cource:" + courceNum);
			Ready();
			break;

		default:
			break;
		}
		
	}
}