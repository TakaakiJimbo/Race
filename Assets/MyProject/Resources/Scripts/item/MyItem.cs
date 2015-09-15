using UnityEngine;
using System.Collections;

public abstract class MyItem : MonoBehaviour {

	[SerializeField] private int       damagecarvalue = 0;
	[SerializeField] private AudioClip setitemsound;
	[SerializeField] private AudioClip hititemsound;

	protected abstract void collidedItemAction (GameObject collidedobject);
	protected abstract void setItemAppearedPosition (Transform cartransform); 

	void OnEnable() {
		audio.PlayOneShot(setitemsound);
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag.IndexOf ("Player") >= 0) {
			GameObject carobject = other.transform.root.gameObject;
			AudioSource.PlayClipAtPoint(hititemsound, carobject.transform.position);
			collidedItemAction(carobject);
			damageCarByItem(carobject.GetComponent<MyCarLifePoint> ());
			destroyItem(gameObject);
		}
	}
	
	protected void damageCarByItem(MyCarLifePoint carlifepoint) {
		carlifepoint.changeLifePoint(damagecarvalue);
	}
	
	protected virtual void destroyItem(GameObject collideobject) {
		Destroy(collideobject);
	}
	
	protected void setItemAppearedPlace(Transform cartransform) {
		setItemAppearedRotation(cartransform);
		setItemAppearedPosition(cartransform);
	}

	protected void setItemAppearedRotation(Transform cartransform) {
		gameObject.transform.rotation = Quaternion.Euler(cartransform.eulerAngles.x, cartransform.eulerAngles.y, cartransform.eulerAngles.z);
	}
}