#pragma strict

//private var spd:float = 0.05;

//function Update () {
//
//	if (Input.GetKey("right")) {
//		transform.position.x += spd;
//	}
//	else if (Input.GetKey("left")) {
//		transform.position.x -= spd;
//	}
//	
//	
//	if (Input.GetKey("up")) {
//		transform.position.z += spd;
//	}
//	else if (Input.GetKey("down")) {
//		transform.position.z -= spd;
//	}
//		
//}

private var forwardSpeed : float = 2;
private var turnSpeed : float = 0.2;
private var forwardMoveAmount : float  = 0.0;
private var turnAmount : float  = 0.0;
function Update () {
	if(Input.GetKey("up") && Mathf.Abs(forwardMoveAmount) < 3){
		forwardMoveAmount += (-1)*forwardSpeed;	//because of returning car	
	}
	if(Mathf.Abs(turnAmount) < 0.5){
		turnAmount += Input.GetAxis("Horizontal")*turnSpeed;
	}
	
	if(Input.GetKey("down")){
		forwardMoveAmount = forwardMoveAmount * 0.2;	//because of returning car
		if(forwardMoveAmount < 4){
			forwardMoveAmount = 0;
			turnAmount = 0;
		}
	}
	
	transform.Rotate(0,turnAmount,0);

	transform.Rotate(0,turnAmount,0);

	rigidbody.AddRelativeForce(0,0,forwardMoveAmount);
}