using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonB : MonoBehaviour {
	
	public static int modeNum = 0;

	public void OnClick(int number){

		switch (number) {
			
		case 0:
			modeNum = 0;
			Debug.Log("mode:" + modeNum);
			break;
			
		case 1:
			modeNum = 1;
			Debug.Log( "mode:" + modeNum);
			break;
			
		default:
			break;
		}
		
	}
}