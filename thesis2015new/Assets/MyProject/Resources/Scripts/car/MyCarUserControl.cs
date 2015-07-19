using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace UnitySampleAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
	[RequireComponent(typeof (MyKeepItem))]
	public class MyCarUserControl : MonoBehaviour
    {
        private CarController car; // the car controller we want to use
		private MyKeepItem keepitem;

        private void Awake()
        {
            // get the car controller
            car = GetComponent<CarController>();
			keepitem = GetComponent<MyKeepItem>();
        }

        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
			bool spacedown = Input.GetKeyDown (KeyCode.Space); 
            car.Move(h, v);
			keepitem.useItem (spacedown);
        }
    }
}