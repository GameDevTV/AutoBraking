using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Protobuf;
using System;

public class BufferControl : MonoBehaviour {

    LocalSocket localSocket;
    CarStats carStats = new CarStats();

	// Use this for initialization
	void Start ()
    {
        localSocket = new LocalSocket();

        carStats.Speed = Int32.MaxValue;
	}
	
	// Update is called once per frame
	void Update ()
    {
        var bytesToSend = carStats.ToByteArray().Length;
        // todo encode message length in bytes as 16 or 32 bit int
        // add this length to the start of the byte stream
        localSocket.Send(carStats.ToByteArray());
        print(bytesToSend);
        // on decode read this first, to know how much message to read
        // then decode
	}
}
