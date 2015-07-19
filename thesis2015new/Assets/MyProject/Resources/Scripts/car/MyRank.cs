using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyRank : MyCarCamera {

	private List<int> rank = new List<int> (){0, 0, 0, 0};

	public void setRank(int changepoint, int nowrank) {
		rank [changepoint] = nowrank;
	}

	public void reflectRank(int changepoint, int nowrank) {
		targetcamera.showNowRank (changepoint, nowrank);
	}
}
