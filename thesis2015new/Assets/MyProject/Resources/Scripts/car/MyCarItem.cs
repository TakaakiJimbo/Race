using UnityEngine;
using System.Collections;

public class MyCarItem : MyCar {

	[SerializeField] private string item = "";

	void Start() {
		reflectItem ();
	}

	private void appearItem() {
		GameObject itementity = Instantiate(Resources.Load("Prefabs/" + item )) as GameObject;
		itementity.name       = item;
		itementity.SendMessage("setItemAppearedPosition" , gameObject.transform);	// item function
	}

	private void emptyItem(){
		item = "";
	}

	public void getItem(string getitem) {
		if(!haveItem()){
			setItem(getitem);
			reflectItem();
		}
	}

	private bool haveItem() {
		return item != "";
	}

	private void reflectItem() {
		targetcamera.showItem(item);
	}

	private void setItem(string getitem) {
		item = getitem;
	}

	public void useItem(bool spacedown){
		if (haveItem() && spacedown) {
			appearItem();
			emptyItem();
			reflectItem();
		}
	}
}