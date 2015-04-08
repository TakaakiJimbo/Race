using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UnitySampleAssets.Vehicles.Car  {

	[RequireComponent(typeof (MyLife))]
	public class MyCamera : MonoBehaviour {

		[SerializeField] public string CameraTarget  = "Cameras";

		private MyLife life;

		private GameObject camerashow;

		private Text showlifepoint;

		void Awake() {
			life = GetComponent<MyLife>();
			camerashow = GameObject.Find (CameraTarget).gameObject;
			showlifepoint = camerashow.FindDeep("PlayerLife").gameObject.GetComponent<Text>();
		}

		public void ReflectLifePoint(int lifepoint) {
			if (life.CheckLife(lifepoint)) {
				showlifepoint.text  = new string ('*', lifepoint);
			}
			else {
				showlifepoint.text = "die";
			}
		}

	}
}