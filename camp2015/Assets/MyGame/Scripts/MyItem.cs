using UnityEngine;
using System.Collections;

namespace UnitySampleAssets.Vehicles.Car  {

	[RequireComponent(typeof (MyLife))]
	public class  MyItem : MonoBehaviour {


		private MyLife life;


		void Awake() {
			life = GetComponent<MyLife>();
		}


		public void ColliderItem (Collider collider) {
			switch (GetItemValue (collider.tag)) {
				case 1 :
					GetItem();
					break;
				case 2 :
					Destroy (collider.gameObject);
					HitBanana();
					break;
				case 3 :
					Destroy (collider.gameObject);
					HitBomb();
					break;
				default :
					break;
			}
		}

		public void CollisionItem (Collision collision) {
			switch (GetItemValue (collision.gameObject.tag)) {
			case 4 :
				Destroy (collider.gameObject);
				HitCarapace();
				break;
			default :
				break;
			}
		}

		
		int GetItemValue (string tag){
			switch (tag) {
			case "Itembox" : 
				return 1;
				break;
			case "Banana" : 
				return 2;
				break;
			case "Bomb" : 
				return 3;
				break;
			case "Carapace" : 
				return 4;
				break;
			default :
				return 0;
				break;
			}
		}
		
		
		string GetItemTag (int value){
			switch (value) {
			case 1 : 
				return "Itembox";
				break;
			case 2 : 
				return "Banana";
				break;
			case 3 : 
				return "Bomb";
				break;
			case 4 : 
				return "Carapace";
				break;
			default :
				return "";
				break;
			}
		}


		void GetItem() {

		}

		void StockItem() {
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