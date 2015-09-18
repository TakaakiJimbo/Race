using UnityEngine;
using System.Collections;

public class MyBomb : MyItem {

	private Rigidbody bombvelocity;
	private float     destroyVelocityLimit = 2.5f;

	protected override void OnEnableItemAction() {
		bombvelocity = gameObject.GetComponent<Rigidbody>();
	}
	
	protected override void OnCollisionEnter(Collision other) {
		if(!touchflag) {
			if (other.gameObject.layer == 8) {
				touchflag = true;
				GameObject carobject = other.gameObject;
				collidedItemAction(carobject);
				damageCarByItem(carobject.GetComponent<MyCarLifePoint> ());
				itemsounds[0].Play();
				destroyItem();
			}
			else if(enableToDestroyItemByForce()) {
				touchflag = true;
				destroyItem();
			}
		}
	}
	
	protected override void collidedItemAction(GameObject collidedobject) {
		explodeCar(collidedobject);
	}
	
	protected override void destroyItem() {
		gameObject.GetComponent<Detonator>().Explode();
		iTween.ScaleTo(gameObject, iTween.Hash("x", 0, "y", 0, "z", 0, "time", 0.0f));
	}

	private bool enableToDestroyItemByForce() {
		Debug.Log("bomb:" + bombvelocity.velocity.magnitude);
		return bombvelocity.velocity.magnitude > destroyVelocityLimit;
	}

	private void explodeCar(GameObject collidedobject) {
		iTween.MoveTo(collidedobject, iTween.Hash("y", 50, "time", 1.5f));
		iTween.RotateTo(collidedobject, iTween.Hash("x", 1440, "time", 5.5f));
	}


	protected override void setItemAppearedPosition (Transform cartransform) {
		Transform gameobjecttransform = gameObject.transform;
		gameobjecttransform.position  = cartransform.position +  cartransform.up * 0.5f +  cartransform.forward * (-4);
		itemsounds[1].Play(); // set
	}
}