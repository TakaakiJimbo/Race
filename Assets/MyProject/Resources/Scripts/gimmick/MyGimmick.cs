using UnityEngine;
using System.Collections;

public abstract class MyGimmick : MonoBehaviour {

	[SerializeField] private int damagecarvalue = 0;
	
	protected AudioSource[] itemsounds;	// 0:hit, 1:set
	
	protected abstract void collidedItemAction (GameObject collidedobject);
	protected abstract void setItemAppearedPosition (Transform cartransform); 
	
	void OnEnable() {
		itemsounds = gameObject.GetComponents<AudioSource>();
	}
	
	// layer 8 is "Car"
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.layer == 8) {
			GameObject carobject = other.gameObject;
			collidedItemAction(carobject);
			damageCarByItem(carobject.GetComponent<MyCarLifePoint> ());
			itemsounds[0].Play();
			destroyItem();
		}
		else if(other.gameObject.tag == "Item") {
			destroyItem();
		}
	}
	
	protected void damageCarByItem(MyCarLifePoint carlifepoint) {
		carlifepoint.changeLifePoint(damagecarvalue);
	}
	
	protected virtual void destroyItem() {
		iTween.ScaleTo(gameObject, iTween.Hash("x", 0, "y", 0, "z", 0, "time", 0.0f));
		StartCoroutine(keepAndDestroyItem(1f));
	}
	
	protected IEnumerator keepAndDestroyItem(float delay) {
		yield return new WaitForSeconds (delay);
		Destroy(gameObject);
	}
	
	protected void setItemAppearedPlace(Transform cartransform) {
		setItemAppearedRotation(cartransform);
		setItemAppearedPosition(cartransform);
	}
	
	protected void setItemAppearedRotation(Transform cartransform) {
		gameObject.transform.rotation = Quaternion.Euler(cartransform.eulerAngles.x, cartransform.eulerAngles.y, cartransform.eulerAngles.z);
	}
}
