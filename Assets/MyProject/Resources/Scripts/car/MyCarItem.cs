using UnityEngine;
using System.Collections;

public class MyCarItem : MyCar {

	[SerializeField] private string item = "";
	[SerializeField] private int    subitem = 0;
	private Transform subcamera;
	private bool      shotsubitemflag = true;

	protected override void initialize() {
		subcamera = GameObject.Find (targetsubcameraname).gameObject.transform;
	}

	void Start() {
		reflectItem ();
	}

	private void appearItem() {
		GameObject itementity = Instantiate(Resources.Load("Prefabs/" + item )) as GameObject;
		itementity.SendMessage("setItemAppearedPosition" , gameObject.transform);	// item function
	}

	private void appearSubItem() {
		GameObject itementity = Instantiate(Resources.Load("Prefabs/subiron")) as GameObject;
		itementity.SendMessage("setItemAppearedPosition" , subcamera);	// item function
	}

	private void deleteSubItem() {
		subitem--;
	}

	private void emptyItem(){
		item = "";
	}

	private IEnumerator enableShotSubItem(float delay, bool flag) {
		yield return new WaitForSeconds(delay);
		shotsubitemflag = flag;
	}

	public void getItem(string getitem) {
		if(!haveItem()){
			setItem(getitem);
			reflectItem();
			reflectSubItem();
		}
	}

	private bool haveItem() {
		return item != "";
	}

	private bool haveSubItem() {
		return subitem > 0;
	}

	private void reflectItem() {
		targetcamera.showItem(item);
	}

	private void reflectSubItem() {
		targetsubcamera.showItem(subitem);
	}

	private void setItem(string getitem) {
		item     = getitem;
		subitem += 20;
	}

	public void useItem(bool usemain, bool usesub){
		if (haveItem() && usemain) {
			appearItem();
			emptyItem();
			reflectItem();
		}
		else if(haveSubItem() && usesub) {
			if(shotsubitemflag) {
				shotsubitemflag = false;
				appearSubItem();
				deleteSubItem();
				reflectSubItem();
				StartCoroutine(enableShotSubItem(0.5f, true));
			}
		}
	}
}