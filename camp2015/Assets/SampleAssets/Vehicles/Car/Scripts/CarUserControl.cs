using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace UnitySampleAssets.Vehicles.Car
{
	[RequireComponent(typeof (MyItem))]
    [RequireComponent(typeof (CarController))]
	[RequireComponent(typeof (StartAction))]
	public class CarUserControl : MonoBehaviour
    {
        private CarController car; // the car controller we want to use
		private MyItem item;
		private StartAction startaction;

        private void Awake()
        {
            // get the car controller
            car = GetComponent<CarController>();
			item = GetComponent<MyItem>();
			startaction = GetComponent<StartAction>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
			bool spacedown = Input.GetKeyDown (KeyCode.Space); 
			car.Move(h, v);
			item.UseItem (spacedown);
        }
    }
}