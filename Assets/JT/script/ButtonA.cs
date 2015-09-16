using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonA : MonoBehaviour {
	
	public static int playerNum = 0;
	float time = 0.0f;

	

	public void OnClick(int number){
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