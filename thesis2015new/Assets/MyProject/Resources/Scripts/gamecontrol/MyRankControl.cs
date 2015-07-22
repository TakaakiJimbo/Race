using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyRankControl : MyGameControl {

	List<List<int>> ranklist           = new List<List<int>> ();
	List<int> rankinitialization       = new List<int> (){0, 0, 0, 0};

	protected override void initialize() {
		for(int i = 0; i < number; i++) {
			ranklist.Add (rankinitialization);
		}
	}

	public void setCarRank(int identifier, int changepoint, int nowrank) {
		ranklist[identifier][changepoint] = nowrank;
	}
}