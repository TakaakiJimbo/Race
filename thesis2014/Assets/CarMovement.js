#pragma strict

private var spd:float = 0.05;

function Start () {

}

function Update () {

	if (Input.GetKey("right")) {
		transform.position.x += spd;
	}
	else if (Input.GetKey("left")) {
		transform.position.x -= spd;
	}
	
	
	if (Input.GetKey("up")) {
		transform.position.z += spd;
	}
	else if (Input.GetKey("down")) {
		transform.position.z -= spd;
	}
		
}