using UnityEngine;
using System;

namespace UnitySampleAssets.Vehicles.Car  {

	[RequireComponent(typeof (MyLife))]
	[RequireComponent(typeof (MyCamera))]
	public class  MyItem : MonoBehaviour {

		private MyLife life;
		private MyCamera camera;

		private string[] itemlist = new string[]{"Banana", "Bomb", "Carapace"};
		private int    keepitem = -1; // -1: false, 0-...: true

		void Awake() {
			life = GetComponent<MyLife>();
			camera = GetComponent<MyCamera>();
		}

		void Start() {
			camera.ReflectItem (keepitem);
		}


		public void CollisionItem (Collision collision) {
			switch (collision.gameObject.tag) {
				case "Banana" :
					Destroy (collision.gameObject);
					HitBanana();
					break;
				case "Bomb" :
					Destroy (collision.gameObject);
					HitBomb();
					break;
				case "Carapace" :
					Destroy (collision.gameObject);
					HitCarapace();
					break;
				default :
					break;
			}
		}

		
		int GetItemValue (string tag){
			return  Array.FindIndex (itemlist, t => t.IndexOf (tag, StringComparison.InvariantCultureIgnoreCase) >= 0);
		}
		
		
		string GetItemTag (int value){
			return itemlist[value];
		}


		public void GetItem() {
			if (!CheckKeepItem (keepitem)) {
				keepitem = UnityEngine.Random.Range (0, itemlist.Length);
				camera.ReflectItem(keepitem);
			}
		}

		public void UseItem(bool spacedown) {
			if (spacedown) {
				if (keepitem != -1) {
					UsedItem ();
				}
			}
		}

		void UsedItem() {
			if (GetItemTag (keepitem) != "Carapace") {
				PopItem (GetItemTag (keepitem), -3);
			}
			else {
				PopItem ("Carapace", 3);
			}
			keepitem = -1;
			camera.ReflectItem(keepitem);
		}

		void PopItem(string itemtag, int longvalue) {
			GameObject itementity = Instantiate(Resources.Load("Prefabs/" + itemtag )) as GameObject; 
			itementity.transform.rotation = Quaternion.Euler(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
			itementity.transform.position = gameObject.transform.position + itementity.transform.forward * longvalue;
		}

		public bool CheckKeepItem(int value) {
			if (keepitem > -1) {
				return true;
			}
			return false;
		}

		void HitBanana() {
			iTween.RotateTo(gameObject, iTween.Hash("y", 1080, "time", 2.0f));
		}
		
		void HitBomb() {
			iTween.MoveTo(gameObject, iTween.Hash("y", 20, "time", 1.5f));
			iTween.RotateTo(gameObject, iTween.Hash("x", 1440, "time", 5.5f));
			life.ChangeLife (-1);
		}

		void HitCarapace() {
			iTween.MoveTo(gameObject, iTween.Hash("y", 10, "time", 1.0f));
			iTween.RotateTo(gameObject, iTween.Hash("x", 1080 , "y", 1080, "z", 1080, "time", 2.5f));
			life.ChangeLife (-1);
		}

	}
}