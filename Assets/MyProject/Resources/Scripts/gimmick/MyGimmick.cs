using UnityEngine;
using System.Collections;

public abstract class MyGimmick : MonoBehaviour {
	[SerializeField] private int damagecarvalue = 0;
	
	protected bool          gimmickflag = false;
	
	protected AudioSource   gimmicksound;
	
	protected abstract void AwakeGimmickAction();
	protected abstract void collidedGimmickActionWithCar  (GameObject carobject);
	protected abstract void collidedGimmickActionWithItem (GameObject itemobject);
	
	void Awake() {
		gimmicksound = gameObject.GetComponent<AudioSource>();
		AwakeGimmickAction();
	}
	
	// layer 8 is "Car"
	protected void OnCollisionEnter(Collision other) {
		if(!gimmickflag) {
			if (other.gameObject.layer == 8) {
				GameObject carobject = other.gameObject;
				collidedGimmickActionWithCar(carobject);
			}
			else if(other.gameObject.tag == "Item") {
				GameObject itemobject = other.gameObject;
				collidedGimmickActionWithItem(itemobject);
			}
		}
	}
}