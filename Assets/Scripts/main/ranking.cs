using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ranking : MonoBehaviour {
	// Use this for initialization
	void Start() {
		for(int i = 0;i < 10;i++) {
			this.GetComponent<Text>().text += PlayerPrefs.GetInt("Result" + (i + 1)) + "\n";
		}
	}
}