using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Protobuf;

public class BufferControl : MonoBehaviour {

    LocalSocket localSocket;
    CarStats carStats = new CarStats();

	// Use this for initialization
	void Start ()
    {
        carStats.Speed = 10;
        print(carStats.Speed);
        localSocket = new LocalSocket();
	}
	
	// Update is called once per frame
	void Update ()
    {
        localSocket.Send(carStats.ToByteArray());
	}
}
