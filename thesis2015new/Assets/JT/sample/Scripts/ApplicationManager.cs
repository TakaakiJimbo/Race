using UnityEngine;
using System.Collections;

public class ApplicationManager : MonoBehaviour {

	private AudioSource sound01;

	void Start () {
		sound01 = GetComponent<AudioSource>();
	}

	public void Quit () 
	{
		sound01.PlayOneShot (sound01.clip);
		Invoke ("scene", 0.5f);
	}

void scene()
	{
	Application.LoadLevel ("Main");
	}
}
