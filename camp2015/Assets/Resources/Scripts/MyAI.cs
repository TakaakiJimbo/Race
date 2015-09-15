using UnityEngine;
using System.Collections;

namespace UnitySampleAssets.Vehicles.Car  {

	public class MyAI : MonoBehaviour {
		
		public bool isAI(string tag) {
			if (tag == "AI") {
				return true;
			}
			return false;
		}
		
	}

}
