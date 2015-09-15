using UnityEngine;
using UnityEngine.UI;

namespace UnitySampleAssets.Vehicles.Car  {

	[RequireComponent(typeof (MyLife))]
	[RequireComponent(typeof (MyItem))]
	[RequireComponent(typeof (MyAI))]
	public class MyCamera : MonoBehaviour {

		[SerializeField] public string CameraTarget  = "Cameras";

		private MyLife life;
		private MyItem item;
		private MyAI   ai;

		private GameObject camerashow;

		private Text showlifepoint;
		private RawImage showitem;
		private Text showrank;
		private Text showtime;

		void Awake() {
			life = GetComponent<MyLife>();
			item = GetComponent<MyItem>();
			ai   = GetComponent<MyAI>();
			camerashow = GameObject.Find (CameraTarget).gameObject;
			showlifepoint = camerashow.FindDeep("PlayerLife").gameObject.GetComponent<Text>();
			showitem = camerashow.FindDeep("Item").gameObject.GetComponent<RawImage>();
			showrank = camerashow.FindDeep("RankNumber").gameObject.GetComponent<Text>();
			showtime = camerashow.FindDeep("TimeCount").gameObject.GetComponent<Text>();

		}


		public void ReflectLifePoint(string lifepoint) {
			if (!ai.isAI (gameObject.tag)) {
				showlifepoint.text  = lifepoint;
			}
		}


		public void ReflectItem(int keepitem, string keepitemdetail) {
			if (!ai.isAI (gameObject.tag)) {			
				if (item.CheckKeepItem (keepitem)) {
					showitem .enabled = true;
					showitem.texture  = Resources.Load<Texture>("Materials/Items/" + keepitemdetail);
				}
				else {
					showitem.enabled = false;
				}
			}
		}

		public void ReflectRank(string rank, bool finish) {
			if (!ai.isAI (gameObject.tag)) {
				camerashow.FindDeep ("Rank").gameObject.GetComponent<Text> ().enabled = true;
				showrank.text  = rank;
				if(!finish) {
					Invoke("HideRank", 3);
				}
			}
		}

		void HideRank() {
			camerashow.FindDeep ("Rank").gameObject.GetComponent<Text> ().enabled = false;
			showrank.text = "";
		}


		public void ReflectTime(string timecount) {
			if (!ai.isAI (gameObject.tag)) {
				showtime.text  = timecount;
			}
		}
	}
}