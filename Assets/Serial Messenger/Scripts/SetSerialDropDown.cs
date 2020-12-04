using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class SetSerialDropdown : MonoBehaviour
{
    public Dropdown serialDropdown;

    // Use this for initialization
    void Start()
    {
        SetSerialDropDownOptions();
    }

    //added 
    public void SetSerialDropDownOptions()
    {

        serialDropdown.options.Clear();

        List<string> ports = new List<string>();
        foreach (string c in SerialPort.GetPortNames())
        {
            ports.Add(c);
        }

        serialDropdown.AddOptions(ports);
        serialDropdown.value = PlayerPrefs.GetInt("serial port");
    }

    public void GetSerialDropDownOptions(){
        Debug.Log("changed");
        PlayerPrefs.SetString("serial port name", serialDropdown.options[serialDropdown.value].text);
        Debug.Log(PlayerPrefs.GetString("serial port name"));
        SerialControl.instance.Initialize();
        SerialControl.instance.WriteToPort("8");
    }
}
