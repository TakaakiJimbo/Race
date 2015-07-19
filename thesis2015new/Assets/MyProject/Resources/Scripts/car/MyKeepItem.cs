using UnityEngine;
using System.Collections;

public class MyKeepItem : MyCarCamera {

	[SerializeField]  private string keepitem = "";

	protected override void initialize () {
		reflectItem ();
	}

	private void appearItem(string keepitem) {
		GameObject itementity = Instantiate(Resources.Load("Prefabs/" + keepitem )) as GameObject;
		itementity.name = keepitem;
		itementity.SendMessage("setItemAppearedPlace" , gameObject.transform);
	}

	private void emptyItem(){
		keepitem = "";
	}

	private bool haveItem() {
		if (keepitem != "") {
			return true;
		}
		return false;
	}

	private void reflectItem() {
		targetcamera.showItem (keepitem);
	}

	public void setItem(string item) {
		if(!haveItem()){
			keepitem = item;
			reflectItem();
		}
	}

	public void useItem(bool spacedown){
		if (haveItem () && spacedown) {
			appearItem(keepitem);
			emptyItem();
			reflectItem();
		}
	}
}