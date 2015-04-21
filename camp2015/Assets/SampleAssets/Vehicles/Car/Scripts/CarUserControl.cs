using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace UnitySampleAssets.Vehicles.Car
{
	[RequireComponent(typeof (MyItem))]
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController car; // the car controller we want to use
		private MyItem item;


        private void Awake()
        {
            // get the car controller
            car = GetComponent<CarController>();
			item = GetComponent<MyItem>();
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