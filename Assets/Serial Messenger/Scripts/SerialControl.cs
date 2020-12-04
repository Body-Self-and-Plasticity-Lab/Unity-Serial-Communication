using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class SerialControl : MonoBehaviour {
	
	[Tooltip("The name of the serial port")]
	public string portName;//the COM Port

	private int baudRate = 9600;//Fixed to 9600 for the trigger box.
	SerialPort serialDevice;

    public static SerialControl instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }


    public void Initialize () {
        portName = PlayerPrefs.GetString("serial port name");

        //for COM ports > 10
        if (portName != "")
        {
            portName = portName.Remove(0, 3);

            int portNumber = int.Parse(portName);

            if (portNumber < 10)
                portName = "COM" + portNumber;
            else
                portName = "\\\\.\\" + "COM" + portNumber;
        }
        
        serialDevice = new SerialPort (portName, baudRate); //initializes a serial port
		if(serialDevice != null) serialDevice.Close (); //makes sure the device is closed before openning
		serialDevice.Open (); //opens serial device
	}

	public void WriteToPort(string message){
		if (serialDevice.IsOpen) {
			serialDevice.Write (message); //if the device is open, send string message when function is called.
			Debug.Log("sent message " + message); //writes message to console (this does not confirm that it was received)
		}
	}

	void OnDisable() {
        if (serialDevice.IsOpen)
            serialDevice.Close(); //close device when finished.
	}
}
