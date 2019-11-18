/// <summary>
///  You don't need this script it is only to show how to write a message to port.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoInteractions : MonoBehaviour {

	SerialControl serialController;
	//public string messageToSend;//message to be sent to serial device


    // Use this for initialization
    void Start() {
        serialController = GetComponent<SerialControl>();	//loads the SerialControl script from this gameObject into serialController.
        serialController.WriteToPort("sys_on" + "\r" + "\n");
    }
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown("1")){
			serialController.WriteToPort("wall_on" + "\r" + "\n"); //calls the WriteToPort function and sends a string to it.
		}
        if (Input.GetKeyDown("2"))
        {
            serialController.WriteToPort("wall_off" + "\r" + "\n"); 
        }

    }
}
