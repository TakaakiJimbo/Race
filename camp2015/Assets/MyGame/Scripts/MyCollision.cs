using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UnitySampleAssets.Vehicles.Car  {
	public class MyCollision : MonoBehaviour {

		[SerializeField]private string lifeshowtarget;
		[SerializeField]private int    lifepoint;
		private GameObject lifeshow;
		private Text       lifeshowpoint;
		private float[]    initialization = new float[]{CarController.maxTorque, CarController.minTorque, CarController.maxSpeed};
		private int        pressnodamage  = 0;

		void Start() {
			lifeshow      = GameObject.Find (lifeshowtarget).gameObject;
			lifeshowpoint = lifeshow.FindDeep("PlayerLife").gameObject.GetComponent<Text>();
			lifeshowpoint.text = new string('*', lifepoint);
		}

		void OnTriggerEnter(Collider other) {
			switch (CheckColliderTag (other.gameObject.tag)) {
				case 1 :
					Dashboard();
					break;
				case 4 :
					Destroy (other.gameObject);
					BananaSlip();
					break;
				case 5 :
					Destroy (other.gameObject);
					BombFly();
					LifeChange(-1);
					break;
				case 6 :
					Press();
					LifeChange(-1);
					break;
				default :
					break;
			}
		}

		void OnCollisionEnter(Collision other) {
			switch (CheckColliderTag (other.gameObject.tag)) {
				case 7 :
					Destroy (other.gameObject);
					CarapaceCrash();
					LifeChange(-1);
					break;
				default :
					break;
			}
		}


		void OnTriggerStay(Collider other) {
			switch (CheckColliderTag (other.gameObject.tag)) {
				case 3 :
					Dart();
					break;
				default :
					break;
			}
		}


		void OnTriggerExit(Collider other) {
			switch (CheckColliderTag (other.gameObject.tag)) {
			case 3 :
				ResetMaxSpeed();
				break;
			default :
				break;
			}
		}


		int CheckColliderTag(string tag) {
			switch (tag) {
			case "Dashboard" : 
				return 1;
				break;
			case "Dart" : 
				return 3;
				break;
			case "Banana" : 
				return 4;
				break;
			case "Bomb" : 
				return 5;
				break;
			case "Press" : 
				return 6;
				break;
			case "Carapace" : 
				return 7;
				break;
			default :
				return 0;
				break;
			}
		}


		void Dashboard() {
			CarController.maxTorque = 1000;
			CarController.minTorque = 1000;
			Invoke("ResetTorque",1);
		}


		void Dart() {
			CarController.maxSpeed = initialization [2] / 3;
		}


		void BananaSlip() {
			iTween.RotateTo(gameObject, iTween.Hash("y", 1080, "time", 2.0f));
		}


		void BombFly() {
			iTween.MoveTo(gameObject, iTween.Hash("y", 20, "time", 1.5f));
			iTween.RotateTo(gameObject, iTween.Hash("x", 1440, "time", 5.5f));
		}


		void Press() {
			iTween.ScaleTo(gameObject, iTween.Hash("y", 0.5, "time", 0.1f));
			PressDamage ();
			Invoke("ResetPress",3);
		}

		void CarapaceCrash() {
			iTween.MoveTo(gameObject, iTween.Hash("y", 10, "time", 1.0f));
			iTween.RotateTo(gameObject, iTween.Hash("x", 1080 , "y", 1080, "z", 1080, "time", 2.5f));
		}

		void LifeChange(int point) {
			lifepoint += point;
			if (LifeCheck (lifepoint)) {
				lifeshowpoint.text = new string ('*', lifepoint);
			}
			else {
				lifeshowpoint.text = "die";
				lifepoint          = -2;
			}
		}

		bool LifeCheck(int lifepoint) {
			if (lifepoint > 0) {
				return true;
			}
			else {
				return false;
			}
		}

		void PressDamage() {
			if (pressnodamage == 0) {
				pressnodamage = 1;
			}
			else {
				lifepoint++;
			}
		}

		void ResetPress() {
			iTween.ScaleTo(gameObject, iTween.Hash("y", 1, "time", 0.1f));
			pressnodamage = 0;
			ResetMaxSpeed();
		}


		void ResetTorque() {
			CarController.maxTorque = initialization [0];
			CarController.minTorque = initialization [1];
		}


		void ResetMaxSpeed() {
			CarController.maxSpeed  = initialization [2];
		}
	}
}