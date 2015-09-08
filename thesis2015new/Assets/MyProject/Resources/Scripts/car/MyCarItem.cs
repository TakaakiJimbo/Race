using UnityEngine;
using System.Collections;

public class MyCarItem : MyCar {

	[SerializeField] private string item = "";
	private Transform subcamera;

	protected override void initialize() {
		subcamera = GameObject.Find (targetsubcameraname).gameObject.transform;
	}

	void Start() {
		reflectItem ();
	}

	private void appearItem(bool usemain, bool usesub) {
		GameObject itementity = Instantiate(Resources.Load("Prefabs/" + item )) as GameObject;
		itementity.name       = item;
		if(usemain) {
			itementity.SendMessage("setItemAppearedPosition" , gameObject.transform);	// item function
		}
		else {
			itementity.SendMessage("setItemAppearedPosition" , subcamera);	// item function
		}
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

	public void useItem(bool usemain, bool usesub){
		if (haveItem() && (usemain || usesub)) {
			appearItem(usemain, usesub);
			emptyItem();
			reflectItem();
		}
	}
}