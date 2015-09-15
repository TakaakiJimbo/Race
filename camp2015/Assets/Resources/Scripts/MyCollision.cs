using UnityEngine;

namespace UnitySampleAssets.Vehicles.Car  {

	[RequireComponent(typeof (CarController))]
	[RequireComponent(typeof (MyItem))]
	[RequireComponent(typeof (MyObstance))]
	public class MyCollision : MonoBehaviour {

		private CarController carcontroller;
		private MyItem        item;
		private MyObstance    obstance ;


		void Awake() {
			carcontroller = GetComponent<CarController>();
			item = GetComponent<MyItem>();
			obstance = GetComponent<MyObstance>();
		}


		void OnTriggerEnter(Collider other) {
			obstance.ColliderObstance (other);
		}

		void OnCollisionEnter(Collision other) {
			item.CollisionItem (other);
		}

		void OnTriggerStay(Collider other) {
			obstance.ColliderObstance (other);
		}


		void OnTriggerExit(Collider other) {
			obstance.ColliderObstance (other);
		}

	}
}