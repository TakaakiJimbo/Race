
//You can set these variables in the scene because they are public 
public var RemoteIP : String = "127.0.0.1";
public var SendToPort : int = 57131;
public var ListenerPort : int = 57130;
public var controller : Transform; 
private var handler : Osc;



public function Start ()
{
	Debug.Log("Called Example One > ");	
	//Initializes on start up to listen for messages
	//make sure this game object has both UDPPackIO and OSC script attached
	var udp : UDPPacketIO = GetComponent("UDPPacketIO");
	udp.init(RemoteIP, SendToPort, ListenerPort);
	handler = GetComponent("Osc");
	handler.init(udp);
	handler.SetAddressHandler("/wii/1/button/1", Example1);
	handler.SetAddressHandler("/wii/1/accel/pry", Example2);
}
Debug.Log("Running");
//these fucntions are called when messages are received
public function Example1(oscMessage : OscMessage) : void
{	
	//How to access values: 
	//oscMessage.Values[0], oscMessage.Values[1], etc
	Debug.Log("Called Example One > " + Osc.OscMessageToString(oscMessage));
} 

//these fucntions are called when messages are received
public function Example2(oscMessage : OscMessage) : void 
{
	//How to access values: 
	//oscMessage.Values[0], oscMessage.Values[1], etc
	Debug.Log("Called Example Two > " + Osc.OscMessageToString(oscMessage));
} 
