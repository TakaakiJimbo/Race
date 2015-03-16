using UnityEngine;
using System.Collections;

namespace UnitySampleAssets.Vehicles.Car  {
	public class MyCollision : MonoBehaviour {


		private float[] initialization = new float[]{CarController.maxTorque, CarController.minTorque, CarController.maxSpeed};


		void Update() {
			transform.Rotate(new Vector3(0, 720, 0) * Time.deltaTime);
		}


		void OnTriggerEnter(Collider other) {
			switch (CheckColliderTag (other.gameObject.tag)) {
			case 1 :
				Dashboard();
				break;
			case 4 :
				Banana(other);
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


		void Banana(Collider other) {
			Destroy (other.gameObject);
			BananaRotate ();
		}

		void BananaRotate() {
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