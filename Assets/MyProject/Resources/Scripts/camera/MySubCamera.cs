using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MySubCamera : MonoBehaviour {

	//キー入力で回転させる距離
	public float keyDistance;	
	private Transform subcameratransform;
	private Text subiron;

	void Awake() {
		subcameratransform = gameObject.transform;
		subiron            = gameObject.FindDeep("SubIron").gameObject.GetComponent<Text>();
	}

	public void moveSubCamera(Vector3 carposition) {
		subcameratransform.position = carposition + Vector3.up * 2;
	}

	public void rotateSubCamera(float subh, float subv) {
		gameObject.transform.Rotate ((subv * keyDistance ), (subh * keyDistance ),0 );
	}

	public void showItem(int subitem) {
		subiron.text = new string ('●', subitem);
	}
}