using UnityEngine;
using System.Collections;

public class Ready : MonoBehaviour
{
	public AsyncOperation async0;
	
	IEnumerator Start(){
		// 非同期でロード開始
		if (ButtonB.modeNum == 0) {
			switch (ButtonC.courceNum) {
			case 1:
				async0 = Application.LoadLevelAsync ("Stage00");
				async0.allowSceneActivation = false;
				yield return async0;
				break;

			case 2:
				async0 = Application.LoadLevelAsync ("Stage01");
				async0.allowSceneActivation = false;
				yield return async0;
				break;
	
			default:
				break;
			}
		}else{
			switch(ButtonC.courceNum){
			case 1:
				async0 = Application.LoadLevelAsync("Stage10");
				async0.allowSceneActivation= false;
				yield return async0;
				break;
			
			case 2:
				async0 = Application.LoadLevelAsync("Stage11");
				async0.allowSceneActivation= false;
				yield return async0;
				break;
			
			default:
				break;
			}
		}
	}

	public void game(){
		async0.allowSceneActivation = true;
	}

	void Update () 
	{
		//if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space)) 
		Invoke("game",2.0f);	

	}

}

