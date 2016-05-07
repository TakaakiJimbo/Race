using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MySolo : MyGameControl {

	List<List<int>> ranklist           = new List<List<int>> ();
	List<int> rankinitialization       = new List<int> (){0, 0, 0, 0};

	protected override void initialize() {
		for(int i = 0; i < number; i++) {
			ranklist.Add (rankinitialization);
		}
	}

	public void setCarRank(int identifier, int changepoint, int nowrank) {
		ranklist[identifier][changepoint] = nowrank;
		if (changepoint == 3 && ranklist[identifier][changepoint] == 1) {
			ResultScene.PlayerNum = identifier;
		}
	}
}