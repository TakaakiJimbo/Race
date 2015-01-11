#pragma strict
#pragma implicit
#pragma downcast
@script AddComponentMenu ("CarPhys/AIScripts/AICarScript")
var centerOfMass : Vector3; 
 
var path : Array;  
var pathGroup : Transform;  
var maxSteer : float = 15.0; 

var wheelFL : WheelCollider;   
var wheelFR : WheelCollider;  
var wheelRL : WheelCollider;   
var wheelRR : WheelCollider;  

var currentPathObj : int;  
var distFromPath : float = 20;  
var maxTorque : float = 50;  
var currentSpeed : float;  

var topSpeed : float = 150;  
var decellarationSpeed : float = 10;  

var temptopSpeed : float = 150;  
var tempdecellarationSpeed : float = 10;  
var temptimer : int = 0;
var tempRigidbodyPosition : Vector3;
var tempOtherRigidbodyPosition : Vector3;
		
var breakingMesh : Renderer;  
var idleBreakLight : Material;  
var activeBreakLight : Material;  
var isBreaking : boolean;  
var inSector : boolean;  
var isControll = false;
var gearRatio = new int[128];

function Start () {  
	rigidbody.centerOfMass = centerOfMass;

	temptopSpeed = topSpeed;
	tempdecellarationSpeed = decellarationSpeed;
	
	GetPath();  
}  
  
function GetPath (){  
	var path_objs : Array = pathGroup.GetComponentsInChildren(Transform);  
	path = new Array();  
	for (var path_obj : Transform in path_objs){  
	  path.Add(path_obj);  
	}  
}  
 
function EngineSound(){
	for (var i = 0; i < gearRatio.length; i++){
		if(gearRatio[i]> currentSpeed){
			break;
		}
	}
	var gearMinValue : float = 0.00;
	var gearMaxValue : float = 0.00;
	if (i == 0){
		gearMinValue = 0;
	}
	else {
		gearMinValue = gearRatio[i-1];
	}
	gearMaxValue = gearRatio[i];
	var enginePitch : float = ((currentSpeed - gearMinValue)/(gearMaxValue - gearMinValue))+1;
	audio.pitch = enginePitch;
}
      
function Update () {
	GetSteer(); 
	if(isControll){
		Move(); 
	}
	BreakingEffect ();  
	EngineSound();
	
	if(currentSpeed < 5){
		temptimer++;
//		Debug.Log( gameObject.name + " : " + temptimer);
	} else { 
		temptimer = 0;
	}
	if(temptimer > 150){
		ResetAI();
		temptimer = 0;
	}
	else if(temptimer > 135){
		topSpeed = temptopSpeed;
	}
} 

function ResetAI() {
	var Reset: Transform = path[currentPathObj-1]as Transform;
	var ResetLook: Transform = path[currentPathObj]as Transform;
	transform.position = Vector3(Reset.position.x,transform.position.y,Reset.position.z);
	transform.rotation = Quaternion.LookRotation(ResetLook.position-Reset.position);
	decellarationSpeed = tempdecellarationSpeed;
	topSpeed = temptopSpeed;
	currentSpeed = 10;
	wheelRL.motorTorque = maxTorque;  
	wheelRR.motorTorque = maxTorque;
	isBreaking = false;
}
 
function FixedUpdate () {
}  

function GetSteer(){  
	var inUse: Transform = path[currentPathObj]as Transform;

	var steerVector : Vector3 = transform.InverseTransformPoint(Vector3(inUse.position.x, inUse.position.y,inUse.position.z));
	var newSteer : float = maxSteer * (steerVector.x / steerVector.magnitude);  
	wheelFL.steerAngle = newSteer;  
	wheelFR.steerAngle = newSteer;  

	if (steerVector.magnitude <= distFromPath){  
		currentPathObj++;
	}  
	if (currentPathObj >= path.length ){  
		currentPathObj = 0; 
	}   
}  
  
function Move (){ 
	if (currentSpeed <= topSpeed && !inSector){  
		wheelRL.motorTorque = maxTorque;  
		wheelRR.motorTorque = maxTorque;  
		wheelRL.brakeTorque = 0;  
		wheelRR.brakeTorque = 0;  
	}  
	else if (!inSector){  
		wheelRL.motorTorque = 0;  
		wheelRR.motorTorque = 0;  
		wheelRL.brakeTorque = decellarationSpeed;
		wheelRR.brakeTorque = decellarationSpeed;  
	}  
	currentSpeed = 2*(22/7)*wheelRL.radius*wheelRL.rpm * 60 / 1000;   
	currentSpeed = Mathf.Round (currentSpeed); 
}  
  
function BreakingEffect (){  
	if (isBreaking){  
		breakingMesh.material = activeBreakLight;  
	}  
	else {  
		breakingMesh.material = idleBreakLight;  
	} 
} 

function OnTriggerEnter(other: Collider) {
	if(other.tag == "Player"){
		OnTriggerEnterSetSpeed();
	}else if(other.tag == "AI"){
		OnTriggerEnterSetSpeed();
	}else if(other.tag == "AIPeople_collider"){
		OnTriggerEnterSetSpeed();
	}else if(other.tag == "signal_collider"){
		OnTriggerEnterSetSpeed();
	}
}

function OnTriggerEnterSetSpeed() {
	topSpeed = 15;
	isBreaking = true;
	decellarationSpeed = 40;
}

function OnTriggerStay(other: Collider) {
	if(other.tag == "Player"){
		OnTriggerStaySetSpeed(other);
	}else if(other.tag == "AI"){
		OnTriggerStaySetSpeed(other);
	}else if(other.tag == "AIPeople_collider"){
		OnTriggerStaySetSpeed(other);
	}else if(other.tag == "signal_collider"){
		OnTriggerStaySetSpeed(other);
	}
}

function OnTriggerStaySetSpeed(other: Collider){
	tempRigidbodyPosition = rigidbody.position;
	tempOtherRigidbodyPosition = other.rigidbody.position;
	if(Vector3.Distance(tempRigidbodyPosition, tempOtherRigidbodyPosition) < 10 &&  Vector3.Angle(tempRigidbodyPosition - tempOtherRigidbodyPosition, rigidbody.transform.forward) > 5){
		currentSpeed = 0;
		topSpeed = -1;
		rigidbody.velocity = Vector3.zero;
		decellarationSpeed = 10000;	
	}
}

function OnTriggerExit(other: Collider) {
	OnTriggerExitSetSpeed();
}

function OnTriggerExitSetSpeed() {
	decellarationSpeed = tempdecellarationSpeed;
	topSpeed = temptopSpeed;
	currentSpeed = 10;
	wheelRL.motorTorque = maxTorque;  
	wheelRR.motorTorque = maxTorque;
	isBreaking = false;
}
 