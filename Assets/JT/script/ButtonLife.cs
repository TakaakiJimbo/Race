	using UnityEngine;
	using System.Collections;
	using UnityEngine.UI;
	
	public class ButtonLife : MonoBehaviour {
		
	public static int LifeNum;
	
		public void OnClick(int number){
			
			switch (number) {
				
		case 1:
			LifeNum = 1;
			break;
				
		case 2:
			LifeNum = 2;
			break;
	
		case 3:
			LifeNum = 3;
			break;
		
		case 4:
			LifeNum = 4;
			break;
		
		case 5:
			LifeNum = 5;
			break;
			
			default:
				break;
			}
			
		}
	}