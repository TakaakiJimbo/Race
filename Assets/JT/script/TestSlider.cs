using UnityEngine;
using UnityEngine.UI;

public class TestSlider : MonoBehaviour {
	
	void Start () {
		Slider slider = this.GetComponent <Slider> ();
		slider.onValueChanged.AddListener((value) => {
			Debug.Log(value);
		});
	}
}