using UnityEngine;
using UnityEngine.UI;

namespace UnitySampleAssets.Vehicles.Car  {

	[RequireComponent(typeof (MyLife))]
	[RequireComponent(typeof (MyItem))]
	public class MyCamera : MonoBehaviour {

		[SerializeField] public string CameraTarget  = "Cameras";

		private MyLife life;
		private MyItem item;

		private GameObject camerashow;

		private Text showlifepoint;
		private Text showitem;

		void Awake() {
			life = GetComponent<MyLife>();
			item = GetComponent<MyItem>();
			camerashow = GameObject.Find (CameraTarget).gameObject;
			showlifepoint = camerashow.FindDeep("PlayerLife").gameObject.GetComponent<Text>();
			showitem = camerashow.FindDeep("Item").gameObject.GetComponent<Text>();
		}

		public void ReflectLifePoint(int lifepoint) {
			if (life.CheckLife(lifepoint)) {
				showlifepoint.text  = new string ('*', lifepoint);
			}
			else {
				showlifepoint.text = "die";
			}
		}

		public void ReflectItem(int keepitem) {
			if (item.CheckKeepItem (keepitem)) {
				showitem.text  = keepitem.ToString();
			}
			else {
				showitem.text = "";
			}
		}

	}
}