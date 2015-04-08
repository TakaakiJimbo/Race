using UnityEngine;
using UnityEngine.UI;
using System.Collections;


namespace UnitySampleAssets.Vehicles.Car  {

	[RequireComponent(typeof (MyLife))]
	[RequireComponent(typeof (MyChangeSpeed))]
	public class MyObstance : MonoBehaviour {

		private MyLife life;
		private MyChangeSpeed changespeed;
		private int pressnow = 0;


		void Awake() {
			life = GetComponent<MyLife>();
			changespeed = GetComponent<MyChangeSpeed>();
		}


		public void CollisionObstance (Collider collider) {
			switch (GetObstanceValue (collider.tag)) {
				case 1 :
					RideDashboard();
					break;
				case 2 :
					RideDart();
					break;
				case 3 :
					HitPress();
					break;
				default :
					break;	
			}
		}


		int GetObstanceValue (string tag){
			switch (tag) {
			case "Dashboard" : 
				return 1;
				break;
			case "Dart" : 
				return 2;
				break;
			case "Press" : 
				return 3;
				break;
			default :
				return 0;
				break;
			}
		}
		
		
		string GetObstanceTag (int value){
			switch (value) {
			case 1 : 
				return "Dashboard";
				break;
			case 2 : 
				return "Dart";
				break;
			case 3 : 
				return "Press";
				break;
			default :
				return "";
				break;
			}
		}

		void RideDashboard() {
			changespeed.ChangeMaxTorque(2f);
			changespeed.ChangeMinTorque(2f);
			Invoke("ResetTorque",1);
		}

		void ResetTorque() {
			changespeed.ResetTorque();
		}

		void RideDart() {
			changespeed.ChangeMaxSpeed(0.3f);
		}

		void HitPress() {
			iTween.ScaleTo(gameObject, iTween.Hash("y", 0.5, "time", 0.1f));
			PressDamage ();
			Invoke("ResetPress",3);
		}

		void PressDamage() {
			if (pressnow == 0) {
				pressnow = 1;
				life.ChangeLife(-1);
			}
		}

		void ResetPress() {
			iTween.ScaleTo(gameObject, iTween.Hash("y", 1, "time", 0.1f));
			pressnow = 0;
			changespeed.ResetMaxSpeed();
		}

	}
}
