using UnityEngine;

namespace UnitySampleAssets.Vehicles.Car  {

	[RequireComponent(typeof (CarController))]
	public class MyChangeSpeed : MonoBehaviour {

		private CarController carcontroller;
		private float[]       initialization = new float[3];
		private float[]       initializationmax = new float[]{1000, 1000, 1000};

		void Awake() {
			carcontroller = GetComponent<CarController> ();
			initialization[0] = carcontroller.maxTorque;
			initialization[1] = carcontroller.minTorque;
			initialization[2] = carcontroller.maxSpeed;

		}

		public void ChangeMaxTorque(float maxtorque) {
			if(CheckMaxSpeed(carcontroller.maxTorque, initializationmax[0])){
				carcontroller.maxTorque = carcontroller.maxTorque * maxtorque;
			}
			else {
				carcontroller.maxTorque =  70;
			}
		}

		public void ChangeMinTorque(float mintorque) {
			if(CheckMaxSpeed(carcontroller.minTorque, initializationmax[1])){
				carcontroller.minTorque = carcontroller.minTorque * mintorque;
			}
			else {
				carcontroller.minTorque =  20;
			}
		}

		public void ChangeMaxSpeed(float maxspeed) {
			if(CheckMaxSpeed(carcontroller.maxSpeed, initializationmax[2])){
				carcontroller.maxSpeed = carcontroller.maxSpeed * maxspeed;
			}
			else {
				carcontroller.maxSpeed =  80;
			}
		}

		bool CheckMaxSpeed(float speed, float max) {
			if(speed < max) {
				return true;
			}
			return false;
		}

		public void ResetTorque() {
			carcontroller.maxTorque = initialization [0];
			carcontroller.minTorque = initialization [1];
		}

		public void ResetMaxSpeed() {
			carcontroller.maxSpeed  = initialization [2];
		}
	}

}