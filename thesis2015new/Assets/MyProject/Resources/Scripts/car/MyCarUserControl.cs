using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
	[RequireComponent(typeof (MyCarItem))]
	public class MyCarUserControl : MyCar{

        private CarController car; // the car controller we want to use
		private MyCarItem     item;
		private MyCarRecover  recovery;  

		protected override void initialize() {
            car       = gameObject.GetComponent<CarController>();
			item      = gameObject.GetComponent<MyCarItem>();
			recovery  = gameObject.GetComponent<MyCarRecover>();
        }

        private void FixedUpdate() {
			float h        = CrossPlatformInputManager.GetAxis("Horizontal"+identifier);
			float v        = CrossPlatformInputManager.GetAxis("Vertical"+identifier);
			bool  usemain  = CrossPlatformInputManager.GetButtonDown("UseitemByMain"+identifier); 
			bool  usesub   = CrossPlatformInputManager.GetButtonDown("UseitemBySub"+identifier); 
			bool  recover  = CrossPlatformInputManager.GetButtonUp("Recover"+identifier);
			float subh     = CrossPlatformInputManager.GetAxis("SubHorizontal"+identifier);
			float subv     = CrossPlatformInputManager.GetAxis("SubVertical"+identifier);
			car.Move(h, v, v, 0f);
			item.useItem(usemain, usesub);
			recovery.recoverStage(recover);
			targetsubcamera.moveSubCamera(gameObject.transform.position);
			targetsubcamera.rotateSubCamera(subh, subv);
        }
    }
}