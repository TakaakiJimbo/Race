using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyCarRank : MyCar {

	private List<int>     rank = new List<int> (){0, 0, 0, 0};
	private MyRankControl rankcontrol;

	protected override void initialize() {
		rankcontrol = GameObject.Find("GameControl").GetComponent<MyRankControl>();
	}

	void Start() {
		StartCoroutine(targetcamera.showRank(0, false));
	}

	public int getCheckPoint() {
		for (int i = 1; i < rank.Count; i++){
			if(rank[i] == 0) {
				return i;
			}
		}
		return -1;
	}

	private void setRank(int changepoint, int nowrank) {
		rank [changepoint] = nowrank;
	}

	public void receiveRank(int changepoint, int nowrank) {
		if(changepoint == 3 && nowrank == -1) {	// for two player mode
			int player = int.Parse(gameObject.name.Substring(3)) - 1;
			player = Mathf.Abs(player);
			Debug.Log(player);
			GameObject.Find("Car"+player).GetComponent<MyCarRank>().receiveRank(1,1);
			GameObject.Find("Car"+player).GetComponent<MyCarRank>().receiveRank(2,1);
			GameObject.Find("Car"+player).GetComponent<MyCarRank>().receiveRank(3,1);
		}
		setRank(changepoint, nowrank);
		reflectRank(changepoint, nowrank);

	}

	private void reflectRank(int changepoint, int nowrank) {
		rankcontrol.setCarRank(identifier, changepoint, nowrank);
		targetcamera.receiveGoal(changepoint, nowrank);
		targetcamera.showNowRank(changepoint, nowrank);
	}
}