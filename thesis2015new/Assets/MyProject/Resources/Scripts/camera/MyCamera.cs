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

	private bool isgoal = false;

	// Use this for initialization
	void Awake () {
		timecounter = gameObject.FindDeep("TimeCounter").gameObject.GetComponent<Text>(); 
		lifepoint   = gameObject.FindDeep("LifePoint").gameObject.GetComponent<Text>();
		progression = gameObject.FindDeep("Progression").gameObject.GetComponent<Text>();
		keepitem    = gameObject.FindDeep("KeepItem").gameObject.GetComponent<RawImage>();
		reverse     = gameObject.FindDeep("Reverse").gameObject.GetComponent<RawImage>();
		rank        = gameObject.FindDeep("Rank").gameObject.GetComponent<RawImage>();
		startcount  = gameObject.FindDeep("StartCount").gameObject.GetComponent<RawImage>();
	}
	
	private bool isGoal() {
		return isgoal;
	}

	public void setGoal() {
		isgoal = true ;
	}

	public void showLifePoint(int life) {
		if (life > 0) {
			lifepoint.text = new string ('♥', life);
		}
		else {
			lifepoint.text = "";
		}
	}

	public void showReverse(bool flag) {
		reverse.enabled = flag;
	}

	public void showCountDown(int count) {
		if (count > -1) {
			startcount.texture = Resources.Load<Texture> ("Materials/canvas/count/" + count);
		}
		else {
			startcount.enabled = false;
		}
	}

	public void showCount(bool flag) {
		timecounter.enabled = flag;
	}

	public void showNowCount(int minutes, int seconds, int milliseconds) {
		if (!isGoal ()) {
			timecounter.text = minutes.ToString().PadLeft (2, '0') + ':' + seconds.ToString().PadLeft (2, '0') + ':' + milliseconds.ToString().PadLeft (3, '0');
		}
	}

	public IEnumerator showRank(float delay, bool flag) {
		yield return new WaitForSeconds(delay);
		rank.enabled = flag;
	}

	public void showNowRank(int changepoint, int nowrank) {
		StartCoroutine(showRank(0, true));
		if (nowrank < 9) {
			rank.texture = Resources.Load<Texture> ("Materials/canvas/rank/" + nowrank);
		}
		else {
			rank.texture = Resources.Load<Texture> ("Materials/canvas/rank/over");
		}
		if (!isGoal()) {
			StartCoroutine(showRank(1.0f, false));
		}
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

	public void showProgression(int nowpositionnumber, int goalpositionnumber) {
		int nowprogression = (int)((double)nowpositionnumber / (double)goalpositionnumber * 10);
		progression.text = new string ('>', nowprogression);
	}
}