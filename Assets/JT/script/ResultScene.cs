using UnityEngine;
using System.Collections;
using UnityEngine.UI;  

public class ResultScene : MonoBehaviour {

	public static int PlayerNum;

	// Use this for initialization
	void Start () {
		winP(PlayerNum);
	}



public void winP(int number){
	
	switch (number) {
	case 0:
			this.GetComponent<Text>().text = "PLAYER 1・2 WIN!";
		break;
		
	case 1:
			this.GetComponent<Text>().text = "PLAYER 3・4 WIN!";
		break;
		
	default:
		break;
		}
	}

}