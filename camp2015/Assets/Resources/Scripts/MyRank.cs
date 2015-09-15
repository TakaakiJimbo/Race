using UnityEngine;
using System.Collections;
using System;

namespace UnitySampleAssets.Vehicles.Car  {

	[RequireComponent(typeof (MyCamera))]
	public class MyRank : MonoBehaviour {
		public static int rankcheckpoint0 = 0;
		public static int rankcheckpoint1 = 0;
		public static int rankcheckpoint2 = 0;

		private float stopwatch;
		private bool swstart = false;
		private bool swend = false;

		public  bool flagrankcheckpoint0 = false;
		public  bool flagrankcheckpoint1 = false;
		public  bool flagrankcheckpoint2 = false;

		private MyCamera camera;

		void Awake() {
			camera = GetComponent<MyCamera>();
		}

		void Start() {
			camera.ReflectTime ("");
		}


		void Update() {
			if (!GameObject.Find ("StartPause") && !swstart) {
				swstart = true;
			}
			if (flagrankcheckpoint2 && !swend) {
				swend = true;

			}
			if (swstart && !swend) {
				stopwatch += Time.deltaTime;
//				camera.ReflectTime(new TimeSpan(0, 0, 0,  0, (int)(stopwatch * 1000.0f)).ToString());
				camera.ReflectTime(String.Format("{0:00}:{1:00}:{2:00}", Math.Floor(stopwatch / 60f), Math.Floor(stopwatch % 60f), stopwatch % 1 * 100));
			}
		}


		void OnTriggerStay(Collider other){
			switch (other.tag) {
				case "Checkpoint0" :
					AddRankCheckPoint0();
					break;
				case "Checkpoint1" : 
					AddRankCheckPoint1();
					break;
				case "Checkpoint2" : 
					AddRankCheckPoint2();
					EnableToGoAfterGoal(other);
					break;
				default : 
					break;
			}
		}

		void AddRankCheckPoint0() {
			if (!flagrankcheckpoint0) {
				flagrankcheckpoint0 = true;
				rankcheckpoint0++;
				camera.ReflectRank(string.Format("{0}", rankcheckpoint0), false);
			}
		}

		void AddRankCheckPoint1() {
			if (!flagrankcheckpoint1) {
				flagrankcheckpoint1 = true;
				rankcheckpoint1++;
				camera.ReflectRank(string.Format("{0}", rankcheckpoint1), false);
			}
		}

		void AddRankCheckPoint2() {
			if (!flagrankcheckpoint2) {
				if (flagrankcheckpoint0 && flagrankcheckpoint1) {
					flagrankcheckpoint2 = true;
					rankcheckpoint2++;
					camera.ReflectRank(string.Format("{0}", rankcheckpoint2), true);
				}
			}
		}

		void EnableToGoAfterGoal(Collider other) {
			if (rankcheckpoint2 == 1 && GameObject.Find("Stage").FindDeep("CheckpointStart")) {
				Destroy(GameObject.Find("Stage").FindDeep("CheckpointStart"));
			}
		}
	}
}
