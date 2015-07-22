using UnityEngine;
using System.Collections;

public class MyBanana : MyItem {
	
	protected override void collidedItemAction(GameObject collidedobject) {
		slipCar(collidedobject);
	}
	
	protected override void setItemAppearedPosition(Transform cartransform) {
		Transform gameobjecttransform = gameObject.transform;
		gameobjecttransform.position = cartransform.position +  cartransform.up +  cartransform.forward * (-4);
	}

	private void slipCar(GameObject collidedobject) {
		iTween.RotateTo(collidedobject, iTween.Hash("y", 1080, "time", 2.0f));
	}
}