using UnityEngine;
using System;

namespace UnitySampleAssets.Vehicles.Car  {

	[RequireComponent(typeof (MyLife))]
	[RequireComponent(typeof (MyItem))]
	[RequireComponent(typeof (MyChangeSpeed))]
	public class MyObstance : MonoBehaviour {

		private MyLife life;
		private MyItem item;
		private MyChangeSpeed changespeed;

		private string[] obstancelist = new string[]{"Itembox", "Dashboard", "Dart", "Press"};
		private int pressnow = 0;



		void Awake() {
			life = GetComponent<MyLife>();
			item = GetComponent<MyItem>();
			changespeed = GetComponent<MyChangeSpeed>();
		}


		public void ColliderObstance (Collider collider) {
			switch (collider.tag) {
				case "Itembox" :
					item.GetItem();
					break;
				case "Dashboard" :
					RideDashboard();
					break;
				case "Dart" :
					RideDart();
					break;
				case "Press" :
					HitPress();
					break;
				default :
					break;	
			}
		}


		int GetObstanceValue (string tag){
			return  Array.FindIndex (obstancelist, t => t.IndexOf (tag, StringComparison.InvariantCultureIgnoreCase) >= 0);
		}
		
		
		string GetObstanceTag (int value){
			return obstancelist[value];
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
