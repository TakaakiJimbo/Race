using UnityEngine;
using System.Collections;

public class GoStagePractice : MonoBehaviour {
	public GameObject fadeManager;
	public bool aaa = true;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (aaa) {
			aaa = false;
			if (FadeManager.Instance == null)
				Instantiate(fadeManager);
			// シーン移行
			// Application.LoadLevel(NextSceneName);
			FadeManager.Instance.LoadLevel("stage01201411220000", 2f);
		}
	}
}
