using UnityEngine;
using System.Collections;

public class Ready : MonoBehaviour 
{
	/*
	void Start () {
		static int courceNumber  = ButtonC.courceNum;	
		Debug.Log(courceNumber);
	}
*/

	public void courceP(int number){
		
		switch (number) {
			
		case 1:
			Application.LoadLevel ("Stage00");
			break;
			
		case 2:
			Application.LoadLevel ("Stage01");
			break;
			
			
		case 3:
			Application.LoadLevel ("Stage10");
			break;
			
		default:
			break;
		}
	}
	void FixedUpdate () 
	{
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space)) 
		{
			courceP(ButtonC.courceNum);
		}
	}
}

