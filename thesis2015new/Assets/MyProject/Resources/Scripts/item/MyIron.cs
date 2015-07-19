using UnityEngine;
using System;

public class  MyIron : MyItem {
	
	private float movePower = 100f;
		
	protected override void collidedItemAction(GameObject collidedObject) {
		iTween.MoveTo(collidedObject, iTween.Hash("y", 20, "time", 0.75f));
		iTween.RotateTo(collidedObject, iTween.Hash("x", 1080 , "y", 1080, "z", 1080, "time", 2.5f));
	}

	protected override void destroyItemAction(GameObject collideObject) {
		collideObject.GetComponent<Detonator>().Explode();
	}

	private void initializeIron() {
		gameObject.rigidbody.velocity = gameObject.transform.forward * movePower;
	}

	protected override void onEnableAction() {
		Invoke ("initializeIron", 0.0001f);
	}

	protected override void setItemAppearedPosition (Transform carTransform) {
		gameObject.transform.position = carTransform.position +  carTransform.up  * 1 +  gameObject.transform.forward * 4;
	}
}
