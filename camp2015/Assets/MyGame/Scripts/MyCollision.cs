using UnityEngine;
using System.Collections;

namespace UnitySampleAssets.Vehicles.Car  {
	public class MyCollision : MonoBehaviour {

		private float[] torque = new float[]{CarController.maxTorque, CarController.minTorque};

		// Car 
		void OnTriggerEnter(Collider other) {
			switch (CheckColliderTag (other.gameObject.tag)) {
			case 1 :
				Dashboard();
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

		void ResetTorque() {
			CarController.maxTorque = torque [0];
			CarController.minTorque = torque [1];
		}
	}
}