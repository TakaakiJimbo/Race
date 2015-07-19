using UnityEngine;
using System.Collections;

public class MyWayPoint : MyCarCamera {

	private int nowpointnumber = -1;
	private int beforepointnumber = -1;
	private int maxpointnumber;
	private MyRoute myroute;
	[SerializeField] private AudioClip reverseaudio;

	private Color fadeincolor = new Color(0,0,0,1);	
	private Color fadeoutolor = new Color(0,0,0,0);	

	protected override void initialize() {
		myroute = GameObject.Find ("Route").GetComponent<MyRoute> ();
	}
	
	void Start() {
		maxpointnumber = myroute.getPointMaxNumber();
		reflectReverse(false);
		targetcamera.showProgression (0, maxpointnumber);
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "WayPoint") {
			nowpointnumber = other.gameObject.GetComponent<MyPoint>().getPointNumber();
			warnReverseRun();
			reflectNowPointPosition();
		}
	}

	private bool checkReverseRun(int pointnumber) {
		if (pointnumber < beforepointnumber) {
			return true;
		}
		return false;
	}

	public int getNowPointNumber() {
		return nowpointnumber;
	}

	private void playReverseSound(bool  flag) {
		if (flag) {
			audio.Play();
		}
	}

	private void reflectReverse(bool flag) {
		targetcamera.showReverse (flag);
	}

	private void reflectNowPointPosition() {
		targetcamera.showProgression (nowpointnumber, maxpointnumber);
	}

	public void startFadeIn(){
		targetcamera.FindDeep("Main Camera").GetComponent<CameraFade>().StartFade(fadeincolor, 1);
	}
	
	public void startFadeOut(){
		targetcamera.FindDeep("Main Camera").GetComponent<CameraFade>().StartFade(fadeoutolor, 1);
	}

	private void warnReverseRun(){
		if (checkReverseRun (nowpointnumber)) {
			reflectReverse (true);
			playReverseSound(true);
		}
		else {
			reflectReverse (false);
			playReverseSound(false);
		}
		beforepointnumber = nowpointnumber;
	}
}