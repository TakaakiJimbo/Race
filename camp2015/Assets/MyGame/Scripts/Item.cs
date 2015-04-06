using UnityEngine;
using System.Collections;

namespace UnitySampleAssets.Vehicles.Car  {
	public class Item : MonoBehaviour {

		public int stockitem = 0;

		public void StockItem() {
			stockitem = Random.Range (4, 6);
		}

	}

}