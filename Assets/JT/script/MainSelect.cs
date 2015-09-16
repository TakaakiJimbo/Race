using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class  MainSelect : MonoBehaviour
{
	float time = 0.0f;
	private AudioSource sound01;

	void Start () {
		sound01 = GetComponent<AudioSource>();
	}

	public void OnClick (){
		sound01.PlayOneShot(sound01.clip);
		Invoke("scene",0.5f);
	}

	void scene(){
		Application.LoadLevel("selectScene");
	}
}



	

	
	