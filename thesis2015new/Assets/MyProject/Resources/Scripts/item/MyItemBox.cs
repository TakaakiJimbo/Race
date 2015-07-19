using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class MyItemBox : MyItem {

	private List<string> itemlist = new List<string> ();

	void Awake() {
		setItemList ();
	}

	void FixedUpdate() {
		gameObject.transform.Rotate(0, 4f, 0);	
	}
	
	protected override void collidedItemAction(GameObject collidedObject) {
		collidedObject.GetComponent<MyKeepItem> ().setItem (itemlist[UnityEngine.Random.Range(0, itemlist.Count)]);
	}
	
	private string cutStringCalledMy(Type type) {
		return (type.Name.Substring (2)).ToLower();
	}

	private bool isItemboxType(Type type) {
		return type == typeof(MyItemBox);
	}
	
	protected override void setItemAppearedPosition (Transform carTransform) {
	}

	private void setItemList() {
		Type targetType = typeof(MyItem);
		foreach (Type type in Assembly.GetExecutingAssembly().GetTypes()) {
			for (Type baseType = type.BaseType; baseType != null; baseType = baseType.BaseType) {
				if (baseType == targetType && !isItemboxType(type)) {
					itemlist.Add(cutStringCalledMy(type));
					break;
				}
			}
		}
	}
}
