using UnityEngine;

namespace UnitySampleAssets.Vehicles.Car  {

	[RequireComponent(typeof (MyCamera))]
	public class MyLife : MonoBehaviour {

		[SerializeField] public int lifepoint = 3;

		private MyCamera camera;

		void Awake(){
			camera = GetComponent<MyCamera> ();
		}

		void Start() {
			camera.ReflectLifePoint (new string ('♥',lifepoint));
		}

		public bool CheckLife(int lifepoint) {
			if (lifepoint > 0) {
				return true;
			}
			else {
				return false;
			}
		}

		public void ChangeLife(int point) {
			lifepoint += point;
			if (CheckLife (lifepoint)) {
				camera.ReflectLifePoint (new string ('♥', lifepoint));
			}
			else {
				camera.ReflectLifePoint ("die");
			}
		}

	}
}