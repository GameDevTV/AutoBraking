using System;
using System.Collections;
using System.Collections.Generic;
using Google.Protobuf;
using UnityEngine;

public class SocketControl : MonoBehaviour
{
    LocalSocket localSocket;
    string lastInstruction, instructionCache;
    bool isJumpQueued = false;

     void Start()
    {
        Application.runInBackground = true;
        localSocket = new LocalSocket();

        SendCarStats();
    }

    public void SendCarStats()
    {
        CarStats carStats = new CarStats();
        carStats.Speed = 42;

        byte[] messageWithHeader = CreateMessageWithHeader(carStats);
        Debug.Log("Sending bytes with header: " + BitConverter.ToString(messageWithHeader));
        localSocket.Send(messageWithHeader);
    }

    private static byte[] CreateMessageWithHeader(CarStats carStats) // todo make more general
    {
        var rawMessageBytes = carStats.ToByteArray();
        int rawMessageSize = rawMessageBytes.Length;
        var messageWithHeader = new byte[rawMessageSize + 1];
        messageWithHeader[0] = BitConverter.GetBytes(rawMessageSize)[0];
        Buffer.BlockCopy(rawMessageBytes, 0, messageWithHeader, 1, rawMessageSize);
        return messageWithHeader;
    }

    private void Update()
    {
        if (!localSocket.isReadyToReceive) { return; }

        print("Ready to receive");
    }
}
