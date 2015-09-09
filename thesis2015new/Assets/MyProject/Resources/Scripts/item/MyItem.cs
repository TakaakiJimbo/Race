using UnityEngine;
using System.Collections;

public abstract class MyItem : MonoBehaviour {

	[SerializeField] private int       damagecarvalue = 0;
	[SerializeField] private AudioClip setitemsound;
	[SerializeField] private AudioClip hititemsound;

	protected abstract void collidedItemAction (GameObject collidedobject);
	protected abstract void setItemAppearedPosition (Transform cartransform); 

	void OnEnable() {
		GetComponent<AudioSource>().PlayOneShot(setitemsound);
	}

	// layer 8 is "Car"
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.layer == 8) {
			GameObject carobject = other.gameObject;
			AudioSource.PlayClipAtPoint(hititemsound, carobject.transform.position);
			collidedItemAction(carobject);
			damageCarByItem(carobject.GetComponent<MyCarLifePoint> ());
			destroyItem();
		}
	}
	
	protected void damageCarByItem(MyCarLifePoint carlifepoint) {
		carlifepoint.changeLifePoint(damagecarvalue);
	}
	
	protected virtual void destroyItem() {
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