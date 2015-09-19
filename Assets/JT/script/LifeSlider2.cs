using UnityEngine;
using UnityEngine.UI;

public class LifeSlider2 :  MonoBehaviour {
	
	private int value;
	public static int CarLife2;
	
	void Start () {
		CarLife2 = 3;
		Slider slider = this.GetComponent <Slider> ();
		slider.onValueChanged.AddListener((value) => {
			CarLife2 = (int) value;
		});
	}
}