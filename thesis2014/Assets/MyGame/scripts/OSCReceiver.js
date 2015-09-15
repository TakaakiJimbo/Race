
//You can set these variables in the scene because they are public 
public var RemoteIP : String = "127.0.0.1";
public var SendToPort : int = 57131;
public var ListenerPort : int = 9000;
public var controller : Transform; 
private var handler : Osc;

public var Ex0 : float = 0;
public var Ex2 : float = 0;
public var ButtonA : float = 0;
public var Button1 : float = 0;
public var Button2 : float = 0;
public var ButtonUp : float = 0;
public var ButtonDown : float = 0;
public var ButtonLeft : float = 0;
public var ButtonRight : float = 0;
public var ButtonPlus : float = 0;
public var ButtonMinus : float = 0;

public function Start ()
{
	//Initializes on start up to listen for messages
	//make sure this game object has both UDPPackIO and OSC script attached
	var udp : UDPPacketIO = GetComponent("UDPPacketIO");
	udp.init(RemoteIP, SendToPort, ListenerPort);
	handler = GetComponent("Osc");
	handler.init(udp);
	handler.SetAddressHandler("/wii/1/accel/pry", Example);
	handler.SetAddressHandler("/wii/1/button/A", Example1);
	handler.SetAddressHandler("/wii/1/button/1", Example2);
	handler.SetAddressHandler("/wii/1/button/2", Example3);
	handler.SetAddressHandler("/wii/1/button/Up", Example4);
	handler.SetAddressHandler("/wii/1/button/Down", Example5);
	handler.SetAddressHandler("/wii/1/button/Left", Example6);
	handler.SetAddressHandler("/wii/1/button/Right", Example7);
	handler.SetAddressHandler("/wii/1/button/Plus", Example8);
	handler.SetAddressHandler("/wii/1/button/Minus", Example9);

}


//these fucntions are called when messages are received
public function Example(oscMessage : OscMessage) : void
{	
	//How to access values: 
	//oscMessage.Values[0], oscMessage.Values[1], etc
	Ex0 = oscMessage.Values[0];
	Ex2 = oscMessage.Values[2];
}

//these fucntions are called when messages are received
public function Example1(oscMessage : OscMessage) : void
{	
	//How to access values: 
	//oscMessage.Values[0], oscMessage.Values[1], etc
	ButtonA = oscMessage.Values[0];
}

//these fucntions are called when messages are received
public function Example2(oscMessage : OscMessage) : void
{	
	//How to access values: 
	//oscMessage.Values[0], oscMessage.Values[1], etc
	Button1 = oscMessage.Values[0];
}

//these fucntions are called when messages are received
public function Example3(oscMessage : OscMessage) : void
{	
	//How to access values: 
	//oscMessage.Values[0], oscMessage.Values[1], etc
	Button2 = oscMessage.Values[0];
}

//these fucntions are called when messages are received
public function Example4(oscMessage : OscMessage) : void
{	
	//How to access values: 
	//oscMessage.Values[0], oscMessage.Values[1], etc
	ButtonUp = oscMessage.Values[0];
}

//these fucntions are called when messages are received
public function Example5(oscMessage : OscMessage) : void
{	
	//How to access values: 
	//oscMessage.Values[0], oscMessage.Values[1], etc
	ButtonDown = oscMessage.Values[0];
}

//these fucntions are called when messages are received
public function Example6(oscMessage : OscMessage) : void
{	
	//How to access values: 
	//oscMessage.Values[0], oscMessage.Values[1], etc
	ButtonLeft = oscMessage.Values[0];
}

//these fucntions are called when messages are received
public function Example7(oscMessage : OscMessage) : void
{	
	//How to access values: 
	//oscMessage.Values[0], oscMessage.Values[1], etc
	ButtonRight = oscMessage.Values[0];
}

//these fucntions are called when messages are received
public function Example8(oscMessage : OscMessage) : void
{	
	//How to access values: 
	//oscMessage.Values[0], oscMessage.Values[1], etc
	ButtonPlus = oscMessage.Values[0];
}

//these fucntions are called when messages are received
public function Example9(oscMessage : OscMessage) : void
{	
	//How to access values: 
	//oscMessage.Values[0], oscMessage.Values[1], etc
	ButtonMinus = oscMessage.Values[0];
}