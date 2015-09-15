using UnityEngine;
using System.Collections;

public class  SelectReady : MonoBehaviour
{
	float time = 0.0f;
	private AudioSource sound01;
	
	void Start () {
		//AudioSourceコンポーネントを取得し、変数に格納
		sound01 = GetComponent<AudioSource>();
	}
	
	public void Ready(){
			sound01.PlayOneShot(sound01.clip);
			Invoke("scene",0.5f);
	}
	
	void scene(){
		Application.LoadLevel ("Ready");
	}
}
