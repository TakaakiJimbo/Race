using UnityEngine;
using System.Collections;

public class Ready : MonoBehaviour
{

	public AsyncOperation async0;
	
	IEnumerator Start(){
		// 非同期でロード開始
		switch(ButtonC.courceNum){
		case 1:
			async0 = Application.LoadLevelAsync("Stage00");
			async0.allowSceneActivation= false;
			yield return async0;
			break;

		case 2:
			async0 = Application.LoadLevelAsync("Stage01");
			async0.allowSceneActivation= false;
			yield return async0;
			break;

		case 3:
			async0 = Application.LoadLevelAsync("Stage10");
			async0.allowSceneActivation= false;
			yield return async0;
			break;

		default:
			break;
		}

	}
	/*
		public void courceP(int number){

		switch (number) {
			
		case 1:
			async.allowSceneActivation= true;
			//Application.LoadLevel ("Stage00");
			break;
			
		case 2:
			Application.LoadLevel ("Stage01");
			break;
			
			
		case 3:
			Application.LoadLevel ("Stage10");
			break;
			
		default:
			break;
		}
	}
	*/
	void FixedUpdate () 
	{
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space)) 
		{
			async0.allowSceneActivation= true;
		}
	}
}

