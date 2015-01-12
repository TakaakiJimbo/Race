//#pragma strict
#pragma implicit
#pragma downcast
@script AddComponentMenu ("CarPhys/AIScripts/AICarScript")
var centerOfMass : Vector3; 

var obj : GameObject; // GameObject型
var FadeManager : GameObject; // GameObject型
var script : OSCReceiver; //ScriptB型(スクリプト名が型名になる)
var OSCvalueButton1 : boolean = false;
var OSCvalueButton2 : boolean = false;
var state : int = 0;
var stateTrigger : boolean = false;
var NewpathGroup : Transform;  

var path : Array;
var pathGroup : Transform;  
var maxSteer : float = 15.0; 

//var wheelFL : WheelCollider;   
//var wheelFR : WheelCollider;  
//var wheelRL : WheelCollider;   
//var wheelRR : WheelCollider;  

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
//	rigidbody.centerOfMass = centerOfMass;
	NewpathGroup = pathGroup;
	SetupOSC();	
	GetPath();  
}  
  
function SetupOSC()
{
	obj = GameObject.Find("OSC");
	script = obj.GetComponent(OSCReceiver);
}

function GetPath (){  
	currentPathObj = 0;
	var path_objs : Array = pathGroup.GetComponentsInChildren(Transform);  
	path = new Array();  
	for (var path_obj : Transform in path_objs){  
	  path.Add(path_obj);  
	}  
}  
 
//function EngineSound(){
//	for (var i = 0; i < gearRatio.length; i++){
//		if(gearRatio[i]> currentSpeed){
//			break;
//		}
//	}
//	var gearMinValue : float = 0.00;
//	var gearMaxValue : float = 0.00;
//	if (i == 0){
//		gearMinValue = 0;
//	}
//	else {
//		gearMinValue = gearRatio[i-1];
//	}
//	gearMaxValue = gearRatio[i];
//	var enginePitch : float = ((currentSpeed - gearMinValue)/(gearMaxValue - gearMinValue))+1;
//	audio.pitch = enginePitch;
//}

function Update () {
	GetSteer();
	if(stateTrigger){
		CheckState();
		ChangeDest();
	}
	GetInput();
	CheckNextStage();
	
//	if(isControll){
//		Move(); 
//	}
//	BreakingEffect ();  
//	EngineSound();
	
//	if(currentSpeed < 5){
//		temptimer++;
////		Debug.Log( gameObject.name + " : " + temptimer);
//	} else {
//		temptimer = 0;
//	}
//	if(temptimer > 70){
//		ResetAI();
//		temptimer = 0;
//	}
} 

function GetSteer(){  
	var inUse: Transform = path[currentPathObj]as Transform;

	var steerVector : Vector3 = transform.InverseTransformPoint(Vector3(inUse.position.x, inUse.position.y,inUse.position.z));	// check

//	transform.localPosition += (Vector3(inUse.position.x, inUse.position.y,inUse.position.z) - transform.localPosition)/20;

//	var newSteer : float = maxSteer * (steerVector.x / steerVector.magnitude);  
//	wheelFL.steerAngle = newSteer;  
//	wheelFR.steerAngle = newSteer; 

	if (currentPathObj < path.length-1){  
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(inUse.position - transform.position), 0.07f);
		transform.position += transform.forward * 5;
		if(steerVector.magnitude <= distFromPath){
			currentPathObj++;
		}
	}
	else{
		stateTrigger = true;
	}
}  

function CheckState()
{
	if(OSCvalueButton1)
	{
		stateTrigger = false;
		if(state == 0){
			GameObject.Find("TitleA").renderer.enabled = false;
			GameObject.Find("LeftA").renderer.enabled = false;
			GameObject.Find("RightA").renderer.enabled = false;
			state = 1;	//exit
		}
		else if(state == 2){
			state = 3;	// practice	
		}
	}
	else if(OSCvalueButton2)
	{
		stateTrigger = false;
		if(state == 0){
			GameObject.Find("TitleA").renderer.enabled = false;
			GameObject.Find("LeftA").renderer.enabled = false;
			GameObject.Find("RightA").renderer.enabled = false;
			state = 2;// next
		}
		else if(state == 2){
			state = 4;	// start
		}
	}
}

function ChangeDest(){
	switch(state){
		case 2:
			NewpathGroup = GameObject.Find("PathRouteA").gameObject.transform;
			break;
		case 3:
			NewpathGroup = GameObject.Find("PathRouteB").gameObject.transform;
			break;
		case 4:
			NewpathGroup = GameObject.Find("PathRouteC").gameObject.transform;
			break;
	}
	if(pathGroup != NewpathGroup){
		pathGroup = NewpathGroup;
		path.length = 0;	//            hairetu wo shokika sitakattakedo dekinakatta
		GetPath();
	}
}
//function ResetAI() {
//	transform.position += Vector3.up * 8;
//	transform.rotation = Quaternion.LookRotation(Vector3(1,0,0.3));
//	decellarationSpeed = tempdecellarationSpeed;
//	topSpeed = temptopSpeed;
//	currentSpeed = 10;
//	wheelRL.motorTorque = maxTorque;  
//	wheelRR.motorTorque = maxTorque;
//	isBreaking = false;
//}

function CheckNextStage()
{
	if(state == 1 ){
		Application.Quit();
	}
	if(state == 2 && stateTrigger)
	{
		GameObject.Find("TitleB").renderer.enabled = true;
		GameObject.Find("LeftB").renderer.enabled = true;
		GameObject.Find("RightB").renderer.enabled = true;
	}
	if(state == 3 ){
		GameObject.Find("TitleB").renderer.enabled = false;
		GameObject.Find("LeftB").renderer.enabled = false;
		GameObject.Find("RightB").renderer.enabled = false;
		gameObject.GetComponent("GoStagePractice").enabled = true;
	}
	if(state == 4 ){
		GameObject.Find("TitleB").renderer.enabled = false;
		GameObject.Find("LeftB").renderer.enabled = false;
		GameObject.Find("RightB").renderer.enabled = false;
		gameObject.GetComponent("GoStage2014").enabled = true;
	}
}

function GetInput()
{
//	GetOSC();
	OSCvalueButton1 = Input.GetKey("1");
	OSCvalueButton2 = Input.GetKey("2");
}

function GetOSC()
{
	if(script.Button1 > 0){
		OSCvalueButton1 = true;
	}
	else{
		OSCvalueButton1 = false;
	}
	if(script.Button2 > 0){
		OSCvalueButton2 = true;
	}
	else{
		OSCvalueButton2 = false;
	}
}
//function Move (){ 
//	if (currentSpeed <= topSpeed && !inSector){  
//		wheelRL.motorTorque = maxTorque;  
//		wheelRR.motorTorque = maxTorque;  
//		wheelRL.brakeTorque = 0;  
//		wheelRR.brakeTorque = 0;  
//	}  
//	else if (!inSector){  
//		wheelRL.motorTorque = 0;  
//		wheelRR.motorTorque = 0;  
//		wheelRL.brakeTorque = decellarationSpeed;
//		wheelRR.brakeTorque = decellarationSpeed;  
//	}  
//	currentSpeed = 2*(22/7) * 60 / 1000;   
//	currentSpeed = Mathf.Round (currentSpeed);
//}  
  
//function BreakingEffect (){  
//	if (isBreaking){  
//		breakingMesh.material = activeBreakLight;  
//	}  
//	else {  
//		breakingMesh.material = idleBreakLight;  
//	} 
//} 
//
//function OnTriggerEnter(other: Collider) {
//	if(other.tag == "Player"){
//		OnTriggerEnterSetSpeed();
//	}else if(other.tag == "AI"){
//		OnTriggerEnterSetSpeed();
//	}else if(other.tag == "AIPeople_collider"){
//		OnTriggerEnterSetSpeed();
//	}else if(other.tag == "signal_collider"){
//		OnTriggerEnterSetSpeed();
//	}
//}
//
//function OnTriggerEnterSetSpeed() {
//	topSpeed = 15;
//	isBreaking = true;
//	decellarationSpeed = 40;
//}
//
//function OnTriggerStay(other: Collider) {
//	if(other.tag == "Player"){
//		OnTriggerStaySetSpeed(other);
//	}else if(other.tag == "AI"){
//		OnTriggerStaySetSpeed(other);
//	}else if(other.tag == "AIPeople_collider"){
//		OnTriggerStaySetSpeed(other);
//	}else if(other.tag == "signal_collider"){
//		OnTriggerStaySetSpeed(other);
//	}
//}
//
//function OnTriggerStaySetSpeed(other: Collider){
//	tempRigidbodyPosition = rigidbody.position;
//	tempOtherRigidbodyPosition = other.rigidbody.position;
//	if((Vector3.Distance(tempRigidbodyPosition, tempOtherRigidbodyPosition) < 10) && (((tempRigidbodyPosition.z - tempOtherRigidbodyPosition.z) < 0))){
//		currentSpeed = 0;
//		topSpeed = -1;
//		decellarationSpeed = 10000;	
//	}
//}
//
//function OnTriggerExit(other: Collider) {
//	OnTriggerExitSetSpeed();
//}
//
//function OnTriggerExitSetSpeed() {
//	decellarationSpeed = tempdecellarationSpeed;
//	topSpeed = temptopSpeed;
//	currentSpeed = 10;
//	wheelRL.motorTorque = maxTorque;  
//	wheelRR.motorTorque = maxTorque;
//	isBreaking = false;
//}
 