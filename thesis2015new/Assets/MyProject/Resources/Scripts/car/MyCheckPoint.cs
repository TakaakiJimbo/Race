using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyCheckPoint : MyCarCamera {

	[SerializeField] private List<bool> checkedpoint = new List<bool> (){true, false, false, false};


	private MyRank myrank;

	protected override void initialize () {
		myrank = gameObject.GetComponent<MyRank> ();
	}

	 void Start() {
		StartCoroutine(targetcamera.showRank(0, false));
	}

	public void changecheckedpoint(int changepoint) {
		checkedpoint[changepoint] = true;
		if (checkedpoint [3]) {
			targetcamera.setGoal();
		}
	}

	public int getcheckedpoint() {
		for (int i = 0; i < checkedpoint.Count; i++){
			if(!checkedpoint[i]) {
				return i;
			}
		}
		return -1;
	}
}