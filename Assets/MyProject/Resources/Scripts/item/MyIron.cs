using UnityEngine;
using System;
using System.Collections;

public class  MyIron : MyItem {
	
	protected float movePower = 100f;
		
	protected override void collidedItemAction(GameObject collidedobject) {
		explodeCar(collidedobject);
	}

	protected override void destroyItem() {
		gameObject.GetComponent<Detonator>().Explode();
		iTween.ScaleTo(gameObject, iTween.Hash("x", 0, "y", 0, "z", 0, "time", 0.0f));
		itemsounds[0].Play();
	}
	
	protected void explodeCar(GameObject collidedobject) {
		iTween.MoveTo(collidedobject, iTween.Hash("y", 20, "time", 0.75f));
		iTween.RotateTo(collidedobject, iTween.Hash("x", 1080 , "y", 1080, "z", 1080, "time", 2.5f));
	}
	
	protected void initializeIron(Transform cartransform) {
		gameObject.GetComponent<Rigidbody>().velocity = cartransform.forward * movePower;
	}

	protected override void setItemAppearedPosition (Transform cartransform) {
		gameObject.transform.position = cartransform.position +  cartransform.up  * 0.5f +  cartransform.forward * 4;
		initializeIron(cartransform);
		itemsounds[1].Play(); // set
		Invoke("destroyItem", 2);
	}
}
