using UnityEngine;
using UnityEngine.UI;

public class StartAction : MonoBehaviour {
	private  GameObject message;
	private  Text       messagevalue;
	private  GameObject howto;
	private  float      timer;
	private  bool       returnkeyflag;
	private  bool       returnkey;

	// Use this for initialization
	void Start () {
		message = GameObject.Find("Message").gameObject;
		messagevalue = message.GetComponent<Text>();
		howto = GameObject.Find("Howto").gameObject;
		timer = 3.0f;
		returnkey = false;
	}
	
	void Update () {
		returnkey = Input.GetKeyDown (KeyCode.Escape);
		if (returnkey) {
			returnkeyflag = true;
			Destroy(howto);
		}
		if (returnkeyflag) {
			timer -= Time.deltaTime;
			if (timer <= 0.0f)
			{
				messagevalue.text = "" ;
				Destroy(gameObject);
			}
			else if (timer <= 1.0f)
			{
				messagevalue.text = "1" ;
			}
			else if (timer <= 2.0f)
			{
				messagevalue.text = "2" ;
			}
		}
	}
}
