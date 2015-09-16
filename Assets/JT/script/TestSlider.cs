using UnityEngine;
using UnityEngine.UI;

public class TestSlider :  MonoBehaviour {

	private int value;

	void Start () {
		MyCarLifePoint.lifepoint = 3;
		Slider slider = this.GetComponent <Slider> ();
		slider.onValueChanged.AddListener((value) => {
		MyCarLifePoint.lifepoint = (int) value;
		});
	}
}