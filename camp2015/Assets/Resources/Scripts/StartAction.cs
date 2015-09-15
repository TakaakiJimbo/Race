using UnityEngine;
using UnityEngine.UI;

public class StartAction : MonoBehaviour {
	private  GameObject message;
	private  RawImage   messagevalue;
	private  GameObject howto;
	private  float      timer;
	private  bool       returnkeyflag;
	private  bool       returnkey;

	// Use this for initialization
	void Start () {
		message = GameObject.Find("Message").gameObject;
		messagevalue = message.GetComponent<RawImage>();
		howto = GameObject.Find("Howto").gameObject;
		timer = 3.5f;
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
			if (timer <= 0f)
			{
				Destroy(gameObject);
				messagevalue.enabled = false;
			}
			else if (timer <= 0.5f)
			{
				messagevalue.texture = Resources.Load<Texture>("Materials/Count/CountGo");
			}
			else if (timer <= 1.5f)
			{
				messagevalue.texture = Resources.Load<Texture>("Materials/Count/Count1");
			}
			else if (timer <= 2.5f)
			{
				messagevalue.texture = Resources.Load<Texture>("Materials/Count/Count2");
			}
		}
	}
}
