using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour {

	private AudioSource sound01;
	
	void Start () {
		sound01 = GetComponent<AudioSource>();
	}
	
	public void OnClick(){
		sound01.PlayOneShot(sound01.clip);
	}
}