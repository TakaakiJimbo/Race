using UnityEngine;
using UnityEngine.UI;

public class LifeSlider :  MonoBehaviour {

	private int value;
	public static int CarLife;

	void Start () {
		CarLife = 3;
		Slider slider = this.GetComponent <Slider> ();
		slider.onValueChanged.AddListener((value) => {
		CarLife = (int) value;
		});
	}
}