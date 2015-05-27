using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		iTween.ColorTo(gameObject,iTween.Hash("a",0,"looptype","pingpong","time",1f));
	}


}
