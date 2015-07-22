using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MyCamera : MonoBehaviour {

	private Text timecounter;
	private Text lifepoint;
	private Text progression;
	private RawImage keepitem;
	private RawImage reverse;
	private RawImage rank;
	private RawImage startcount;
	private RawImage result;

	private bool  resultflag;
	private Color fadeincolor = new Color(0,0,0,1);	
	private Color fadeoutolor = new Color(0,0,0,0);
	private Color diedcolor   = new Color(0,0,0,0.3f);	

	// Use this for initialization
	void Awake () {
		timecounter = gameObject.FindDeep("TimeCounter").gameObject.GetComponent<Text>(); 
		lifepoint   = gameObject.FindDeep("LifePoint").gameObject.GetComponent<Text>();
		progression = gameObject.FindDeep("Progression").gameObject.GetComponent<Text>();
		keepitem    = gameObject.FindDeep("KeepItem").gameObject.GetComponent<RawImage>();
		reverse     = gameObject.FindDeep("Reverse").gameObject.GetComponent<RawImage>();
		rank        = gameObject.FindDeep("Rank").gameObject.GetComponent<RawImage>();
		startcount  = gameObject.FindDeep("StartCount").gameObject.GetComponent<RawImage>();
		result      = gameObject.FindDeep("Result").gameObject.GetComponent<RawImage>();
		enabledResult(false);
	}
	
	public void enabledCount(bool flag) {
		timecounter.enabled = flag;
	}
	
	public void enabledCountDown(bool flag) {
		startcount.enabled = flag ;
	}

	private void enabledRank(bool flag) {
		rank.enabled = flag;
	}

	private void enabledResult(bool flag) {
		resultflag     = flag;
		result.enabled = flag;
	}
	
	public void enabledReverse(bool flag) {
		reverse.enabled = flag;
	}
	
	private void fadeDied() {
		gameObject.FindDeep("Main Camera").GetComponent<CameraFade>().StartFade(diedcolor, 5);
	}
	
	public void fadeIn(){
		gameObject.FindDeep("Main Camera").GetComponent<CameraFade>().StartFade(fadeincolor, 1);
	}
	
	public void fadeOut(){
		gameObject.FindDeep("Main Camera").GetComponent<CameraFade>().StartFade(fadeoutolor, 1);
	}

	public bool isResult() {
		return resultflag;
	}

	public void receiveGoal(int changepoint, int nowrank) {
		if(changepoint == 3) {
			enabledResult(true);
			if(nowrank == -1) {
				fadeDied();
				result.texture = Resources.Load<Texture> ("Materials/canvas/result/died");
			}
			else {
				result.texture = Resources.Load<Texture> ("Materials/canvas/result/finish");
			}
		}
	}

	public void showCountDown(int count) {
		startcount.texture = Resources.Load<Texture> ("Materials/canvas/count/" + count);
	}

	public void showItem(string item) {
		if (item == "") {
			keepitem.enabled = false;
		}
		else {
			keepitem.enabled = true;
			keepitem.texture = Resources.Load<Texture>("Materials/canvas/item/" + item);
		}
	}
	
	public void showLifePoint(int point) {
		if (point > 0) {
			lifepoint.text = new string ('♥', point);
		}
		else {
			lifepoint.text = "";
		}
	}

	public void showNowCount(int minutes, int seconds, int milliseconds) {
		if (!isResult()) {
			timecounter.text = minutes.ToString().PadLeft (2, '0') + ':' + seconds.ToString().PadLeft (2, '0') + ':' + milliseconds.ToString().PadLeft (3, '0');
		}
	}

	public void showNowRank(int changepoint, int nowrank) {
		StartCoroutine(showRank(0, true));
		if (nowrank > 0 && nowrank < 9) {
			rank.texture = Resources.Load<Texture> ("Materials/canvas/rank/" + nowrank);
		}
		else {
			rank.texture = Resources.Load<Texture> ("Materials/canvas/rank/over");
		}
		if (!isResult()) {
			StartCoroutine(showRank(1.0f, false));
		}
	}

	public void showProgression(int nowpositionnumber, int goalpositionnumber) {
		int nowprogression;
		if(!isResult()) {
			nowprogression = (int)((double)nowpositionnumber / (double)goalpositionnumber * 10);
		}
		else {
			nowprogression = 10;	// max value
		}
		progression.text = new string ('>', nowprogression);
	}

	public IEnumerator showRank(float delay, bool flag) {
		yield return new WaitForSeconds(delay);
		enabledRank(flag);
	}
}