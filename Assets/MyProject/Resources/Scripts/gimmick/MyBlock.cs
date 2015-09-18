using UnityEngine;
using System.Collections;

public class MyBlock : MyGimmick {

	private Rigidbody blockrigid;
	private float     destroyVelocityLimit = 0.2f;

	protected override void AwakeGimmickAction(){
		blockrigid = gameObject.GetComponent<Rigidbody>();
	}

	protected override void collidedGimmickActionWithCar  (GameObject carobject){
		if(enableToDestroyItemByForce()) {
			gimmickflag = true;
			destroyBlock();
		}
	}

	protected override void collidedGimmickActionWithItem (GameObject itemobject){
		if(enableToDestroyItemByForce()) {
			gimmickflag = true;
			destroyBlock();
		}
	}

	protected void destroyBlock() {
		gameObject.GetComponent<Detonator>().Explode();
		iTween.ScaleTo(gameObject, iTween.Hash("x", 0, "y", 0, "z", 0, "time", 0.0f));
		gimmicksound.Play();
	}

	private bool enableToDestroyItemByForce() {
		Debug.Log(blockrigid.velocity.magnitude);
		return blockrigid.velocity.magnitude > destroyVelocityLimit;
	}
}