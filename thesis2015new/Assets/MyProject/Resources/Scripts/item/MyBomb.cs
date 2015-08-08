using UnityEngine;
using System.Collections;

public class MyBomb : MyItem {
	
	protected override void collidedItemAction(GameObject collidedobject) {
		explodeCar(collidedobject);
	}
	
	protected override void destroyItem(GameObject collideobject) {
		collideobject.GetComponent<Detonator>().Explode();
	}

	private void explodeCar(GameObject collidedobject) {
		iTween.MoveTo(collidedobject, iTween.Hash("y", 20, "time", 1.5f));
		iTween.RotateTo(collidedobject, iTween.Hash("x", 1440, "time", 5.5f));
	}

	protected override void setItemAppearedPosition (Transform cartransform) {
		Transform gameobjecttransform = gameObject.transform;
		gameobjecttransform.position  = cartransform.position +  cartransform.up * 0.5f +  cartransform.forward * (-4);
	}
}