using UnityEngine;
using System.Collections;

public class MyBomb : MyItem {
	
	protected override void collidedItemAction(GameObject collidedObject) {
		iTween.MoveTo(collidedObject, iTween.Hash("y", 20, "time", 1.5f));
		iTween.RotateTo(collidedObject, iTween.Hash("x", 1440, "time", 5.5f));
	}

	protected override void destroyItemAction(GameObject collideObject) {
		collideObject.GetComponent<Detonator>().Explode();
	}

	protected override void setItemAppearedPosition (Transform carTransform) {
		gameObject.transform.position = carTransform.position +  carTransform.up * 1 +  gameObject.transform.forward * (-4);
	}
}