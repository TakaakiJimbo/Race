using UnityEngine;
using System.Collections;
using UnityEngine.UI;  

public class ResultScene : MonoBehaviour {

	// Use this for initialization
	void Start () {

		winP(ButtonA.playerNum);
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