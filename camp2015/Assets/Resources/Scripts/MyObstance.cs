using UnityEngine;
using System;

namespace UnitySampleAssets.Vehicles.Car  {

	[RequireComponent(typeof (MyLife))]
	[RequireComponent(typeof (MyItem))]
	[RequireComponent(typeof (MyChangeSpeed))]
	[RequireComponent(typeof (CheckPoint))]

	public class MyObstance : MonoBehaviour {

		private MyLife life;
		private MyItem item;
		private MyChangeSpeed changespeed;
		private CheckPoint checkpoint;

		private string[] obstancelist = new string[]{"Itembox", "Dashboard", "Dart", "Press", "Courseout"};
		private int pressnow = 0;

		[SerializeField] private GameObject targetBox;
		private GameObject[] targetArray;
		private Transform target;
		private bool coursereturnnow;


		void Awake() {
			life = GetComponent<MyLife>();
			item = GetComponent<MyItem>();
			changespeed = GetComponent<MyChangeSpeed>();
			checkpoint = GetComponent<CheckPoint>();

			targetArray = targetBox.GetChildren();
			coursereturnnow = false;
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
				case "Courseout" : 
					Coursereturn();
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

		public void Coursereturn() {
			if (!coursereturnnow) {
				coursereturnnow = true;
				int targetCount = 0;
				int targetNumber = 0;
				float distance =  Vector3.Distance(gameObject.transform.position, targetArray[targetCount].transform.position);
				while (targetCount < targetArray.Length-2) {
					targetCount++;
					if(distance > Vector3.Distance(gameObject.transform.position, targetArray[targetCount].transform.position)){
						distance = Vector3.Distance(gameObject.transform.position, targetArray[targetCount].transform.position);
						targetNumber = targetCount;
					}
					targetCount++;
				}
				transform.position = targetArray [targetNumber].transform.position + transform.up * 10;
				transform.LookAt(targetArray [targetNumber + 1].transform.position);
				rigidbody.velocity = Vector3.zero;
				Invoke ("Coursereturnend",3);
			}
		}

		public void Coursereturnend() {
			coursereturnnow = false;
		}
	}
}
