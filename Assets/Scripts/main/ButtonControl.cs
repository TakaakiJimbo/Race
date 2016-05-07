using UnityEngine;
using System.Collections;

public class ButtonControl : MonoBehaviour {

	GameObject startButton;
	GameObject howToPlayButton;
//	GameObject rankingButton;
	GameObject intro;
//	GameObject rank;
	GameObject nowLoading;

	[SerializeField] private AudioClip sound;

	void Start() {
		startButton = transform.FindChild("START").gameObject;
		howToPlayButton = transform.FindChild("HowToPlay").gameObject;
		//rankingButton = transform.FindChild("Ranking").gameObject;
		intro = transform.FindChild("Intro").gameObject;
		//rank = transform.FindChild("Rank").gameObject;
		nowLoading = transform.FindChild("NowLoading").gameObject;
		intro.SetActive(false);
		nowLoading.SetActive(false);
	//	rank.SetActive(false);
	}

	public void clickStartButton() {
		GetComponent<AudioSource>().PlayOneShot(sound);
		startButton.SetActive(false);
		howToPlayButton.SetActive(false);
	//	rankingButton.SetActive(false);
		nowLoading.SetActive(true);
		StartCoroutine("LoadScene", "selectScene");
	}

	public void clickHowToPlayButton() {
		GetComponent<AudioSource>().PlayOneShot(sound);
		intro.SetActive(true);
	}

	public void clickRankingButton() {
		GetComponent<AudioSource>().PlayOneShot(sound);
	//	rank.SetActive(true);
	}

	public void clickIntro() {
		intro.SetActive(false);
	}

	public void clickRank() {
	//	rank.SetActive(false);
	}

	private IEnumerator LoadScene(string scene) {
		yield return new WaitForSeconds(0.5f);
		Application.LoadLevelAsync(scene);
	}
}
