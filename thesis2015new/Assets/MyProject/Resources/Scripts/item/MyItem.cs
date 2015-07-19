using UnityEngine;
using System.Collections;

[RequireComponent(typeof (MyLifePoint))]
public abstract class MyItem : MonoBehaviour {

	[SerializeField] private int damagecarvalue = 0;
	[SerializeField] private AudioClip setitemsound;
	[SerializeField] private AudioClip hititemsound;

	protected abstract void collidedItemAction (GameObject collidedObject);
	protected abstract void setItemAppearedPosition (Transform carTransform); 

	void OnEnable() {
		audio.PlayOneShot (setitemsound);
		onEnableAction ();
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag.IndexOf ("Player") >= 0) {
			GameObject carobject = other.transform.root.gameObject;
			AudioSource.PlayClipAtPoint (hititemsound, carobject.transform.position);
			collidedItemAction(carobject);
			damageCarByItem(carobject);
			destroyItemAction(gameObject);
		}
	}
	
	protected void damageCarByItem(GameObject collidedobject) {
		collidedobject.GetComponent<MyLifePoint> ().changeLifePoint (damagecarvalue);
	}
	
	protected virtual void destroyItemAction(GameObject collideobject) {
		Destroy(collideobject);
	}

	protected virtual void onEnableAction() {
	}

	protected void setItemAppearedPlace(Transform cartransform) {
		setItemAppearedRotation (cartransform);
		setItemAppearedPosition (cartransform);
	}

	protected void setItemAppearedRotation(Transform cartransform) {
		gameObject.transform.rotation = Quaternion.Euler(cartransform.eulerAngles.x, cartransform.eulerAngles.y, cartransform.eulerAngles.z);
	}
}