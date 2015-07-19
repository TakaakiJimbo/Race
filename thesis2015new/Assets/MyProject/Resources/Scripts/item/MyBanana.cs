using UnityEngine;
using System.Collections;

public class MyBanana : MyItem {
	
	protected override void collidedItemAction(GameObject collidedObject) {
		iTween.RotateTo(collidedObject, iTween.Hash("y", 1080, "time", 2.0f));
	}
	
	protected override void setItemAppearedPosition (Transform carTransform) {
		gameObject.transform.position = carTransform.position +  carTransform.up * 1 +  gameObject.transform.forward * (-4);
	}
}